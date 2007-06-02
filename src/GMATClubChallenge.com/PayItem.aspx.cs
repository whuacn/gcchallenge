using System;
using Shop;

namespace GMATClubTest.Web
{
    public partial class PayItem : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            string redir = "";
            try
            {
                if (null != Request["payed"] && Request["payed"] == "true")
                {
                    transaction_id = new Guid(Request["transaction_id"]);
                    amount = Request["amt"];

                    string[] spl = amount.Split('.');
                    Decimal m = new Decimal(((double) Int32.Parse(spl[0])) + ((double) Int32.Parse(spl[1]))/100);
                    redir =
                        ShopManager.complite_transaction(access_manager_, transaction_id, m,
                                                         "StartTest.aspx?idx={0}&type={1}&pkg_idx={2}");
                }
                else
                {
                    idx = Int32.Parse(Request["idx"]);
                    type = Request["type"].ToString();
                    package_idx = Int32.Parse(Request["pkg_idx"]);
                    if (-1 == package_idx) package_idx = idx;

                    Decimal money = ShopManager.get_product_price(connection_, idx, type, package_idx);
                    Double d = (Double) money;

                    amount = ((int) d).ToString() + "." + (((int) (d - ((double) ((int) d))))*100).ToString("D2");

                    item_name = ShopManager.get_product_description(connection_, idx, type, package_idx);
                    item_id = idx.ToString();

                    transaction_id = Guid.NewGuid();
                    ShopManager.create_transaction(connection_, transaction_id, idx, type, package_idx, money);
                }
            }
            catch (Exception ee)
            {
                Session["error_message"] = ee.Message;
                Response.Redirect("Error.aspx");
            }
            if ("" != redir)
            {
                Response.Redirect(redir);
            }
        }


        protected string item_name;
        protected string item_id;
        protected string amount;

        protected int idx;
        protected string type;
        protected int package_idx;

        protected Guid transaction_id;
    }
}