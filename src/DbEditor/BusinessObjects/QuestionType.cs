using System;

namespace GmatClubTest.DbEditor.BusinessObjects
{
	public struct QuestionType: IComparable
	{
		public enum Type {Quantitative = 1, Verbal = 2};
		
		public enum Subtype	
		{
			DataSufficiency = 1, 
			ProblemSolving = 2,
			ReadingComprehensionPassage = 3, 
			ReadingComprehensionQuestionToPassage = 4,
			CriticalReasoning = 5,
			SentenceCorrection = 6
		};

		public static readonly String[] TypeNames = new String[] {"Mixed", "Quantitative", "Verbal"};
		public static readonly String[] SubtypeNames = new String[] {"Not defined", "Data Sufficiency", "Problem Solving", "", "Reading Comprehension", "Critical Reasoning", "Sentence Correction"};

		private OptionalInteger questionTypeId;
		private OptionalInteger questionSubtypeId;
		
		public QuestionType(Type type)
		{
			this.questionTypeId = new OptionalInteger((int)type);
			this.questionSubtypeId = new OptionalInteger();
		}

		public QuestionType(Subtype subtype)
		{
			this.questionTypeId = new OptionalInteger();
			this.questionSubtypeId = new OptionalInteger((int)subtype);
		}

		public QuestionType(OptionalInteger questionTypeId, OptionalInteger questionSubtypeId)
		{
			this.questionTypeId = questionTypeId;
			this.questionSubtypeId = questionSubtypeId;
		}

		public OptionalInteger QuestionTypeId {get {return questionTypeId;}}
		public OptionalInteger QuestionSubtypeId {get {return questionSubtypeId;}}

		public bool IsSubsetOf(QuestionType questionType)
		{
			if (questionType.questionTypeId.HasValue)
			{
				if (this.questionTypeId.HasValue)
				{
					return questionType.questionTypeId.Value == this.questionTypeId.Value;
				}
				else
				{
					if (!this.questionSubtypeId.HasValue) return false;

					if (questionType.questionTypeId.Value == (int)Type.Quantitative)
					{
						return this.questionSubtypeId.Value == (int)Subtype.DataSufficiency || this.questionSubtypeId.Value == (int)Subtype.ProblemSolving;
					} else
					{
						return this.questionSubtypeId.Value == (int)Subtype.ReadingComprehensionQuestionToPassage || this.questionSubtypeId.Value == (int)Subtype.CriticalReasoning || this.questionSubtypeId.Value == (int)Subtype.SentenceCorrection;
					}
				}
			}

			if (!questionType.questionSubtypeId.HasValue) return true;
			if (!this.questionSubtypeId.HasValue) return false;

			return this.questionSubtypeId.Value == questionType.questionSubtypeId.Value;
		}

		public static QuestionType CreateMixed()
		{
			return new QuestionType(new OptionalInteger(), new OptionalInteger());
		}

		public override int GetHashCode()
		{
			return this.questionTypeId.GetHashCode() + this.questionSubtypeId.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType()) return false;
			QuestionType arg = (QuestionType)obj;

			return this.questionTypeId.Equals(arg.questionTypeId) && this.questionSubtypeId.Equals(arg.questionSubtypeId);
		}

		public override string ToString()
		{
			if (questionSubtypeId.HasValue)
				return SubtypeNames[questionSubtypeId.Value];

			if (questionTypeId.HasValue)
				return TypeNames[questionTypeId.Value];

			return TypeNames[0];
		}

		public int CompareTo(object obj)
		{
			if (!(obj is QuestionType)) throw new ArgumentException("Argument is not an QuestionType", "obj");
			QuestionType arg = (QuestionType)obj;

			int res = questionSubtypeId.CompareTo(arg.questionSubtypeId);
			if (res != 0) return res;

			return questionTypeId.CompareTo(arg.questionTypeId);
		}
	}

	public struct OptionalInteger: IComparable
	{
		private int value;
		private bool hasValue;

		public int Value
		{
			get { if (!hasValue) throw new InvalidOperationException("OptionalInteger has no value.") ; return value; }
			set { this.value = value; hasValue = true;}
		}

		public bool HasValue
		{
			get { return hasValue; }
		}

		public OptionalInteger(int value)
		{
			this.value = value;
			hasValue = true;
		}

		public OptionalInteger(Object value)
		{
			if (value == null)
			{
				this.value = -1;
				this.hasValue = false;
				return;
			}

			this.value = (int)value;
			this.hasValue = true;
		}

		public override int GetHashCode()
		{
			return value.GetHashCode() + hasValue.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null || GetType() != obj.GetType()) return false;
			OptionalInteger arg = (OptionalInteger)obj;

			if (this.hasValue != arg.hasValue)
				return false;

			if (!this.hasValue) return true;
			return this.value == arg.value;
		}

		public override string ToString()
		{
			if (!hasValue) return "[no value]";
			return value.ToString();
		}

		public int CompareTo(object obj)
		{
			if (!(obj is OptionalInteger)) throw new ArgumentException("Argument is not an OptionalInteger", "obj");
			OptionalInteger arg = (OptionalInteger)obj;

			if (this.hasValue != arg.hasValue)
				return this.hasValue ? 1 : -1;

			if (!this.hasValue) return 0;
			if (this.value == arg.value) return 0;

			return this.value > arg.value ? 1 : -1;
		}
	}
}
