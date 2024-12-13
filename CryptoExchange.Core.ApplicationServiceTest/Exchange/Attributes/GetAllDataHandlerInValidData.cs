using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace CryptoExchange.Core.ApplicationServiceTest.Exchange.Attributes
{
    public class GetAllDataHandlerInValidData : DataAttribute
    {
        public override IEnumerable<object[]> GetData(MethodInfo testMethod)
        {
            return new List<object[]>()
            {
               new object[] {  50 },
               new object[] {  60 },
            };
        }
    }
}
