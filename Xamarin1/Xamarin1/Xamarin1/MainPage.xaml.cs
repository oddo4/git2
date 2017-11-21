using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Xamarin1
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void buttonSend_Clicked(object sender, EventArgs e)
        {
            List<string> strList = new List<string>();
            

            for (int i = 0; i < entryText.Text.Length; i++)
            {
                if (Char.IsLetter(entryText.Text[i]))
                {
                    if (Char.ToLower(entryText.Text[i]) == 'c' && Char.ToLower(entryText.Text[i + 1]) == 'h')
                    {
                        strList.Add(entryText.Text.Substring(i, 2).ToLower());
                        i++;
                    }
                    else if (Char.IsUpper(entryText.Text[i]))
                    {
                        strList.Add(Char.ToLower(entryText.Text[i]).ToString());
                    }
                    else
                    {
                        strList.Add(entryText.Text[i].ToString());
                    }
                }
            }

            string newStr = string.Join("", strList.ToArray());

            strList.Reverse();

            if (string.Join("", strList.ToArray()) == newStr)
            {
                labelInfo.Text = entryText.Text +" je palindrom.";
            }
            else
            {
                labelInfo.Text = entryText.Text + " není palindrom.";
            }
        }
    }
}
