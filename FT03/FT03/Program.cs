using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT03
{
    class Program
    {
        static void Main(string[] args)
        {
            //Data d1=new Data(21,8,1990,3,20,20,20);
            //Data d2 = new Data(21, 7, 1998, 3, 20, 20, 20);
            //Console.WriteLine(d1.toString());

            //Console.WriteLine(d1.getHora().difEntre2Horas(new Hora(9,50,20)));
            //Console.WriteLine(d1.difEntre2Anos(d2));


            Ponto p1 = new Ponto(1, 2);
            Ponto p2 = new Ponto(3, 4);

            //Console.WriteLine(p1.toString());
            //Console.WriteLine("Distancia entre dois pontos:"+p1.distEntre2Pontos(p2));

            Recta r1 = new Recta(p1,p2);
            Recta r2 = new Recta(r1);
            Console.WriteLine(r1.toString());

            Console.ReadKey();
        }
    }
}
