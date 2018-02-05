using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Metaclassification.Data.InputOutput
{
    public static class Write
    {
        public static void SysOut(List<List<double>> matrix)
        {
            int i = 0;
            StringBuilder output = new StringBuilder();
            if (i % 20 == 0) Console.WriteLine();
            foreach (List<double> line in matrix)
            {
                output.Clear();
                foreach (double lm in line)
                {
                    output.Append(lm + "\t");
                }
                Console.WriteLine(output);
            }
        }

    }
}
