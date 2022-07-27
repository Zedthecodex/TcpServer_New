using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TcpServer_Client
{
    public partial class Form1 : Form
    {
        private room room_og;
        private room room_test;
        private room room_test1;

        private room selectedRoom = null;

        public Form1()
        {
            InitializeComponent();
            

            room_og = new room("room_og", "192.168.1.3", 9000);
            room_test = new room("room_test", "192.168.1.3", 9500);
            room_test1 = new room("room_test1", "192.168.1.132", 9750);

            selectedRoom = room_og;
            connectToRoom(selectedRoom, true);
        }


        public void AppendText(string str)
        {
            ChatLog_textbox.Text += str + "\n";
            ChatLog_textbox.SelectionStart = ChatLog_textbox.Text.Length;
            ChatLog_textbox.ScrollToCaret();
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;

            switch (index)
            {
                case 0:
                    selectedRoom = room_og;
                    break;
                case 1:
                    selectedRoom = room_test;
                    break;
                case 2:
                    selectedRoom = room_test1;
                    break;
              
            }

            //Message_Textbox.Text = listBox1.SelectedItem.ToString();

           // selectedRoom.ConnectionRoom.SendText(listBox1.SelectedItem.ToString());
            //connectToRoom(selectedRoom, true);
        }

        private void connectToRoom(room rm, Boolean disconnectedifConnected)
        {
            if(!rm.Connected)
            {
                Boolean connected = rm.ConnectionRoom.Connect(this, rm.Address, rm.Port, nickName_Textbox.Text);
                if(connected)
                {
                    Connect_Button.Text = "Disconnect";
                    rm.Connected = true;
                }
            }else if(disconnectedifConnected)
            {
                rm.ConnectionRoom.Disconnect();
                rm.Connected = false;
                Connect_Button.Text = "Connect";   
            }
            refreshList();
        }

        private void refreshList()
        {
            listBox1.Items.Clear();

            string[] myRooms = new string[3];

            myRooms[0] = room_og.Name + ConnectedOrNot(room_og);
            myRooms[1] = room_test.Name + ConnectedOrNot(room_test);
            myRooms[2] = room_test1.Name + ConnectedOrNot(room_test1);

            listBox1.Items.AddRange(myRooms);
        }

        string ConnectedOrNot(room r)
        {
            Boolean b = r.Connected;

            if (b) return " (connected)";
            else return "";
        }

        private void Send_Button_Click(object sender, EventArgs e)
        {
            if (!selectedRoom.Connected) return;

            selectedRoom.ConnectionRoom.SendText(Message_Textbox.Text);
            
            Message_Textbox.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            refreshList();
        }

        private void Connect_Button_Click(object sender, EventArgs e)
        {
            room_og.ConnectionRoom.SendText(listBox1.SelectedItem.ToString());
            Task.Delay(3000);
            connectToRoom(selectedRoom, true);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;

            switch (index)
            {
                case 0:
                    selectedRoom = room_og;
                    break;
                case 1:
                    selectedRoom = room_test;
                    break;
                case 2:
                    selectedRoom = room_test1;
                    break;
            }

            // MessageBox.Show(Convert.ToString(index));

            if (!selectedRoom.Connected) Connect_Button.Text = "Connect";
            else Connect_Button.Text = "Disconnect";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            room_og.ConnectionRoom.Disconnect();
        }
    }
}
