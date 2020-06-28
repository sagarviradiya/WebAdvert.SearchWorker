using System;
using System.Collections.Generic;
using System.Text;
using WebAdvert.Models.Messages;

namespace WebAdvert.SearchWorker
{
    public static class MappingHelper
    {
        public static AdvertType MapAdvertType(AdvertConfirmedMessage message)
        {
            return new AdvertType
            {

                CreationTime = DateTime.UtcNow,
                Id = message.Id,
                Title = message.Title,

            };
        }
    }
}
