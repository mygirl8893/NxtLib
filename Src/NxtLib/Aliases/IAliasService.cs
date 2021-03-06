using System;
using System.Threading.Tasks;

namespace NxtLib.Aliases
{
    public interface IAliasService
    {
        Task<TransactionCreatedReply> BuyAlias(AliasLocator query, Amount amount, CreateTransactionParameters parameters);
        Task<TransactionCreatedReply> DeleteAlias(AliasLocator query, CreateTransactionParameters parameters);
        Task<AliasReply> GetAlias(AliasLocator query, ulong? requireBlock = null, ulong? requireLastBlock = null);
        Task<AliasCountReply> GetAliasCount(Account account, ulong? requireBlock = null, ulong? requireLastBlock = null);

        Task<AliasesReply> GetAliases(Account account, DateTime? timeStamp = null, int? firstIndex = null,
            int? lastIndex = null, ulong? requireBlock = null, ulong? requireLastBlock = null);

        Task<AliasesReply> GetAliasesLike(string prefix, int? firstIndex = null, int? lastIndex = null,
            ulong? requireBlock = null, ulong? requireLastBlock = null);

        Task<TransactionCreatedReply> SellAlias(AliasLocator query, Amount price, CreateTransactionParameters parameters,
            Account recipient = null);

        Task<TransactionCreatedReply> SetAlias(string aliasName, string aliasUri, CreateTransactionParameters parameters);
    }
}