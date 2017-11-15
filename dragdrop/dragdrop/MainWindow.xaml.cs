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
using FileHelpers;

namespace dragdrop
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        FrameworkElement source = null;
        bool captured = false;
        double xShape, yShape, xCanvas, yCanvas;
        List<Shape> shapesList = new List<Shape>();
        FilesSave fSave = new FilesSave("DragDropData.csv");

        public MainWindow()
        {
            InitializeComponent();

            if (fSave.ReadCSVFile(shapesList))
            {
                IEnumerable<FrameworkElement> elements = canvas.Children.OfType<FrameworkElement>();

                using (var e1 = elements.GetEnumerator())
                using (var e2 = shapesList.GetEnumerator())
                {
                    while (e1.MoveNext() && e2.MoveNext())
                    {
                        var item1 = e1.Current;
                        var item2 = e2.Current;

                        Canvas.SetLeft(item1, item2.PosX);
                        Canvas.SetTop(item1, item2.PosY);
                    }
                }
            }
        }

        private void shape_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            source = (FrameworkElement)sender;
            Mouse.Capture(source);
            captured = true;
            xShape = Canvas.GetLeft(source);
            yShape = Canvas.GetTop(source);
            xCanvas = e.GetPosition(canvas).X;
            yCanvas = e.GetPosition(canvas).Y;

            //writeData.Content = source.Name;
        }

        private void writeData_Click(object sender, RoutedEventArgs e)
        {
            shapesList = new List<Shape>();
            IEnumerable <FrameworkElement> elements = canvas.Children.OfType<FrameworkElement>();

            foreach (var elem in elements)
            {
                Shape shape = new Shape(Canvas.GetLeft(elem), Canvas.GetTop(elem));
                shapesList.Add(shape);
            }

            fSave.WriteCSVFile(shapesList);
        }

        private void shape_MouseMove(object sender, MouseEventArgs e)
        {
            if (captured)
            {
                double x = e.GetPosition(canvas).X;
                double y = e.GetPosition(canvas).Y;
                xShape += x - xCanvas;
                Canvas.SetLeft(source, xShape);
                xCanvas = x;
                yShape += y - yCanvas;
                Canvas.SetTop(source, yShape);
                yCanvas = y;
            }
        }

        private void shape_MouseLeftButtonUp(object sender, MouseEventArgs e)
        {
            Mouse.Capture(null);
            /*if (existShape(source.Name) == false)
            {
                Shape shape = new Shape(source.Name, xShape, yShape);
                shapesList.Add(shape);
            }*/

            captured = false;
        }

        /*private bool existShape(string Name)
        {
            foreach (Shape data in shapesList)
            {
                if (data.Name == Name)
                {
                    data.PosX = xShape;
                    data.PosY = yShape;
                    return true;
                }
            }

            return false;
        }*/


    }
}
