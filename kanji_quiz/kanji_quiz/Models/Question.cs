using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace kanji_quiz.Models
{
    public class Question
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("answer1")]
        public string Answer1 { get; set; }
        [JsonProperty("answer2")]
        public string Answer2 { get; set; }
        [JsonProperty("answer3")]
        public string Answer3 { get; set; }
        [JsonProperty("correct_answer")]
        public int CorrectAnswer { get; set; }
    }
}
