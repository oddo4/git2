using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp
{
    class Contact
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> PhoneList { get; set; }
        public List<string> EmailList { get; set; }

        public Contact()
        {

        }

        public Contact(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneList.Add("123456789");
            this.EmailList.Add("novak@example.cz");
        }
    }
}
