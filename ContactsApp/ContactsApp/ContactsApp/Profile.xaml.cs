using ImageCircle.Forms.Plugin.Abstractions;
using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Profile : ContentPage
    {
        Classes.Person Person;
        ObservableCollection<Classes.Person> listContact;
        int collectionID = 0;

        public Profile()
        {
            InitializeComponent();
            
        }

        public Profile(ObservableCollection<Classes.Person> list, int ID, Classes.Person person)
        {
            InitializeComponent();
            Person = person;
            listContact = list;
            collectionID = ID;

            ShowContact();
        }

        private void ShowContact()
        {
            this.Title = Person.GetFullName();
            cirImgProfilePhoto.Source = Person.ProfilePhoto;
            labelFullName.Text = Person.GetFullName();
            foreach (string item in Person.PhoneList)
            {
                CreateContactRow(0, item);
            }
            foreach (string item in Person.EmailList)
            {
                CreateContactRow(1, item);
            }
        }

        /*private void EditContact_Activated(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EditContact(listContact, Person));
        }*/

        private async void EditContact_Clicked(object sender, EventArgs e)
        {
            EditContact editContact = new EditContact(listContact, collectionID, Person);

            editContact.Disappearing += BackToProfile;

            await Navigation.PushAsync(editContact);
        }

        private void BackToProfile(object sender, EventArgs e)
        {
            PhoneList.Children.Clear();
            EmailList.Children.Clear();
            ShowContact();
            ((EditContact)sender).Disappearing -= BackToProfile;
        }

        private void Msg_Tapped(string number)
        {
            
        }

        private void Call_Tapped(string number)
        {

        }

        private void SendMail_Tapped(object sender, EventArgs e)
        {
            labelFullName.Text = "haha haha";
        }

        private void CreateContactRow(int type, string value)
        {
            var layout = new StackLayout() { Padding = new Thickness(0, 10, 0, 10) };

            var grid = new Grid();
            grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Auto) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });
            grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Auto) });

            var frameValue = new Frame() { BackgroundColor = Color.Transparent, Padding = new Thickness(20, 0, 0, 0), CornerRadius = 0, HasShadow = false };
            var labelValue = new Label() { Text = value };
            frameValue.Content = labelValue;

            grid.Children.Add(frameValue, 0, 0);

            switch (type)
            {
                case 0:
                    CreatePhoneRow(grid, value);
                    layout.Children.Add(grid);

                    PhoneList.Children.Add(layout);
                    break;
                case 1:
                    CreateMailRow(grid, value);
                    layout.Children.Add(grid);

                    EmailList.Children.Add(layout);
                    break;
            }
        }

        private void CreatePhoneRow(Grid grid, string number)
        {
            var frameMsg = new Frame() { BackgroundColor = Color.Transparent, Padding = new Thickness(10, 0, 10, 0), CornerRadius = 0, HasShadow = false };
            var imageMsg = new Image() { Source = "msg.png", HeightRequest = 20, WidthRequest = 20 };
            var imageMsgTap = new TapGestureRecognizer();
            imageMsgTap.Tapped += (sender, e) => Msg_Tapped(number);
            imageMsg.GestureRecognizers.Add(imageMsgTap);
            frameMsg.Content = imageMsg; 

            var frameCall = new Frame() { BackgroundColor = Color.Transparent, Padding = new Thickness(10, 0, 10, 0), CornerRadius = 0, HasShadow = false };
            var imageCall = new Image() { Source = "call.png", HeightRequest = 20, WidthRequest = 20 };
            var imageCallTap = new TapGestureRecognizer();
            imageCallTap.Tapped += (sender, e) => Call_Tapped(number);
            imageCall.GestureRecognizers.Add(imageCallTap);
            frameCall.Content = imageCall;

            grid.Children.Add(frameMsg, 2, 0);
            grid.Children.Add(frameCall, 3, 0);
        }
        private void CreateMailRow(Grid grid, string mail)
        {
            var frameSendMail = new Frame() { BackgroundColor = Color.Transparent, Padding = new Thickness(10, 0, 10, 0), CornerRadius = 0, HasShadow = false };
            var imageSendMail = new Image() { Source = "mail.png", HeightRequest = 20, WidthRequest = 20 };
            var imageSendMailTap = new TapGestureRecognizer();
            imageSendMailTap.Tapped += SendMail_Tapped;
            imageSendMail.GestureRecognizers.Add(imageSendMailTap);
            frameSendMail.Content = imageSendMail;

            grid.Children.Add(frameSendMail, 3, 0);
        }
    }
}