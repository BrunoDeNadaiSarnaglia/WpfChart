using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
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
            Timer timer = new Timer(5000);
            timer.Enabled = true;
            timer.Elapsed += this.OnTimer; 
        }

        private void OnTimer(object asdsa, EventArgs ard){
            string url = "https://www.random.org/integers/?num=1&min=1&max=6&col=1&base=10&format=plain&rnd=new";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "lamdaskmd";
            
            double y = default(double);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream resStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(resStream))
                    {
                        y = (double)int.Parse(reader.ReadLine());
                    }
                }
            }

            this.Dispatcher.Invoke((Action)(() =>
            {
                points.AddPoint(x++, y);
                if(x == 200)    points.MaxNumberPoints = 10;
            }));        
        }


    }
}
