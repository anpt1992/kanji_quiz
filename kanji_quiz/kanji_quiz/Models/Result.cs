using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace kanji_quiz.Models
{
    public class Result
    {
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("data")]
        public Data Data { get; set; }
    }
}
