using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04Hospital
{
    class Patient
    {
        public string Name { get; set; }

        public string Doctor { get; set; }

        public Patient(string name, string doctor)
        {
            this.Name = name;
            this.Doctor = doctor;
        }
    }
}
