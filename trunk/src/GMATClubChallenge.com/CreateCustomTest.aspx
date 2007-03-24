<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="CreateCustomTest.aspx.cs" Inherits="GMATClubTest.Web.CreateCustomTest" Title="Custom test creation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
<script language="javascript" type="text/javascript">
var idx=<% =test_idx %>
var tests=new Array();
var test_doc=null;
var l_select_id=0;
var last_added=null;
if(tests.length==0)
{
   exec_http_req("CustomTestsLogic::list_questions",new Array(),
   function (error,http)
   {
      if(error)
      {
         alert("Error: "+error);
      }
      else
      {
         test_doc=http.responseXML.documentElement;
      }
   });
}
function update_test_questions(t_id,after)
{
   exec_http_req("CustomTestsLogic::list_q_in_test",new Array("test_id",t_id),
   function (error,http)
   {
      if(error)
      {
        alert("Error: "+error);
      }
      else
      {
         tests[t_id][4]=http.responseText.split(";");
         after(tests[t_id][4]);
      }
   });
}


function clearlistbox(lb){
  for (var i=lb.options.length-1; i>=0; i--){
    lb.options[i] = null;
  }
  lb.selectedIndex = -1;
}
function add_question()
{
   add_question_selector(add_test_selector());
};
function del_question(div_id)
{
   document.getElementById(div_id).innerHTML="";
   document.getElementById(div_id).style.display='none';
}
function add_question_selector(test_id)
{
   

   var lb=document.createElement("SELECT");
   lb.name=lb.id=last_added+"_s_q";
   document.getElementById(last_added).appendChild(lb);
   
   
      
   update_question_selector(test_id,lb);
   document.getElementById(last_added).innerHTML+="&nbsp; &nbsp; &nbsp; <a href=\"javascript:del_question('"+last_added+"')\">[Del]</a>";
   document.getElementById(last_added).innerHTML+="<hr style='height:1px; width:100%'/>";
};

function fill_q_selector(array,control_)
{
   var control=document.getElementById(control_.id);
   clearlistbox(control);
   control.style.width="250 px";
   for(var i=0;i<array.length;++i)
   {
      var opt=document.createElement("OPTION");
      control.options.add(opt);
      var l=array[i].split("||");
      opt.innerText=(i+1)+". "+l[1];
      opt.value=l[0];
      if(i==0)
      {
         opt.selected=true;
      }
   };
};

function update_question_selector(t_id,elt)
{
   if(null!=tests[t_id])
   {
      if(tests[t_id][4].length==0)
      {
         update_test_questions(t_id,function(list){
            fill_q_selector(list,elt)
         });
      }
      else
      {
         fill_q_selector(tests[t_id][4],elt);
      };
   }
};
function test_sel_change(what)
{
   update_question_selector(what.options[what.selectedIndex].value,document.getElementById(what.id+"_q"));
};

function add_test_selector()
{
   //if(null==test_doc) throw new Exception("adasd");
   
   last_added="select_id_"+l_select_id;
   l_select_id++;
   
   
   var d=document.createElement("div");
   d.name=d.id=last_added;
   
   document.getElementById('controls_place').appendChild(d);
   
   var cur_test=-1;
   
   var t="Select test and question <select style='width: 200px' onchange='test_sel_change(this)' id='"+last_added+"_s'>";


   for(var i=0;i<test_doc.childNodes.length;++i)
   {
      var elt=test_doc.childNodes(i);
      var id=elt.childNodes(0).text;
      var name=elt.childNodes(1).text;
      var type=elt.childNodes(4).text;
      t+="<option value='"+id+"'>"+name+"</option>";
      if(null==tests[id])
      {
         tests[id]=new Array(id,name,type,elt,new Array());
      }
      if(-1==cur_test)
      {
         cur_test=id;      
      };
      
   }
   t+="</select>";
   d.innerHTML+=t;
   return cur_test;
   
};

function del_all()
{
   document.getElementById("_ctl0_content_test_name").value="";
   document.getElementById("_ctl0_content_test_description").value="";
   for(var i=0;i<l_select_id;++i)  
   {
      var n_n="select_id_"+i;
      var dv=document.getElementById(n_n);
      if(null!=dv)
      {
         dv.innerHTML="";
      }
   };
};

function show_ok_message()
{
   document.getElementById("ok_message").style.visibility='';
};

