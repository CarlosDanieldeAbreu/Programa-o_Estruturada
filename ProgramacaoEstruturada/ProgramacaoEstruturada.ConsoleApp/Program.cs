using System;
using System.Linq;

namespace ProgramacaoEstruturada.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] valor = new int[10];

            SelecionaOpcao(valor);
        }
        static void SelecionaOpcao(int[] valor)
        {
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("====MENU====");
                Console.ResetColor();
                Console.WriteLine("Digite: \n1 - Inserir números \n2 - Remover número \n3 - Mostrar números \n4 - Mostrar números negativos \n5 - Mostrar o maior número \n6 - Mostrar os três maiores números \n7 - Mostrar o menor número \n8 - Mostrar a média dos números \n9 - Sair");
                string strOpcao = Console.ReadLine();
                int opcao = Convert.ToInt32(strOpcao);
                Console.Clear();
                Console.WriteLine();
                if(opcao == 1)
                {
                    InserirOsnumeros(valor);
                }else if(opcao == 2)
                {
                    RemoverNúmeroDoArray(valor);
                }
                else if(opcao == 3)
                {
                    MostraOsValoresDaSequencia(valor);
                }
                else if (opcao == 4)
                {
                    int[] valoresNegativos = VerificaSeTemNumeroNegativo(valor);
                    Console.Write("Os valores negativos são: ");
                    Console.WriteLine(String.Join(",", valoresNegativos));
                }
                else if (opcao == 5)
                {
                    Console.WriteLine("O maior número é:" + VerificaQualEoMaior(valor));
                }
                else if (opcao == 6)
                {
                    int[] tresMaiores = VerificaOsTresMaioresNumeros(valor);
                    Console.Write("Os maiores números são:");
                    Console.WriteLine(String.Join(",", tresMaiores));
                }
                else if (opcao == 7)
                {
                    Console.WriteLine("O menor número é:" + VerificaQualEoMenor(valor));
                }
                else if (opcao == 8)
                {
                    Console.WriteLine("\nValor medio dos números:" + calculo(valor));
                }
                else if (opcao == 9)
                {
                    break;
                }
            }
        }
        static int[] RemoverNúmeroDoArray(int[] valor)
        {
            MostraOsValoresDaSequencia(valor);
            Console.WriteLine("");
            Console.WriteLine("Digite o número que deseja remover: ");
            string strRemover = Console.ReadLine();
            int Remover = Convert.ToInt32(strRemover);
            Console.WriteLine("");
            Console.WriteLine("O(s) número(s) foi(ram) excluido com sucesso: ");

            valor = valor.Where(e => e != Remover).ToArray();
            Console.WriteLine(String.Join(",", valor));
            return valor;
        }
        static void MostraOsValoresDaSequencia(int[] valor)
        {
            Console.Write("Os valores são: ");
            Console.WriteLine(String.Join(",", valor));
        }
        static int[] VerificaOsTresMaioresNumeros(int[] valor)
        {
            Array.Sort(valor);
            Array.Reverse(valor);

            int[] tresMaioresNumeros = new int[3];

            for(int i = 0;i < tresMaioresNumeros.Length; i++)
            {
                tresMaioresNumeros[i] = valor[i];
            }
            return tresMaioresNumeros;
        }
        static int VerificaQualEoMaior(int[] valor)
        {
            int verificaOmaior = int.MinValue;
            for (int i = 0; i < valor.Length; i++)
            {
                if (valor[i] > verificaOmaior)
                {
                    verificaOmaior = valor[i];
                }
            }
            return verificaOmaior;
        }
        static int VerificaQualEoMenor(int[] valor)
        {
            int verificaOmenor = int.MaxValue;
            for (int i = 0; i < valor.Length; i++)
            {
                if (valor[i] < verificaOmenor)
                {
                    verificaOmenor = valor[i];
                }
            }
            return verificaOmenor;
        }
        static int[] VerificaSeTemNumeroNegativo(int[] valor)
        {
            Array.Sort(valor);
            int contador = 0;
            for (int i = 0; i < valor.Length; i++)
            {
                if (valor[i] < 0)
                {
                    contador++;
                } 
            }
            int[] verificaNegativos = new int[contador];
            for (int i = 0;i < verificaNegativos.Length; i++)
            {
                verificaNegativos[i] = valor[i];
            }
            return verificaNegativos;
        }
        static void InserirOsnumeros(int[] valor)
        {
            for (int i = 0; i < valor.Length; i++)
            {
                Console.Write("Insira o " + (i + 1) + "° valor: ");
                string strValor = Console.ReadLine();
                valor[i] = int.Parse(strValor);
            }
        }
        static int calculo(int[] valor)
        {
            int valorMedio = 0;
            int soma = 0;
            for (int i = 0; i < valor.Length; i++)
                soma += valor[i];
            valorMedio = soma / valor.Length;
            return valorMedio;
        }
    }
}
