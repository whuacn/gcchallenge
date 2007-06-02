using System;
using System.Collections.Generic;
using System.Text;

namespace GmatClubTest.BusinessLogic
{
    /// <summary>
    /// Question identity 
    /// </summary>
    public class QuestionIdentity: IEquatable<QuestionIdentity>
    {
        private int _setId;
        private int _questionId;
        public QuestionIdentity(int setId, int questionId)
        {
            _setId = setId;
            _questionId = questionId;
        }

        public int SetId { get { return _setId; } }
        public int QuestionId { get { return _questionId; } }

        //Overide Equals for correctly comparison
        public override bool Equals(object obj)
        {
            if (obj == null)
                return base.Equals(obj);

            if (obj.GetType() == typeof(QuestionIdentity))
            {
                QuestionIdentity qi = (QuestionIdentity)obj;
                return
                    _setId == qi.SetId &&
                    _questionId == qi.QuestionId;
            }
            return base.Equals(obj);
        }

        //Overide GetHashCode for correctly comparison
        public override int GetHashCode()
        {
            return _setId.GetHashCode() ^ _questionId.GetHashCode();
        }

        public static bool operator ==(QuestionIdentity a, QuestionIdentity b)
        {
            if (Equals(a, null) || Equals(b, null))
                return false;

            bool itEqual = a.SetId == b.SetId && a._questionId == b.QuestionId;
            return itEqual;
        }

        public static bool operator !=(QuestionIdentity a, QuestionIdentity b)
        {
            if (a == null || b == null)
                return false;
           
            return !(a == b);
        }

        public bool Equals(QuestionIdentity other)
        {
            if (Equals(other, null))
                return false;

            return _setId == other.SetId && _questionId == other.QuestionId;
        }
    }
}
