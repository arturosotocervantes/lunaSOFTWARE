using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace lunaSOFT.BackEnd
{
    class clsConexion
    {
        MySqlConnection cn = new MySqlConnection();

        public void abrirConexion()
        {
            string strCadenaConexion;
            strCadenaConexion = "SERVER=localhost ; PORT=3306; DATABASE=lunasoft; UID= root; PWD= ";
            cn.ConnectionString = strCadenaConexion;
            cn.Open();
        }

        public MySqlCommand mysql_Command()
        {
            MySqlCommand cmd = new MySqlCommand();
            return cmd;

        }

        public void cerrarConexion()
        {
            cn.Close();
        }

        public MySqlConnection Con
        {
            get { return this.cn; }
        }

    }
}
