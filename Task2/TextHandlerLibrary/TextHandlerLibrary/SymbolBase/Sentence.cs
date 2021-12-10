using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandlerLibrary.SymbolBase
{
    class Sentence
    {
        private static char[] PunctuationMarks = new char[20] { ' ', '?', '!', ',', ':', ';', '-', '[', ']', '{', '}', '(', ')', '`', '"', '\'', '.', '\t', '\v', '\n' };

        private string SentenceUnit { get; set; }

        public int Count
        {
            get
            {
                return wordList.Count;
            }
        }

        public int PunctuationCount
        {
            get
            {
                return punctuationList.Count;
            }
        }

        public List<Word> wordList = new List<Word>();
        public List<Punctuation> punctuationList = new List<Punctuation>();

        public Sentence(string sentenceUnit)
        {
            SentenceUnit = sentenceUnit;
            DivideSentence();
        }

        public void DivideSentence()
        {
            Word wordBuffer = new Word();
            Punctuation punctuationBuffer = new Punctuation();

            for (int i = 0; i < SentenceUnit.Length; i++)
            {
                if (IsPunctuation(SentenceUnit[i]) == false)
                {
                    wordBuffer.AddSymbol(SentenceUnit[i]);
                }
                else
                {
                    if (IsTab(SentenceUnit[i]) == true)
                    {
                        punctuationBuffer.SetValue(' ');
                    }
                    else
                    {
                        punctuationBuffer.SetValue(SentenceUnit[i]);
                    }

                    if (i != 0)
                    {
                        if (wordBuffer.SymbolUnit != null)
                        {
                            wordList.Add(new Word(wordBuffer.SymbolUnit));
                            wordBuffer.Clear();
                        }

                        if (punctuationBuffer.SymbolUnit.Equals(' ') == true)
                        {
                            if (SentenceUnit[i - 1].Equals(' ') == false)
                            {
                                if (SentenceUnit[i - 1].Equals('\t') == false)
                                {
                                    if (SentenceUnit[i - 1].Equals('\v') == false)
                                    {
                                        punctuationBuffer.SetIndex(wordList.Count - 1);
                                        punctuationList.Add(new Punctuation(punctuationBuffer.SymbolUnit, punctuationBuffer.Index));
                                    }
                                }
                                //punctuationBuffer.SetIndex(wordList.Count - 1);
                                //punctuationList.Add(new Punctuation(punctuationBuffer.SymbolUnit, punctuationBuffer.Index));
                            }
                        }
                        else
                        {
                            punctuationBuffer.SetIndex(wordList.Count - 1);
                            punctuationList.Add(new Punctuation(punctuationBuffer.SymbolUnit, punctuationBuffer.Index));
                        }
                    }
                    else
                    {
                        punctuationBuffer.SetIndex(-1);
                        punctuationList.Add(new Punctuation(punctuationBuffer.SymbolUnit, punctuationBuffer.Index));
                    }
                }
            }
        }
        public bool IsPunctuation(char symbol)
        {
            bool returnValue = false;

            for (int i = 0; i < PunctuationMarks.Length; i++)
            {
                if (symbol.CompareTo(PunctuationMarks[i]) == 0)
                {
                    returnValue = true;
                    break;
                }
            }
            return returnValue;
        }

        public bool IsTab(char symbol)
        {
            if (symbol.Equals('\t') == true || symbol.Equals('\v') == true)
            {
                return true;
            }
            else return false;
        }

        public string PrintCompositeSentence()
        {
            StringBuilder returnString = new StringBuilder();
            if (punctuationList.Count > 0)
            {
                if (punctuationList.ElementAt(0).Index == -1)
                {
                    returnString.Append(punctuationList.ElementAt(0).SymbolUnit);
                }

                for (int i = 0; i < wordList.Count; i++)
                {
                    returnString.Append(wordList.ElementAt(i).SymbolUnit);
                    for (int j = 0; j < punctuationList.Count; j++)
                    {
                        if (punctuationList.ElementAt(j).Index == i)
                        {
                            returnString.Append(punctuationList.ElementAt(j).SymbolUnit);
                        }
                    }
                }
            }
            return returnString.ToString();
        }

        public Word GetWordAt(int index)
        {
            return wordList.ElementAt(index);
        }

        public Punctuation GetPunctuationdAt(int index)
        {
            return punctuationList.ElementAt(index);
        }
    }
}
