using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT04
{
    class ContactoDois
    {
        //private

        protected int id;
        protected int telefone;
        protected string nome;
        protected string email;

        //public

        //construtores
        public ContactoDois()
        {
            id = 0;
            telefone = 0;
            nome = "sem nome";
            email = "sem email";
        }
        public ContactoDois(int i, int telef, string n, string e)
        {
            if (!SetId(i))
                id = 0;
            if (!SetTelefone(telef))
                telefone = 0;
            if (!SetNome(n))
                nome = "erro";
            if (!SetEmail(e))
                email = "erro";
        }
        public ContactoDois(ContactoDois c)
        {
            id = c.id;
            telefone = c.telefone;
            nome = c.nome;
            email = c.email;
        }



        //Sets & Gets
        public bool SetId(int i)
        {
            if (i > 0)
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
            if (!string.IsNullOrEmpty(n))
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
            if (!string.IsNullOrEmpty(e) && e.IndexOf('@') != -1)
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

        //To String
        public string toString()
        {
            return "ID: " + id.ToString()
                 + "\nNome: " + nome
                 + "\nTelefone: " + telefone.ToString()
                 + "\nEmail: " + email
                 ;
        }

        //Funções
    }
}
