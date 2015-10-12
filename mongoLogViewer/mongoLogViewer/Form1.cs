using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mongoLogViewer
{
    public partial class MongoLogViewer : Form
    {
        DBHelper dbHelper = new DBHelper();
        string currentId;
        string currentPassword;
        bool isLogin = false;

        public MongoLogViewer()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            if (!isLogin)
            {
                var nameList = await dbHelper.Login(userId.Text, password.Text);
                if (nameList == null)
                {
                    userId.Clear();
                    password.Clear();
                    MessageBox.Show("Login Failed!");
                }
                else
                {
                    currentId = userId.Text;
                    currentPassword = password.Text;

                    userId.Enabled = false;
                    password.Enabled = false;
                    LoginButton.Text = "LogOut";

                    nameBox.Enabled = true;
                    LogLevel.Enabled = true;
                    FromDateTime.Enabled = true;
                    ToDateTime.Enabled = true;
                    ShowButton.Enabled = true;
                    nameBox.Items.Clear();
                    nameBox.Items.AddRange(nameList.ToArray());
                    isLogin = true;


                }
            }
            else
            {
                LoginButton.Text = "LogIn";
                userId.Enabled = true;
                password.Enabled = true;
                userId.Clear();
                password.Clear();
                nameBox.Items.Clear();
                dataGridView.Rows.Clear();
                dataGridView.Refresh();

                nameBox.Enabled = false;
                LogLevel.Enabled = false;
                FromDateTime.Enabled = false;
                ToDateTime.Enabled = false;
                ShowButton.Enabled = false;
                isLogin = false;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            dataGridView.Refresh();
            int level = LogLevel.SelectedIndex;
            var logs = await dbHelper.GetData(currentId, currentPassword, nameBox.SelectedItem.ToString(), level ,FromDateTime.Value, ToDateTime.Value);
            foreach(var log in logs)
            {
                string msg = "{";
                foreach(var m in log.Msg)
                {
                    msg += "[" + m.Key + "=" + m.Value + "]";
                }
                msg += "}";

                
                dataGridView.Rows.Add(LogLevel.Items[log.Level].ToString(), log.Time, msg);
            }
        }
    }
}
