using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT04
{
    abstract class Funcionario
    {
        protected int id;
        protected string nome;
        protected string email;
        protected double valorHora;
        protected Data dataNasc;

        public Funcionario()
        {
            id = 0;
            nome = "sem nome";
            email = "";
            valorHora = 0;
            dataNasc = new Data();
        }
        public Funcionario(int id,string n,string e,double v,int d,int m,int a)
        {
            if (!setId(id))
                id = 0;
            if (!setNome(n))
                nome = "erro";
            if (!setEmail(e))
                email = "email invalido";
            if (!setValorHora(v))
                valorHora = 0;
            dataNasc = new Data(d, m, a);
        }
        public Funcionario(int id, string n, string e, double v, Data d)
        {
            if (!setId(id))
                id = 0;
            if (!setNome(n))
                nome = "erro";
            if (!setEmail(e))
                email = "email invalido";
            if (!setValorHora(v))
                valorHora = 0;
            dataNasc = d;
        }
        public Funcionario(Funcionario f)
        {
            id = f.id;
            nome = f.nome;
            email = f.email;
            valorHora = f.valorHora;
            dataNasc = f.dataNasc;
        }


        public int getId()
        {
            return id;
        }
        public bool setId(int x)
        {
            if(x>=0)
            {
                id = x;
                return true;
            }
            return false;
        }
        public string getNome()
        {
            return nome;
        }
        public bool setNome(string n)
        {
            if(!string.IsNullOrEmpty(n))
            {
                nome = n;
                return true;
            }
            return false;
        }
        public string getEmail()
        {
            return email;
        }
        public bool setEmail(string email)
        {
            if(!string.IsNullOrEmpty(email))
            {
                this.email = email;
                return true;
            }
            return false;
        }
        public double getValorHora()
        {
            return valorHora;
        }
        public bool setValorHora(double valor)
        {
            if (valor >= 0)
            {
                valorHora = valor;
                return true;
            }
            return false;
        }
        public Data getDataNascimento()
        {
            return dataNasc;
        }
        public bool setDataNascimento(int dia, int mes, int ano)
        {
            return (dataNasc.setAno(ano) && dataNasc.setMes(mes) && dataNasc.setDia(dia));
        }
        public bool setDataNascimento(Data d)
        {
            return (dataNasc.setAno(d.getAno()) && dataNasc.setMes(d.getMes()) && dataNasc.setDia(d.getDia()));
        }
        public int calcularIdade()
        {
            int ano = int.Parse(DateTime.Now.Year.ToString());
            int mes = int.Parse(DateTime.Now.Month.ToString());
            int dia = int.Parse(DateTime.Now.Day.ToString());
            return this.dataNasc.difEntre2Anos(new Data(dia, mes, ano));
        }
        public double calcSal(double h)
        {
            if(h>0)
                return h * valorHora;
            return -1;
        }
    }
}
