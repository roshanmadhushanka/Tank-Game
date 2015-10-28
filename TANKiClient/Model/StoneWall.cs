using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANKiClient.Model
{
    class StoneWall : GameObject
    {
        //Class variables
        public static Image img_stone_wall { set; get; }

        public StoneWall(int x_cordinate, int y_cordinate)
        {
            this.x_cordinate = x_cordinate;
            this.y_cordinate = y_cordinate;
            this.image = StoneWall.img_stone_wall;
            this.isVisible = true;
            this.type = Type.STONE;
        }

        public static void LoadGraphics()
        {
            img_stone_wall = (Image)Properties.Resources.S;
        }
    }
}
