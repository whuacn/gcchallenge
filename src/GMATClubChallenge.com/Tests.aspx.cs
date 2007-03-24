using System;
using System.Data.SqlClient;
using GmatClubTest.Data;

namespace GMATClubTest.Web
{
   public partial class Tests : BasePage
   {
      protected BindedTests bts = null;
       
      protected new void Page_Load(object sender, EventArgs e)
      {
         base.Page_Load(sender,e);
      }
      
      public override void DoLoad(object sender, EventArgs e)
      {
         ((MainLayout)(Master)).setPageHead("GMAT Tests");
      }

      public void readAllContents()
      {
         bts = new BindedTests();
         GmatClubTest.Data.BindedTestsTableAdapters.binded_testsTableAdapter a = new GmatClubTest.Data.BindedTestsTableAdapters.binded_testsTableAdapter();
         a.SqlConnection = (SqlConnection)access_manager_.Connection;
         a.Fill(bts.binded_tests);
      }
      public string buildContents(int idx)
      {
         
         if(null==bts)
         {
            readAllContents();   
         }
         string ret = "<table cellpadding='0' cellspacing='0' border='0' width='100%'><tr><td width='100%'>&nbsp;</td><td width='90'>&nbsp;</td></tr>";
         foreach(BindedTests.binded_testsRow i in bts.binded_tests)
         {
            
            if(i.idx==idx)
            {
               ret += "<tr>";
               if(i.type==1)
               {
                  if (!i.IschidxNull())
                  {
                     ret += String.Format("<td colspan='2'><a href='javascript:on_shop_item_click({3},\"group\",-1);'>{1}</a><div style='font-size: 8pt;'>{2}</div><hr style='height: 1px'/></td>", i.chidx, i.ch_name, show_descr(i.IsdescrNull() ? "" : i.descr, 0), i.chidx);
                  }
               }
               if(i.type==2 || i.type==3)
               {
                  if(!i.IschidxNull())
                  {
                     ret += String.Format("<td><a href='javascript:on_shop_item_click({0},\"{3}\",{2});'>{1}</a></td><td valign='top'>{4}</td>", i.chidx, i.ch_name, i.idx, i.type == 2 ? "test" : "download",i.type==2?rdrawer.draw(i.chidx,i.rating):"&nbsp;");
                  }
               }
               ret += "</tr>";
            }
            
         }

         ret+="</table>";
         return ret;
         
      }
      
      public string show_contents(Object idx,Object descr)
      {
         if (hasContents(descr)) 
            return show_descr(descr,0);
         else
            return buildContents(Int32.Parse(idx.ToString()));
      }
      
      public bool hasContents(Object descr)
      {
         if (descr.GetType() == typeof(DBNull)) return false;      
         string ds=do_decode(descr);
         if(ds.IndexOf("---")!=-1) return true; 
         return false;
      }
      public string show_descr(Object descr,int g)
      {
         if (descr.GetType() == typeof(DBNull)) return "";
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
      protected RatingDrawer rdrawer=new RatingDrawer(false);

   }
}
