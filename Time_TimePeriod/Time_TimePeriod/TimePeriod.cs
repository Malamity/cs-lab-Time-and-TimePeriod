using System;
using System.Collections.Generic;
using System.Text;

namespace Time_TimePeriod
{
    internal class TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        private readonly long seconds;
        private readonly byte minutes;
        private readonly byte hours;
        private long sumTime;

        public long SumTime
        {
            get
            {
                return sumTime;
            }
            set
            {
                sumTime = value;
                if (sumTime < 0)
                {
                    throw new ArgumentException(nameof(sumTime), "suma czasu jest mniejsza od zera");
                }
            }
        }

        public long Seconds
        {
            get
            {
                return seconds;
            }
        }

        public byte Minutes
        {
            get
            {
                return minutes;
            }
        }

        public byte Hours
        {
            get
            {
                return hours;
            }
        }
    }
}
