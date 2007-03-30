<%@ Page Language="C#" MasterPageFile="~/MainLayout.master" AutoEventWireup="true" CodeFile="ManagePersonal.aspx.cs" Inherits="GMATClubTest.Web.ManagePersonal" Title="User profile" %>
<asp:Content ID="Content3" ContentPlaceHolderID="add_js" Runat="Server">
<link rel="stylesheet" type="text/css" media="all" href="calendar-blue.css" title="winter" />
   <script type="text/javascript" language="javascript" src="js/calendar_stripped.js"></script>
   <script type="text/javascript" language="javascript" src="js/lang/calendar-en.js"></script>
   <script type="text/javascript" language="javascript" src="js/calendar-setup_stripped.js"></script>

<script type="text/javascript" language="javascript" src="js/rate_it.js"></script>
<script type="text/javascript" language="javascript">

function validate_date(name,c)
{
   if(c==null)
   {
      alert("Date control not found. Reload page and try again");
      return false;
   };
   var a=c.value.split('/');
   if(a.length!=3)
   {
       alert("Incorrect '"+name+"' date provided");   
       return false;
   };
   return true;   
};
function start_mistakes(code,name)
{
   
   var fr=document.getElementById('fr_date');
   var to=document.getElementById('to_date');
   if(validate_date("from",fr) && validate_date("to",to))
   {
      document.getElementById("cnt").style.visibility='hidden';
      var str="MistakesTest.aspx?fr="+fr.value+"&to="+to.value+"&type="+code+"&name="+name;      
      window.location=str;
      
   };
};
function myMistakes(code,name)
{

   var data=
   "<br/>All Your mistakes within selected period "+
   "<br/> will be provided to You as a single test.<br/>"+
   "<table border='0'>"+
   "<tr><td>From: </td><td><input id='fr_date' type='text' size='18' value='' class='itt'/> <img src='i/cal.gif' id='sh_c_1' style='cursor: pointer;'/></td></tr>"+
   "<tr><td>To:</td><td><input id='to_date' type='text' size='18' value='' class='itt'/> <img src='i/cal.gif' id='sh_c_2' style='cursor: pointer;'/></td></tr>"+
   "<tr><td><a href='javascript: start_mistakes("+code+",\""+name+"\");'>[Start test]</a></td><td>&nbsp;</td></tr></table>";
   
   show_data(data);
   
    function catcalc1(cal) {
        var date = cal.date;
        var time = date.getTime()
        // use the _other_ field
        var field = document.getElementById("fr_date");
        var date2 = new Date(time);
        field.value = date2.print("%m/%d/%Y");
    }
    Calendar.setup({
        inputField     :    "fr_date",   // id of the input field
        ifFormat       :    "%m/%d/%Y",       // format of the input field
        showsTime      :    false,
        timeFormat     :    "24",
        eventName      :    "click",
        onUpdate       :    catcalc1,
        button         :    "sh_c_1"
    });
    
    function catcalc2(cal) {
        var date = cal.date;
        var time = date.getTime()
        // use the _other_ field
        var field = document.getElementById("to_date");
        var date2 = new Date(time);
        field.value = date2.print("%m/%d/%Y");
    }
    Calendar.setup({
        inputField     :    "to_date",   // id of the input field
        ifFormat       :    "%m/%d/%Y",       // format of the input field
        showsTime      :    false,
        timeFormat     :    "24",
        eventName      :    "click",
        onUpdate       :    catcalc2,
        button         :    "sh_c_2"
    });
    

   
   
   show_ajax_window(0);   
};

