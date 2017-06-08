using lunaSOFT.BackEnd;
using lunaSOFT.Pojos;
using System;
using System.Windows.Forms;

namespace lunaSOFT.FrontEnd
{
    public partial class frmCatalogoCliente : Form
    {
        DAOClientes objDAOCliente = new DAOClientes();
        pojoClientes pCliente;
        public frmCatalogoCliente()
        {
            InitializeComponent();
        }

       

        

       

        private void frmCatalogoCliente_Load(object sender, EventArgs e)
        {
            this.dvgClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dvgClientes.MultiSelect = false;
            cargar();
        }


        public void cargar()
        {
            objDAOCliente = new DAOClientes();
            dvgClientes.DataSource = objDAOCliente.mostrar();

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            bool bandera = true;
            do
            {
                string inputCliente = Microsoft.VisualBasic.Interaction.InputBox("Nombre del cliente", "Cliente", "", -1, -1);

                if (inputCliente != "")
                {
                    pCliente = new pojoClientes();
                    pCliente.Nombre = inputCliente;
                    if (!objDAOCliente.verificar(pCliente.Nombre))
                    {
                        if (objDAOCliente.insertarCliente(pCliente))
                        {
                            MessageBox.Show("Cliente registrado");
                            bandera = false;
                        }
                        else
                            MessageBox.Show("ERROR");
                    }
                    else
                        MessageBox.Show("Ya existe ese cliente en el sistema");

                }
                else
                    bandera = false;

            } while (bandera);
            frmCatalogoCliente_Load(this, e);
        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            int idCliente = int.Parse(dvgClientes.CurrentRow.Cells[0].Value.ToString());
            string nombre = dvgClientes.CurrentRow.Cells[1].Value.ToString();
            string inputCliente = Microsoft.VisualBasic.Interaction.InputBox("Nombre del cliente", "Editando cliente", nombre, -1, -1);



            if (inputCliente != "")
            {
                MessageBox.Show(idCliente + "");
                pCliente = new pojoClientes();
                pCliente.IdCliente = idCliente;
                pCliente.Nombre = inputCliente;
                if (objDAOCliente.editar(pCliente))
                {
                    MessageBox.Show("Actualizado correctamente");
                    frmCatalogoCliente_Load(this, e);
                }
                else
                    MessageBox.Show("MA FACKING LIFE");
            }
            else
                MessageBox.Show("no se hizo ningun cambio");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DAOClientes objcl = new DAOClientes();
            if (MessageBox.Show("Estas seguro que desas eliminar", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string valor = dvgClientes.CurrentRow.Cells[0].Value.ToString();

                if (objDAOCliente.eliminar(int.Parse(valor)))
                {
                    MessageBox.Show("Elimando con éxito");
                    frmCatalogoCliente_Load(this, e);
                }
                else
                    MessageBox.Show("ERROR");
            }
        }



       

        public void buscar()
        {
            dvgClientes.DataSource = objDAOCliente.buscar(txtBuscar.Text);
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            buscar();
        }
    }
}
