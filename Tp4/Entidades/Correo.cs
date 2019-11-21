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

        public Correo()
        {
            mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }

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

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            StringBuilder sb = new StringBuilder();            
            Correo correoRecibido = (Correo)elementos;
            foreach(Paquete paquete in correoRecibido.Paquetes)
            {
                sb.AppendFormat("{0} para {1} ({2})\n\n", paquete.TrackingID, paquete.DireccionEntrega, paquete.Estado.ToString());
            }
            return sb.ToString();
        }


        /*
         c. Crear un hilo para el método MockCicloDeVida del paquete, y agregar dicho hilo a mockPaquetes.
         d. Ejecutar el hilo. 
         */
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
            //  NUNCA LLEGO AL CATCH
            //try
            //{
                Thread hilo = new Thread(new ThreadStart(paquete.MockCicloVida));
                mockPaquetes.Add(hilo);

                hilo.Start();
            //}
            //catch(Exception errorAlInsertar)
            //{
            //    throw errorAlInsertar;                
            //}

            return correo;
        }
    }
}
