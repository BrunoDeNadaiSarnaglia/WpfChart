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
        int maxNumberPoints = 5;
        LinkedList<KeyValuePair<double, double>> values = new LinkedList<KeyValuePair<double, double>>();
        public void AddPoint(double x, double y)
        {
            KeyValuePair<double, double> kvp = new KeyValuePair<double, double>(x, y);
            this.values.AddFirst(kvp);
            this.Add(kvp);
            while (this.Count > maxNumberPoints) this.RemoveAt(0);
        }

        public int MaxNumberPoints
        {
            get { return this.maxNumberPoints; }

            set
            {
                this.maxNumberPoints = value;
                this.Clear();
                int i = 0;
                LinkedList<KeyValuePair<double, double>> filter = new LinkedList<KeyValuePair<double, double>>();
                foreach (KeyValuePair<double, double> kvp in this.values)
                {
                    if (i++ == this.maxNumberPoints) break;
                    filter.AddFirst(kvp);
                }
                foreach (KeyValuePair<double, double> kvp in filter)
                {
                    this.Add(kvp);
                }
            }
        }
    }
}
