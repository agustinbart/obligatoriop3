using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo
{
    public class Cliente : Usuario
    {
        private DateTime _fecharegistro;
        private string _contrasena;

        #region Getters & Setters
        public DateTime FechaRegistro { get => _fecharegistro; set => _fecharegistro = value; }
        public string Contrasena { get => _contrasena; set => _contrasena = value; }
        #endregion

        public Cliente(int pId, string pNombre, string pCedula, string pTelefono, string pDireccion, string pMail, DateTime pFechaRegistro, string pContrasena) :
            base(pId, pNombre, pCedula, pTelefono, pDireccion, pMail)
        {
            _fecharegistro = pFechaRegistro;
            _contrasena = pContrasena;
        }

        public Cliente()
        {

        }

        public override string ToString()
        {
            return $"{Id} {Nombre} {Cedula} {Telefono} {Direccion} {Mail} {FechaRegistro.ToString("d")} {Contrasena}";
        }
    }
}
