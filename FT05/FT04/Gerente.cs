using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT04
{
    class Gerente : Funcionario
    {
        private string especialidade;
        private int extensao;

        public Gerente():base()
        {
            especialidade = "nenhuma";
            extensao = 0;
        }
        public Gerente(int id, string n, string e, double v, int d, int m, int a,string esp,int ext) : base(id, n, e, v, d, m, a)
        {
            if (!setEspecialidade(esp))
                especialidade = "Erro";
            if (!setExtensao(ext))
                extensao = 0;
        }
        public Gerente(Gerente g): base(g.id,g.nome,g.email,g.valorHora,g.dataNasc)
        {
            especialidade = g.especialidade;
            extensao = g.extensao;
        }

        public string getEspecialidade()
        {
            return especialidade;
        }
        public bool setEspecialidade(string e)
        {
            if (!string.IsNullOrEmpty(e))
            {
                especialidade = e;
                return true;
            }
            return false;
        }
        public int getExtensao()
        {
            return extensao;
        }
        public bool setExtensao(int e)
        {
            if (e >= 0)
            {
                extensao = e;
                return true;
            }
            return false;
        }
        public string toString()
        {
            return "Gerente Nº" + id.ToString() + ":"
                 + "\nNome:" + nome
                 + "\nEmail:" + email
                 + "\nValor Hora:" + valorHora.ToString()
                 + "\nEspecialidade:" + especialidade
                 + "\nExtensao: " + extensao.ToString()
                 + "\nData Nascimento:"+dataNasc.toString()+" Idade: "+calcularIdade().ToString()
                 ;
        }
        //Calc sal?
    }
}
