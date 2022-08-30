using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo
{
    public class Proveedor
    {
        private string _rut;
        private string _nombre;
        private string _telefono;
        private string _mail;

        #region Getters & Setters
        public string RUT { get => _rut; set => _rut = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Mail { get => _mail; set => _mail = value; }
        #endregion

        public Proveedor()
        {

        }
        public Proveedor(string pRUT, string pNombre, string pMail, string pTelefono)
        {
            _rut = pRUT;
            _nombre = pNombre;
            _mail = pMail;
            _telefono = pTelefono;
        }

        public override string ToString()
        {
            return $"{RUT} {Nombre} {Telefono} {Mail}";
        }
    }
}
