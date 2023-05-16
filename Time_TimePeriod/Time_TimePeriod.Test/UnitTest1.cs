using Microsoft.VisualStudio.TestTools.UnitTesting;
using Time_TimePeriod;


namespace Time_TimePeriod.Test
{
    [TestClass()]
    public class Time_TimePeriodTests
    {

        [TestMethod()]
        public void CreatingTimeObjectByConstructor1()
        {
            Time punktCzasu = new Time(11, 22, 13);
            string expected = ("11:22:13");
            string actual = punktCzasu.ToString();
            Assert.AreEqual(expected, actual, "Konstruktor 1 dzia³a b³êdnie");

        }
        [TestMethod()]
        public void CreatingTimeObjectByConstructor2()
        {
            Time punktCzasu = new Time();
            string expected = "0:0:0";
            string actual = punktCzasu.ToString();
            Assert.AreEqual(expected, actual, "Konstruktor 2 dzia³a b³êdnie");

        }
        [TestMethod()]
        public void CreatingTimeObjectByConstructor3()
        {
            Time punktCzasu = new Time(11);
            string expected = ("11:0:0");
            string actual = punktCzasu.ToString();
            Assert.AreEqual(expected, actual, "Konstruktor 3 dzia³a b³êdnie");

        }
        [TestMethod()]
        public void CreatingTimeObjectByConstructor4()
        {
            Time punktCzasu = new Time(11, 11);
            string expected = ("11:11:0");
            string actual = punktCzasu.ToString();
            Assert.AreEqual(expected, actual, "Konstruktor 4 dzia³a b³êdnie");

        }
        [TestMethod()]
        public void CreatingTimeObjectByConstructor5()
        {
            Time punktCzasu = new Time("15:14:12");
            string expected = ("15:14:12");
            string actual = punktCzasu.ToString();
            Assert.AreEqual(expected, actual, "Konstruktor 5 dzia³a b³êdnie");

        }
        [TestMethod()]
        public void GetVariablesFromTime()
        {
            Time punktCzasu = new Time("22:9:17");
            byte getGodziny = punktCzasu.Hours;
            byte expectGodizny = 22;
            byte getMinuty = punktCzasu.Minutes;
            byte expectMinuty = 9;
            byte getSekundy = punktCzasu.Seconds;
            byte expectSekundy = 17;
            Assert.AreEqual(expectGodizny, getGodziny, "Pobieranie wartoœci godzin jest b³êdne");
            Assert.AreEqual(expectMinuty, getMinuty, "Pobieranie wartoœci minut jest b³êdne");
            Assert.AreEqual(expectSekundy, getSekundy, "Pobieranie wartoœci sekund jest b³êdne");
        }
        [TestMethod()]
        public void TimeToStingMethod()
        {
            Time punktCzasu = new Time("22:9:17");
            string expected = "22:9:17";
            string actual = punktCzasu.ToString();
            Assert.AreEqual(expected, actual, "Przekszta³canie na wyœwietlanie godziny nie dzia³a");
        }

        [TestMethod()]
        public void EqualsMethodTest()
        {
            Time punktCzasu1 = new Time("22:9:15");
            Time punktCzasu2 = new Time("21:9:15");
            bool areEqual = punktCzasu1.Equals(punktCzasu2);
            bool expected = false;
            Assert.AreEqual(expected, areEqual, "Przyrównywanie punktów czasu nie dzia³a test1");
        }
        [TestMethod()]
        public void EqualsMethodTest2()
        {
            Time punktCzasu1 = new Time("22:9:25");
            Time punktCzasu2 = new Time("22:9:25");
            bool areEqual = punktCzasu1.Equals(punktCzasu2);
            bool expected = true;
            Assert.AreEqual(expected, areEqual, "Przyrównywanie punktów czasu nie dzia³a test2");
        }
        [TestMethod()]
        public void EqualsMethodTest3()
        {
            Time punktCzasu1 = new Time("22:9:15");
            Time punktCzasu2 = new Time("21:9:15");
            bool areEqual = punktCzasu1 == punktCzasu2;
            bool expected = false;
            Assert.AreEqual(expected, areEqual, "Przyrównywanie punktów czasu nie dzia³a test3");
        }
        [TestMethod()]
        public void EqualsMethodTest4()
        {
            Time punktCzasu1 = new Time("22:9:25");
            Time punktCzasu2 = new Time("22:9:25");
            bool areEqual = punktCzasu1 == punktCzasu2;
            bool expected = true;
            Assert.AreEqual(expected, areEqual, "Przyrównywanie punktów czasu nie dzia³a test4");
        }

