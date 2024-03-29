﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANKiClient.Model
{
    class Floor : GameObject
    {
        //Class variables
        public static Image img_floor { set; get; }

        public Floor(int x_cordinate, int y_cordinate)
        {
            this.x_cordinate = x_cordinate;
            this.y_cordinate = y_cordinate;
            this.image = Floor.img_floor;
            this.isVisible = true;
            this.type = Type.FLOOR;
        }
        public static void LoadGraphics()
        {
            //Loading floor graphics
            img_floor = (Image)Properties.Resources.F;
        }
    }
}
