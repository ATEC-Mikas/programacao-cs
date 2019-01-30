using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT04
{
    class Contacto
    {
        //private

        private int id;
        private int telefone;
        private string nome;
        private string email;
        private Data dataNasc;

        //public

        //construtores
        public Contacto()
        {
            id = 0;
            telefone = 0;
            nome = "sem nome";
            email = "sem email";
            dataNasc = new Data();
        }
        public Contacto(int i,int telef,string n,string e,int d,int m,int a)
        {
            if (!SetId(i))
                id = 0;
            if (!SetTelefone(telef))
                telefone = 0;
            if (!SetNome(n))
                nome = "erro";
            if (!SetEmail(e))
                email = "erro";
            dataNasc = new Data(d, m, a);
        }
        public Contacto(Contacto c)
        {
            id = c.id;
            telefone = c.telefone;
            nome = c.nome;
            email = c.email;
            dataNasc = new Data(c.dataNasc);
        }
        


        //Sets & Gets
        public bool SetId(int i)
        {
            if(i>0)
            {
                id = i;
                return true;
            }
            return false;
        }
        public int GetId()
        {
            return id;
        }
        public bool SetTelefone(int telef)
        {
            if (telef > 100000000 && telef < 999999999) 
            {
                telefone = telef;
                return true;
            }
            return false;
        }
        public int GetTelefone()
        {
            return telefone;
        }
        public bool SetNome(string n)
        {
            if(!string.IsNullOrEmpty(n))
            {
                nome = n;
                return true;
            }
            return false;
        }
        public string GetNome()
        {
            return nome;
        }
        public bool SetEmail(string e)
        {
            if(!string.IsNullOrEmpty(e)&&e.IndexOf('@')!=-1)
            {
                email = e;
                return true;
            }
            return false;
        }
        public string GetEmail()
        {
            return email;
        }
        public bool SetData(int d,int m,int a)
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

        //To String
        public string toString()
        {
            return "ID: " + id.ToString()
                 + "\nNome: " + nome
                 + "\nTelefone: " + telefone.ToString()
                 + "\nEmail: " + email
                 + "\nData de nascimento: " +dataNasc.toString()
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
