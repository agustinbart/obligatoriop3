using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo
{
    public class Reparacion
    {
        private int _id;
        private int _anio;
        private string _matricula;
        private DateTime _fechaentrada;
        private DateTime _fechasalida;
        private int _idmecanico;
        private string _descripcionentrada;
        private string _descripcionsalida;
        private int _kmentrada;

        #region Getters & Setters
        public int Id { get => _id; set => _id = value; }
        public int Anio { get => _anio; set => _anio = value; }
        public string Matricula { get => _matricula; set => _matricula = value; }
        public DateTime FechaEntrada { get => _fechaentrada; set => _fechaentrada = value; }
        public DateTime FechaSalida { get => _fechasalida; set => _fechasalida = value; }
        public int IdMecanico { get => _idmecanico; set => _idmecanico = value; }
        public string DescripcionEntrada { get => _descripcionentrada; set => _descripcionentrada = value; }
        public string DescripcionSalida { get => _descripcionsalida; set => _descripcionsalida = value; }
        public int KmEntrada { get => _kmentrada; set => _kmentrada = value; }
        #endregion

        public Reparacion()
        {

        }

        public Reparacion(int pId, int pAnio, string pMatricula, DateTime pFechaEntrada, DateTime pFechaSalida, int pIdMecanico, string pDescripcionEntrada, string pDescripcionSalida, int KmEntrada)
        {
            _id = pId;
            _anio = pAnio;
            _matricula = pMatricula;
            _fechaentrada = pFechaEntrada;
            _fechasalida = pFechaSalida;
            _idmecanico = pIdMecanico;
            _descripcionentrada = pDescripcionEntrada;
            _descripcionsalida = pDescripcionSalida;
            _kmentrada = KmEntrada;
        }

        public override string ToString()
        {
            return $"{Id} {Anio} {Matricula} {IdMecanico} {FechaEntrada.ToString("d")}";
        }
    }
}
