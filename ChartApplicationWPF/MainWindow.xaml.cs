using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ChartApplicationWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double x = 0;
        double y = 0;
        Points points = new Points();
        public MainWindow()
        {
            InitializeComponent();
            var line = new LineSeries();
            line.SetBinding(LineSeries.ItemsSourceProperty, new Binding());
            line.DependentValueBinding = new Binding("Value");
            line.IndependentValueBinding = new Binding("Key");
            line.DataContext = points;
            Chart.Series.Add(line);
            Timer timer = new Timer(1000);
            timer.Enabled = true;
            timer.Elapsed += this.OnTimer; 
        }

        private void OnTimer(object asdsa, EventArgs ard){
            x += 10;
            y += 10;
            this.Dispatcher.Invoke((Action)(() =>
            {
                points.AddPoint(x, y);
                if(x == 200)    points.MaxNumberPoints = 10;
            }));        
        }


    }
}
