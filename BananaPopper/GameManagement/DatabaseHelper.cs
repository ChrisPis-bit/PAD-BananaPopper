using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;


class DatabaseHelper
{
    //This class handles repeated database code, like query's

    string connectionString = "server=oege.ie.hva.nl;user=mult;database=zmult;port=3306;password=hyxjnFq3hznpHMf+";
    public MySqlConnection con;

    public DatabaseHelper()
    {
        con = new MySqlConnection(connectionString);
    }

    public void ExecuteQuery(string query)
    {
        try
        {
            con.Open();

            string sql = query;

            MySqlScript script = new MySqlScript(con, sql);
            script.Execute();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        con.Close();
    }
}

