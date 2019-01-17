using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT04
{
    class Operario:Funcionario
    {
        private string departamento;

        public Operario() : base()
        {
            departamento = "nenhum";
        }
        public Operario(int id, string n, string e, double v, int d, int m, int a, string derp) : base(id, n, e, v, d, m, a)
        {
            if (!setDepartamento(derp))
                departamento = "Erro";
        }
        public Operario(Operario o) : base(o.id, o.nome, o.email, o.valorHora, o.dataNasc)
        {
            departamento = o.departamento;
        }

        public string getDepartamento()
        {
            return departamento;
        }
        public bool setDepartamento(string d)
        {
            if(!string.IsNullOrEmpty(d))
            {
                departamento = d;
                return true;
            }
            return false;
        }
        public string toString()
        {
            return "Operario Nº" + id.ToString() + ":"
                 + "\nNome:" + nome
                 + "\nEmail:" + email
                 + "\nValor Hora:" + valorHora.ToString()
                 + "\nDepartamento:" + departamento
                 + "\nData Nascimento:" + dataNasc.toString() + " Idade: " + calcularIdade().ToString()
                 ;
        }
    }
}
