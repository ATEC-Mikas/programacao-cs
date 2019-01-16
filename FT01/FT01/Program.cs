using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT01
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Exercicio A
            //string nome;
            //Console.Write("Insira o seu nome:");
            //nome = Console.ReadLine();
            //Console.Write("Olá "+nome+"!");
            ////Exercicio B
            //if(nome.ToLower().Equals("bartolomeu")) {
            //    Console.Write("Dá cá o meu!");
            //}
            ////Exercicio C
            //if (nome.ToLower().Substring(nome.Length - 2, 2).Equals("eu")){
            //    Console.Write("Dá cá o meu!");
            //}
            ////Exercicio D
            //string nome_C;
            //Console.Write("Insira o seu nome completo:");
            //nome_C = Console.ReadLine();
            //string[] nomes;
            //nomes = nome_C.Split(' ');
            //Console.WriteLine("Primeiro nome: "+ nomes[0]);
            //Console.WriteLine("Ultimo nome: " + nomes[nomes.Length-1]);
            ////Exercicio E
            //string[] frases= new string[3];
            //for(int i=0;i<3;i++) {
            //    Console.WriteLine("Frase numero " + (i + 1) + " :");
            //    frases[i]=Console.ReadLine();
            //}
            //int maior = 0;
            //for(int i = 0; i < 3; i++){
            //    if(frases[maior].Length<frases[i].Length)
            //        maior=i;
            //}
            //Console.WriteLine("Maior Frase: "+(maior + 1));
            //Console.WriteLine("'" + frases[maior] + "'");
            ////Exercicio F
            //string[] teste1 = { "teste", "testezao", "testezinho" , "porra" };
            //string[] teste2 = { "teste", "papel", "patos", "quack" };
            //if (exercicioF(teste1))
            //    Console.WriteLine("Mesmo numero de letras");
            //else
            //    Console.WriteLine("Numero diferente de letras");
            //if (exercicioF(teste2))
            //    Console.WriteLine("Mesmo numero de letras");
            //else
            //    Console.WriteLine("Numero diferente de letras");
            ////Exercicio G
            //string[] teste2 = { "teste", "papel", "patos", "quack" };
            //Console.WriteLine("Resultado: " + exercicioG(teste2));
            ////Exercicio H
            //string teste;
            //Console.Write("Insira a frase:");
            //teste = Console.ReadLine();
            //teste=teste.Replace('v', 'b').Replace('V', 'B');
            //teste=teste.Replace("ão", "om").Replace("ÃO", "OM");
            //Console.WriteLine(teste);
            ////Exercicio I
            //string n;
            //Console.WriteLine("Digite a sua frase:");
            //n = Console.ReadLine();
            //if (exercicioI(n))
            //    Console.Write("É composto somente por algarismos.");
            //else
            //    Console.Write("Não é composto somente por algarismos.");
            ////Exericico J
            //string n;
            //Console.WriteLine("Digite a sua frase:");
            //n = Console.ReadLine();
            //if (exercicioJ(n))
            //    Console.Write("A frase não contem algarismos.");
            //else
            //    Console.Write("A frase contem algarismos.");
            ////Exercicio K
            //string s1, s2;
            //Console.Write("Digite a sua frase 1:");
            //s1 = Console.ReadLine();
            //Console.Write("Digite a sua frase 2:");
            //s2 = Console.ReadLine();
            //if (string.Compare(s1.ToLower(), s2.ToLower()) > 0)
            //    Console.WriteLine("Frase 2 esta em primeiro");
            //else if (string.Compare(s1.ToLower(), s2.ToLower()) < 0)
            //    Console.WriteLine("Frase 1 esta em primeiro");
            //else
            //    Console.WriteLine("As frases são iguais");
            //Exericio L
            //string[] frases = new string[10];
            //for(int i=0;i<10;i++)
            //{
            //    Console.Write("Insira a frase Nº" + (i + 1) + ":");
            //    frases[i] = Console.ReadLine();
            //}
            //frases = exercicioL(frases);
            //for (int i = 0; i < frases.Length; i++)
            //    Console.WriteLine(frases[i]);
            //Exercicio M
            /*
             *  0 = Questao
             *  1 = Resposta certa
             *  2 = Resposta 1
             *  3 = Resposta 2
             *  4 = Resposta 3
             *  5 = Resposta 4
             */
            //string[,] questoes = new string[10, 6];
            //string resposta;
            //int valido;

            //for(int i=0;i<10;i++)
            //{
            //    questoes[i, 0] = "Pergunta generica com resposta " + ((i % 4) + 1);
            //    questoes[i, 1] = ((i % 4) +1).ToString();
            //    questoes[i, 2] = "Pergunta generica 1";
            //    questoes[i, 3] = "Pergunta generica 2";
            //    questoes[i, 4] = "Pergunta generica 3";
            //    questoes[i, 5] = "Pergunta generica 4";
            //}

            //for(int i=0;i<10;i++)
            //{
            //    valido = 0;
            //    Console.WriteLine(questoes[i,0]);
            //    for (int j = 1; j <= 4; j++)
            //        Console.WriteLine(j+" - "+questoes[i,j+1]);
            //    while(valido==0)
            //    {
            //        Console.WriteLine("Qual a sua resposta");
            //        resposta = Console.ReadLine();
            //        if(!string.IsNullOrWhiteSpace(resposta))
            //        {
            //            if (int.Parse(resposta) > 0 && int.Parse(resposta) <= 4)
            //            {
            //                valido = 1;
            //                if (int.Parse(resposta) == int.Parse(questoes[i, 1]))
            //                    Console.WriteLine("Respondeu certo!");
            //                else
            //                    Console.WriteLine("Respondeu errado.");
            //            }
            //        }
            //    }
            //}

            Console.ReadKey();
        }

        public static bool exercicioF(string[] frase) {
            int t = frase[0].Length;
            for(int i = 1; i < frase.Length; i++) {
                if(t!=frase[i].Length) {
                    return false;
                }
            }
            return true;
        }
        public static int exercicioG(string[] frase) {
            int soma = 0;
            for (int i = 0; i < frase.Length; i++)
                soma += frase[i].Length;
            return soma;
        }

        public static bool exercicioI(string frase) {
            char[] numeros = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i=0;i<frase.Length;i++) {
                if (!numeros.Contains(frase[i]))
                        return false;
            }
            return true;
        }

        public static bool exercicioJ(string frase)
        {
            char[] numeros = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 0; i < frase.Length; i++)
            {
                if (numeros.Contains(frase[i]))
                    return false;
            }
            return true;
        }

        public static string[] exercicioL(string[] frases)
        {
            if(frases.Length!=10)
            {
                string[] erro = { "ERROR","Numero de frases invalido" };
                return erro;
            }
            string aux;
            for(int i=0;i<10;i++)
            {
                for(int j=i;j<10;j++)
                {
                    if(string.Compare(frases[i].ToLower(),frases[j].ToLower()) > 0)
                    {
                        aux = frases[i];
                        frases[i] = frases[j];
                        frases[j] = aux;
                    }
                }
            }

            return frases;
        }
    }
}
