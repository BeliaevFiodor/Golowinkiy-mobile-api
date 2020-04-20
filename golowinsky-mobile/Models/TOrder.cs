using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace golowinsky_mobile.Models
{
    [DataContract]
    public class TOrder
    {
        [DataMember]
        public string orderContent { get; set; }
        [DataMember]
        public string orderComment { get; set; }
        [DataMember]
        public string orderPhone { get; set; }
    }
}
