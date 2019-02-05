using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT_07
{
    class Abastecimento
    {
        //Atributos & Propriedades
        public Carro Car { get; set; }
        public DateTime Data { get; set; }
        private double _valor;
        public double Valor { get { return _valor; } set { if (value >= 0) _valor = value; } }
        private double _litros;
        public double Litros { get { return _litros; } set { if (value >= 0) _litros = value; } }
        private double _contakm;
        public double ContaKM { get { return _contakm; } set { if (value >= 0) _contakm = value; } }

        //Construtores
        public Abastecimento()
        {
            Car = new Carro();
            Data = DateTime.Today;
            Valor = 0;
            Litros = 0;
            ContaKM = 0;
        }
        public Abastecimento(Carro car,DateTime data,double valor,double litros,double contakm)
        {
            _valor = -1;
            _litros = -1;
            _contakm = -1;
            this.Car = car;
            this.Data = data;
            this.Valor = valor;
            this.Litros = litros;
            this.ContaKM = contakm;
            if (_valor == -1 || _litros == -1 || _contakm == -1)
                throw (new Exception("Objecto mal criado"));
        }
        public Abastecimento(Abastecimento ab)
        {
            Car = ab.Car;
            Data = ab.Data;
            Valor = ab.Valor;
            Litros = ab.Litros;
            ContaKM = ab.ContaKM;
        }
        //Funcoes
        public double calcPrecoLitro()
        {
            return Valor / Litros;
        }
    }
}
