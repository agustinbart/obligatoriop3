using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo
{
    public class Repuesto
    {
        private string _codigo;
        private string _descripcion;
        private double _costo;
        private string _tipo;
        private string _rutproveedor;

        #region Getters & Setters
        public string Codigo { get => _codigo; set => _codigo = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public double Costo { get => _costo; set => _costo = value; }
        public string Tipo { get => _tipo; set => _tipo = value; }
        public string RUTProveedor { get => _rutproveedor; set => _rutproveedor = value; }
        #endregion

        public Repuesto()
        {

        }

        public Repuesto(string pCodigo, string pDescripcion, double pCosto, string pTipo, string pRUTProveedor)
        {
            _codigo = pCodigo;
            _descripcion = pDescripcion;
            _costo = pCosto;
            _tipo = pTipo;
            _rutproveedor = pRUTProveedor;
        }

        public override string ToString()
        {
            return $"{Codigo} {Descripcion} ${Costo} {RUTProveedor}";
        }

    }
}
