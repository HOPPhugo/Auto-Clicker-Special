using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

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
            _hookID = SetHook(_proc);
        }
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                // Exemple : Touche F6 pour toggle
                if (vkCode == (int)Keys.F6)
                {
                    // Toggle activé ou désactivé
                    Application.OpenForms[0].BeginInvoke((Action)(() =>
                    {
                        Form1 form = (Form1)Application.OpenForms[0];
                        form.ToggleClicker();
                    }));
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
            base.OnFormClosed(e);
        }

        public void ToggleClicker()
        {
            Cliker = !Cliker;
            if (Cliker)
            {
                autoCliker.Start();
                button1.BackColor = Color.Blue;
            }
            else
            {
                autoCliker.Stop();
                button1.BackColor = Color.White;
            }
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
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
                DoMouseClick1();
                DoMouseClick2();
                DoMouseClick3();
                DoMouseClick4();
                DoMouseClick5();
                DoMouseClick6();
                DoMouseClick7();
                DoMouseClick8();
                DoMouseClick9();
                DoMouseClick10();
            }
            
        }
        public void DoMouseClick()
        {
                //simule un clic a la position courante du curseur
                int X = Cursor.Position.X;
                int Y = Cursor.Position.Y;
                mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        public void DoMouseClick1()
        {
            //simule un clic a la position courante du curseur
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        public void DoMouseClick2()
        {
            //simule un clic a la position courante du curseur
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        public void DoMouseClick3()
        {
            //simule un clic a la position courante du curseur
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        public void DoMouseClick4()
        {
            //simule un clic a la position courante du curseur
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        public void DoMouseClick5()
        {
            //simule un clic a la position courante du curseur
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        public void DoMouseClick6()
        {
            //simule un clic a la position courante du curseur
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        public void DoMouseClick7()
        {
            //simule un clic a la position courante du curseur
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        public void DoMouseClick8()
        {
            //simule un clic a la position courante du curseur
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        public void DoMouseClick9()
        {
            //simule un clic a la position courante du curseur
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }
        public void DoMouseClick10()
        {
            //simule un clic a la position courante du curseur
            int X = Cursor.Position.X;
            int Y = Cursor.Position.Y;
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0);
        }

        private void Key_Down(object sender, KeyEventArgs e)
        {
        }
    }
}
