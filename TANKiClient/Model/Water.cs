using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANKiClient.Model
{
    class Water : GameObject
    {
        //Class variables
        public static Image img_water { set; get; }

        public Water(int x_cordinate, int y_cordinate)
        {
            this.x_cordinate = x_cordinate;
            this.y_cordinate = y_cordinate;
            this.image = Water.img_water;
            this.isVisible = true;
            this.type = Type.WATER;
        }

        public static void LoadGraphics()
        {
            img_water = (Image)Properties.Resources.W;
        }
    }
}
