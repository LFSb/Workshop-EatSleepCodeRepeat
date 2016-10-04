using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eu.sig.training.ch04;

namespace EatSleepCodeRepeat
{
  public static class ValidationHelper
  {

    private const int TransferLimit = 100;

    public static Boolean ValidateCounterAccount(string counterAccount)
    {
      // 1. Assuming result is 9-digit bank account number, validate 11-test:
      if (String.IsNullOrEmpty(counterAccount) || counterAccount.Length != 9)
      {
        throw new BusinessException("Invalid account number!");
      }

      return true;
    }

    public static Boolean ValidateAmount(Money amount)
    {
      return !amount.GreaterThan(TransferLimit);
    }

    public static bool ValidateParameters(Money amount, string counterAccount)
    {
      if (!ValidationHelper.ValidateCounterAccount(counterAccount))
      {
        throw new BusinessException("Invalid account number!");
      }

      if (!ValidationHelper.ValidateAmount(amount))
      {
        throw new BusinessException("Limit exceeded!");
      }

      return true;
    }
  }
}
