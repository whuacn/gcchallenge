using GmatClubTest.BusinessLogic;

namespace GmatClubTest.Practice
{
	/// <summary>
	/// Summary description for ITestForm.
	/// </summary>
	public interface ITestForm
	{
		void ReEnableButtons(INavigator navigator);
		void ChangeCaption(string caption);
	}
}
