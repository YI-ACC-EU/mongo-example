using Euris.MongoExample.Models;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using System.Text.Json;
using Newtonsoft.Json;
using JsonConvert = Newtonsoft.Json.JsonConvert;

Console.WriteLine("Hello, World!");

var connectionString = Environment.GetEnvironmentVariable("MONGODB_CONNECTION_STRING");
if (connectionString == null)
{
    Console.WriteLine("You must set your 'MONGODB_CONNECTION_STRING' environmental variable. See\n\t https://www.mongodb.com/docs/drivers/go/current/usage-examples/#environment-variable");
    Environment.Exit(0);
}

var client = new MongoClient(connectionString);

//BSON
//var bsonCollection = client.GetDatabase("test").GetCollection<BsonDocument>("test");

//var filter = Builders<BsonDocument>
//    .Filter
//    .Regex("title", new BsonRegularExpression("Android", "i"));
//var document = bsonCollection.Find(filter).ToList();
//var settings = new JsonWriterSettings { Indent = true };
//var jsonOutput = document.ToJson(settings);
//Console.WriteLine(jsonOutput);

//MODEL
//var modelCollection = client.GetDatabase("test").GetCollection<Book>("test");
//var modelFilter = Builders<Book>
//    .Filter.Where(x => x.Categories.Contains("Mobile"));
////.Regex(x => x.Title, new BsonRegularExpression("android", "i"));
////.Filter.And(
////    Builders<Book>.Filter.Where(x => x.PageCount < 500), 
////    Builders<Book>.Filter.Where(x => x.PublishedDate > new DateTime(2014,1,1)));
//var books = modelCollection.Find(modelFilter).ToList();
//var serializedDocument = JsonConvert.SerializeObject(books, Formatting.Indented);
//Console.WriteLine(serializedDocument);

//client.GetDatabase("test").CreateCollection("test5");
var newCollection = client.GetDatabase("test").GetCollection<BsonDocument>("test5");

var exampleDocument = new BsonDocument
{
    {"PersonId", "1"},
    {"Name", "Mario"},
    {"Surname", "Rossi"},
    {"SomeData", "Initial Data"}
};
var filterById = Builders<BsonDocument>.Filter.Eq("PersonId", exampleDocument["PersonId"]);

//DELETE
newCollection.DeleteOne(filterById);

//INSERT
newCollection.InsertOne(exampleDocument);
Console.WriteLine($"Inserted: {newCollection.Find(filterById).FirstOrDefault().ToJson()}");

//UPDATE
var update = Builders<BsonDocument>.Update.Set("SomeData", "Updated Data");
newCollection.UpdateOne(filterById, update);
Console.WriteLine($"Updated: {newCollection.Find(filterById).FirstOrDefault().ToJson()}");

