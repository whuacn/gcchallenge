using System;
using System.Data;
using System.Data.SqlClient;
namespace AccessControl
{
   namespace acl_userTableAdapters
   {
      partial class base_user_infoTableAdapter
      {
         public System.Data.SqlClient.SqlConnection SqlConnection
         {
            get { return this.Connection; }
            set { this.Connection = value; }
        
         }
         protected int ExecuteNonQuery(System.Data.SqlClient.SqlCommand cmd)
         {
            System.Data.ConnectionState previousConnectionState = cmd.Connection.State;
            if (((cmd.Connection.State & System.Data.ConnectionState.Open) != System.Data.ConnectionState.Open))
            {
               cmd.Connection.Open();
            }
            int returnValue;
            try
            {
               returnValue = cmd.ExecuteNonQuery();
            }
            finally
            {
               if ((previousConnectionState == System.Data.ConnectionState.Closed))
               {
                  cmd.Connection.Close();
               }
            }
            return returnValue;
         }

         [System.Diagnostics.DebuggerNonUserCodeAttribute()]
         [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
         [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Insert, false)]
         public virtual int InsertUserAdv(string guididx, string login, string pwd, string first_name, string last_name, string email)
         {
            System.Data.SqlClient.SqlCommand command = this.Connection.CreateCommand();
            command.CommandText =
            @"
insert into acl_user (guididx,login,pwd) values (@guididx,@login,@pwd)

insert into acl_user_prop_value (user_idx,prop_idx,value)
Select IDENT_CURRENT('acl_user'),acl_property.idx,@first_name from acl_property where acl_property.name='first_name';

insert into acl_user_prop_value (user_idx,prop_idx,value)
Select IDENT_CURRENT('acl_user'),acl_property.idx,@last_name from acl_property where acl_property.name='last_name';

insert into acl_user_prop_value (user_idx,prop_idx,value)
Select IDENT_CURRENT('acl_user'),acl_property.idx,@email from acl_property where acl_property.name='email';
            
             ";

            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@guididx", System.Data.SqlDbType.VarChar, 36, System.Data.ParameterDirection.Input, 0, 0, "guididx", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@login", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "login", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@pwd", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@first_name", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@last_name", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Current, false, null, "", "", ""));


            if ((guididx == null)) throw new System.ArgumentNullException("guididx");
            if ((pwd == null)) throw new System.ArgumentNullException("pwd");
            if ((login == null)) throw new System.ArgumentNullException("login");

            command.Parameters[0].Value = guididx;
            command.Parameters[1].Value = login;
            command.Parameters[2].Value = pwd;
            command.Parameters[3].Value = first_name;
            command.Parameters[4].Value = last_name;
            command.Parameters[5].Value = email;

            return ExecuteNonQuery(command);
         }
         [System.Diagnostics.DebuggerNonUserCodeAttribute()]
         [System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
         [System.ComponentModel.DataObjectMethodAttribute(System.ComponentModel.DataObjectMethodType.Update, false)]
         public virtual int UpdateUserAdv(string login, string first_name, string last_name, string email, int original_idx)
         {
            System.Data.SqlClient.SqlCommand command = this.Connection.CreateCommand();
            command.CommandText =
            @"
update acl_user set login=@login where idx=@original_idx;
update acl_user_prop_value set value=@first_name where acl_user_prop_value.user_idx=@original_idx and acl_user_prop_value.prop_idx=(select idx from acl_property where name='first_name');
update acl_user_prop_value set value=@last_name  where acl_user_prop_value.user_idx=@original_idx and acl_user_prop_value.prop_idx=(select idx from acl_property where name='last_name');
update acl_user_prop_value set value=@email  where acl_user_prop_value.user_idx=@original_idx and acl_user_prop_value.prop_idx=(select idx from acl_property where name='email');
             ";

            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@original_idx", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, 0, 0, "idx", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@login", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "login", System.Data.DataRowVersion.Current, false, null, "", "", ""));

            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@first_name", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@last_name", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Current, false, null, "", "", ""));
            command.Parameters.Add(new System.Data.SqlClient.SqlParameter("@email", System.Data.SqlDbType.VarChar, 50, System.Data.ParameterDirection.Input, 0, 0, "pwd", System.Data.DataRowVersion.Current, false, null, "", "", ""));


            if ((login == null)) throw new System.ArgumentNullException("login");

            command.Parameters[0].Value = original_idx;
            command.Parameters[1].Value = login;
            command.Parameters[2].Value = first_name;
            command.Parameters[3].Value = last_name;
            command.Parameters[4].Value = email;

            return ExecuteNonQuery(command);
         }
      }
   }
}

namespace AccessControl
{
   partial class acl_user
   {

      public static void can_set_login(IDbConnection c, int idx, string new_login)
      {
         if ("new_one" == new_login) throw new System.Exception("Please rename user 'new_one'");
         Object dx = get_user_idx_by_login(c, new_login);

         if (dx != null && !dx.Equals(idx))
         {
            throw new System.Exception("Other user has such login: " + new_login);
         }
      }

      protected static Object get_user_idx_by_login(IDbConnection c, string new_login)
      {
         SqlCommand cmd = (SqlCommand)(c.CreateCommand());
         cmd.CommandText = "select idx from acl_user where login='" + new_login + "';";
         return cmd.ExecuteScalar();
      }
      
      partial class base_user_infoDataTable
      {
      }
   }
}
