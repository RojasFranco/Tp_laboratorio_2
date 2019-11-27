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
        public FormPrincipal()
        {
            InitializeComponent();
            correo = new Correo();
        }

         /// <summary>
         /// Limpia las tres listas que muestran los estados del paquete
         /// </summary>
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

        /// <summary>
        /// Llama al mismo metodo desde el hilo que lo creo, y luego llama al metodo actualizarEstados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

         /// <summary>
         /// Agrega el paquete al correo, si hay error lo informa con un Messagebox
         /// </summary>
         /// <param name="sender"></param>
         /// <param name="e"></param>
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paquete = new Paquete(this.txtDireccion.Text, this.mtxtTrackingID.Text);            
            paquete.InformaEstado += paq_InformaEstado;            
            paquete.InformaError += ManejadorError;// PARA MANEJAR ERROR AL INSERTAR EN BD
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

        /// <summary>
        /// Informa el error a traves de messageBox
        /// </summary>
        /// <param name="errorRecibido">Error capturado</param>
        private void ManejadorError(Exception errorRecibido)
        {
            MessageBox.Show(errorRecibido.Message, "Error en la carga de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Muestra informacion del elemento
        /// </summary>
        /// <typeparam name="T">Clase a mostrar</typeparam>
        /// <param name="elemento">elemento a mostrar</param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);
                this.rtbMostrar.Text.Guardar(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\salida.txt");
            }
        }

        /// <summary>
        /// Muestar todos los paquetes del correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BrnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Muestra informacion del paquete que se selecciono con click derecho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        /// <summary>
        /// Llama al metodo finEntregas de correo para cerrar hilos activos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
    }
}
