using Amazon.Lambda.Core;
using Amazon.Lambda.SNSEvents;
using Nest;
using System.Text.Json;
using System.Threading.Tasks;
using WebAdvert.Models.Messages;

[assembly: LambdaSerializer(typeof(JsonSerializer))]
namespace WebAdvert.SearchWorker
{
    public class SearchWorker
    {
        private readonly IElasticClient elasticClient;
        public SearchWorker() : this(ElasticSearchHelper.GetInstance(ConfigurationHelper.Instance)) { }
        public SearchWorker(IElasticClient elasticClient)
        {
            this.elasticClient = elasticClient;
        }
        public async Task Function(SNSEvent snsEvent, ILambdaContext context)
        {
            
            foreach (var item in snsEvent.Records)
            {
                context.Logger.LogLine(item.Sns.Message);
                var message = JsonSerializer.Deserialize<AdvertConfirmedMessage>(item.Sns.Message);
                var advertDocument = MappingHelper.MapAdvertType(message);
                await elasticClient.IndexDocumentAsync(advertDocument);
            }
        }
    }
}
