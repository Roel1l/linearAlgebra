using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace linearAlgebra
{
    class Vector
    {
        private double length;
        public double x;
        public double y;
        public double z;
        public double originX = 0;
        public double originY = 0;

        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

        }

        public void draw()
        {
   
        }

        public void scale(double factor)
        {
            this.x = this.x * factor;
            this.y = this.y * factor;
            this.z = this.z * factor;
        }
    }
}
