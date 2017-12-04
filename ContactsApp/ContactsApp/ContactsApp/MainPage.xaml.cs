using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ContactsApp
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Classes.Person> listContact = new ObservableCollection<Classes.Person>();
        public MainPage()
        {
            InitializeComponent();
            
            Classes.Person novak = new Classes.Person() { FirstName = "Jan", LastName = "Novák", ProfilePhoto = "defaultavatar.jpg"};
            novak.PhoneList.Add("123456789");
            novak.EmailList.Add("novak@example.com");
            listContact.Add(novak);

            listViewContacts.ItemsSource = listContact;
            
        }

        private async void SelectedProfile(object sender, ItemTappedEventArgs e)
        {
            Profile profile = new Profile(listContact, listContact.IndexOf((Classes.Person)listViewContacts.SelectedItem), e.Item as Classes.Person);
            listViewContacts.SelectedItem = null;

            profile.Disappearing += BackToContacts;

            await Navigation.PushAsync(profile);
        }

        private void BackToContacts(object sender, EventArgs e)
        {
            listViewContacts.ItemsSource = listContact;
            ((Profile)sender).Disappearing -= BackToContacts;
        }

        private void AddContact_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditContact(listContact, 0, new Classes.Person() { ProfilePhoto = "defaultavatar.jpg" }));
        }
    }
}
