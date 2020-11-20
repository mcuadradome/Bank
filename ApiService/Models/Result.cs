using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace ApiService.Models
{
    public class Result
    {
        [DataMember]
        public int Codigo { get; set; }
        [DataMember]
        public string Mensaje { get; set; }
    }
}