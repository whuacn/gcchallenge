using System;

namespace GmatClubTest.BusinessLogic
{
    /// <summary>
    /// Thrown by INavigator when set time is up.
    /// </summary>
    public class TimeIsUpException : Exception
    {
        public TimeIsUpException() : base("Time is up")
        {
        }
    }
}