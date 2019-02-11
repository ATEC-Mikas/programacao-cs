using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace projeto
{
    class Program
    {
        //Ler e guardar chaves
        public static void GuardarChavesFavoritas(List<Chave> favoritas)
        {
            StreamWriter chavewr = new StreamWriter(@"favoritas.txt");
            foreach(Chave c in favoritas)
            {
                chavewr.WriteLine(c.toFile());
            }
            chavewr.Close();
        }
        public static void GuardarUmaChave(Chave fav)
        {
            List<Chave> temp = CarregarChavesFavoritas();
            temp.Add(fav);
            GuardarChavesFavoritas(temp);
        }
        public static List<Chave> CarregarChavesFavoritas()
        {
            List<Chave> temp = new List<Chave>();
            if (!File.Exists(@"favoritas.txt"))
                File.Create(@"favoritas.txt").Close();
            StreamReader chaverd = new StreamReader(@"favoritas.txt");
            while(!chaverd.EndOfStream)
            {
                try
                {

                    string linha = chaverd.ReadLine();
                    string[] atributos = linha.Split(';');
                    if(atributos.Length>=9&&atributos.Length<12)
                    {
                        Chave c = new Chave(int.Parse(atributos[0]),
                                            int.Parse(atributos[1]),
                                            int.Parse(atributos[2]),
                                            int.Parse(atributos[3]),
                                            int.Parse(atributos[4]),
                                            int.Parse(atributos[5]),
                                            int.Parse(atributos[6])
                                        );
                        for(int i=0;i<int.Parse(atributos[7]);i++)
                        {
                            c.adicionarNSuplementar(int.Parse(atributos[8 + i]));
                        }
                        c.setESuplementar(int.Parse(atributos[atributos.Length - 1]));
                        temp.Add(c);
                    }
                }
                catch(Exception e)
                {
                    escreverLog("Erro", "Erro a carregar chave favorita (" + e.Message + ") - Verificar ficheiro");
                }
            }
            chaverd.Close();
            return temp;
        }
        //Função para reportar erros
        public static void erro(string s)
        {
            Console.WriteLine("O/a "+s+" que forneceu é invalido/a");
            escreverLog("Warning", "O utilizador forneceu um(a) " + s + " invalida");
        }
        //Funções para auxiliar a entrada de dados
        public static int LerInt()
        {
            int o = 0;
            while (!int.TryParse(Console.ReadLine(), out o))
                Console.WriteLine("Tem de introduzir um valor inteiro");
            return o;
        }
        public static bool LerEscolhaSN()
        {
            char c;
            do
            {
                c = Console.ReadKey().KeyChar;
                if (c != 'S' && c != 's' && c != 'N' && c != 'n')
                    Console.WriteLine("Erro, tem de escolher (s) ou (n)");
            } while (c != 'S' && c != 's' && c != 'N' && c != 'n');
            Console.WriteLine();
            if (c == 'S' || c == 's')
                return true;
            else
                return false;
        }
        //Funções para auxiliar a saida e tratamento de erros
        public static void sair()
        {
            Console.Clear();
            Console.WriteLine("A sair do programa...");
            System.Threading.Thread.Sleep(1000);
            Environment.Exit(0);
        }
        //Escrever nas logs
        public static void escreverLog(string tipo,string desc)
        {
            StreamWriter logs = new StreamWriter(@"logs.txt", true);
            logs.WriteLine("["+tipo.ToUpper()+"] " + DateTime.Now.ToString() + ": "+desc);
            logs.Close();
        }
        //Funções relacionadas com interação com a chave
        public static Chave inserirchave()
        {
            Chave c = new Chave();
            for(int i=1;i<=5;i++)
            {
                Console.WriteLine("Numero "+i+":");
                while (!c.setNumero(LerInt(), i))
                    erro("numero");
            }
            for(int i=1;i<=2;i++)
            {
                Console.WriteLine("Estrela "+i+":");
                while (!c.setEstrela(LerInt(), i))
                    erro("estrela");
            }
            Console.WriteLine("Deseja ter numeros suplementares? (S/N)");
            if(LerEscolhaSN())
            {
                int ns;
                do
                {
                    Console.WriteLine("Quantos numeros suplementares (max de 2):");
                    ns = LerInt();
                    if(ns <= 0 || ns > 2)
                        Console.WriteLine("Numero invalido, máximo de 2\n");
                } while (ns <= 0 || ns > 2);
                for(int i=1;i<=ns;i++)
                {
                    Console.WriteLine("Numero suplementar "+i+":");
                    while (!c.adicionarNSuplementar(LerInt()))
                        erro("numero suplementar");
                }
            }
            Console.WriteLine("Deseja ter uma estrela suplementar? (S/N):");
            if(LerEscolhaSN())
            {
                Console.WriteLine("Estrela suplementar:");
                while (!c.setESuplementar(LerInt()))
                    erro("estrela suplementar");
            }
            Console.WriteLine("Deseja guardar esta chave? (S/N)");
            if (LerEscolhaSN())
                GuardarUmaChave(c);
            return c;
        }
        public static Chave carregarchave()
        {
            List<Chave> listaChaves = CarregarChavesFavoritas();
            if(listaChaves.Count==0)
            {
                Console.WriteLine("Como não tem nenhuma chave guardada irá ter de introduzir uma...");
                return inserirchave();
            }
                int opc;
            do
            {
                Console.Clear();
                int i = 0;
                foreach (Chave c in listaChaves)
                {
                    i++;
                    Console.WriteLine(i + " - " + c.toString());
                }
                opc = LerInt();
            } while (opc <= 0 || opc > listaChaves.Count);
            return listaChaves[opc - 1];
        }
        public static Chave chavealeatoria()
        {
            Chave c = new Chave(true);
            c.destrancarChave();
            Console.WriteLine(c.toString("aleatória"));
            Console.WriteLine("Deseja ter numeros suplementares? (S/N)");
            if (LerEscolhaSN())
            {
                int ns;
                do
                {
                    Console.WriteLine("Quantos numeros suplementares (max de 2):");
                    ns = LerInt();
                    if (ns <= 0 || ns > 2)
                        Console.WriteLine("Numero invalido, máximo de 2\n");
                } while (ns <= 0 || ns > 2);
                c.gerarNSuplementar(ns);
            }
            Console.WriteLine("Deseja ter uma estrela suplementar? (S/N):");
            if (LerEscolhaSN())
            {
                c.gerarESuplementar();
            }
            Console.WriteLine(c.toString("aleatória"));
            Console.WriteLine("Deseja guardar esta chave? (S/N)");
            if (LerEscolhaSN())
                GuardarUmaChave(c);
            return c;
        }
        public static void editarChave(int pos)
        {
            pos--;
            int opc;
            int i;
            int[] aux = { -1,-1,-1,-1, -1, -1, -1, -1,-1};
            //aux[0] - delimitador estrelas
            //aux[1] - delimitador numeros suplementares 
            //aux[2] - delimitador estrelas suplementares 
            //aux[3] - delimitador adicionar numero suplementar
            //aux[4] - delimitador remover numero suplementar
            //aux[5] - delimitador adicionar estrela suplementar
            //aux[6] - delimitador remover estrela suplementar
            //aux[7] - delimitador remover chave
            List<Chave> listaChave = CarregarChavesFavoritas();
            do
            {
                do{
                Console.Clear();
                listaChave[pos].organizarChave();
                i = 0;
                foreach (int num in listaChave[pos].getNumeros())
                {
                    i++;
                    Console.WriteLine(i + " - Numero " + i + " - " + num);
                }
                aux[0] = i;
                foreach (int num in listaChave[pos].getEstrelas())
                {
                    i++;
                    Console.WriteLine(i + " - Estrela " + (i - aux[0]) + " - " + num);
                }
                aux[1] = i;
                foreach (int num in listaChave[pos].getNSuplementar())
                {
                    i++;
                    Console.WriteLine(i + " - Numero suplementar " + (i - aux[1]) + " - " + num);
                }
                aux[2] = i;
                if (listaChave[pos].getESuplementar() != -1)
                {
                    i++;
                    aux[3] = i;
                    Console.WriteLine(i + " - Estrela suplementar - " + listaChave[pos].getESuplementar());
                }
                if(listaChave[pos].getNSuplementar().Length<2)
                {
                    i++;
                    aux[4] = i;
                    Console.WriteLine(i + " - Adicionar Numero suplementar");
                }
                if(listaChave[pos].getNSuplementar().Length>0)
                    {
                        i++;
                        aux[5] = i;
                        Console.WriteLine(i+" - Remover Numero suplementar");
                    }
                if(listaChave[pos].getESuplementar()==-1)
                    {
                        i++;
                        aux[6] = i;
                        Console.WriteLine(i+" - Adicionar Estrela suplementar");
                    }
                    if (listaChave[pos].getESuplementar() != -1)
                    {
                        i++;
                        aux[7] = i;
                        Console.WriteLine(i + " - Remover Estrela suplementar");
                    }
                i++;
                aux[8] = i;
                Console.WriteLine(i+" - Eliminar chave");
                Console.WriteLine("\n\n0 - Sair");
                    opc = LerInt();
                } while (opc < 0 || opc > i);
                if (opc == 0)
                    return;

                if (opc <= aux[0] && aux[0] != -1)
                {
                    listaChave[pos] = chaveAlterarNumero(listaChave[pos], opc);
                }
                else if (opc <= aux[1] && aux[1] != -1)
                {
                    listaChave[pos] = chaveAlterarEstrela(listaChave[pos], opc - aux[0]);
                }
                else if (opc <= aux[2] && aux[2] != -1)
                {
                    listaChave[pos] = chaveAlterarNSuplementar(listaChave[pos], opc - aux[1]);
                }
                else if (opc == aux[3] && aux[3] != -1)
                {
                    listaChave[pos] = chaveAlterarESuplementar(listaChave[pos]);
                }
                else if (opc == aux[4] && aux[4] != -1)
                    listaChave[pos] = chaveAdicionarNSuplementar(listaChave[pos]);
                else if (opc == aux[5] && aux[5] != -1)
                    listaChave[pos] = chaveRemoverNSuplementar(listaChave[pos]);
                else if (opc == aux[6] && aux[6] != -1)
                    listaChave[pos] = chaveAdicionarESuplementar(listaChave[pos]);
                else if (opc == aux[7] && aux[7] != -1)
                    listaChave[pos] = chaveRemoverESuplementar(listaChave[pos]);
                else if (opc == aux[8] && aux[8] != -1)
                {
                    Console.WriteLine("De certeza que pretende apagar a chave? (s/n)");
                    if(LerEscolhaSN())
                    {
                        listaChave.Remove(listaChave[pos]);
                        GuardarChavesFavoritas(listaChave);
                        Console.WriteLine("A apagar...");
                        System.Threading.Thread.Sleep(1000);
                        return;
                    }
                }
                GuardarChavesFavoritas(listaChave);
            } while (opc!=0);
        }
        //Funções para editar as chave favorita
        public static Chave chaveAlterarNumero(Chave c,int pos)
        {
            Console.Clear();
            Console.WriteLine("Alterar o numero "+c.getNumeros()[pos-1]+":");
            if(!c.setNumero(LerInt(),pos))
            {
                Console.WriteLine("Numero inválido. prima uma tecla para voltar ao menu...");
                Console.ReadKey();
            }
            return c;
        }
        public static Chave chaveAlterarEstrela(Chave c,int pos)
        {
            Console.Clear();
            Console.WriteLine("Alterar a estrela " + c.getEstrelas()[pos - 1] + ":");
            if (!c.setEstrela(LerInt(), pos))
            {
                Console.WriteLine("Estrela inválida. prima uma tecla para voltar ao menu...");
                Console.ReadKey();
            }
            return c;
        }
        public static Chave chaveAlterarNSuplementar(Chave c, int pos)
        {
            int aux= c.getNSuplementar()[pos - 1];
            Console.Clear();
            Console.WriteLine("Alterar o numero suplementar " + aux + ":");
            c.removerNSuplementar(aux);
            if (!c.adicionarNSuplementar(LerInt()))
            {
                Console.WriteLine("Numero inválido. prima uma tecla para voltar ao menu...");
                c.adicionarNSuplementar(aux);
                Console.ReadKey();
            }
            return c;
        }
        public static Chave chaveAlterarESuplementar(Chave c)
        {
            Console.Clear();
            Console.WriteLine("Alterar a estrela suplementar " + c.getESuplementar() + ":");
            if (!c.setESuplementar(LerInt()))
            {
                Console.WriteLine("Estrela inválida. prima uma tecla para voltar ao menu...");
                Console.ReadKey();
            }
            return c;
        }
        public static Chave chaveAdicionarNSuplementar(Chave c)
        {
            Console.Clear();
            Console.WriteLine("Numero suplementar: ");
            if (!c.adicionarNSuplementar(LerInt()))
            {
                Console.WriteLine("Numero suplementar inválido. prima uma tecla para voltar ao menu...");
                Console.ReadKey();
            }
            return c;
        }
        public static Chave chaveRemoverNSuplementar(Chave c)
        {
            Console.Clear();
            int i = 0;
            foreach(int num in c.getNSuplementar())
            {
                i++;
                Console.WriteLine(i+" - "+num);
            }
            if(!c.removerNSuplementar(c.getNSuplementar()[LerInt()-1]))
            {
                Console.WriteLine("Numero suplementar inválido. prima uma tecla para voltar ao menu...");
                Console.ReadKey();
            }

            return c;
        }
        public static Chave chaveAdicionarESuplementar(Chave c)
        {
            Console.Clear();
            Console.WriteLine("Estrela suplementar: ");
            if (!c.setESuplementar(LerInt()))
            {
                Console.WriteLine("Estrela suplementar inválida. prima uma tecla para voltar ao menu...");
                Console.ReadKey();
            }
            return c;
        }
        public static Chave chaveRemoverESuplementar(Chave c)
        {
            Console.Clear();
            Console.WriteLine("De certeza que pretende apagar a Estrela suplementar? (S/N)");
            if (LerEscolhaSN())
                c.removerESuplementar();
            return c;
        }
        //Funções de apresentação de menus
        public static int menuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("1 - Jogar");
            Console.WriteLine("2 - Editar chaves favoritas");
            Console.WriteLine("\n0 - Sair");
            return LerInt();
        }
        public static int menuJogar()
        {
            Console.Clear();
            Console.WriteLine("1 - Inserir uma chave manualmente");
            Console.WriteLine("2 - Escolher uma chave do ficheiro das chaves favoritas");
            Console.WriteLine("3 - Estou me a sentir com sorte (Chave Aleatória)");
            Console.WriteLine("\n0 - Sair");
            return LerInt();
        }
        public static void menuEditarChaves()
        {
            Console.Clear();
            int op;
            int i;
            List<Chave> listaChave;
            do
            {
                do
                {
                    listaChave = CarregarChavesFavoritas();
                    Console.Clear();
                    i = 0;
                    if(listaChave.Count==0)
                        Console.WriteLine("Não tem nenhuma chave guardada...");
                    foreach (Chave c in listaChave)
                    {
                        i++;
                        Console.WriteLine(c.toString("numero " + i));
                    }
                    Console.WriteLine("\n0 - Sair");
                    op = LerInt();
                } while (op < 0 || op > listaChave.Count);
                if(op!=0)
                    editarChave(op);
            } while (op != 0);
        }
        //Função de jogo
        public static void jogarChave(Chave c)
        {
            Console.Clear();
            Chave premiada = new Chave(true);
            List<int> match = c.match(premiada);
            Console.WriteLine(c.toString("escolhida")+"\n");
            Console.WriteLine(premiada.toString("premiada") + "\n");
            if(match.Count-1==0)
            {
                Console.WriteLine("Não ganhou nada...");
                Console.ReadKey();
                return;
            }
            Console.WriteLine("Acertou em "+(match.Count-1)+" numero(s)");
            bool flag = false;
            foreach(int n in match)
            {
                if(n==-1)
                    if(flag)
                        Console.Write(" | Estrelas:");
                    else
                        Console.Write("Estrelas:");
                else
                {
                    flag = true;
                    Console.WriteLine(n+" ");
                }
            }
            Console.ReadKey();
        }
        //Jogar
        public static void jogar()
        {
            try
            {
                int op;
                do
                {
                    op = menuJogar();
                    switch (op)
                    {
                        case 1:
                            {
                                Console.Clear();
                                Chave c=inserirchave();
                                jogarChave(c);
                                break;
                            }
                        case 2:
                            {
                                Console.Clear();
                                Chave c=carregarchave();
                                jogarChave(c);
                                break;
                            }
                        case 3:
                            {
                                Console.Clear();
                                Chave c = chavealeatoria();
                                jogarChave(c);
                                break;
                            }
                    }
                } while (op != 0);
            }
            catch (Exception e)
            {
                escreverLog("CRASH", "Crash no jogar (" + e.Message + ")");
                jogar();
            }
        }
        //Principal
        static void principal()
        {
            try
            {
                int op;
                do
                {
                    op = menuPrincipal();
                    switch (op)
                    {
                        case 1:
                            jogar();
                            break;
                        case 2:
                            menuEditarChaves();
                            break;
                        case 0:
                            sair();
                            break;
                    }
                } while (op != 0);
                Console.ReadKey();
        }
            catch (Exception e)
            {
                escreverLog("CRASH", "Crash no principal (" + e.Message + ")");
        principal();
    }
}
        //Main
        static void Main(string[] args)
        {
            principal();
        }
    }
}
