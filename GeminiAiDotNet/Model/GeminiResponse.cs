using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemini.Model
{
    public class GeminiResponse
    {
        public List<GeminiCandidates> candidates {  get; set; }
        public GeminiUsageMetadata geminiUsageMetadata { get; set; }
        public string modelVersion { get; set; }
    }
}
