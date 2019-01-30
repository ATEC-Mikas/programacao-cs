using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT04
{
    class Pessoa : ContactoDois
    {
        //privado
        private Data dataNasc;


        //publico

        //Construtores
        public Pessoa():base()
        {
            dataNasc = new Data();
        }
        public Pessoa(int i, int telef, string n, string e, int d, int m, int a):base(i,telef,n,e)
        {
            dataNasc = new Data(d, m, a);
        }
        public Pessoa(Pessoa p):base(p.id,p.telefone,p.nome,p.email)
        {
            dataNasc = new Data(p.dataNasc);
        }

        //Sets & Gets
        public bool SetData(int d, int m, int a)
        {
            return (dataNasc.setAno(a) &&
                    dataNasc.setMes(m) &&
                    dataNasc.setDia(d));
        }
        public bool SetData(Data d)
        {
            return (dataNasc.setAno(d.getAno()) &&
                    dataNasc.setMes(d.getMes()) &&
                    dataNasc.setDia(d.getDia()));
        }
        public Data GetData()
        {
            return dataNasc;
        }
        //to String
        public string toString()
        {
            return "ID: " + id.ToString()
                 + "\nNome: " + nome
                 + "\nTelefone: " + telefone.ToString()
                 + "\nEmail: " + email
                 + "\nData de nascimento: " + dataNasc.toString()
                 ;
        }


        //Funções
        public int calcularIdade()
        {
            int ano = int.Parse(DateTime.Now.Year.ToString());
            int mes = int.Parse(DateTime.Now.Month.ToString());
            int dia = int.Parse(DateTime.Now.Day.ToString());
            return dataNasc.difEntre2Anos(new Data(dia, mes, ano));
        }
    }
}
