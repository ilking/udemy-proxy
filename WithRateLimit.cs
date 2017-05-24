using System;

namespace ShekelExample
{
  class WithRateLimit : CoinApi
  {
    private CoinApi _realSubject;
    
    DateTime lastCalled = DateTime.MinValue;
    
    public WithRateLimit(CoinApi realSubject)
    {
      _realSubject = realSubject;
    }
    
    public override decimal GetValueInUSD(int shekels)
    {
      if (DateTime.Now - lastCalled < TimeSpan.FromSeconds(1))
      {
        throw new InvalidOperationException("Rate limit exceeded");
      } else
      {
        var value = _realSubject.GetValueInUSD(shekels);
        lastCalled = DateTime.Now;
        return value;
      }
    }
  }
}