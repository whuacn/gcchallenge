using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography;


namespace AccessControl
{
   public class AccessManager : BaseManager
   {
      public AccessManager(IDbConnection connection)
         : base(connection)
      {
         logon_=false;
      }
      public enum AccessStatus { logged, notlogged, unknown };
      
      public string SiteRoot 
      {
         get
         {
            return site_root_;
         }
         set 
         {
            site_root_=value;
         }
      }
      public string LastError
      {
         get 
         {
            return error_descr_;   
         }
      }
      
      
      public int UserId
      {
         get
         {
            return user_idx_;
         }
      }
      
      public Guid UserGuid
      {
         get
         {
            return user_guididx_;
         }
      }
      
      public SqlTransaction Transaction
      {
         get { return transaction_; }
         set { transaction_=value; }
      }
      public AccessStatus get_access_status()
      {
         if (logon_) return AccessStatus.logged;

         return AccessStatus.notlogged;
      }

      public string UserLogin
      {
         get { return (""==login_name_ || null==login_name_ )?"no_one":login_name_;  }
      }

      public System.Collections.ArrayList UserGroups 
      { 
         get 
         {
            return user_groups_;
         }
      }
      
      public string UserMainRole
      {
         get
         {
            if (null == user_groups_ || 0 == user_groups_.Count) return "no_one";
            return user_groups_[0].ToString();
         }
      }
      
      public Guid Ctx
      {
         get { return ctx_;}
      }

      public void init_access_status(string cookie_ctx)
      {
         logon_ = false;
         Guid c_ctx;
         user_idx_=-1;
         
         if (null!=cookie_ctx)
         {
            c_ctx=new Guid(cookie_ctx);
         }
         else
         {
            return;
         }
         SqlDataReader read;

         {

            SqlCommand cmd = build_command_(String.Format("select guididx,userid from acl_session where guididx='{0}';", c_ctx));
            read = cmd.ExecuteReader();
            if(!read.HasRows)
            {
               read.Close();
               return;
            }
            read.Read();
            if (Guid.Equals(c_ctx, new Guid(read[0].ToString())))
            {
               ctx_ = c_ctx;
               user_guididx_ = new Guid(read[1].ToString());
               logon_ = true;
            }
            if(read.Read())
            {
               throw new System.Exception(String.Format("There are more then one row for session ({0}).", c_ctx));
            }
            read.Close();
         }
         {
            SqlCommand cmd = build_command_(String.Format("select idx,login from acl_user where guididx='{0}';", user_guididx_));
            read = cmd.ExecuteReader();
            if (read.Read())
            {
               user_idx_=(int)(read[0]);
               login_name_ = read[1].ToString();
            }
            read.Close();
         }
         
         init_user_groups_();
      }


      public void create_user(string login, string pwd, System.Collections.Hashtable props)
      {

         if (has_login(login))
         {
            throw new System.Exception("Login '" + login + "' is already exists.\nTry another one");
         }
         SqlCommand cmd = build_command_(
            String.Format(
            "insert into acl_user (guididx,login,pwd) values('{0}','{1}','{2}');\n", 
            System.Guid.NewGuid(),
            login,
            buildHash_(pwd)));
         
         cmd.CommandText += "insert into acl_user_group_membership (user_idx,group_idx) select IDENT_CURRENT('acl_user'),idx from acl_group where name='users';\n";

         foreach(Object prop_idx in props.Keys)
         {
            string value = props[prop_idx].ToString();
            cmd.CommandText += String.Format("insert into acl_user_prop_value (user_idx,prop_idx,value) select IDENT_CURRENT('acl_user'),{0},'{1}';", prop_idx, value);
         }
         
         cmd.ExecuteNonQuery();
      }
      
      public bool has_login(string login)
      {
         SqlCommand cmd=build_command_(String.Format("select guididx from acl_user where login='{0}';", login));
         Object o=cmd.ExecuteScalar();
         if (o==null || o.GetType() == typeof(System.DBNull) )
         {
            return false;
         }
         else
         {
            return true; 
         }
      }

