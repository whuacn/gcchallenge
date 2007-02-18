using System;
using GmatClubTest.Common;

namespace GmatClubTest.DbEditor.BusinessObjects
{
   public struct QuestionType: IComparable
   {
      public enum Type {Quantitative = 1, Verbal = 2};
      
      public enum Subtype   
      {
            ReadingComprehensionPassage = 3,
            ReadingComprehensionQuestionToPassage = 4,
            CriticalReasoning = 5,
            SentenceCorrection = 6,
            Arithmetic = 7,
            Algebra = 8,
            WordProblems = 9,
            Geometry = 10,
            Statistics = 11,
            Probability = 12,
            Combinations = 13
      };

     

      private OptionalInteger questionTypeId;
      private OptionalInteger questionSubtypeId;
      
      public QuestionType(Type type)
      {
         this.questionTypeId = new OptionalInteger((int)type);
         this.questionSubtypeId = new OptionalInteger();
      }

       public QuestionType(BuisinessObjects.Subtype subtype)
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

               if (questionType.questionTypeId.Value == (int)BuisinessObjects.Type.Quantitative)
               {
                   return
                       questionSubtypeId.Value == (int) BuisinessObjects.Subtype.CriticalReasoning ||
                       questionSubtypeId.Value == (int)BuisinessObjects.Subtype.Algebra ||
                       questionSubtypeId.Value == (int)BuisinessObjects.Subtype.Arithmetic ||
                       questionSubtypeId.Value == (int)BuisinessObjects.Subtype.Combinations ||
                       questionSubtypeId.Value == (int)BuisinessObjects.Subtype.Geometry ||
                       questionSubtypeId.Value == (int)BuisinessObjects.Subtype.Probability ||
                       questionSubtypeId.Value == (int)BuisinessObjects.Subtype.SentenceCorrection ||
                       questionSubtypeId.Value == (int)BuisinessObjects.Subtype.Statistics ||
                       questionSubtypeId.Value == (int)BuisinessObjects.Subtype.WordProblems;
               } else
               {
                   return questionSubtypeId.Value == (int)BuisinessObjects.Subtype.ReadingComprehensionQuestionToPassage || questionSubtypeId.Value == (int)BuisinessObjects.Subtype.CriticalReasoning || this.questionSubtypeId.Value == (int)BuisinessObjects.Subtype.SentenceCorrection;
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
             return BuisinessObjects.SubtypeNames[questionSubtypeId.Value];

         if (questionTypeId.HasValue)
             return BuisinessObjects.TypeNames[questionTypeId.Value];

         return BuisinessObjects.TypeNames[0];
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
