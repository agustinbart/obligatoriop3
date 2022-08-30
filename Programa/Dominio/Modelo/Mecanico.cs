using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo
{
    public class Mecanico
    {
        private int _id;
        private string _nombre;
        private string _cedula;
        private string _telefono;
        private DateTime _fechaingreso;
        private int _valorhora;
        private string _activo;

        #region Getters & Setters
        public DateTime FechaIngreso { get => _fechaingreso; set => _fechaingreso = value; }
        public int ValorHora { get => _valorhora; set => _valorhora = value; }
        public string Activo { get => _activo; set => _activo = value; }
        public int Id { get => _id; set => _id = value; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public string Cedula { get => _cedula; set => _cedula = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        #endregion

        public Mecanico()
        {

        }
        public Mecanico(int pId, string pNombre, string pCedula, string pTelefono, DateTime pFechaIngreso, int pValorHora, string pActivo)
        {
            _id = pId;
            _nombre = pNombre;
            _cedula = pCedula;
            _telefono = pTelefono;
            _fechaingreso = pFechaIngreso;
            _valorhora = pValorHora;
            _activo = pActivo;
        }

        public override string ToString()
        {
            return $"{Id} {Nombre} {Cedula} ${ValorHora}";
        }
    }
}