      public Guid logon(string login, string pwd)
      {
         if(logon_)
         {
            logof();
         }
         logon_ = false;
         user_idx_=-1;
         Guid ret=System.Guid.NewGuid();
         
         
         // find user
         {
            SqlDataReader read = build_reader_(String.Format("select idx,guididx from \"acl_user\" where login='{0}' and pwd='{1}';", login, buildHash_(pwd)));
            if (!read.HasRows)
            {
               read.Close();
               logon_ = false;
               throw new System.Exception("Can't logon. Probably no such user.");
            }
            read.Read();
            user_idx_ = (int)read[0];
            user_guididx_ = new Guid(read[1].ToString());
            

            if (read.Read())
            {
               read.Close();
               logon_ = false;
               throw new System.Exception(String.Format("There are more then one pair of login ({0}) and pwd.", login));
            }
            read.Close();
         }
         //  check session
         bool do_insert=true;
         
         {
            SqlDataReader reader=build_reader_(String.Format("select guididx from acl_session where userid='{0}';", user_guididx_));
            if(reader.Read())
            {
               ret=new Guid(reader[0].ToString());
               do_insert=false;
            }
            reader.Close();
         }
         
         // insert session
         if(do_insert)
         {
            SqlCommand insertCmd = build_command_(String.Format("insert into acl_session values('{0}','{1}');", ret, user_guididx_));
            int i = insertCmd.ExecuteNonQuery();
            if (i != 1)
            {
               logon_ = false;
               throw new System.Exception("Can't start new user session");
            }
         }
         
         {
            set_property(user_guididx_,"last_access",DateTime.Now.ToString());
         }         
         init_user_groups_();

         login_name_=login;
         ctx_ = ret;
         logon_ = true;
         return ret;
      }
      

      

      public void logof()
      {
         logon_ = false;
         user_idx_=-1;
         user_guididx_=Guid.Empty;
         login_name_="";
         user_groups_=null;
         
         SqlCommand insertCmd = build_command_(String.Format("delete from acl_session where guididx='{0}';", ctx_));
         insertCmd.ExecuteNonQuery();
      }

      static public bool has_logged(Guid idx)
      {
         return false;
      }
      
      public void can_do(Guid idx,string function)
      {
         if(!check_do(idx,function))
         {
            throw new SystemException("Access to: '"+function +"' for: '"+idx.ToString()+ "'denied");
         }
      }
      
      public bool check_do(Guid idx,string function)
      {
         SqlCommand cmd=build_command_(String.Format(
@"
select acl_function.idx 
from acl_user 
inner join acl_user_group_membership on (acl_user.idx = acl_user_group_membership.user_idx and (acl_user.guididx='{0}' or acl_user.login='nobody'))
inner join acl_group on (acl_user_group_membership.group_idx=acl_group.idx)
inner join acl_function_grants on (acl_group.idx=acl_function_grants.group_idx)
inner join acl_function on (acl_function_grants.func_idx=acl_function.idx and (acl_function.name='all' or acl_function.name='{1}') and acl_function.deleted=0)
"
, idx,function));

         try
         {
            Object o=cmd.ExecuteScalar();         
            if(null==o || o.GetType()==typeof(System.DBNull))
            {
               return false;
            }
            return true;
         }
         catch(System.Exception ee)
         {
            throw ee;
         }
      }


      public void can_do(string function)
      {
         if(!check_do(function))
         {
            throw new SystemException(String.Format("Access denied for {0} to {1}",UserLogin,function));
         }
      }

      public bool check_do(string function)
      {
         if (login_name_ == "admin") return true;
         return check_do(user_guididx_, function);
      }

      ////////////////////////////////////////////////////

      public string reset_pwd(System.Guid guididx)
      {
         set_pwd(guididx, "empty");
         return "empty";
      }

      public void set_pwd_current(string new_pwd)
      {
         set_pwd(UserGuid, new_pwd);
      }

      public void set_pwd(System.Guid guididx, string new_pwd)
      {
         build_command_(
                        String.Format("update acl_user set pwd='{0}' where guididx='{1}';",
                        buildHash_(new_pwd),
                        guididx)).ExecuteNonQuery();
      }
   

      ////////////////////////////////////////////////////
      
      
      protected static string buildHash_(string pwd)
      {
         SHA1 sha = new SHA1CryptoServiceProvider();
         byte[] hash = sha.ComputeHash(System.Text.Encoding.ASCII.GetBytes(pwd));
         return Convert.ToBase64String(hash).ToString();
      }
      
