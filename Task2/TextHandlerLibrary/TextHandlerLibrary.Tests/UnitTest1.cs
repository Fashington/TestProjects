using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Configuration;

namespace TextHandlerLibrary.Tests
{
    [TestClass]
    public class UnitTest1
    {
        static string inputDirectory = $"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\\TextSamples\\TextSample.txt";
        static string outputDirectory = $"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\\TextSamples\\DeployedTextSample.txt";

        //static private string inputDirectory = $"E:\\Study\\TextHandlerLibrary\\TextHandlerLibrary.Tests\\bin\\Debug\\net5.0\\{ConfigurationManager.AppSettings["inputFilePath"].Clone()}";
        //static private string outputDirectory = $"E:\\Study\\TextHandlerLibrary\\TextHandlerLibrary.Tests\\bin\\Debug\\net5.0\\{ConfigurationManager.AppSettings["outputFilePath"].Clone()}";

        [TestMethod]
        public void DefaultPrintTest()
        {
            Parser parser = new Parser();
            parser.Parse(inputDirectory);
            parser.Write(parser.Print, outputDirectory);

            var areEquals = System.IO.File.ReadLines(outputDirectory).SequenceEqual(
                System.IO.File.ReadLines($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\\TextSamples\\DefaultPrintTest.txt"));

            Assert.AreEqual(true, areEquals);
        }

        [TestMethod]
        public void PrintInAscendingOrderTest()
        {
            Parser parser = new Parser();
            parser.Parse(inputDirectory);
            parser.Write(parser.PrintInAscendingOrder, outputDirectory);

            var areEquals = System.IO.File.ReadLines(outputDirectory).SequenceEqual(
                System.IO.File.ReadLines($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\\TextSamples\\PrintInAscendingOrderTest.txt"));

            Assert.AreEqual(true, areEquals);
        }

        [TestMethod]
        public void SearchWordInQuestionTest()
        {
            Parser parser = new Parser();
            parser.Parse(inputDirectory);
            parser.Write(parser.SearchWordInQuestion, 3, outputDirectory);

            var areEquals = System.IO.File.ReadLines(outputDirectory).SequenceEqual(
                System.IO.File.ReadLines($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\\TextSamples\\SearchWordInQuestionTest.txt"));

            Assert.AreEqual(true, areEquals);
        }

        [TestMethod]
        public void DeleteWordConsonantTest_WordLenght_4()
        {
            Parser parser = new Parser();
            parser.Parse(inputDirectory);
            parser.DeleteWordConsonant(4);
            parser.Write(parser.Print, outputDirectory);

            var areEquals = System.IO.File.ReadLines(outputDirectory).SequenceEqual(
                System.IO.File.ReadLines($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\\TextSamples\\DeleteWordConsonantTest.txt"));

            Assert.AreEqual(true, areEquals);
        }

        [TestMethod]
        public void ReplaceWordInSentenceTest_In_Sentence_2_WithWord_TeddyBear()
        {
            Parser parser = new Parser();
            parser.Parse(inputDirectory);
            parser.ReplaceWordInSentence(1, 4, "TeddyBear");
            parser.Write(parser.Print, outputDirectory);

            var areEquals = System.IO.File.ReadLines(outputDirectory).SequenceEqual(
                System.IO.File.ReadLines($"{AppDomain.CurrentDomain.SetupInformation.ApplicationBase}\\TextSamples\\ReplaceWordInSentenceTest.txt"));

            Assert.AreEqual(true, areEquals);
        }
    }
}
