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
    public partial class EditContact : ContentPage
    {
        Classes.Person Person;
        ObservableCollection<Classes.Person> listContact;
        bool newContact = false;
        int collectionID = 0;

        public EditContact()
        {
            InitializeComponent();

        }
        public EditContact(ObservableCollection<Classes.Person> list, int ID, Classes.Person person)
        {
            InitializeComponent();
            Person = person;
            listContact = list;
            collectionID = ID;

            if (Person.GetFullName() != " ")
            {
                this.Title = "Edit Contact";
                ToolbarItem delete = new ToolbarItem() { Order = ToolbarItemOrder.Primary, Text = "Delete", Priority = 1 };
                delete.Clicked += DeleteContact_Clicked;
                ToolbarItems.Add(delete);
                ShowContact();
            }
            else
            {
                this.Title = "Add Contact";
                newContact = true;
            }

            cirImgProfilePhoto.Source = Person.ProfilePhoto;
        }

        private void ShowContact()
        {
            cirImgProfilePhoto.Source = Person.ProfilePhoto;
            entryFirstName.Text = Person.FirstName;
            entryLastName.Text = Person.LastName;
            foreach (string item in Person.PhoneList)
            {
                CreateContactRow(0, item);
            }
            foreach (string item in Person.EmailList)
            {
                CreateContactRow(1, item);
            }
        }

        private void DeleteNumber_Tapped(StackLayout number)
        {
            PhoneList.Children.Remove(number);
        }

        private void DeleteEmail_Tapped(StackLayout mail)
        {
            EmailList.Children.Remove(mail);
        }

        private void ChangePhoto_Tapped(object sender, EventArgs e)
        {

        }

        private void AddNumber_Tapped(object sender, EventArgs e)
        {
            CreateContactRow(0, "");
        }

        private void AddEmail_Tapped(object sender, EventArgs e)
        {
            CreateContactRow(1, "");
        }

        private void SaveContact_Clicked(object sender, EventArgs e)
        {
            if (entryFirstName.Text != "" && entryLastName.Text != "")
            {
                Person.FirstName = entryFirstName.Text;
                Person.LastName = entryLastName.Text;
                Person.PhoneList = new List<string>();
                Person.EmailList = new List<string>();

                for (int i = 0; i < PhoneList.Children.Count; i++)
                {
                    StackLayout layout = (StackLayout)PhoneList.Children[i];
                    Grid grid = (Grid)layout.Children[0];
                    Frame frame = (Frame)grid.Children[0];
                    Entry entry = (Entry)frame.Content;

                    Person.PhoneList.Add(entry.Text);
                }

                for (int j = 0; j < EmailList.Children.Count; j++)
                {
                    StackLayout layout = (StackLayout)EmailList.Children[j];
                    Grid grid = (Grid)layout.Children[0];
                    Frame frame = (Frame)grid.Children[0];
                    Entry entry = (Entry)frame.Content;

                    Person.EmailList.Add(entry.Text);
                }

                if (newContact)
                {
                    listContact.Add(Person);

                    listContact = new ObservableCollection<Classes.Person>(from i in listContact orderby i.LastName select i);

                    Navigation.PushAsync(new Profile(listContact, listContact.IndexOf(Person), Person));
                    Navigation.RemovePage(this);
                }
                else
                {
                    Navigation.PopAsync();
                }
            }
        }

        private void DeleteContact_Clicked(object sender, EventArgs e)
        {
            listContact.RemoveAt(collectionID);

            Navigation.PopToRootAsync();
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

            var frameValue = new Frame() { BackgroundColor = Color.Transparent, Padding = new Thickness(20, 0, 0, 0), CornerRadius = 0, HasShadow = false};
            var editorValue = new Entry() { Text = value };
            frameValue.Content = editorValue;

            grid.Children.Add(frameValue, 0, 0);

            switch (type)
            {
                case 0:
                    editorValue.Keyboard = Keyboard.Telephone;
                    editorValue.Placeholder = "Phone Number";
                    frameValue.Content = editorValue;

                    grid.Children.Add(frameValue, 0, 0);

                    CreateDeleteRow(layout, grid, type);
                    layout.Children.Add(grid);

                    PhoneList.Children.Add(layout);
                    break;
                case 1:
                    editorValue.Keyboard = Keyboard.Email;
                    editorValue.Placeholder = "Email Address";
                    frameValue.Content = editorValue;

                    grid.Children.Add(frameValue, 0, 0);

                    CreateDeleteRow(layout, grid, type);
                    layout.Children.Add(grid);

                    EmailList.Children.Add(layout);
                    break;
            }
        }

        private void CreateDeleteRow(StackLayout layout, Grid grid, int type)
        {
            var frameDelete = new Frame() { BackgroundColor = Color.Transparent, Padding = new Thickness(10, 0, 10, 0), CornerRadius = 0, HasShadow = false };
            var imageDelete = new Image() { Source = "remove.png", HeightRequest = 20, WidthRequest = 20 };
            var imageDeleteTap = new TapGestureRecognizer();
            
            switch (type)
            {
                case 0:

                    imageDeleteTap.Tapped += (sender, e) => DeleteNumber_Tapped(layout);
                    break;
                case 1:
                    imageDeleteTap.Tapped += (sender, e) => DeleteEmail_Tapped(layout);
                    break;
            }
            
            imageDelete.GestureRecognizers.Add(imageDeleteTap);
            frameDelete.Content = imageDelete;

            grid.Children.Add(frameDelete, 3, 0);
        }
    }
}