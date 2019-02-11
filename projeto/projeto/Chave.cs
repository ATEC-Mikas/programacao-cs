using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projeto
{
    class Chave
    {
        //Atributos
        private int[] numeros;
        private int[] estrelas;
        private List<int> nsuplementar;
        private int esuplementar;
        private bool locked;

        //Construtores
        public Chave()
        {
            numeros = new int[5];
            estrelas = new int[2];
            nsuplementar = new List<int>();
            locked = false;
            esuplementar = -1;
            for (int i = 0; i < 5; i++)
                numeros[i] = -1;
            for (int i = 0; i < 2; i++)
                estrelas[i] = -1;
        }
        public Chave(bool gerada)
        {
            if(gerada)
            {
                gerarNumeros();
                gerarEstrelas();
                esuplementar = -1;
                locked = true;
                nsuplementar = new List<int>();
            } else
            {
                numeros = new int[5];
                estrelas = new int[2];
                nsuplementar = new List<int>();
                locked = false;
                esuplementar = -1;
                for (int i = 0; i < 5; i++)
                    numeros[i] = -1;
                for (int i = 0; i < 2; i++)
                    estrelas[i] = -1;
            }
        }
        public Chave(int n1,int n2,int n3,int n4,int n5,int e1,int e2)
        {
            locked = false;
            esuplementar = -1;
            nsuplementar = new List<int>();
            numeros = new int[5];
            estrelas = new int[2];
            if (!setNumero(n1, 1))
                throw new Exception("Numero invalido!");
            if (!setNumero(n2, 2))
                throw new Exception("Numero invalido!");
            if (!setNumero(n3, 3))
                throw new Exception("Numero invalido!");
            if (!setNumero(n4, 4))
                throw new Exception("Numero invalido!");
            if (!setNumero(n5, 5))
                throw new Exception("Numero invalido!");
            if(!setEstrela(e1,1))
                throw new Exception("Estrela invalida!");
            if (!setEstrela(e2, 2))
                throw new Exception("Estrela invalida!");
        }
        public Chave(Chave c)
        {
            nsuplementar = new List<int>();
            numeros = new int[5];
            estrelas = new int[2];

            int[] cnum = c.getNumeros();
            int[] cest = c.getEstrelas();
            for (int i = 0; i < cnum.Length; i++)
                numeros[i] = cnum[i];
            for (int i = 0; i < cest.Length; i++)
                estrelas[i] = cest[i];
            foreach (int num in c.getNSuplementar())
                nsuplementar.Add(num);
            esuplementar = c.esuplementar;
            locked = c.locked;
        }


        //Sets & Gets
        public bool setNumero(int numero,int pos)
        {
            if(numero <=50 && numero>0 && pos>0 && pos<=5 && !locked && !numeros.Contains(numero) && !nsuplementar.Contains(numero))
            {
                numeros[pos-1]=numero;
                return true;
            }
            return false;
        }
        public int[] getNumeros()
        {
            return numeros;
        }
        public bool setEstrela(int estrela, int pos)
        {
            if (estrela <= 12 && estrela > 0 && pos > 0 && pos <= 5 && !locked && !estrelas.Contains(estrela) && estrela!=esuplementar)
            {
                estrelas[pos - 1] = estrela;
                return true;
            }
            return false;
        }
        public int[] getEstrelas()
        {
            return estrelas;
        }
        public int[] getNSuplementar()
        {
            int[] v = new int[nsuplementar.Count];
            for (int i = 0; i < nsuplementar.Count; i++)
                v[i] = nsuplementar[i];
            return v;
        }
        public bool setESuplementar(int es)
        {
            if (es <= 12 && es>0 && !locked && !estrelas.Contains(es))
            {
                esuplementar = es;
                return true;
            }
            return false;
        }
        public int getESuplementar()
        {
            return esuplementar;
        }

        //Metodos

        //privado
        private void gerarNumeros()
        {
            Random rand = new Random();
            numeros = new int[5];
            for (int i = 0; i < 5; i++)
                numeros[i] = -1;
            int numero;
            for(int i=0;i<5;i++)
            {
                do
                {
                    numero = rand.Next(1, 51);
                } while (numeros.Contains(numero));
                numeros[i] = numero;
            }
        }
        private void gerarEstrelas()
        {
            Random rand = new Random();
            estrelas = new int[2];
            for (int i = 0; i < 2; i++)
                estrelas[i] = -1;
            int numero;
            for (int i = 0; i < 2; i++)
            {
                do
                {
                    numero = rand.Next(1, 13);
                } while (estrelas.Contains(numero));
                estrelas[i] = numero;
            }
        }
        //publico
        public void gerarESuplementar()
        {
            Random rand = new Random();
            int num;
            do
            {
                num = rand.Next(1, 13);
            } while (estrelas.Contains(num));
            setESuplementar(num);
    
        }
        public bool gerarNSuplementar(int n)
        {
            Random rand = new Random();
            int num;
            if (n>0&&n<=2)
            {
                for(int i=0;i<n;i++)
                {
                    do
                    {
                        num = rand.Next(1, 51);
                    } while (numeros.Contains(num) || nsuplementar.Contains(num));
                    adicionarNSuplementar(num);
                }
            }
            return false;
        }
        public bool adicionarNSuplementar(int numero)
        {
            if (numero <= 50 && numero > 0 && nsuplementar.Count<=2 && !locked && !nsuplementar.Contains(numero) && !numeros.Contains(numero))
            {
                nsuplementar.Add(numero);
                return true;
            }
            return false;
        }
        public bool removerNSuplementar(int numero)
        {
            return nsuplementar.Remove(numero);
        }
        public void removerESuplementar()
        {
            if (!locked)
                esuplementar = -1;

        }
        public void trancarChave()
        {
            locked = true;
        }
        public void destrancarChave()
        {
            locked = false;
        }
        public string toString(string text)
        {
            organizarChave();
            string r = "Chave " + text + ":\n\tNumeros: ";
            foreach (int num in numeros)
                    r += num + " ";
            r += " | Estrelas: ";
            foreach (int num in estrelas)
                r += num + " ";
            if(nsuplementar.Count!=0)
            {
                r += (nsuplementar.Count==1? "\n\tNumero Suplementar: " : "\n\tNumeros Suplementares: ");
                foreach( int num in nsuplementar)
                    r += num + " ";
                if (esuplementar != -1)
                    r += " | Estrela suplementar: " + esuplementar;
            }
            else if(esuplementar != -1)
                    r += "\n\tEstrela suplementar: " + esuplementar;
            return r;
        }
        public string toString()
        {
            return toString("");
        }
        public string toFile()
        {
            organizarChave();
            string r = "";
            foreach (int num in numeros)
                r += num + ";";
            foreach (int num in estrelas)
                r += num + ";";
            r += nsuplementar.Count + ";";
            foreach (int num in nsuplementar)
               r += num + ";";
            r += esuplementar;
            return r;
        }
        public void organizarChave()
        {
            Array.Sort(numeros);
            Array.Sort(estrelas);
            nsuplementar.Sort();
        }
        public List<int> match(Chave gerada)
        {
            List<int> n = new List<int>();
            if(gerada.locked && !locked)
            {
                organizarChave();
                gerada.organizarChave();
                foreach (int num in numeros)
                    if (gerada.getNumeros().Contains(num))
                        n.Add(num);
                foreach (int num in nsuplementar)
                    if (gerada.getNumeros().Contains(num))
                        n.Add(num);

                n.Add(-1);

                foreach (int est in estrelas)
                    if (gerada.getEstrelas().Contains(est))
                        n.Add(est);
                if (gerada.getEstrelas().Contains(esuplementar))
                    n.Add(esuplementar);

            }
            return n;
        }
    }
}
