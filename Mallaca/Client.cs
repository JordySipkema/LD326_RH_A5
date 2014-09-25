using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mallaca
{
    class Client : User
    {
        public int Lenght { get; set; }
        public int Weight { get; set; }
        public double BMI { get { return Weight / (Lenght * Lenght);} }
        public Client()
        { 
        
        }
    }
}
