using System.Drawing;

namespace GmatClubTest.QuestionRenderer
{
	/// <summary>
	/// Contains image of a question and its answers. 
	/// </summary>
	public class ImageSet
	{
		internal Image question;
		internal Image[] answers; 

		public Image Question
		{
			get { return question; }
		}

		public Image[] Answers
		{
			get { return answers; }
		}
	}
}
