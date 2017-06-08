using System;
using System.Drawing;
using System.Windows.Forms;
using lunaSOFT.FrontEnd.Login;
using MySql.Data.MySqlClient;
using lunaSOFT.BackEnd;
using System.Security.Cryptography;
using System.Text;

namespace lunaSOFT
{
    public partial class frmLogin : Form
    {

        clsConexion cn = new clsConexion();
        MySqlCommand cmd;

        public frmLogin()
        {
            InitializeComponent();
        }


        private void login_Load(object sender, EventArgs e)
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
                //txtContraseña.ForeColor = Color.LightGray;
                txtContraseña.ForeColor = Color.DimGray;

            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "")
            {
                txtContraseña.UseSystemPasswordChar = true;
            }

        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {

            if (txtContraseña.Text == "Contraseña")
            {
                txtContraseña.UseSystemPasswordChar = false;
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

        private void btnIngresar_Click(object sender, EventArgs e)
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

            try
            {
                String user = txtUsuario.Text;
                String password = txtContraseña.Text;
                String usuario = "", contraseña = "", rol = "";

                cmd.CommandText = "select usuario from login where usuario='" + user + "'";
                if (cmd.ExecuteScalar() != null)
                {
                    usuario = (cmd.ExecuteScalar().ToString());
                }

                cmd.CommandText = "select contraseña from login where contraseña='" + encriptarPassword(password)+ "'";
                if (cmd.ExecuteScalar() != null)
                {
                    contraseña = ""+(cmd.ExecuteScalar());
                    
                }

                cmd.CommandText = "select rol from login where usuario='" + user + "'";
                if (cmd.ExecuteScalar() != null)
                {
                    rol = (cmd.ExecuteScalar().ToString());
                }

                cn.cerrarConexion();

                
                if (user == usuario && encriptarPassword(password) == contraseña)
                {
                    
                    if (rol == "GERENTE ADMINISTRATIVO")
                    {
                        MessageBox.Show("Bienvenido GERENTE ADMINISTRATIVO");
                    }
                    else if (rol == "GERENTE OPERATIVO")
                    {
                        MessageBox.Show("Bienvenido GERENTE OPERATIVO");
                    }
                    else if (rol == "OPERATIVO")
                    {
                        MessageBox.Show("Bienvenido OPERATIVO");
                    }
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña Invalidos...", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ingrese correctamente Usuario y Contraseña!", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                btnIngresar_Click(sender, e);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            new frmAgregarUsuario().Show();
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
