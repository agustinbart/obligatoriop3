using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo
{
    public class Reserva
    {
        private int _id;
        private DateTime _fecha;
        private string _descripcionproblema;
        private int _idcliente;
        private string _matricula;
        private string _aceptado;

        #region Getters & Setters
        public int Id { get => _id; set => _id = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        public string DescripcionProblema { get => _descripcionproblema; set => _descripcionproblema = value; }
        public int IdCliente { get => _idcliente; set => _idcliente = value; }
        public string Matricula { get => _matricula; set => _matricula = value; }
        public string Aceptado { get => _aceptado; set => _aceptado = value; }
        #endregion

        public Reserva(int pId, DateTime pFecha, string pDescripcionProblema, int pIdCliente, string pMatricula, string pAceptado)
        {
            _id = pId;
            _fecha = pFecha;
            _descripcionproblema = pDescripcionProblema;
            _idcliente = pIdCliente;
            _matricula = pMatricula;
            _aceptado = pAceptado;
        }

        public Reserva()
        {

        }

        public override string ToString()
        {
            return $"{Id} {Fecha.ToString("d")} {IdCliente} {Matricula}";
        }
    }
}
