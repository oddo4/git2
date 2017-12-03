using ImageCircle.Forms.Plugin.Abstractions;
using System;
using System.Collections.Generic;
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
        public Profile()
        {
            InitializeComponent();
        }

        public Profile(Classes.Person person)
        {
            InitializeComponent();
            //person.PhoneList.Add(new Classes.PhoneNumber() { PNumber = "123456789" });
            //person.PhoneList.Add(new Classes.PhoneNumber() { PNumber = "123456789" });
            //person.EmailList.Add("novak@example.com");
            cirImgProfilePhoto.Source = person.ProfilePhoto;
            labelFullName.Text = person.GetFullName();
            CreateContactRow(0, person.PhoneList[0]);
            CreateContactRow(1, person.EmailList[0]);
        }

        private void Msg_Tapped(object sender, EventArgs e)
        {
            labelFullName.Text = "haha";
        }

        private void Call_Tapped(object sender, EventArgs e)
        {
            labelFullName.Text = "hahaha";
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

                    Phones.Children.Add(layout);
                    break;
                case 1:
                    CreateMailRow(grid, value);
                    layout.Children.Add(grid);

                    Emails.Children.Add(layout);
                    break;
            }
        }

        private void CreatePhoneRow(Grid grid, string number)
        {
            var frameMsg = new Frame() { BackgroundColor = Color.Transparent, Padding = new Thickness(10, 0, 10, 0), CornerRadius = 0, HasShadow = false };
            var imageMsg = new Image() { Source = "msg.png", HeightRequest = 20, WidthRequest = 20 };
            var imageMsgTap = new TapGestureRecognizer();
            imageMsgTap.Tapped += Msg_Tapped;
            imageMsg.GestureRecognizers.Add(imageMsgTap);
            frameMsg.Content = imageMsg; 

            var frameCall = new Frame() { BackgroundColor = Color.Transparent, Padding = new Thickness(10, 0, 10, 0), CornerRadius = 0, HasShadow = false };
            var imageCall = new Image() { Source = "call.png", HeightRequest = 20, WidthRequest = 20 };
            var imageCallTap = new TapGestureRecognizer();
            imageCallTap.Tapped += Call_Tapped;
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