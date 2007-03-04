<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PayItem.aspx.cs" Inherits="GMATClubTest.Web.PayItem" %>

<div id="forms">
<table border="0" cellpadding="0" cellspacing="0">
<tr>
<td valign="middle">
<form style="margin: 0px; padding: 0px;" action="https://www.sandbox.paypal.com/cgi-bin/webscr" method="post">
   <input type="image" src="https://www.paypal.com/en_US/i/btn/x-click-but23.gif" name="submit"  alt="Make payments with payPal - it's fast, free and secure!">
   <input type="hidden" name="cmd" value="_xclick">
   <input type="hidden" name="business" value="boss@gmatclub.com">
   <input type="hidden" name="item_name" value="<% =item_name %>">
   <input type="hidden" name="item_number" value="<% =item_id %>">
   <input type="hidden" name="amount" value="<%=amount %>">
   <input type="hidden" name="no_shipping" value="1">
   <input type="hidden" name="no_note" value="1">
   <input type="hidden" name="currency_code" value="USD">
   <input type="hidden" name="bn" value="IC_Sample">
   <input type="hidden" name="return" value="http://localhost:3866/GMATClubChallenge.com/PayItem.aspx?payed=true&transaction_id=<% =transaction_id %>">
   
</form>
</td>
<td>&nbsp;&nbsp;</td>
<td style="font-family:Verdana; font-size: 8pt;">
Pay <b>$<%=amount %></b> for <b><% =item_name %></b> by PayPal 
</td>
</tr>
</table>

</div>