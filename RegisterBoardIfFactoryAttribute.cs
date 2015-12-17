using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [System.AttributeUsage(AttributeTargets.Class)]
    class RegisterBoardIfFactoryAttribute : Attribute
    {
        //a b c..
        string _uiOption;

        public string UIOption
        {
            get { return _uiOption; }
           
        }
        public RegisterBoardIfFactoryAttribute(string uiOption)
        {
            _uiOption = uiOption; 
        }
    }
}
