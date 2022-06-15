using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APPEK2.DB
{
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        // Constructor
        public DBConnect()
        {
            Initialize();       // prilikom kreiranja klase DBConnect unutar konstruktora pokrece se metoda za ostvarivanje veze prema bazi podataka
        }

        // Initialize values
        private void Initialize()       // definira se metoda initialize()
        {
            server = "ucka.veleri.hr";
            database = "vbognolo";
            uid = "vbognolo";
            password = "11";

            string connectionString;        // pohrana svih podataka unutar 1 varijable
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);     // svi podaci se salju klasi MySqlConnection a istance se spremaju u objekt connection
        }

        // Open connection to database
        private string OpenConnection()
        {
            try
            {
                connection.Open();      // pokusava se pozvati konekcija kroz objekt connection preko metode open()
                return "";      // ako uspije vraca se prazan string
            }
            catch (MySqlException ex)       // ako ne uspije, trazi se greska
            {

                switch (ex.Number)      // ako je greska 0..., ako je 1045...
                {
                    case 0:
                        return "Cannot connect to server.  Contact administrator";

                    case 1045:
                        return "Invalid username/password, please try again";
                }
                return "Error";
            }
        }       // koristenje try-catch da ne pukne program

        // Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();         // pokusava se zatvoriti veza prema bazi
                return true;        
            }
            catch (MySqlException ex)       // ako ne uspije, vrati false
            {
                return false;
            }
        }

        // Insert statement
        public void Insert(string Sql)         // punjenje baze podataka
        {
            if (this.OpenConnection() == "")       // ako je konekcija otvorena, vraca se prazan string
            {
                MySqlCommand mySql = new MySqlCommand(Sql, connection);     //  u objekt se sprema sql naredba i veza prema bazi (connection) -- kreiranje objekta za izvrsavanje sql naredbi
                mySql.ExecuteNonQuery();    // izvrsavanje sql naredbe
                this.CloseConnection();     // this se odnosi na klasu (DBConnect)
            }
        }

        // Update statement
        public void Update(string Sql)
        {
            if (this.OpenConnection() == "")
            {
                MySqlCommand cmd = new MySqlCommand(Sql, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        // Delete statement
        public void Delete(string sql)
        {
            if (this.OpenConnection() == "")
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }

        // Select statement
        public MySqlDataReader Select(string sql)
        {
            if(this.OpenConnection() == "")
            {
                MySqlCommand cmd = new MySqlCommand(sql, connection);       // pohrana sql naredbe i veze prema bazi u objekt cmd
                MySqlDataReader data = cmd.ExecuteReader();         // izvrsava se naredba i rezultat se sprema u objekt data
                return data;    
            }

            return null;    // ako se ne otvori konekcija
        }

    }
}