      protected void init_user_groups_()
      {
         
         SqlDataReader read=build_reader_(String.Format(
@"
select name from acl_group 
inner join acl_user_group_membership on 
   acl_group.idx = acl_user_group_membership.group_idx and 
   acl_user_group_membership.user_idx = (select idx from acl_user where guididx='{0}')
   order by grouplevel asc;
"
         , user_guididx_));

         user_groups_=new System.Collections.ArrayList();   
         try
         {
            while (read.Read())
            {
               user_groups_.Add(read[0]);
            }         
         }
         catch(System.Exception ee)
         {
            read.Close();
            throw ee;
         }
         read.Close();
      }
      
      
      protected static System.Collections.Hashtable build_property_(int idx,string i_name, string h_name, string value, bool is_nes, bool is_int, bool is_user)
      {
         System.Collections.Hashtable ht=new System.Collections.Hashtable();
         ht["idx"] = idx;
         ht["name"]=i_name;
         ht["human_name"]=h_name;
         ht["value"]=value;
         ht["is_nessesary"]=is_nes;
         ht["is_internal"]=is_int;
         ht["is_user_editable"] = is_user;
         return ht;
      }

      public System.Collections.ArrayList get_user_prop_info(Guid user)
      {
         System.Collections.ArrayList ht = new System.Collections.ArrayList();
         System.Collections.ArrayList must_be_properties=new System.Collections.ArrayList();


         SqlCommand cmd0 = build_command_(
         @"
select 
acl_property.idx,
acl_property.name,
acl_property.human_name,
acl_property.type, 
acl_property.nesses, 
acl_property.is_internal, 
acl_property.is_user_editable

from acl_property inner join acl_property_group on 
(acl_property_group.prop_idx=acl_property.idx and acl_property_group.group_name='user_props') 
order by acl_property.idx, acl_property.name;
         "
         );

         SqlDataReader reader0 = cmd0.ExecuteReader();
         try
         {
            while (reader0.Read())
            {
               must_be_properties.Add(new string[] { reader0[0].ToString(), reader0[1].ToString(), reader0[2].ToString(), reader0[3].ToString(), reader0[4].ToString(), reader0[5].ToString(), reader0[6].ToString() });
            }
            reader0.Close();
         }
         catch(System.Exception ee)
         {
            reader0.Close();
            throw ee;
         }
         
         SqlCommand cmd=build_command_(
         String.Format(
         @"
select 
acl_user_prop_value.idx,
acl_user_prop_value.prop_idx,
acl_user_prop_value.value, 
acl_user.login
         from acl_user 
          inner JOIN acl_user_prop_value on ((acl_user_prop_value.user_idx=acl_user.idx) and acl_user.guididx='{0}') 
          order by acl_user.login;"
          ,
           user));

         SqlDataReader reader=cmd.ExecuteReader();
         
         System.Collections.Hashtable got_props=new System.Collections.Hashtable ();
         
         string login_="";
         try
         {
            bool f=true;
            try
            {
               while (reader.Read())
               {
                  got_props.Add(reader[1], new string[] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString() });
                  if (f) { login_ = reader[3].ToString(); f = false; }
               }
               reader.Close();
            }
            catch(System.Exception ee)
            {
               reader.Close();
               throw ee;
            }
            
            ht.Add(build_property_(-42, "login", "Login", login_, true, false, true));
            for(int i=0;i<must_be_properties.Count;++i)
            {
               string[] cp=(string[])(must_be_properties[i]);
               int prop_idx=Int32.Parse(cp[0]);
               string[] cgp = (string[])got_props[prop_idx];
               if(null!=cgp)
               {
                  
                  ht.Add(
                     build_property_(
                                      Int32.Parse(cgp[0]),              /*idx*/
                                      cp[1],                            /*name*/
                                      cp[2],                            /*human_name*/
                                      cgp[2],                           /*value*/
                                      Boolean.Parse(cp[4]),             /*is nes*/
                                      Boolean.Parse(cp[5]),             /*is int*/
                                      Boolean.Parse(cp[6])              /*is user*/
                                    )
                         );
               }
               else
                  ht.Add(
                     build_property_(
                                      -1,              /*idx*/
                                      cp[1],                            /*name*/
                                      cp[2],                            /*human_name*/
                                      "",                              /*value*/
                                      Boolean.Parse(cp[4]),             /*is nes*/
                                      Boolean.Parse(cp[5]),             /*is int*/
                                      Boolean.Parse(cp[6])              /*is user*/
                                    )
                         );
               {
               
               }
               
            }
         }
         catch(System.Exception e)
         {
            throw e;
         }

