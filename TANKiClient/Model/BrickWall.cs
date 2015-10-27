using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANKiClient.Model
{
    class BrickWall :GameObject
    {
        //Object variables
        public int damage { set; get; }
        public Image image { set; get; }

        //Class variables
        public static Image dmage0 { set; get; }
        public static Image dmage1 { set; get; }
        public static Image dmage2 { set; get; }

        private BrickWall(int x_cordination, int y_cordination, int damage)
        {
            this.x_cordinate = x_cordination;
            this.y_cordinate = y_cordination;
            this.damage = damage;
        }

        public static void LoadGraphics() {

        }

        public void Update(int damage) {
            this.damage = damage;
            switch (damage)
            {
                case 0:
                    this.image = BrickWall.dmage0;
                    break;
                case 1:
                    this.image = BrickWall.dmage1;
                    break;
                case 2:
                    this.image = BrickWall.dmage2;
                    break;
                default:
                    this.image = Floor.image;
                    break;
            }
        }


    }
}
