using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
	public class QuantitativeSets: FolderWithSets
	{
		public QuantitativeSets(QuestionSets parent): base("QuestionTypeId="+(int)QuestionType.Type.Quantitative, "Quantitative", parent)
		{
		}

		internal override bool DoCanAddNewChild(Entity entity)
		{
			QuestionSet t = entity as QuestionSet;
			return t != null && !t.Value.IsQuestionTypeIdNull() && t.Value.QuestionTypeId == (int)QuestionType.Type.Quantitative;
		}
	}
}
