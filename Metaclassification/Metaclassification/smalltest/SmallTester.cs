using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaclassification.smalltest
{
    public class SmallTester
    {
        private static SmallTester instance = null;
        private List<List<double>> dataBase = null;

        private SmallTester() { }

        public static SmallTester Instance { get
            {
                if (instance == null) instance = new SmallTester();
                return instance;
            } }

        public void setDB(List<List<double>> DB)
        {
            dataBase = DB;
        }

        public double GetValueFromDb(int signIndex, int Title)
        {
            return dataBase[signIndex][Title];
        }

        public void RunTestForEveryone(TestEnum testEnum)
        {
            Console.WriteLine("\n_____" + Enum.GetName(typeof(TestEnum), testEnum) + "_____");
            int joE = 0;
            int joH = 0;
            int maxSigner = 20;
            int[] e = null;
            for (int SignerI=0; SignerI<maxSigner; SignerI++)
            {
                e = RunTest(SignerI, testEnum);
                joE += e[0];
                joH += e[1];
            }

            //Console.WriteLine(joE + "__" + (double)(joE)*10/maxSigner + ":::::"+ joH + "__" + (double)(joH) * 5 / maxSigner);
            //Console.WriteLine((double)(2*joE + joH) * 2.5 / maxSigner + "\n");

            double procE = (double)(joE) * 10 / maxSigner;
            double procH = (double)(joH) * 5 / maxSigner;

            Console.WriteLine("Eredeti:       {0}/{1}       {2}", joE, maxSigner*10, procE);
            Console.WriteLine("Hamis:         {0}/{1}       {2}", joH, maxSigner*20, procH);
            //Console.WriteLine("Sum:           {0}/{1}       {2}", joE + joH, maxSigner*30, (double)(joE + joH) / (maxSigner*30) * 100);
            Console.WriteLine("Avg's AVG:                   {0}\n", (procE + procH) / 2);
        }

        public int[] RunTest(int SignerIndex, TestEnum test = TestEnum.Default)
        {
            int[] ret = new int[2];

            TestEnum[] testEnum = null;

            if (test != TestEnum.Default) {
                testEnum = new TestEnum[]{ test};
            }
            else {
                testEnum = new TestEnum[]{
                    //TestEnum.MinMax,
                    TestEnum.MedianDistanceB,
                    //TestEnum.AverageDistanceB,
                    //TestEnum.HarmonicAverageDistanceB,
                    //TestEnum.GeometricAverageDistanceB,
                    //TestEnum.NegyzetesAverageDistanceB,
                };
            }
            double[] EnumRet = new double[testEnum.Length];
            int forSet = 2;
            IntervallTest.forSet = forSet;
            int forWeight = 6;
            List<double> Betanito = new List<double>();
            for (double i = 0; i < 10 - IntervallTest.forSet - forWeight; i++)
                Betanito.Add(0);


            int firstSignIndex = SignerIndex * 40;
            double[] eredmenyek = new double[30];
            for (int i = 0; i < eredmenyek.Length; i++) eredmenyek[i] = 0;

            /////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////

            for (int i = 2; i < dataBase[0].Count; i++)
            {
                int[] weight = new int[testEnum.Length];
                for (int testId = 0; testId < testEnum.Length; testId++)
                {
                    IntervallTest.forSet = forSet;
                    IntervallTest.Set(firstSignIndex, i, testEnum[testId]);
                    //begin weightSet
                    for (int signI = 0; signI < forWeight; signI++)
                    {
                        if (IntervallTest.InIntervall(firstSignIndex + IntervallTest.forSet + signI, i))
                            weight[testId]++;
                        IntervallTest.forSet++;
                        IntervallTest.Set(firstSignIndex, i, testEnum[testId]);
                    }
                    //end weightSet
                }
                //Console.WriteLine(weight[0]);
                IntervallTest.forSet = forSet + forWeight;
                for (int testId = 0; testId < testEnum.Length; testId++)
                {
                    IntervallTest.Set(firstSignIndex, i, testEnum[testId]);
                    double sulyozott = weight[testId] >= forWeight - 2 ? (double)weight[testId] / forWeight : 0;
                    if (weight[testId] == 4)
                    {
                        bool stop = true;
                    }
                    if (sulyozott != 0)
                    {
                        //begin betanit
                        for (int signI = 0; signI < 10 - IntervallTest.forSet; signI++)
                        {
                            if (IntervallTest.InIntervall(firstSignIndex + IntervallTest.forSet + forWeight + signI, i))
                                Betanito[signI] += sulyozott;
                        }
                        //end betanit
                        for (int signI = 0; signI < eredmenyek.Length; signI++)
                        {
                            if (IntervallTest.InIntervall(firstSignIndex + 10 + signI, i))
                                eredmenyek[signI] += sulyozott;
                        }
                        //break;
                    }
                }
            }

            ret[0] = 0;
            ret[1] = 0;
            string eredmeny = "-1\t-1\t-1\t-1\t-1\t-1\t-1\t-1\t-1\t-1";
            double border = Betanito.Min();
            for (int i = 0; i < eredmenyek.Length; i++)
            {
                if (border <= eredmenyek[i])
                {
                    if (i < 10) ret[0]++;
                    eredmeny = eredmeny +"\t1";
                }
                else if (eredmenyek[i] < border)
                {
                    if (10 <= i) ret[1]++;
                    eredmeny = eredmeny + "\t0";
                }
            }
            //Console.WriteLine(eredmeny);

            return ret;
        }

    }
}
