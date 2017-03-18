using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace linearAlgebra
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Point p;
        Vector v;

        public MainWindow() 
        {
            InitializeComponent();

            p = new Point(canvas, 100, 100);
            v = new Vector(canvas, 10, 10);
            p.draw();
            v.draw();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Right:
                    p.x++;
                    break;
                case Key.Left:
                    p.x--;
                    break;
                case Key.Up:
                    p.y--;
                    break;
                case Key.Down:
                    p.y++;
                    break;

            }

            p.draw();
        }

    }


}
