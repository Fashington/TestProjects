using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using TextHandlerLibrary.SymbolBase;
using System.Configuration;

namespace TextHandlerLibrary
{
    public class Parser
    {
        private static List<Sentence> Sentences = new List<Sentence>();

        private void StringSeparator(string stringUnit)
        {
            StringBuilder buffString = new StringBuilder();
            for (int i = 0; i < stringUnit.Length; i++)
            {
                switch (stringUnit[i])
                {
                    case '.':
                        if (i < stringUnit.Length - 1)
                        {
                            if (stringUnit[i + 1].Equals('.') == true)
                            {
                                buffString.Append(stringUnit[i]);
                            }
                            else
                            {
                                buffString.Append(stringUnit[i]);
                                Sentences.Add(new Sentence(buffString.ToString()));
                                buffString.Clear();
                            }
                        }
                        else
                        {
                            buffString.Append(stringUnit[i]);
                            Sentences.Add(new Sentence(buffString.ToString()));
                            buffString.Clear();
                        }
                        break;
                    case ';':
                        buffString.Append(stringUnit[i]);
                        Sentences.Add(new Sentence(buffString.ToString()));
                        buffString.Clear();
                        break;
                    case '!':
                        buffString.Append(stringUnit[i]);
                        Sentences.Add(new Sentence(buffString.ToString()));
                        buffString.Clear();
                        break;
                    case '?':
                        buffString.Append(stringUnit[i]);
                        Sentences.Add(new Sentence(buffString.ToString()));
                        buffString.Clear();
                        break;
                    default:
                        if (i == stringUnit.Length - 1)
                        {
                            buffString.Append(stringUnit[i]);
                            Sentences.Add(new Sentence(buffString.ToString()));
                            buffString.Clear();
                        }
                        else
                        {
                            buffString.Append(stringUnit[i]);
                        }
                        break;
                }
            }
        }

        public void Parse(string inputDirectory)
        {
            using (StreamReader streamReader = new StreamReader(inputDirectory, System.Text.Encoding.Default))
            {
                int iterator = 0;
                while (streamReader.Peek() > -1)
                {
                    if (iterator > 0)
                    {
                        StringSeparator($"\n{streamReader.ReadLine()}");
                    }
                    else
                    {
                        StringSeparator(streamReader.ReadLine());
                    }
                    iterator++;
                }
            }
        }

        public void Write(Func<string> printMethod, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, System.Text.Encoding.Default))
            {
                writer.Write(printMethod());
            }
        }

        public void Write(Func<int, string> printMethod, int i, string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath, false, System.Text.Encoding.Default))
            {
                writer.Write(printMethod(i));
            }
        }

        public string Print()
        {
            StringBuilder returnString = new StringBuilder();

            foreach (Sentence sentence in Sentences)
            {
                returnString.Append(sentence.PrintCompositeSentence());
            }

            return returnString.ToString();
        }

        public string PrintInAscendingOrder()
        {
            StringBuilder returnString = new StringBuilder();

            var sortedSentences = Sentences.OrderBy(s => s.Count);

            foreach (Sentence sortedSentence in sortedSentences)
            {
                returnString.Append(sortedSentence.PrintCompositeSentence());
            }

            return returnString.ToString();
        }

        public string SearchWordInQuestion(int wordLenght)
        {
            StringBuilder returnString = new StringBuilder();

            List<Word> soughtWords = new List<Word>();

            foreach (Sentence sentence in Sentences)
            {
                for (int i = 0; i < sentence.PunctuationCount; i++)
                {
                    if (sentence.GetPunctuationdAt(i).SymbolUnit.Equals('?') == true)
                    {
                        for (int j = 0; j < sentence.Count; j++)
                        {
                            if (sentence.GetWordAt(j).Count == wordLenght)
                            {
                                if (soughtWords.Count > 0)
                                {
                                    int uniqueCounter = soughtWords.Count;

                                    foreach (Word sampleWord in soughtWords)
                                    {
                                        if (sentence.GetWordAt(j).SymbolUnit != sampleWord.SymbolUnit)
                                        {
                                            uniqueCounter--;
                                        }
                                    }

                                    if (uniqueCounter == 0)
                                    {
                                        soughtWords.Add(sentence.GetWordAt(j));
                                    }
                                }
                                else
                                {
                                    soughtWords.Add(sentence.GetWordAt(j));
                                }
                            }
                        }
                    }
                }
            }

            foreach (Word word in soughtWords)
            {
                if (returnString.Length > 0)
                {
                    returnString.Append($"\n{word.SymbolUnit}");
                }
                else returnString.Append(word.SymbolUnit);
            }

            return returnString.ToString();
        }

        public void DeleteWordConsonant(int wordLenght)
        {
            foreach (Sentence sentence in Sentences)
            {
                var wordSearchResult = sentence.wordList.Where(s => (s.Count == wordLenght)
                && (s.CompositeWordUnit.ElementAt(0).IsVowel() == false)).ToList();

                foreach (Word word in wordSearchResult)
                {
                    sentence.wordList.Remove(word);
                }
            }
        }

        public void ReplaceWordInSentence(int sentenceIndex, int originWordLenght, string wordSample)
        {
            var wordSearchResult = Sentences.ElementAt(sentenceIndex).wordList.Where(s => s.Count == originWordLenght).ToList();

            foreach (Word word in wordSearchResult)
            {
                int index = Sentences.ElementAt(sentenceIndex).wordList.IndexOf(word);
                Sentences.ElementAt(sentenceIndex).wordList.ElementAt(index).Clear();
                Sentences.ElementAt(sentenceIndex).wordList.ElementAt(index).SetValue(wordSample);
            }
        }
    }
}
