using Business.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Models
{
    public abstract class BaseEntity : IBaseEntity
    {
        [Column(Order = 0)]
        public int Id { get; set; }
    }
}