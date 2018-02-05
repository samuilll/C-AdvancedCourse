using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task04Hospital
{
    class Task04Hospital
    {
        static void Main(string[] args)
        {

            var departmentData = new Dictionary<string, Department>();

            var doctorData = new Dictionary<string, List<Patient>>();

            SetTheDataInSorages(departmentData, doctorData);

            RecieveOutputLinesAndPrint(departmentData, doctorData);
        }

        private static void SetTheDataInSorages(Dictionary<string, Department> departmentData, Dictionary<string, List<Patient>> doctorData)
        {
            var line = Console.ReadLine().Split();

            while (line[0] != "Output")
            {
                var department = line[0];

                var doctor = line[1] + " " + line[2];

                var patientName = line[3];

                var patient = new Patient(patientName, doctor);

                if (!departmentData.ContainsKey(department))
                {
                    departmentData[department] = new Department(department);
                }
                if (departmentData[department].Patients.Count <= 60)
                {
                    departmentData[department].Patients.Add(patient);

                    if (!doctorData.ContainsKey(doctor))
                    {
                        doctorData[doctor] = new List<Patient>();
                    }
                    doctorData[doctor].Add(patient);
                }


                line = Console.ReadLine().Split();
            }
        }

        private static void RecieveOutputLinesAndPrint(Dictionary<string, Department> departmentData, Dictionary<string, List<Patient>> doctorData)
        {
            var outputInfo = Console.ReadLine().Split();

            while (outputInfo[0] != "End")
            {
                if (outputInfo.Length == 1)
                {
                    PrintTheDepartmentInfo(departmentData, outputInfo);
                }
                else if (Int32.TryParse(outputInfo[1], out int room))
                {
                    PrintTheRoomInformation(departmentData, outputInfo);
                }
                else
                {
                    PrintTheDoctorInformation(doctorData, outputInfo);
                }
                outputInfo = Console.ReadLine().Split();
            }
        }

        private static void PrintTheDoctorInformation(Dictionary<string, List<Patient>> doctorData, string[] outputInfo)
        {
            var doctor = outputInfo[0]+" "+outputInfo[1];

            foreach (var patient in doctorData[doctor].OrderBy(n=>n.Name))
            {
                Console.WriteLine(patient.Name);
            }
        }

        private static void PrintTheRoomInformation(Dictionary<string, Department> departmentData, string[] outputInfo)
        {
            var department = outputInfo[0];

            var room = int.Parse(outputInfo[1]);

            var orderedNames = new List<string>();


            var patientList = departmentData[department].Patients;

            var index = (room - 1) * 3;

            for (int i = index; i < index+3; i++)
            {
                if (i<patientList.Count)
                {
                    orderedNames.Add(patientList[i].Name);
                }
            }

            foreach (var name in orderedNames.OrderBy(n=>n))
            {
                Console.WriteLine(name);
            }
        }

        private static void PrintTheDepartmentInfo(Dictionary<string, Department> departmentData, string[] outputInfo)
        {
            var department = outputInfo[0];

            foreach (var patient in departmentData[department].Patients)
            {
                Console.WriteLine(patient.Name);
            }
        }
    }
}
