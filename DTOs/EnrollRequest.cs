using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD09.DTOs
{
    public class EnrollRequest
    {
        public string IndexNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Studies { get; set; }
    }
}
