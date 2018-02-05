using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaclassification.smalltest
{
    public static class IntervallTest
    {
        public static int forSet = -1;
        private static double min = 0;
        private static double max = 0;
        private static TestEnum lastTest = TestEnum.Default;
        public static double border = 0;

        public static bool InIntervall(int SignIndex, int Title)
        {
            bool ret = false;

            SmallTester tester = SmallTester.Instance;

            double value = tester.GetValueFromDb(SignIndex, Title);
            if (min < value && value < max)
                ret = true;

            return ret;
        }

        private static double getDistanceFromMid(double min, double max, double midV, bool Bigger)
        {
            double ret = -1;
            switch (Bigger)
            {
                case true:
                    ret = max - midV;
                    if (midV - min > ret) ret = midV - min;
                    break;
                case false:
                    ret = max - midV;
                    if (midV - min < ret) ret = midV - min;
                    break;
            }
            return ret;
        }

        public static void Set(int SignerIndex, int Title, TestEnum test)
        {
            
            switch (test)
            {
                case TestEnum.MinMax: MinMaxSet(SignerIndex, Title); break;
                case TestEnum.MedianDistanceB: MedianDistanceSet(SignerIndex, Title, true); break;
                case TestEnum.MedianDistanceS: MedianDistanceSet(SignerIndex, Title, false); break;
                case TestEnum.AverageDistanceB: AverageDistanceSet(SignerIndex, Title, true); break;
                case TestEnum.AverageDistanceS: AverageDistanceSet(SignerIndex, Title, false); break;
                case TestEnum.HarmonicAverageDistanceB: HarmonicAverageDistanceSet(SignerIndex, Title, true); break;
                case TestEnum.HarmonicAverageDistanceS: HarmonicAverageDistanceSet(SignerIndex, Title, false); break;
                case TestEnum.GeometricAverageDistanceB: GeometricAverageDistanceSet(SignerIndex, Title, true); break;
                case TestEnum.GeometricAverageDistanceS: GeometricAverageDistanceSet(SignerIndex, Title, false); break;
                case TestEnum.NegyzetesAverageDistanceB: NegyzetesAverageDistanceSet(SignerIndex, Title, true); break;

                case TestEnum.Default:
                default: throw new NotImplementedException();
            }
        }

        private static void MinMaxSet(int SignerIndex, int Title)
        {
            SmallTester tester = SmallTester.Instance;

            min = tester.GetValueFromDb(SignerIndex, Title);
            max = min;
            for (int i = 1; i < forSet; i++)
            {
                double value = tester.GetValueFromDb(SignerIndex + i, Title);
                if (value < min) min = value;
                else if (max < value) max = value;
            }
        }

        private static void MedianDistanceSet(int SignerIndex, int Title, bool Bigger)
        {
            List<double> values = new List<double>();
            SmallTester tester = SmallTester.Instance;
            for (int i = 0; i < forSet; i++)
            {
                values.Add(tester.GetValueFromDb(SignerIndex + i, Title));
            }
            values.Sort();

            double median = 0;
            if (forSet % 2 == 0)
            {
                int i = 0;
                while (i + 1 < forSet / 2) i++;
                median = (values[i] + values[i]) / 2;
            }
            else
                median = values[forSet / 2];

            double distance = getDistanceFromMid(values[0], values.Max(), median, Bigger);
            min = median - distance;
            max = median + distance;
        }

        private static void AverageDistanceSet(int SignerIndex, int Title, bool Bigger)
        {
            List<double> values = new List<double>();
            SmallTester tester = SmallTester.Instance;
            for (int i = 0; i < forSet; i++)
            {
                values.Add(tester.GetValueFromDb(SignerIndex + i, Title));
            }
            values.Sort();
            double avrage = values.Average();

            double distance = getDistanceFromMid(values[0], values.Max(), avrage, Bigger);
            min = avrage - distance;
            max = avrage + distance;
        }

        private static void HarmonicAverageDistanceSet(int SignerIndex, int Title, bool Bigger)
        {
            List<double> values = new List<double>();
            SmallTester tester = SmallTester.Instance;
            for (int i = 0; i < forSet; i++)
            {
                values.Add(tester.GetValueFromDb(SignerIndex + i, Title));
            }
            values.Sort();

            double sum = 0;
            foreach(double lm in values)
            {
                sum += 1 / lm;
            }
            double avrage = values.Count()/sum;

            double distance = getDistanceFromMid(values[0], values.Max(), avrage, Bigger);
            min = avrage - distance;
            max = avrage + distance;
        }

        private static void GeometricAverageDistanceSet(int SignerIndex, int Title, bool Bigger)
        {
            List<double> values = new List<double>();
            SmallTester tester = SmallTester.Instance;
            for (int i = 0; i < forSet; i++)
            {
                values.Add(tester.GetValueFromDb(SignerIndex + i, Title));
            }
            values.Sort();

            double szorzat = 1;
            foreach (double lm in values)
            {
                double szorzo = lm;
                if (szorzo < 0)
                    szorzo = -1 * szorzo;
                if (szorzo == 0)
                    szorzo = 0.5;
                szorzat = szorzat * szorzo;
            }
            
            double avrage = Math.Sqrt(szorzat);

            double distance = getDistanceFromMid(values[0], values.Max(), avrage, Bigger);
            min = avrage - distance;
            max = avrage + distance;
        }

        private static void NegyzetesAverageDistanceSet(int SignerIndex, int Title, bool Bigger)
        {
            List<double> values = new List<double>();
            SmallTester tester = SmallTester.Instance;
            for (int i = 0; i < forSet; i++)
            {
                values.Add(tester.GetValueFromDb(SignerIndex + i, Title));
            }
            values.Sort();

            double szum = 0;
            foreach (double lm in values)
            {
                double szorzo = lm;
                if (szorzo < 0)
                    szorzo = -1 * szorzo;
                if (szorzo == 0)
                    szorzo = 0.5;
                szum += szorzo * szorzo;
            }

            double avrage = Math.Sqrt(szum/values.Count());

            double distance = getDistanceFromMid(values[0], values.Max(), avrage, Bigger);
            min = avrage - distance;
            max = avrage + distance;
        }

    }

    public enum TestEnum
    {
        MinMax = 0,
        //A distance értékekhez S változat a középértéktől kissebb távolságra lévőt jelzi, a B a nagyobbat
        MedianDistanceB = 1,
        MedianDistanceS = 2,
        AverageDistanceB = 3,
        AverageDistanceS = 4,
        HarmonicAverageDistanceB = 5,
        HarmonicAverageDistanceS = 6,
        GeometricAverageDistanceB = 7,
        GeometricAverageDistanceS = 8,
        NegyzetesAverageDistanceB = 9,
        Default = -1
    }
}
