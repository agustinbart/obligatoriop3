using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Consultas
{
    public class FiltroFechaListaPendiente
    {
        private string _clinom;
        private string _matricula;
        private DateTime _fecha;

        #region Getters & Setters
        public string CliNom { get => _clinom; set => _clinom = value; }
        public string Matricula { get => _matricula; set => _matricula = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        #endregion

        public FiltroFechaListaPendiente() { }

        public FiltroFechaListaPendiente(string pCliNom, string pMatricula, DateTime pFecha)
        {
            _clinom = pCliNom;
            _matricula = pMatricula;
            _fecha = pFecha;
        }

        public override string ToString()
        {
            return $"{CliNom} {Matricula} {Fecha.ToString("d")}";
        }
    }
}
