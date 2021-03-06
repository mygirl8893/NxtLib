using System.Collections.Generic;
using Newtonsoft.Json;
using NxtLib.Internal;

namespace NxtLib.Transactions
{
    public class UnconfirmedTransactionIdsResply : BaseReply
    {
        [JsonConverter(typeof(StringToIntegralTypeConverter))]
        public List<ulong> UnconfirmedTransactionIds { get; set; }
    }
}