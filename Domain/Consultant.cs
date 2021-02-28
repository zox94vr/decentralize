using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Consultant:Employee
    {
        public string ConsultantId { get; set; }
        public List<ConsultantVendor> ConsultantsVendors { get; set; }
    }
}
