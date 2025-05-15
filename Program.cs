using Azure;
using Azure.AI.TextAnalytics;

string endpoint = Environment.GetEnvironmentVariable("LANGUAGE_ENDPOINT") ?? throw new InvalidOperationException("Set the LANGUAGE_ENDPOINT environment variable.");
string key = Environment.GetEnvironmentVariable("LANGUAGE_KEY") ?? throw new InvalidOperationException("Set the LANGUAGE_KEY environment variable.");

TextAnalyticsClient client = new(new(endpoint), new AzureKeyCredential(key));

Console.WriteLine("===========================");
Console.WriteLine("言語検出の例:");

DetectedLanguage detectedLanguage = client.DetectLanguage("Ce document est rédigé en Français.");
Console.WriteLine("Language:");
Console.WriteLine($"\t{detectedLanguage.Name},\tISO-6391: {detectedLanguage.Iso6391Name}\n");

Console.WriteLine("===========================");
Console.WriteLine("キー フレーズ抽出の例:");

var keyPhrasesResponse = client.ExtractKeyPhrases("Dr. Smith has a very modern medical office, and she has great staff.");
foreach (string keyphrase in keyPhrasesResponse.Value)
{
    Console.WriteLine($"\t{keyphrase}");
}

Console.WriteLine("===========================");
Console.WriteLine("キー フレーズ抽出の例:");

var entityResponse = client.RecognizeEntities("I had a wonderful trip to Seattle last week.");
Console.WriteLine("Named Entities:");
foreach (var entity in entityResponse.Value)
{
    Console.WriteLine($"\tText: {entity.Text},\tCategory: {entity.Category},\tSub-Category: {entity.SubCategory}");
    Console.WriteLine($"\t\tScore: {entity.ConfidenceScore:F2},\tLength: {entity.Length},\tOffset: {entity.Offset}\n");
}

