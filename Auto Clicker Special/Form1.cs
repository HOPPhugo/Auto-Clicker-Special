// Importations nécessaires pour le fonctionnement de l'application
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Auto_Clicker_Special
{
    public partial class Form1 : Form
    {
        // Constantes pour les hooks clavier
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        // Déclarations pour le hook clavier
        private static LowLevelKeyboardProc _proc = HookCallback;
        private static IntPtr _hookID = IntPtr.Zero;

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        // Fonctions importées des API Windows pour gérer les entrées clavier/souris
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

        // Constantes pour les clics souris
        private const uint MOUSEEVENTF_LEFTDOWN = 0x02;
        private const uint MOUSEEVENTF_LEFTUP = 0x04;

        // Variables de contrôle
        bool Cliker = false;
        int clicks = 0;
        int chrono = 0;
        bool train = false;

        public Form1()
        {
            InitializeComponent();
            _hookID = SetHook(_proc); // Active le hook clavier global
        }

        // Callback du hook clavier
        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);
                if (vkCode == (int)Keys.F6) // F6 pour activer/désactiver le clicker
                {
                    Application.OpenForms[0].BeginInvoke((Action)(() =>
                    {
                        Form1 form = (Form1)Application.OpenForms[0];
                        form.ToggleClicker(); // Appel à la fonction toggle
                    }));
                }
            }
            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }

        // Nettoyage du hook clavier lors de la fermeture du formulaire
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            UnhookWindowsHookEx(_hookID);
            base.OnFormClosed(e);
        }

        // Fonction pour activer/désactiver le clicker automatique
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

        // Fonction pour enregistrer le hook clavier
        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        // Bouton 2 - Contenu volontairement hostile et offensant
        private async void button2_Click(object sender, EventArgs e)
        {
            // Affiche une série de messages désagréables et ferme l'application
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

        // Bouton 3 - Messages positifs
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

        // Bouton principal qui change l’état et compte les clics
        private void button1_Click(object sender, EventArgs e)
        {
            // choisi une couleur aléatoir
            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            Color randomColor = Color.FromKnownColor(randomColorName);
            train = true;
            clicks = clicks + 1;
            label13.Text = "Clicks : " + clicks;

                button1.BackColor = Color.FromKnownColor(randomColorName);
            
        }

        // Tick du timer de l'auto clicker, fait 20 clics rapides
        private void autoCliker_Tick(object sender, EventArgs e)
        {
            if (Cliker == true)
            {
                DoMouseClick(); DoMouseClick1(); DoMouseClick2(); DoMouseClick3(); DoMouseClick4();
                DoMouseClick5(); DoMouseClick6(); DoMouseClick7(); DoMouseClick8(); DoMouseClick9();
                DoMouseClick10(); DoMouseClick11(); DoMouseClick12(); DoMouseClick13(); DoMouseClick14();
                DoMouseClick15(); DoMouseClick16(); DoMouseClick17(); DoMouseClick18(); DoMouseClick19();
                DoMouseClick20();
            }
        }

        // Fonctions de clics répétées (simulent des clics à la position du curseur)
        public void DoMouseClick() { int X = Cursor.Position.X; int Y = Cursor.Position.Y; mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, X, Y, 0, 0); }
        public void DoMouseClick1() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick2() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick3() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick4() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick5() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick6() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick7() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick8() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick9() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick10() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick11() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick12() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick13() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick14() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick15() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick16() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick17() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick18() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick19() { DoMouseClick(); DoMouseClick(); }
        public void DoMouseClick20() { DoMouseClick(); DoMouseClick(); }

        // Ne fait rien (hook vide pour événement clavier)
        private void Key_Down(object sender, KeyEventArgs e) { }

        // Chargement du formulaire
        private void Form1_Load(object sender, EventArgs e) { }

        // Timer qui incrémente le chronomètre si le mode entrainement est actif
        private void temps_Tick(object sender, EventArgs e)
        {
            if (train == false)
            {
                chrono = 0;
                label14.Text = "Timer :" + chrono;
            }
            if (train == true)
            {
                chrono = chrono + 1;
                label14.Text = "Timer :" + chrono;
            }
        }

        // Bouton pour calculer les CPS (clics par seconde)
        private void button4_Click(object sender, EventArgs e)
        {
            if (chrono != 0)
            {
                int cps = clicks / chrono;
                label13.Text = "Clicks : 0";
                label14.Text = "Timer : 0";
                MessageBox.Show("Vous avez fait : " + cps + " CPS (Clicks par secondes)");
                clicks = 0;
                chrono = 0;
                train = false;
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        // redirige sur mon github
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/HOPPhugo");
        }

        //expliquation de comment calculer les cps
        private void label5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("How to calcul the cps?\n\nClick per secondes (CPS) = Total number of clicks / Total time in secondes\nIf you clicked 30time in 5 secondes. \nThat mean you clicked 6time per seondes.");
        }
    }
}
