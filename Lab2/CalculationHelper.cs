using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eu.sig.training.ch04;
using eu.sig.training.ch04.v1;

namespace EatSleepCodeRepeat
{
  public static class CalculationHelper
  {
    public static Int32 Sum(string counterAccount)
    {
      var sum = 0;

      for (var i = 0; i < counterAccount.Length; i++)
      {
        sum = sum + (9 - i) * (int)Char.GetNumericValue(counterAccount[i]);
      }

      return sum;
    }

    public static Transfer ReturnAccountTransfer(CheckingAccount checkingsAccount, string counterAccount, Money amount)
    {
      // 2. Look up counter account and make transfer object:

      // <2>

      // 3. Check whether withdrawal is to registered counter account:

      var acct = Accounts.FindAcctByNumber(counterAccount);

      return new Transfer(checkingsAccount, acct, amount);
    }

    public static Transfer ReturnAccountTransfer(SavingsAccount savingsAccount, string counterAccount, Money amount)
    {
      // 2. Look up counter account and make transfer object:

      // <2>

      // 3. Check whether withdrawal is to registered counter account:

      var acct = Accounts.FindAcctByNumber(counterAccount);

      return new Transfer(savingsAccount, acct, amount);
    }
  }
}
