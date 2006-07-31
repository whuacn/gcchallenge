using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
	public class VerbalPractices: FolderWithTests
	{
		public VerbalPractices(Practices parent): base("IsPractice=1 AND QuestionTypeId="+(int)QuestionType.Type.Verbal, "Verbal", parent)
		{
		}

		internal override bool DoCanAddNewChild(Entity entity)
		{
			Test t = entity as Test;
			return t != null && t.Value.IsPractice && !t.Value.IsQuestionTypeIdNull() && t.Value.QuestionTypeId == (int)QuestionType.Type.Verbal;
		}
	}
}
