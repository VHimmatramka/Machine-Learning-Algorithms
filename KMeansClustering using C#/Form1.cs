using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace KMeansClustering
{
    public partial class Form1 : Form
    {
        List<DataPoint> _rawDataToCluster = new List<DataPoint>();
        List<DataPoint> _normalizedDataToCluster = new List<DataPoint>();
        List<DataPoint> _clusters = new List<DataPoint>();       
        private int _numberOfClusters = 0;
        private bool success;
        public Form1()
        {
            InitializeComponent();
        }
        private void NormalizeData()
        {                        
                //double H1Sum = 0.0;
                double H2Sum = 0.0;
                double H3Sum = 0.0;
                double H4Sum = 0.0;
                double H5Sum = 0.0;
                double H6Sum = 0.0;
                double H7Sum = 0.0;
                double H8Sum = 0.0;
                double H9Sum = 0.0;
               double H10Sum = 0.0;
                
                foreach (DataPoint dataPoint in _rawDataToCluster)
                {
                  //  H1Sum += dataPoint.H1;
                    H2Sum += dataPoint.H2;
                    H3Sum += dataPoint.H3;
                    H4Sum += dataPoint.H4;
                    H5Sum += dataPoint.H5;
                    H6Sum += dataPoint.H6;
                    H7Sum += dataPoint.H7;
                    H8Sum += dataPoint.H8;
                    H9Sum += dataPoint.H9;
                    H10Sum += dataPoint.H10;
                    
                }
               // double H1Mean = H1Sum / _rawDataToCluster.Count;
                double H2Mean = H2Sum / _rawDataToCluster.Count;
                double H3Mean = H3Sum / _rawDataToCluster.Count;
                double H4Mean = H4Sum / _rawDataToCluster.Count;
                double H5Mean = H5Sum / _rawDataToCluster.Count;
                double H6Mean = H6Sum / _rawDataToCluster.Count;
                double H7Mean = H7Sum / _rawDataToCluster.Count;
                double H8Mean = H8Sum / _rawDataToCluster.Count;
                double H9Mean = H9Sum / _rawDataToCluster.Count;
                double H10Mean = H10Sum / _rawDataToCluster.Count;
                
            
               // double sumH1 = 0.0;
                double sumH2 = 0.0;
                double sumH3 = 0.0;
                double sumH4 = 0.0;
                double sumH5 = 0.0;
                double sumH6 = 0.0;
                double sumH7 = 0.0;
                double sumH8 = 0.0;
                double sumH9 = 0.0;
              double sumH10 = 0.0;
               

                foreach (DataPoint dataPoint in _rawDataToCluster)
                {
                  //  sumH1 += Math.Pow(dataPoint.H1 - H1Mean, 2);
                    sumH2 += Math.Pow(dataPoint.H2 - H2Mean, 2);
                    sumH3 += Math.Pow(dataPoint.H3 - H3Mean, 2);
                    sumH4 += Math.Pow(dataPoint.H4 - H4Mean, 2);
                    sumH5 += Math.Pow(dataPoint.H5 - H5Mean, 2);
                    sumH6 += Math.Pow(dataPoint.H6 - H6Mean, 2);
                    sumH7 += Math.Pow(dataPoint.H7 - H7Mean, 2);
                    sumH8 += Math.Pow(dataPoint.H8 - H8Mean, 2);
                   sumH10 += Math.Pow(dataPoint.H10 - H10Mean, 2);
                   
                   

                }
               // double H1SD = sumH1 / _rawDataToCluster.Count;
                double H2SD = sumH2 / _rawDataToCluster.Count;
                double H3SD = sumH3 / _rawDataToCluster.Count;
                double H4SD = sumH4 / _rawDataToCluster.Count;
                double H5SD = sumH5 / _rawDataToCluster.Count;
                double H6SD = sumH6 / _rawDataToCluster.Count;
                double H7SD = sumH7 / _rawDataToCluster.Count;
                double H8SD = sumH8 / _rawDataToCluster.Count;
                double H9SD = sumH9 / _rawDataToCluster.Count;
              double H10SD = sumH10 / _rawDataToCluster.Count;
                
                
                foreach (DataPoint dataPoint in _rawDataToCluster)
                {
                    _normalizedDataToCluster.Add(new DataPoint()
                    {
                       // H1 = (dataPoint.H1 - H1Mean)/H1SD,
                        H2 = (dataPoint.H2 - H2Mean) / H2SD,
                        H3 = (dataPoint.H3 - H3Mean) / H3SD,
                        H4 = (dataPoint.H4 - H4Mean) / H4SD,
                        H5 = (dataPoint.H5 - H5Mean) / H5SD,
                        H6 = (dataPoint.H6 - H6Mean) / H6SD,
                        H7 = (dataPoint.H7 - H7Mean) / H7SD,
                        H8 = (dataPoint.H8 - H8Mean) / H8SD,
                        H9 = (dataPoint.H9 - H9Mean) / H9SD,
                   H10 = (dataPoint.H10 - H10Mean) / H10SD,
                        
                    }
                        );
                }
                MessageBox.Show("Normalisation Done!!", "Normalisation Done"); 
        }

        private void InitilizeRawData()
        {
            
            if (_rawDataToCluster.Count == 0)
            {
                string lstRawDataItem = string.Empty;
                for (int i = 0; i < lstRawData.Items.Count; i++)
                {
                    DataPoint dp = new DataPoint();
                    lstRawDataItem = lstRawData.Items[i].ToString();
                    lstRawDataItem = lstRawDataItem.Replace("{", "");
                    lstRawDataItem = lstRawDataItem.Replace("}", "");
                    string[] data = lstRawDataItem.Split(',');
                    dp.H1 = double.Parse(data[0]);
                    dp.H2 = double.Parse(data[1]);
                    dp.H3 = double.Parse(data[2]);
                    dp.H4 = double.Parse(data[3]);
                    dp.H5 = double.Parse(data[4]);
                    dp.H6 = double.Parse(data[5]);
                    dp.H7 = double.Parse(data[6]);
                    dp.H8 = double.Parse(data[7]);
                    dp.H9 = double.Parse(data[8]);
                    dp.H10 = double.Parse(data[9]);
                    
                    _rawDataToCluster.Add(dp);
                }
            }
            }
           
        
        
        private void ShowData(List<DataPoint> data, int decimals, TextBox outPut)
        {
            
            foreach (DataPoint dp in data)
            {
                outPut.Text += dp.ToString() + Environment.NewLine;
            }                 
        }

        private void InitializeCentroids()
        {        
            Random random = new Random(_numberOfClusters);
            for (int i = 0; i < _numberOfClusters; ++i)
            {
                _normalizedDataToCluster[i].Cluster = _rawDataToCluster[i].Cluster = i;
            }
            for (int i = _numberOfClusters; i < _normalizedDataToCluster.Count; i++)
            {
                _normalizedDataToCluster[i].Cluster = _rawDataToCluster[i].Cluster = random.Next(0, _numberOfClusters);
            }
        }
            
        private bool UpdateDataPointMeans()
        {
            if (EmptyCluster(_normalizedDataToCluster)) return false;

            var groupToComputeMeans = _normalizedDataToCluster.GroupBy(s => s.Cluster).OrderBy(s => s.Key);
            int clusterIndex = 0;
           double height1 = 0.0;
            double height2 = 0.0;
            double height3 = 0.0;
            double height4 = 0.0;
            double height5 = 0.0;
            double height6 = 0.0;
            double height7 = 0.0;
            double height8 = 0.0;
            double height9 = 0.0;
           double height10 = 0.0;
            
            
            foreach (var item in groupToComputeMeans)
            {
                foreach (var value in item)
                {
                   height1 += value.H1;
                    height2 += value.H2;
                    height3 += value.H3;
                    height4 += value.H4;
                    height5 += value.H5;
                    height6 += value.H6;
                    height7 += value.H7;
                    height8 += value.H8;
                    height9 += value.H9;
                   height10 += value.H10;
                   
                    
                }
               _clusters[clusterIndex].H1 = height1 / item.Count();
                _clusters[clusterIndex].H2 = height2 / item.Count();
                _clusters[clusterIndex].H3 = height3 / item.Count();
                _clusters[clusterIndex].H4 = height4 / item.Count();
                _clusters[clusterIndex].H5 = height5 / item.Count();
                _clusters[clusterIndex].H6 = height6 / item.Count();
                _clusters[clusterIndex].H7 = height7 / item.Count();
                _clusters[clusterIndex].H8 = height8 / item.Count();
                _clusters[clusterIndex].H9 = height9 / item.Count();
              _clusters[clusterIndex].H10 = height10 / item.Count();
               
                clusterIndex++;
                height1 = 0.0;
                height2 = 0.0;
                height3 = 0.0;
                height4 = 0.0;
                height5 = 0.0;
                height6 = 0.0;
                height7 = 0.0;
                height8 = 0.0;
                height9 = 0.0;
            height10 = 0.0;
               
                
            }
            return true;
        }

        private bool EmptyCluster(List<DataPoint> data)
        {
            var emptyCluster =
                data.GroupBy(s => s.Cluster).OrderBy(s => s.Key).Select(g => new { Cluster = g.Key, Count = g.Count() });

            foreach (var item in emptyCluster)
            {
                if (item.Count == 0)
                {
                    return true;
                }
            }
            return false;
        }

        private bool UpdateClusterMembership()
        {
            bool changed = false;

            double[] distances = new double[_numberOfClusters];

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _normalizedDataToCluster.Count; ++i)
            {
                sb.AppendLine(" ");
                for (int k = 0; k < _numberOfClusters; ++k)
                    distances[k] = ElucidanDistance(_normalizedDataToCluster[i], _clusters[k]);

                int newClusterId = MinIndex(distances);
                if (newClusterId != _normalizedDataToCluster[i].Cluster)
                {
                    changed = true;
                    _normalizedDataToCluster[i].Cluster = _rawDataToCluster[i].Cluster = newClusterId;
                    //sb.AppendLine("Data Point >> Height: " + _rawDataToCluster[i].Height + ", Weight: " +
                    //              _rawDataToCluster[i].Weight + " moved to Cluster # " + newClusterId);
                }
                else
                {
                    sb.AppendLine("No change.");
                }
                sb.AppendLine(" ");
                
                sb.AppendLine("------------------------------");
                //txtIterations.Text += sb.ToString();

            }
            if (changed == false)
                return false;
            if (EmptyCluster(_normalizedDataToCluster)) return false;
            return true;
        }

        private double ElucidanDistance(DataPoint dataPoint, DataPoint mean)
        {
            double _diffs = 0.0;
            _diffs = Math.Pow(dataPoint.H1 - mean.H1, 2);
            _diffs = Math.Pow(dataPoint.H2 - mean.H2, 2);
            _diffs = Math.Pow(dataPoint.H3 - mean.H3, 2);
            _diffs = Math.Pow(dataPoint.H4 - mean.H4, 2);
            _diffs = Math.Pow(dataPoint.H5 - mean.H5, 2);
            _diffs = Math.Pow(dataPoint.H6 - mean.H6, 2);
            _diffs = Math.Pow(dataPoint.H7 - mean.H7, 2);
            _diffs = Math.Pow(dataPoint.H8 - mean.H8, 2);
            _diffs = Math.Pow(dataPoint.H9 - mean.H9, 2);
          //  _diffs = Math.Pow(dataPoint.H10 - mean.H10, 2);
            
            return Math.Sqrt(_diffs);
        }

        private int MinIndex(double[] distances)
        {
            int _indexOfMin = 0;
            double _smallDist = distances[0];
            for (int k = 0; k < distances.Length; ++k)
            {
                if (distances[k] < _smallDist)
                {
                    _smallDist = distances[k];
                    _indexOfMin = k;
                }
            }
            return _indexOfMin;
        }

        public void Cluster()
        {
            bool _changed = true;
            bool _success = true;
            InitializeCentroids();

            //int maxIteration = _normalizedDataToCluster.Count * 10;
            int maxIteration = _normalizedDataToCluster.Count;
            int _threshold = 0;
            while (success == true && _changed == true && _threshold < maxIteration)
            {
                ++_threshold;
                _success = UpdateDataPointMeans();
                _changed = UpdateClusterMembership();
            }
        }

       

        //private void btnNormalize_Click(object sender, EventArgs e)
        //{
        //InitilizeRawData();
        //NormalizeData();
        //ShowData(_normalizedDataToCluster, 1, txtNormalized);

        //}
       public static int cz = 0;
       public static int co = 0;
       public static int c1 = 0;
       public static int[] c = new int[100];
      
        private void btnCluster_Click(object sender, EventArgs e)
        {
            InitilizeRawData();
            NormalizeData();
            ShowData(_normalizedDataToCluster, 1, txtNormalized);

            InitilizeRawData();
            _numberOfClusters =     int.Parse(txtNumberOfClusters.Text);
            
            //initialize the clusters (Setting indeces)
            for (int i = 0; i < _numberOfClusters; i++)
            {
                _clusters.Add(new DataPoint(){Cluster = i});
            }
            
           Cluster();
            StringBuilder sb = new StringBuilder();
            var group = _rawDataToCluster.GroupBy(s => s.Cluster).OrderBy(s => s.Key);
            foreach (var g in group)
            {                             
                sb.AppendLine("Cluster # " + g.Key + ":");               
                foreach (var value in g)
                {
                    
                    sb.Append(value.ToString());
                    sb.AppendLine();
                    
                }

                sb.AppendLine("------------------------------");
                
                
            }

            
            txtOutput.Text = sb.ToString();
            //for cluster zero
            Int16 cluster_count = Convert.ToInt16(txtNumberOfClusters.Text);

            int Flag = 0;
            foreach (string line in txtOutput.Lines)
            {

                if (line.Contains("------------------------------"))
                {
                    Flag++;

                }
                else if (Flag == 0)
                {
                    if (line.Contains("{11"))
                    {
                        cz++;
                    }
                }
                else if (Flag == 1)
                {
                    if (line.Contains("{12"))
                    {
                        co++;
                    }
                }


            }
            label7.Visible = true;
            float acc_zero = (((float)(cz + co) / (float)lstRawData.Items.Count) * 100f);
            // float acc_zero = (float)(((cz + co) / lstRawData.Items.Count) * 100);
            label7.Text = acc_zero.ToString(); 
           
           
           
        }
        
       
        
    
        private void Form1_Load(object sender, EventArgs e)
        {
            
            label7.Visible = false;
           
        }









        public double H1Sum { get; set; }

      
       
    }
  
}
