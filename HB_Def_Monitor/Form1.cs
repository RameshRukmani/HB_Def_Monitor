using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HB_Def_Monitor
{
    public partial class Monitor : Form
    {
        string DataIN;
        private DateTime datetime;
        delegate void SetTextCallback(string text);
        public Monitor()
        {
            InitializeComponent();
        
            datetime = DateTime.Now;
            string time = +datetime.Year + ":" + datetime.Hour + ":" + datetime.Minute + ":" + datetime.Second;

            textBox17.Text = time;

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            button1_Connect.Enabled = true;
            button2_Disconnect.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
           

        }

        private void comboBox1_Port_DropDown(object sender, EventArgs e)
        {
            string[] portLists = SerialPort.GetPortNames();
            comboBox1_Port.Items.Clear();
            comboBox1_Port.Items.AddRange(portLists);

        }

        private void button1_Connect_Click(object sender, EventArgs e)
        {
            try 
            {
                serialPort1.PortName = comboBox1_Port.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBox2_BaudRate.Text);
                serialPort1.Open();

                MessageBox.Show("Estabished Contact With Arduino");

                button1_Connect.Enabled = false;
                button2_Disconnect.Enabled = true;

            }
            catch(Exception error)
            {
                MessageBox.Show("Check Availability of Ports or Correct Port!");
            }
        }

        private void button2_Disconnect_Click(object sender, EventArgs e)
        {
            try 
            {
                serialPort1.Close();
                button1_Connect.Enabled = true;
                button2_Disconnect.Enabled = false;

                MessageBox.Show("Arduino no longer in Contact!");

            
            
            }
            catch 
            {

                MessageBox.Show("error.Message");
            }
        }

        private void Monitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                serialPort1.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void serialPort1_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            string DataIN = serialPort1.ReadLine();
            this.SetText(DataIN);

            this.BeginInvoke(new EventHandler(ProcessData));
            this.BeginInvoke(new EventHandler(Displaydata));
        }
        public void SetText(string text)
        {
            string[] newData = text.Split('E');
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(SetText), new object[] { text });
                return;
            }
            textBox2.Text = newData[0];
            textBox3.Text = newData[1];
            textBox4.Text = newData[2];
            textBox5.Text = newData[3];
            textBox6.Text = newData[4];
        }

        private void ProcessData(object sender, EventArgs e)
        {
            string dataIN = DataIN;

        }
        private void Displaydata(object sender, EventArgs e)
        {


        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }

    








}
