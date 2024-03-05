using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RepoLayer.Entity
{
    public class NoteEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }

        public string NoteTitle { get; set; }

        public string NoteDescription { get; set; }

        public string colour { get; set; }

        public string background { get; set; }

        public bool IsPin { get; set; }

        public bool IsTrash { get; set; }

        public bool IsArchive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public DateTime Remainder { get; set; }

        [ForeignKey("NotesUser")]
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual UserEntity NotesUser { get; set; }
    }

}
