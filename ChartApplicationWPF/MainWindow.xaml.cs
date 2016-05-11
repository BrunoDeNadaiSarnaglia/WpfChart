using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public MainWindow()
        {
            InitializeComponent();
            var line = new LineSeries();
            ObservableCollection<KeyValuePair<double, double>> values = new ObservableCollection<KeyValuePair<double, double>>();
            values.Add(new KeyValuePair<double, double>(10, 10));
            values.Add(new KeyValuePair<double, double>(20, 40));
            values.Add(new KeyValuePair<double, double>(30, 90));
            values.Add(new KeyValuePair<double, double>(40, 160));
            values.Add(new KeyValuePair<double, double>(50, 250));

            line.SetBinding(LineSeries.ItemsSourceProperty, new Binding());
            line.DataContext = values;
            line.DependentValueBinding = new Binding("Value");
            line.IndependentValueBinding = new Binding("Key");
            line.DataContext = values;
            Chart.Series.Add(line);
        }
    }
}
