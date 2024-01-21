using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SafeCampus.Models;



public class Student
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string ? Id { get; set; }

    [BsonElement("campusId")]
    public string ? CampusId {get;set;}
    
    [BsonElement("department")]
    public string ? Department {get;set;}
    
    [BsonElement("sex")]
    public string ? Sex {get;set;}
    
    [BsonElement("registeredYear")]
    public int RegisteredYear {get;set;}
    
    [BsonElement("photo")]
    public string ? Photo{get;set;}  
}
