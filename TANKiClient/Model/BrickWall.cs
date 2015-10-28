using System;
using System.Collections;
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

        //Class variables
        private static Hashtable bricks = new Hashtable();
        public static Image damage0 { set; get; }
        public static Image damage1 { set; get; }
        public static Image damage2 { set; get; }
        public static Image damage3 { set; get; }

        public BrickWall(int x_cordination, int y_cordination, int damage)
        {
            this.x_cordinate = x_cordination;
            this.y_cordinate = y_cordination;
            this.damage = damage;
            switch (damage)
            {
                case 0:
                    this.image = BrickWall.damage0;
                    break;
                case 1:
                    this.image = BrickWall.damage1;
                    break;
                case 2:
                    this.image = BrickWall.damage2;
                    break;
                case 3:
                    this.image = BrickWall.damage3;
                    break;
                default:
                    this.image = null;
                    this.type = Type.FLOOR;
                    break;
            }
            this.isVisible = true;
            this.type = Type.BRICK;
        }

        public static void LoadGraphics() {
            damage0 = (Image)Properties.Resources.B0;
            damage1 = (Image)Properties.Resources.B1;
            damage2 = (Image)Properties.Resources.B2;
            damage3 = (Image)Properties.Resources.B3;
        }

        public void Update(int damage) {
            this.damage = damage;
            switch (damage)
            {
                case 0:
                    this.image = BrickWall.damage0;
                    break;
                case 1:
                    this.image = BrickWall.damage1;
                    break;
                case 2:
                    this.image = BrickWall.damage2;
                    break;
                default:
                    this.image = null;
                    break;
            }
        }

        public static void AddBrickWall(int x_cordinate, int y_cordinate)
        {
            int num = y_cordinate * 10 + (x_cordinate + 1);
            bricks.Add(num, new BrickWall(x_cordinate, y_cordinate, 0));
        }


    }
}
