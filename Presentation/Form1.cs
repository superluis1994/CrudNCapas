using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using common.Attributes;
using Domain.Crud;

namespace Presentation
{
    public partial class Form1 : Form
    { 
        /** Variables */
        CUsuario usuarios = new CUsuario();
        AttributesUsuario attributes = new AttributesUsuario();
        bool edit = false;
        public Form1()
        {
            InitializeComponent();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            txtId.Enabled = false;
        }
       
        private void getData()
        {
            CUsuario cUsario = new CUsuario();
            DvgDatos.DataSource = cUsario.Mostrar();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
          
            getData();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Normal)this.WindowState = FormWindowState.Maximized;
            else this.WindowState = FormWindowState.Normal;
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void guna2HtmlLabel5_Click(object sender, EventArgs e)
        {

        }
        private void ClearTxt()
        {
            txtId.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            dateFecha.Text = string.Empty;
        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            btnGuardar.Enabled = true;
            btnNuevo.Enabled = false;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (edit == false)
            {
                    //insertar
                try
                {
                    attributes.Nombre = txtNombre.Text.ToUpper();
                    attributes.Apellido = txtApellido.Text.ToUpper();
                    attributes.Correo_electronico = txtEmail.Text;
                    attributes.Fecha_nacimiento = dateFecha.Value;
                    usuarios.Insertar(attributes);
                    ClearTxt();
                    getData();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    MessageBox.Show( "SE GUADO UN REGISTRO DE FORMA EXITOSA", "INSERTADO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }catch (Exception ex) 
                {
                    MessageBox.Show( $" SE PRODUJO EL SIENTE ERROR: {ex.ToString()}", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                
                
            }
            else
            {
                //actualizar
                try
                {

                    attributes.Id =Convert.ToInt32(txtId.Text);
                    attributes.Nombre = txtNombre.Text.ToUpper();
                    attributes.Apellido = txtApellido.Text.ToUpper();
                    attributes.Correo_electronico = txtEmail.Text;
                    attributes.Fecha_nacimiento = dateFecha.Value;
                    usuarios.Modificar(attributes);
                    ClearTxt();
                    getData();
                    btnGuardar.Enabled = false;
                    btnNuevo.Enabled = true;
                    txtId.Enabled = true;
                    edit = false;
                    MessageBox.Show("SE ACTUALIZO UN REGISTRO DE FORMA EXITOSA", "ACTUALIZDO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    MessageBox.Show( $" SE PRODUJO EL SIENTE ERROR: {ex.ToString()}", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (DvgDatos.SelectedRows.Count>0)
            {
            txtId.Enabled = false;
            btnNuevo.Enabled=false;
            btnGuardar.Enabled = true;
            edit = true;
                //CARGAR DATOS
                txtId.Text = DvgDatos.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = DvgDatos.CurrentRow.Cells[1].Value.ToString();
                txtApellido.Text = DvgDatos.CurrentRow.Cells[2].Value.ToString();
                txtEmail.Text = DvgDatos.CurrentRow.Cells[3].Value.ToString();
                dateFecha.Text  = DvgDatos.CurrentRow.Cells[4].Value.ToString();

            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(DvgDatos.SelectedRows.Count >0)
            {
                DialogResult dialog =new DialogResult();
                dialog = MessageBox.Show("¿DESEAS ELIMINAR ESTE RESGITRO?", "ELIMINAR", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialog == DialogResult.Yes)
                {
                    try
                    {
                        attributes.Id =Convert.ToInt32( DvgDatos.CurrentRow.Cells[0].Value.ToString());
                        usuarios.Eliminar(attributes);
                        getData();
                        MessageBox.Show("REGISTRO ELIMINADO CORRECTAMENTE", "ELIMINANDO", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }catch (Exception ex)
                    {
                    MessageBox.Show( $" SE PRODUJO EL SIENTE ERROR: {ex.ToString()}", "Error", MessageBoxButtons.OK,MessageBoxIcon.Error);

                    }
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CUsuario cUsuario = new CUsuario();
            DvgDatos.DataSource = cUsuario.Buscar(txtBuscar.Text);
        }
    }
}
