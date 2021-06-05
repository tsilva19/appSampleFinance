using System;

namespace DIO.Bank
{
  public class Conta
  {
    private TypeAccount TypeAccount { get; set; }
    private string Name { get; set; }

    private double Balance { get; set; }

    private double Credit { get; set; }

    public Conta(TypeAccount typeAccount, string name, double balance, double credit )
    {
      this.TypeAccount = typeAccount;
      this.Name = name;
      this.Balance = balance;
      this.Credit = credit;

    }



    public bool Withdraw(double amount)
    {
      //Validation Balance
      if (this.Balance - amount < (this.Credit * -1))
      {
        Console.WriteLine("Insufficient funds!!");
        return false;
      }

      this.Balance -= amount;
      //this.Balance = this.Balance - amount;

      Console.WriteLine("the current account balance of {0} is {1} ", this.Name, this.Balance);
      return true;
    }

    public void Deposit(double depositAmount)
    {
      this.Balance += depositAmount;
      //this.Balance = this.Balance + depositAmount;
      Console.WriteLine("the current account balance of {0} is {1} ", this.Name, this.Balance);
    }

    public void Transfer(double transferValue, Conta destinationAccount)
    {
      if (this.Withdraw(transferValue))
      {
        destinationAccount.Deposit(transferValue);
      }
    }

    public override string ToString()
    {
      string retorno = "";
      retorno += "TipoConta " + this.TypeAccount + " | ";
      retorno += "Nome " + this.Name + " | ";
      retorno += "Saldo " + this.Balance + " | ";
      retorno += "Credito " + this.Credit + " | ";
      return retorno;
    }



  }


}