function submit_test()
{
   //if();
   //l_select_id
   var t_name=document.getElementById("_ctl0_content_test_name");
   if(t_name==null) 
   {
      alert("No test name box found");
      return;
   };
   
   var t_descr=document.getElementById("_ctl0_content_test_description");
   if(t_descr==null) 
   {
      alert("No test description box found");
      return;
   };
   
   
   if(""==t_name.value)
   {
      alert("No test name provided");
      return;
   };
   var ids="";
   var cnt=new Array();
   for(var i=0;i<l_select_id;++i)
   {
      var n_n="select_id_"+i+"_s";
      var tst=document.getElementById(n_n);
      if(null==tst)
      {
         continue;
      }
      
      var q=document.getElementById(n_n+"_q");
      if(null==q)
      {
         continue;
      };
      if(""!=ids)
      {
         ids+=",";
      };
      ids+=q.options[q.selectedIndex].value;
      if(cnt[q.options[q.selectedIndex].value]==null)
      {
         cnt[q.options[q.selectedIndex].value]=1;
      }
      else
      {
         alert ("Question: "+q.options[q.selectedIndex].innerText+" used more than once");
         return;
      }
         
   };
   
   if(""==ids)
   {
      alert("Can't create empty test!\n You must add some questions!");
      return;
   }
   
   var tps=document.getElementById("types");
   var stps=document.getElementById("subtypes");
   var tl_=document.getElementById("time_limit");
   //if(!Int32.Parse(tl_.value))
   {
      //alert("Time limit muust be a digit");
      //return;
   }
      
   exec_http_req("CustomTestsLogic::create_test",
   
   new Array("qtypeid",tps.options[tps.selectedIndex].value,
             "qsubtypeid",stps.options[stps.selectedIndex].value,
             "tl",tl_.value,
             "name",t_name.value,
             "descr",t_descr.value,
             "questions",ids),
   function (error,http)
   {
      if(error)
      {
        alert("Error: "+error);
      }
      else
      {
         del_all();
         show_ok_message();
      }
   });

};
</script>
   <table width="100%">
   <tr>
   <td style="width: 104px">Test name</td><td>
      <asp:TextBox ID="test_name" runat="server" CssClass="itt" Width="450px"></asp:TextBox></td>
   </tr>
      <tr>
         <td style="width: 104px">
            Test description
         </td>
         <td>
            <asp:TextBox ID="test_description" runat="server" CssClass="itt" Width="450px" Rows="3" TextMode="MultiLine"></asp:TextBox>
         </td>
      </tr>
      <tr><td>Question Type:</td><td><select id="types"></select><td></tr>
      <tr><td>SubType: </td><td><select id="subtypes"></select></td></tr>
      <tr><td>Time limit: </td><td><input type="text"  value="3600" id="time_limit"></td></tr>
      <tr>
         <td style="width: 104px">
         <a href="javascript: add_question()">[Add question]</a> 
         </td>
         <td>
         </td>
      </tr>
      <tr>
         <td colspan="2">
            <hr style="height: 1px;" width="100%" />
            <div id="controls_place">
               
            </div>
         </td>
      </tr>
      <tr>
         <td style="width: 104px">
         <a href="javascript: submit_test()">[Submit test]</a>
         </td>
         <td>
         </td>
      </tr>
      <tr>
         <td colspan="2" id="ok_message" style="visibility: hidden;">
         Test created. Thanks you!
         </td>
      </tr>
   </table>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
<script language="javascript" type="text/javascript">
var types_=document.getElementById("types");
var subtypes_=document.getElementById("subtypes");

function fill(to,td)
{
   for(var i=0;i<td.childNodes.length;++i)
   {
      var elt=td.childNodes(i);
      var id = elt.childNodes(0).text;
      var name = elt.childNodes(1).text;
      var opt=document.createElement("OPTION");            
      to.options.add(opt);
      opt.value=id;
      opt.innerText=name;
      if(i==0) opt.selected=true;
   }
}

if(null!=types_)
{
   exec_http_req("CustomTestsLogic::list_types",new Array(),
   function (error,http)
   {
      if(error)
      {
         alert("Error: "+error);
      }
      else
      {
         fill(types_,http.responseXML.documentElement);
         
         exec_http_req("CustomTestsLogic::list_subtypes",new Array(),
         function (error,http)
         {
            if(error)
            {
               alert("Error: "+error);
            }
            else
            {
               fill(subtypes_,http.responseXML.documentElement);
            }
         });
         
      }
   });
}
</script>
</asp:Content>

