using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MongoDBDemo
{
    class Persona
    {
        public MongoDB.Bson.ObjectId Id { get; private set; }
        public string Nome { get; set; }

        public Indirizzo Indirizzo { get; set; }
    }
}
