using System;
using System.Threading;

namespace ShekelExample
{
  public class Client
  {
    public void Execute(int shekels)
    {
      var service = new WithRateLimit(new ShekelCoinApi());
      
      for (int i = 0; i < 25; i++)
      {
        try
        {
          Console.WriteLine("${0}", service.GetValueInUSD(shekels));
        }
        catch(Exception ex)
        {
          Console.WriteLine(ex.Message);
        }
        Thread.Sleep(100);
      }
    }
  }
}