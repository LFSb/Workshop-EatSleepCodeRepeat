using System;

namespace eu.sig.training.ch04.v1
{
  public class SavingsAccount
  {
    public CheckingAccount RegisteredCounterAccount { get; set; }

    public Transfer makeTransfer(string counterAccount, Money amount)
    {
      if (ValidateCounterAccount(counterAccount))
      {
        if (Sum(counterAccount) % 11 == 0)
        {
          var result = ReturnAccountTransfer(counterAccount, amount);

          if (result.CounterAccount.Equals(this.RegisteredCounterAccount))
          {
            return result;
          }

          throw new BusinessException("Counter-account not registered!");
        }
      }

      throw new BusinessException("Invalid account number!!");
    }

    public Transfer ReturnAccountTransfer(string counterAccount, Money amount)
    {
      // 2. Look up counter account and make transfer object:

      // <2>

      // 3. Check whether withdrawal is to registered counter account:

      var acct = Accounts.FindAcctByNumber(counterAccount);

      return new Transfer(this, acct, amount);
    }

    public Boolean ValidateCounterAccount(string counterAccount)
    {
      // 1. Assuming result is 9-digit bank account number, validate 11-test:
      if (String.IsNullOrEmpty(counterAccount) || counterAccount.Length != 9)
      {
        throw new BusinessException("Invalid account number!");
      }

      return true;
    }

    public Int32 Sum(string counterAccount)
    {
      var sum = 0;

      for (var i = 0; i < counterAccount.Length; i++)
      {
        sum = sum + (9 - i) * (int)Char.GetNumericValue(counterAccount[i]);
      }

      return sum;
    }
  }
}
