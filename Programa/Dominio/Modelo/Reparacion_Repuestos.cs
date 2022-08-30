using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Reparacion_Repuestos
    {
        private int _idreparacion;
        private int _anio;
        private string _repuestocod;
        private int _cantidad;
        private double _costounitario;

        #region Getters & Setters
        public int IdReparacion { get => _idreparacion; set => _idreparacion = value; }
        public int Anio { get => _anio; set => _anio = value; }
        public string RepuestoCod { get => _repuestocod; set => _repuestocod = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public double CostoUnitario { get => _costounitario; set => _costounitario = value; }
        #endregion

        public Reparacion_Repuestos()
        {

        }

        public Reparacion_Repuestos(int pIdReparacion, int pAnio, string pRepuestoCod, int pCantidad, double pCostoUnitario)
        {
            _idreparacion = pIdReparacion;
            _anio = pAnio;
            _repuestocod = pRepuestoCod;
            _cantidad = pCantidad;
            _costounitario = pCostoUnitario;
        }

        public override string ToString()
        {
            return $"{IdReparacion} {Anio} {RepuestoCod} {Cantidad} {CostoUnitario}";
        }
    }
}
