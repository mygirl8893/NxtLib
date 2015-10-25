﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using NxtLib.Internal;
using NxtLib.Local;

namespace NxtLib.Debug
{
    public class DebugService : BaseService, IDebugService
    {
        public DebugService(string baseAddress = Constants.DefaultNxtUrl)
            : base(baseAddress)
        {
        }

        public async Task<DoneReply> ClearUnconfirmedTransactions()
        {
            return await Post<DoneReply>("clearUnconfirmedTransactions");
        }

        public async Task<DumpPeersReply> DumpPeers(string version = null, int? weight = null, bool? connect = null,
            string adminPassword = null)
        {
            var queryParameters = new Dictionary<string, string>();
            queryParameters.AddIfHasValue(nameof(version), version);
            queryParameters.AddIfHasValue(nameof(weight), weight);
            queryParameters.AddIfHasValue(nameof(connect), connect);
            queryParameters.AddIfHasValue(nameof(adminPassword), adminPassword);
            return await Get<DumpPeersReply>("dumpPeers", queryParameters);
        }

        public async Task<DoneReply> FullReset()
        {
            return await Post<DoneReply>("fullReset");
        }

        public async Task<TransactionsListReply> GetAllBroadcastedTransactions(ulong? requireBlock = null, ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string>();
            queryParameters.AddIfHasValue(nameof(requireBlock), requireBlock);
            queryParameters.AddIfHasValue(nameof(requireLastBlock), requireLastBlock);
            return await Get<TransactionsListReply>("getAllBroadcastedTransactions", queryParameters);
        }

        public async Task<TransactionsListReply> GetAllWaitingTransactions(ulong? requireBlock = null, ulong? requireLastBlock = null)
        {
            var queryParameters = new Dictionary<string, string>();
            queryParameters.AddIfHasValue(nameof(requireBlock), requireBlock);
            queryParameters.AddIfHasValue(nameof(requireLastBlock), requireLastBlock);
            return await Get<TransactionsListReply>("getAllWaitingTransactions", queryParameters);
        }

        public async Task<LogReply> GetLog(int count)
        {
            var queryParameters = new Dictionary<string, string> {{nameof(count), count.ToString()}};
            return await Get<LogReply>("logReply", queryParameters);
        }

        // TODO: Implement with proper reply
        public async Task<JObject> GetStackTraces(int? depth = null)
        {
            var queryParameters = new Dictionary<string, string>();
            queryParameters.AddIfHasValue(nameof(depth), depth);
            return await Get("getStackTraces", queryParameters);
        }

        public async Task<DoneReply> LuceneReindex()
        {
            return await Post<DoneReply>("luceneReindex");
        }

        public async Task<BlocksReply<Transaction>> PopOff(HeightOrNumberOfBlocksLocator locator)
        {
            return await Post<BlocksReply<Transaction>>("popOff", locator.QueryParameters);
        }

        public async Task<DoneReply> RebroadcastUnconfirmedTransactions()
        {
            return await Post<DoneReply>("rebroadcastUnconfirmedTransactions");
        }

        public async Task<DoneReply> RequeueUnconfirmedTransactions()
        {
            return await Post<DoneReply>("requeueUnconfirmedTransactions");
        }

        public async Task<RetrievePrunedDataReply> RetrievePrunedData()
        {
            return await Post<RetrievePrunedDataReply>("retrievePrunedData");
        }

        public async Task<ScanReply> Scan(HeightOrNumberOfBlocksLocator locator, bool? validate = null)
        {
            var queryParameters = locator.QueryParameters;
            queryParameters.AddIfHasValue(nameof(validate), validate);
            return await Post<ScanReply>("scan", queryParameters);
        }

        public async Task<SetLoggingReply> SetLogging(string logLevel, IEnumerable<string> communicationEvents)
        {
            var queryParameters = new Dictionary<string, List<string>>();
            var communicationEventList = communicationEvents.ToList();
            if (communicationEventList.Any())
            {
                queryParameters.Add("communicationEvent", communicationEventList);
            }
            queryParameters.AddIfHasValue(nameof(logLevel), logLevel);
            return await Post<SetLoggingReply>("setLogging", queryParameters);
        }

        public async Task<ShutdownReply> Shutdown(bool? scan = null)
        {
            var queryParameters = new Dictionary<string, string>();
            queryParameters.AddIfHasValue(nameof(scan), scan);
            return await Post<ShutdownReply>("shutdown", queryParameters);
        }

        public async Task<DoneReply> TrimDerivedTables()
        {
            return await Post<DoneReply>("trimDerivedTables");
        }
    }
}