         return ht;   
      }
      
      public System.Collections.ArrayList get_user_groups_info(Guid user)
      {
      System.Collections.ArrayList al=new System.Collections.ArrayList();
         SqlCommand cmd0 = build_command_(String.Format(
@"
SELECT     acl_group.idx, acl_group.name, acl_user_group_membership.idx AS Expr1
FROM         acl_group LEFT OUTER JOIN
                      acl_user_group_membership ON acl_group.idx = acl_user_group_membership.group_idx AND acl_user_group_membership.user_idx = (select idx from acl_user where guididx='{0}')
where acl_group.deleted = 0
GROUP BY acl_group.idx, acl_group.name, acl_user_group_membership.idx
order by acl_group.idx
"
, user));
        
         SqlDataReader read=cmd0.ExecuteReader();
         try
         {
            while (read.Read())
            {
               System.Collections.Hashtable ht=new System.Collections.Hashtable();
               
               ht["group_idx"]=read[0];
               ht["name"]=read[1].ToString();
               ht["gm_idx"]=read[2];
               al.Add(ht);
            }
            read.Close();
         }
         catch(System.Exception ee)
         {
            read.Close();
            throw ee;
         }
         return al;
      }
      
      
      public void set_property(Guid user_guididx,string prop_name,Object prop_value)
      {
         SqlCommand spi = build_command_(String.Format(
         @"
delete from acl_user_prop_value where 
    user_idx=(select idx from acl_user     where guididx='{0}') 
and prop_idx=(select idx from acl_property where name='{1}');            

insert into acl_user_prop_value (user_idx,prop_idx,value)
select acl_user.idx,acl_property.idx,'{2}' from acl_user,acl_property where acl_user.guididx='{0}' and acl_property.name='{1}';
            "
            
         ,
         user_guididx, 
         prop_name,
         prop_value));
         
         spi.ExecuteNonQuery();
      
      }
      public void apply_login(Guid guididx,string login)
      {
         SqlCommand al=build_command_(String.Format("update acl_user set login='{1}' where guididx='{0}';",guididx,login));
         al.ExecuteNonQuery();
      }

      public void apply_prop(int original_idx,string value)
      {
         SqlCommand ap = build_command_(String.Format("update acl_user_prop_value set value='{1}' where idx='{0}';", original_idx, value));
         ap.ExecuteNonQuery();
      }
      public void add_prop(Guid guididx,string name,string value)
      {
         SqlCommand add_user_prop = build_command_(String.Format(
         @"
insert into acl_user_prop_value (user_idx,prop_idx,value)
select acl_user.idx,acl_property.idx,'{2}' from acl_user CROSS JOIN acl_property where acl_user.guididx='{0}' and acl_property.name='{1}';", 
guididx, name,value));
         add_user_prop.ExecuteNonQuery();
      }
      
      
      public void apply_props(Guid guididx,System.Collections.Hashtable ht)
      {
         foreach (string kn in ht.Keys)
         {
            string[] values=((string[])ht[kn]);
            if(kn=="login")
            {
               apply_login(guididx,values[1]);
            }
            else
            {
               int pidx=Int32.Parse(values[0]);
               if(pidx==-1 || pidx==0)
               {
                  add_prop(guididx,kn,values[1]);
               }
               else
               {
                  apply_prop(pidx,values[1]);
               }
            }   
         }
      }
      public void apply_groups(Guid guididx, System.Collections.ArrayList al)
      {
         SqlCommand set_groups= build_command_(
                                                String.Format(
                                                @"
                                                DELETE FROM acl_user_group_membership
                                                WHERE     (user_idx =
                                                                          (SELECT     idx
                                                                            FROM          acl_user
                                                                            WHERE      (guididx = '{0}')))
                                                "
                                                , guididx));


         for(int i=0;i<al.Count;++i)
         {
            set_groups.CommandText+=String.Format("\ninsert into acl_user_group_membership (user_idx,group_idx) select idx, {1} from acl_user where guididx='{0}';",guididx,al[i]);
         }
         set_groups.ExecuteNonQuery();
      }


      
      public System.Collections.Hashtable get_group_info(Guid guididx)
      {
         System.Collections.Hashtable ret=new System.Collections.Hashtable ();
         SqlDataReader reader = build_reader_(String.Format("select idx,guididx,name,descr from acl_group where guididx='{0}';",guididx));
         
         try
         {
            while(reader.Read())         
            {
               ret["idx"]=reader[0];
               ret["guididx"]=reader[1];
               ret["name"]=reader[2];
               ret["descr"]=reader[3]; 
               break;
            }
            reader.Close();
         }
         catch(System.Exception ee)
         {
            reader.Close();
            throw ee;
         }
         return ret;
      }

