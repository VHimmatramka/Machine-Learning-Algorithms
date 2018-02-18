using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMeansClustering
{
    public class DataPoint
    {
        public double H1 { get; set; }
        public double H2 { get; set; }
        public double H3 { get; set; }
        public double H4 { get; set; }
        public double H5 { get; set; }
        public double H6 { get; set; }
        public double H7 { get; set; }
        public double H8 { get; set; }
        public double H9 { get; set; }
        public double H10 { get; set; }
       

        public int Cluster { get; set; }
        public DataPoint(double h1, double h2, double h3, double h4, double h5, double h6, double h7, double h8, double h9,double h10)
        {
            H1 = h1;
            H2 = h2;
            H3 = h3;
            H4 = h4;
            H5 = h5;
            H6 = h6;
            H7 = h7;
            H8 = h8;
            H9 = h9;
            H10 = h10;
            
            Cluster = 0;

        }

        public DataPoint()
        {

        }

       
        public override string ToString()
        {

            return string.Format("{{{0},{1},{2},{3},{4},{5},{6},{7},{8},{9}}}", H1.ToString("f" + 0), H2.ToString("f" + 9), H3.ToString("f" + 9), H4.ToString("f" + 9), H5.ToString("f" + 9), H6.ToString("f" + 9), H7.ToString("f" + 9), H8.ToString("f" + 9), H9.ToString("f" + 9), H10.ToString("f" + 9));
        }

        
    }
}
