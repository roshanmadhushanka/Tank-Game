using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANKiClient.Model
{
    public class GameObject
    {
        public int x_cordinate { set; get; }
        public int y_cordinate { set; get; }
        public bool isVisible { set; get; }
        public Image image { set; get; }
        public static Arena arena { set; get; }

        public static GameObject[] Parser(String str)
        {
            return null;
        }
    }
}
