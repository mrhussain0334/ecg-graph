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
        List<string> list = new List<string>();
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var data = JsonConvert.DeserializeObject<float[]>(File.ReadAllText("ecgSampleData.json"));
            data = data.Where(p => p <= 1000).ToArray();
           var id = graphViewer.Add(data,"ECG", Color.Red);
            list.Add(id);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                graphViewer.Remove(list.LastOrDefault());
                list.Remove(list.LastOrDefault());
            }
            catch (Exception)
            {

            }
        }
    }
}
