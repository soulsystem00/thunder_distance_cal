using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thunder_distance_cal
{
    public partial class Form1 : Form
    {
        Stopwatch Stopwatch;
        Thread thread;
        public Form1()
        {
            InitializeComponent();
        }

        void counter()
        {
            while(true)
            {
                TimeSpan ts = Stopwatch.Elapsed;
                double sec = ts.TotalSeconds;
                txt_sec.Text = sec.ToString("F2");
            }
            
        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            
            Stopwatch = new Stopwatch();
            thread = new Thread(counter);
            Stopwatch.Start();
            thread.Start();
        }

        private void btn_end_Click(object sender, EventArgs e)
        {
            thread.Abort();
            Stopwatch.Stop();

            TimeSpan timeSpan = Stopwatch.Elapsed;
            double sec = timeSpan.TotalSeconds;
            txt_sec.Text = sec.ToString("F2");
            double distance = 340 * sec;
            txt_dis.Text = distance.ToString("F2");

        }
    }
}
