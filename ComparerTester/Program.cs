using System;
using System.Collections.Generic;

using System.Text;
using TK_DataComparerLib;
using FilesComparer;

namespace ComparerTester
{
    class Program
    {
        static void Main(string[] args)
        {
            ComparisonBoard comp = new ComparisonBoard();

            ComparableFolder leftFolder = new ComparableFolder();
            leftFolder.Name = "C:\\tmp";
            leftFolder.CollectEntities();

            ComparableFolder rightFolder = new ComparableFolder();
            rightFolder.Name = "C:\\tmp - Copie";
            rightFolder.CollectEntities();

            comp.CreateComparison(leftFolder, rightFolder);

            WriteResults(comp, leftFolder.Entities[0]);

            Console.Read();
        }

        private static void WriteResults(ComparisonBoard comp, DataEntity dataEntity)
        {
            foreach (DataEntity otherEntity in comp.Comparisons[dataEntity].Keys)
            {
                foreach (string propName in comp.Comparisons[dataEntity][otherEntity].Keys)
                {
                    Console.Write(comp.Comparisons[dataEntity][otherEntity][propName].ToString());
                    Console.Write(" - ");
                }
                Console.WriteLine("");
            }
        }
    }
}
