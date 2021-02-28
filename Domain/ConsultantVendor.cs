using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class ConsultantVendor
    {
        public string ConsultantId { get; set; }
        public Consultant Consultant { get; set; }
        public string VendorId { get; set; }
        public Vendor Vendor { get; set; }

    }
}
