using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Modelo
{
    public class Vehiculo
    {
        private int _id;
        private string _matricula;
        private string _marca;
        private string _modelo;
        private int _anio;
        private string _color;

        #region Getters & Setters
        public int Id { get => _id; set => _id = value; }
        public string Matricula { get => _matricula; set => _matricula = value; }
        public string Marca { get => _marca; set => _marca = value; }
        public string Modelo { get => _modelo; set => _modelo = value; }
        public int Anio { get => _anio; set => _anio = value; }
        public string Color { get => _color; set => _color = value; }
        #endregion

        public Vehiculo()
        {

        }
        public Vehiculo(int pId, string pMatricula, string pMarca, string pModelo, int pAnio, string pColor)
        {
            _id = pId;
            _matricula = pMatricula;
            _marca = pMarca;
            _modelo = pModelo;
            _anio = pAnio;
            _color = pColor;
        }

        public override string ToString()
        {
            return $"{Id} {Matricula} {Marca} {Modelo}";
        }
    }
}
