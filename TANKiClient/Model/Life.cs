using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANKiClient.Model
{
    class Life : GameObject
    {
        //Class variables
        public static Image img_health;
        public Life(int x_cordinate, int y_cordinate)
        {
            this.image = Life.img_health;
            this.type = Type.LIFE;
        }
        public static void LoadGraphics()
        {
            img_health = (Image)Properties.Resources.H;
        }
    }
}
