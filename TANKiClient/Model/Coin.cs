using System;
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

        public Coin(int x_cordinate, int y_cordinate)
        {
            this.image = Coin.img_coin;
            this.type = Type.COIN;
        }
        public static void LoadGraphics()
        {
            img_coin = (Image)Properties.Resources.C;
        }
    }
}
