using System;
using Transferencia_Bancaria.Enum;
using Transferencia_Bancaria.Classes;
using System.Collections.Generic;

namespace Transferencia_Bancaria
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while(opcaoUsuario !="7")
            {
                switch (opcaoUsuario)
                {
                case "1":
                    ListarContas();
                    break;
                case "2":
                    InserirConta();
                    break;
                case "3":
                    Transferir();
                    break;
                case "4":
                    Sacar();
                    break;
                case "5":
                    Depositar();
                    break;
                case "6":
                    Console.Clear();
                    break;
                default:
                    Console.WriteLine("Voce precisa escolher uma opção");
                    Console.WriteLine("-------------------------------");
                    break;
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Até a próxima!");
        }
        private static string ObterOpcaoUsuario()
           {
               Console.WriteLine();
               Console.WriteLine("----------------------------");
               Console.WriteLine("| Informe a opção desejada |");
               Console.WriteLine("----------------------------");
               Console.WriteLine("   1) Listar contas         ");
               Console.WriteLine("   2) Inserir nova conta    ");
               Console.WriteLine("   3) Transferir            ");
               Console.WriteLine("   4) Sacar                 ");
               Console.WriteLine("   5) Depositar             ");
               Console.WriteLine("   6) Limpar tela           ");
               Console.WriteLine("   7) Sair                  ");
               Console.WriteLine();

               string opcaoUsuario = Console.ReadLine();
               Console.WriteLine();
               return opcaoUsuario;    
            }
        public static void ListarContas()
        {
            if(listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }

            Console.Write("Contas Cadastradas: ");
            Console.WriteLine();
                for( int i = 0; i < listaContas.Count; i++)
                {
                    Conta conta = listaContas[i];
                    Console.WriteLine($"{i})  {conta.ToString()} ");
                }
        }
        private static void InserirConta()
        {
            Console.WriteLine("Tipo de conta");
            Console.Write(" 1- Pessoa Física || 2- Pessoa Jurídica ?   ");
            int tipoDeConta = int.Parse(Console.ReadLine());
            Console.Write("Qual o nome da conta ?   ");
            string Nome = Console.ReadLine();
            Console.Write("Digite o valor de cheque especial da conta ?   ");
            double Credito = double.Parse(Console.ReadLine());
            double Saldo = 0; // A conta só pode receber saldo com Depósito ou transferência.
            Conta conta = new Conta((TipoConta)tipoDeConta, Saldo, Credito, Nome);
            listaContas.Add(conta);
        }
        private static void Transferir()
        {
            Console.Write("Digite o número da conta pagadora:  ");
            int contaSaida = Console.Read();
            Console.Write("Qual o valor a ser transferido?  ");
            double Valor = Console.Read();
            Console.Write("Qual conta receberá a transferência?  ");
            int contaDestino = Console.Read();
            listaContas[contaSaida].Transferir(Valor,listaContas[contaDestino]);
        }
        private static void Depositar()
        {
            Console.Write("Qual a conta a receber o depósito ?  ");
            int indiceConta = Console.Read();
            Console.Write("Qual o valor a ser depositado ?  ");
            double Valor = Console.Read();
            listaContas[indiceConta].Depositar(Valor);
        }
        private static void Sacar()
        {
            Console.Write("Digite o número da conta:  ");
            int indiceConta = Console.Read();
            Console.Write("Qual o valor a ser sacado ?  ");
            double Valor = Console.Read();
            listaContas[indiceConta].Sacar(Valor);
        }
    }
}