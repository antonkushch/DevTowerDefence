using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.Interfaces
{
    interface ISpecialAttack<T> : IAttack<AbstractDeveloper>
    {
        void SpecialAttack(T attackBy);
    }
}
