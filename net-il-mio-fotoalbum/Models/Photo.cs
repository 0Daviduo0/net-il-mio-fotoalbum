using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace net_il_mio_fotoalbum.Models
{
    [Table("photo")]
    public class Photo
    {
        [Key]
        public long Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public byte[]? Image { get; set; }

        public bool Visibility { get; set; }

        public List<Category>? Categories { get; set; }
    }
}
