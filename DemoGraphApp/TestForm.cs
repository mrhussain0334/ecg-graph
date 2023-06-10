using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoGraphApp
{
    public partial class TestForm : Form
    {
        protected override CreateParams CreateParams

        {

            get

            {

                CreateParams cp = base.CreateParams;

                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT

                return cp;

            }

        }
        public TestForm()
        {
            InitializeComponent();
        }

        private void btnDraw_Click(object sender, EventArgs e)
        {
            panel1.CreateGraphics().DrawLine(new Pen(Color.Red,3),new Point(0,0), new Point(100,100));
            panel2.CreateGraphics().DrawLine(new Pen(Color.Red,3),new Point(0,0), new Point(100,100));

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            panel1.CreateGraphics().Clear(Color.White);
            panel2.CreateGraphics().Clear(Color.White);
        }
    }
}
