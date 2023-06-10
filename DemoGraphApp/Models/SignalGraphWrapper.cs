using System.Windows.Forms;

namespace DemoGraphApp.Models
{
    public class DropDownDto<T>
    {
        public T Value { get; set; }
        public string Display { get; set; }

        public DropDownDto(T value, string display)
        {
            Value = value;
            Display = display;
        }
    }
    public class SignalGraphWrapper
    {
        public bool IsDragging { get; set; }
        public Button Button { get; set; }
        public SignalGraph SignalGraph { get; set; }
    }
}