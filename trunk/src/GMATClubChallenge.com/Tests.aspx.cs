using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using AccessControl;
using log4net;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;

namespace GMATClubTest.Web
{
   public partial class Tests : BasePage
   {
      protected GmatClubTest.Data.BindedTests bts=null;
      protected void Page_Load(object sender, EventArgs e)
      {
         base.Page_Load(sender,e);
      }
      
      public override void DoLoad(object sender, EventArgs e)
      {
         ((GMATClubTest.Web.MainLayout)(Master)).setPageHead("GMAT Tests");
      }

      public void readAllContents()
      {
         bts = new GmatClubTest.Data.BindedTests();
         GmatClubTest.Data.BindedTestsTableAdapters.binded_testsTableAdapter a = new GmatClubTest.Data.BindedTestsTableAdapters.binded_testsTableAdapter();
         a.SqlConnection = (System.Data.SqlClient.SqlConnection)access_manager_.Connection;
         a.Fill(bts.binded_tests);
      }
      public string buildContents(int idx)
      {
         
         if(null==bts)
         {
            readAllContents();   
         }
         string ret="";
         foreach(BindedTests.binded_testsRow i in bts.binded_tests)
         {
            if(i.idx==idx)
            {
               if(i.type==1)
               {
                  if (!i.IschidxNull())
                  {
                     ret += String.Format("<a href='22'>{1}</a><hr style='height: 1px'/><div style='font-size: 8pt;'>{2}</div><br />", i.chidx, i.ch_name, show_descr(i.IsdescrNull() ? "" : i.descr, 0));
                  }
               }
               if(i.type==2)
               {
                  if(!i.IschidxNull())
                  {
                     ret+=String.Format("<a href='starttest.aspx?testid={0}'>{1}</a><br/>",i.chidx,i.ch_name);
                  }
               }
            }   
            
         }

         return ret;
         
      }
      
      public string show_contents(Object idx,Object descr)
      {
         if (hasContents(descr)) 
            return show_descr(descr,0);
         else
            return buildContents(System.Int32.Parse(idx.ToString()));
      }
      
      public bool hasContents(Object descr)
      {
         if (descr.GetType() == typeof(System.DBNull)) return false;      
         string ds=do_decode(descr);
         if(ds.IndexOf("---")!=-1) return true; 
         return false;
      }
      public string show_descr(Object descr,int g)
      {
         if (descr.GetType() == typeof(System.DBNull)) return "";
         string ds=do_decode(descr);
         if(ds.IndexOf("---")!=-1)
         {
            string[] s=new string[] { "---" };
            string[] spl = ds.Split(s, StringSplitOptions.RemoveEmptyEntries);
            if(spl.Length<=g) return spl[0]; else return spl[g];
         }
         return ds;
      }
      
      public string do_decode(Object str)
      {
         return Server.UrlDecode((string)str);
      }

      public override string current_function_name()
      {
         return "show_tests";
      }

   }
}
