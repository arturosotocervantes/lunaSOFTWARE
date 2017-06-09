using lunaSOFT.BackEnd;
using lunaSOFT.BackEnd.loginDAO;
using lunaSOFT.Pojos.login;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace lunaSOFT.FrontEnd.Login
{
    public partial class frmConfirmar : Form
    {
        clsConexion cn = new clsConexion();
        pojoLogin objPojo = new pojoLogin();
        DAOLogin objDAO = new DAOLogin();
        MySqlCommand cmd;
        String user = "", password = "", rol = "";
        public frmConfirmar()
        {
            InitializeComponent();
        }



        /// Encripta una cadena

        public static string encriptarPassword(string originalPassword)
        {
            SHA1 sha1 = SHA1Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha1.ComputeHash(encoding.GetBytes(originalPassword));
            for (int i = 0; i < stream.Length; i++) sb.AppendFormat("{0:x2}", stream[i]);
            return sb.ToString();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                cn.abrirConexion();
                cmd = cn.mysql_Command();
                cmd.Connection = cn.Con;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al establecer la conexion a la base de datos!", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (txtContraseña.Text != "Contraseña" && txtUsuario.Text != "Usuario")
            {
                try
                {
                    String user = txtUsuario.Text;
                    String password = txtContraseña.Text;
                    String usuario = "", contraseña = "", rol = "";

                    cmd.CommandText = "select usuario from login where usuario='" + user + "' and contraseña=sha1(" + password + ")";
                    if (cmd.ExecuteScalar() != null)
                    {
                        usuario = (cmd.ExecuteScalar().ToString());
                    }

                    cmd.CommandText = "select contraseña from login where usuario='" + user + "' and contraseña=sha1(" + password + ")";
                    if (cmd.ExecuteScalar() != null)
                    {
                        contraseña = (cmd.ExecuteScalar().ToString());

                    }

                    cmd.CommandText = "select rol from login where usuario='" + user + "' and contraseña=sha1(" + password + ")";
                    if (cmd.ExecuteScalar() != null)
                    {
                        rol = (cmd.ExecuteScalar().ToString());
                    }
                    cn.cerrarConexion();

                    if (user == usuario && encriptarPassword(password) == contraseña && rol == "GERENTE ADMINISTRATIVO")
                    {
                        objPojo.usuario = this.user;
                        objPojo.contraseña = encriptarPassword(this.password);
                        objPojo.rol = this.rol.ToUpper();
                        objDAO.insertarUsuario(objPojo);//METODO

                        MessageBox.Show("Usuario registrado con exito", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        this.Close();

                    }
                    else
                    {
                        MessageBox.Show("Usuario no registrado como Administrador Generar...", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ingrese correctamente Usuario y Contraseña!", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }else
            {
                MessageBox.Show("Rellena correctamente los campos Usuario y Contraseña!", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

        private void frmConfirmar_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            txtUsuario.GotFocus += new EventHandler(this.TextGotFocusUsuario);
            txtUsuario.LostFocus += new EventHandler(this.TextLostFocusUsuario);

            txtContraseña.GotFocus += new EventHandler(this.TextGotFocusContraseña);
            txtContraseña.LostFocus += new EventHandler(this.TextLostFocusContraseña);
        }


        public void TextGotFocusUsuario(object sender, EventArgs e)
        {
            if (txtUsuario.Text == "Usuario")
            {
                txtUsuario.Text = "";
                txtUsuario.ForeColor = Color.Black;

            }
        }

        public void TextLostFocusUsuario(object sender, EventArgs e)
        {

            if (txtUsuario.Text == "")
            {
                txtUsuario.Text = "Usuario";
                txtUsuario.ForeColor = Color.DimGray;

            }
        }


        public void TextGotFocusContraseña(object sender, EventArgs e)
        {


            if (txtContraseña.Text == "Contraseña")
            {
                txtContraseña.Text = "";
                txtContraseña.ForeColor = Color.Black;
            }
        }

        public void TextLostFocusContraseña(object sender, EventArgs e)
        {

            if (txtContraseña.Text == "")
            {
                txtContraseña.Text = "Contraseña";
                txtContraseña.ForeColor = Color.DimGray;

            }
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Contraseña")
            {
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

            if (txtContraseña.Text == "")
            {
                txtContraseña.UseSystemPasswordChar = true;
            }
        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Contraseña")
            {
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                txtContraseña.Focus();
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnConfirmar_Click(sender, e);
            }
        }

        public void recuperarDatos(String user, String password, String rol)
        {

            this.user = user;
            this.password = password;
            this.rol = rol;


        }
    }
}
