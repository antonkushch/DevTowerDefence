using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Exceptions
{
    public class MaxUpgradeException : Exception
    {
        public MaxUpgradeException() { }
        public MaxUpgradeException(string msg) : base(msg) { }
    }
}
