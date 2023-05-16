using System;
using System.Security.Cryptography.X509Certificates;

namespace Time_TimePeriod
{
    public class Time : IEquatable<Time>, IComparable<Time>
    {
        private readonly byte seconds;
        private readonly byte minutes;
        private readonly byte hours;

        public byte Seconds { get { return seconds;} }

        public byte Minutes { get { return minutes; } }

        public byte Hours { get { return hours; } }

        public Time(byte hours, byte minutes, byte seconds)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = seconds;

            if (Hours < 0) throw new ArgumentException(nameof(Hours), "wartość Godziny jest ujemna");
            if (Minutes < 0) throw new ArgumentException(nameof(Minutes), "wartość Minuty jest ujemna");
            if (Seconds < 0) throw new ArgumentException(nameof(Seconds), "wartość Sekundy jest ujemna");
            if (Hours > 23) throw new ArgumentException(nameof(Hours), "wartość Godziny jest zbyt duża");
            if (Minutes > 59) throw new ArgumentException(nameof(Minutes), "wartość Minuty jest zbyt duża");
            if (Seconds > 59) throw new ArgumentException(nameof(Seconds), "wartość Sekundy jest zbyt duża");
        }

        public Time(byte hours, byte minutes)
        {
            this.hours = hours;
            this.minutes = minutes;
            this.seconds = 00;
            if (Hours < 0) throw new ArgumentException(nameof(Hours), "wartość Godziny jest ujemna");
            if (Minutes < 0) throw new ArgumentException(nameof(Minutes), "wartość Minuty jest ujemna");
            if (Hours > 23) throw new ArgumentException(nameof(Hours), "wartość Godziny jest zbyt duża");
            if (Minutes > 59) throw new ArgumentException(nameof(Minutes), "wartość Minuty jest zbyt duża");
        }

        public Time(byte hours)
        {
            this.hours = hours;
            this.minutes = 00;
            this.seconds = 00;
            if (Hours < 0) throw new ArgumentException(nameof(Hours), "wartość Godziny jest ujemna");
            if (Hours > 23) throw new ArgumentException(nameof(Hours), "wartość Godziny jest zbyt duża");
        }

        public Time(string time)
        {
            string[] timeInString = time.Split(':');
            byte[] timeInByteArray = Array.ConvertAll(timeInString, byte.Parse);
            this.hours = timeInByteArray[0];
            this.minutes = timeInByteArray[1];
            this.seconds = timeInByteArray[2];

            if (Hours < 0) throw new ArgumentException(nameof(Hours), "wartość Godziny jest ujemna");
            if (Minutes < 0) throw new ArgumentException(nameof(Minutes), "wartość Minuty jest ujemna");
            if (Seconds < 0) throw new ArgumentException(nameof(Seconds), "wartość Sekundy jest ujemna");
            if (Hours > 23) throw new ArgumentException(nameof(Hours), "wartość Godziny jest zbyt duża");
            if (Minutes > 59) throw new ArgumentException(nameof(Minutes), "wartość Minuty jest zbyt duża");
            if (Seconds > 59) throw new ArgumentException(nameof(Seconds), "wartość Sekundy jest zbyt duża");
        }

        public override string ToString()
        {
            return Hours + ":" + Minutes + ":" + Seconds;
        }

        public bool Equals(Time other)
        {
            if(this.Hours == other.Hours && this.Minutes == other.Minutes && this.Seconds == other.Seconds)
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
            if(obj == null || !(obj is Time)) return false;
            return Equals((Time)obj);
        }

        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Hours.GetHashCode();
            hash = (hash * 7) + Minutes.GetHashCode();
            hash = (hash * 7) + Seconds.GetHashCode();
            return hash;
        }

        public static bool operator ==(Time left, Time right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Time left, Time right)
        {
            return !(left == right);
        }

        public int CompareTo(Time other)
        {
            if (this.Hours > other.Hours) return -1;
            if (this.Hours == other.Hours) return 0;
            return 1;
        }

        public static bool operator <(Time left, Time right)
        {
            if(left.Hours < right.Hours)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator >(Time left, Time right)
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

        public static bool operator >=(Time left, Time right)
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

        public static bool operator <=(Time left, Time right)
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

        public Time Multiplication(int number)
        {
            long sumTime = (Hours * 3600 + Minutes * 60 + Seconds) * number;
            return new Time((byte)((sumTime/3600)%24),(byte)((sumTime/60)%60), (byte)(sumTime%60));
        }

        public Time Plus(TimePeriod t1)
        {
            long sumTime = Hours * 3600 + Minutes * 60 + Seconds + t1.SumTime;
            return new Time((byte)((sumTime/3600)%24),(byte)((sumTime/60)%60), (byte)(sumTime%60));
        }

        public Time Plus(Time t1, TimePeriod t2)
        {
            long sumTime = t1.Hours * 3600 + t1.Minutes * 60 + t1.Seconds + t2.SumTime;
            return new Time((byte)((sumTime / 3600) % 24), (byte)((sumTime / 60) % 60), (byte)(sumTime % 60));
        }

        public static Time operator +(Time t1, TimePeriod t2)
        {
            long sumTime = t1.Hours * 3600 + t1.minutes * 60 + t1.Seconds + t2.SumTime;
            return new Time((byte)((sumTime / 3600) % 24), (byte)((sumTime / 60) % 60), (byte)(sumTime % 60));
        }

        public Time Minus(Time t1)
        {
            long sumTime = Hours * 3600 + Minutes * 60 + Seconds - t1.SumTime;

            while((sumTime / 3600) % 24 < 0)
            {
                sumTime += 24 * 3600;
            }
            while((sumTime / 60) %60 < 0)
            {
                sumTime += 86400;
            }
            while (sumTime % 60 < 0)
            {
                sumTime += 86400;
            }
            return new Time((byte)((sumTime/3600)%24), (byte)((sumTime / 60) %60), (byte)(sumTime % 60));
        }
    }
}