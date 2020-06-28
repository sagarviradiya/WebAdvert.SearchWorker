using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebAdvert.SearchWorker
{
    public static class ElasticSearchHelper
    {
        private static IElasticClient _elasticClient;
        public static IElasticClient GetInstance(IConfiguration configuration)
        {
            if (_elasticClient == null)
            {
                var elasticSearchURL = configuration.GetSection("ES").GetValue<string>("URL");
                var settings = new ConnectionSettings(new Uri(elasticSearchURL)).DefaultIndex("adverts");
                _elasticClient = new ElasticClient(settings);
            }
            return _elasticClient;
        }
    }
}
