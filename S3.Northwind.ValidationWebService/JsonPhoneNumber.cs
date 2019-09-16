using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3.Northwind.ValidationWebService
{
    public class JsonPhoneNumber
    {
        public bool Valid { get; set; }
        public string Number { get; set; }
        public string Local_format { get; set; }
        public string International_format { get; set; }
        public string Country_prefix { get; set; }
        public string Country_code { get; set; }
        public string Country_name { get; set; }
        public string Location { get; set; }
        public string Carrier { get; set; }
        public string Line_type { get; set; }

        public static explicit operator PhoneNumber(JsonPhoneNumber jsonPhoneNumber)
        {
            return new PhoneNumber() { Valid = jsonPhoneNumber.Valid };
        }
    }
}
