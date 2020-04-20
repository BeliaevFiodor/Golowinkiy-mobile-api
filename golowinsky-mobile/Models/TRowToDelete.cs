using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace golowinsky_mobile.Models
{
    [DataContract]
    public class TRowToDelete
    {
        [DataMember]
        public string tableName { get; set; }
        [DataMember]
        public string keyName { get; set; }
        [DataMember]
        public string keyValue { get; set; }
        [DataMember]
        public string key2Name { get; set; }
        [DataMember]
        public string key2Value { get; set; }
    }

}
