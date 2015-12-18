using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANKiClient.Model
{
    class Coin : GameObject
    {
        //Class variables
        public static Image img_coin { set; get; }
        public int time_out { set; get; }
        public int value { set; get; }

        public Coin(int x_cordinate, int y_cordinate, int time_out, int value)
        {
            this.x_cordinate = x_cordinate;
            this.y_cordinate = y_cordinate;
            this.image = Coin.img_coin;
            this.value = value;
            this.time_out = time_out;
            this.type = Type.COIN;
        }
        public static void LoadGraphics()
        {
            //Loading coin graphics
            img_coin = (Image)Properties.Resources.C;
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
