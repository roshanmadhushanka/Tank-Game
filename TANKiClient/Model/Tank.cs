using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TANKiClient.Model
{
    public class Tank : GameObject
    {
        //Object variables
        public string name { set; get; }
        public int direction { set; get; }
        public int shot { set; get; }
        public int health { set; get; }
        public int coins { set; get; }
        public int points { set; get; }

        //Class variables
        public static Image tank1 { set; get; }
        public static Image tank2 { set; get; }
        public static Image tank3 { set; get; }
        public static Image tank4 { set; get; }
        public static Image tank5 { set; get; }

        private Tank()
        {

        }

        private Tank(string name, Image image)
        {
            this.name = name;
            this.image = image;
            this.isVisible = false;
        }

        private Tank(string name, int x_cordination, int y_direction, int shot, int health, int coins, int points)
        {
            this.name = name;
            this.x_cordinate = x_cordination;
            this.y_cordinate = y_cordinate;
            this.shot = shot;
            this.health = health;
            this.coins = coins;
            this.points = points;
        }

        public static void LoadGraphics()
        {

        }
    }
}
