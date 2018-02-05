using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metaclassification
{

    static class Program
    {
        public static string ResPath = System.IO.Directory.GetCurrentDirectory() + @"\resources\";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Console.WriteLine("\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n");

            TestingPhase();
            Fusion.Merge.Run();

            Console.WriteLine("\n::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::\n");

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }

        private static void TestingPhase()
        {
            smalltest.SmallTester sTester = smalltest.SmallTester.Instance;
            sTester.setDB(Data.InputOutput.Read.Tabla());
            sTester.RunTestForEveryone(smalltest.TestEnum.GeometricAverageDistanceB);
            sTester.RunTestForEveryone(smalltest.TestEnum.HarmonicAverageDistanceB);
            sTester.RunTestForEveryone(smalltest.TestEnum.MinMax);
            sTester.RunTestForEveryone(smalltest.TestEnum.NegyzetesAverageDistanceB);
            sTester.RunTestForEveryone(smalltest.TestEnum.AverageDistanceB);
            sTester.RunTestForEveryone(smalltest.TestEnum.MedianDistanceB);
            //sTester.RunTestForEveryone(smalltest.TestEnum.Fusion);
        }
    }
}
