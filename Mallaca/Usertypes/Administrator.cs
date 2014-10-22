using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mallaca.Usertypes
{
    public class Administrator : Specialist
    {

        public Administrator() 
        {
        }

        public override UserType UserType
        {
            get
            {
                return UserType.Administrator;
            }
        }
    }
}
