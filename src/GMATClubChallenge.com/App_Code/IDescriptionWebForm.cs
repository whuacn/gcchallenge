using System.Web.UI;
using System.Web.UI.WebControls;

namespace GmatClubTest.Web
{
    abstract public class IDescriptionWebForm : Page
    {
        public string descriptionString = "";
        abstract public void Caption(string caption);
        abstract public void DescriptionString (string descriptionString);
    }
}
