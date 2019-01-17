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

            StreamReader rdgerentes = new StreamReader(@"Gerentes.txt");
            while(!rdgerentes.EndOfStream)
            {
                string linha = rdgerentes.ReadLine();
                linha = linha.Replace('/', ';');
                string[] atributos = linha.Split(';');
                foreach (string teste in atributos)
                    Console.WriteLine(teste);
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

            StreamReader rdoperarios = new StreamReader(@"Operarios.txt");
            while (!rdoperarios.EndOfStream)
            {
                string linha = rdoperarios.ReadLine();
                linha = linha.Replace('/', ';');
                string[] atributos = linha.Split(';');
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
            }
            rdoperarios.Close();



            Gerente g1=new Gerente(1,"diogo","diogo@neves",7.2,24,5,1990,"Tijolos",2);
            Console.WriteLine("\n\n" + g1.toString());
            Operario o1 = new Operario(2,"Teste","teste@neves",2,2,3,1990,"Departamento Tijoleiro");
            Console.WriteLine("\n\n"+o1.toString());

            gerentes.Add(g1);
            operarios.Add(o1);


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
