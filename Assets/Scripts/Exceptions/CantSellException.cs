using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Exceptions
{
    public class CantSellException : Exception
    {
        public CantSellException() { }
        public CantSellException(string msg) : base(msg) { }
    }
}
