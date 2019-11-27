using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        private string direccionEntrega;
        private EEstado estado;
        private string trackingID;

        // Delegado y evento para informar cuando haya error al insertar en base de datos
        public delegate void DelegadoErrorInsertar(Exception error);
        public event DelegadoErrorInsertar InformaError;

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

        /// <summary>
        /// Tipos de estados del paquete
        /// </summary>
        public enum EEstado
        {
            Ingresado,
            EnViaje,
            Entregado
        }

        #region Propiedades

        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }

        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }

        public string TrackingID
        {
            get { return this.trackingID; }
            set { this.trackingID = value; }
        }

        #endregion

        /// <summary>
        /// Constructor de paquete
        /// </summary>
        /// <param name="direccionEntrega">Direccion de entrega</param>
        /// <param name="trackingID">Id del paquete</param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }

        /// <summary>
        /// Va cambiando e informando el estado del paquete hasta llegar a entregado. Al final guarda en base de datos
        /// </summary>
        public void MockCicloVida()
        {            
            while(this.estado != EEstado.Entregado)
            {
                Thread.Sleep(4000);                
                switch (this.estado)
                {
                    case EEstado.Ingresado:
                        this.estado = EEstado.EnViaje;
                        break;
                    case EEstado.EnViaje:
                        this.estado = EEstado.Entregado;
                        break;
                }
                this.InformaEstado.Invoke(this.estado, EventArgs.Empty);
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception errorAlInsertar)
            {
                this.InformaError(errorAlInsertar);
            }

        }

         /// <summary>
         /// Muestra los datos del elemento casteandolo a paquete
         /// </summary>
         /// <param name="elemento">elemento a mostrar</param>
         /// <returns>string con los datos del elemento</returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete paqueteMostrar = (Paquete)elemento;
            return string.Format("{0} para {1}\n", paqueteMostrar.TrackingID, paqueteMostrar.DireccionEntrega);           
        }

        /// <summary>
        /// Retorna los datos del paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos(this);            
        }

        #region Sobrecargas
        /// <summary>
        /// Compara dos paquetes
        /// </summary>
        /// <param name="paquete1">Primer paquete</param>
        /// <param name="paquete2">Segundo paquete</param>
        /// <returns>True si coinciden sus id, false caso contrario</returns>
        public static bool operator ==(Paquete paquete1, Paquete paquete2)
        {
            if(paquete1.TrackingID == paquete2.TrackingID)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Compara dos paquetes
        /// </summary>
        /// <param name="paquete1">Primer paquete</param>
        /// <param name="paquete2">Segundo paquete</param>
        /// <returns>False si coinciden sus id, true caso contrario</returns>
        public static bool operator !=(Paquete paquete1, Paquete paquete2)
        {
            return !(paquete1==paquete2);
        }



        #region //PARA WARNINGS
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        #endregion        

        #endregion
    }
}
