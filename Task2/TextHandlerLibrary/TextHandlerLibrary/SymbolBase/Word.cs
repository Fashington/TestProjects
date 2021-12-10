using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandlerLibrary.SymbolBase
{
    class Word : ISymbolBase<string>
    {
        private string WordUnit { get; set; }

        public int Count
        {
            get
            {
                return WordUnit.Length;
            }
        }

        public  string SymbolUnit
        {
            get
            {
                return WordUnit;
            }
        }

        public List<Letter> CompositeWordUnit = new List<Letter>();

        public Word() { }

        public Word(string wordUnit)
        {
            WordUnit = wordUnit;
            ToCompositeWordUnit();
        }

        public void Clear()
        {
            WordUnit = null;
            if (CompositeWordUnit.Any() == true)
            {
                CompositeWordUnit.Clear();
            }
        }

        public void SetValue(string value)
        {
            WordUnit = value;
            ToCompositeWordUnit();
        }

        public void AddSymbol(char value)
        {
            WordUnit += value;
        }

        public void ToCompositeWordUnit()
        {
            for (int i = 0; i < WordUnit.Length - 1; i++)
            {
                CompositeWordUnit.Add(new Letter(WordUnit[i]));
            }
        }
    }
}
