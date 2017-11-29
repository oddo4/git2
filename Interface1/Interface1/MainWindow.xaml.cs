using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Interface1
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CsvHelper csvHelper = new CsvHelper();
            JsonHelper jsonHelper = new JsonHelper();

            IFileHelper fileHelper = csvHelper;
            fileHelper = jsonHelper;

            if (true)
            {
                fileHelper = csvHelper;
            }
            else if (false)
            {
                fileHelper = new XmlHelper();
            }
            else
            {
                fileHelper = jsonHelper;
            }

            List<string> data = new List<string>();

            string output = fileHelper.SaveToString(data);
        }
    }
}
