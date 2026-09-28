using Google.GenAI;
using ITI_Project.Context;

namespace ITI_Project.Services
{
    public class AIService
    {
        private readonly IConfiguration _configuration;
        private readonly MyDbContext _db;
        public AIService(IConfiguration configuration, MyDbContext db)
        {
            _configuration = configuration;
            _db = db;

        }
        public async Task<string> AskAI(string question)
        {
            var apiKey = _configuration["Gemini:ApiKey"];
            var model = _configuration["Gemini:Model"];

            var products = _db.Products.ToList();
            var context = "";

            foreach (var product in products)
            {
                context += $"Product: {product.Title}, Price: {product.Price}, Quantity: {product.Quantity}\n";
            }

            var prompt = $"""
                You are an inventory assistant.
                Answer the user's question using only the inventory data below.

                Inventory Data:
                {context}

                User Question:
                {question}
            """;

            var client = new Client(apiKey: apiKey);

            var response = await client.Models.GenerateContentAsync(
                model: model,
                contents: prompt
            );
            return response.Candidates[0].Content.Parts[0].Text;
        }
    }
}
