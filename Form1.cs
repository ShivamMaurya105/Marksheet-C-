using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Student_Marksheet
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String name, fathername, dob, course;
            name = textBox1.Text;
            fathername = textBox2.Text;
            dob = textBox3.Text;
            course = comboBox2.Text;
            textBox10.Text="500";

            int year, math, physics, chemistry, english, phyedu, obtained;
            float percentage;
            year = int.Parse(comboBox1.Text);
            math = int.Parse(textBox5.Text);
            physics = int.Parse(textBox6.Text);
            chemistry = int.Parse(textBox7.Text);
            english = int.Parse(textBox8.Text);
            phyedu = int.Parse(textBox4.Text);
            obtained = math + physics + chemistry + english + phyedu;
            textBox9.Text = obtained.ToString();
            percentage = obtained / 5;
            textBox11.Text = percentage.ToString();
            if (percentage >= 50 && percentage < 60)
                textBox12.Text = "C";
            else if (percentage >= 60 && percentage < 75)
                textBox12.Text = "B";
            else if (percentage >= 75 && percentage <= 100)
                textBox12.Text = "A";
            

            //1. Address of Server and Database.
            string ConnectionString = "Data Source=SHIVAM\\SQLEXPRESS;Initial Catalog=MyDB;Integrated Security=True";
            
            //2. Establish connection
            SqlConnection con=new SqlConnection(ConnectionString);
            //3. OpenFileDialog connection
            con.Open();
            //4. prepare query
            string query = "INSERT INTO marksheet (Name,Father_Name,DOB,Course, Year,Math,Physics,Chemistry,English,Phy_Edu,Obtained,Total,Percentage,Grade) VALUES ('"+name+ "','"+fathername+"','"+dob+"','"+course+"','"+year+"','"+math+"','"+physics+"','"+chemistry+"','"+english+"','"+phyedu+"','"+obtained+"','"+textBox10.Text+"','"+percentage+"','"+textBox12.Text+"')";
            //5. execut query
            SqlCommand cmd=new SqlCommand(query,con);
            cmd.ExecuteNonQuery();
            //6. close connection
            con.Close();
            MessageBox.Show("Details Saved");
             
        }

        private void button2_Click(object sender, EventArgs e)
        {
        
            SqlConnection con = new SqlConnection("Data Source = SHIVAM\\SQLEXPRESS; Initial Catalog = MyDB; Integrated Security = True");
            SqlCommand cmd = new SqlCommand("select * from marksheet",con);
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
