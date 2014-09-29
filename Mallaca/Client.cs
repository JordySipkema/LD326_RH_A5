using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mallaca
{
    class Client : User
    {
        public decimal Lenght { get; set; }
        public decimal Weight { get; set; }
        public decimal BMI { get { return Weight / (Lenght * Lenght);} }
        public Client()
        { 
        
        }
    }
}
