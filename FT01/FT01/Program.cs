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
            //Exercicio I

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
    }
}
