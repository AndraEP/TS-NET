//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelAndApi
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [DataContract(IsReference = true)]
    public partial class Media
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
