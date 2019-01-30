using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT04
{
    class Program
    {
        static void Main(string[] args)
        {
            Contacto c1 = new Contacto();
            c1.SetEmail("testeme");

            Console.WriteLine(c1.toString());

            Console.WriteLine("\n\n\n");

            Conta conta1 = new Conta();
            conta1.Depositar(200.202);

            Console.WriteLine(conta1.toString());



            Console.ReadKey();
        }
    }
}
