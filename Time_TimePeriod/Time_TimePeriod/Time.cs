using System;
using System.Security.Cryptography.X509Certificates;

namespace Time_TimePeriod
{
    public class Time : IEquatable<Time>, IComparable<Time>
    {
        private readonly byte sekundy;
        private readonly byte minuty;
        private readonly byte godziny;

        public byte Sekundy { get { return sekundy;} }

        public byte Minuty { get { return minuty; } }

        public byte Godziny { get { return sekundy; } }

        public Time(byte godziny, byte minuty, byte sekundy)
        {
            this.godziny = godziny;
            this.minuty = minuty;
            this.sekundy = sekundy;

            if (Godziny < 0) throw new ArgumentException(nameof(Godziny), "wartość Godziny jest ujemna");
            if (Minuty < 0) throw new ArgumentException(nameof(Minuty), "wartość Minuty jest ujemna");
            if (Sekundy < 0) throw new ArgumentException(nameof(Sekundy), "wartość Sekundy jest ujemna");
            if (Godziny > 23) throw new ArgumentException(nameof(Godziny), "wartość Godziny jest zbyt duża");
            if (Minuty > 59) throw new ArgumentException(nameof(Minuty), "wartość Minuty jest zbyt duża");
            if (Sekundy > 59) throw new ArgumentException(nameof(Sekundy), "wartość Sekundy jest zbyt duża");
        }

        public Time(byte godziny, byte minuty)
        {
            this.godziny = godziny;
            this.minuty = minuty;
            this.sekundy = 00;
            if (Godziny < 0) throw new ArgumentException(nameof(Godziny), "wartość Godziny jest ujemna");
            if (Minuty < 0) throw new ArgumentException(nameof(Minuty), "wartość Minuty jest ujemna");
            if (Godziny > 23) throw new ArgumentException(nameof(Godziny), "wartość Godziny jest zbyt duża");
            if (Minuty > 59) throw new ArgumentException(nameof(Minuty), "wartość Minuty jest zbyt duża");
        }

        public Time(byte godziny)
        {
            this.godziny = godziny;
            this.minuty = 00;
            this.sekundy = 00;
            if (Godziny < 0) throw new ArgumentException(nameof(Godziny), "wartość Godziny jest ujemna");
            if (Godziny > 23) throw new ArgumentException(nameof(Godziny), "wartość Godziny jest zbyt duża");
        }

        public Time(string time)
        {
            string[] timeInString = time.Split(':');
            byte[] timeInByteArray = Array.ConvertAll(timeInString, byte.Parse);
            this.godziny = timeInByteArray[0];
            this.minuty = timeInByteArray[1];
            this.sekundy = timeInByteArray[2];

            if (Godziny < 0) throw new ArgumentException(nameof(Godziny), "wartość Godziny jest ujemna");
            if (Minuty < 0) throw new ArgumentException(nameof(Minuty), "wartość Minuty jest ujemna");
            if (Sekundy < 0) throw new ArgumentException(nameof(Sekundy), "wartość Sekundy jest ujemna");
            if (Godziny > 23) throw new ArgumentException(nameof(Godziny), "wartość Godziny jest zbyt duża");
            if (Minuty > 59) throw new ArgumentException(nameof(Minuty), "wartość Minuty jest zbyt duża");
            if (Sekundy > 59) throw new ArgumentException(nameof(Sekundy), "wartość Sekundy jest zbyt duża");
        }

        public override string ToString()
        {
            return Godziny + ":" + Minuty + ":" + Sekundy;
        }

        public bool Equals(Time other)
        {
            if(this.Godziny == other.Godziny && this.Minuty == other.Minuty && this.Sekundy == other.Sekundy)
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
            hash = (hash * 7) + Godziny.GetHashCode();
            hash = (hash * 7) + Minuty.GetHashCode();
            hash = (hash * 7) + Sekundy.GetHashCode();
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
    }
}