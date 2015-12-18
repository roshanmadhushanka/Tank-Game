using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using TANKiClient.Model;

namespace TANKiClient
{
    public delegate void UpdateGame(String str);
    public delegate void ExecuteGame(String com);
    

    public partial class Game : Form
    {
        private static Game form = null;
        private GameClient client;
        
        private Hashtable map = new Hashtable();
        Arena arena;
      

        public Game()
        {
            InitializeComponent();
            client = new GameClient(this);
            GameObject.LoadGraphic();        //Loadin images  
           
            InitMap();                        //Initialize Map
            arena = new Arena(ref map);       //Pass Graphical map as a reference
        }

        public void InitMap()
        {
            //For Demo Only
            //Map Image boxes into a init number
            
            map.Add(1, c00);
            map.Add(2, c01);
            map.Add(3, c02);
            map.Add(4, c03);
            map.Add(5, c04);
            map.Add(6, c05);
            map.Add(7, c06);
            map.Add(8, c07);
            map.Add(9, c08);
            map.Add(10, c09);
            map.Add(11, c10);
            map.Add(12, c11);
            map.Add(13, c12);
            map.Add(14, c13);
            map.Add(15, c14);
            map.Add(16, c15);
            map.Add(17, c16);
            map.Add(18, c17);
            map.Add(19, c18);
            map.Add(20, c19);
            map.Add(21, c20);
            map.Add(22, c21);
            map.Add(23, c22);
            map.Add(24, c23);
            map.Add(25, c24);
            map.Add(26, c25);
            map.Add(27, c26);
            map.Add(28, c27);
            map.Add(29, c28);
            map.Add(30, c29);
            map.Add(31, c30);
            map.Add(32, c31);
            map.Add(33, c32);
            map.Add(34, c33);
            map.Add(35, c34);
            map.Add(36, c35);
            map.Add(37, c36);
            map.Add(38, c37);
            map.Add(39, c38);
            map.Add(40, c39);
            map.Add(41, c40);
            map.Add(42, c41);
            map.Add(43, c42);
            map.Add(44, c43);
            map.Add(45, c44);
            map.Add(46, c45);
            map.Add(47, c46);
            map.Add(48, c47);
            map.Add(49, c48);
            map.Add(50, c49);
            map.Add(51, c50);
            map.Add(52, c51);
            map.Add(53, c52);
            map.Add(54, c53);
            map.Add(55, c54);
            map.Add(56, c55);
            map.Add(57, c56);
            map.Add(58, c57);
            map.Add(59, c58);
            map.Add(60, c59);
            map.Add(61, c60);
            map.Add(62, c61);
            map.Add(63, c62);
            map.Add(64, c63);
            map.Add(65, c64);
            map.Add(66, c65);
            map.Add(67, c66);
            map.Add(68, c67);
            map.Add(69, c68);
            map.Add(70, c69);
            map.Add(71, c70);
            map.Add(72, c71);
            map.Add(73, c72);
            map.Add(74, c73);
            map.Add(75, c74);
            map.Add(76, c75);
            map.Add(77, c76);
            map.Add(78, c77);
            map.Add(79, c78);
            map.Add(80, c79);
            map.Add(81, c80);
            map.Add(82, c81);
            map.Add(83, c82);
            map.Add(84, c83);
            map.Add(85, c84);
            map.Add(86, c85);
            map.Add(87, c86);
            map.Add(88, c87);
            map.Add(89, c88);
            map.Add(90, c89);
            map.Add(91, c90);
            map.Add(92, c91);
            map.Add(93, c92);
            map.Add(94, c93);
            map.Add(95, c94);
            map.Add(96, c95);
            map.Add(97, c96);
            map.Add(98, c97);
            map.Add(99, c98);
            map.Add(100, c99);
        }

        public void SetImage(int x_cordinate, int y_cordinate, Image img)
        {
            int num = y_cordinate * 10 + (x_cordinate + 1);
            PictureBox tmp = (PictureBox)map[num];
            tmp.Image = img;
        }

        public static Game GetForm()
        {
            
            if(form == null)
            {
                Game.form = new Game();
            }
            return form;
        }

        public void ChangeTextBox(String txt)
        {
            //Update game status
            if (rchGameStat.InvokeRequired)
            {
                Invoke(new UpdateGame(ChangeTextBox) , new object[] { txt });
            }
            else
            {
                rchGameStat.Text += "\n" + txt;
            }
        }