      public System.Collections.ArrayList get_group_functions(Guid guididx)
      {
         System.Collections.ArrayList ret=new System.Collections.ArrayList ();
         SqlDataReader reader=build_reader_(String.Format(
@"
SELECT     acl_function.idx, acl_function.name, acl_function.descr, acl_function_grants.idx
FROM       acl_function 
LEFT OUTER JOIN acl_function_grants 
ON  acl_function_grants.func_idx = acl_function.idx 
and acl_function_grants.group_idx = (select idx from acl_group where guididx='{0}')
where acl_function.deleted=0
order by acl_function.idx;
"
, guididx));

         try
         {
            while(reader.Read())
            {
            
               System.Collections.Hashtable ht=new System.Collections.Hashtable();
               ht["idx"]=reader[0];
               ht["name"]=reader[1];
               ht["descr"]=reader[2];
               ht["grant_idx"]=reader[3];
               ret.Add(ht);
            }
            reader.Close();
         }
         catch(System.Exception ee)
         {
            reader.Close();
            throw ee;
         }
         return ret;
      }
      
      
      protected SqlCommand build_command_(string cmd)
      {
         SqlCommand ret = (SqlCommand)(connection_.CreateCommand());
         ret.CommandText = cmd;
         ret.Transaction=transaction_;
         return ret;
      }

      protected SqlDataReader build_reader_(string cmd)
      {
         return build_command_(cmd).ExecuteReader();
      } 


      public void apply_grants(Guid guididx, System.Collections.ArrayList al)
      {
         SqlCommand set_grants = build_command_(
                                                String.Format(
                                                @"
                                                DELETE FROM acl_function_grants
                                                WHERE     (group_idx =
                                                                          (SELECT     idx
                                                                            FROM       acl_group
                                                                            WHERE      (guididx = '{0}')))
                                                "
                                                , guididx));


         for (int i = 0; i < al.Count; ++i)
         {
            set_grants.CommandText += String.Format("\ninsert into acl_function_grants (group_idx,func_idx) select idx, {1} from acl_group where guididx='{0}';", guididx, al[i]);
         }
         
         set_grants.ExecuteNonQuery();
      }
      public void grant_all(Guid guididx)
      {
         SqlCommand set_grants = build_command_(
                                                String.Format(
                                                @"
                                                DELETE FROM acl_function_grants
                                                WHERE     (group_idx =
                                                                          (SELECT     idx
                                                                            FROM       acl_group
                                                                            WHERE      (guididx = '{0}')))
                                                                            
                                                insert into acl_function_grants (group_idx,func_idx) select acl_group.idx,acl_function.idx  from acl_group, acl_function where acl_group.guididx='{0}' and acl_function.name='all';
                                                "
                                                , guididx));
         set_grants.ExecuteNonQuery();
      }
      
      public bool is_all_granted(Guid guididx)
      {
         SqlCommand get=build_command_(String.Format(
@"
select acl_function_grants.idx 
from acl_function 
inner join acl_function_grants on (acl_function_grants.func_idx=acl_function.idx and acl_function.name='all')
inner join acl_group           on (acl_function_grants.group_idx=acl_group.idx and acl_group.guididx='{0}');"
, guididx));

         try
         {
            Object o = get.ExecuteScalar();
            if(null == o || o.GetType()==typeof(System.DBNull))
            {
               return false;
            }
            return true;
         }
         catch(System.Exception ee)
         {
            throw ee;
         }
      }
      
      
      protected string read_resorce(string name)
      {
         return System.IO.File.ReadAllText(site_root_+"/rc/"+name);
      }

