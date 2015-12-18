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
        //
        public int time_out { set; get; }
        public int value { set; get; }
        //Class variables
        public static Image img_health;

        public Life(int x_cordinate, int y_cordinate, int time_out)
        {
            this.x_cordinate = x_cordinate;
            this.y_cordinate = y_cordinate;
            this.image = Life.img_health;
            this.type = Type.LIFE;
            this.time_out = time_out;
            this.value = 20;
        }
        public static void LoadGraphics()
        {
            //Loadin life graphics
            img_health = (Image)Properties.Resources.H;
        }

        public void Update()
        {
            if (time_out > 0)
            {
                time_out -= 1000;
            }
            else
            {
                this.type = Type.FLOOR;
            }
        }
    }
}
