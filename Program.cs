using System;

namespace ShekelExample
{
  class Program
  {
    public static void Main(string[] args)
    {
      if (args.Length < 1)
      {
        Console.WriteLine("Insufficient Arguments.");
      }
      else
      {
        var client = new Client();
        client.Execute(int.Parse(args[0]));
      }
    }
  }
}