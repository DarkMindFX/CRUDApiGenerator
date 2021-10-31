using System.Text.Json.Serialization;

namespace PPT.DTO
{
    public class Link
    {
        public Link()
        {
        }

        public Link(string href, string rel, string method)
        {
            this.Href = href;
            this.Rel = rel;
            this.Method = method;
        }

        [JsonPropertyName("href")]
        public string Href { get; private set; }

        [JsonPropertyName("rel")]
        public string Rel { get; private set; }

        [JsonPropertyName("method")]
        public string Method { get; private set; }
        
    }
}
