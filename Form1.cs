using System;
using System.Windows.Forms;

namespace TP_4___Ejercicio_1___Hospital
{
    public partial class Form1 : Form
    {
        Class_Lista HospitalLista = new Class_Lista();

        Nodo nodoSeleccionado;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           //txtCodigo.Text = "";
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            HospitalLista.AgregarAlPrincipio(this.txtNombre.Text, this.txtApellido.Text,this.txtDireccion.Text,this.txtTelefono.Text);
            GenerarLista();

            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
                

        }
    

        private void GenerarLista()
        {
            this.listaNodos.Items.Clear();
            Listar(HospitalLista.NodoInicial);
        }

        private void Listar(Nodo nodo)
        {
            if (nodo != null)
            {
                listaNodos.Items.Add(nodo);

                if (nodo.Siguiente != null)
                    Listar(nodo.Siguiente);
            }
        }

        private void GenerarListaGrid()
        {
            this.dataGridView.Rows.Clear();
            ListarGrid(HospitalLista.NodoInicial);
        }

        private void ListarGrid(Nodo nodo)
        {
            if (nodo != null)
            {
                
                this.dataGridView.Rows.Add(nodo.Codigo, nodo.Nombre, nodo.Apellido,nodo.Direccion,nodo.Telefono);


                if (nodo.Siguiente != null)
                    ListarGrid(nodo.Siguiente);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listaNodos_SelectedIndexChanged(object sender, EventArgs e)
        {
            nodoSeleccionado = (Nodo)this.listaNodos.SelectedItem;
            txtNombre.Text = nodoSeleccionado.Nombre;
            txtApellido.Text = nodoSeleccionado.Apellido;
            txtDireccion.Text = nodoSeleccionado.Direccion;
            txtTelefono.Text = nodoSeleccionado.Telefono;
        }


        private void btnRegsitroAlFinal_Click(object sender, EventArgs e)
        {
            HospitalLista.AgregarAlFinal(this.txtNombre.Text, this.txtApellido.Text, this.txtDireccion.Text, this.txtTelefono.Text);
            GenerarLista();

            txtNombre.Text = "";
            txtApellido.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (nodoSeleccionado != null)
            {

                HospitalLista.ActualizarNodo(nodoSeleccionado.Codigo, this.txtNombre.Text, this.txtApellido.Text, this.txtDireccion.Text, this.txtTelefono.Text);

                //HospitalLista.AgregarAlFinal(this.txtNombre.Text, this.txtApellido.Text, this.txtDireccion.Text, this.txtTelefono.Text);
                GenerarLista();

                txtNombre.Text = "";
                txtApellido.Text = "";
                txtDireccion.Text = "";
                txtTelefono.Text = "";
                GenerarLista();
            }

            else
                MessageBox.Show("debe seleccionar un nodo.");
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            listaNodos.Visible = false;
            dataGridView.Visible = true;
            BtnCerrarListado.Visible = true;
            GenerarListaGrid();

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (nodoSeleccionado != null)
            {
                HospitalLista.QuitarPosicion(nodoSeleccionado.Codigo);
                GenerarLista();
            }

            else
                MessageBox.Show("debe seleccionar un nodo.");
        }

        private void BtnCerrarListado_Click(object sender, EventArgs e)
        {
            listaNodos.Visible = true;
            dataGridView.Visible = false;
            BtnCerrarListado.Visible = false;
            GenerarLista();
        }




    }
}

