using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemini.Model
{
    public class GeminiCandidates
    {
        public GeminiContent content { get; set; }
        public GeminiCitationMetadata citationMetadata { get; set; }
        public string finishReason { get; set; }
        public float avgLogprobs { get; set; }
    }
}
