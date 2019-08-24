using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDB
{
    public class WatchLiveTelevisionChannel : IInteraction
    {
        public string channelName { get; set; }
        public int minutesViewed { get; set; }
        public string medium { get; set; }
        public string Id { get; set; }
        public string dayOfWeek { get; set; }
    }
}
