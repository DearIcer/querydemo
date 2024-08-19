using System.ComponentModel.DataAnnotations;

namespace EF.Entity;

public abstract class Entity
{
    [Key] public long Id { get; set; }
}