using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RazorPagesMovie.Models
{
    [DataContract(IsReference = true)]
    public partial class CommentDTO
    {
        [Key]
        [DataMember]
        public int CommentId { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public int PostPostId { get; set; }
        [DataMember]
        public virtual PostDTO Post { get; set; }
    }
}
