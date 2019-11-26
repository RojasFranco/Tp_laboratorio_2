using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Correo_UTN_por_Franco.Rojas._2c
{
    public partial class FormPrincipal : Form
    {
        private Correo correo;

        //Falta Exception en Insertar de PaqueteDAO y Mostrar
        public FormPrincipal()
        {
            InitializeComponent();
            correo = new Correo();
        }


        /*
         9. El método ActualizarEstados limpiará los 3 ListBox 
         y luego recorrerá la lista de paquetes agregando cada uno de ellos en el listado que corresponda.
         */
        private void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();
            foreach(Paquete paqueteEnCorreo in this.correo.Paquetes)
            {                
                switch (paqueteEnCorreo.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        this.lstEstadoIngresado.Items.Add(paqueteEnCorreo); 
                        break;
                    case Paquete.EEstado.EnViaje:
                        this.lstEstadoEnViaje.Items.Add(paqueteEnCorreo);                        
                        break;
                    case Paquete.EEstado.Entregado:
                        this.lstEstadoEntregado.Items.Add(paqueteEnCorreo);                        
                        break;
                    default:
                        break;
                }
            }
        }


        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            { 
                this.ActualizarEstados();
            }
        }

        /*
         3. El evento click del botón btnAgregar realizará las siguientes acciones en el siguiente orden:
             a. Creará un nuevo paquete y asociará al evento InformaEstado el método paq_InformaEstado. 
             b. Agregará el paquete al correo, controlando las excepciones que puedan derivar de dicha acción.
             c. Llamará al método ActualizarEstados.          
         */
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);            
            paquete.InformaEstado += paq_InformaEstado;
            try
            {
                correo += paquete;
            }
            catch(TrackingIdRepetidoException err)
            {
                MessageBox.Show(err.Message, "Paquete repetido", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            catch(Exception errorInsertando)
            {
                MessageBox.Show(errorInsertando.Message);
            }
            this.ActualizarEstados();
        }

        /*
        8. El método MostrarInformacion<T> evaluará que el atributo elemento no sea nulo y:
        a. Mostrará los datos de elemento en el rtbMostrar. 
        b. Utilizará el método de extensión para guardar los datos en un archivo llamado salida.txt
        */
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\salida.txt");
            }
        }

        private void BrnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
    }
}
