using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANKiClient.Model
{
    public enum Type
    {
        FLOOR = 0,
        BRICK = 1,
        COIN = 2,
        LIFE = 3,
        STONE = 4,
        TANK = 5,
        WATER = 6

    }
    public class GameObject
    {
        public int x_cordinate { set; get; }
        public int y_cordinate { set; get; }
        public bool isVisible { set; get; }
        public Image image { set; get; }
        //public static Arena arena { set; get; }
        public Type type { set; get; }
        public static GameObject[] Parser(String str)
        {
            return null;
        }

        public static void LoadGraphic()
        {
            //Load all the graphics from each class
            BrickWall.LoadGraphics();
            Coin.LoadGraphics();
            Floor.LoadGraphics();
            Life.LoadGraphics();
            StoneWall.LoadGraphics();
            Tank.LoadGraphics();
            Water.LoadGraphics();
        }
    }
}
