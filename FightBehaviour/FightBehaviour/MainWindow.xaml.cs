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
using System.Windows.Threading;

namespace FightBehaviour
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer BattleTimer;
        Player p = new Player("Player", 10, 10);
        Scorpion s = new Scorpion("Scorpion", 10, 10);

        public MainWindow()
        {
            InitializeComponent();
            BattleTimer.Interval = new TimeSpan(0,0,1);
            BattleTimer.Tick
            BattleTimer.Start();

        }
    }
}
