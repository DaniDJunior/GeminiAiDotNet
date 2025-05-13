using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gemini.Model
{
    public class GeminiUsageMetadata
    {
        public int promptTokenCount { get; set; }
        public int cantidatesTokenCount { get; set; }
        public int totalTokenCount { get; set; }

        public List<GeminiTokenDetail> promptTokensDetails { get; set; }
        public List<GeminiTokenDetail> candidatesTokensDetails { get; set; }
    }
}
