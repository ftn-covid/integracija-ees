using FTN;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Pisi
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var base1 = new BaseVoltage() { Name = "BaseVoltage1", NominalVoltage = 5, MRID = Guid.NewGuid().ToString() };
            var base2 = new BaseVoltage() { Name = "BaseVoltage2", NominalVoltage = 15, MRID = Guid.NewGuid().ToString() };

            List<PowerTransformer> transformers = new List<PowerTransformer>();
            List<TransformerWinding> windings = new List<TransformerWinding>();
            List<WindingTest> windingTests = new List<WindingTest>();

            for (int i = 0; i < 20; i++)
            {
                PowerTransformer transformer = new PowerTransformer
                {
                    Name = $"Transformer {i}",
                    MRID = Guid.NewGuid().ToString(),
                    Description = $"Description for power transformer {i}"
                };
                transformers.Add(transformer);
                List<TransformerWinding> windingList = new List<TransformerWinding> {
                    new TransformerWinding{
                        Name = $"Winding {2 * i}",
                        MRID = Guid.NewGuid().ToString(),
                        BaseVoltage = base1,
                        Description = $"Description for transformer winding {2 * i}",
                        PowerTransformer = transformer
                    },
                    new TransformerWinding {
                        Name = $"Winding {2 * i + 1}",
                        MRID = Guid.NewGuid().ToString(),
                        BaseVoltage = base2,
                        Description = $"Description for transformer winding {2 * i + 1}",
                        PowerTransformer = transformer
                    }
                };
                windings.AddRange(windingList);

                List<WindingTest> windingTestList = new List<WindingTest> {
                    new WindingTest {
                        Name = $"Winding test {2 * i}",
                        MRID = Guid.NewGuid().ToString(),
                        From_TransformerWinding = windingList[0],
                        Description = $"Description for winding test {2 * i}"
                    },
                    new WindingTest {
                        Name = $"Winding test {2 * i + 1}",
                        MRID = Guid.NewGuid().ToString(),
                        From_TransformerWinding = windingList[1],
                        Description = $"Description for winding test {2 * i + 1}"
                    }
                 };

                windingTests.AddRange(windingTestList);
            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(BaseVoltageToString(base1, "1"));
            sb.AppendLine(BaseVoltageToString(base2, "2"));

            for (int i = 0; i < 20; i++)
            {
                sb.AppendLine(TranformerToString(transformers[i], i.ToString()));

                sb.AppendLine(WindingToString(windings[2 * i], $"{i}, 1"));
                sb.AppendLine(WindingTestToString(windingTests[2 * i], $"{i}, 1"));

                sb.AppendLine(WindingToString(windings[2 * i + 1], $"{i}, 2"));
                sb.AppendLine(WindingTestToString(windingTests[2 * i + 1], $"{i}, 2"));
            }
            //Console.WriteLine(sb.ToString());
            System.IO.File.WriteAllText("pisi.txt", sb.ToString());
            Console.ReadLine();
        }

        public static string BaseVoltageToString(BaseVoltage baseV, string num)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"BV {num}\n\t");
            sb.AppendLine($"\tNAME: {baseV.Name}");
            sb.AppendLine($"\tMRDI: {baseV.MRID}");
            sb.AppendLine($"\tNOMINAL VOLTAGE: { baseV.NominalVoltage.ToString()}");
            return sb.ToString();
        }

        public static string TranformerToString(PowerTransformer transformer, string num)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"PT {num}\n\t NAME: {transformer.Name}");
            sb.AppendLine($"\tMRDI: {transformer.MRID}");
            sb.AppendLine($"\tDESCRIPTION: { transformer.Description}");
            return sb.ToString();
        }

        public static string WindingToString(TransformerWinding winding, string num)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\t\tTW {num}");
            sb.AppendLine($"\t\t\tNAME: {winding.Name}");
            sb.AppendLine($"\t\t\tMRDI: {winding.MRID}");
            sb.AppendLine($"\t\t\tDESCRIPTION: {winding.Description}");
            sb.AppendLine($"\t\t\tNOMINAL VOLTAGE: {winding.BaseVoltage.NominalVoltage}");
            return sb.ToString();
        }

        public static string WindingTestToString(WindingTest winding, string num)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"\t\t\t\tWT {num}");
            sb.AppendLine($"\t\t\t\t\tNAME: {winding.Name}");
            sb.AppendLine($"\t\t\t\t\tMRID: {winding.MRID}");
            sb.AppendLine($"\t\t\t\t\tDESCRIPTION: {winding.Description}");
            return sb.ToString();
        }
    }
}