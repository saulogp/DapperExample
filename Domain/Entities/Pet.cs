using Dapper.Contrib.Extensions;
using ExemploDapper.Domain.Fixed;
using System;

namespace ExemploDapper.Domain.Entities
{
    [Table("[dbo].[Pet]")]
    public class Pet
    {
        [ExplicitKey]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TypePet Type { get; set; }
    }
}