</script>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="content" Runat="Server">
   &nbsp;
   <asp:HyperLink ID="lMain" runat="server" NavigateUrl="ManagePersonal.aspx?panel=main">[Main]</asp:HyperLink>
   |
   <asp:HyperLink ID="lTests" runat="server" NavigateUrl="ManagePersonal.aspx?panel=tests">[Active tests]</asp:HyperLink>
   |
   <asp:HyperLink ID="lProfile" runat="server" NavigateUrl="ManagePersonal.aspx?panel=profile">[Profile settings]</asp:HyperLink>
   |
   <asp:HyperLink ID="lResults" runat="server" NavigateUrl="ManagePersonal.aspx?panel=results">[Results]</asp:HyperLink>&nbsp;

   <asp:Panel ID="pMain" runat="server" Width="100%">
      <b>Main:</b>
      <table border="1" cellspacing="0" cellpadding="0" width="100%" >
      	<tr>
      		<td width="50%" valign="top" style="height: 158px">
               <asp:GridView ID="resultsGrid2" runat="server" AutoGenerateColumns="False"
                  DataKeyNames="mid" DataSourceID="shortResults" Width="100%" OnSelectedIndexChanged="resultsGrid2_SelectedIndexChanged">
                  <Columns>
                     <asp:TemplateField HeaderText="Id" SortExpression="Id" Visible="False">
                        <ItemTemplate>
                           <asp:Label ID="idlbl" runat="server" Text='<% # DataBinder.Eval(Container.DataItem,"mid") %>'></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField>
                        
                     <asp:ButtonField  HeaderText="Review your results" CommandName="Select" SortExpression="Name" DataTextField="Name"  >
                        <ItemStyle CssClass="itt" Width="250px" />
                     </asp:ButtonField>
                     <asp:TemplateField HeaderText="At" SortExpression="met">
                        <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# ((DateTime)DataBinder.Eval(Container.DataItem,"met")).Date.ToShortDateString() %>'></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Score" SortExpression="Result">
                        <ItemTemplate>
                           <asp:Label ID="Label2" runat="server" Text='<%# (bool)DataBinder.Eval(Container.DataItem,"IsPractice")==false?(DataBinder.Eval(Container.DataItem,"Result")+"th"):(DataBinder.Eval(Container.DataItem,"max_score")+"/"+DataBinder.Eval(Container.DataItem,"q_cnt")) %>'></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField>
                  </Columns>
                  <HeaderStyle BackColor="LightSteelBlue" />
                  <AlternatingRowStyle BackColor="#C0C0FF" />
               </asp:GridView>
               <asp:SqlDataSource 
               ID="shortResults" runat="server" 
               ConnectionString="<%$ ConnectionStrings:gmatConnectionString %>" 
               ProviderName="<%$ ConnectionStrings:gmatConnectionString.ProviderName %>" 
               SelectCommand="SELECT TOP 4 results.mid, results.met, Tests.IsPractice, Tests.Name, results.ge * 100 / results.all_cnt AS Result, results.max_score, q_cnt.value AS q_cnt FROM (SELECT Results_3.TestId AS tid, MAX(all_res.cnt) AS all_cnt, COUNT(1) AS ge, MAX(us.max_score) AS max_score, MAX(us.mid) AS mid, MAX(us.met) AS met FROM Results AS Results_3 INNER JOIN (SELECT MAX(EndTime) AS met, MAX(Id) AS mid, MAX(Score) AS max_score, TestId FROM Results AS Results_1 WHERE (UserId = @UserId) GROUP BY TestId) AS us ON us.TestId = Results_3.TestId AND us.max_score >= Results_3.Score INNER JOIN (SELECT TestId, COUNT(1) AS cnt FROM Results AS Results_2 GROUP BY TestId) AS all_res ON all_res.TestId = Results_3.TestId GROUP BY Results_3.TestId) AS results INNER JOIN Tests ON results.tid = Tests.Id INNER JOIN (SELECT TestContents.TestId AS id, SUM(QuestionSets.NumberOfQuestionsToPick) AS value FROM TestContents INNER JOIN QuestionSets ON TestContents.QuestionSetId = QuestionSets.Id GROUP BY TestContents.TestId) AS q_cnt ON q_cnt.id = Tests.Id ORDER BY results.mid DESC">
                  <SelectParameters>
                     <asp:SessionParameter Name="UserId" SessionField="UserId" />
                  </SelectParameters>
               </asp:SqlDataSource>
                                           
               <b>Custom tests:</b>
               <br /><br />
               <asp:GridView ID="ctView" runat="server" AutoGenerateColumns="False" DataKeyNames="Id"
                  DataSourceID="customTests" Width="100%" Font-Bold="False" GridLines="None" OnRowCommand="ctView_RowCommand">
                  <Columns>
                     <asp:TemplateField HeaderText="Id" InsertVisible="False" SortExpression="Id" Visible="False">
                        <ItemTemplate>
                           <asp:Label ID="id_lbl" runat="server" Text='<%# Bind("Id") %>'></asp:Label>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Name" SortExpression="Name">
                        <ItemStyle Width="200px" />
                        <ItemTemplate>
                           <asp:HyperLink ID="HyperLink1" runat="server" Text='<%# Bind("Name") %>' NavigateUrl='<%# "StartTest.aspx?idx="+DataBinder.Eval(Container.DataItem,"Id")+"&type=test&pkg_idx=-1" %>'></asp:HyperLink>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Created" SortExpression="created">
                        <ItemTemplate>
                           <asp:Label ID="Label1" runat="server" Text='<%# ((DateTime)DataBinder.Eval(Container.DataItem,"created")).Date.ToShortDateString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle Width="80px" />
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Rating" SortExpression="rating">
                        <ItemTemplate>
                           <%# rdrawer.draw((int)DataBinder.Eval(Container.DataItem, "Id"), (int)DataBinder.Eval(Container.DataItem, "rating"))%>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:ButtonField Text="[edit]" CommandName="edt" />
                     <asp:ButtonField Text="[del]" CommandName="del"/>
                  </Columns>
                  <HeaderStyle Font-Bold="True" />
               </asp:GridView>
               <asp:SqlDataSource ID="customTests" runat="server" ConnectionString="<%$ ConnectionStrings:gmatConnectionString %>"
                  SelectCommand="SELECT     Tests.Id, Tests.Name, Tests.rating, CustomTests.created&#13;&#10;FROM         CustomTests INNER JOIN&#13;&#10;                      Tests ON CustomTests.test_id = Tests.Id&#13;&#10;WHERE     (CustomTests.author = @UserId)">
                  <SelectParameters>
                     <asp:SessionParameter Name="UserId" SessionField="UserId" />
                  </SelectParameters>
               </asp:SqlDataSource>
               
               <br />
               <asp:HyperLink ID="create_ct" runat="server" NavigateUrl="CreateCustomTest.aspx">[Create custom Test]</asp:HyperLink>
               <br /><br />
               <hr style="width:100%; height:1 px" />
               <br />
               <b>Mistake Analysis (All Tests and Exercises)<br /></b>
               <b><a href="javascript: myMistakes(-1,'all')">[Start "My mistakes test"]</a></b>
               &nbsp;<asp:SqlDataSource ID="mistakes" runat="server" ConnectionString="<%$ ConnectionStrings:gmatConnectionString %>"
                  SelectCommand="SELECT correct_answers * 100 / (CASE WHEN all_answers = 0 OR all_answers IS NULL THEN 1 ELSE all_answers END) AS Value, Name, Id FROM (SELECT COUNT(Answers.Id) AS all_answers, SUM(CASE WHEN Answers.IsCorrect = 1 THEN 1 ELSE 0 END) AS correct_answers, QuestionSubtypes.Name,QuestionSubtypes.Id as Id FROM Results RIGHT OUTER JOIN ResultsDetails ON Results.Id = ResultsDetails.ResultId RIGHT OUTER JOIN Answers ON ResultsDetails.AnswerId = Answers.Id RIGHT OUTER JOIN Questions ON Answers.QuestionId = Questions.Id RIGHT OUTER JOIN QuestionSubtypes ON Questions.SubtypeId = QuestionSubtypes.Id WHERE (Results.UserId = @UserId) OR (Results.UserId IS NULL) GROUP BY QuestionSubtypes.Name,QuestionSubtypes.Id ) AS tt ORDER BY Name">
                  <SelectParameters>
                     <asp:SessionParameter Name="UserId" SessionField="UserId" />
                  </SelectParameters>
               </asp:SqlDataSource>
               <asp:GridView ID="mistakesGv" runat="server" DataSourceID="mistakes" Width="100%" AutoGenerateColumns="False" GridLines="Horizontal" ShowHeader="False">
                  <Columns>
                     <asp:TemplateField HeaderText="Name" InsertVisible="False" SortExpression="Name">
                        <ItemTemplate>
                           <a href='<%# "javascript: myMistakes("+DataBinder.Eval(Container.DataItem,"Id")+",\""+ DataBinder.Eval(Container.DataItem,"Name") + "\");" %> '> <%# DataBinder.Eval(Container.DataItem,"Name") %>  </a>
                        </ItemTemplate>
                     </asp:TemplateField>
                     <asp:TemplateField HeaderText="Value" InsertVisible="False" SortExpression="Value">
                        <ItemTemplate>
                           <asp:Image ID="img_prc" runat="server" ImageUrl='<%# "ProgressBar.aspx?w=150&h=20&p="+DataBinder.Eval(Container.DataItem,"Value") %>'></asp:Image>
                        </ItemTemplate>
                     </asp:TemplateField>
                  </Columns>
               
               </asp:GridView>
               <br />
               <br />
               <br />
               
               
               </td>
      		<td width="50%" valign="top" style="height: 158px">
               <asp:GridView ID="tinyResGv" runat="server" AutoGenerateColumns="False" DataSourceID="tinyResults"
                  OnSelectedIndexChanged="tinyResGv_SelectedIndexChanged" Width="100%">
                  <Columns>
                     <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name">
                        <ItemStyle Width="250px" />
                     </asp:BoundField>
                     <asp:BoundField DataField="Expr1" HeaderText="Value" ReadOnly="True" SortExpression="Expr1" />
                  </Columns>
                  <HeaderStyle BackColor="LightSteelBlue" />
                  <AlternatingRowStyle BackColor="#C0C0FF" />
               </asp:GridView>
               <asp:SqlDataSource ID="tinyResults" runat="server" ConnectionString="<%$ ConnectionStrings:gmatConnectionString %>"
                  SelectCommand="SELECT Name, COALESCE (Result, 0) AS Expr1 FROM (SELECT 100 AS rdr, QuestionTypes.Name, AVG(results.ge * 100 / results.all_cnt) AS Result FROM (SELECT Results_3.TestId AS tid, MAX(all_res.cnt) AS all_cnt, COUNT(1) AS ge, MAX(us.max_score) AS max_score, MAX(us.mid) AS mid FROM Results AS Results_3 INNER JOIN (SELECT MAX(Id) AS mid, MAX(Score) AS max_score, TestId FROM Results AS Results_1 WHERE (UserId = @UserId) GROUP BY TestId) AS us ON us.TestId = Results_3.TestId AND us.max_score >= Results_3.Score INNER JOIN (SELECT TestId, COUNT(1) AS cnt FROM Results AS Results_2 GROUP BY TestId) AS all_res ON all_res.TestId = Results_3.TestId GROUP BY Results_3.TestId) AS results INNER JOIN Tests ON results.tid = Tests.Id INNER JOIN (SELECT TestContents.TestId AS id, SUM(QuestionSets.NumberOfQuestionsToPick) AS value FROM TestContents INNER JOIN QuestionSets ON TestContents.QuestionSetId = QuestionSets.Id GROUP BY TestContents.TestId) AS q_cnt ON q_cnt.id = Tests.Id INNER JOIN QuestionTypes ON Tests.QuestionTypeId = QuestionTypes.Id GROUP BY QuestionTypes.Name UNION SELECT 1 AS rdr, 'Tests Taken' AS Expr1, COUNT(1) AS Result FROM Results AS Results_4 INNER JOIN Tests AS Tests_1 ON Tests_1.Id = Results_4.TestId AND Results_4.UserId = @UserId UNION SELECT 2 AS rdr, 'Exercises' AS Expr1, SUM(CASE WHEN Tests_1.isPractice = 1 THEN 1 ELSE 0 END) AS Result FROM Results AS Results_4 INNER JOIN Tests AS Tests_1 ON Tests_1.Id = Results_4.TestId AND Results_4.UserId = @UserId) AS trs ORDER BY rdr">
                  <SelectParameters>
                     <asp:SessionParameter Name="UserId" SessionField="UserId" />
                  </SelectParameters>
               </asp:SqlDataSource>
               <asp:Image ID="mathImage" runat="server" Height="160px" ImageUrl="UserChart.aspx?w=370&h=160&t=1" Width="370px" />
               <hr style="width:100%; height: 1px;" />
               <asp:Image ID="Image2" runat="server" Height="160px" ImageUrl="UserChart.aspx?w=370&h=160&t=2" Width="370px" />
               <hr style="width:100%; height: 1px;" />
               <asp:Image ID="Image3" runat="server" Height="160px" ImageUrl="UserChart.aspx?w=370&h=160&t=3" Width="370px" />
               </td>
      	</tr>
      </table>
   </asp:Panel>
   
   <asp:Panel ID="pTests" runat="server" Width="100%">
      <b>Active tests:</b><asp:GridView ID="gvTests" runat="server" AutoGenerateColumns="False" CellPadding="0" Width="100%">
         <Columns>
            <asp:BoundField DataField="idx" Visible="False"  />
            <asp:TemplateField>
               <ItemTemplate>
                  <asp:Image Width="16" Height="16" ID="Image1" runat="server" ImageUrl='<%# ((DateTime)DataBinder.Eval(Container.DataItem,"expires_at")) < DateTime.Now && ((DateTime)DataBinder.Eval(Container.DataItem,"expires_at"))!=((DateTime)DataBinder.Eval(Container.DataItem,"sold_at")) ?"i/expired.gif":"i/blank.gif" %>'/>
               </ItemTemplate>
               <ItemStyle Width="16"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="">
               <ItemTemplate>
                  <asp:Image Width="16" Height="16" ID="Image1" runat="server" ImageUrl='<%# ((int)DataBinder.Eval(Container.DataItem,"type")) == 1?"i/package.gif":((int)DataBinder.Eval(Container.DataItem,"type")) == 2?"i/test.gif":"i/pdf.gif" %>'/>
               </ItemTemplate>
               <ItemStyle Width="16" />
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Name">
               <ItemTemplate>
                 <asp:Label ID="lbl2" runat="server"  Text='<%#((int)DataBinder.Eval(Container.DataItem,"type")) != 1 && ((int)DataBinder.Eval(Container.DataItem,"parent"))!=-1?"&nbsp;":" " %>' />
                 <asp:HyperLink ID="lTests" runat="server" NavigateUrl='<%# build_url(Container.DataItem) %>' Text='<%# DataBinder.Eval(Container.DataItem,"name") %>'></asp:HyperLink> 
               </ItemTemplate>
               <ItemStyle Width="40%" />
            </asp:TemplateField>
            <asp:BoundField DataField="sold_at" HeaderText="Sold at" />
            <asp:TemplateField HeaderText="Left">
               <ItemTemplate>
                  <asp:Label ID="lLeft2" runat="server" Text='<%# build_left(Container.DataItem) %>'/>
               </ItemTemplate>
               
            </asp:TemplateField>
            
            
         </Columns>
      </asp:GridView>
      &nbsp;&nbsp;
   </asp:Panel>
   <asp:Panel ID="pProfile" runat="server" Visible="False" Width="100%">
      <strong>Profile:</strong>
      <br />
      Login &nbsp; &nbsp; &nbsp;&nbsp; &nbsp;<asp:TextBox ID="login" runat="server" CssClass="itt"
         ReadOnly="True"></asp:TextBox>
      <asp:RequiredFieldValidator ID="lgnreq" runat="server" ControlToValidate="login"
         ErrorMessage="Login Required"></asp:RequiredFieldValidator><br />
      Password&nbsp;
      <asp:TextBox ID="pwd" runat="server" CssClass="itt" TextMode="Password"></asp:TextBox>
      <asp:CompareValidator ID="cpr" runat="server" ControlToCompare="pwd_check" ControlToValidate="pwd"
         ErrorMessage="Passwords not equal"></asp:CompareValidator>
      <asp:RequiredFieldValidator ID="pwdreq" runat="server" ControlToValidate="pwd" ErrorMessage="Password can't be empty"></asp:RequiredFieldValidator><br />
      Password&nbsp;
      <asp:TextBox ID="pwd_check" runat="server" CssClass="itt" TextMode="Password"></asp:TextBox>
      again<br />
      <asp:LinkButton ID="chgPwd" runat="server" CausesValidation="False" OnClick="chgPwd_Click">Change password</asp:LinkButton>&nbsp;
      <br />
      <hr style="height: 1px; width:100%" />
      <asp:SqlDataSource id="props" runat="server" SelectCommand="SELECT acl_user_prop_value.idx as prop_idx, acl_property.idx AS template_idx, acl_user_prop_value.user_idx, acl_user_prop_value.value as value, acl_property.name as name, acl_property.human_name as human_name, acl_property.nesses as nesses, acl_property.is_user_editable as is_user_editable, acl_property.is_internal as is_internal &#13;&#10;FROM acl_property LEFT OUTER JOIN acl_user_prop_value ON &#13;&#10;(acl_property.idx = acl_user_prop_value.prop_idx &#13;&#10;AND (acl_user_prop_value.user_idx = @user_idx OR acl_user_prop_value.user_idx IS NULL)&#13;&#10;) &#13;&#10;WHERE (acl_property.is_internal = @is_internal) AND (acl_property.is_user_editable = @is_user_editable) order by acl_property.idx;" ConnectionString="<%$ ConnectionStrings:gmatConnectionString %>">
      <SelectParameters>
         <asp:SessionParameter Name="user_idx" SessionField="UserId" Type="Int32" />
         <asp:Parameter DefaultValue="false" Name="is_internal" Type="Boolean" />
         <asp:Parameter DefaultValue="true" Name="is_user_editable" Type="Boolean" />
      </SelectParameters>
   </asp:SqlDataSource><asp:GridView id="propsview" runat="server" CaptionAlign="Left" Caption="Other user info" DataSourceID="props" DataKeyNames="name" AutoGenerateColumns="False">
         <Columns>
            <asp:TemplateField HeaderText="name" SortExpression="name" Visible="False">
               <ItemTemplate>
                  <asp:Label ID="name" runat="server" Text='<%# Bind("name") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="idx" SortExpression="idx" Visible="False">
               <ItemTemplate>
                  <asp:Label ID="lblidx" runat="server" Text='<%# Bind("prop_idx") %>'></asp:Label>
               </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="human_name" HeaderText="Property" SortExpression="idx">
               <ItemStyle CssClass="itt" Width="200px"  />
            </asp:BoundField>
            
            <asp:CheckBoxField DataField="nesses" HeaderText="nesses" SortExpression="nesses"
               Visible="False" ></asp:CheckBoxField>
               
            <asp:TemplateField HeaderText="Value" SortExpression="idx">
               <ItemStyle CssClass="itt" Width="200px"  />
               <ItemTemplate>
                  <asp:TextBox Width="200px" CssClass="itt" ID="value_box" runat="server" Text='<%# Bind("value") %>'></asp:TextBox>
               </ItemTemplate>
            </asp:TemplateField>
         </Columns>
      </asp:GridView>      
      <br />
      &nbsp;<asp:LinkButton ID="save" runat="server" OnClick="save_Click" CausesValidation="False">Save changes</asp:LinkButton></asp:Panel>
      

   <asp:Panel ID="pResults" runat="server" Visible="False" Width="100%">
   <table width="100%">
   <tr>
   <td valign="top">
   <table id="Table2" border="0" cellpadding="1" cellspacing="1" width="100%">
      <tr>
         <td >
            <table id="Table6" border="0" cellpadding="1" cellspacing="1">
               <tr>
                  <td><b>Results:</b></td>
               </tr>
            </table>
            <asp:DataGrid ID="resultsGrid" runat="server" AutoGenerateColumns="False" DataMember="Results"
               DataSource="<%# resultsSet %>" OnSelectedIndexChanged="resultsGrid_SelectedIndexChanged" GridLines="Horizontal" Width="100%">
               <HeaderStyle Font-Bold="True" />
               <Columns>
                  <asp:ButtonColumn CommandName="Select" DataTextField="TestName" HeaderText="Test name"
                     Text="Test name"></asp:ButtonColumn>
                  <asp:BoundColumn DataField="TestName" HeaderText="Test name" ReadOnly="True" SortExpression="TestName"
                     Visible="False"></asp:BoundColumn>
                  <asp:BoundColumn DataField="StartTime" DataFormatString="{0:g}" HeaderText="Start time"
                     ReadOnly="True" SortExpression="StartTime"></asp:BoundColumn>
                  <asp:BoundColumn DataField="EndTime" DataFormatString="{0:g}" HeaderText="End time"
                     ReadOnly="True" SortExpression="EndTime"></asp:BoundColumn>
                  <asp:BoundColumn DataField="Score" HeaderText="Score" ReadOnly="True" SortExpression="Score">
                  </asp:BoundColumn>
                  <asp:TemplateColumn></asp:TemplateColumn>
                  <asp:BoundColumn DataField="Id" HeaderText="Id" SortExpression="Id" Visible="False">
                  </asp:BoundColumn>
                  <asp:BoundColumn DataField="UserId" HeaderText="UserId" SortExpression="UserId" Visible="False">
                  </asp:BoundColumn>
                  <asp:BoundColumn DataField="TestId" HeaderText="TestId" SortExpression="TestId" Visible="False">
                  </asp:BoundColumn>
               </Columns>
               <AlternatingItemStyle BackColor="#E0E0E0" />
            </asp:DataGrid>
         </td>
      </tr>
   </table>
   </td>
   <td width="250">
   <table id="Table4" align="left" border="0" cellpadding="1" cellspacing="1" style="background-color:#eeeeee;">
      <tr>
         <td>
            <table id="Table7" border="0" cellpadding="1" cellspacing="1">
               <tr>
                  <td><b>From</b></td>
               </tr>
            </table>
            <asp:Calendar ID="beginCalendar" runat="server" OnSelectionChanged="beginCalendar_SelectionChanged"
               ShowGridLines="True" Width="232px"></asp:Calendar>
         </td>
      </tr>
      <tr>
         <td align="left" style="height: 239px">
            <table id="Table8" border="0" cellpadding="1" cellspacing="1">
               <tr>
                  <td><b>To</b></td>
               </tr>
            </table>
            <asp:Calendar ID="endCalendar" runat="server" EnableTheming="True" FirstDayOfWeek="Monday"
               OnSelectionChanged="endCalendar_SelectionChanged" ShowGridLines="True" Width="232px">
            </asp:Calendar>
         </td>
      </tr>
   </table>
   </td></tr>
   </table>   
   </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ajax_windows" Runat="Server">
      <div style="width:500px; visibility:hidden; background-color: #FFFBB7; border: solid 1px #C3C1A8; text-align: left;" id="cnt" >
         <img id='close_id' style='cursor: pointer; border: none; 0 pt;' src='i/x.gif' height='15' width='15' alt='Close' onclick="javascript: document.getElementById('cnt').style.visibility='hidden'; return false;"/>
         <div id="c_place" style="border: none; 2 px; "></div>
         <div id="op_e_place" style="border: none; 2 px;  color: red;"></div>
    </div>
</asp:Content>

