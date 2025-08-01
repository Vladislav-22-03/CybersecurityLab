using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cybersecurity
{ 
    public class LabVariant
    {
        public int Id { get; set; }
        public string AttackType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        public List<Solution> Solutions { get; set; } = new List<Solution>();

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GroupName { get; set; }

        public class Solution
        {
            public string Description { get; set; }
            public decimal Cost { get; set; }
            public int HoursToFix { get; set; }
        }
    }
}
