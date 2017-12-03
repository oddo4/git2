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

            List<Classes.Person> listContact = new List<Classes.Person>();

            listContact.Add(new Classes.Person() { ProfilePhoto = ImageSource.FromFile("defaultavatar.jpg"), FirstName = "Jan", LastName = "Novák" });

            listViewContacts.ItemsSource = listContact;
            
        }

        private void SelectedProfile(object sender, ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new Profile(e.Item as Classes.Person));
            listViewContacts.SelectedItem = null;
        }
    }
}
