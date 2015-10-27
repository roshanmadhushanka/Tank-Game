using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TANKiClient.GUI
{
    abstract class Graphics
    {
        //Load images for game
        public static Image tank1 { set; get; }
        public static Image tank2 { set; get; }
        public static Image tank3 { set; get; }
        public static Image tank4 { set; get; }
        public static Image tank5 { set; get; }
        public static Image brick0 { set; get; }
        public static Image brick1 { set; get; }
        public static Image brick2 { set; get; }
        public static Image brick3 { set; get; }
        public static Image stone { set; get; }
        public static Image health { set; get; }
        public static Image coins { set; get; }

        public static void LoadGraphics()
        {
            //Load graphics from source
        }
    }
}
