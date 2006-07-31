using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
	public class VerbalSets: FolderWithSets
	{
		public VerbalSets(QuestionSets parent): base("QuestionTypeId="+(int)QuestionType.Type.Verbal, "Verbal", parent)
		{
		}

		internal override bool DoCanAddNewChild(Entity entity)
		{
			QuestionSet t = entity as QuestionSet;
			return t != null && !t.Value.IsQuestionTypeIdNull() && t.Value.QuestionTypeId == (int)QuestionType.Type.Verbal;
		}
	}
}
