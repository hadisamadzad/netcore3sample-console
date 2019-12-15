using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Paragraph = DocumentFormat.OpenXml.Wordprocessing.Paragraph;

namespace SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"D:\Hadi Samadzad.docx";
            //byte[] file = File.ReadAllBytes(path);
            using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(path, true))
            {
                string docText = null;
                using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = sr.ReadToEnd();
                }
                // here i will manipuldate docText
                MemoryStream ms = new MemoryStream();
                using (WordprocessingDocument wordDocument =
                    WordprocessingDocument.Create(ms, WordprocessingDocumentType.Document, true))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    Body body = new Body(new Paragraph(new DocumentFormat.OpenXml.Drawing.Run(new DocumentFormat.OpenXml.Drawing.Text(docText))));
                    mainPart.Document = new Document(body);
                }
                File.WriteAllBytes(@"D:\New Hadi.docx", ms.ToArray());
            }

            Console.ReadKey();
        }

        public static async Task MyAsyncMethod()
        {
            await Task.Run(() => doSomething());
            Console.WriteLine("I thought this should come first");
            //await task;
        }

        public static async Task doSomething()
        {
            await Task.Delay(5000);
            Console.WriteLine("I should come second");
        }

        public static IEnumerable<double> M2(double number)
        {
            var res = new List<double>();
            for (int i = 1; i <= number; i++)
            {
                res.Add(Math.Pow(1.01, i));
            }

            return res;
        }

        public static IEnumerable<double> YM2(double number)
        {
            for (int i = 1; i <= number; i++)
            {
                yield return Math.Pow(1.01, i);
            }
        }

        //public static Task<IEnumerable<double>> M2(double number)
        //{
        //    var res = new List<double>();
        //    var task = new Task<IEnumerable<double>>(() =>
        //    {
        //        for (int i = 1; i <= number; i++)
        //        {
        //            res.Add(Math.Pow(1.01, i));
        //        }

        //        return res;
        //    });

        //    return task;
        //}

        //public static Task<IEnumerable<double>> YM2(double number)
        //{
        //    var res = new List<double>();
        //    var task = new Task<IEnumerable<double>>(() =>
        //    {
        //        for (int i = 1; i <= number; i++)
        //        {
        //            yield return Math.Pow(1.01, i);
        //        }

        //        return res;
        //    });

        //    return task;
        //}
    }
}
