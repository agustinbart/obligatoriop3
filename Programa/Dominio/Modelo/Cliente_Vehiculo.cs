using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Cliente_Vehiculo
    {
        private int _clicod;
        private string _vehiculomatricula;
        private DateTime _fecha;

        #region Getters & Setters
        public int CliCod { get => _clicod; set => _clicod = value; }
        public string VehiculoMatricula { get => _vehiculomatricula; set => _vehiculomatricula = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        #endregion

        public Cliente_Vehiculo() { }

        public Cliente_Vehiculo(int pCliCod, string pVehiculoMatricula, DateTime pFecha)
        {
            _clicod = pCliCod;
            _vehiculomatricula = pVehiculoMatricula;
            _fecha = pFecha;
        }

        public override string ToString()
        {
            return $"{CliCod} {VehiculoMatricula} {Fecha}";
        }
    }
}
