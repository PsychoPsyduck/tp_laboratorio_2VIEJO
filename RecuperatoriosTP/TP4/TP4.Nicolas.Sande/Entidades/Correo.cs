﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> mockPaquetes;
        private List<Paquete> paquetes;
        /// <summary>
        /// 
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        /// <summary>
        /// 
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread t in this.mockPaquetes)
            {
                if (t.IsAlive)
                {
                    t.Abort();
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementos"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            List<Paquete> listPaquetes = (List<Paquete>)((Correo)elementos).paquetes;
            StringBuilder retorno = new StringBuilder();

            foreach (Paquete p in listPaquetes)
            {
                retorno.AppendFormat("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }

            return retorno.ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete paquete in c.Paquetes)
            {
                if (paquete.DireccionEntrega == p.DireccionEntrega)
                {
                    throw new TrackingIdRepetidoException("El trackingID ya figura en lista");
                }
            }
            c.Paquetes.Add(p);
            //thread
            Thread threadPaquete = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(threadPaquete);
            threadPaquete.Start();
            return c;
        }
        /// <summary>
        /// 
        /// </summary>
        public List<Paquete> Paquetes
        {
            get
            {
                return this.paquetes;
            }
            set
            {
                this.paquetes = value;
            }
        }
    }
}
