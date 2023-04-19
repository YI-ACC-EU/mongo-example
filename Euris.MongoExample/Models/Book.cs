namespace Euris.MongoExample.Models;
using MongoDB.Bson.Serialization.Attributes;
public class Book
{
    [BsonId]
    public object Id { get; set; }

    [BsonElement("title")] 
    public string Title { get; set; }

    [BsonElement("isbn")] 
    public string Isbn { get; set; }

    [BsonElement("pageCount")] 
    public int PageCount { get; set; }

    [BsonElement("publishedDate")] 
    public DateTime PublishedDate { get; set; }

    [BsonElement("thumbnailUrl")] 
    public string ThumbnailUrl { get; set; }

    [BsonElement("shortDescription")] 
    public string ShortDescription { get; set; }

    [BsonElement("longDescription")] 
    public string LongDescription { get; set; }

    [BsonElement("status")] 
    public string Status { get; set; }

    [BsonElement("authors")] 
    public List<string> Authors { get; set; }

    [BsonElement("categories")] 
    public List<string> Categories { get; set; }
}
