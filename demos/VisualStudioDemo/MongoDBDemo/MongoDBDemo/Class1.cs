using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace MongoDBDemo
{
    public class Class1
    {
        public static void Main(string[] args)
        {
            try
            {
                var connectionString = "mongodb://linus.mongohq.com:10031/";
                var username = System.Configuration.ConfigurationManager.AppSettings["username"];
                var password = System.Configuration.ConfigurationManager.AppSettings["password"];
                Console.WriteLine("Username:", username);
                var client = new MongoClient(connectionString);
                var server = client.GetServer();
                var database = server.GetDatabase("app11298010", new MongoCredentials(username, password));

                // Inizialmente la collection non esiste, verrà creata automaticamente
                var collection = database.GetCollection<Persona>("entities");

                var entity = new Persona { Nome = "Tom", Indirizzo = new Indirizzo 
                {
                    Via = "123 Main St.",
                    Citta = "Centerville",
                    Provincia = "PA",
                    Cap = 12345
                } 
                };
                // Una alternativa a proprie classi di dominio è usare un BsonDocument:
                // BsonDocument nested = new BsonDocument {
                //     { "Nome", "Tom" },
                //     { "Indirizzo", new BsonDocument {
                //         { "Via", "123 Main St." },
                //         { "Citta", "Centerville" },
                //         { "Provincia", "PA" },
                //         { "Cap", 12345}
                //     }}
                // };
                Console.WriteLine("Provo a inserire un document...");
                collection.Insert(entity);

                var id = entity.Id;
                Console.WriteLine(string.Format("Leggo il document con _id {0}", id.ToString()));
                var query = Query.EQ("_id", id);
                entity = collection.FindOne(query);
                if (entity != null)
                {
                    Console.WriteLine("Persona trovata con successo!");
                    Console.WriteLine(string.Format("Nome: {0}, Indirizzo: {1}", entity.Nome, String.Join(",", entity.Indirizzo.Via, entity.Indirizzo.Citta, entity.Indirizzo.Provincia, entity.Indirizzo.Cap)));
                }
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("Si è verificato un errore: {0}", e.Message)); 
                Console.ReadLine();
            }
        }
    }
}
