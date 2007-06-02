using System;
using System.Web;
using System.Collections;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using AccessControl;
using log4net;
namespace Shop
{
   public class ShopManager
   {
       public static string item_click(System.Data.SqlClient.SqlConnection conn, System.Web.HttpRequest req, AccessControl.AccessManager access_manager, System.Data.SqlClient.SqlTransaction tr,string success_url,string fail_url)
      {
         int idx=Int32.Parse(req["idx"]);
         string type=req["type"];
         int pkg = Int32.Parse(req["pkg_idx"]);
         if (pkg == -1) pkg = idx;

         try
         {
            //check_sold_item(access_manager, idx, type, pkg);
            return String.Format(success_url, idx, type, pkg);
         }
         catch(System.Exception)
         {
            return String.Format(fail_url, idx, type, pkg);         
         }
      }
   
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
         string rt="sub";
         if((int)ht["type"]==2) rt="test";
         if((int)ht["type"]==3) rt="pdf";
         
         return "<tr><td>["+rt+"]</td><td>"+ht["name"]+"</td><td><input type='checkbox' name='idx_"+ht["type"]+"_"+ht["idx"]+"' "+((ht["bound"].GetType()==typeof(DBNull))?"":"checked") +" ></td></tr>";
      }

      public static System.Collections.ArrayList get_item_cont_by_idx(System.Data.SqlClient.SqlConnection conn, System.Data.SqlClient.SqlTransaction tr, int idx)
      {
         SqlCommand cmd=conn.CreateCommand();
         cmd.CommandText="select guididx from shop_item where idx="+idx.ToString()+";";
         return get_item_cont_by_guididx(conn,tr,new Guid(cmd.ExecuteScalar().ToString()));
      }
      
      public static System.Collections.ArrayList get_item_cont_by_guididx(System.Data.SqlClient.SqlConnection conn, System.Data.SqlClient.SqlTransaction tr, Guid guididx)
      {
         System.Collections.ArrayList arr = new System.Collections.ArrayList();
         {
            SqlCommand cmd = conn.CreateCommand();
            cmd.Transaction = tr;

            cmd.CommandText = String.Format(
            @"
            select shop_item.idx,shop_item.name,selected.idx from shop_item left join 
            (select idx,name from shop_item where parent_idx=(select idx from shop_item where guididx='{0}') ) as selected
            on (shop_item.idx=selected.idx) 
            where shop_item.guididx!='{0}'
            order by shop_item.idx
            "
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
                  ht["type"] = 1;
                  arr.Add(ht);
               }
               reader.Close();
            }
            catch (System.Exception)
            {
               reader.Close();
            }
         }

