using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FT05
{
    class Program
    {
        public static int lerInt()
        {
            int i = 0;
            while (!int.TryParse(Console.ReadLine(), out i))
            {
                Console.WriteLine("Erro.");
            }
            return i;

        }
        public static Data lerData()
        {
            Data d = new Data();
            string linha;
            while (true)
            {
                linha = Console.ReadLine();
                string[] data = linha.Split('/');
                if (data.Length == 3)
                    if (isAlgarismosOnly(data[0]) && isAlgarismosOnly(data[1]) && isAlgarismosOnly(data[2]))
                    {
                        if (d.setAno(int.Parse(data[2])) && d.setMes(int.Parse(data[1])) && d.setDia(int.Parse(data[0])))
                            break;

                    }
                Console.WriteLine("Erro.");
            }
            return d;
        }

        public static bool isAlgarismosOnly(string frase)
        {
            char[] numeros = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            for (int i = 0; i < frase.Length; i++)
            {
                if (!numeros.Contains(frase[i]))
                    return false;
            }
            return true;
        }
        public static void erro(string erro)
        {
            Console.WriteLine("O/a " + erro + " que introduziu é invalido");
        }

        public static char lerSexo()
        {
            char c;
            do {
                c = Console.ReadKey().KeyChar;
                Console.WriteLine("Erro.");
            }while (c != 'S' || c != 's' || c != 'F' || c != 'f' || c != 'N' || c != 'n');
            return c;

        }

        static void Main(string[] args)
        {
            //Candidato c = new Candidato();

            //c.adicionarCompetencia("Atirar tijolos");
            //c.adicionarCompetencia("Atirar Neves");
            //c.adicionarExperiencia("Competição de atiramento nevástico");
            //c.adicionarHabilitacao("certificado de atiramento de tijolos a 100m");
            //c.removerCompetencia(2);
            //c.removerExperiencia(1);
            //c.removerHabilitacao(1);
            //Console.WriteLine(c.toString());

            ArrayList candidatos = new ArrayList();

            int opc;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Inserir Candidato");
                Console.WriteLine("2 - Mostrar Candidatos");
                Console.WriteLine("\n\n0 - Sair");
                opc = lerInt();
                switch(opc)
                {
                    case 1:
                        Console.Clear();
                        //Console.WriteLine("TBD");
                        Candidato c = new Candidato();
                        Console.WriteLine("Insira o nome: ");
                        while (!c.setNome(Console.ReadLine()))
                            erro("Nome");
                        Console.WriteLine("Insira a localidade: ");
                        while (!c.setLocalidade(Console.ReadLine()))
                            erro("Localidade");
                        Console.WriteLine("Insira a Data de nascimento: ");
                        while (!c.setData(lerData()))
                            erro("Data de nascimento");
                        Console.WriteLine("Insira o Sexo(M/F/N):");
                        while (!c.setSexo(lerSexo()))
                            erro("Sexo");
                        Console.WriteLine("Insira o email: ");
                        while (!c.setEmail(Console.ReadLine()))
                            erro("Email");
                        Console.WriteLine("Insira o telefone");
                        while (!c.setTelefone(lerInt()))
                            erro("Telefone");

                        Console.ReadKey();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("TBD");
                        Console.ReadKey();
                        break;
                }
            } while (opc != 0);


            
            //Console.ReadKey();
        }
    }
}
