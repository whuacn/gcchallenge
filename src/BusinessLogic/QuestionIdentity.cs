using System;
using System.Collections.Generic;
using System.Text;

namespace GmatClubTest.BusinessLogic
{
    /// <summary>
    /// Question identity 
    /// </summary>
    public class QuestionIdentity
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
            if (obj is QuestionIdentity)
            {
                return
                    _setId == (obj as QuestionIdentity).SetId &&
                    _questionId == (obj as QuestionIdentity).QuestionId;
            }
            return base.Equals(obj);
        }

        //Overide GetHashCode for correctly comparison
        public override int GetHashCode()
        {
            return _setId.GetHashCode() ^ _questionId.GetHashCode();
        }
    }
}
