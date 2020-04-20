using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace golowinsky_mobile.Models
{
    [DataContract]
    public class Table
    {
        [DataMember]
        public string tableName { get; set; }
        [DataMember]
        public List<Tpredpr> predpr { get; set; }
        [DataMember]
        public List<Ttov_gr> tov_gr { get; set; }
        [DataMember]
        public List<Ttov_art> tov_art { get; set; }
        [DataMember]
        public List<Ttov_img> tov_img { get; set; }
        [DataMember]
        public List<Ttov_img_base64> tov_img_base64 { get; set; }
        [DataMember]
        public List<Tpredpr_kart> predpr_kart { get; set; }
        [DataMember]
        public List<Tpredpr_tov_gr> predpr_tov_gr { get; set; }
        [DataMember]
        public List<Tpredpr_tov_art> predpr_tov_art { get; set; }
        [DataMember]
        public List<Ttov_gr_tov_art> tov_gr_tov_art { get; set; }
        [DataMember]
        public List<Tsettings> settings { get; set; }
        [DataMember]
        public List<Ttov_contacts> tov_contacts { get; set; }
        [DataMember]
        public List<Tstyles> styles { get; set; }
        [DataMember]
        public List<Tanswers> answers { get; set; }
        [DataMember]
        public List<Tquestions> questions { get; set; }
    }

}
