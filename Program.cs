using System;
using System.Collections.Generic;

namespace DIO.Bank
{
  class Program
  {
    static List<Conta> listaContas = new List<Conta>();

    static void Main(string[] args)
    {

      string optionUser = UserOption();


      while (optionUser.ToUpper() != "X")
      {
        switch (optionUser)
        {
          case "1":
            ListarContas();
            break;
          case "2":
            InserirConta();
            break;
          case "3":
            Trasferir();
            break;
          case "4":
            Sacar();
            break;
          case "5":
             Depositar();
            break;
          case "C":
            Console.Clear();
            break;

          default:
            throw new ArgumentOutOfRangeException();
        }

        optionUser = UserOption();
      }
      Console.WriteLine("Obrigado por utilizar nossos serviços");
      Console.ReadLine();
    }

    private static void Trasferir()
    {
        Console.WriteLine("Digite o numero de Origem: ");
        int indiceContaOrigem = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o numero da Conta DEstino: ");
        int indiceContaDestino = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o valor a ser transferido: ");
        double valoTransferencia = double.Parse(Console.ReadLine());

        listaContas[indiceContaOrigem].Transfer(valoTransferencia, listaContas[indiceContaDestino]);
    }

    private static void Sacar()
    {
        Console.WriteLine("Digite o numero da Conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o valor a ser sacado: ");
        double valorSaque = double.Parse(Console.ReadLine());

        listaContas[indiceConta].Withdraw(valorSaque);
    }

    private static void Depositar()
    {
        Console.WriteLine("Digite o numero da Conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        Console.WriteLine("Digite o valor a ser Depositado: ");
        double valorDeposito = double.Parse(Console.ReadLine());

        listaContas[indiceConta].Deposit(valorDeposito);
    }

    private static void InserirConta()
    {
      Console.WriteLine("Inserir Conta");

      Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Conta PJ: ");
      int entradaTipoConta = int.Parse(Console.ReadLine());

      Console.WriteLine("Digite o nome do Cliente: ");
      string entradaNome = Console.ReadLine();

      Console.WriteLine("Digite o saldo inicial: ");
      double entradaSaldo = double.Parse(Console.ReadLine());

      Console.WriteLine("Digite o Credito: ");
      double entradaCredito = double.Parse(Console.ReadLine());

      Conta novaConta = new Conta(typeAccount: (TypeAccount)entradaTipoConta,
                                  name: entradaNome,
                                  balance: entradaSaldo,
                                  credit: entradaCredito);

      listaContas.Add(novaConta);


    }

    private static void ListarContas()
    {
      Console.WriteLine("Listar Contas");

      if (listaContas.Count == 0)
      {
        Console.WriteLine("Nenhuma Conta Cadastrada");
        return;
      }

      for (int i = 0; i < listaContas.Count; i++)
      {
        Conta conta = listaContas[i];
        Console.WriteLine("#{0} - ", i);
        Console.WriteLine(conta);
      }
    }

    private static string UserOption()
    {
      Console.WriteLine();
      Console.WriteLine("THIAGO BANK A SEU DISPOR");
      Console.WriteLine("Informe a opção desejada: ");

      Console.WriteLine("1 - Listar Contas");
      Console.WriteLine("2 - Inserir nova conta");
      Console.WriteLine("3 - Transferir");
      Console.WriteLine("4 - Sacar");
      Console.WriteLine("5 - Depositar");
      Console.WriteLine("C  - Limpar Tela");
      Console.WriteLine("X - Sair");
      Console.WriteLine();

      string optionUser = Console.ReadLine().ToUpper();
      Console.WriteLine();
      return optionUser;
    }
  }
}
