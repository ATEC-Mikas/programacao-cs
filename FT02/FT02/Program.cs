using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FT02
{
    class Program
    {
        static void Main(string[] args)
        {
            //StreamReader rd = new StreamReader(@"vencimentos.txt");
            //StreamWriter wr = new StreamWriter(@"supmil.txt");

            ////o código do funcionários, o nome e o vencimento (valor real)

            //int i = 0;
            //while (!rd.EndOfStream)
            //{
            //    string linha = rd.ReadLine();
            //    string[] atributos = linha.Split(' ');
            //    if (atributos.Length == 3)
            //    {
            //        if (float.Parse(atributos[2]) >= 1000)
            //        {
            //            wr.Write(atributos[0] + " " + atributos[1] + " " + atributos[2] + "\n");
            //            i++;
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Erro!");
            //    }
            //    
            //}
            //if (i == 0)
            //{
            //    wr.Write("Não contem registos");
            //}
            //wr.Close();
            //rd.Close();
            //Console.Write("Concluido com sucesso...");

            //cada linha tem o numero do aluno, o nome e a média (valor real)
            //StreamReader rd = new StreamReader(@"notas.txt");
            //StreamWriter wdReprovado = new StreamWriter(@"reprovado.txt");
            //StreamWriter wdAprovado = new StreamWriter(@"aprovado.txt");
            //int[] i = {0,0};
            //while(!rd.EndOfStream)
            //{
            //    string linha = rd.ReadLine();
            //    string[] atributos = linha.Split(' ');
            //    if(atributos.Length==3)
            //    {
            //        if(float.Parse(atributos[2]) >= 0 && float.Parse(atributos[2]) <= 20)
            //        {
            //            if (float.Parse(atributos[2]) >= 9.5)
            //            {
            //                wdAprovado.WriteLine(atributos[0] + " " + atributos[1] + " " + atributos[2]);
            //                i[0]++;
            //            }
            //            else
            //            {
            //                wdReprovado.WriteLine(atributos[0] + " " + atributos[1] + " " + atributos[2]);
            //                i[1]++;
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine("Erro!");
            //        }
            //    }
            //    else
            //    {
            //        Console.WriteLine("Erro!");
            //    }
            //}
            //if (i[0] == 0)
            //    wdAprovado.WriteLine("não contem registos");
            //if (i[1] == 0)
            //    wdReprovado.WriteLine("não contem registos");

            //wdAprovado.Close();
            //wdReprovado.Close();
            //rd.Close();

            //Console.WriteLine("Concluido com sucesso...");



            Console.ReadKey();
        }
    }
}
