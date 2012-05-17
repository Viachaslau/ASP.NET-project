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
            string query = "SELECT id FROM iptable WhERE ip='"+TextBox1.Text+'\'';
            string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=|DataDirectory|\Database1.mdf;Integrated Security=True";
            SqlConnection connection1 = new SqlConnection(connectionString);         
            connection1.Open();
      SqlCommand command1 = new SqlCommand(query, connection1);
      SqlDataReader dataReader1 = command1.ExecuteReader();
      // Организуем циклический перебор полученных записей
      //и выводим название каждой планеты в список
      while (dataReader1.Read())
      {
          TextBox1.Text = dataReader1[0].ToString();
      ///  listPlanets.Items.Add(dataReader1["PlanetName"]);
      }
      
      // Очистка
      dataReader1.Close();
      connection1.Close();
     
        }
    }
}
