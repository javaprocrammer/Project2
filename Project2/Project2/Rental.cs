using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class Rental
    {
        public string MovieNumber { get; set; }
        public string MemberNumber { get; set; }
        public string Checkedout { get; set; }
        public string Returned { get; set; }
        public string ExpectedReturn { get; set; }
        public string RentalCost { get; set; }
    }
}
