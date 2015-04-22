using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Newtonsoft.Json.Linq;

namespace NxtLib.Internal
{
    internal class AttachmentConverter
    {
        private readonly JObject _attachments;
        private static readonly IReadOnlyDictionary<TransactionSubType, Func<JObject, Attachment>> AttachmentFuncs;

        static AttachmentConverter()
        {
            var attachmentFuncs = new Dictionary<TransactionSubType, Func<JObject, Attachment>>();

            attachmentFuncs.Add(TransactionSubType.AccountControlEffectiveBalanceLeasing, value => new AccountControlEffectiveBalanceLeasingAttachment(value));
            attachmentFuncs.Add(TransactionSubType.ColoredCoinsAskOrderCancellation, value => new ColoredCoinsAskOrderCancellationAttachment(value));
            attachmentFuncs.Add(TransactionSubType.ColoredCoinsAskOrderPlacement, value => new ColoredCoinsAskOrderPlacementAttachment(value));
            attachmentFuncs.Add(TransactionSubType.ColoredCoinsAssetIssuance, value => new ColoredCoinsAssetIssuanceAttachment(value));
            attachmentFuncs.Add(TransactionSubType.ColoredCoinsAssetTransfer, value => new ColoredCoinsAssetTransferAttachment(value));
            attachmentFuncs.Add(TransactionSubType.ColoredCoinsBidOrderCancellation, value => new ColoredCoinsBidOrderCancellationAttachment(value));
            attachmentFuncs.Add(TransactionSubType.ColoredCoinsBidOrderPlacement, value => new ColoredCoinsBidOrderPlacementAttachment(value));
            attachmentFuncs.Add(TransactionSubType.ColoredCoinsDividendPayment, value => new ColoredCoinsDividendPaymentAttachment(value));
            attachmentFuncs.Add(TransactionSubType.DigitalGoodsDelisting, value => new DigitalGoodsDelistingAttachment(value));
            attachmentFuncs.Add(TransactionSubType.DigitalGoodsDelivery, value => new DigitalGoodsDeliveryAttachment(value));
            attachmentFuncs.Add(TransactionSubType.DigitalGoodsFeedback, value => new DigitalGoodsFeedbackAttachment(value));
            attachmentFuncs.Add(TransactionSubType.DigitalGoodsListing, value => new DigitalGoodsListingAttachment(value));
            attachmentFuncs.Add(TransactionSubType.DigitalGoodsPriceChange, value => new DigitalGoodsPriceChangeAttachment(value));
            attachmentFuncs.Add(TransactionSubType.DigitalGoodsPurchase, value => new DigitalGoodsPurchaseAttachment(value));
            attachmentFuncs.Add(TransactionSubType.DigitalGoodsQuantityChange, value => new DigitalGoodsQuantityChangeAttachment(value));
            attachmentFuncs.Add(TransactionSubType.DigitalGoodsRefund, value => new DigitalGoodsRefundAttachment(value));
            attachmentFuncs.Add(TransactionSubType.MessagingAccountInfo, value => new MessagingAccountInfoAttachment(value));
            attachmentFuncs.Add(TransactionSubType.MessagingAliasAssignment, value => new MessagingAliasAssignmentAttachment(value));
            attachmentFuncs.Add(TransactionSubType.MessagingAliasBuy, value => new MessagingAliasBuyAttachment(value));
            attachmentFuncs.Add(TransactionSubType.MessagingAliasDelete, value => new MessagingAliasDeleteAttachment(value));
            attachmentFuncs.Add(TransactionSubType.MessagingAliasSell, value => new MessagingAliasSellAttachment(value));
            attachmentFuncs.Add(TransactionSubType.MessagingArbitraryMessage, value => null);
            //attachmentFuncs.Add(TransactionSubType.MessagingHubTerminalAnnouncement, TODO: .... );
            //attachmentFuncs.Add(TransactionSubType.MessagingPollCreation, TODO: .... );
            //attachmentFuncs.Add(TransactionSubType.MessagingVoteCasting, TODO: .... );
            attachmentFuncs.Add(TransactionSubType.MonetarySystemCurrencyDeletion, value => new MonetarySystemCurrencyDeletion(value));
            attachmentFuncs.Add(TransactionSubType.MonetarySystemCurrencyIssuance, value => new MonetarySystemCurrencyIssuanceAttachment(value));
            attachmentFuncs.Add(TransactionSubType.MonetarySystemCurrencyMinting, value => new MonetarySystemCurrencyMintingAttachment(value));
            attachmentFuncs.Add(TransactionSubType.MonetarySystemCurrencyTransfer, value => new MonetarySystemCurrencyTransferAttachment(value));
            attachmentFuncs.Add(TransactionSubType.MonetarySystemExchangeBuy, value => new MonetarySystemExchangeBuyAttachment(value));
            attachmentFuncs.Add(TransactionSubType.MonetarySystemExchangeSell, value => new MonetarySystemExchangeSellAttachment(value));
            attachmentFuncs.Add(TransactionSubType.MonetarySystemPublishExchangeOffer, value => new MonetarySystemPublishExchangeOfferAttachment(value));
            attachmentFuncs.Add(TransactionSubType.MonetarySystemReserveClaim, value => new MonetarySystemReserveClaimAttachment(value));
            attachmentFuncs.Add(TransactionSubType.PaymentOrdinaryPayment, value => null);
            attachmentFuncs.Add(TransactionSubType.MonetarySystemReserveIncrease, value => new MonetarySystemReserveIncreaseAttachment(value));

            AttachmentFuncs = new ReadOnlyDictionary<TransactionSubType, Func<JObject, Attachment>>(attachmentFuncs);
        }

        internal AttachmentConverter(JObject attachments)
        {
            _attachments = attachments;
        }

        internal Attachment GetAttachment(TransactionSubType transactionSubType)
        {
            var attachment = AttachmentFuncs[transactionSubType].Invoke(_attachments);
            return attachment;
        }
    }
}