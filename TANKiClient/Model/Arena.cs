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
        public static int size = 10;
        public static GameObject[,] obj_map { set; get; }

        public Arena(ref Hashtable map)
        {
            //Get the hashed pictureboxes by reference
            obj_map = new GameObject[Arena.size, Arena.size];
            this.map = map;
            Arena.arena = this;
            for(int i=0; i< Arena.size; i++)
            {
                for(int j=0; j< Arena.size; j++)
                {
                    obj_map[i,j] = new Floor(i,j);
                }
            }
        }

        public int getArenaSize()
        {
            return size;
        }

        public void UpdateArena(int index, Image image)
        {
            PictureBox tmp = (PictureBox)map[index];
            tmp.Image = image;
        }

        public void UpdateArena(int x_cordinate, int y_cordinate, Image image)
        {
            //Update Arena according to the position
            int num = y_cordinate * Arena.size + (x_cordinate + 1);
            PictureBox tmp = (PictureBox)map[num];
            tmp.Image = image;
        }

        public static void AddGameObject(int x_cordinate, int y_cordinate, GameObject obj)
        {
            //Adding game objects to the arena
            obj_map[y_cordinate, x_cordinate] = obj;
        }

        public static GameObject GetGameObject(int x_cordinate, int y_cordinate)
        {
            return obj_map[y_cordinate, x_cordinate];
        }

        public static void AddGameObjectRef(int x_cordinate, int y_cordinate,ref GameObject obj)
        {
            obj_map[y_cordinate, x_cordinate] = obj;
        }

        public static void UpdateArena()
        {
            //Render Arena
            for(int i=0; i<Arena.size; i++)
            {
                for(int j=0; j< Arena.size; j++)
                {
                    Arena.arena.UpdateArena(j, i, obj_map[i, j].image);
                }
            }
        }

        public static void ClearArena()
        {
            for (int i = 0; i < Arena.size; i++)
            {
                for (int j = 0; j < Arena.size; j++)
                {
                    Arena.AddGameObject(i, j, new Floor(i,j));
                }
            }
        }
    }
}
