namespace DTO
{
    // Configuration class for temperature and output tokens
    public class GenerationConfig
    {
        public double Temperature { get; set; } = 1; //0.8
        public int MaxOutputTokens { get; set; } = 2048;
    }

    // Classes to represent the structure of the Gemini API response
    public class GeminiApiResponse
    {
        public Candidate[] candidates { get; set; }
    }

    public class Candidate
    {
        public Content content { get; set; }
    }

    public class Content
    {
        public Part[] parts { get; set; }
    }

    public class Part
    {
        public string text { get; set; }
    }
}
