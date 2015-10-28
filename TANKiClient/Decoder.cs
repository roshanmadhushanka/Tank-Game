using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TANKiClient.Model;

namespace TANKiClient
{
    class Decoder
    {
        public static void Decode(string str) {
            string[] lines = Regex.Split(str.Substring(0, str.Length - 1), ":");
            if (lines[0].StartsWith("S"))
            {
                Console.WriteLine(lines[1]); //Name
                Console.WriteLine(lines[2]); //Cordinate
                string[] cord = Regex.Split(lines[2], ",");
                Console.WriteLine(lines[3]); //Direction
                Tank t = new Tank(lines[1], Int32.Parse(cord[0]), Int32.Parse(cord[1]));
                Arena.AddGameObject(t.x_cordinate, t.y_cordinate, t);
            }
            else if (lines[0].StartsWith("I"))
            {
                //Initialize
                string player_name = lines[1];
                //lines[2] - Brick
                string[] bricks = Regex.Split(lines[2], ";");
                for (int i = 0; i < bricks.Length; i++)
                {
                    string[] cords = Regex.Split(bricks[i], ",");
                    BrickWall brick = new BrickWall(Int32.Parse(cords[0]), Int32.Parse(cords[1]), 0);
                    Arena.AddGameObject(brick.x_cordinate, brick.y_cordinate, brick);
                }
                //lines[3] - Stone
                string[] stones = Regex.Split(lines[3], ";");
                for (int i = 0; i < stones.Length; i++)
                {
                    string[] cords = Regex.Split(stones[i], ",");
                    StoneWall stone = new StoneWall(Int32.Parse(cords[0]), Int32.Parse(cords[1]));
                    Arena.AddGameObject(stone.x_cordinate, stone.y_cordinate, stone);
                }
                //lines[4] - Water
                string[] waters = Regex.Split(lines[4], ";");
                for (int i = 0; i < waters.Length; i++)
                {
                    string[] cords = Regex.Split(waters[i], ",");
                    Water water = new Water(Int32.Parse(cords[0]), Int32.Parse(cords[1]));
                    Arena.AddGameObject(water.x_cordinate, water.y_cordinate, water);
                }
            }
            else if (lines[0].StartsWith("G"))
            { 
                for(int x=0; x<10; x++)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        if (Arena.obj_map[x, y].type == Model.Type.TANK || Arena.obj_map[x, y].type == Model.Type.BRICK)
                        {
                            Arena.obj_map[x, y] = new Floor(x, y);
                        }
                    }
                }

                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].StartsWith("G"))
                    {

                    }
                    else if (lines[i].StartsWith("P"))
                    {
                        string[] player = Regex.Split(lines[i], ";");
                        Tank t = new Tank(player[0], Int32.Parse(player[2]));
                        string[] cord = Regex.Split(player[1], ",");
                        t.x_cordinate = Int32.Parse(cord[0]);
                        t.y_cordinate = Int32.Parse(cord[1]);
                        t.shot = Int32.Parse(player[3]);
                        t.health = Int32.Parse(player[4]);
                        t.coins = Int32.Parse(player[5]);
                        t.points = Int32.Parse(player[6]);
                        Arena.AddGameObject(t.x_cordinate, t.y_cordinate, t);
                    }
                    else
                    {
                        string[] walls = Regex.Split(lines[i], ";");
                        for (int j = 0; j < walls.Length; j++)
                        {
                            string[] wall = Regex.Split(walls[j], ",");
                            if(Int32.Parse(wall[2]) != 4)
                            {
                                BrickWall b = new BrickWall(Int32.Parse(wall[0]), Int32.Parse(wall[1]), Int32.Parse(wall[2]));
                                Arena.AddGameObject(b.x_cordinate, b.y_cordinate, b);
                            }
                        }
                    }
                }
            }
            Arena.UpdateArena();
        }

    }
}
