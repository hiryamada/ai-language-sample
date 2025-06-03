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
Console.WriteLine("エンティティ認識(NER)の例");

var entityResponse = client.RecognizeEntities("I had a wonderful trip to Seattle last week.");
Console.WriteLine("Named Entities:");
foreach (var entity in entityResponse.Value)
{
    Console.WriteLine($"\tText: {entity.Text},\tCategory: {entity.Category},\tSub-Category: {entity.SubCategory}");
    Console.WriteLine($"\t\tScore: {entity.ConfidenceScore:F2},\tLength: {entity.Length},\tOffset: {entity.Offset}\n");
}

Console.WriteLine("===========================");
Console.WriteLine("エンティティリンキングの例");

var linkedEntitiesResponse = client.RecognizeLinkedEntities(
                "Microsoft was founded by Bill Gates and Paul Allen on April 4, 1975, " +
                "to develop and sell BASIC interpreters for the Altair 8800. " +
                "During his career at Microsoft, Gates held the positions of chairman, " +
                "chief executive officer, president and chief software architect, " +
                "while also being the largest individual shareholder until May 2014.");

Console.WriteLine("Linked Entities:");
foreach (var entity in linkedEntitiesResponse.Value)
{
    Console.WriteLine($"\tText: {entity.Name},\tData Source: {entity.DataSource}");
    Console.WriteLine($"\t\tDataSourceEntityId: {entity.DataSourceEntityId},\tURL: {entity.Url}");
}

Console.WriteLine("===========================");
Console.WriteLine("感情分析の例");

var sentimentResponse = client.AnalyzeSentiment("山田先生の講義はわかりやすい");
Console.WriteLine("Sentiment Ayanysis:");

Console.WriteLine(sentimentResponse.Value.Sentiment);
foreach (var sentence in sentimentResponse.Value.Sentences)
{
    Console.WriteLine($"\tText: {sentence.Text},\tSentiment: {sentence.Sentiment}");
    Console.WriteLine($"\t\tPositive Score: {sentence.ConfidenceScores.Positive:F2},\tNegative Score: {sentence.ConfidenceScores.Negative:F2},\tNeutral Score: {sentence.ConfidenceScores.Neutral:F2}");
}