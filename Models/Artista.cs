using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ImagenesMVCNetCore.Models
{
    [Table("ARTISTAS")]
    public class Artista
    {
        [Key]
        [Column("ID")]
        public int IdArtista { get; set; }

        [Column("Nombre")]
        public string Nombre { get; set; }

        [Column("Foto")]
        public string Foto { get; set; }


    }
}



