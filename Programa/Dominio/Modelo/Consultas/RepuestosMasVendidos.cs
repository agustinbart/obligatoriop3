using Dominio.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Consultas
{
    public class RepuestosMasVendidos : Repuesto
    {
        private int _cantidad;

        #region Getters & Setters
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        #endregion

        public RepuestosMasVendidos() { }

        public RepuestosMasVendidos(string pCodigo, string pDescripcion, double pCosto, string pTipo, string pRUTProveedor, int pCantidad):
            base(pCodigo, pDescripcion, pCosto, pTipo, pRUTProveedor)
        {
            _cantidad = pCantidad;
        }

        public override string ToString()
        {
            return $"{Codigo} {Descripcion} {Cantidad}";
        }
    }
}
