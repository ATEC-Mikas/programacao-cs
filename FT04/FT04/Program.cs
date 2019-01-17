using System;
//using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FT04
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList teste = new ArrayList();
            



            Gerente g1=new Gerente(1,"diogo","diogo@neves",7.2,24,5,1990,"Tijolos",2);
            Console.WriteLine("\n\n" + g1.toString());
            Operario o1 = new Operario(2,"Teste","teste@neves",2,2,3,1990,"Departamento Tijoleiro");
            Console.WriteLine("\n\n"+o1.toString());

            teste.Add(g1);
            teste.Add(o1);
            Console.WriteLine();
            foreach (Object obj in teste)
                Console.WriteLine(obj);
            

            Console.WriteLine(teste[0].toString());


            Console.ReadKey();
        }
    }
}
