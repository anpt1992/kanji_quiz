using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace kanji_quiz.Models
{
    public class Data
    {
        [JsonProperty("questions")]
        public List<Question> Questions { get; set; }
    }
}
