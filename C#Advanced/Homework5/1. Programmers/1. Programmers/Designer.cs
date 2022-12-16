using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._Programmers
{
    public class Designer : Junior
    {
        public Designer(string name, int age, string company, decimal salary) 
        : base(name, age, company, salary)
        {
            this.DesignKnowledge = new List<string>();
        }

        public List<string> DesignKnowledge { get; set; }
    }
}
