using System;

namespace Time_TimePeriod
{
    public struct TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
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

        public TimePeriod(byte hours, byte minutes, long seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;
            this.sumTime = seconds + minutes * 60 + hours * 3600;

            if (Hours < 0) { throw new ArgumentException(nameof(Hours), "wartość Godziny jest ujemna"); }
            if (Minutes < 0) { throw new ArgumentException(nameof(Minutes), "wartość Minuty jest ujemna"); }
            if (Seconds < 0) { throw new ArgumentException(nameof(Seconds), "wartość Sekundy jest ujemna"); }
        }

        public TimePeriod(byte hours, byte minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = 00;
            this.sumTime = minutes * 60 + hours * 3600;

            if (Hours < 0) { throw new ArgumentException(nameof(Hours), "wartość Godziny jest ujemna"); }
            if (Minutes < 0) { throw new ArgumentException(nameof(Minutes), "wartość Minuty jest ujemna"); }
        }

        public TimePeriod(long seconds)
        {
            this.hours = (byte)(seconds / 3600);
            seconds %= 3600;
            this.minutes = (byte)(seconds/60);
            this.seconds = seconds % 60;
            this.sumTime = seconds;

            if (Hours < 0) { throw new ArgumentException(nameof(Hours), "wartość Godziny jest ujemna"); }
            if (Minutes < 0) { throw new ArgumentException(nameof(Minutes), "wartość Minuty jest ujemna"); }
            if (Seconds < 0) { throw new ArgumentException(nameof(Seconds), "wartość Sekundy jest ujemna"); }
        }

        public TimePeriod(Time left, Time right)
        {
            this.sumTime = left.Seconds - right.Seconds + left.Minutes * 60 - right.Minutes * 60+left.Hours*3600-right.Hours*3600;

            this.hours = (byte)(sumTime/3600);
            this.minutes = (byte)((sumTime/60)%60);
            this.seconds = sumTime % 60;

            if (Hours < 0) { throw new ArgumentException(nameof(Hours), "wartość Godziny jest ujemna"); }
            if (Minutes < 0) { throw new ArgumentException(nameof(Minutes), "wartość Minuty jest ujemna"); }
            if (Seconds < 0) { throw new ArgumentException(nameof(Seconds), "wartość Sekundy jest ujemna"); }
        }

        public TimePeriod(string time)
        {
            string[] timeInString = time.Split(':');
            long[] timeInByteInArray = Array.ConvertAll(timeInString, long.Parse);
            this.hours=(byte)timeInByteInArray[0];
            this.minutes = (byte)timeInByteInArray[1];
            this.seconds = timeInByteInArray[2];
            this.sumTime = this.seconds + this.minutes * 60 + this.hours * 3600;

            if (Hours < 0) { throw new ArgumentException(nameof(Hours), "wartość Godziny jest ujemna"); }
            if (Minutes < 0) { throw new ArgumentException(nameof(Minutes), "wartość Minuty jest ujemna"); }
            if (Seconds < 0) { throw new ArgumentException(nameof(Seconds), "wartość Sekundy jest ujemna"); }
        }

        public override string ToString()
        {
            return Hours + ":" + Minutes + ":" + Seconds;
        }

        public bool Equals(TimePeriod other)
        {
            if (this.Hours == other.Hours && this.Minutes == other.Minutes && this.Seconds == other.Seconds) 
            { 
                return true;
            }
            else 
            { 
                return false;
            }
        }

        public override bool Equals(object obj)
        {
            if(obj==null || !(obj is TimePeriod)) return false;

            return Equals((TimePeriod)obj);
        }

        public override int GetHashCode()
        {
            int hash = 13;

            hash = (hash * 7) + Hours.GetHashCode();
            hash = (hash * 7) + Minutes.GetHashCode();
            hash = (hash * 7) + Seconds.GetHashCode();
            return hash;
        }

        public static bool operator ==(TimePeriod left, TimePeriod right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TimePeriod left, TimePeriod right)
        {
            return !(left == right);
        }

        public int CompareTo(TimePeriod other)
        {
            if (this.Hours > other.Hours) return -1;
            if (this.Hours == other.Hours && this.Minutes == other.Minutes && this.Seconds == other.Seconds) return 0;
            return 1;
        }

        public static bool operator <(TimePeriod left, TimePeriod right)
        {
            if (left.Hours < right.Hours)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator <=(TimePeriod left, TimePeriod right)
        {
            if (left.Hours < right.Hours || left.Equals(right))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public static bool operator >(TimePeriod left, TimePeriod right)
        {
            if (left.Hours > right.Hours)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public static bool operator >=(TimePeriod left, TimePeriod right)
        {
            if (left.Hours > right.Hours || left.Equals(right))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public TimePeriod Plus(TimePeriod timeToAdd)
        {
            this.SumTime += timeToAdd.SumTime;
            return new TimePeriod(this.SumTime);
        }

        public static TimePeriod Plus(TimePeriod timeToAdd1, TimePeriod timeToAdd2)
        {
            long Sum = timeToAdd1.SumTime + timeToAdd2.SumTime;
            return new TimePeriod(Sum);
        }

        public TimePeriod Minus(TimePeriod timeToSubtract)
        {
            long sumTime = Hours * 3600 + Minutes * 60 + Seconds - timeToSubtract.SumTime;

            while((sumTime / 3600) % 24 < 0)
            {
                sumTime += 24 * 3600;
            }
            while((sumTime / 60) % 60 < 0)
            {
                sumTime += 86400;
            }
            while (sumTime % 60 < 0)
            {
                sumTime += 86400;
            }
            return new TimePeriod(sumTime);
        }

        public static TimePeriod Minus(TimePeriod timeToSubtract1, TimePeriod timeToSubtract2)
        {
            long sumTime = timeToSubtract1.Hours * 3600 + timeToSubtract1.Minutes * 60 + timeToSubtract1.Seconds - timeToSubtract2.SumTime;

            while ((sumTime / 3600) % 24 < 0)
            {
                sumTime += 24 * 3600;
            }
            while ((sumTime / 60) % 60 < 0)
            {
                sumTime += 86400;
            }
            while (sumTime % 60 < 0)
            {
                sumTime += 86400;
            }
            return new TimePeriod(sumTime);
        }

        public static TimePeriod operator +(TimePeriod left,  TimePeriod right)
        {
            return new TimePeriod(left.SumTime + right.SumTime);
        }

        public static TimePeriod operator -(TimePeriod left, TimePeriod right)
        {
            long sumTime = left.Hours * 3600 + left.Minutes * 60 + left.Seconds - right.SumTime;

            while ((sumTime / 3600) % 24 < 0)
            {
                sumTime += 24 * 3600;
            }
            while ((sumTime / 60) % 60 < 0)
            {
                sumTime += 86400;
            }
            while (sumTime % 60 < 0)
            {
                sumTime += 86400;
            }
            return new TimePeriod(sumTime);
        }
    }
}
