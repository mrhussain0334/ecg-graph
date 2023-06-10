using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DemoGraphApp
{
    public partial class SignalGraph : UserControl
    {
        private readonly Pen _pen;
        private float[] _data;
        private readonly Dictionary<string, Tuple<PointF, int>> _dots = new Dictionary<string, Tuple<PointF, int>>();
        private readonly List<PointF> _points = new List<PointF>();
        private float _period;
        private float _frequency;
        private string label;

        private string GetLetter(int a)
        {
            for (int i = 65 + a; i <= 90; i++) //
            {
                // Convert the int to a char to get the actual character behind the ASCII code
                return ((char)i).ToString() + " ";

            }
            return "";
        }
        protected override CreateParams CreateParams

        {

            get

            {

                CreateParams cp = base.CreateParams;

                cp.ExStyle |= 0x00000020; //WS_EX_TRANSPARENT

                return cp;

            }

        }
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {

            //do not allow the background to be painted 

        }
        public SignalGraph(float[] data, float period, float frequency,string label,  Pen pen = null)
        {
            InitializeComponent();
            this.Height = 50;
            this.Paint += GraphBoxOnPaint;
            this.MouseClick += SignalGraph_MouseClick;
            _pen = pen ?? new Pen(Color.Red,3);
            _data = data;
            _period = period;
            _frequency = frequency;
            this.label = label;
        }

        private void SignalGraph_MouseClick(object sender, MouseEventArgs e)
        {
            var closest = _points.Aggregate((x, y) => Math.Abs(x.X - e.X) < Math.Abs(y.X - e.X) ? x : y);
            var index = _points.IndexOf(closest);
            _dots.Add(GetLetter(_dots.Count), new Tuple<PointF, int>(new PointF(e.X, e.Y), index));
            Refresh();
        }

        private void GraphBoxOnPaint(object sender, PaintEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            Draw(e);
        }
        public void Draw(PaintEventArgs e)
        {
            Change();
            e.Graphics.Clear(Color.White);
            if (_points.Count > 1)
            {
                e.Graphics.DrawCurve(_pen,_points.ToArray());
                e.Graphics.DrawString(label, new Font(FontFamily.GenericSansSerif, 5, FontStyle.Regular), new SolidBrush(Color.Green),
                        new PointF(_points.Last().X + 5, UsableHeight()));
            }
            if (_dots.Count > 0)
            {
                foreach (var item in _dots)
                {
                    var val = item.Value;
                    if (val.Item2 >= _points.Count)
                    {
                        continue;
                    }
                    var point = _points[val.Item2];
                    e.Graphics.DrawLine(new Pen(Color.Green, 1), new PointF(point.X,val.Item1.Y), new PointF(point.X, point.Y));
                    e.Graphics.DrawString(item.Key, new Font(FontFamily.GenericSansSerif, 5, FontStyle.Regular), new SolidBrush(Color.Green), 
                        new PointF(point.X, val.Item1.Y));
                }
            }
        }

        private float UsableHeight()
        {
                var height = this.Height * 0.5f;
            return height;
        }
        public void SetPeriod(float period)
        {
            _period = period;
        }

        public void SetFrequency(float frequency)
        {
            _frequency = frequency;
        }
        private void Change()
        {
            float totalValueToTake = _period * _frequency;
            long max = (long)Math.Round(Math.Min(_data.Length, totalValueToTake));
            float pointPerVal = this.Width * 0.5f / max;
            _points.Clear();
            var height = this.UsableHeight();
            var maxVal = 1000;
            
            for (var i = 0; i < max; i++)
            {
                var y = (_data[i] / maxVal) * height;
                y = height - y;
                _points.Add(new PointF(pointPerVal * (i + 1),y));
            }
        }
        
    }
}