using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT05
{
    class Candidato
    {
        //private
        private string nome;
        private string localidade;
        private Data dataNasc;
        private char sexo;
        private string email;
        private int telefone;
        private string[] habilitacao; //4
        private string[] experiencia; //6
        private string[] competencia; //6

        private bool validarString(string x)
        {
            return !string.IsNullOrEmpty(x);
        }
        private string[] removerElemento(string[] x,int pos)
        {
            if(pos<x.Length-1)
                for(int i=pos;i<x.Length-1;i++)
                {
                    x[i] = x[i + 1];
                }

            return x;
        }
        //public

        public Candidato()
        {
            nome = "sem nome";
            localidade = "nenhuma";
            dataNasc = new Data();
            sexo = 'n';
            email = "nenhum";
            telefone = 0;
            habilitacao = new string[4];
            experiencia = new string[6];
            competencia = new string[6];
            habilitacao[0] = "0";
            experiencia[0] = "0";
            competencia[0] = "0";
        }
        public Candidato(string n,string local,int dia,int mes,int ano,char sex,string em,int telef)
        {
            if (!setNome(n))
                nome = "nome invalido";
            if (!setLocalidade(local))
                localidade = "localidade invalida";
            dataNasc = new Data(dia, mes, ano);
            if (!setSexo(sex))
                sexo = 'n';
            if (!setEmail(em))
                email = "email invalido";
            if (!setTelefone(telef))
                telefone = 0;
            habilitacao = new string[4];
            experiencia = new string[6];
            competencia = new string[6];
            habilitacao[0] = "0";
            experiencia[0] = "0";
            competencia[0] = "0";
        }
        public Candidato(Candidato c)
        {
            nome = c.nome;
            localidade = c.localidade;
            dataNasc = c.dataNasc;
            sexo = c.sexo;
            email = c.email;
            telefone = c.telefone;
            habilitacao = c.habilitacao;
            experiencia = c.experiencia;
            competencia = c.competencia;
        }

        public bool setNome(string n)
        {
            if(validarString(n))
            {
                nome = n;
                return true;
            }
            return false;
        }
        public string getNome()
        {
            return nome;
        }
        public bool setLocalidade(string l)
        {
            if(validarString(l))
            {
                localidade = l;
                return true;
            }
            return false;
        }
        public string getLocalidade()
        {
            return localidade;
        }
        public bool setData(int dia,int mes,int ano)
        {
            return (dataNasc.setAno(ano) && dataNasc.setMes(mes) && dataNasc.setDia(dia));
        }
        public bool setData(Data d)
        {
            return (dataNasc.setAno(d.getAno()) && dataNasc.setMes(d.getMes()) && dataNasc.setDia(d.getDia()));
        }
        public Data getData()
        {
            return dataNasc;
        }
        public bool setSexo(char s)
        {
            if(s=='M' || s=='m')
            {
                sexo = 'm';
                return true;
            }
            if (s == 'F' || s == 'f')
            {
                sexo = 'f';
                return true;
            }
            if (s== 'n' || s=='N')
            {
                sexo = 'n';
                return true;
            }
            return false;
        }
        public string getSexo()
        {
            if (sexo == 'm')
                return "masculino";
            if (sexo == 'f')
                return "feminino";
            if (sexo == 'n')
                return "nenhum/indefenido";
            return "erro";
        }
        public bool setEmail(string e)
        {
            if(validarString(e))
            {
                email = e;
                return true;
            }
            return false;
        }
        public string getEmail()
        {
            return email;
        }
        public bool setTelefone(int t)
        {
            if(t>=100000000 && t<=999999999)
            {
                telefone = t;
                return true;
            }
            return false;
        }
        public int getTelefone()
        {
            return telefone;
        }
        public bool adicionarHabilitacao(string h)
        {
            if(validarString(h) && int.Parse(habilitacao[0]) < 3)
            {
                habilitacao[0]= (int.Parse(habilitacao[0])+1).ToString();
                habilitacao[int.Parse(habilitacao[0])] = h;
                return true;
            }
            return false;
        }
        public bool removerHabilitacao(int n)
        {
            if(n>0 && n<=3 && n <=int.Parse(habilitacao[0]))
            {
                removerElemento(habilitacao, n);
                habilitacao[0] = (int.Parse(habilitacao[0]) - 1).ToString();
                return true;
            }
            return false;
        }
        public bool adicionarExperiencia(string e)
        {
            if(validarString(e) && int.Parse(experiencia[0]) < 6)
            {
                experiencia[0] = (int.Parse(experiencia[0]) + 1).ToString();
                experiencia[int.Parse(experiencia[0])] = e;
                return true;
            }
            return false;
        }
        public bool removerExperiencia(int n)
        {
            if (n > 0 && n <= 3 && n <= int.Parse(experiencia[0]))
            {
                removerElemento(experiencia, n);
                experiencia[0] = (int.Parse(experiencia[0]) - 1).ToString();
                return true;
            }
            return false;
        }
        public bool adicionarCompetencia(string c)
        {
            if (validarString(c) && int.Parse(competencia[0]) < 6)
            {
                competencia[0] = (int.Parse(competencia[0]) + 1).ToString();
                competencia[int.Parse(competencia[0])] = c;
                return true;
            }
            return false;
        }
        public bool removerCompetencia(int n)
        {
            if (n > 0 && n <= 3 && n <= int.Parse(competencia[0]))
            {
                removerElemento(competencia, n);
                competencia[0] = (int.Parse(competencia[0]) - 1).ToString();
                return true;
            }
            return false;
        }
        public string toString()
        {
            string r =  "Nome: " + nome
                     + "\nLocalidade: " + localidade
                     + "\nData de nascimento: " + dataNasc.toString()
                     + "\nSexo: " + getSexo()
                     + "\nEmail: " + email
                     + "\nTelefone: " + telefone.ToString()
                     ;
            if(int.Parse(habilitacao[0])>0)
            {
                r += "\nHabilitação(ões): ";
                for (int i = 1; i <= int.Parse(habilitacao[0]); i++)
                    r += "\n" + habilitacao[i];
            }

            if (int.Parse(experiencia[0]) > 0)
            {
                r += "\nExperiencia(s) Profissional(ais): ";
                for (int i = 1; i <= int.Parse(experiencia[0]); i++)
                    r += "\n" + experiencia[i];
            }

            if (int.Parse(competencia[0]) > 0)
            {
                r += "\nCompetencias: ";
                for (int i = 1; i <= int.Parse(competencia[0]); i++)
                    r += "\n" + competencia[i];
            }

            return r;
        }
    }
}
