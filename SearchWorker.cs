using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization.Json;
using Amazon.Lambda.SNSEvents;

[assembly: LambdaSerializer(typeof(JsonSerializer))]
namespace WebAdvert.SearchWorker
{
    public class SearchWorker
    {
        public void Function(SNSEvent snsEvent,ILambdaContext context)
        {
            foreach (var item in snsEvent.Records)
            {
                context.Logger.LogLine(item.Sns.Message);
            }
        }
    }
}
