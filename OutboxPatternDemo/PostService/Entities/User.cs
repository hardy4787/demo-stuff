using System.ComponentModel.DataAnnotations.Schema;

namespace PostService.Entities
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Version { get; set; }
    }
}
