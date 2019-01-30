namespace FT04
{
    class Conta
    {
        //private
        private string titular;
        private int numero;
        private double saldo;
        private bool estado;

        //Construtores
        public Conta()
        {
            titular = "sem nome";
            numero = 0;
            saldo = 0;
            estado = false;
        }
        public Conta(string t,int n,double s,bool e)
        {
            if (!SetTitular(t))
                titular = "erro";
            if (!SetNumero(n))
                n = 0;
            saldo = 0;
            Depositar(s);
            estado = e;
        }
        public Conta(Conta c)
        {
            titular = c.titular;
            numero = c.numero;
            saldo = c.saldo;
            estado = c.estado;
        }


        //Sets & Gets
        public bool SetTitular(string t)
        {
            if(!string.IsNullOrEmpty(t))
            {
                titular = t;
                return true;
            }
            return false;
        }
        public string GetTitular()
        {
            return titular;
        }
        public bool SetNumero(int n)
        {
            if(n>0)
            {
                numero = n;
                return true;
            }
            return false;
        }
        public int GetNumero()
        {
            return numero;
        }
        public double GetSaldo()
        {
            return saldo;
        }
        public bool GetEstado()
        {
            return estado;
        }

        //To string
        public string toString()
        {
            return "Titular: " + titular
                 + "\nNumero: " + numero.ToString()
                 + "\nSaldo: " + saldo.ToString("0.00") + " Euros"
                 + "\nEstado da conta: " + (estado ? "Ativa" : "Inativa")
                 ;
        }

        //Outras funções
        public bool Levantar(double valor)
        {
            if(valor>0&&valor<=saldo)
            {
                saldo -= valor;
                return true;
            }
            return false;
        }
        public bool Depositar(double valor)
        {
            if(valor>0)
            {
                saldo += valor;
                return true;
            }
            return false;
        }
        public void AlterarEstado()
        {
            estado = !estado;
        }
        public double Credito()
        {
            if (saldo >= 5000)
                return saldo * 0.5;
            else if (saldo >= 1000)
                return saldo * 0.3;
            else if (saldo >= 500)
                return saldo * 0.1;
            else return 0;
        }
    }
}
