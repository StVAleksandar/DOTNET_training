using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    class Employees
    {
        public int employeeID { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string title { get; set; }
        public string titleOfCourtesy { get; set; }
        public DateTime birthDate { get; set; }
        public DateTime hireDate { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string homePhone { get; set; }
        public string extension { get; set; }
        public byte[] photo { get; set; }
        public string notes { get; set; }
        public int reportsTo { get; set; }
        public string photoPath { get; set; }
    }
}
