using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace RazorPages.Models
{
    [DataContract(IsReference = true)]
    public partial class MediaDTO
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        [Required]
        //[RegularExpression(@"^(?:[\w]\:|\\)(\\[a-z_\-\s0-9\.]+)+\.(gif|jpg|jpeg|png|mp4)$")]
        [RegularExpression(@"^([A-Z]*[a-zA-Z_\-\s0-9\.]+)+\.(gif|jpg|jpeg|png|mp4)$")]
        public string Path { get; set; }
        [DataMember]
        [Range(0, 1)]
        public int Moved { get; set; }
        [DataMember]
        [RegularExpression(@"^[A-Z]*[a-zA-Z""'\s-,]*$")]
        public string Evenimente { get; set; }
        [DataMember]
        [RegularExpression(@"^[A-Z]*[a-zA-Z""'\s-,]*$")]
        public string Persoane { get; set; }
        [DataMember]
        [RegularExpression(@"^[A-Z]*[a-zA-Z""'\s-,]*$")]
        public string Peisaje { get; set; }
        [DataMember]
        [RegularExpression(@"^[A-Z]*[a-zA-Z""'\s-,]*$")]
        public string Locuri { get; set; }
        [DataMember]
        [RegularExpression(@"^[A-Z]*[a-zA-Z""'\s-,]*$")]
        public string Altele { get; set; }
        [DataMember]
        [DataType(DataType.Date)]
        public string DataCreare { get; set; }
    }
}

