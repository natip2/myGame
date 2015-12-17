using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [System.AttributeUsage(AttributeTargets.Class)]
    class RegisterPlayerInFactoryAttribute : Attribute
    {
        Type _interfaceType;
        public Type InterfaceType
        {
            get { return _interfaceType; }

        }
        public RegisterPlayerInFactoryAttribute(Type interfaceType)
        {
            _interfaceType = interfaceType;
        }
    }
}
