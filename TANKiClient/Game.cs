using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TANKiClient
{
    public delegate void UpdateGame(String str);
    public delegate void ExecuteGame(String com);


    public partial class Game : Form
    {
        private static Game form = null;
        private GameClient client;

        public Game()
        {
            InitializeComponent();
            client = new GameClient(this);
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
                string[] lines = Regex.Split(com, ":");
                if (lines[0].StartsWith("S"))
                {
                    //Set player name
                    lblMessage.Text = "Player : " + lines[1].Substring(0, 2);
                }

                if (lines[0].StartsWith("G"))
                {
                    //split command
                    string[] tmp = Regex.Split(com, ":");
                    string[] data = Regex.Split(tmp[1], ";");

                    //take data individually 
                    string player_name = data[0];
                    string cord = data[1];

                }
            }
        }

        public void UpdateTankHelth(int val)
        {

        }


        private void Game_Load(object sender, EventArgs e)
        {
            
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
        }

        private void btnRight_Click(object sender, EventArgs e)
        {
            client.SendToServer("RIGHT#");
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            client.SendToServer("DOWN#");
        }

        private void btnLeft_Click(object sender, EventArgs e)
        {
            client.SendToServer("LEFT#");
        }

        private void btnShoot_Click(object sender, EventArgs e)
        {
            client.SendToServer("SHOOT#");
        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {
            client.ip = txtIPAddress.Text;
            client.SendToServer("JOIN#");
        }
    }
}
