using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Windows.Forms;
using DemoGraphApp.Models;

namespace DemoGraphApp
{
    public partial class GraphViewerControl : UserControl
    {
        private Dictionary<string, SignalGraphWrapper> _graphData = new Dictionary<string, SignalGraphWrapper>();
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp;
                cp = base.CreateParams;
                cp.Style &= ~0x04000000; //WS_CLIPSIBLINGS
                cp.Style &= ~0x02000000; //WS_CLIPCHILDREN
                return cp;
            }
        }
        public GraphViewerControl()
        {
            InitializeComponent();
            Resize += (sender, args) => ((Control)sender).Refresh();
            // ResizeRedraw = true;
            //10ms, 100ms, 1000ms, 3s, 30s
            var periods = new List<DropDownDto<float>>
            {
                new DropDownDto<float>(0.01f, "10ms"),
                new DropDownDto<float>(0.1f, "100ms"),
                new DropDownDto<float>(1, "1s"),
                new DropDownDto<float>(3, "3s"),
                new DropDownDto<float>(30, "30s")
            };

            //100 Hz, 200 Hz, 1kHz, 2kHz
            var frequencies = new List<DropDownDto<float>>
            {
                new DropDownDto<float>(100, "100Hz"),
                new DropDownDto<float>(130, "130Hz"),
                new DropDownDto<float>(200, "200Hz"),
                new DropDownDto<float>(1000, "1kHz"),
                new DropDownDto<float>(2000, "2kHz")
            };
            this.cbxPeriod.DataSource = periods;
            cbxPeriod.DisplayMember = "Display";
            cbxPeriod.ValueMember = "Value";
            this.cbxFrequency.DataSource = frequencies;
            cbxFrequency.DisplayMember = "Display";
            cbxFrequency.ValueMember = "Value";
        }
        /// <summary>
        /// Return Id of Component
        /// </summary>
        /// <param name="data"></param>
        /// <param name="label"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public string Add(float[] data, string label,  Color color)
        {
            var id = Guid.NewGuid().ToString("N");
            _graphData[id] = new SignalGraphWrapper();
            var button = new Button();
            button.Name = id;
            button.Text = (graphPanel.Controls.Count + 1) + "";
            button.Width = 40;
            button.Anchor = AnchorStyles.Left | AnchorStyles.Top;
            button.MouseDown += Button_MouseClick;
            button.MouseMove += Button_MouseMove;
            button.MouseUp += Button_MouseUp;
            var signalGraph = new SignalGraph(data, (float)cbxPeriod.SelectedValue, (float)cbxFrequency.SelectedValue,
                label,
                new Pen(color,2));
            _graphData[id].SignalGraph = signalGraph;
            _graphData[id].Button = button;
            signalGraph.Width = graphPanel.Width;
            signalGraph.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            var y = (graphPanel.Controls.Count) * signalGraph.Height;
            signalGraph.Top = y;
            button.Top = y;
            buttonPanel.Controls.Add(button);
            graphPanel.Controls.Add(signalGraph);
            return id;
        }
        public bool Remove(string id)
        {
            if (!_graphData.ContainsKey(id))
            {
                return false;
            }
            graphPanel.Controls.Remove(_graphData[id].SignalGraph);
            buttonPanel.Controls.Remove(_graphData[id].Button);
            return true;
        }

        private void Button_MouseUp(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            var wrapper = _graphData[button.Name];
            wrapper.IsDragging = false;
        }

        private void Button_MouseMove(object sender, MouseEventArgs e)
        {
            var wrapper = _graphData.Values.FirstOrDefault(p => p.IsDragging);
            if (wrapper != null && wrapper.IsDragging)
            {
               
                wrapper.Button.Top += (Cursor.Position.Y - curPosY);
                if (wrapper.Button.Top < 0)
                {
                    wrapper.Button.Top = 0;
                }
                if ((wrapper.Button.Top + wrapper.Button.Height) > buttonPanel.Height)
                {
                    wrapper.Button.Top = buttonPanel.Height - wrapper.Button.Height;
                }
                SuspendLayout();
                wrapper.SignalGraph.BringToFront();
                wrapper.Button.BringToFront();
                ResumeLayout();
                wrapper.SignalGraph.Top = wrapper.Button.Top;
                curPosY = Cursor.Position.Y;
            }
        }

        int curPosY;
        private void Button_MouseClick(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            var wrapper = _graphData[button.Name];
            wrapper.IsDragging = true;
            curPosY = Cursor.Position.Y;
                SuspendLayout();
            wrapper.SignalGraph.BringToFront();
            wrapper.Button.BringToFront();
                ResumeLayout();
        }

        private void cbxPeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var valuePair in _graphData)
            {
                valuePair.Value.SignalGraph.SetPeriod((float)cbxPeriod.SelectedValue);
                valuePair.Value.SignalGraph.Refresh();
            }
        }

        private void cbxFrequency_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var valuePair in _graphData)
            {
                valuePair.Value.SignalGraph.SetFrequency((float)cbxFrequency.SelectedValue);
                valuePair.Value.SignalGraph.Refresh();
            }
        }
    }
}