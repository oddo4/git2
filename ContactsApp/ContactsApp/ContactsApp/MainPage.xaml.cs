using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactsApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            List<Contact> listContact = new List<Contact>();

            for (int i = 0; i < 20; i++)
            {
                listContact.Add(new Contact() { FirstName = "Jan", LastName = "Novák" });
            }

            listViewContacts.ItemsSource = listContact;
            
        }

        private async void Profile_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Profile());
            
        }
    }
}
