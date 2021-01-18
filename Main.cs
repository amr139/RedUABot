using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedUABot
{
    public partial class Main : Form
    {
        //Class & Events 
        private string email = "";
        private string password = "";
        
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateSession();            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             if (ReadSession())
            {
                BotDoAction();
            }
            else
            {
                PanelMensaje.Visible = false;
                PanelCreate.Visible = true;
            }
           
        }

        private void PasswordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CreateSession();
            }
        }

        //Custom Functions

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SendMessage(IntPtr hWnd, int wMsg, uint wParam, uint lParam);

        private List<Handles> WaitingForHandles(in Process p)
        {
            List<Handles> wantedWindows = new List<Handles>();
            do
            {
                wantedWindows = WindowHandleInfo.GetAllWindowsProcess(in p);
                Thread.Sleep(100);

            } while (wantedWindows.Count != 2);

            return wantedWindows;
        }

        private void BotDoAction()
        {

            //Get the process
            Process p = Process.Start(ConfigurationManager.AppSettings.Get("version"));
            if (p!=null)
            {
                //get the wanted windows of the selected process
                List<Handles> wantedWindows = WaitingForHandles(in p);
                if (wantedWindows.Count == 2)
                {
                    //Window1: SendEmail
                    foreach(char s in email)
                    {
                        SendMessage(wantedWindows[0].pointer, 0x0102, (uint)s, GetLParam(1, 0, 0, 0, 0));
                    }

                    //Window2: SendPassword
                    foreach (char s in password)
                    {
                        SendMessage(wantedWindows[1].pointer, 0x0102, (uint)s, GetLParam(1, 0, 0, 0, 0));
                    }

                    //Window3: SendIntro
                    SendMessage(wantedWindows[1].pointer, 0x0102, (uint)13, GetLParam(1, 0, 0, 0, 0));
                    Close();

                }
            }
            else
            {
                MessageBox.Show("Process hasn't been opened!", "KO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void CreateSession()
        {
            
            try
            {
                if(EmailTextBox.Text.Length>0 && PasswordTextBox.Text.Length > 0)
                {
                    RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
                    byte[] space = new byte[32];
                    random.GetBytes(space);

                    string key = ArrayBytesToHex(space);

                    StreamWriter f = new StreamWriter(key + ".session");
                    f.WriteLine(EmailTextBox.Text);
                    f.WriteLine(AES.Encrypt(PasswordTextBox.Text, key));
                    f.Close();
                    MessageBox.Show("Session created!", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    email = EmailTextBox.Text;
                    password = PasswordTextBox.Text;
                    BotDoAction();

                }else
                {
                    MessageBox.Show("Fields are not filled!", "KO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Error!" + Environment.NewLine + e.Message, "KO", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private bool ReadSession()
        {
            string[] ficheros = Directory.GetFiles(Directory.GetCurrentDirectory(), "*.session");
            //obtenemos la clave de cifrado
            if (ficheros.Count() > 0)
            {
                string fichero = ficheros[0];
                
                string keyAES = fichero.Substring(fichero.LastIndexOf("\\") + 1, fichero.LastIndexOf(".")- fichero.LastIndexOf("\\")-1);

                StreamReader f = new StreamReader(fichero);
                this.email = f.ReadLine();
                this.password = AES.Decrypt(f.ReadLine(),keyAES);
                f.Close();
                return (email.Count()!= 0 && password.Count()!=0);
            }
            return false;
        }

        //Aux Functions
        private string ArrayBytesToHex(in byte[] data)
        {
            StringBuilder hex = new StringBuilder(data.Length * 2);
            foreach (byte b in data)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        private static uint GetLParam(Int16 repeatCount, byte extended, byte contextCode, byte previousState,
            byte transitionState)
        {
            var lParam = (uint)repeatCount;
            //uint scanCode = MapVirtualKey((uint)key, MAPVK_VK_TO_CHAR);
            //uint scanCode = GetScanCode(key);
            lParam +=  0x10000;
            lParam += (uint)((extended) * 0x1000000);
            lParam += (uint)((contextCode * 2) * 0x10000000);
            lParam += (uint)((previousState * 4) * 0x10000000);
            lParam += (uint)((transitionState * 8) * 0x10000000);
            return lParam;
        }

       
    }
}
