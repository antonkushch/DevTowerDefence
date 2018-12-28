using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Exceptions
{
    public class NotEnoughMoneyException : Exception
    {
        public NotEnoughMoneyException() { }
        public NotEnoughMoneyException(string msg) : base(msg) { }
    }
}
