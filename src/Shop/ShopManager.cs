using System;
using System.Web;
using System.Collections;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using AccessControl;
namespace Shop
{
   public class ShopManager
   {
      public static string show_item_descr(System.Data.SqlClient.SqlConnection conn, System.Web.HttpRequest req, System.Data.SqlClient.SqlTransaction tr)
      {
         SqlCommand cmd=conn.CreateCommand();
         cmd.Transaction = tr;
         cmd.CommandText=String.Format("select descr from shop_item where guididx='{0}';",req["guididx"]);
         System.Object obj=cmd.ExecuteScalar();
         String value=obj.GetType()==typeof(System.DBNull)?"":obj.ToString();
      
         string ret=String.Format(@"<div>
<form name='item_descr' action='1.axp' method='get' onsubmit='javascript:save_text({0}); return false;'>
<textarea id='HereIsTheText'> {1}</textarea></form>
</div>",
"\""+req["guididx"]+"\"",value);
         
         return ret;
      }

      public static string save_item_descr(System.Data.SqlClient.SqlConnection conn, System.Web.HttpRequest req, System.Data.SqlClient.SqlTransaction tr)
      {
         string descr=req["descr"];
         System.Guid guididx=new System.Guid(req["guididx"]);
         
         
         SqlCommand cmd = conn.CreateCommand();
         cmd.Transaction=tr;
         
         cmd.CommandText=String.Format("update shop_item set descr='{1}' where guididx='{0}';",req["guididx"],req["descr"]);
         cmd.ExecuteNonQuery();
         
         return "ok";
      }
      
      
      public static string format_row(System.Collections.Hashtable ht)
      {
         return "<tr><td>["+(((int)ht["type"]==1)?"sub":"test")+"]</td><td>"+ht["name"]+"</td><td><input type='checkbox' name='idx_"+ht["type"]+"_"+ht["idx"]+"' "+((ht["bound"].GetType()==typeof(DBNull))?"":"checked") +" ></td></tr>";
      }
      public static string show_item_cont(System.Data.SqlClient.SqlConnection conn, System.Web.HttpRequest req,System.Data.SqlClient.SqlTransaction tr)
      {
         System.Guid guididx = new System.Guid(req["guididx"]);
         System.Collections.ArrayList arr = new System.Collections.ArrayList();
         {
            SqlCommand cmd=conn.CreateCommand();
            cmd.Transaction=tr;
            
            cmd.CommandText=String.Format(
            @"
            select shop_item.idx,shop_item.name,selected.idx from shop_item left join 
            (select idx,name from shop_item where parent_idx=(select idx from shop_item where guididx='{0}') ) as selected
            on (shop_item.idx=selected.idx) 
            where shop_item.guididx!='{0}'
            order by shop_item.idx
            "
            , guididx);
            SqlDataReader reader=cmd.ExecuteReader();
            try
            {
               while (reader.Read())
               {
                  System.Collections.Hashtable ht=new System.Collections.Hashtable();
                  ht["idx"]=reader[0];
                  ht["name"]=reader[1];
                  ht["bound"] = reader[2];
                  ht["type"]=1;
                  arr.Add(ht);   
               }
               reader.Close();
            }
            catch(System.Exception )
            {
               reader.Close();
            }
         }

         {
            SqlCommand cmd = conn.CreateCommand();
            cmd.Transaction=tr;
            
            cmd.CommandText = String.Format(
            @"select Tests.id,Tests.name,shop_item_tests.idx from Tests   
                left  join shop_item_tests on 
                (Tests.Id=shop_item_tests.test_idx and shop_item_tests.idx = (select idx from shop_item where guididx='{0}') )
                order by Tests.id
                ;"
                , guididx);
                
            SqlDataReader reader = cmd.ExecuteReader();
            try
            {
               while (reader.Read())
               {
                  System.Collections.Hashtable ht = new System.Collections.Hashtable();
                  ht["idx"] = reader[0];
                  ht["name"] = reader[1];
                  ht["bound"] = reader[2];
                  ht["type"]=2;
                  arr.Add(ht);
               }
               reader.Close();
            }
            catch (System.Exception )
            {
               reader.Close();
            }
         }
         
         string ret="<form name='bindings_form'><table border=0><tr><td colspan=3> <b>Contents of:"+req["name"]+"</td></tr>";
         foreach (System.Collections.Hashtable ht in arr)
         {
            ret+=format_row(ht);
         }
         ret+="</table></br>";
         ret+="<input type='hidden' name='name' value='"+req["name"]+"'/>";
         ret+="<input type='button' name='submit_bindings_props' value='Apply bindings' class='itt' onclick='javascript: handle_apply_binds(\""+guididx+"\");'></form>";
         
         return ret;
      }

      public static string apply_contents(System.Data.SqlClient.SqlConnection conn, System.Web.HttpRequest req, AccessControl.AccessManager access_manager, System.Data.SqlClient.SqlTransaction tr)
      {
         System.Guid guididx = new System.Guid(req["guididx"]);
         SqlCommand cmd=conn.CreateCommand();
         cmd.Transaction=tr;
         
         cmd.CommandText=String.Format(
         @"
            delete from shop_item_tests where idx=(select idx from shop_item where guididx='{0}');
            update shop_item set parent_idx=null where parent_idx=(select idx from shop_item where guididx='{0}');
            
         "
         , guididx);
         System.Collections.Generic.List<int> tests=new System.Collections.Generic.List<int> ();
         for (int i = 0; i < req.Params.Keys.Count; ++i)
         {
            string key = req.Params.Keys[i];
            if (key.IndexOf("idx_", 0) == 0)
            {
               string[] a=key.Substring(4).Split('_');
               if (a[0] == "1")
               {
                  cmd.CommandText += String.Format("update shop_item set parent_idx=(select idx from shop_item where guididx='{0}') where idx={1};\n", guididx, a[1]);
               }
               if(a[0]=="2") 
               {
                  cmd.CommandText+=String.Format("insert into shop_item_tests (test_idx,idx) select {1},idx from shop_item where guididx='{0}';\n",guididx,a[1]);
                  tests.Add(Int32.Parse(a[1]));
               }
            }
         }

         cmd.ExecuteNonQuery();
         
         
         foreach(int testid in tests)
         {
            access_manager.check_function_and_group(String.Format("test_{0}",testid), get_test_name_by_id_(conn,tr,testid));
         }
         
         return show_item_cont(conn,req,tr);
      }

      static string get_test_name_by_id_(System.Data.SqlClient.SqlConnection conn, System.Data.SqlClient.SqlTransaction tr, int test_id)
      {
         SqlCommand cmd = conn.CreateCommand();
         cmd.Transaction = tr;
         cmd.CommandText = String.Format("select name from Tests where id={0};",test_id);
         return cmd.ExecuteScalar().ToString();
      }
   }
}
