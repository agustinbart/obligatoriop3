using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo
{
    public class Usuario
    {
        private int _id;
        private string _nombre;
        private string _cedula;
        private string _telefono;
        private string _direccion;
        private string _mail;

        #region Getters & Setters
        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Cedula { get => _cedula; set => _cedula = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Direccion { get => _direccion; set => _direccion = value; }
        public string Mail { get => _mail; set => _mail = value; }
        #endregion

        public Usuario(int pId, string pNombre, string pCedula, string pTelefono, string pDireccion, string pMail)
        {
            _id = pId;
            _nombre = pNombre;
            _cedula = pCedula;
            _telefono = pTelefono;
            _direccion = pDireccion;
            _mail = pMail;
        }

        public Usuario()
        {

        }
        public override string ToString()
        {
            return base.ToString() + $"{Id} {Nombre} {Cedula} {Telefono} {Direccion} {Mail} ";
        }
    }
}
