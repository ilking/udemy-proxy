using System;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace ShekelExample
{
  class ShekelCoinApi : CoinApi
  {
    public override decimal GetValueInUSD(int shekels)
    {
      var request = WebRequest.Create(@"http://api.fixer.io/latest?base=ILS&symbols=USD");
      ConversionResponse json = null;
      
      using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
      {
        var serializer = new DataContractJsonSerializer(typeof(ConversionResponse));
        var obj = serializer.ReadObject(response.GetResponseStream());
        json = obj as ConversionResponse;
      }
      
      return (decimal) (json != null ? (shekels * json.Rates.USD) : 0f);
    }
  }
  
  [DataContract]
  public class ConversionResponse
  {
    [DataMember(Name = "rates")]
    public RatesResponse Rates { get; set; }
  }
  
  [DataContract]
  public class RatesResponse
  {
    [DataMember(Name="USD")]
    public float USD { get; set; }
  }
}