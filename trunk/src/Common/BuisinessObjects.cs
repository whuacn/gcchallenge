using System;
using System.Collections.Generic;
using System.Text;

namespace GmatClubTest.Common
{
    public static class BuisinessObjects
    {
        public enum Type
        {
            Quantitative = 1,
            Verbal = 2
        };

        public static readonly String[] TypeNames = new String[] { "Mixed", "Quantitative", "Verbal" };
        public static readonly String[] SubtypeNames = new String[] { "Not defined", "Data Sufficiency", "Problem Solving", "", "Reading Comprehension", "Critical Reasoning", "Sentence Correction" };

        //Maybe need read this constants from DataBase
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
        // This values valid only for my database! 
        //Start ChangeSubTypesFor2.0ver.sql and Update this constants.


        public enum DifficultyLevel
        {
            Easy = 1,
            Medium = 2,
            Hard = 3
        } ;

        public enum StatusType
        {
            NOT_SEEN = 0,
            SEEN = 1,
            ANSWER_IS_CORRECT = 2,
            ANSWER_IS_INCORRECT = 3
        } ;
    }
}
