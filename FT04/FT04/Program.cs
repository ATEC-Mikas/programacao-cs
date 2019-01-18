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

        public static int lerInt()
        {
            int i=0;
            while(!int.TryParse(Console.ReadLine(),out i))
            {
                Console.WriteLine("Erro.");
            }
            return i;

        }
        public static double lerDouble()
        {
            double d = 0;
            while (!double.TryParse(Console.ReadLine(), out d))
            {
                Console.WriteLine("Erro.");
            }
            return d;
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

        static void Main(string[] args)
        {
            ArrayList gerentes =new ArrayList();
            ArrayList operarios = new ArrayList();
            int cont = 0;


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
                    cont++;
                }
            }
                    Console.WriteLine(cont +" Gerente(s) processado(s).");
            rdgerentes.Close();

    
            if (!File.Exists("Operarios.txt"))
                File.Create("Operarios.txt").Close();

            cont = 0;
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
                    cont++;
                }
            }
            Console.WriteLine(cont + " Operario(s) processado(s).");
            rdoperarios.Close();

            Console.ReadKey();
            Console.Clear();

            int opc = 0;
            bool flag = true;

            while (flag)
            {
                Console.Clear();
                Console.WriteLine("Indique a opção desejada:");
                Console.WriteLine("1 - Inserir Gerente");
                Console.WriteLine("2 - Inserir Operario");
                Console.WriteLine("3 - Visualizar Gerentes");
                Console.WriteLine("4 - Visualizar Operários");
                Console.WriteLine("5 - Visualizar Funcionários");
                Console.WriteLine("0 - Sair");
                opc = lerInt();
                switch (opc)
                {
                    case 1:
                        Gerente ger;
                        ger = new Gerente();
                        Console.WriteLine("Digite o Numero identificador:");
                        while (!ger.setId(lerInt()))
                            erro("numero");
                        Console.WriteLine("Digite o Nome:");
                        while (!ger.setNome(Console.ReadLine()))
                            erro("nome");
                        Console.WriteLine("Digite o Email:");
                        while (!ger.setEmail(Console.ReadLine()))
                            erro("email");
                        Console.WriteLine("Digite o Valor Hora:");
                        while (!ger.setValorHora(lerDouble()))
                            erro("valor hora");
                        Console.WriteLine("Digite a especialidade:");
                        while (!ger.setEspecialidade(Console.ReadLine()))
                            erro("especialidade");
                        Console.WriteLine("Digite a extensao:");
                        while (!ger.setExtensao(lerInt()))
                            erro("extensão");
                        Console.WriteLine("Digite a data (DD/MM/AAAA):");
                        ger.setDataNascimento(lerData());
                        gerentes.Add(ger);
                        break;
                    case 2:
                        Operario op;
                        op = new Operario();
                        Console.WriteLine("Digite o Numero identificador:");
                        while (!op.setId(lerInt()))
                            erro("numero");
                        Console.WriteLine("Digite o Nome:");
                        while (!op.setNome(Console.ReadLine()))
                            erro("nome");
                        Console.WriteLine("Digite o Email:");
                        while (!op.setEmail(Console.ReadLine()))
                            erro("email");
                        Console.WriteLine("Digite o Valor Hora:");
                        while (!op.setValorHora(lerDouble()))
                            erro("valor hora");
                        Console.WriteLine("Digite o Departamento:");
                        while (!op.setDepartamento(Console.ReadLine()))
                            erro("departamento");
                        operarios.Add(op);
                        break;
                    case 3:
                        gerentes=menuGerentes(gerentes);
                        break;
                    case 4:
                        foreach (Operario obj in operarios)
                        {
                            Console.WriteLine("\n" + obj.toString());
                        }
                        Console.ReadKey();
                        break;
                    case 5:
                        foreach (Gerente obj in gerentes)
                        {
                            Console.WriteLine("\n" + obj.toString());
                        }
                        foreach (Operario obj in operarios)
                        {
                            Console.WriteLine("\n" + obj.toString());
                        }
                        Console.ReadKey();
                        break;
                    case 0:
                        flag = false;
                        break;
                    default:
                        break;
                }
            }


            Console.WriteLine("A sair do programa...");
            Console.ReadKey();
                Console.WriteLine("\n---------------------------------\n\nLog files...\n\n-----------------------------------");

            cont = 0;
            StreamWriter wdgerentes = new StreamWriter(@"Gerentes.txt");
            
            foreach (Gerente obj in gerentes)
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
                cont++;
            }
            Console.WriteLine(cont + " Gerente(s) guardado(s).");
            wdgerentes.Close();
            cont = 0;
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
                cont++;
            }
            Console.WriteLine(cont + " Operario(s) guardado(s).");
            wdoperarios.Close();




            Console.ReadKey();
        }
        public static ArrayList menuGerentes(ArrayList gerentes)
        {
            int i;
            int opc=0;

            while(true)
            {
                i = 0;
                Console.Clear();
                Console.WriteLine("Editar Gerente:");
                foreach (Gerente obj in gerentes)
                {
                    Console.WriteLine((i+1)+" - "+ obj.getNome());
                    i++;
                }
                Console.WriteLine("\n0 - Sair");
                opc = lerInt();
                if (opc == 0)
                    break;
                if(opc<=i && opc>0)
                    gerentes[opc - 1] = menuEditarGerente((Gerente)gerentes[opc - 1]);
            }

            //Console.ReadKey();
            return gerentes;
        }
        public static Gerente menuEditarGerente(Gerente gerente)
        {
            int opc = 0;
            bool flag=true;
            while (flag)
            {
                Console.Clear();
                Console.WriteLine("1 - Nº Identificador: " + gerente.getId().ToString());
                Console.WriteLine("2 - Nome: " + gerente.getNome());
                Console.WriteLine("3 - Email: " + gerente.getEmail());
                Console.WriteLine("4 - Valor Hora: " + gerente.getValorHora().ToString());
                Console.WriteLine("5 - Especialidade: " + gerente.getEspecialidade());
                Console.WriteLine("6 - Extensão: " + gerente.getExtensao().ToString());
                Console.WriteLine("7 - Data de Nascimento: " + gerente.getDataNascimento().toString());
                Console.WriteLine("\n0 - Sair");
                opc = lerInt();
                switch(opc)
                {
                    case 0:
                        flag = false;
                        break;
                    case 1:
                        Console.WriteLine("Digite o Numero Identificador:");
                        if (!gerente.setId(lerInt()))
                        {
                            erro("numero identifcador");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Digite o Nome:");
                        if (!gerente.setNome(Console.ReadLine()))
                        {
                            erro("nome");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Digite o Email:");
                        if (!gerente.setEmail(Console.ReadLine()))
                        {
                            erro("email");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        Console.WriteLine("Digite o Valor por hora:");
                        if (!gerente.setValorHora(lerDouble()))
                        {
                            erro("valor hora");
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        Console.WriteLine("Digite a Especialidade:");
                        if (!gerente.setEspecialidade(Console.ReadLine()))
                        {
                            erro("especialidade");
                            Console.ReadKey();
                        }
                        break;
                    case 6:
                        Console.WriteLine("Digite a Extensão:");
                        if (!gerente.setExtensao(lerInt()))
                        {
                            erro("extensão");
                            Console.ReadKey();
                        }
                        break;
                    case 7:
                        Console.WriteLine("Digite a data(DD/MM/AAAA):");
                        if (!gerente.setDataNascimento(lerData()))
                        {
                            erro("data de nascimento errada");
                            Console.ReadKey();
                        }
                        break;
                }
            }
            return gerente;
        }
    }
}
