using lunaSOFT.Pojos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lunaSOFT.BackEnd
{
    class DAOClientes
    {

        clsConexion conexion = new clsConexion();

        public bool insertarCliente(pojoClientes pojoCliente)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                conexion.abrirConexion();
                cmd.Connection = conexion.Con;
                cmd.CommandText = "INSERT INTO clientes (nombre) VALUES (@cliente)";
                cmd.Parameters.AddWithValue("@cliente", pojoCliente.Nombre);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public bool verificar(string cliente)
        {
            try
            {
                string sql = "";
                MySqlCommand cm = new MySqlCommand();
                MySqlDataReader dr;
                conexion.abrirConexion();
                sql = "select nombre from clientes where nombre= '" + cliente + "'";
                cm.CommandText = sql;
                cm.CommandType = CommandType.Text;
                cm.Connection = conexion.Con;
                dr = cm.ExecuteReader();

                if (dr.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }

        public bool editar(pojoClientes pCliente)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                clsConexion conexion = new clsConexion();
                conexion.abrirConexion();
                cmd.Parameters.AddWithValue("@idCliente", pCliente.IdCliente);
                cmd.Parameters.AddWithValue("@nombre", pCliente.Nombre);
                String mysql = "update clientes set nombre=@nombre where idclientes=@idCliente";

                cmd.CommandText = mysql;
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conexion.Con;
                cmd.ExecuteNonQuery();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conexion.cerrarConexion();
            }

        }

        public DataTable mostrar()
        {
            try
            {

                DataTable datos = new DataTable();
                conexion.abrirConexion();

                MySqlCommand cm = new MySqlCommand("select idclientes,nombre from clientes", conexion.Con);
                MySqlDataAdapter ad = new MySqlDataAdapter(cm);
                DataSet ds = new DataSet();

                ad.Fill(ds, "Clientes");
                datos = ds.Tables["Clientes"];
                ad.Dispose();
                cm.Dispose();

                return datos;
            }
            catch
            {
                return null;
            }
            finally
            {
                conexion.cerrarConexion();
            }

        }

        public bool eliminar(int idCliente)
        {
            try
            {
                conexion.abrirConexion();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = conexion.Con;
                cmd.CommandText = "delete from clientes where idclientes = " + idCliente;
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                conexion.cerrarConexion();
            }

        }

        public DataTable buscar(string nombre)
        {
            try
            {
                DataTable datos = new DataTable();
                conexion.abrirConexion();

                MySqlCommand cm = new MySqlCommand("select * from clientes where nombre LIKE '" + nombre + "%'", conexion.Con);
                MySqlDataAdapter ad = new MySqlDataAdapter(cm);
                DataSet ds = new DataSet();

                ad.Fill(ds, "Clientes");
                datos = ds.Tables["Clientes"];
                ad.Dispose();
                cm.Dispose();

                return datos;
            }
            catch
            {
                return null;
            }
            finally
            {
                conexion.cerrarConexion();
            }
        }
    }
}
