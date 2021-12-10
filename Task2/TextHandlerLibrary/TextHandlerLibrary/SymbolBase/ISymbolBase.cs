using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextHandlerLibrary.SymbolBase
{
    interface ISymbolBase<T>
    {
        public T SymbolUnit { get;}

        public void SetValue(T value);

        public void Clear();
    }
}
