using System;
using System.Collections.Generic;
using System.Text;

namespace TK_DataComparerLib
{
    public class ComparisonScore : IComparable
    {
        DataEntity _leftEntity = null;

        public DataEntity LeftEntity
        {
            get { return _leftEntity; }
            set { _leftEntity = value; }
        }
        DataEntity _rightEntity = null;

        public DataEntity RightEntity
        {
            get { return _rightEntity; }
            set { _rightEntity = value; }
        }
        double _score = -1.0;

        public double Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public ComparisonScore(DataEntity leftEntity, DataEntity rightEntity, double score)
        {
            _leftEntity = leftEntity;
            _rightEntity = rightEntity;
            _score = score;
        }

        public int CompareTo(object obj)
        {
            ComparisonScore otherScore = obj as ComparisonScore;

            if (otherScore == null)
            {
                return 1;
            }

            return _score.CompareTo(otherScore.Score);
        }
    }
}
