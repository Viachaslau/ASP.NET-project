using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class About : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            bool hack = false;
            string query = "SELECT ip FROM iptable WHERE Id = (SELECT ip FROM mactable WHERE mac='"+TextBox1.Text+"')";
            if ((query.IndexOf("DELETE") != -1) || (query.IndexOf("INSERT") != -1) || (query.IndexOf("DRPOP") != -1) || (query.IndexOf("CREATE") != -1) || (query.IndexOf("UPDATE") != -1))
            {
                TextBox1.Text = "SQL Injection  Protection";
                hack = true;
            }
            if (!hack) 
            {
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection connection1 = new SqlConnection(connectionString);         
            connection1.Open();
            SqlCommand command1 = new SqlCommand(query, connection1);
            SqlDataReader dataReader1 = command1.ExecuteReader();      
            try
            {
                while (dataReader1.Read())
                {
                    TextBox1.Text = dataReader1[0].ToString();             
                }
            }
            catch 
            {
                TextBox1.Text = "Упс! Что-то пошло не так.";
            }
            finally
            {
                dataReader1.Close();
                connection1.Close();
            }
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            bool hack = false;
            string query = "SELECT fio,spec,room FROM personal WHERE Id = (SELECT Id FROM iptable WHERE ip='" + TextBox1.Text + "')";
            if ((query.IndexOf("DELETE") != -1) || (query.IndexOf("INSERT") != -1) || (query.IndexOf("DRPOP") != -1) || (query.IndexOf("CREATE") != -1) || (query.IndexOf("UPDATE") != -1))
            {
                TextBox1.Text = "SQL Injection  Protection";
                hack = true;
            }
            if (!hack)
            {
                string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
                SqlConnection connection1 = new SqlConnection(connectionString);
                connection1.Open();
                SqlCommand command1 = new SqlCommand(query, connection1);
                SqlDataReader dataReader1 = command1.ExecuteReader();
                try
                {
                    while (dataReader1.Read())
                    {
                        TextBox1.Text = dataReader1[0].ToString() + " spec: 107" + dataReader1[1].ToString() + " room:" + dataReader1[2].ToString();
                    }
                }
                catch
                {
                    TextBox1.Text = "Упс! Что-то пошло не так.";
                }
                finally
                {
                    dataReader1.Close();
                    connection1.Close();
                }
            }
        }
    }
}
