using System;
using System.Collections.Generic;

namespace Domain
{
    public class Vendor:Employee
    {
        public string VendorId { get; set; }
        public List<ConsultantVendor> ConsultantsVendors { get; set; }
    }
}
