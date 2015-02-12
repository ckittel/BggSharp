using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BggSharp.Models.HttpResponse.Plays;
using Play = BggSharp.Models.Play;

namespace BggSharp.Helpers.MapperExtensions
{
    internal static class PlaysResponseExtensions
    {
        public static List<Play> ToFlattenedModel(this IEnumerable<PlaysResponse> responses)
        {
            var orderedResponses = responses.OrderBy(pr => pr.Page);
            var result = new List<Play>();
            foreach (var orderedResponse in orderedResponses)
            {
                foreach (var responsePlay in orderedResponse.Plays)
                {
                    var play = new Play
                    {
                        Id = responsePlay.Id,
                        Comments = responsePlay.Comments,
                        IsIncomplete = (responsePlay.Incomplete == "1"),
                        IsNowInStats = (responsePlay.NowInStats == "1"),
                        Length = responsePlay.Length,
                        Location = responsePlay.Location,
                        Item = { Id = responsePlay.Item.ObjectId, Name = responsePlay.Item.Name }
                    };
                    play.Item.Type = responsePlay.Item.ObjectType.FromApiValue();

                    DateTime parsedDate;
                    if (DateTime.TryParse(responsePlay.Date, out parsedDate))
                    {
                        play.Date = parsedDate;
                    }

                    foreach (var itemSubtype in responsePlay.Item.Subtypes.Subtypes)
                    {
                        play.Item.Subtypes.Add(itemSubtype.Value.FromApiResult());
                    }

                    result.Add(play);
                }
            }
            //Parallel.ForEach(responses.SelectMany(response => response.Plays), responsePlay =>
            //{
                
            //});

            return result;
        }
    }
}