        public void ExecuteCommand(String com)
        {
            if (this.InvokeRequired)
            {
                Invoke(new ExecuteGame(ExecuteCommand), new object[] { com });
            }
            else
            {
                string[] lines = Regex.Split(com.Substring(0, com.Length-1), ":");
                if (lines[0].StartsWith("I"))
                {
                    //Game initilizing
                    string name = lines[1].Substring(0, 2);
                    lblMessage.Text = "Player : " + name;
                    // MessageBox.Show(name)
                    switch (name)
                    {
                        case "P0":
                            picCurrent.Image = Tank.tank1;
                            break;
                        case "P1":
                            picCurrent.Image = Tank.tank2;
                            break;
                        case "P2":
                            picCurrent.Image = Tank.tank3;
                            break;
                        case "P3":
                            picCurrent.Image = Tank.tank4;
                            break;
                        case "P4":
                            picCurrent.Image = Tank.tank4;
                            break;
                    }
                    
                }

                if (lines[0].StartsWith("S"))
                {
                    //Set player name
                    
                }

                if (lines[0].StartsWith("G"))
                {
                    //Game data

                }
                Decoder.Decode(com);
            }
        }

        public void UpdateTankHelth(int val)
        {

        }


        private void Game_Load(object sender, EventArgs e)
        {
            AI.ai_status = false;
        }

        private void Game_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Pressed");
        }

        public void UpdateGameStat(string stat)
        {
            rchGameStat.Text += "\n" + stat;
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            client.SendToServer("UP#");
            //Arena.ClearArena();
            //Tank.getTank("P0").MoveNorth();
            //Arena.AddGameObject(Tank.getTank("P0").x_cordinate, Tank.getTank("P0").y_cordinate, Tank.getTank("P0"));
            //Arena.UpdateArena();
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            client.SendToServer("RIGHT#");
            //Arena.ClearArena();
            //Tank.getTank("P0").MoveEast();
            //Arena.AddGameObject(Tank.getTank("P0").x_cordinate, Tank.getTank("P0").y_cordinate, Tank.getTank("P0"));
            //Arena.UpdateArena();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            client.SendToServer("DOWN#");
            //Arena.ClearArena();
            //Tank.getTank("P0").MoveSouth();
            //Arena.AddGameObject(Tank.getTank("P0").x_cordinate, Tank.getTank("P0").y_cordinate, Tank.getTank("P0"));
            //Arena.UpdateArena();
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            client.SendToServer("LEFT#");
            //Arena.ClearArena();
            //Tank.getTank("P0").MoveWest();
            //Arena.AddGameObject(Tank.getTank("P0").x_cordinate, Tank.getTank("P0").y_cordinate, Tank.getTank("P0"));
            //Arena.UpdateArena();
        }

        private void btnShoot_Click(object sender, EventArgs e)
        {
            client.SendToServer("SHOOT#");
        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            client.ip = txtIPAddress.Text;
            client.SendToServer("JOIN#");
            AI.gameClient = client;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            Tank.getTank("P0").x_cordinate = 2;
            Tank.getTank("P0").y_cordinate = 1;
            Arena.AddGameObject(2, 1, Tank.getTank("P0"));
            Arena.UpdateArena();
            //Decoder.Decode("L:0,1:19207#");
            //Decoder.Decode("S:P1:1,1:0#");
            //Arena.UpdateArena();
        }

        private void c69_Click(object sender, EventArgs e)
        {
            
        }

        private void rchGameStat_TextChanged(object sender, EventArgs e)
        {
            rchGameStat.SelectionStart = rchGameStat.Text.Length;
            rchGameStat.ScrollToCaret();
        }

        private void btnAI_Click(object sender, EventArgs e)
        {
            if(AI.ai_status == false)
            {
                AI.ai_status = true;
                btnAI.Text = "Disable AI";
                btnUp.Enabled = false;
                btnDown.Enabled = false;
                btnLeft.Enabled = false;
                btnRight.Enabled = false;
            }
            else
            {
                AI.ai_status = false;
                btnAI.Text = "Activate AI";
                btnUp.Enabled = true;
                btnDown.Enabled = true;
                btnLeft.Enabled = true;
                btnRight.Enabled = true;
            }
        }

        public void updateGameDetails()
        {
            lblScore.Text = Tank.getTank(Tank.current_player_name).coins.ToString();
        }
    }
}
