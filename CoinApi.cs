using System;

namespace ShekelExample
{
  abstract class CoinApi
  {
    public abstract decimal GetValueInUSD(int shekels);
  }
}
