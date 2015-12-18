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
        public static string current_player_name { set; get; }

       
        //Object variables
        public string name { set; get; }
        public int direction { set; get; }
        public int shot { set; get; }
        public int health { set; get; }
        public int coins { set; get; }
        public int points { set; get; }

        //Class variables
        private static Hashtable tanks = new Hashtable();
        public static Image tank1 { set; get; }
        public static Image tank2 { set; get; }
        public static Image tank3 { set; get; }
        public static Image tank4 { set; get; }
        public static Image tank5 { set; get; }
        public static Image tank11 { set; get; }
        public static Image tank21 { set; get; }
        public static Image tank31 { set; get; }
        public static Image tank41 { set; get; }
        public static Image tank51 { set; get; }
        public static Image tank12 { set; get; }
        public static Image tank22 { set; get; }
        public static Image tank32 { set; get; }
        public static Image tank42 { set; get; }
        public static Image tank52 { set; get; }
        public static Image tank13 { set; get; }
        public static Image tank23 { set; get; }
        public static Image tank33 { set; get; }
        public static Image tank43 { set; get; }
        public static Image tank53 { set; get; }

        public Tank()
        {

        }


        public static Tank getTank(string name)
        {
            if (!tanks.ContainsKey(name))
            {
                tanks.Add(name, new Tank(name));
            }
            return (Tank)tanks[name];
        }

        public Tank(string name, int direction)
        {
            this.name = name;
            this.direction = direction;
            this.type = Type.TANK;

            switch (name)
            {
                case "P0":
                    switch (direction)
                    {
                        case 0:
                            this.image = Tank.tank1;
                            break;
                        case 1:
                            this.image = Tank.tank11;
                            break;
                        case 2:
                            this.image = Tank.tank12;
                            break;
                        case 3:
                            this.image = Tank.tank13;
                            break;
                    }
                    break;
                case "P1":
                    switch (direction)
                    {
                        case 0:
                            this.image = Tank.tank2;
                            break;
                        case 1:
                            this.image = Tank.tank21;
                            break;
                        case 2:
                            this.image = Tank.tank22;
                            break;
                        case 3:
                            this.image = Tank.tank23;
                            break;
                    }
                    break;
                case "P2":
                    switch (direction)
                    {
                        case 0:
                            this.image = Tank.tank3;
                            break;
                        case 1:
                            this.image = Tank.tank31;
                            break;
                        case 2:
                            this.image = Tank.tank32;
                            break;
                        case 3:
                            this.image = Tank.tank33;
                            break;
                    }
                    break;
                case "P3":
                    switch (direction)
                    {
                        case 0:
                            this.image = Tank.tank4;
                            break;
                        case 1:
                            this.image = Tank.tank41;
                            break;
                        case 2:
                            this.image = Tank.tank42;
                            break;
                        case 3:
                            this.image = Tank.tank43;
                            break;
                    }
                    break;
                case "P4":
                    switch (direction)
                    {
                        case 0:
                            this.image = Tank.tank5;
                            break;
                        case 1:
                            this.image = Tank.tank51;
                            break;
                        case 2:
                            this.image = Tank.tank52;
                            break;
                        case 3:
                            this.image = Tank.tank53;
                            break;
                    }
                    break;
                default:
                    this.image = null;
                    break;
            }

            this.shot = 0;
            this.health = 100;
            this.coins = 0;
            this.points = 0;
            this.type = Type.TANK;
            this.isVisible = true;
        }
        public Tank(string name, int x_cordinate, int y_cordinate)
        {
            this.type = Type.TANK;
            this.name = name;
            switch (name)
            {
                case "P0":
                    this.image = Tank.tank1;
                    break;
                case "P1":
                    this.image = Tank.tank2;
                    break;
                case "P2":
                    this.image = Tank.tank3;
                    break;
                case "P3":
                    this.image = Tank.tank4;
                    break;
                case "P4":
                    this.image = Tank.tank5;
                    break;
                default:
                    this.image = null;
                    break;
            }
            this.x_cordinate = x_cordinate;
            this.y_cordinate = y_cordinate;
            this.direction = 0;
            this.shot = 0;
            this.health = 100;
            this.coins = 0;
            this.points = 0;
            this.type = Type.TANK;
            this.isVisible = true;
        }

        public Tank(string name)
        {
            this.type = Type.TANK;
            this.name = name;
            switch (name)
            {
                case "P0":
                    this.image = Tank.tank1;
                    break;
                case "P1":
                    this.image = Tank.tank2;
                    break;
                case "P2":
                    this.image = Tank.tank3;
                    break;
                case "P3":
                    this.image = Tank.tank4;
                    break;
                case "P4":
                    this.image = Tank.tank5;
                    break;
                default:
                    this.image = null;
                    break;
            }
            this.type = Type.TANK;
            this.isVisible = false;
        }

        public Tank(string name, int x_cordinate, int y_cordinate, int direction, int shot, int health, int coins, int points)
        {
            this.name = name;
            this.direction = direction;
            switch (name)
            {
                case "P0":
                    switch (direction)
                    {
                        case 0:
                            this.image = Tank.tank1;
                            break;
                        case 1:
                            this.image = Tank.tank11;
                            break;
                        case 2:
                            this.image = Tank.tank12;
                            break;
                        case 3:
                            this.image = Tank.tank13;
                            break;
                    }
                    break;
                case "P1":
                    switch (direction)
                    {
                        case 0:
                            this.image = Tank.tank2;
                            break;
                        case 1:
                            this.image = Tank.tank21;
                            break;
                        case 2:
                            this.image = Tank.tank22;
                            break;
                        case 3:
                            this.image = Tank.tank23;
                            break;
                    }
                    break;
                case "P2":
                    switch (direction)
                    {
                        case 0:
                            this.image = Tank.tank3;
                            break;
                        case 1:
                            this.image = Tank.tank31;
                            break;
                        case 2:
                            this.image = Tank.tank32;
                            break;
                        case 3:
                            this.image = Tank.tank33;
                            break;
                    }
                    break;
                case "P3":
                    switch (direction)
                    {
                        case 0:
                            this.image = Tank.tank4;
                            break;
                        case 1:
                            this.image = Tank.tank41;
                            break;
                        case 2:
                            this.image = Tank.tank42;
                            break;
                        case 3:
                            this.image = Tank.tank43;
                            break;
                    }
                    break;
                case "P4":
                    switch (direction)
                    {
                        case 0:
                            this.image = Tank.tank5;
                            break;
                        case 1:
                            this.image = Tank.tank51;
                            break;
                        case 2:
                            this.image = Tank.tank52;
                            break;
                        case 3:
                            this.image = Tank.tank53;
                            break;
                    }
                    break;
                default:
                    this.image = null;
                    break;
            }
            this.x_cordinate = x_cordinate;
            this.y_cordinate = y_cordinate;
            
            this.shot = shot;
            this.health = health;
            this.coins = coins;
            this.points = points;
            this.type = Type.TANK;
            this.isVisible = true;
        }

        public static void LoadGraphics()
        {
            //Loading Tank Graphics
            tank1 = (Image)Properties.Resources.T1;
            tank2 = (Image)Properties.Resources.T2;
            tank3 = (Image)Properties.Resources.T3;
            tank4 = (Image)Properties.Resources.T4;
            tank5 = (Image)Properties.Resources.T5;
            tank11 = (Image)Properties.Resources.T13;
            tank21 = (Image)Properties.Resources.T23;
            tank31 = (Image)Properties.Resources.T33;
            tank41 = (Image)Properties.Resources.T43;
            tank51 = (Image)Properties.Resources.T53;
            tank12 = (Image)Properties.Resources.T12;
            tank22 = (Image)Properties.Resources.T22;
            tank32 = (Image)Properties.Resources.T32;
            tank42 = (Image)Properties.Resources.T42;
            tank52 = (Image)Properties.Resources.T52;
            tank13 = (Image)Properties.Resources.T11;
            tank23 = (Image)Properties.Resources.T21;
            tank33 = (Image)Properties.Resources.T31;
            tank43 = (Image)Properties.Resources.T41;
            tank53 = (Image)Properties.Resources.T51;
        }

        public void Update(int x_cordinate, int y_cordinate, int direction, int shot, int health, int coins, int points)
        {

        }         
        
        public void setDirection(int direction)
        {
            this.direction = direction;
            switch (name)
            {
                case "P0":
                    switch (direction)
                    {
                        case 0:
                            this.image = Tank.tank1;
                            break;
                        case 1:
                            this.image = Tank.tank11;
                            break;
                        case 2:
                            this.image = Tank.tank12;
                            break;
                        case 3:
                            this.image = Tank.tank13;
                            break;
                    }
                    break;
                case "P1":
                    switch (direction)
                    {
                        case 0:
                            this.image = Tank.tank2;
                            break;
                        case 1:
                            this.image = Tank.tank21;
                            break;
                        case 2:
                            this.image = Tank.tank22;
                            break;
                        case 3:
                            this.image = Tank.tank23;
                            break;
                    }
                    break;
                case "P2":
                    switch (direction)
                    {
                        case 0:
                            this.image = Tank.tank3;
                            break;
                        case 1:
                            this.image = Tank.tank31;
                            break;
                        case 2:
                            this.image = Tank.tank32;
                            break;
                        case 3:
                            this.image = Tank.tank33;
                            break;
                    }
                    break;
                case "P3":
                    switch (direction)
                    {
                        case 0:
                            this.image = Tank.tank4;
                            break;
                        case 1:
                            this.image = Tank.tank41;
                            break;
                        case 2:
                            this.image = Tank.tank42;
                            break;
                        case 3:
                            this.image = Tank.tank43;
                            break;
                    }
                    break;
                case "P4":
                    switch (direction)
                    {
                        case 0:
                            this.image = Tank.tank5;
                            break;
                        case 1:
                            this.image = Tank.tank51;
                            break;
                        case 2:
                            this.image = Tank.tank52;
                            break;
                        case 3:
                            this.image = Tank.tank53;
                            break;
                    }
                    break;
                default:
                    this.image = null;
                    break;
            }
        }    
        
        public bool MoveNorth()
        {
            //0
            if(direction == 0)
            {
                if (this.y_cordinate > 0)
                {
                    if(Arena.obj_map[x_cordinate,y_cordinate-1].type == Type.FLOOR)
                    {
                        this.y_cordinate -= 1;
                        return true;
                    }
                }
            }
            else
            {
                setDirection(0);
            }
            return false;
        }          
        
        public bool MoveEast()
        {
            //1
            if(direction == 1)
            {
                if(x_cordinate< Arena.size-1)
                {
                    if (Arena.obj_map[x_cordinate + 1, y_cordinate].type == Type.FLOOR)
                    {
                        x_cordinate += 1;
                        return true;
                    }
                }
            }
            else
            {
                setDirection(1);
            }
            return false;
        }       
        
        public bool MoveSouth()
        {
            //2
            if(direction == 2)
            {
                if(y_cordinate < Arena.size - 1)
                {
                    if (Arena.obj_map[x_cordinate, y_cordinate + 1].type == Type.FLOOR)
                    {
                        y_cordinate += 1;
                        return true;
                    }
                }
            }
            else
            {
                setDirection(2);
            }
            return false;
        }     
        
        public bool MoveWest()
        {
            //3
            if(direction == 3)
            {
                if(x_cordinate > 0)
                {
                    if (Arena.obj_map[x_cordinate - 1, y_cordinate].type == Type.FLOOR)
                    {
                        x_cordinate -= 1;
                        return true;
                    }
                }
            }
            else
            {
                setDirection(3);
            }
            return false;
        }                                                   
    }
}
