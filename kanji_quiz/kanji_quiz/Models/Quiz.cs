using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace kanji_quiz.Models
{
    public class Quiz
    {
        [JsonProperty("returned_status")]
        public string returned_status { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("Question")]
        public string Question { get; set; }
        [JsonProperty("Answer1")]
        public string Answer1 { get; set; }
        [JsonProperty("Answer2")]
        public string Answer2 { get; set; }
        [JsonProperty("Answer3")]
        public string Answer3 { get; set; }
        [JsonProperty("CorrectAnswer")]
        public int CorrectAnswer { get; set; }
    }
}
