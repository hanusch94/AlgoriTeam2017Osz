using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/*
 * A projekt célja, hogy egy 4 fős csapattal aláíráshitelesítéshez készítsünk osztályozót.
 *      A kényelem kedvéért a külön algoritmusokat más más környezetben, texchnológiával készítettük el.
 *      
 *      Én statisztikai alapú osztályozással kísérleteztem, valamint az én feladatom volt, hogy a végső
 *      eredményt adjak a különálló algoritmusok eredményei alapján.
 * 
 * Ennek az osztálynak a feladata, hogy a fájlba kiírt eredményeket beolvassa, majd egy összegzést végezzen,
 * minek az eredményét kiírja a képernyőre
 */

namespace Metaclassification.Fusion
{
    public static class Merge
    {
        private static int SignerStart = 0;
        private static int SignerEnd = 20;
        private static int SignStart = 10;
        private static int SignEnd = 40;
        private static double BasicRet = -1;

        private static int joE = 0;
        private static int joH = 0;

        public static void Run()
        {
            List<System.IO.StreamReader> files = new List<System.IO.StreamReader>();
            List<double> accuracy = new List<double>();

            ////////////fileSetup start
            ////TODO: WindowsForm-ban fileexplorer segíłtségével lehessen kiválasztani a fájlokat
            files.Add(new System.IO.StreamReader(Program.ResPath +"RinMed.txt"));
            accuracy.Add(0.74);
            files.Add(new System.IO.StreamReader(Program.ResPath + "RinAvg.txt"));
            accuracy.Add(0.74);
            files.Add(new System.IO.StreamReader(Program.ResPath + "Ain.txt"));
            accuracy.Add(0.62);

            //files.Add(new System.IO.StreamReader(Program.ResPath + "RinMinMax.txt"));
            //accuracy.Add(0.70);
            //files.Add(new System.IO.StreamReader(Program.ResPath + "RinHarm.txt"));
            //accuracy.Add(0.70);
            //files.Add(new System.IO.StreamReader(Program.ResPath + "RinGeom.txt"));
            //accuracy.Add(0.68);
            //files.Add(new System.IO.StreamReader(Program.ResPath + "RinNegyz.txt"));
            //accuracy.Add(0.71);
            /////////////fileSetup end

            if (accuracy.Count != files.Count) throw new IndexOutOfRangeException("Minden fájlhoz 1-1 accuracy-nak kell tartoznia. Ez nem teljesül");
            try
            {
                string sLine;
                for (int i = 0; i < SignerStart; i++)
                {
                    for (int fileId = 0; fileId < files.Count; fileId++)
                    {
                        if ((sLine = files[fileId].ReadLine()) == null) throw new IndexOutOfRangeException("A " + fileId + ". fajl nem tartalmaz eleg sort");
                    }
                }
                double[] ret = new double[SignEnd - SignStart];
                for (int i = 0; i < ret.Length; i++) ret[i] = BasicRet;

                for (int SignerId = SignerStart; SignerId < SignerEnd; SignerId++)
                {
                    for (int fileId = 0; fileId < files.Count; fileId++)
                    {
                        if ((sLine = files[fileId].ReadLine()) == null) throw new IndexOutOfRangeException("A " + fileId + ". fajl nem tartalmaz eleg sort");
                        String[] saLine = sLine.Trim().Split('\t');
                        if (saLine.Length < ret.Length) throw new IndexOutOfRangeException("A " + fileId + ". fajl " + SignerId + ". sorában nem tartalmaz eleg értéket");
                        for (int SignId = SignStart; SignId < SignEnd; SignId++)
                        {
                            int eredeti = Int32.Parse(saLine[SignId]);
                            switch (eredeti)
                            {
                                case 1:
                                    ret[SignId - SignStart] = BayesTrap(ret[SignId - SignStart], accuracy[fileId]);
                                    break;
                                case 0:
                                    ret[SignId - SignStart] = BayesTrap(ret[SignId - SignStart], 1 - accuracy[fileId]);
                                    break;
                                case -1: break;     ///nincs számolt értéke az adott aláírásra az adott algoritmusnak
                                default: throw new ArgumentOutOfRangeException("A " + fileId + ". fajl " + SignerId + ". sorában " + SignId);
                            }
                        }
                    }

                    for (int i = SignStart; i < SignEnd; i++)
                    {
                        double value = ret[i - SignStart];
                        if (i < 20)
                        {
                            if (0.5<=value) {
                                joE++;
                            }
                        }
                        else if (20 <= i)
                        {
                            if (value<0.5)
                                joH++;
                        }
                        else throw new ArgumentException();
                        ret[i - SignStart] = BasicRet;
                    }
                }
                kiir();
            }
            finally { foreach (System.IO.StreamReader file in files) file.Close(); }
        }

        private static double BayesTrap(double now, double change)
        {
            if (now == -1) return change;   ///-1 jelöli, ha az adott algoritmus nem ad eredményt az adott aláírásra
            if (change > 1 || change < 0) throw new ArgumentOutOfRangeException("change");
            if (now > 1 || now < 0) throw new ArgumentOutOfRangeException("now");

            return (now * change) / (now * change + (1 - now) * (1 - change));
        }

        private static void kiir()
        {
            int osszEredeti = SignEnd<20 ? (SignEnd-SignStart)*(SignerEnd-SignerStart) : (20-SignStart) * (SignerEnd - SignerStart);
            int osszHamis = (SignEnd - SignStart) * (SignerEnd - SignerStart) - osszEredeti;

            double procE = (double)joE / osszEredeti * 100;
            double procH = (double)joH / osszHamis * 100;

            Console.WriteLine("\n_____MERGE_____");
            Console.WriteLine("Eredeti:       {0}/{1}       {2}", joE, osszEredeti, procE);
            Console.WriteLine("Hamis:         {0}/{1}       {2}", joH, osszHamis, procH);
            Console.WriteLine("Sum:           {0}/{1}       {2}", joE+ joH, osszEredeti + osszHamis, (double)(joE+joH) / (osszEredeti+osszHamis)*100);
            Console.WriteLine("Avg's AVG:                   {0}\n", (procE + procH) / 2);
        }
    }
}
