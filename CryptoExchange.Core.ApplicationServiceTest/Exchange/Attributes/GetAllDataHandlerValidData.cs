using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace CryptoExchange.Core.ApplicationServiceTest.Exchange.Attributes
{
    public class GetAllDataHandlerValidData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            return new List<object[]>()
            {
               new object[] {  CryptoExchange.Core.RequestResponse.Common.CurrencyType.USD },
               new object[] {  CryptoExchange.Core.RequestResponse.Common.CurrencyType.AUD },
               new object[] {  CryptoExchange.Core.RequestResponse.Common.CurrencyType.EUR },
               new object[] {  CryptoExchange.Core.RequestResponse.Common.CurrencyType.BRL },
               new object[] {  CryptoExchange.Core.RequestResponse.Common.CurrencyType.GBP },

            };
        }
    }
}
