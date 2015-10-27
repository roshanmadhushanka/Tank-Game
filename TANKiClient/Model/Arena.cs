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
    public class Arena
    {
        public static Arena arena;
        Hashtable map;

        public Arena(ref Hashtable map)
        {
            this.map = map;
            Arena.arena = this;
        }

        public void UpdateArena(int index, Image image)
        {
            PictureBox tmp = (PictureBox)map[index];
            tmp.Image = image;
        }

        public void UpdateArena(int x_cordinate, int y_cordinate, Image image)
        {
            int num = y_cordinate * 10 + (x_cordinate + 1);
            PictureBox tmp = (PictureBox)map[num];
            tmp.Image = image;
        }


    }
}
