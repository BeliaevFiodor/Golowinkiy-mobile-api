using golowinsky_mobile.Models;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;

namespace golowinsky_mobile.Contract
{
    [ServiceContract]
    public interface ICarPrc
    {
        [OperationContract]
        //Person1 CheckMobileAppCodeUrl(string app_code, string url);
        TCheckMobileAppCodeUrl CheckMobileAppCodeUrl(string app_code, string url);

        [OperationContract]
        List<TGetNewTablesMobileDB> GetNewTablesMobileDB(string app_code, string code_mobile);
        [OperationContract]
        List<TGetNewTablesMobileDB> GetAllTablesMobileDB(string app_code, string code_mobile);
        [OperationContract]
        List<Tpredpr> GetMobileDBpredpr(string app_code, string code_mobile);
        [OperationContract]
        List<Ttov_gr> GetMobileDBtov_gr(string app_code, string code_mobile);
        [OperationContract]
        List<Ttov_art> GetMobileDBtov_art(string app_code, string code_mobile);
        [OperationContract]
        List<Ttov_img> GetMobileDBtov_img(string app_code, string code_mobile);
        [OperationContract]
        List<Ttov_img> GetMobileDBtov_img_async(string app_code, string code_mobile);
        [OperationContract]
        List<Ttov_img> GetMobileDBtov_img_sync(string app_code, string code_mobile);
        [OperationContract]
        List<Ttov_img_base64> GetMobileDBtov_img_base64_async(string app_code, string code_mobile);
        [OperationContract]
        List<Ttov_contacts> GetMobileDBtov_contacts(string app_code, string code_mobile);
        [OperationContract]
        List<Tctlg> GetMobileDBctlg(string app_code, string code_mobile);
[OperationContract]
        List<Tsettings> GetMobileDBsettings(string app_code, string code_mobile);
        [OperationContract]
        List<Tstyles> GetMobileDBstyles(string app_code, string code_mobile);
        [OperationContract]
        List<Tpredpr_kart> GetMobileDBpredpr_kart(string app_code, string code_mobile);
        [OperationContract]
        List<Tpredpr_tov_art> GetMobileDBpredpr_tov_art(string app_code, string code_mobile);
        [OperationContract]
        List<Tpredpr_tov_gr> GetMobileDBpredpr_tov_gr(string app_code, string code_mobile);
        [OperationContract]
        List<Ttov_gr_tov_art> GetMobileDBtov_gr_tov_art(string app_code, string code_mobile);
        [OperationContract]
        List<Tquestions> GetMobileDBquestions(string app_code, string code_mobile);
        [OperationContract]
        List<Tanswers> GetMobileDBanswers(string app_code, string code_mobile);
        [OperationContract]
        Tmessage GetImageMobile1(string app_code, string img_filename);
        [OperationContract]
        byte[] RetrieveFile(string filename, string app_code);
        [OperationContract]
        //[WebGet(UriTemplate = "GetImageMobile/{app_code}/{img_filename}")]
        Stream GetImageMobile(string app_code, string img_filename);
        [OperationContract]
        string GetImageMobileBase64(string app_code, string img_filename);
        [OperationContract]
        Stream GetVideoMobile(string app_code, string img_filename);
        [OperationContract]
        TUpdateMarkMobileDB UpdateMarkMobileDB(string app_code, string code_mobile, string tablename);
        [OperationContract]
        TGetMobileShowLogin GetMobileShowLogin(string app_code);
        [OperationContract]
        TVideoFileSave VideoFileSave(string app_code, string code_mobile, string filename);
        [OperationContract]
        TVideoFileDelete VideoFileDelete(string app_code, string code_mobile, string filename);
        [OperationContract]
        int ServerTest();
        //List<object> GetMobileDB(string app_code, string tablename);
        [OperationContract]
//string UpdateTable (string app_code, string code_mobile, string tablename);
//string UpdateTable (string app_code, string code_mobile, string tablename, RequestData rData);
        TResult UpdateBase(string app_code, List<Table> tables);
//TResult UpdateBase (string app_code, RequestData rData);

[OperationContract]
        TResult DeleteFromBase(string app_code, List<TRowToDelete> rowsToDelete);
[OperationContract]
        TResult UploadPhoto(string appCode, string fileName, Stream fileContents);
[OperationContract]
        TResult SetUpdateAllFlag(string app_code);

        [OperationContract]
        TResult AddInetMobileOrder2(string smsText, string comment);

        [OperationContract]
        TResult AddInetMobileOrder(TOrder order);

        [OperationContract]
        TResult AddInetMobileOrder3();

        string UpdateTable(string tableName, string appCode, Table table);

    }
}
