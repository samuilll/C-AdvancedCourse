using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04Hospital
{
    class Department
    {
        public string Name { get; set; }

        public List<Patient> Patients { get; set; }

        public Department(string name)
        {
            this.Name = name;

            this.Patients = new List<Patient>();
        }
    }
}
