using System;
using EatSleepCodeRepeat;

namespace eu.sig.training.ch04.v1
{
  public class CheckingAccount
  {
    public Transfer MakeTransfer(String counterAccount, Money amount)
    {
      if (!ValidationHelper.ValidateParameters(amount, counterAccount))
      {
        if (CalculationHelper.Sum(counterAccount) % 11 == 0)
        {
          return CalculationHelper.ReturnAccountTransfer(this, counterAccount, amount);
        }
      }
      
      throw new BusinessException("Parameters were invalid!");
    }
  }
}