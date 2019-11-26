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

        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;

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

        public Paquete(string direccionEntrega, string trackingID)
        {
            this.DireccionEntrega = direccionEntrega;
            this.TrackingID = trackingID;
            this.Estado = EEstado.Ingresado;
        }

        /*                        
        5. MockCicloDeVida hará que el paquete cambie de estado de la siguiente forma:
        a. Colocar una demora de 4 segundos. 
        b. Pasar al siguiente estado.
        c. Informar el estado a través de InformarEstado. EventArgs no tendrá ningún dato extra. 
        d. Repetir las acciones desde el punto A hasta que el estado sea Entregado. 
        e. Finalmente guardar los datos del paquete en la base de datos 

        */
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
                throw errorAlInsertar;
            }

        }



        /*  VEEEEEEEEEEEEEEEEEEER
        2. MostrarDatos utilizará string.Format con el siguiente formato
        "{0} para {1}", p.trackingID, p.direccionEntrega para compilar la información del paquete. 

         */
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            Paquete paqueteMostrar = (Paquete)elemento;
            return string.Format("{0} para {1}", paqueteMostrar.TrackingID, paqueteMostrar.DireccionEntrega);           
        }


        public override string ToString()
        {
            return this.MostrarDatos(this);            
        }

        #region Sobrecargas

        public static bool operator ==(Paquete paquete1, Paquete paquete2)
        {
            if(paquete1.TrackingID == paquete2.TrackingID)
            {
                return true;
            }
            return false;
        }

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
