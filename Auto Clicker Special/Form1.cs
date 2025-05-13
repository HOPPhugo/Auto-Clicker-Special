using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Auto_Clicker_Special
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, int dx, int dy, uint cButtons, uint dwExtraInfo);
        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;
        private const uint MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const uint MOUSEEVENTF_RIGHTUP = 0x10;
        bool Cliker = false;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("SHUT UP, THIS IS THE BEST AUTO CLICKER EVER CREATED !!!!");
            MessageBox.Show("YOU ARE THE DUMBEST KID I'VE SEEN IN MY ENTIRE LIFE !");
            MessageBox.Show("you are BAD :(");
            MessageBox.Show("you have a ridicul life");
            MessageBox.Show("you are cringe !");
            MessageBox.Show("good bye, have a bad day :(:(:(");
            this.Hide();
            await Task.Delay(3000);
            MessageBox.Show(":(");
            MessageBox.Show("bad guy !");
            MessageBox.Show("go play \"adopt me\" little gay kid");
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            button2.Visible = false;
            label12.Visible = false;
            MessageBox.Show("You are a good guy :)");
            MessageBox.Show("Your life is incredible ^^");
            MessageBox.Show("have a nice day 👍");
            MessageBox.Show(":3");
            MessageBox.Show("💓");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ( button1.BackColor == Color.White)
            {
                button1.BackColor = Color.Blue;
                return;
            }
            else
            {
                button1.BackColor = Color.White;
                return;
            }
        }

        private void autoCliker_Tick(object sender, EventArgs e)
        {
            if (Cliker == true)
            {
                DoMouseClick();
            }
            
        }
        public void DoMouseClick()
        {
                //simule un clic a la position courante du curseur
                int X = Cursor.Position.X;
                int Y = Cursor.Position.Y;
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F6 && Cliker == false) 
            {
                Cliker = true;
                MessageBox.Show("overt");
                return;
            }
            if (e.KeyCode == Keys.F6 && Cliker == true) 
            {
                Cliker = false;
                MessageBox.Show("fwew");
                return;
            }
        }
    }
}
