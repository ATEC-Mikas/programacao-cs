using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

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
                if(c != 'M' && c != 'm' && c != 'F' && c != 'f' && c != 'N' && c != 'n')
                    Console.WriteLine("Erro.");
            }while (c != 'M' && c != 'm' && c != 'F' && c != 'f' && c != 'N' && c != 'n');
            return c;

        }

        public static ArrayList carregarCandidatos(ArrayList candidatos,bool logs)
        {
            int cont = 0;
            if (!File.Exists("Candidatos.txt"))
                File.Create("Candidatos.txt").Close();
            StreamReader rd = new StreamReader("Candidatos.txt");
            while (!rd.EndOfStream)
            {
                string linha = rd.ReadLine();
                linha = linha.Replace('/', ';');
                string[] atributos = linha.Split(';');
                if (logs)
                {
                    foreach (string teste in atributos)
                        Console.Write(teste+" ");
                }
                Console.WriteLine();
                if (atributos.Length>0)
                {
                    Candidato c = new Candidato(
                                            atributos[0],
                                            atributos[1],
                                            int.Parse(atributos[2]),
                                            int.Parse(atributos[3]),
                                            int.Parse(atributos[4]),
                                            Char.Parse(atributos[5]),
                                            atributos[6],
                                            int.Parse(atributos[7])
                                            );
                    int chato = 8;
                    for (int i = 0; i < int.Parse(atributos[chato]); i++) 
                        c.adicionarHabilitacao(atributos[chato + 1 + i]);
                    chato += int.Parse(atributos[chato])+1;
                    for (int i = 0; i < int.Parse(atributos[chato]); i++)
                        c.adicionarExperiencia(atributos[chato + 1 + i]);
                    chato += int.Parse(atributos[chato])+1;
                    for (int i = 0; i < int.Parse(atributos[chato]); i++)
                        c.adicionarCompetencia(atributos[chato + 1 + i]);
                    candidatos.Add(c);
                    cont++;
                }
            }
            if (logs)
                Console.WriteLine(cont + " Candidato(s) processado(s).");
            rd.Close();

            return candidatos;
        }

        public static int guardarCandidatos(ArrayList candidatos, bool logs)
        {
            int cont = 0;
            StreamWriter wd = new StreamWriter(@"Candidatos.txt");

            foreach (Candidato obj in candidatos)
            {
                string linha = obj.getNome()+";"
                             + obj.getLocalidade() + ";"
                             + obj.getData().toString() + ";"
                             + obj.getSexo(true).ToString() + ";"
                             + obj.getEmail() + ";"
                             + obj.getTelefone().ToString() + ";"
                             ;
                string[] holder = obj.getHabilitacoes();
                for (int i = 0; i <= int.Parse(holder[0]); i++)
                    linha += holder[i] + ";";
                holder = obj.getExperiencias();
                for (int i = 0; i <= int.Parse(holder[0]); i++)
                    linha += holder[i] + ";";
                holder = obj.getCompetencias();
                for (int i = 0; i <= int.Parse(holder[0]); i++)
                    linha += holder[i] + ";";
                wd.WriteLine(linha);
                cont++;
            }
            if (logs)
                Console.WriteLine(cont + " Candidatos(s) guardado(s).");
            wd.Close();
            return cont;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine(c.toString());

            ArrayList candidatos = new ArrayList();

            candidatos = carregarCandidatos(candidatos,false);
            //Candidato de = new Candidato();

            //de.adicionarCompetencia("Atirar tijolos");
            //de.adicionarCompetencia("Atirar Neves");
            //de.adicionarExperiencia("Competição de atiramento nevástico");
            //de.adicionarHabilitacao("certificado de atiramento de tijolos a 100m");

            //candidatos.Add(de);

            int opc;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Inserir Candidato");
                Console.WriteLine("2 - Mostrar Candidatos");
                Console.WriteLine("3 - Alterar Candidatos");
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
                        Console.WriteLine("\nInsira o email: ");
                        while (!c.setEmail(Console.ReadLine()))
                            erro("Email");
                        Console.WriteLine("Insira o telefone");
                        while (!c.setTelefone(lerInt()))
                            erro("Telefone");
                        int n;
                        Console.WriteLine("Quantas habilitações? (máximo de três):");
                        do
                        {
                            n = lerInt();
                            if (n < 0 || n > 3) 
                                erro("numero de habilitações");
                        } while (n < 0 || n > 3);
                        for(int i=0;i<n;i++)
                        {
                            Console.WriteLine("Habilitação nrº" + (i+1) + ":");
                            while (!c.adicionarHabilitacao(Console.ReadLine()))
                                erro("Habilitação");
                        }
                        Console.WriteLine("Quantas Experiencias? (máximo de cinco):");
                        do
                        {
                            n = lerInt();
                            if (n < 0 || n > 5)
                                erro("numero de experiencias");
                        } while (n < 0 || n > 5);
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("Experiencia nrº" + (i + 1) + ":");
                            while (!c.adicionarExperiencia(Console.ReadLine()))
                                erro("Experiencia");
                        }
                        Console.WriteLine("Quantas Competencias? (máximo de cinco):");
                        do
                        {
                            n = lerInt();
                            if (n < 0 || n > 5)
                                erro("numero de competencias");
                        } while (n < 0 || n > 5);
                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("Competencia nrº" + (i + 1) + ":");
                            while (!c.adicionarCompetencia(Console.ReadLine()))
                                erro("Competencia");
                        }
                        candidatos.Add(c);
                        break;
                    case 2:
                        Console.Clear();
                        //Console.WriteLine("TBD");
                        foreach (Candidato cand in candidatos)
                            Console.WriteLine(cand.toString());

                        Console.ReadKey();
                        break;
                    case 3:
                        candidatos = menuCandidatos(candidatos);
                        break;
                }
            } while (opc != 0);



            guardarCandidatos(candidatos, false);
        }
        public static ArrayList menuCandidatos(ArrayList candidatos)
        {
            int o;
            int escolha;
            do
            {
                o = 0;
                Console.Clear();
                foreach (Candidato cand in candidatos)
                {
                    o++;
                    Console.WriteLine(o + " - " + cand.getNome());
                }
                Console.WriteLine("\n\n0 - Sair");
                do
                {
                    escolha = lerInt();
                    if (escolha > candidatos.Count - 1 && escolha < 0)
                        Console.WriteLine("Erro.");
                } while (escolha > candidatos.Count - 1 && escolha < 0);
                if (escolha != 0)
                    candidatos[escolha - 1] = menuEditarCandidato((Candidato)candidatos[escolha - 1]);
            } while (escolha != 0);
            return candidatos;
        }

        public static Candidato menuEditarCandidato(Candidato c)
        {
            int escolha;
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Nome - " + c.getNome());
                Console.WriteLine("2 - Localidade - " + c.getLocalidade());
                Console.WriteLine("3 - Data de Nascimento - " + c.getData().toString());
                Console.WriteLine("4 - Sexo - " + c.getSexo());
                Console.WriteLine("5 - Email - " + c.getEmail());
                Console.WriteLine("6 - Telefone - " + c.getTelefone().ToString());
                Console.WriteLine("7 - Habilitações");
                Console.WriteLine("8 - Experiencias");
                Console.WriteLine("9 - Competencias");
                Console.WriteLine("\n\n0 - Sair");
                escolha = lerInt();
                switch(escolha)
                {
                    case 1:
                        Console.WriteLine("Digite o Nome:");
                        if (!c.setNome(Console.ReadLine()))
                        {
                            erro("nome");
                            Console.ReadKey();
                        }
                        break;
                    case 2:
                        Console.WriteLine("Digite o Localidade:");
                        if (!c.setLocalidade(Console.ReadLine()))
                        {
                            erro("localidade");
                            Console.ReadKey();
                        }
                        break;
                    case 3:
                        Console.WriteLine("Digite o Data de nascimento (DD/MM/AAAA):");
                        if (!c.setData(lerData()))
                        {
                            erro("data de nascimento");
                            Console.ReadKey();
                        }
                        break;
                    case 4:
                        Console.WriteLine("Insira o sexo(M/F/N):");
                        if (!c.setSexo(lerSexo()))
                        {
                            erro("sexo");
                            Console.ReadKey();
                        }
                        break;
                    case 5:
                        Console.WriteLine("Digite o Email:");
                        if (!c.setEmail(Console.ReadLine()))
                        {
                            erro("email");
                            Console.ReadKey();
                        }
                        break;
                    case 6:
                        Console.WriteLine("Digite o Telefone:");
                        if (!c.setTelefone(lerInt()))
                        {
                            erro("telefone");
                            Console.ReadKey();
                        }
                        break;
                    case 7:
                        int oph;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Habilitações atuais:");
                            string[] habilitacao = c.getHabilitacoes();
                            for (int i = 1; i <= int.Parse(habilitacao[0]); i++)
                                Console.WriteLine(i + " - " + habilitacao[i]);

                            Console.WriteLine("\n\n1 - Adicionar Habilitacao");
                            Console.WriteLine("2 - Remover Habilitacao");
                            Console.WriteLine("\n\n0 - Sair");
                            oph = lerInt();
                            switch(oph)
                            {
                                case 1:
                                    Console.WriteLine("\n\nDigite a nova Habilitação");
                                    if(!c.adicionarHabilitacao(Console.ReadLine()))
                                    {
                                        erro("Habilitacao");
                                        Console.ReadKey();
                                    }
                                    break;
                                case 2:
                                    int r;
                                    Console.WriteLine("\n\nQual pretende apagar:");
                                    r = lerInt();
                                    if (r > 0 && r <= int.Parse(habilitacao[0]))
                                        c.removerHabilitacao(r);
                                    break;
                            }
                        } while (oph != 0);

                        break;
                    case 8:
                        int ope;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Experencias atuais:");
                            string[] experiencia = c.getExperiencias();
                            for (int i = 1; i <= int.Parse(experiencia[0]); i++)
                                Console.WriteLine(i + " - " + experiencia[i]);

                            Console.WriteLine("\n\n1 - Adicionar Habilitacao");
                            Console.WriteLine("2 - Remover Habilitacao");
                            Console.WriteLine("\n\n0 - Sair");
                            ope = lerInt();
                            switch (ope)
                            {
                                case 1:
                                    Console.WriteLine("\n\nDigite a nova Experiencia");
                                    if (!c.adicionarExperiencia(Console.ReadLine()))
                                    {
                                        erro("Experencia");
                                        Console.ReadKey();
                                    }
                                    break;
                                case 2:
                                    int r;
                                    Console.WriteLine("\n\nQual pretende apagar:");
                                    r = lerInt();
                                    if (r > 0 && r <= int.Parse(experiencia[0]))
                                        c.removerExperiencia(r);
                                    break;
                            }
                        } while (ope != 0);
                        break;
                    case 9:
                        int opc;
                        do
                        {
                            Console.Clear();
                            Console.WriteLine("Competencias atuais:");
                            string[] competencia = c.getCompetencias();
                            for (int i = 1; i <= int.Parse(competencia[0]); i++)
                                Console.WriteLine(i + " - " + competencia[i]);

                            Console.WriteLine("\n\n1 - Adicionar Competencia");
                            Console.WriteLine("2 - Remover Competencia");
                            Console.WriteLine("\n\n0 - Sair");
                            opc = lerInt();
                            switch (opc)
                            {
                                case 1:
                                    Console.WriteLine("\n\nDigite a nova competencia");
                                    if (!c.adicionarCompetencia(Console.ReadLine()))
                                    {
                                        erro("Competencia");
                                        Console.ReadKey();
                                    }
                                    break;
                                case 2:
                                    int r;
                                    Console.WriteLine("\n\nQual pretende apagar:");
                                    r = lerInt();
                                    if (r > 0 && r <= int.Parse(competencia[0]))
                                        c.removerCompetencia(r);
                                    break;
                            }
                        } while (opc != 0);
                        break;
                }
            } while (escolha != 0);


            return c;
        }
    }
}
