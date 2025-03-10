﻿using System;
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
    public bool online;
    public int playerIndex;

    public DatabaseHelper()
    {
        con = new MySqlConnection(connectionString);
    }

    //Executes a sql query with opening a connection
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

    //Executes a sql query without opening a connection
    //Used in database code where a connection has already been opened
    public void ExecuteClosedQuery(string query)
    {
        try
        {
            string sql = query;

            MySqlScript script = new MySqlScript(con, sql);
            script.Execute();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
    }
}

