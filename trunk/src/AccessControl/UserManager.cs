using System;
using System.Web;
using System.Collections;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace AccessControl
{
   public class UserManager
   {
      public int ServerSideAdd(int firstNumber, int secondNumber)
      {
         return firstNumber + secondNumber;
      }

      protected static string build_prop_(System.Collections.Hashtable ht)
      {
         if((System.Boolean)ht["is_user_editable"]==true)
         {
               return "<tr><td>" + ht["human_name"] + "</td><td><input type='text' name='prop_"+ht["name"]+"|"+ht["idx"] + "' value='" + ht["value"] + "' class='itt'></td></tr>";
         }
         else
         {
            return "<tr style='height: 22px;'><td>" + ht["human_name"] + "</td><td><b> "+ht["value"] +" </b></td></tr>";
         }
         
      }
      protected static string build_group_(System.Collections.Hashtable ht)
      {
         if (typeof(System.DBNull)==ht["gm_idx"].GetType())
         {
            return "<tr><td>" + ht["name"] + "</td><td><input type='checkbox' name='gm_" + ht["group_idx"]+ "' value='" + ht["idx"] + "' ></td></tr>";
         }
         else
         {
            return "<tr><td>" + ht["name"] + "</td><td><input type='checkbox' name='gm_" + ht["group_idx"] + "' value='" + ht["idx"] + "' checked></td></tr>";            
         }
      }
      protected static string build_grant_(System.Collections.Hashtable ht)
      {
         
         if(ht["name"].Equals("all")) return "";
         if (typeof(System.DBNull) == ht["grant_idx"].GetType())
         {
            return "<tr><td><input type='checkbox' name='grants_" + ht["idx"] + "' value='" + ht["grant_idx"] + "' >" + ht["name"] + "</td><td>" + ht["descr"] + "</td></tr>";
         }
         else
         {
            return "<tr><td><input type='checkbox' name='grants_" + ht["idx"] + "' value='" + ht["grant_idx"] + "' checked >" + ht["name"] + "</td><td>" + ht["descr"] + "</td></tr>";
         }
      }


      public static string build_user_info_(AccessControl.AccessManager mgr,System.Web.HttpRequest req)
      {
         Guid guididx = new Guid(req.Params["guididx"]);
         System.Collections.ArrayList ht = mgr.get_user_prop_info(guididx);
         System.Collections.ArrayList gi = mgr.get_user_groups_info(guididx);

         string ret=String.Format(
      "<table border=0 cellpadding='2' width='100%'>"+
      "<tr><td>User: <b>{0}</b></td><td></td></tr>"+
      "<tr><td><table border='0' cellpadding='0' cellspacing='0' width='100%' class='user_info'>",
      ((System.Collections.Hashtable)ht[0])["value"]);
         
         
         ret+="<tr><td>Properties</td><td>Groups</td></tr>";
         ret += "<tr><td valign='top'>" +
                   "<table border='0' cellpadding='0' cellspacing='0' width='100%'><form name='props_form' >";
            
           for(int i=0;i<ht.Count;++i)
           {
              ret += build_prop_((System.Collections.Hashtable)ht[i]);            
           }
           ret += 
           "<tr><td>&nbsp;</td><td>"+
           "<input type='hidden' name='guididx' value='"+guididx.ToString()+"'/>"+
           "<input type='button' name='submit_user_props' value='Apply properties' class='itt' onclick='javascript: handle_submit_props()'></td></tr></form>";
           
           ret += "</table></td><td valign='top'><table border='0' cellpadding='0' cellspacing='0' width='100%'><form name='groups_form'>";
           for(int i=0;i<gi.Count;++i)
           {
            ret+=build_group_((System.Collections.Hashtable)gi[i]);
           }
           ret+="<tr><td>&nbsp;</td><td>"+
           "<input type='hidden' name='guididx' value='" + guididx.ToString() + "'/>" +
           "<input type='button' name='submit_user_groups' value='Apply groups' class='itt' onclick='javascript: handle_submit_groups()'/></td></tr>";         
           ret+="</form></table></td></tr></table></td></tr></table>";
         
         
         
         return ret;
      }
      public static string show_group_info_(AccessControl.AccessManager mgr,System.Web.HttpRequest req)
      {
         Guid guididx = new System.Guid(req.Params["guididx"]);
         System.Collections.Hashtable ht = mgr.get_group_info(guididx);
         System.Collections.ArrayList grants = mgr.get_group_functions(guididx);
         string is_all=mgr.is_all_granted(guididx)?"checked":"";
         
         string
         ret = "<div  style='clip: rect (0px,50px,50px,0px)'><table border=0 cellpadding='2' width='100%'><form name='grants_form'>";
         ret+="<tr><td colspan='2'>Group: <b>"+ht["name"].ToString()+"</b></td></tr>";
         ret+="<tr style='background-color: #f0f0f0;' ><td><input type='checkbox' name='grants_all' value='yes' "+is_all+" >Allow all</td><td>&nbsp;</td></tr>";
         for(int i=0;i<grants.Count;++i)
         {
            ret+=build_grant_((System.Collections.Hashtable)grants[i]);
         }
         
         ret +="<tr><td colspan='2'><input type='hidden' name='guididx' value='" + guididx.ToString() + "'/>";
         ret+="</td></tr></form></table></div>";
         ret+="<input type='button' name='submit_group_perms' value='Apply permissions' class='itt' onclick='javascript: handle_submit_permissions()'/>";      ;
         return ret;
      }
      
      public static string apply_props_(AccessControl.AccessManager mgr,System.Web.HttpRequest req)
      {
         Guid guididx=new System.Guid(req.Params["guididx"]);
         System.Collections.Hashtable ht=new System.Collections.Hashtable();
         for(int i=0;i<req.Params.Keys.Count;++i)
         {
            string key=req.Params.Keys[i];
            if(key.IndexOf("prop_",0)==0)
            {                                                  
               string[] pdata=key.Substring(5).Split(new Char[]{'|'});
               string pname=pdata[0];
               if(pdata[1]=="") pdata[1]="-1";
               int pidx=Int32.Parse(pdata[1]);
               ht[pname] = new string[2] { pdata[1], req.Params[key].ToString() };
            }
         }
         mgr.apply_props(guididx,ht);
         return build_user_info_(mgr,req); 
      }

      public static string apply_groups_(AccessControl.AccessManager mgr, System.Web.HttpRequest req)
      {
         Guid guididx = new System.Guid(req.Params["guididx"]);
         System.Collections.ArrayList ht = new System.Collections.ArrayList();
         for (int i = 0; i < req.Params.Keys.Count; ++i)
         {
            string key = req.Params.Keys[i];
            if (key.IndexOf("gm_", 0) == 0)
            {
               ht.Add(Int32.Parse(key.Substring(3)));   
            }
         }
         mgr.apply_groups(guididx, ht);
         return build_user_info_(mgr, req);
      }
      
      public static string apply_grants_(AccessControl.AccessManager mgr, System.Web.HttpRequest req)      
      {
         Guid guididx = new System.Guid(req.Params["guididx"]);
         if (null!=req.Params["grants_all"] && req.Params["grants_all"].Equals("yes"))
         {
            mgr.grant_all(guididx);
         }
         else
         {

            System.Collections.ArrayList ht = new System.Collections.ArrayList();
            for (int i = 0; i < req.Params.Keys.Count; ++i)
            {
               string key = req.Params.Keys[i];
               if (key.IndexOf("grants_", 0) == 0)
               {
                  ht.Add(Int32.Parse(key.Substring(7)));
               }
            }
            mgr.apply_grants(guididx, ht);
         }
         return show_group_info_(mgr, req);
      }
   }
}
