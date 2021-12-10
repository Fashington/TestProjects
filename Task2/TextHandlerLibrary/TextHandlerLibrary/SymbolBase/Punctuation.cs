using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandlerLibrary.SymbolBase
{
    class Punctuation : ISymbolBase<char>
    {
        private char SimplePunctuationUnit { get; set; }
        private int WordIndex;

        public char SymbolUnit
        {
            get
            {
                return SimplePunctuationUnit;
            }
        }

        public int Index
        {
            get
            {
                return WordIndex;
            }
        }

        public Punctuation() { }

        public Punctuation(char simplePunctuationUnit, int wordIndex)
        {
            SimplePunctuationUnit = simplePunctuationUnit;
            WordIndex = wordIndex;
        }

        public Punctuation(char simplePunctuationUnit)
        {
            SimplePunctuationUnit = simplePunctuationUnit;
        }

        public void Clear()
        {
            SimplePunctuationUnit = '\0';
        }

        public void SetIndex(int index)
        {
            WordIndex = index;
        }

        public void SetValue(char value)
        {
            SimplePunctuationUnit = value;
        }
    }
}