      protected string generate_from_resorce(string name)
      {
         string ret=read_resorce(name);
         ret = ret.Replace("%login%",login_name_);
         ret = ret.Replace("%guididx%",user_guididx_.ToString());
         ret = ret.Replace("%ctxidx%", ctx_.ToString());
         return ret;

      }
      
      public string show_login_status_box()
      {
         
         string ret;
         if(logon_)
         {
            ret = generate_from_resorce("logged.rc.html");
         }
         else
         {
            ret = generate_from_resorce("not_logged.rc.html");
         }
         return "<div align='right' id=\"login_box\">"+ret+"</div>";
      }
      
      public bool manage_session(System.Web.HttpRequest request, 
                                 System.Web.HttpResponse response,
                                 string cookieName,
                                 IStatusHandler handler)
      {
         error_descr_ = "";
         if(null==cookieName || ""==cookieName) 
         {
            throw new System.Exception("Access Manager Cookie name must be setupped throught 'AccessManager.Cookie' variable in web.config");
         }
         try
         {
            if (null != request.Params["login"] && 
                null != request.Params["password"])
            {
               logon(
                     request.Params["login"].ToString(),
                     request.Params["password"].ToString());


               if (request.Params["remember"]!=null) 
               {
                  response.Cookies[cookieName].Value = ctx_.ToString();
                  response.Cookies[cookieName].Expires = DateTime.Now.AddDays(32);
               }
               
               handler.on_logon();               
            }

            if (null != request.Params["logoff"] && request.Params["logoff"].Equals("true"))
            {
               logof();
               return handler.on_logof();               
            }         
         }
         catch(System.Exception ee)
         {
            error_descr_ = ee.Message;   
         }
         return true;
      }


      public void check_function_and_group(string name,string descr)
      {
         acl_functionTableAdapters.acl_functionTableAdapter af=new acl_functionTableAdapters.acl_functionTableAdapter();
         af.Connection = (SqlConnection)connection_;
         
         acl_groupTableAdapters.acl_groupTableAdapter ag=new acl_groupTableAdapters.acl_groupTableAdapter();
         ag.Connection = (SqlConnection)connection_;
         
         Object func_idx_ = af.HasFunction(name); ;
         Object group_idx_ = ag.HasGroup(name);
         if (null == func_idx_ || func_idx_.GetType() == typeof(DBNull))
         {
            func_idx_ = af.InsertFunction(name, descr).Value;
         }

         if (null == group_idx_ || group_idx_.GetType() == typeof(DBNull))
         {
            group_idx_ = ag.InsertGroup(System.Guid.NewGuid(),500,name,descr).Value;
         }

         {
            SqlCommand cmd = build_command_(String.Format("select idx from acl_function_grants where group_idx='{0}' and func_idx={1};", group_idx_, func_idx_));
            Object idx_ = cmd.ExecuteScalar();
            if (null == idx_ || idx_.GetType() == typeof(DBNull))
            {
               grant_((int)group_idx_,(int)func_idx_);     
            }
         }
         
      }
      
      void grant_(int group_idx,int function_idx)
      {
         SqlCommand ins = build_command_(
         String.Format("insert into acl_function_grants (group_idx,func_idx) values({0},{1});", group_idx, function_idx));   
         if(ins.ExecuteNonQuery()!=1) throw new System.Exception("Can't grant access");
      }
      
      public void grant_access_to_function(string name)
      {

         SqlCommand del=build_command_(
         String.Format(
         @"
         delete from acl_user_group_membership where group_idx=(select idx from acl_group where name='{0}') and user_idx={1};
         insert into acl_user_group_membership (user_idx,group_idx) select {1},idx from acl_group where name='{0}';
         "
         , name,
         user_idx_));
         del.ExecuteNonQuery();
      }

      public void revoke_access_to_function(string name)
      {
         SqlCommand del = build_command_(
         String.Format(
         @"
         delete from acl_user_group_membership where group_idx=(select idx from acl_group where name='{0}') and user_idx={1};
         "
         , name,
         user_idx_));
         del.ExecuteNonQuery();
      }
      
      
      protected SqlTransaction transaction_=null;
      protected string error_descr_;
      protected string groupDescr_;
      protected bool logon_;
      protected Guid ctx_;
      protected Guid user_guididx_;
      protected int  user_idx_;
      protected string login_name_;
      protected System.Collections.ArrayList user_groups_;
      protected string site_root_;
   }
}
