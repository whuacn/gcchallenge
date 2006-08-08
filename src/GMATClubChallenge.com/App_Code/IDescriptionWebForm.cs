using System.Web.UI;

namespace GmatClubTest.Web
{
    public abstract class IDescriptionWebForm : Page
    {
        public string descriptionString = "";
        public abstract void Caption(string caption);
        public abstract void DescriptionString(string descriptionString);
    }
}