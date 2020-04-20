using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace golowinsky_mobile.Models
{
    public class TCheckMobileAppCodeUrl
    {
        public int Result { get; set; }
        public bool CanEdit { get; set; }
    }

    public class TVideoFileSave
    {
        public bool Result { get; set; }
        public string FileName { get; set; }
        public string ErrorText { get; set; }
    }

    public class TVideoFileDelete
    {
        public bool Result { get; set; }
    }

    public class TUpdateMarkMobileDB
    {
        public bool Result { get; set; }
    }

    public class TGetMobileShowLogin
    {
        public string Result { get; set; }
    }

    public class TGetNewTablesMobileDB
    {
        public string t { get; set; }
    }

    public class Tpredpr
    {
        public string p_id { get; set; }
        public string p_name { get; set; }
        public string p_catalog { get; set; }
        public string p_image { get; set; }
    }

    public class Ttov_gr
    {
        public string p_id { get; set; }
        public string g_id { get; set; }
        public string g_name { get; set; }
        public string g_image { get; set; }
        public string g_sup { get; set; }
    }

    public class Ttov_art
    {
        public string g_id { get; set; }
        public string t_article { get; set; }
        public string t_name { get; set; }
        public string t_cost { get; set; }
        public int fl_mark { get; set; }
        public string ctlg_id { get; set; }
        public string t_description { get; set; }
        public string t_image { get; set; }
        public string t_namebasket { get; set; }
        public string t_imageprev { get; set; }
    }

    public class Ttov_img
    {
        public string filename { get; set; }
        //public byte[] img { get; set; }
    }

    public class Ttov_img_base64
    {
        public string filename { get; set; }
        //public byte[] img { get; set; }
        public string imgBase64 { get; set; }
    }

    public class Ttov_contacts
    {
        public string t_article { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string newappcode { get; set; }
        public string mapOfflineRadius { get; set; }
        public int mapOfflineZoomMin { get; set; }
        public int mapOfflineZoomMax { get; set; }
    }

    public class Tctlg
    {
        public string ctlg_id { get; set; }
        public string ctlg_name { get; set; }
    }

    public class Tsettings
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Tstyles
    {
        public string element { get; set; }
        public string value { get; set; }
        public string property { get; set; }
    }

    public class Tpredpr_kart
    {
        public string p_id { get; set; }
        public string p_descr { get; set; }
        public string p_image { get; set; }
    }

    public class Tpredpr_tov_art
    {
        public string p_id { get; set; }
        public string t_article { get; set; }
    }

    public class Tpredpr_tov_gr
    {
        public string p_id { get; set; }
        public string g_id { get; set; }
    }

    public class Ttov_gr_tov_art
    {
        public string g_id { get; set; }
        public string t_article { get; set; }
    }

    public class Tquestions
    {
        public string q_id { get; set; }
        public string q_description { get; set; }
        public string q_rightansid { get; set; }
        public string q_image { get; set; }
        public string q_anstext { get; set; }
    }

    public class Tanswers
    {
        public string a_id { get; set; }
        public string a_description { get; set; }
        public string q_id { get; set; }
    }

    public class TResult
    {
        public string type { get; set; }
        public string value { get; set; }
    }

    public class Tmessage
    {
        public string message { get; set; }
    }
}
