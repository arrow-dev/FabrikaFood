using System;

namespace FabrikaFood.Abstractions
{
    //DataModels for data coming from the database inherits the entity system properties from this class.
    public abstract class TableData
    {
        public string Id { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public byte[] Version { get; set; }
    }
}