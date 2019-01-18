using System;
//using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FT04
{
    class Program
    {

        static void Main(string[] args)
        {
            ArrayList gerentes =new ArrayList();
            ArrayList operarios = new ArrayList();

            if (!File.Exists("Gerentes.txt"))
                File.Create("Gerentes.txt").Close();
            StreamReader rdgerentes = new StreamReader(@"Gerentes.txt");
            while(!rdgerentes.EndOfStream)
            {
                string linha = rdgerentes.ReadLine();
                linha = linha.Replace('/', ';');
                string[] atributos = linha.Split(';');
                //foreach (string teste in atributos)
                //    Console.WriteLine(teste);
                if(atributos.Length==9)
                {
                    gerentes.Add(new Gerente(
                                             int.Parse(atributos[0]),
                                             atributos[1],
                                             atributos[2],
                                             double.Parse(atributos[3]),
                                             int.Parse(atributos[4]),
                                             int.Parse(atributos[5]),
                                             int.Parse(atributos[6]),
                                             atributos[7],
                                             int.Parse(atributos[8])
                                            ));
                    Console.WriteLine("Gerente processado.");
                }
            }
            rdgerentes.Close();

            // TODO ARRANJAR OPERARIOS IGUAL A GERENTE
            if (!File.Exists("Operarios.txt"))
                File.Create("Operarios.txt").Close();

            StreamReader rdoperarios = new StreamReader(@"Operarios.txt");
            while (!rdoperarios.EndOfStream)
            {
                string linha = rdoperarios.ReadLine();
                linha = linha.Replace('/', ';');
                string[] atributos = linha.Split(';');
                //foreach (string teste in atributos)
                //    Console.WriteLine(teste);
                if(atributos.Length==8)
                {
                    operarios.Add(new Operario(
                                             int.Parse(atributos[0]),
                                             atributos[1],
                                             atributos[2],
                                             double.Parse(atributos[3]),
                                             int.Parse(atributos[4]),
                                             int.Parse(atributos[5]),
                                             int.Parse(atributos[6]),
                                             atributos[7]
                                            ));
                    Console.WriteLine("Operario processado.");
                }
            }
            rdoperarios.Close();

            Console.ReadKey();


            Gerente g1=new Gerente(1,"diogo","diogo@neves",7.2,24,5,1990,"Tijolos",2);
            //Console.WriteLine("\n\n" + g1.toString());
            Operario o1 = new Operario(2,"Teste","teste@neves",2,2,3,1990,"Departamento Tijoleiro");
            //Console.WriteLine("\n\n"+o1.toString());

            gerentes.Add(g1);
            operarios.Add(o1);

            foreach (Gerente obj in gerentes)
            {
                Console.WriteLine("\n"+obj.toString());
            }

            foreach (Operario obj in operarios)
            {
                Console.WriteLine("\n"+obj.toString());
            }

            Console.ReadKey();

            Console.WriteLine("---------------------------------\n\nLog files...\n\n-----------------------------------");


            StreamWriter wdgerentes = new StreamWriter(@"Gerentes.txt");
            foreach(Gerente obj in gerentes)
            {
                string linha = obj.getId().ToString() + ";"
                             + obj.getNome() + ";"
                             + obj.getEmail() + ";"
                             + obj.getValorHora().ToString() + ";"
                             + obj.getDataNascimento().toString() + ";"
                             + obj.getEspecialidade() + ";"
                             + obj.getExtensao().ToString()
                             ;
                wdgerentes.WriteLine(linha);
                Console.WriteLine("Gerente guardado.");
            }
            wdgerentes.Close();

            StreamWriter wdoperarios = new StreamWriter(@"Operarios.txt");
            foreach (Operario obj in operarios)
            {
                string linha = obj.getId().ToString() + ";"
                             + obj.getNome() + ";"
                             + obj.getEmail() + ";"
                             + obj.getValorHora().ToString() + ";"
                             + obj.getDataNascimento().toString() + ";"
                             + obj.getDepartamento()
                             ;
                wdoperarios.WriteLine(linha);
                Console.WriteLine("Operario guardado.");
            }
            wdoperarios.Close();




            Console.ReadKey();
        }
    }
}
