using GmatClubTest.DbEditor.Tree;

namespace GmatClubTest.DbEditor.BusinessObjects
{
	public class MixedAdaptiveTests: FolderWithTests
	{
		public MixedAdaptiveTests(AdaptiveTests parent): base("IsPractice=0 AND Isnull(QuestionTypeId, -1)=-1", "Mixed", parent)
		{
		}

		internal override bool DoCanAddNewChild(Entity entity)
		{
			Test t = entity as Test;
			return t != null && !t.Value.IsPractice && t.Value.IsQuestionTypeIdNull();
		}
	}
}
