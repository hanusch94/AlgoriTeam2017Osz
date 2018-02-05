using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metaclassification.Data.InputOutput
{
    public static class Read
    {
        public static List<String> FromFile(String Path)
        {
            List<string> ret = new List<String>();

            int counter = 0;
            string line;

            // Read the file and display it line by line. 
            System.IO.StreamReader file = new System.IO.StreamReader(Path);
            while ((line = file.ReadLine()) != null)
            {
                ret.Add(line);
                counter++;
            }

            return ret;
        }

        public static List<List<double>> Tabla(List<int> titles)
        {
            List<List<double>> ret = new List<List<double>>();

            List<double> line = new List<double>();
            int sorIndex = 0;
            foreach (String lm in FromFile(Program.ResPath + @"input.txt"))
            {
                String[] splitted = lm.Trim().Split('\t');
                if (splitted[1] == "h" || splitted[1] == "e")
                {
                    if (line.Count > 0)
                    {
                        ret.Add(line);
                        line = new List<double>();
                    }
                }
                //foreach (string ertek in splitted)
                for (int i = 0; i < splitted.Length; i++)
                {
                    bool need = false;
                    foreach(int title in titles)
                        if (title == i)
                        {
                            string ertek = splitted[i];
                            line.Add(CellaErtek(i, ertek));
                        }
                }
                sorIndex++;
            }

            return ret;
        }

        public static List<List<double>> Tabla()
        {
            List<List<double>> ret = new List<List<double>>();

            List<double> line = new List<double>();
            int sorIndex = 0;
            foreach(String lm in FromFile(Program.ResPath + @"input.txt"))
            {
                String[] splitted = lm.Trim().Split('\t');
                if (splitted[1] == "h" || splitted[1] == "e")
                {
                    if (line.Count > 0)
                    {
                        ret.Add(line);
                        line = new List<double>();
                    }
                }
                //foreach (string ertek in splitted)
                for (int i = 0; i<splitted.Length; i++)
                {
                    string ertek = splitted[i];
                    line.Add(CellaErtek(i, ertek));
                }
                sorIndex++;
            }
            if (line.Count > 0)
            {
                ret.Add(line);
                line = new List<double>();
            }

            return ret;
        }


        private static double CellaErtek(int i, string ertek)
        {
            double ret;

            switch (i)
            {
                case (int)Titles.eredetiseg:
                    ret = ertek == "e" ? 1 : 0;
                    break;
                case (int)Titles.Loop_Extent_0:
                case (int)Titles.Loop_Extent_1:
                case (int)Titles.Loop_Extent_2:
                case (int)Titles.Loop_Extent_3:
                case (int)Titles.Loop_Extent_4:
                    ret = ertek == "Infinity" ? 1 : double.Parse(ertek);
                    break;
                case (int)Titles.Loop_InscribedDiameter_0:
                case (int)Titles.Loop_InscribedDiameter_1:
                case (int)Titles.Loop_InscribedDiameter_2:
                case (int)Titles.Loop_InscribedDiameter_3:
                case (int)Titles.Loop_InscribedDiameter_4:
                case (int)Titles.Loop_ModificationRatio_0:
                case (int)Titles.Loop_ModificationRatio_1:
                case (int)Titles.Loop_ModificationRatio_2:
                case (int)Titles.Loop_ModificationRatio_3:
                case (int)Titles.Loop_ModificationRatio_4:
                    ret = ertek == "#N�V?" ? -1 : double.Parse(ertek);
                    break;
                default:
                    ret = double.Parse(ertek);
                    break;
            }
            return ret;
        }
    }
}
