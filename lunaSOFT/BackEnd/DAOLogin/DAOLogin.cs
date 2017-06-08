using lunaSOFT.Pojos.login;
using MySql.Data.MySqlClient;
using System;

namespace lunaSOFT.BackEnd.loginDAO
{

    class DAOLogin
    {
        clsConexion cn = new clsConexion();


        public void insertarUsuario(pojoLogin objPojo)
        {

            MySqlCommand cmd = new MySqlCommand();

            cn.abrirConexion();
            cmd.Connection = cn.Con;
            cmd.Parameters.AddWithValue("@idUser", null);
            cmd.Parameters.AddWithValue("@user", objPojo.usuario);
            cmd.Parameters.AddWithValue("@password", objPojo.contraseña);
            cmd.Parameters.AddWithValue("@rol", objPojo.rol);

            String sql = "INSERT INTO login ( idUsuario, usuario ,contraseña ,rol) VALUES ( @idUser, @user , @password, @rol)";//isertar datos
            cmd.CommandText = sql;

            cmd.ExecuteNonQuery();

            cn.cerrarConexion();
        }
    }     
        
    }

