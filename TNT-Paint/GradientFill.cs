using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TNT_Paint
{
    public class GradientFill
    {
        public enum GradientType
        {
            Linear,
            Radial
        }

        public GradientType Type { get; set; }
        public Color StartColor { get; set; }
        public Color EndColor { get; set; }

        public GradientFill(GradientType type, Color startColor, Color endColor)
        {
            Type = type;
            StartColor = startColor;
            EndColor = endColor;
        }
    }

}
