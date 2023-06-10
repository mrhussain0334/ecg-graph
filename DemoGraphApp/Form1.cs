using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoGraphApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var data = JsonConvert.DeserializeObject<float[]>(File.ReadAllText("ecgSampleData.json"));
            data = data.Where(p => p <= 1000).ToArray();
            graphViewer.Add(data,Color.Red);
        }
    }
}
