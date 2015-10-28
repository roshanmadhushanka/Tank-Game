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
        public static GameObject[,] obj_map { set; get; }

        public Arena(ref Hashtable map)
        {
            obj_map = new GameObject[10, 10];
            this.map = map;
            Arena.arena = this;
            for(int i=0; i<10; i++)
            {
                for(int j=0; j<10; j++)
                {
                    obj_map[i,j] = new Floor(i,j);
                }
            }
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

        public static void AddGameObject(int x_cordinate, int y_cordinate, GameObject obj)
        {
            obj_map[y_cordinate, x_cordinate] = obj;
        }

        public static void UpdateArena()
        {
            for(int i=0; i<10; i++)
            {
                for(int j=0; j<10; j++)
                {
                   // if(obj_map[i,j].GetType() != typeof(StoneWall) || obj_map[i, j].GetType() != typeof(Water))
                  //  {
                     //   Arena.arena.UpdateArena(j, i, Floor.img_floor);
                        
                    //}
                    Arena.arena.UpdateArena(j, i, obj_map[i, j].image);
                }
            }
        }
    }
}
