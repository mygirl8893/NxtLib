﻿using System;
using NxtLib.Internal;

namespace NxtLib.Blocks
{
    public class BlockLocator : LocatorBase
    {
        public ulong? BlockId { get; private set; }
        public int? Height { get; private set; }
        public DateTime? Timestamp { get; private set; }

        private BlockLocator(ulong blockId)
            : base(Parameters.Block, blockId.ToString())
        {
            BlockId = blockId;
        }

        private BlockLocator(int height)
            : base(Parameters.Height, height.ToString())
        {
            Height = height;
        }

        private BlockLocator(DateTime timestamp, int nxtTimestamp)
            : base(Parameters.Timestamp, nxtTimestamp.ToString())
        {
            Timestamp = timestamp;
        }

        public static BlockLocator ByBlockId(ulong blockId)
        {
            return new BlockLocator(blockId);
        }

        public static BlockLocator ByHeight(int height)
        {
            return new BlockLocator(height);
        }

        public static BlockLocator ByTimestamp(DateTime timestamp)
        {
            var nxtTimestamp = new DateTimeConverter().GetNxtTimestamp(timestamp);
            return new BlockLocator(timestamp, nxtTimestamp);
        }
    }
}