        [TestMethod()]
        public void GetHashCodeTest()
        {
            Time punktCzasu1 = new Time("2:2:2");
            int expected = 4573;
            int acctual = punktCzasu1.GetHashCode();
            Assert.AreEqual(expected, acctual, "Pobieranie Hashu punktu Time nie dzia³a");
        }
        [TestMethod()]
        public void NotEqualsMethodTest1()
        {
            Time punktCzasu1 = new Time("23:1:55");
            Time punktCzasu2 = new Time("21:9:15");
            bool areEqual = punktCzasu1 != punktCzasu2;
            bool expected = true;
            Assert.AreEqual(expected, areEqual, "Nierównoœæ czasów dzia³a b³êdnie test1");
        }
        [TestMethod()]
        public void NotEqualsMethodTest2()
        {
            Time punktCzasu1 = new Time("23:1:55");
            Time punktCzasu2 = new Time("23:1:55");
            bool areEqual = punktCzasu1 != punktCzasu2;
            bool expected = false;
            Assert.AreEqual(expected, areEqual, "Nierównoœæ czasów dzia³a b³êdnie test2");
        }
        [TestMethod()]
        public void CompareToTest1()
        {
            Time punktCzasu1 = new Time("13:1:55");
            Time punktCzasu2 = new Time("23:15:26");
            int expected = 1;
            int acctual = punktCzasu1.CompareTo(punktCzasu2);
            Assert.AreEqual(expected, acctual, "Nie dzia³a porównywanie punktów czasu test1");

        }
        [TestMethod()]
        public void CompareToTest2()
        {
            Time punktCzasu1 = new Time("13:1:55");
            Time punktCzasu2 = new Time("23:15:26");
            int expected = -1;
            int acctual = punktCzasu2.CompareTo(punktCzasu1);
            Assert.AreEqual(expected, acctual, "Nie dzia³a porównywanie punktów czasu test2");

        }
        [TestMethod()]
        public void CompareToTest3()
        {
            Time punktCzasu1 = new Time("13:1:55");
            Time punktCzasu2 = new Time("13:1:55");
            int expected = 0;
            int acctual = punktCzasu2.CompareTo(punktCzasu1);
            Assert.AreEqual(expected, acctual, "Nie dzia³a porównywanie punktów czasu test3");

        }
        [TestMethod()]
        public void OperatorMniejszoœciTest()
        {
            Time punktCzasu1 = new Time("13:1:55");
            Time punktCzasu2 = new Time("23:15:26");
            bool expected = true;
            bool acctual = punktCzasu1 < punktCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator < test1");
        }
        [TestMethod()]
        public void OperatorMniejszoœciTest2()
        {
            Time punktCzasu1 = new Time("13:1:55");
            Time punktCzasu2 = new Time("3:15:26");
            bool expected = false;
            bool acctual = punktCzasu1 < punktCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator < test2");
        }
        [TestMethod()]
        public void OperatorWiêkszoœciTest()
        {
            Time punktCzasu1 = new Time("13:1:55");
            Time punktCzasu2 = new Time("23:15:26");
            bool expected = false;
            bool acctual = punktCzasu1 > punktCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator > test1");
        }
        [TestMethod()]
        public void OperatorWiêkszoœciTest2()
        {
            Time punktCzasu1 = new Time("13:1:55");
            Time punktCzasu2 = new Time("3:15:26");
            bool expected = true;
            bool acctual = punktCzasu1 > punktCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator > test2");
        }
        [TestMethod()]
        public void OperatorMniejszoœciRównoœciTest()
        {
            Time punktCzasu1 = new Time("13:1:55");
            Time punktCzasu2 = new Time("23:15:26");
            bool expected = true;
            bool acctual = punktCzasu1 <= punktCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator <= test1");
        }
        [TestMethod()]
        public void OperatorMniejszoœciRównoœciTest2()
        {
            Time punktCzasu1 = new Time("13:1:55");
            Time punktCzasu2 = new Time("3:15:26");
            bool expected = false;
            bool acctual = punktCzasu1 <= punktCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator <= test2");
        }
        [TestMethod()]
        public void OperatorMniejszoœciRównoœciTest3()
        {
            Time punktCzasu1 = new Time("13:1:55");
            Time punktCzasu2 = new Time("13:1:55");
            bool expected = true;
            bool acctual = punktCzasu1 <= punktCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator <= test3");
        }
        [TestMethod()]
        public void OperatorWiêkszoœciRównoœciTest()
        {
            Time punktCzasu1 = new Time("13:1:55");
            Time punktCzasu2 = new Time("23:15:26");
            bool expected = false;
            bool acctual = punktCzasu1 >= punktCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator >= test1");
        }
        [TestMethod()]
        public void OperatorWiêkszoœciRównoœciTest2()
        {
            Time punktCzasu1 = new Time("13:1:55");
            Time punktCzasu2 = new Time("3:15:26");
            bool expected = true;
            bool acctual = punktCzasu1 >= punktCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator >= test2");
        }
        [TestMethod()]
        public void OperatorWiêkszoœciRównoœciTest3()
        {
            Time punktCzasu1 = new Time("13:1:55");
            Time punktCzasu2 = new Time("13:1:55");
            bool expected = true;
            bool acctual = punktCzasu1 >= punktCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator >= test3");
        }
        [TestMethod()]
        public void MethodZwielokrotnianiaTest1()
        {
            Time punktCzasu1 = new Time("1:2:3");
            string expected = "2:4:6";
            Assert.AreEqual(expected, punktCzasu1.Multiplication(2).ToString(), "Nie dzia³a funkcja zwielokrotniania test1");
        }
        [TestMethod()]
        public void MethodZwielokrotnianiaTest2()
        {
            Time punktCzasu1 = new Time("3:2:3");
            string expected = "3:18:27";
            Assert.AreEqual(expected, punktCzasu1.Multiplication(9).ToString(), "Nie dzia³a funkcja zwielokrotniania test2");
        }
        [TestMethod()]
        public void MethodPlusTest1()
        {
            Time punktCzasu1 = new Time("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("23:15:26");
            string expected = "1:20:10";
            Assert.AreEqual(expected, punktCzasu1.Plus(przedzia³Czasu2).ToString(), "Nie dzia³a funkcja dodawania do punktu przezia³u czasowego test1");

        }
        [TestMethod()]
        public void MethodPlusTest2()
        {
            Time punktCzasu1 = new Time("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("5:22:11");
            string expected = "7:26:55";
            Assert.AreEqual(expected, punktCzasu1.Plus(przedzia³Czasu2).ToString(), "Nie dzia³a funkcja dodawania do punktu przezia³u czasowego test2");

        }

        [TestMethod()]
        public void MethodPlusTest3()
        {
            Time punktCzasu1 = new Time("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("23:15:26");
            Time acctual = Time.Plus(punktCzasu1, przedzia³Czasu2);
            string expected = "1:20:10";
            Assert.AreEqual(expected, acctual.ToString(), "Nie dzia³a funkcja dodawania do punktu przezia³u czasowego test3");

        }
        [TestMethod()]
        public void MethodPlusTest4()
        {
            Time punktCzasu1 = new Time("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("5:22:11");
            Time acctual = Time.Plus(punktCzasu1, przedzia³Czasu2);
            string expected = "7:26:55";
            Assert.AreEqual(expected, acctual.ToString(), "Nie dzia³a funkcja dodawania do punktu przezia³u czasowego test4");

        }

        [TestMethod()]
        public void OperatorPlusTest5()
        {
            Time punktCzasu1 = new Time("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("23:15:26");
            string expected = "1:20:10";
            Assert.AreEqual(expected, (punktCzasu1 + przedzia³Czasu2).ToString(), "Nie dzia³a funkcja dodawania do punktu przezia³u czasowego test5");
        }
        [TestMethod()]
        public void OperatorPlusTest6()
        {
            Time punktCzasu1 = new Time("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("5:22:11");
            string expected = "7:26:55";
            Assert.AreEqual(expected, (punktCzasu1 + przedzia³Czasu2).ToString(), "Nie dzia³a funkcja dodawania do punktu przezia³u czasowego test6");
        }
        public void MethodMinusTest1()
        {
            Time punktCzasu1 = new Time("22:45:17");
            TimePeriod przedzia³Czasu2 = new TimePeriod("19:8:17");
            string expected = "2:37:0";
            Assert.AreEqual(expected, punktCzasu1.Minus(przedzia³Czasu2).ToString(), "Nie dzia³a funkcja odejmowania od punktu przezia³u czasowego test1");

        }
        [TestMethod()]
        public void MethodMinusTest2()
        {
            Time punktCzasu1 = new Time("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("5:22:11");
            string expected = "20:42:33";
            Assert.AreEqual(expected, punktCzasu1.Minus(przedzia³Czasu2).ToString(), "Nie dzia³a funkcja odejmowania od punktu przezia³u czasowego test2");

        }
        public void OperatorMinusTest3()
        {
            Time punktCzasu1 = new Time("22:45:17");
            TimePeriod przedzia³Czasu2 = new TimePeriod("19:8:17");
            string expected = "2:37:0";
            Assert.AreEqual(expected, (punktCzasu1 - przedzia³Czasu2).ToString(), "Nie dzia³a funkcja odejmowania od punktu przezia³u czasowego test3");

        }
        [TestMethod()]
        public void OperatorMinusTest4()
        {
            Time punktCzasu1 = new Time("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("5:22:11");
            string expected = "20:42:33";
            Assert.AreEqual(expected, (punktCzasu1 - przedzia³Czasu2).ToString(), "Nie dzia³a funkcja odejmowania od punktu przezia³u czasowego test4");

        }

        public void MethodMinusTest5()
        {
            Time punktCzasu1 = new Time("22:45:17");
            TimePeriod przedzia³Czasu2 = new TimePeriod("19:8:17");
            string expected = "2:37:0";
            Time acctual = Time.Minus(punktCzasu1, przedzia³Czasu2);
            Assert.AreEqual(expected, acctual.ToString(), "Nie dzia³a funkcja odejmowania od punktu przezia³u czasowego test5");

        }
        
        [TestMethod()]
        public void MethodMinusTest6()
        {
            Time punktCzasu1 = new Time("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("5:22:11");
            string expected = "20:42:33";
            Time acctual = Time.Minus(punktCzasu1, przedzia³Czasu2);
            Assert.AreEqual(expected, acctual.ToString(), "Nie dzia³a funkcja odejmowania od punktu przezia³u czasowego test6");

        }

        [TestMethod()]
        public void GetVariablesFromTimePeriod()
        {
            TimePeriod okesCzasu = new TimePeriod("22:9:17");
            byte getGodziny = okesCzasu.Hours;
            byte expectGodizny = 22;
            byte getMinuty = okesCzasu.Minutes;
            byte expectMinuty = 9;
            long getSekundy = okesCzasu.Seconds;
            long expectSekundy = 17;
            long sumaCzasu = okesCzasu.SumTime;
            long expectedSumaCzasu = 22 * 3600 + 9 * 60 + 17;
            Assert.AreEqual(expectGodizny, getGodziny, "Pobieranie wartoœci godzin jest b³êdne");
            Assert.AreEqual(expectMinuty, getMinuty, "Pobieranie wartoœci minut jest b³êdne");
            Assert.AreEqual(expectSekundy, getSekundy, "Pobieranie wartoœci sekund jest b³êdne");
            Assert.AreEqual(expectedSumaCzasu, sumaCzasu, "Pobieranie wartoœci sumy czasu jest b³êdne");
        }

        [TestMethod()]
        public void CreatingTimePeriodByConstructor1()
        {
            TimePeriod okresCzasu = new TimePeriod(11, 15, 3);
            string expected = okresCzasu.ToString();
            string acctual = "11:15:3";
            Assert.AreEqual(expected, acctual, "Konstruktor 1 dzia³a b³êdnie");
        }

        [TestMethod()]
        public void CreatingTimePeriodByConstructor2()
        {
            TimePeriod okresCzasu = new TimePeriod(26, 15);
            string expected = okresCzasu.ToString();
            string acctual = "26:15:0";
            Assert.AreEqual(expected, acctual, "Konstruktor 2 dzia³a b³êdnie");
        }

        [TestMethod()]
        public void CreatingTimePeriodByConstructor3()
        {
            TimePeriod okresCzasu = new TimePeriod(15);
            string expected = okresCzasu.ToString();
            string acctual = "0:0:15";
            Assert.AreEqual(expected, acctual, "Konstruktor 3 dzia³a b³êdnie");
        }

        [TestMethod()]
        public void CreatingTimePeriodByConstructor4()
        {
            TimePeriod okresCzasu = new TimePeriod(367);
            string expected = okresCzasu.ToString();
            string acctual = "0:6:7";
            Assert.AreEqual(expected, acctual, "Konstruktor 4 dzia³a b³êdnie");
        }

        [TestMethod()]
        public void CreatingTimePeriodByConstructor5()
        {
            Time punktCzasu1 = new Time(15, 13, 2);
            Time punktCzasu2 = new Time(4, 25, 33);
            TimePeriod okresCzasu = new TimePeriod(punktCzasu1, punktCzasu2);
            string expected = okresCzasu.ToString();
            string acctual = "10:47:29";
            Assert.AreEqual(expected, acctual, "Konstruktor 5 dzia³a b³êdnie");
        }

        [TestMethod()]
        public void CreatingTimePeriodByConstructor6()
        {
            TimePeriod okresCzasu = new TimePeriod("15:2:38");
            string expected = okresCzasu.ToString();
            string acctual = "15:2:38";
            Assert.AreEqual(expected, acctual, "Konstruktor 6 dzia³a b³êdnie");
        }

        [TestMethod()]
        public void TimePeriodToStingMethod()
        {
            TimePeriod okresCzasu = new TimePeriod("22:9:17");
            string expected = "22:9:17";
            string actual = okresCzasu.ToString();
            Assert.AreEqual(expected, actual, "Przekszta³canie na wyœwietlanie godziny nie dzia³a");
        }

        [TestMethod()]
        public void EqualsMethodTestPeriod()
        {
            TimePeriod okresCzasu1 = new TimePeriod("22:9:15");
            TimePeriod okresCzasu2 = new TimePeriod("14:9:15");
            bool areEqual = okresCzasu1.Equals(okresCzasu2);
            bool expected = false;
            Assert.AreEqual(expected, areEqual, "Przyrównywanie okresów czasu nie dzia³a test1");
        }

        [TestMethod()]
        public void EqualsMethodTestPeriod2()
        {
            TimePeriod okresCzasu1 = new TimePeriod("22:9:25");
            TimePeriod okresCzasu2 = new TimePeriod("22:9:25");
            bool areEqual = okresCzasu1.Equals(okresCzasu2);
            bool expected = true;
            Assert.AreEqual(expected, areEqual, "Przyrównywanie  okres czasu nie dzia³a test2");
        }
        [TestMethod()]
        public void EqualsMethodTestPeriod3()
        {
            TimePeriod okresCzasu1 = new TimePeriod("22:9:15");
            TimePeriod okresCzasu2 = new TimePeriod("21:9:15");
            bool areEqual = okresCzasu1 == okresCzasu2;
            bool expected = false;
            Assert.AreEqual(expected, areEqual, "Przyrównywanie okres czasu nie dzia³a test3");
        }
        [TestMethod()]
        public void EqualsMethodTestPeriod4()
        {
            TimePeriod okresCzasu1 = new TimePeriod("22:9:25");
            TimePeriod okresCzasu2 = new TimePeriod("22:9:25");
            bool areEqual = okresCzasu1 == okresCzasu2;
            bool expected = true;
            Assert.AreEqual(expected, areEqual, "Przyrównywanie punktów czasu nie dzia³a test4");
        }
        [TestMethod()]
        public void GetHashCodePeriodTest()
        {
            TimePeriod okresCzasu1 = new TimePeriod("2:2:2");
            int expected = 4573;
            int acctual = okresCzasu1.GetHashCode();
            Assert.AreEqual(expected, acctual, "Pobieranie Hashu punktu TimePeriod nie dzia³a");
        }
        [TestMethod()]
        public void NotEqualsMethodPeriodTest1()
        {
            TimePeriod okresCzasu1 = new TimePeriod("23:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("21:9:15");
            bool areEqual = okresCzasu1 != okresCzasu2;
            bool expected = true;
            Assert.AreEqual(expected, areEqual, "Nierównoœæ okresów czasów dzia³a b³êdnie test1");
        }
        [TestMethod()]
        public void NotEqualsMethodPeriodTest2()
        {
            TimePeriod okresCzasu1 = new TimePeriod("23:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("23:1:55");
            bool areEqual = okresCzasu1 != okresCzasu2;
            bool expected = false;
            Assert.AreEqual(expected, areEqual, "Nierównoœæ okresów czasów dzia³a b³êdnie test2");
        }
        [TestMethod()]
        public void CompareToPeriodTest1()
        {
            TimePeriod okresCzasu1 = new TimePeriod("13:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("23:15:26");
            int expected = 1;
            int acctual = okresCzasu1.CompareTo(okresCzasu2);
            Assert.AreEqual(expected, acctual, "Nie dzia³a porównywanie odcinków czasu test1");

        }
        [TestMethod()]
        public void CompareToPeriodTest2()
        {
            TimePeriod okresCzasu1 = new TimePeriod("13:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("23:15:26");
            int expected = -1;
            int acctual = okresCzasu2.CompareTo(okresCzasu1);
            Assert.AreEqual(expected, acctual, "Nie dzia³a porównywanie okresów czasu test2");

        }
        [TestMethod()]
        public void CompareToPeriodTest3()
        {
            TimePeriod okresCzasu1 = new TimePeriod("13:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("13:1:55");
            int expected = 0;
            int acctual = okresCzasu2.CompareTo(okresCzasu1);
            Assert.AreEqual(expected, acctual, "Nie dzia³a porównywanie okresów czasu test3");

        }
        [TestMethod()]
        public void OperatorMniejszoœciPeriodTest()
        {
            TimePeriod okresCzasu1 = new TimePeriod("13:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("23:15:26");
            bool expected = true;
            bool acctual = okresCzasu1 < okresCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator < test1");
        }
        [TestMethod()]
        public void OperatorMniejszoœciPeriodTest2()
        {
            TimePeriod okresCzasu1 = new TimePeriod("13:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("3:15:26");
            bool expected = false;
            bool acctual = okresCzasu1 < okresCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator < test2");
        }
        [TestMethod()]
        public void OperatorWiêkszoœciPeriodTest()
        {
            TimePeriod okresCzasu1 = new TimePeriod("13:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("23:15:26");
            bool expected = false;
            bool acctual = okresCzasu1 > okresCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator > test1");
        }
        [TestMethod()]
        public void OperatorWiêkszoœciPeriodTest2()
        {
            TimePeriod okresCzasu1 = new TimePeriod("13:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("3:15:26");
            bool expected = true;
            bool acctual = okresCzasu1 > okresCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator > test2");
        }
        [TestMethod()]
        public void OperatorMniejszoœciRównoœciPeriodTest()
        {
            TimePeriod okresCzasu1 = new TimePeriod("13:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("23:15:26");
            bool expected = true;
            bool acctual = okresCzasu1 <= okresCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator <= test1");
        }
        [TestMethod()]
        public void OperatorMniejszoœciRównoœciPeriodTest2()
        {
            TimePeriod okresCzasu1 = new TimePeriod("13:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("3:15:26");
            bool expected = false;
            bool acctual = okresCzasu1 <= okresCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator <= test2");
        }
        [TestMethod()]
        public void OperatorMniejszoœciRównoœciPeriodTest3()
        {
            TimePeriod okresCzasu1 = new TimePeriod("13:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("13:1:55");
            bool expected = true;
            bool acctual = okresCzasu1 <= okresCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator <= test3");
        }
        [TestMethod()]
        public void OperatorWiêkszoœciRównoœciPeriodTest()
        {
            TimePeriod okresCzasu1 = new TimePeriod("13:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("23:15:26");
            bool expected = false;
            bool acctual = okresCzasu1 >= okresCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator >= test1");
        }
        [TestMethod()]
        public void OperatorWiêkszoœciRównoœciPeriodTest2()
        {
            TimePeriod okresCzasu1 = new TimePeriod("13:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("3:15:26");
            bool expected = true;
            bool acctual = okresCzasu1 >= okresCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator >= test2");
        }
        [TestMethod()]
        public void OperatorWiêkszoœciRównoœciPeriodTest3()
        {
            TimePeriod okresCzasu1 = new TimePeriod("13:1:55");
            TimePeriod okresCzasu2 = new TimePeriod("13:1:55");
            bool expected = true;
            bool acctual = okresCzasu1 >= okresCzasu2;
            Assert.AreEqual(expected, acctual, "Nie dzia³a operator >= test3");
        }

        [TestMethod()]
        public void MethodPlusPeriodTest1()
        {
            TimePeriod przedzia³Czasu1 = new TimePeriod("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("23:15:26");
            string expected = "25:20:10";
            Assert.AreEqual(expected, przedzia³Czasu1.Plus(przedzia³Czasu2).ToString(), "Nie dzia³a funkcja dodawania przedzia³ów czasowych  test1");

        }
        [TestMethod()]
        public void MethodPlusPeriodTest2()
        {
            TimePeriod przedzia³Czasu1 = new TimePeriod("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("5:22:11");
            string expected = "7:26:55";
            Assert.AreEqual(expected, przedzia³Czasu1.Plus(przedzia³Czasu2).ToString(), "Nie dzia³a funkcja dodawania przedzia³ów czasowych test2");

        }
        [TestMethod()]
        public void MethodPlusPeriodTest3()
        {
            TimePeriod przedzia³Czasu1 = new TimePeriod("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("23:15:26");
            TimePeriod acctual = TimePeriod.Plus(przedzia³Czasu1, przedzia³Czasu2);
            string expected = "25:20:10";
            Assert.AreEqual(expected, acctual.ToString(), "Nie dzia³a funkcja dodawania przedzia³ów czasowych  test3");

        }
        [TestMethod()]
        public void MethodPlusPeriodTest4()
        {
            TimePeriod przedzia³Czasu1 = new TimePeriod("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("5:22:11");
            TimePeriod acctual = TimePeriod.Plus(przedzia³Czasu1, przedzia³Czasu2);
            string expected = "7:26:55";
            Assert.AreEqual(expected, acctual.ToString(), "Nie dzia³a funkcja dodawania przedzia³ów czasowych  test4");

        }
        [TestMethod()]
        public void OperatorPlusPeriodTest5()
        {
            TimePeriod przedzia³Czasu1 = new TimePeriod("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("23:15:26");
            string expected = "25:20:10";
            Assert.AreEqual(expected, (przedzia³Czasu1 + przedzia³Czasu2).ToString(), "Nie dzia³a funkcja dodawania przedzia³ów czasowych  test5");
        }
        [TestMethod()]
        public void OperatorPlusPeriodTest6()
        {
            TimePeriod przedzia³Czasu1 = new TimePeriod("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("5:22:11");
            string expected = "7:26:55";
            Assert.AreEqual(expected, (przedzia³Czasu1 + przedzia³Czasu2).ToString(), "Nie dzia³a funkcja dodawania przedzia³ów czasowych  test6");
        }
        public void MethodMinusPeriodTest1()
        {
            TimePeriod przedzia³Czasu1 = new TimePeriod("22:45:17");
            TimePeriod przedzia³Czasu2 = new TimePeriod("19:8:17");
            string expected = "2:37:0";
            Assert.AreEqual(expected, przedzia³Czasu1.Minus(przedzia³Czasu2).ToString(), "Nie dzia³a funkcja odejmowania przedzia³ów czasowych  test1");

        }
        [TestMethod()]
        public void MethodMinusPeriodTest2()
        {
            TimePeriod przedzia³Czasu1 = new TimePeriod("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("5:22:11");
            string expected = "20:42:33";
            Assert.AreEqual(expected, przedzia³Czasu1.Minus(przedzia³Czasu2).ToString(), "Nie dzia³a funkcja odejmowania przedzia³ów czasowych  test2");

        }
        public void OperatorMinusPeriodTest3()
        {
            TimePeriod przedzia³Czasu1 = new TimePeriod("22:45:17");
            TimePeriod przedzia³Czasu2 = new TimePeriod("19:8:17");
            string expected = "2:37:0";
            Assert.AreEqual(expected, (przedzia³Czasu1 - przedzia³Czasu2).ToString(), "Nie dzia³a funkcja odejmowania przedzia³ów czasowych  test3");

        }
        [TestMethod()]
        public void OperatorMinusPeriodTest4()
        {
            TimePeriod przedzia³Czasu1 = new TimePeriod("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("5:22:11");
            string expected = "20:42:33";
            Assert.AreEqual(expected, (przedzia³Czasu1 - przedzia³Czasu2).ToString(), "Nie dzia³a funkcja odejmowania przedzia³ów czasowych  test4");

        }
        public void MethodMinusPeriodTest5()
        {
            TimePeriod przedzia³Czasu1 = new TimePeriod("22:45:17");
            TimePeriod przedzia³Czasu2 = new TimePeriod("19:8:17");
            string expected = "2:37:0";
            TimePeriod acctual = TimePeriod.Minus(przedzia³Czasu1, przedzia³Czasu2);
            Assert.AreEqual(expected, acctual.ToString(), "Nie dzia³a funkcja odejmowania przedzia³ów czasowych  test5");

        }
        [TestMethod()]
        public void MethodMinusPeriodTest6()
        {
            TimePeriod przedzia³Czasu1 = new TimePeriod("2:4:44");
            TimePeriod przedzia³Czasu2 = new TimePeriod("5:22:11");
            string expected = "20:42:33";
            TimePeriod acctual = TimePeriod.Minus(przedzia³Czasu1, przedzia³Czasu2);
            Assert.AreEqual(expected, acctual.ToString(), "Nie dzia³a funkcja odejmowania przedzia³ów czasowych  test6");

        }
    }
}
