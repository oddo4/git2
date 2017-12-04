using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace ContactsApp.Classes
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public List<string> PhoneList = new List<string>();
        public List<string> EmailList = new List<string>();
        public ImageSource ProfilePhoto { get; set; }

        public Person()
        {
            
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
