using System;
using EatSleepCodeRepeat;

namespace eu.sig.training.ch04.v1
{
  public class SavingsAccount
  {
    public CheckingAccount RegisteredCounterAccount { get; set; }

    public Transfer makeTransfer(string counterAccount, Money amount)
    {
      if (ValidationHelper.ValidateCounterAccount(counterAccount))
      {
        if (CalculationHelper.Sum(counterAccount) % 11 == 0)
        {
          var result = CalculationHelper.ReturnAccountTransfer(this, counterAccount, amount);

          if (result.CounterAccount.Equals(this.RegisteredCounterAccount))
          {
            return result;
          }

          throw new BusinessException("Counter-account not registered!");
        }
      }

      throw new BusinessException("Invalid account number!!");
    }

    
  }
}
