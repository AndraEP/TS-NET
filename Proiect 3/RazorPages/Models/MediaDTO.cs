using System;
using System.Collections.Generic;
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
        public string Path { get; set; }
        [DataMember]
        public int Moved { get; set; }
        [DataMember]
        public string Evenimente { get; set; }
        [DataMember]
        public string Persoane { get; set; }
        [DataMember]
        public string Peisaje { get; set; }
        [DataMember]
        public string Locuri { get; set; }
        [DataMember]
        public string Altele { get; set; }
        [DataMember]
        public string DataCreare { get; set; }
    }
}

