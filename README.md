# Connecting to Mongo Database
dotnet add package MongoDB.Driver.Core --version 2.10.0

Reference: https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-3.1&tabs=visual-studio
## What is a document?

### 
Format is called BSON. Looks like JSON .   Contains elements / fields . 

Contains an ID element. Just like Primary Key .  _id is the name. Value mus be unique. It can be any type but comonly used is Object id .  Comparable to Guid. ObjectId.GenerateNewId (). ObjectId is 12 Byte BSON Value.

Everything is document in MongoDB.  Used for Query, Update, Index etc. 
Document Serialization

BsonDocument Model:  
    Created to o accurately represent BSON specifications.
    Created considering performance. There is no over head of converting a POCO to BSON spec
    Dynamic model. No specific schema





    Example; DateTime type is larger in .NET than BSON Specification

`
Creating BSON Document in .NET 

 var person = new BsonDocument();
            person.Add("firstName", new BsonString("Knappan"));
            person.Add("age", new BsonInt32(42));
            person.Add("isAlive", true);
            person.Add("address", new BsonArray(new[] { "1 Realestate Dr", "Apartment 512" }));
            person.Add(
                "contact", new BsonDocument
                {
                    {"phone", "123-456-7896"},
                    {"email" , "someone@somedomain.com"}
                }
            

`