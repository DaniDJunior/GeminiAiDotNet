using System.IO;
using Microsoft.Extensions.Configuration;

var builder = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("config.json", optional: false);

IConfiguration config = builder.Build();

string? ApiKey = config.GetSection("Gemini")["key"];

if(ApiKey == null || ApiKey == "API_KEY")
{
    throw new Exception("Validar a chave de api");
}

Gemini.Client client = new Gemini.Client(ApiKey);

var response = await client.generate_content("Defina o que vc é?");

if(response == null)
{
    throw new Exception("Não foi possivel gerar uma resposta");
}

var candate = response.candidates.FirstOrDefault();

if(candate == null)
{
    throw new Exception("O Gemini não retornou nenhum candidato a resposta");
}

Console.WriteLine(candate.content.parts.FirstOrDefault()?.text);
