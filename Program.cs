using System;
using System.Runtime.Serialization;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Runtime.Serialization.Json;

namespace Lab5
{
    class Program
    {
        static void Main(string[] args)
        {

            DocumentStatistics docstat = new DocumentStatistics();
            const string path = @"C:\Users\kcross\Desktop\Education\C# Certification\C# class 2\Lab5";
            ProcessFiles(path,docstat);
            SerializeStats(@"C:\Users\kcross\Desktop\Education\C# Certification\C# class 2\Lab5\jsonresult.json", docstat);


            Console.WriteLine("Done...Press <ENTER> to exit.");
            Console.ReadLine();
        }
        private static void ProcessFiles(string filepath, DocumentStatistics d)
        {
            
           Console.WriteLine("Processing Files....");

            string[] files = Directory.GetFiles(filepath);
            for (int i = 0; i < files.Length; i++)
            {
                string[] paths = files[i].Split('\\');
                string fn = paths[paths.Length-1];
                
                
                d.Documents.Add(fn);
                d.DocumentCount++;
                string[] words;
                string allwords = string.Empty;

                StreamReader s = new StreamReader(files[i]);
                allwords = s.ReadToEnd();
                allwords.Replace("(","").Replace(")", "").Replace(":", "").Replace(";", "");
                words = Regex.Split(allwords,@"\s+");
                              
                foreach (string st in words)
                {
                    if (!string.IsNullOrEmpty(st))
                    {
                        if (d.WordCounts.ContainsKey(st.ToLower()))
                        {
                            d.WordCounts[st.ToLower()]++;
                        }
                        else
                            d.WordCounts.Add(st.ToLower().Trim(), 1);
                    }
                }
                
            }
        }

        private static void SerializeStats(string filepath, DocumentStatistics stats)
        {
            Console.WriteLine("Serializing to Json....");
            FileStream writer = new FileStream(filepath, FileMode.Create);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(DocumentStatistics));
            
            serializer.WriteObject(writer, stats);
            writer.Close();
        }
    }
}