         {
            SqlCommand cmd = conn.CreateCommand();
            cmd.Transaction = tr;

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
                  ht["type"] = 2;
                  arr.Add(ht);
               }
               reader.Close();
            }
            catch (System.Exception)
            {
               reader.Close();
            }
         }

         {
            SqlCommand cmd = conn.CreateCommand();
            cmd.Transaction = tr;

            cmd.CommandText = String.Format(        
            @"select pdf_download.idx,pdf_download.name,shop_item_pdfs.idx from pdf_download   
                left join shop_item_pdfs on 
                (pdf_download.idx=shop_item_pdfs.pdf_idx and shop_item_pdfs.idx = (select idx from shop_item where guididx='{0}') )
                order by pdf_download.idx
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
                  ht["type"] = 3;
                  arr.Add(ht);
               }
               reader.Close();
            }
            catch (System.Exception)
            {
               reader.Close();
            }
         }
         
         return arr;
      }
      
      public static string show_item_cont(System.Data.SqlClient.SqlConnection conn, System.Web.HttpRequest req,System.Data.SqlClient.SqlTransaction tr)
      {
         System.Guid guididx = new System.Guid(req["guididx"]);
         System.Collections.ArrayList arr=get_item_cont_by_guididx(conn,tr,guididx);
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
            delete from shop_item_pdfs where idx=(select idx from shop_item where guididx='{0}');
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
               if(a[0]=="3")
               {
                  cmd.CommandText += String.Format("insert into shop_item_pdfs (pdf_idx,idx) select {1},idx from shop_item where guididx='{0}';\n", guididx, a[1]);
                  tests.Add(Int32.Parse(a[1]));
               }
            }
         }

         cmd.ExecuteNonQuery();
         
         
         /*foreach(int testid in tests)
         {
            access_manager.check_function_and_group(String.Format("test_{0}",testid), get_test_name_by_id_(conn,tr,testid));
         } */
         
         return show_item_cont(conn,req,tr);
      }

      public static string get_package_name_id_(System.Data.SqlClient.SqlConnection conn, System.Data.SqlClient.SqlTransaction tr, int idx)
      {
         SqlCommand cmd = conn.CreateCommand();
         cmd.Transaction = tr;
         cmd.CommandText = String.Format("select name from shop_item where idx={0};", idx);
         return cmd.ExecuteScalar().ToString();
      }

      public static string get_test_name_by_id_(System.Data.SqlClient.SqlConnection conn, System.Data.SqlClient.SqlTransaction tr, int test_id)
      {
         SqlCommand cmd = conn.CreateCommand();
         cmd.Transaction = tr;
         cmd.CommandText = String.Format("select name from Tests where id={0};",test_id);
         return cmd.ExecuteScalar().ToString();
      }

      public static string get_download_name_by_id_(System.Data.SqlClient.SqlConnection conn, System.Data.SqlClient.SqlTransaction tr, int idx)
      {
         SqlCommand cmd = conn.CreateCommand();
         cmd.Transaction = tr;
         cmd.CommandText = String.Format("select name from pdf_download where idx={0};", idx);
         return cmd.ExecuteScalar().ToString();
      }

      public static System.Decimal get_package_price_(System.Data.SqlClient.SqlConnection conn, System.Data.SqlClient.SqlTransaction tr, int idx)
      {
         SqlCommand cmd = conn.CreateCommand();
         cmd.Transaction = tr;
         cmd.CommandText = String.Format("select full_price from shop_item where idx={0};", idx);
         Object o=cmd.ExecuteScalar();
         return typeof(System.DBNull) == o.GetType() || null == o ? new System.Decimal(0) : System.Decimal.Parse(o.ToString());
      }

      public static System.Decimal get_package_item_price_(System.Data.SqlClient.SqlConnection conn, System.Data.SqlClient.SqlTransaction tr, int idx)
      {
         SqlCommand cmd = conn.CreateCommand();
         cmd.Transaction = tr;
         cmd.CommandText = String.Format("select item_price from shop_item where idx={0};", idx);
         Object o = cmd.ExecuteScalar();
         return typeof(System.DBNull) == o.GetType() || null == o ? new System.Decimal(0) : System.Decimal.Parse(o.ToString());
      }

      public static System.Decimal get_product_price(System.Data.SqlClient.SqlConnection conn, int idx, string type, int package_idx)
      {
         if ("group" == type)
         {
            return get_package_price_(conn, null, idx); ;
         }
         else if ("test" == type)
         {
            return get_package_item_price_(conn, null, package_idx); ;
         }
         else if (type == "download")
         {
            return get_package_item_price_(conn, null, package_idx); ;
         }
         throw new SystemException("No such type: " + type);
      }
      
      public static string get_product_description(System.Data.SqlClient.SqlConnection conn, int idx, string type, int package_idx)
      {
         if ("group" == type)
         {
            return "package '" + Shop.ShopManager.get_package_name_id_(conn, null, idx)+"'";
         }
         else if ("test" == type)
         {
            return "test '" + Shop.ShopManager.get_test_name_by_id_(conn, null, idx)+"'" ;
         }
         else if (type == "download")
         {
            return "resource download: '" + Shop.ShopManager.get_download_name_by_id_(conn, null, idx)+"'";
         }
         throw new SystemException("No such type: "+type);
      }


      public static void purchase(AccessControl.AccessManager mgr,int idx, string type, int package_idx, decimal payed)
      {
         purchase_(mgr, mgr.Connection, mgr.UserGuid, idx, type, package_idx, payed);
      }

      protected static void purchase_(AccessControl.AccessManager mgr,IDbConnection conn, Guid guididx, int idx, string type,int package_idx, decimal payed)
      {
         
         string s=String.Format("item_{0}_{1}",type,idx);

         
         shop_itemTableAdapters.shop_itemTableAdapter sh_it_ta = new shop_itemTableAdapters.shop_itemTableAdapter();
         sh_it_ta.SqlConnection = (System.Data.SqlClient.SqlConnection)(conn);

         shop_sold_itemTableAdapters.shop_sold_itemTableAdapter sh_sit_ta = new shop_sold_itemTableAdapters.shop_sold_itemTableAdapter();
         sh_sit_ta.SqlConnection = (System.Data.SqlClient.SqlConnection)(conn);

         shop_item.shop_itemDataTable p = sh_it_ta.GetRowByIdx(package_idx);
         if (p.Rows.Count == 0) throw new System.Exception("No such item to purchase");

         shop_sold_item.shop_sold_itemDataTable sh_sit = sh_sit_ta.GetData();
         shop_sold_item.shop_sold_itemDataTable p_sit = sh_sit_ta.GetByItt(package_idx, 1, guididx);
         int prnt_idx = -1;
         // if item bought from a package we must select a package idx to bind to
         if (p_sit.Rows.Count != 0)
         {
            prnt_idx = p_sit[0].idx;
         }
         
         string name="";
         if("group"==type)
         {
            name = "Access to package: " + get_package_name_id_((System.Data.SqlClient.SqlConnection)conn, null, idx);

            int pidx_ = -1;
            
            if (p[0]["parent_idx"].GetType() != typeof(System.DBNull))
            {
               pidx_ = p[0].parent_idx;    
            }

            sh_sit.Addshop_sold_itemRow(p[0].idx, DateTime.Now, DateTime.Now.AddMinutes(p[0].expires_after), 0, p[0].limit, guididx, (int)1, 0, p[0].name, pidx_,payed);
            payed=0;

            int prn = sh_sit[sh_sit.Rows.Count - 1].idx;

            {
               mgr.check_function_and_group(s, "Access to " + name);
               mgr.grant_access_to_function(s);
            }

            // for unlimited package we must grant access to all it's contents            
            if (p[0].limit==0)
            {
               System.Collections.ArrayList arr = get_item_cont_by_idx((System.Data.SqlClient.SqlConnection)(conn), null, idx);
               foreach (System.Collections.Hashtable i in arr)
               {
                  if(i["bound"]==null) continue;
                  if(i["bound"].GetType()==typeof(System.DBNull)) continue;
                  if((int)i["bound"]!=idx) continue;
                  if((int)i["type"]==2)
                  {
                     name = "Test: " + get_test_name_by_id_((System.Data.SqlClient.SqlConnection)conn, null, (int)i["idx"]);
                     string f = String.Format("item_{0}_{1}", "test", i["idx"]);
                     mgr.check_function_and_group(f, name);
                     mgr.grant_access_to_function(f);
                     //LogManager.GetLogger("Shop.purchase").WarnFormat("Access granted for '{0}' to {1}", mgr.UserLogin, name);
                     sh_sit.Addshop_sold_itemRow((int)i["idx"], DateTime.Now, DateTime.Now.AddMinutes(p[0].expires_after), 0, 0, guididx, (int)2, prn, i["name"].ToString(), p[0].idx,0);
                  }
                  if((int)i["type"]==3)
                  {
                     name = "Download: " + get_download_name_by_id_((System.Data.SqlClient.SqlConnection)conn, null, (int)i["idx"]);
                     string f = String.Format("item_{0}_{1}", "download", i["idx"]);
                     mgr.check_function_and_group(f, name);
                     mgr.grant_access_to_function(f);                                                                         
                     sh_sit.Addshop_sold_itemRow((int)i["idx"], DateTime.Now, DateTime.Now.AddMinutes(p[0].expires_after), 0, 0, guididx, (int)3, prn, i["name"].ToString(),p[0].idx,0);
                     //LogManager.GetLogger("Shop.purchase").WarnFormat("Access granted for '{0}' to {1}", mgr.UserLogin, name);
                  }
               }
            }
         }
         
         else if("test"==type)
         {
            string nme=get_test_name_by_id_((System.Data.SqlClient.SqlConnection)conn, null, idx);
            sh_sit.Addshop_sold_itemRow(idx, DateTime.Now, DateTime.Now.AddMinutes(p[0].expires_after), 0, 0, guididx, (int)2, prnt_idx, nme, p[0].idx,payed);

            name = "Test: " + nme;
            mgr.check_function_and_group(s, name);
            mgr.grant_access_to_function(s);            
            
         }
         else if("download"==type)
         {
            string nme = get_download_name_by_id_((System.Data.SqlClient.SqlConnection)conn, null, idx);
            sh_sit.Addshop_sold_itemRow(idx, DateTime.Now, DateTime.Now.AddMinutes(p[0].expires_after), 0, 0, guididx, (int)3, prnt_idx, nme, p[0].idx,payed);
            name = "Download: " + nme ;
            mgr.check_function_and_group(s, name);
            mgr.grant_access_to_function(s);            
         }
         else
         {
            throw new System.Exception(String.Format("Unknown type: '{0}'",type));
         }
         
         sh_sit_ta.Update(sh_sit);
      }

      public static int type2code(string repr)
      {
         if (repr == "group") return 1;
         if (repr == "test") return 2;
         if (repr == "download") return 3;
         throw new System.Exception("Error type: " + repr);
      }
      
      public static string code2type(int repr)
      {
         if (repr == 1) return "group";
         if (repr == 2) return "test";
         if (repr == 3) return "download";
         throw new System.Exception("Error type: " + repr.ToString());
      }
      public static void check_sold_item(AccessControl.AccessManager mgr, int idx, string type, int package_idx)
      {
         shop_itemTableAdapters.shop_itemTableAdapter ta=new shop_itemTableAdapters.shop_itemTableAdapter();
         ta.SqlConnection = (System.Data.SqlClient.SqlConnection)mgr.Connection;
         
         Shop.shop_sold_itemTableAdapters.shop_sold_itemTableAdapter si_ta = new Shop.shop_sold_itemTableAdapters.shop_sold_itemTableAdapter();
         si_ta.SqlConnection = (System.Data.SqlClient.SqlConnection)mgr.Connection;


         shop_item.shop_itemDataTable p = ta.GetRowByIdx(package_idx);
         if (0==p.Rows.Count)
         {
            throw new System.Exception("Has no such package");
         }

         Shop.shop_sold_item.shop_sold_itemDataTable psi = si_ta.GetByItt(package_idx, type2code("group"), mgr.UserGuid);
         if (psi.Rows.Count == 0 && "group" == type)
         {
            throw new System.Exception("Package was not bought");
         }

         if(type!="group")
         {
            Shop.shop_sold_item.shop_sold_itemDataTable csi = si_ta.GetByItt(idx, type2code(type), mgr.UserGuid);
            // let's merge 

            foreach (Shop.shop_sold_item.shop_sold_itemRow r in csi)
            {
               if (r.sold_at == r.expires_at)
               {
                  csi[0].sold_at = csi[0].expires_at;
               }
            }

            if (p[0].limit != 0)
            {
               if (psi.Rows.Count == 0)
               {
                  throw new System.Exception("Unexpected condition");
               }
               bool has_nb = false;
               if (csi.Rows.Count != 0)
               {
                  foreach (Shop.shop_sold_item.shop_sold_itemRow i in csi)
                  {
                     if(i.parent==psi[0].idx)
                     {
                        has_nb = true;
                     }
                  }
               }

               if (!has_nb)
               {
                  // item is selected from the limited package
                  if (psi[0].use_count == psi[0].sold_count)
                  {
                     throw new System.Exception("Limit reached");
                  }
                  purchase(mgr, idx, type, package_idx,0);
                  psi[0].use_count++;
                  si_ta.Update(psi);
                  return;
               }

            }
            return;
            if (csi.Rows.Count == 0)
            {
               throw new System.Exception("Item was not bought");
            }
         
            if (csi[0].expires_at < DateTime.Now && csi[0].expires_at != csi[0].sold_at)
            {
               mgr.revoke_access_to_function(String.Format("item_{0}_{1}", type, idx ));
               throw new System.Exception("Access time was expired");
            }
         }
      }
      public static string build_left(object obj_)
      {
         string ret = "";
         System.Data.DataRowView sir = (System.Data.DataRowView)obj_;
         if ((int)sir["sold_count"] != 0 && (int)sir["type"] == 1)
         {
            ret += ((int)sir["sold_count"] - (int)sir["use_count"]).ToString() + " item(s)";

         }


         if ((DateTime)sir["sold_at"] != (DateTime)sir["expires_at"] &&
            (DateTime)sir["expires_at"] > DateTime.Now && (int)sir["sold_count"] == 0)
         {
            if ("" != ret)
            {
               ret += "<br/>";
            }
            System.TimeSpan tt = ((DateTime)sir["expires_at"] - DateTime.Now);
            int days = tt.Days;
            int hors = tt.Hours;
            int mins = tt.Minutes;
            if (days != 0) ret += days.ToString() + "d, ";
            if (hors != 0) ret += hors.ToString() + "h, ";
            if (mins != 0) ret += mins.ToString() + "m ";

         }

         return ret;

      }

      public static Shop.shop_sold_item sort_sold_items(Shop.shop_sold_item sold_items)
      {
         Shop.shop_sold_item sold_items_sorted = new Shop.shop_sold_item();
         System.Collections.SortedList used = new System.Collections.SortedList();
         for (int i = 0; i < sold_items._shop_sold_item.Rows.Count; ++i)
         {
            Shop.shop_sold_item.shop_sold_itemRow row = sold_items._shop_sold_item[i];
            if (used.ContainsKey(row.idx)) continue;
            if (row.type == 1)
            {
               sold_items_sorted._shop_sold_item.ImportRow(row);
               foreach (Shop.shop_sold_item.shop_sold_itemRow r in sold_items._shop_sold_item.Rows)
               {
                  if (r.parent == row.idx)
                  {
                     sold_items_sorted._shop_sold_item.ImportRow(r);
                     used[r.idx] = 1;
                  }
               }
            }
            else
            {
               sold_items_sorted._shop_sold_item.ImportRow(row);
            }
         }
         return sold_items_sorted;
      }


      public static string delete_bought_items(System.Data.SqlClient.SqlConnection conn, System.Web.HttpRequest req, AccessControl.AccessManager access_manager, System.Data.SqlClient.SqlTransaction tr)
      {
         System.Collections.Generic.List<int> lst = new System.Collections.Generic.List<int>();
         
         foreach (string key in req.Params.AllKeys)
         {
            if (key.IndexOf("to_del_idx_") != 0) continue;
            lst.Add(Int32.Parse(req[key]));
         }
         if (lst.Count != 0)
         {
            SqlCommand cmd = conn.CreateCommand();
            cmd.Transaction = tr;
            foreach (int idx in lst)
            {
               cmd.CommandText += String.Format("delete from shop_sold_item where idx={0};", idx);
            }
            cmd.ExecuteNonQuery();
         }
         
         return show_user_basket(conn, req, access_manager, tr);
      }

      protected static string build_pdescr(Shop.shop_item.shop_itemRow r,Shop.binded_tests bt)
      {
         string ret = "";
         ret+="<tr>";
         //if (r.rdr == -1)
         {
            string v = r.idx.ToString() + "_1_" + r.idx.ToString();
            string n = "buy_it_" + r.idx.ToString() + "_1_" + r.idx.ToString();
            ret += "<td><input type='checkbox' name='"+n+"' value='"+v+"'></td>";
         }

         ret+=("<td> <img src='i/package.gif' width='16' height='16'/>"+r.name+"</td>");
         ret+="</tr>";
         
         foreach (binded_tests.binded_testsRow i in bt._binded_tests.Rows)
         {
               
            if (i.idx == r.idx)
            {
               
               if (i["ch_name"]!=null && i["ch_name"].GetType() != typeof(System.DBNull))
               {
                  string img = "package.gif";
                  if (i.type == 2) img = "test.gif";
                  if (i.type == 3) img = "pdf.gif";

                  string v = "";
                  // this is a hack for those packages who are members of sub package
                  if (i.type == 1)
                  {
                     v = i.chidx.ToString() + "_" + i.type.ToString() + "_" + i.chidx.ToString();
                  }
                  else
                  {
                     v = i.chidx.ToString() + "_" + i.type.ToString() + "_" + i.idx.ToString();
                  }
                  string n = "buy_it_" + i.chidx.ToString() + "_" + i.type.ToString() + "_" + i.idx.ToString();

                  ret += "<tr><td><input type='checkbox' name='"+n+"' value='" + v + "'/></td><td>&nbsp;&nbsp;<img src='i/" + img + "' width='16' height='16'/>" + i.ch_name + "</td></tr>";
               }
            }
         }

         return ret;
      }

      public static string show_user_basket(System.Data.SqlClient.SqlConnection conn, System.Web.HttpRequest req, AccessControl.AccessManager access_manager, System.Data.SqlClient.SqlTransaction tr)
      {
         

         System.Guid guididix = new System.Guid(req["guididx"]);
         
         Shop.shop_sold_item sold_items = new Shop.shop_sold_item();
         Shop.shop_sold_itemTableAdapters.shop_sold_itemTableAdapter ta = new Shop.shop_sold_itemTableAdapters.shop_sold_itemTableAdapter();
         ta.Connection = (System.Data.SqlClient.SqlConnection)access_manager.Connection;
         ta.FillByOwner(sold_items._shop_sold_item, guididix);

         Shop.shop_sold_item sold_items_sorted = sort_sold_items(sold_items);

         string left = "<form name='to_delete_items'><table border=0 cellpadding=0 cellspacing=0>";

         left += "<tr><td colspan='5'>Bought items</td></tr>";
         

         foreach (Shop.shop_sold_item.shop_sold_itemRow r in sold_items_sorted._shop_sold_item)
         {
            left += "<tr>";
            left += String.Format("<td><input type='checkbox' class='itt' style='border: none;' value='{0}' name='to_del_idx_{0}'/></td>", r.idx);
            left += String.Format("<td><img width='16' height='16' src='i/{0}'/></td>", (r.is_expired() || r.is_depleted())?"expired.gif":"blank.gif");
            string img= String.Format("<img width='16' height='16' src='i/{0}'/>", ((r.type==1) ? "package.gif":(r.type==2?"test.gif":"pdf.gif")));
            
            if (r.type != 1 && r.parent != -1)
            {
               left += "<td width='10'>&nbsp;</td><td>" + img+ r.name + "</td>";
            }
            else
            {
               left += "<td colspan='2'>" + img + r.name + "</td>";
            }
            left += "</tr>";
         }
         if(sold_items_sorted._shop_sold_item.Rows.Count!=0)
         {
            left += "<tr><td colspan='5'><input value='Delete' type='button' style='itt' onclick='javascript:delete_bought_items();'></td></tr>";
         }

         left += "<tr><td colspan='5'><input type='hidden' name='guididx' value='"+guididix.ToString()+"'/></td></tr>";
         left += "</table></form>";

         //////////////////////////////////////////////////////////////////////////////////////////////

         string right = "<form name='to_purchase_items'><table border=0 cellpadding=0 cellspacing=0>";

         right += "<tr><td colspan='2'>Shop items</tr>";
         Shop.binded_tests bt=new Shop.binded_tests();
         Shop.binded_testsTableAdapters.binded_testsTableAdapter bta = new Shop.binded_testsTableAdapters.binded_testsTableAdapter();
         bta.Connection = conn;
         bta.Fill(bt._binded_tests);

         Shop.shop_item sh= new Shop.shop_item ();
         Shop.shop_itemTableAdapters.shop_itemTableAdapter sha=new Shop.shop_itemTableAdapters.shop_itemTableAdapter(); 
         sha.Connection = conn;
         sha.Fill(sh._shop_item);

         foreach (shop_item.shop_itemRow r in sh._shop_item.Rows)
         {
            right += build_pdescr(r,bt);
         }


         right += "<tr><td colspan='2'><input value='Add to user' type='button' style='itt' onclick='javascript:add_selected_items();'></td></tr>";
         if (sh._shop_item.Rows.Count != 0)
         {
            right += "<tr><td colspan='2'><input type='hidden' name='guididx' value='" + guididix.ToString() + "'/></td></tr>";
         }
         right += "</table></form>";
         //////////////////////////////////////////////////////////////////////////////////////////////
         return "<table width='100%' border=0><tr><td valign='top' width='50%'>" + left + "</td><td width='50%' valign='top'>" + right + "</td></tr></table>";
      }

      public static string purchase_items(System.Data.SqlClient.SqlConnection conn, System.Web.HttpRequest req, AccessControl.AccessManager access_manager, System.Data.SqlClient.SqlTransaction tr)
      {
         Guid guididx = new Guid(req["guididx"]);

         foreach (string key in req.Params.AllKeys)
         {
            if (key.IndexOf("buy_it_") != 0) continue;
            //lst.Add(Int32.Parse(req[key]));
            String[] spl=req[key].Split('_');

            purchase_(access_manager,access_manager.Connection, guididx,Int32.Parse(spl[0]), code2type(Int32.Parse(spl[1])), Int32.Parse(spl[2]),0);

         }
         return show_user_basket(conn, req, access_manager, tr);
      }
      
      public static void create_transaction(System.Data.SqlClient.SqlConnection conn,Guid tr_idx,int idx, string type, int package_idx,Decimal money)
      {
         Shop.shop_transactionTableAdapters.shop_transactionTableAdapter ta=new Shop.shop_transactionTableAdapters.shop_transactionTableAdapter();
         ta.Connection=conn;
         ta.Insert(tr_idx,money,DateTime.Now,DateTime.Now,0,idx,type,package_idx,"");
      }
      
      public static string complite_transaction(AccessControl.AccessManager mgr,Guid tr_idx,Decimal money,string url_template)
      {
         Shop.shop_transaction ds=new Shop.shop_transaction ();
         Shop.shop_transactionTableAdapters.shop_transactionTableAdapter ta = new Shop.shop_transactionTableAdapters.shop_transactionTableAdapter();
         ta.Connection=(System.Data.SqlClient.SqlConnection)mgr.Connection;
         ta.FillByIdx(ds._shop_transaction,tr_idx);
         if(ds._shop_transaction.Rows.Count==0)
         {
            throw new System.Exception("No such transaction: "+tr_idx.ToString());
         }
         if(ds._shop_transaction[0].amount!=money)
         {
            throw new System.Exception("You pay - " + money.ToString() + " but must - " + ds._shop_transaction[0].amount.ToString());
         }
         ds._shop_transaction[0].complited=DateTime.Now;
         ds._shop_transaction[0].state=1;
         ta.Update(ds._shop_transaction[0]);

         String type = ds._shop_transaction[0].type.Trim();
         
         purchase(mgr,ds._shop_transaction[0].idx,type,ds._shop_transaction[0].package_idx,ds._shop_transaction[0].amount);
         
         return String.Format(url_template,ds._shop_transaction[0].idx,type,ds._shop_transaction[0].package_idx);
      }
   }
}
