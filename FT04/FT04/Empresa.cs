using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT04
{
    class Empresa : ContactoDois
    {
        //private
        private string responsavel;
        private string morada;
        private int atividade;

        //public

        //construtores
        public Empresa():base()
        {
            responsavel = "nenhum";
            morada = "nenhuma";
            atividade = 0;
        }
        public Empresa(int i, int telef, string n, string e,string r,string m,int a) :base(i,telef,n,e)
        {
            if (!SetResponsavel(r))
                responsavel = "erro";
            if (!SetMorada(m))
                morada = "erro";
            if (!SetAtividade(a))
                atividade = 0;
        }
        public Empresa(Empresa e):base(e.id,e.telefone,e.nome,e.email)
        {
            responsavel = e.responsavel;
            morada = e.morada;
            atividade = e.atividade;
        }




        //Sets & Gets
        public bool SetResponsavel(string r)
        {
            if(!string.IsNullOrEmpty(r))
            {
                responsavel = r;
                return true;
            }
            return false;
        }
        public string GetResponsavel()
        {
            return responsavel;
        }
        public bool SetMorada(string m)
        {
            if(!string.IsNullOrEmpty(m))
            {
                morada = m;
                return true;
            }
            return false;
        }
        public string GetMorada()
        {
            return morada;
        }
        public bool SetAtividade(int a)
        {
            if(a>0)
            {
                atividade = a;
                return true;
            }
            return false;
        }
    }
}
