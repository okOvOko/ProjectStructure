namespace BasicApp.DataAccess.Model
{
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class Entity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}