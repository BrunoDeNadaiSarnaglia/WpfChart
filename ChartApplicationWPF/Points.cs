using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChartApplicationWPF
{
    class Points : ObservableCollection<KeyValuePair<double, double>>
    {
        public void AddPoint(double x, double y)
        {
            this.Add(new KeyValuePair<double, double>(x, y));
        }
    }
}
