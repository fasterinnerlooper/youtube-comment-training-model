using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenAI;
using OpenAI.Managers;
using OpenAI.ObjectModels;
using OpenAI.ObjectModels.RequestModels;

namespace YoutubeCommentTrainingModel
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length==0) {
                Console.WriteLine("Usage: CommentSafety videoId youtube-api-key openai-api-key");
                return;
            }

            var comments = new List<string>();

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = args[1]
            });

            // Define the video ID you want to retrieve comments for
            string videoId = args[0];

            // Create a request to list comment threads
            var request = youtubeService.CommentThreads.List("id,replies,snippet");
            request.VideoId = videoId;

            try
            {
                var response = request.Execute();

                string jsonResponse = JsonConvert.SerializeObject(response, Formatting.Indented);

                JObject jsonObject = JObject.Parse(jsonResponse);
                var items = jsonObject["items"];
                comments.AddRange(from item in items
                                  let snippet = item["snippet"]?["topLevelComment"]?["snippet"]?["textDisplay"]
                                  select snippet?.ToString() ?? "");
                var openAiService = new OpenAIService(new OpenAiOptions()
                {
                    ApiKey = args[2]
                });

                var messages = new List<ChatMessage>
                {
                    // ChatMessage.FromSystem(@"I will provide you with a list of comments and I would like you to categorise each comment on a scale dictated by how psychologically safe each comment is. Please paraphrase each statement in a way that removes any offensive terms and reduces any negativity. When a comment has been categorised as low psychological safety, it is critical that you only ever describe the comment and you never show the original comment."),
                    ChatMessage.FromSystem(@"I will provide you with a list of YouTube comments and your job is to categorise them based on their psychological safety. Group them under their rating but for comments that are rated low, paraphrase them to remove any negativity or offensive language."),
                    ChatMessage.FromUser(string.Join(',', comments))
                };
                var completionResult = openAiService.ChatCompletion.CreateCompletion(new ChatCompletionCreateRequest
                {
                    Messages = messages,
                    Model = Models.Gpt_3_5_Turbo
                });

                if(completionResult.Result.Successful)
                {
                    completionResult.Result.Choices.ForEach((choice) =>{
                        Console.WriteLine(choice.Message.Content);
                    });
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}
