using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Consultas
{
    public class FiltroFechaListaReparacion : FiltroFechaListaPendiente
    {
        private double _costototal;

        #region Getters & Setters
        public double CostoTotal { get => _costototal; set => _costototal = value; }
        #endregion

        public FiltroFechaListaReparacion() { }

        public FiltroFechaListaReparacion(string pCliNom, string pMatricula, DateTime pFecha, double pCostoTotal) : 
            base(pCliNom, pMatricula, pFecha)
        {
            _costototal = pCostoTotal;
        }

        public override string ToString()
        {
            return $"{CliNom} {Matricula} {Fecha.ToString("d")} ${CostoTotal}";
        }
    }
}
