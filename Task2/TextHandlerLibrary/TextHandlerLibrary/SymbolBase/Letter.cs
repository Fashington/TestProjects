using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandlerLibrary.SymbolBase
{
    class Letter : ISymbolBase<Char>
    {
        private char[] Vowel = new char[12] { 'a', 'e', 'i', 'o', 'u', 'y', 'A', 'E', 'I', 'O', 'U', 'Y' };
        private char LetterUnit { get; set; }
        public char SymbolUnit
        {
            get
            {
                return LetterUnit;
            }
        }

        public Letter() { }

        public Letter(char letterUnit)
        {
            this.LetterUnit = letterUnit;
        }

        public  void Clear()
        {
            LetterUnit = '\0';
        }

        public void SetValue(char value)
        {
            LetterUnit = value;
        }

        public bool IsVowel()
        {
            bool isTrue = false;

            for (int i = 0; i < 12; i++)
            {
                if (LetterUnit.Equals(Vowel[i]) == true)
                {
                    isTrue = true;
                }
            }

            return isTrue;
        }
    }
}

