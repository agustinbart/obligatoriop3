using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Reparacion_Horas
    {
        private int _idreparacion;
        private int _anio;
        private int _idmecanico;
        private int _horas;
        private int _costohora;

        #region Getters y Setters
        public int IdReparacion { get => _idreparacion; set => _idreparacion = value; }
        public int Anio { get => _anio; set => _anio = value; }
        public int IdMecanico { get => _idmecanico; set => _idmecanico = value; }
        public int Horas { get => _horas; set => _horas = value; }
        public int CostoHora { get => _costohora; set => _costohora = value; }

        #endregion

        public Reparacion_Horas()
        {

        }

        public Reparacion_Horas(int pIdReparacion, int pAnio, int pIdMecanico, int pHoras, int pCostoHora)
        {
            _idreparacion = pIdReparacion;
            _anio = pAnio;
            _idmecanico = pIdMecanico;
            _horas = pHoras;
            _costohora = pCostoHora;
        }

        public override string ToString()
        {
            return $"{IdReparacion} {Anio} {IdMecanico} {Horas} {CostoHora}";
        }
    }
}
