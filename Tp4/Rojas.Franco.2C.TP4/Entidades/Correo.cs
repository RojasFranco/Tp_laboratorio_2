using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private static List<Thread> mockPaquetes;
        private List<Paquete> paquetes;

        #region Propiedades

        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }

        #endregion

        /// <summary>
        /// Constructor Correo, instancia sus atributos
        /// </summary>
        public Correo()
        {
            mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

        /// <summary>
        /// Cierra todos los hilos que esten activos
        /// </summary>
        public void FinEntregas()
        {
            foreach(Thread hilo in mockPaquetes)
            {
                if(hilo!=null && hilo.IsAlive)
                {
                    hilo.Abort();
                }
            }
        }

        /// <summary>
        /// Muestra datos de la lista de paquetes
        /// </summary>
        /// <param name="elementos">elemento a castear por lista de paquetes</param>
        /// <returns>string con los datos de la lista</returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string retorno = string.Empty;
            Correo correoRecibido = (Correo)elementos;
            foreach(Paquete paquete in correoRecibido.Paquetes)
            {
                retorno+=string.Format("{0} para {1} ({2})\n\n", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString());
            }
            return retorno;
        }

        /// <summary>
        /// Agrega paquete al correo si es que no esta en el
        /// </summary>
        /// <param name="correo">correo donde agregar el paquete</param>
        /// <param name="paquete">paquete a agregar</param>
        /// <returns>Retorna el correo si lo pudo agregar, caso contrario lanza TrackingIdRepetidoException</returns>
        public static Correo operator +(Correo correo, Paquete paquete)
        {
            foreach(Paquete paqueteEnElCorreo in correo.Paquetes)
            {
                if(paqueteEnElCorreo==paquete)
                {
                    throw new TrackingIdRepetidoException(string.Format("El Tracking ID: {0} ya figura en la lista de envios", paquete.TrackingID));
                }
            }
            correo.paquetes.Add(paquete);

            Thread hilo = new Thread(new ThreadStart(paquete.MockCicloVida));
            mockPaquetes.Add(hilo);
            hilo.Start();

            return correo;
        }
    }
}
