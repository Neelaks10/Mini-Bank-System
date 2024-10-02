using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient; 



namespace Baningwithmysql
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3309;UID=root;PWD=mj;DATABASE=mj";
            MySqlConnection con = new MySqlConnection(cs);
            try
            {
                con.Open();
                MySqlCommand cmd2 = new MySqlCommand("select * from account");
                cmd2.Connection = con;

                MySqlDataAdapter dr2 = new MySqlDataAdapter();
                dr2.SelectCommand = cmd2;
                DataTable dt2 = new DataTable();
                dr2.Fill(dt2);
                dataGridView1.DataSource = dt2;
                dataGridView1.Visible = true;
            }
            catch (Exception rr)
            {
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            String cs = "Server = localhost;PORT = 3309;UID=root;PWD=mj;DATABASE=mj";

            MySqlConnection con = new MySqlConnection(cs);

                con.Open();

                MySqlCommand cmd = new MySqlCommand("insert into account values('" + textBox1.Text  + "','" + textBox2.Text + "','" + textBox3.Text + "')");

            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            MessageBox.Show("New Account Created successfully..");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            String cs = "Server = localhost;PORT = 3309;UID=root;PWD=mj;DATABASE=mj";
            MySqlConnection con = new MySqlConnection(cs);
            con.Open();

            MySqlCommand cmd1 = new MySqlCommand(" select * from account where accno='"+textBox1.Text+"'");
            MySqlDataReader dr;

            cmd1.Connection = con;
            dr = cmd1.ExecuteReader();

            if (dr.Read())
            {
                textBox2.Text = dr.GetString(1);
                textBox3.Text = dr.GetString(2);
            }
            else
            {
                MessageBox.Show(" No such Records present");
                textBox1.Text = "";
                textBox1.Focus();
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3309;UID=root;PWD=mj;DATABASE=mj";

            MySqlConnection con = new MySqlConnection(cs);

            con.Open();

            MySqlCommand cmd = new MySqlCommand("update account set name='" + textBox2.Text + "',bal='" + textBox3.Text + "' where accno='" + textBox1.Text + "'");

            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            MessageBox.Show("Account Details Updated successfully..");

        }

        private void button3_Click(object sender, EventArgs e)
        {
            String cs = "Server = localhost;PORT = 3309;UID=root;PWD=mj;DATABASE=mj";

            MySqlConnection con = new MySqlConnection(cs);

            con.Open();

            MySqlCommand cmd = new MySqlCommand("delete from account where accno='" + textBox1.Text + "'");

            cmd.Connection = con;

            cmd.ExecuteNonQuery();

            MessageBox.Show("Account Details Removed successfully..");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            dataGridView1.Visible = false;
            textBox1.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.Show();
        }
    }
}
