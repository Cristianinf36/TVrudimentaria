using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace CristianTV
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Para evitar que el usuario cambie la vista a la ventana
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            //Variable de encendido o apagado
            power = true;
            //Array bidimensional de canales.
            canales = new string[,]{
                {"2","https://ss1.domint.net:3126/ta2_str/teleantillas/playlist.m3u8" },
                {"5","https://playback.akamaized.net/streams/28126860_8531341_lsi1pcducrzz1i7nf83_1/media/28126860_8531341_lsi1pcducrzz1i7nf83_1@446000pb.m3u8?dw=80&ts=1554670800&hdnts=exp=1554845897~acl=/streams/28126860_8531341_lsi1pcducrzz1i7nf83_1/media*~hmac=c33a88843933b175dde299277cdfeb9bdb518b42ddbdd74d88bd0bf0874162f6"} ,
                {"9","https://stream-02.nyc.dailymotion.com/sec(d6Li0alGMG4oHIKxMrrxpg92VpQkmWBM78_15VIpbds)/dm/3/x6tt2y8/live.m3u8#cell=lnyc&comment=TRS&qos_vpart=1&qos_stail=1"} ,
                {"11","https://ss3.domint.net:3114/t11_str/telesistema/playlist.m3u8"} , 
                {"13","https://playback.akamaized.net/streams/28126860_8555433_lsil4l41wxb1ravw87q_1/media/28126860_8555433_lsil4l41wxb1ravw87q_1@696000pb.m3u8?dw=80&ts=1554678000&hdnts=exp=1554852106~acl=/streams/28126860_8555433_lsil4l41wxb1ravw87q_1/media*~hmac=cc44c68d5222ab6994778a13b273876072130c1a23aad9b86a0b401d412e05d3"} ,
                {"15","https://playback.akamaized.net/streams/28126860_8555544_lsiwcec8oizvke1n04w_1/media/28126860_8555544_lsiwcec8oizvke1n04w_1@446000p.m3u8?dw=80&ts=1554670800&hdnts=exp=1554844599~acl=/streams/28126860_8555544_lsiwcec8oizvke1n04w_1/media*~hmac=852cdb5f65d52d3e11257cbd6d365dcc330f6e3854ef5c9432f7988f74423367"} ,
                {"19","http://cinevision01.streamprolive.com/hls/live.m3u8" } ,
                {"23","http://ss8.domint.net:2118/tf_str/futu/playlist.m3u8"} ,
                {"29","https://ss1.domint.net:3302/tu_str/universo/chunklist_w1317328852.m3u8"} 
                
            };

            //URL inicial
            urlCanal = canales[0, 1];
            axWindowsMediaPlayer1.URL = urlCanal;
            txtCanal.Text = canales[0,0];

            //Rellenar el listbox
            RenellenaListBox();
        }
        

        //Método para que continue la reproducción
        private void axWindowsMediaPlayer1_PlayStateChange(object sender,
                AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            if (e.newState == 10)
            {
                
                    this.BeginInvoke(new Action(() => {
                        if (power != false)
                        {
                            this.axWindowsMediaPlayer1.URL = urlCanal;
                        }
                    }));
                
                
            }
        }
        
        
        //Método para encender y apagar.
        private void On_Click(object sender, EventArgs e)
        {
            if (power)
            {
                axWindowsMediaPlayer1.URL = "";
                power = false;
                label1.Enabled = false;
                txtCanal.Enabled = false;
                Back.Enabled = false;
                Next.Enabled = false;
                Cambia.Enabled = false;
                btn0.Enabled = false;
                btn1.Enabled = false;
                btn2.Enabled = false;
                btn3.Enabled = false;
                btn4.Enabled = false;
                btn5.Enabled = false;
                btn6.Enabled = false;
                btn7.Enabled = false;
                btn8.Enabled = false;
                btn9.Enabled = false;
                Borrar.Enabled = false;
                listBox1.Enabled = false;
            }
            else
            {
                axWindowsMediaPlayer1.URL = urlCanal;
                power = true;
                label1.Enabled = true;
                txtCanal.Enabled = true;
                Back.Enabled = true;
                Next.Enabled = true;
                Cambia.Enabled = true;
                btn0.Enabled = true;
                btn1.Enabled = true;
                btn2.Enabled = true;
                btn3.Enabled = true;
                btn4.Enabled = true;
                btn5.Enabled = true;
                btn6.Enabled = true;
                btn7.Enabled = true;
                btn8.Enabled = true;
                btn9.Enabled = true;
                Borrar.Enabled = true;
                listBox1.Enabled = true;
            }
        }

        
        //Botones numericos
        private void btn1_Click(object sender, EventArgs e)
        {
            txtCanal.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            txtCanal.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            txtCanal.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            txtCanal.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            txtCanal.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            txtCanal.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            txtCanal.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            txtCanal.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            txtCanal.Text += "9";
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            txtCanal.Text += "0";
        }

        private void Borrar_Click(object sender, EventArgs e)
        {
            txtCanal.Text = "";
        }
        

        //Botón de cambiar
        private void Cambia_Click(object sender, EventArgs e)
        {
            bool isFound = false;
            for(int i = 0; i< 9; i++)
            {
                if (txtCanal.Text.Equals(canales[i, 0]))
                {
                    urlCanal = canales[i, 1];
                    this.axWindowsMediaPlayer1.URL = urlCanal;
                    isFound = true;
                }
            }
            if (isFound == false)
            {
                MessageBox.Show("Canal no disponible. Disculpe los inconvenientes");
            }
            
        }

        //Botón de ir hacia atrás
        private void Back_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                if ( urlCanal.Equals(canales[i, 1]) && i != 0)
                {
                    urlCanal = canales[i-1, 1];
                    this.axWindowsMediaPlayer1.URL = urlCanal;
                    txtCanal.Text = canales[i - 1, 0];
                }
            }
        }
        //Botón hacia adelante
        private void Next_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 9; i++)
            {
                if (urlCanal.Equals(canales[i, 1]) && i != 8)
                {
                    urlCanal = canales[i + 1, 1];
                    this.axWindowsMediaPlayer1.URL = urlCanal;
                    txtCanal.Text = canales[i + 1, 0];
                    break;
                }
            }
        }
        //Método para rellenar la lista
        private void RenellenaListBox()
        {
            
            listBox1.Items.Add("Canal 2: Teleantillas");
            listBox1.Items.Add("Canal 5: Telemicro");
            listBox1.Items.Add("Canal 9: Color Visión");
            listBox1.Items.Add("Canal 11: Telesistema");
            listBox1.Items.Add("Canal 13: Telecentro");
            listBox1.Items.Add("Canal 15: Digital 15");
            listBox1.Items.Add("Canal 19: Cinevision");
            listBox1.Items.Add("Canal 23: Telefuturo");
            listBox1.Items.Add("Canal 29: Teleuniverso");
            
        }

        //Cambiar de canal a través del listbox
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            urlCanal = canales[listBox1.SelectedIndex, 1];
            axWindowsMediaPlayer1.URL = urlCanal;
            txtCanal.Text = canales[listBox1.SelectedIndex, 0];
        }

        //Variables
        private bool power;
        private string[,] canales;
        private string urlCanal;

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 ayuda = new Form2();
            ayuda.Show();
        }
    }
}
