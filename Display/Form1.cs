using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Display
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private Socket clientSocket;

        private ClientControl client = new ClientControl();

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("是否退出？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void btnSend_Click_1(object sender, EventArgs e)
        {
            if (txt1.Text == "" && txt2.Text == "" && txt3.Text == "" && txt4.Text == "" && txt5.Text == "")
            {
                MessageBox.Show("请输入文本！");
                return;
            }
            string msg = txt1.Text + "\n" + txt2.Text + "\n" + txt3.Text + "\n" + txt4.Text + "\n" + txt5.Text;
            client.ReadAndSend(msg);
        }

        private void btnConnect_Click_1(object sender, EventArgs e)
        {

            try
            {
                client.Connect(txtIP.Text, Convert.ToInt32(txtPort.Text));
                if (client.connState == true)
                {
                    txt1.Enabled = true;
                    txt2.Enabled = true;
                    txt3.Enabled = true;
                    txt4.Enabled = true;
                    txt5.Enabled = true;
                    btnSend.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Thread.Sleep(1);
            }
        }
    }
}
