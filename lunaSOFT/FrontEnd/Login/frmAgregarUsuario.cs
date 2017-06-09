using System;
using System.Windows.Forms;
using lunaSOFT.FrontEnd.Login;
using System.Drawing;
using lunaSOFT.Pojos.login;
using lunaSOFT.BackEnd.loginDAO;

namespace lunaSOFT.FrontEnd.Login
{
    public partial class frmAgregarUsuario : Form
    {


        public frmAgregarUsuario()
        {
            InitializeComponent();
        }

        private void frmAgregarUsuario_Load(object sender, EventArgs e)
        {
            cbxRol.SelectedIndex = 0;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.Enter)
            {
                cbxRol.Focus();
            }
        }

       

        private void cbxRol_SelectedValueChanged(object sender, EventArgs e)
        {
            btnRegistrar.Focus();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (txtUsuario.Text != "Usuario" && txtContraseña.Text != "Contraseña")
            {
            frmConfirmar objConfirmar = new frmConfirmar();
            String user = "", password = "", rol = "";

            user = txtUsuario.Text;
            password =txtContraseña.Text;
            rol = "" + cbxRol.SelectedItem;

            objConfirmar.recuperarDatos(user, password, rol);
            objConfirmar.MdiParent = this.MdiParent;   //con esta linea se mete dentro del mdi parent
            objConfirmar.Show();
            this.Close();
            }else
            {
                MessageBox.Show("Rellene correctamente los campos Usuario y Contraseña!", "Info!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        

        private void cbxRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Contraseña")
            {
                txtContraseña.UseSystemPasswordChar = false;
            }
        }

        private void cbxRol_Click(object sender, EventArgs e)
        {
            if (txtContraseña.Text == "Contraseña")
            {
                txtContraseña.UseSystemPasswordChar = false;
            }
        }
    }

}
