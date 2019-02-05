using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT_07
{
    class Carro
    {
        //Atributos && Propriedades
        public string Matricula { get; set; }
        private int _ano;
        public int Ano { get { return _ano; } set { if (value > 1900 && value > DateTime.Today.Year) _ano = value; } }
        private double _kminiciais;
        public double KMiniciais { get { return _kminiciais; } set { if (value > 0) _kminiciais = value; } }
        private string TipoCombustivel { get; set; }
        public List<Abastecimento> ListaAbastecimento { get; set; }

        //Construtores

        public Carro()
        {
            Matricula = "nenhuma";
            Ano = 2000;
            KMiniciais = 0;
            TipoCombustivel = "ar";
            ListaAbastecimento = new List<Abastecimento>();
        }
        public Carro(string mat,int ano,double km,string tipo)
        {
            _ano = -1;
            _kminiciais = -1;
            ListaAbastecimento = new List<Abastecimento>();

            Matricula = mat;
            TipoCombustivel = tipo;
            Ano = ano;
            KMiniciais = km;

            if (_ano == -1 || _kminiciais == -1)
                throw new Exception("Objeto construido incorretamente");
        }
        public Carro(Carro c)
        {
            Matricula = c.Matricula;
            Ano = c.Ano;
            TipoCombustivel = c.TipoCombustivel;
            KMiniciais = c.KMiniciais;
            ListaAbastecimento = c.ListaAbastecimento;
        }
        //Funcoes
        public bool AdicionarEntrada(Carro car,DateTime data,double valor,double litros,double km)
        {
            try
            {
                ListaAbastecimento.Add(new Abastecimento(car, data, valor, litros, km));
                return true;
            } catch(Exception)
            {
                return false;
            }
        }
        public bool RemoverEntrada(int pos)
        {
            if (pos >= 0 && pos<=ListaAbastecimento.Count)
            {
                ListaAbastecimento.Remove(ListaAbastecimento[pos]);
                return true;
            }
            return false;
        }

        public double CalcConsumoMedio()
        {

            return 0;
        }
        public double TotalGastoEmCombustivel()
        {
            double x=0;
            foreach(Abastecimento a in ListaAbastecimento)
            {
                x += a.Valor;
            }
            return x;
        }
        public int QuantasSubidasCombustivel()
        {
            int x = 0;
            if(ListaAbastecimento.Count>2)
                for(int i=0;i<ListaAbastecimento.Count;i++)
                    if(ListaAbastecimento[i].Valor<ListaAbastecimento[i+1].Valor)
                        x++;

            return x;
        }
        public double DiferencaCombustivel()
        {
            if (ListaAbastecimento.Count > 2)
                return Math.Abs(ListaAbastecimento[0].Valor - ListaAbastecimento[ListaAbastecimento.Count - 1].Valor);
            return 0;
        }
    }
}
