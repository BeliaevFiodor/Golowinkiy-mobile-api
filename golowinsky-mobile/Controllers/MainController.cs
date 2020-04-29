using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using golowinsky_mobile.Contract;
using golowinsky_mobile.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace golowinsky_mobile.Controllers
{
    [Produces("application/json")]
    [Route("ws/carprc.svc/")]
    [ApiController]
    [AllowAnonymous]
       public class MainController : ControllerBase
    {
        private readonly ICarPrc _repository;
        public MainController(ICarPrc repository)
        {
            _repository = repository;
        }
        /// <summary>
        /// This is xml comments. here is a method description
        /// </summary>
        /// <param name="app_code">what is app_code</param>
        /// <param name="url">what is url</param>
        /// <returns>what is returns</returns>
        [HttpPost("CheckMobileAppCodeUrl/{app_code}/{url}")]
        public async Task<ActionResult<TCheckMobileAppCodeUrl>> CheckMobileAppCodeUrl(string app_code, string url)
        {
            return _repository.CheckMobileAppCodeUrl(app_code, url);
        }


        [HttpPost("UpdateMarkMobileDB/{app_code}/{code_mobile}/{tablename}")]
        public async Task<ActionResult<TUpdateMarkMobileDB>> UpdateMarkMobileDB(string app_code, string code_mobile, string tablename)
        {
            return _repository.UpdateMarkMobileDB(app_code, code_mobile, tablename);
        }

        [HttpPost("GetMobileShowLogin/{app_code}")]
        // [Route("GetMobileShowLogin/{app_code}")]
        public async Task<ActionResult<TGetMobileShowLogin>> GetMobileShowLogin(string app_code)
        {
            return _repository.GetMobileShowLogin(app_code);
        }

        [HttpPost("GetNewTablesMobileDB/{app_code}/{code_mobile}")]
        // [Route("GetNewTablesMobileDB/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<TGetNewTablesMobileDB>>> GetNewTablesMobileDB(string app_code, string code_mobile)
        {
            return _repository.GetNewTablesMobileDB(app_code, code_mobile);
        }

        [HttpPost("GetAllTablesMobileDB/{app_code}/{code_mobile}")]
        //  [Route("GetAllTablesMobileDB/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<TGetNewTablesMobileDB>>> GetAllTablesMobileDB(string app_code, string code_mobile)
        {
            return _repository.GetAllTablesMobileDB(app_code, code_mobile);
        }

        [HttpPost("GetMobileDBpredpr/{app_code}/{code_mobile}")]
        //   [Route("GetMobileDBpredpr/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Tpredpr>>> GetMobileDBpredpr(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBpredpr(app_code, code_mobile);
        }

        [HttpPost("GetMobileDBtov_gr/{app_code}/{code_mobile}")]
        //     [Route("GetMobileDBtov_gr/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Ttov_gr>>> GetMobileDBtov_gr(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBtov_gr(app_code, code_mobile);
        }

        [HttpPost("GetMobileDBtov_art/{app_code}/{code_mobile}")]
        //   [Route("GetMobileDBtov_art/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Ttov_art>>> GetMobileDBtov_art(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBtov_art(app_code, code_mobile);
        }

        [HttpPost("GetMobileDBtov_img/{app_code}/{code_mobile}")]
        //    [Route("GetMobileDBtov_img/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Ttov_img>>> GetMobileDBtov_img(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBtov_img(app_code, code_mobile);
        }

        [HttpPost("GetMobileDBtov_img_async/{app_code}/{code_mobile}")]
        //  [Route("GetMobileDBtov_img_async/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Ttov_img>>> GetMobileDBtov_img_async(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBtov_img_async(app_code, code_mobile);
        }

        [HttpPost("GetMobileDBtov_img_base64_async/{app_code}/{code_mobile}")]
        //   [Route("GetMobileDBtov_img_base64_async/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Ttov_img_base64>>> GetMobileDBtov_img_base64_async(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBtov_img_base64_async(app_code, code_mobile);
        }

        [HttpPost("GetMobileDBtov_img_sync/{app_code}/{code_mobile}")]
        //   [Route("GetMobileDBtov_img_sync/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Ttov_img>>> GetMobileDBtov_img_sync(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBtov_img_sync(app_code, code_mobile);
        }

        [HttpPost("GetMobileDBtov_contacts/{app_code}/{code_mobile}")]
        //  [Route("GetMobileDBtov_contacts/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Ttov_contacts>>> GetMobileDBtov_contacts(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBtov_contacts(app_code, code_mobile);
        }
        [HttpPost("GetMobileDBctlg/{app_code}/{code_mobile}")]
        // [Route("GetMobileDBctlg/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Tctlg>>> GetMobileDBctlg(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBctlg(app_code, code_mobile);
        }
        [HttpPost("GetMobileDBsettings/{app_code}/{code_mobile}")]
        //  [Route("GetMobileDBsettings/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Tsettings>>> GetMobileDBsettings(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBsettings(app_code, code_mobile);
        }

        [HttpPost("GetMobileDBquestions/{app_code}/{code_mobile}")]
        //   [Route("GetMobileDBquestions/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Tquestions>>> GetMobileDBquestions(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBquestions(app_code, code_mobile);
        }

        [HttpPost("GetMobileDBanswers/{app_code}/{code_mobile}")]
        //  [Route("GetMobileDBanswers/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Tanswers>>> GetMobileDBanswers(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBanswers(app_code, code_mobile);
        }


        [HttpPost]
        //   [Route("GetMobileDBstyles/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Tstyles>>> GetMobileDBstyles(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBstyles(app_code, code_mobile);
        }

        [HttpPost("GetMobileDBpredpr_kart/{app_code}/{code_mobile}")]
        //   [Route("GetMobileDBpredpr_kart/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Tpredpr_kart>>> GetMobileDBpredpr_kart(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBpredpr_kart(app_code, code_mobile);
        }

        [HttpPost("GetMobileDBpredpr_tov_art/{app_code}/{code_mobile}")]
        //   [Route("GetMobileDBpredpr_tov_art/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Tpredpr_tov_art>>> GetMobileDBpredpr_tov_art(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBpredpr_tov_art(app_code, code_mobile);
        }

        [HttpPost("GetMobileDBpredpr_tov_gr/{app_code}/{code_mobile}")]
        //   [Route("GetMobileDBpredpr_tov_gr/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Tpredpr_tov_gr>>> GetMobileDBpredpr_tov_gr(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBpredpr_tov_gr(app_code, code_mobile);
        }

        [HttpPost("GetMobileDBtov_gr_tov_art/{app_code}/{code_mobile}")]
        //   [Route("GetMobileDBtov_gr_tov_art/{app_code}/{code_mobile}")]
        public async Task<ActionResult<List<Ttov_gr_tov_art>>> GetMobileDBtov_gr_tov_art(string app_code, string code_mobile)
        {
            return _repository.GetMobileDBtov_gr_tov_art(app_code, code_mobile);
        }

        [HttpGet("RetrieveFile/{filename}/{app_code}")]
        //   [Route("RetrieveFile/{filename}/{app_code}")]
        public async Task<ActionResult<byte[]>> RetrieveFile(string filename, string app_code)
        {
            return _repository.RetrieveFile(filename, app_code);
        }

        [HttpGet("GetImageMobile/{app_code}/{img_filename}")]
        //   [Route("GetImageMobile/{app_code}/{img_filename}")]
        public async Task<ActionResult<Stream>> GetImageMobile(string app_code, string img_filename)
        {
            return _repository.GetImageMobile(app_code, img_filename);
        }

        [HttpGet("GetImageMobileBase64/{app_code}/{img_filename}")]
        //   [Route("GetImageMobileBase64/{app_code}/{img_filename}")]
        public async Task<ActionResult<string>> GetImageMobileBase64(string app_code, string img_filename)
        {
            return _repository.GetImageMobileBase64(app_code, img_filename);
        }

        [HttpGet("GetVideoMobile/{app_code}/{img_filename}")]
        //   [Route("GetVideoMobile/{app_code}/{img_filename}")]
        public async Task<ActionResult<Stream>> GetVideoMobile(string app_code, string img_filename)
        {
            return _repository.GetVideoMobile(app_code, img_filename);
        }
        [HttpGet("VideoFileSave/{app_code}/{code_mobile}/{filename}")]
        //  [Route("VideoFileSave/{app_code}/{code_mobile}/{filename}")]
        public async Task<ActionResult<TVideoFileSave>> VideoFileSave(string app_code, string code_mobile, string filename)
        {
            return _repository.VideoFileSave(app_code, code_mobile, filename);
        }

        [HttpGet("VideoFileDelete/{app_code}/{code_mobile}/{filename}")]
        //   [Route("VideoFileDelete/{app_code}/{code_mobile}/{filename}")]
        public async Task<ActionResult<TVideoFileDelete>> VideoFileDelete(string app_code, string code_mobile, string filename)
        {
            return _repository.VideoFileDelete(app_code, code_mobile, filename);
        }


        [HttpGet("GetImageMobile1/{app_code}/{img_filename}")]
        //  [Route("GetImageMobile1/{app_code}/{img_filename}")]

        public async Task<ActionResult<Tmessage>> GetImageMobile1(string app_code, string img_filename)
        {
            return _repository.GetImageMobile1(app_code, img_filename);
        }

        [HttpGet("ServerTest")]
        //  [Route("ServerTest")]
        public async Task<ActionResult<int>> ServerTest()
        {
            return _repository.ServerTest();
        }

        [HttpPost("UpdateBase/{app_code}")]
        //   [Route("UpdateBase/{app_code}")]
        public async Task<ActionResult<TResult>> UpdateBase(string app_code, List<Table> tables)
        {
            return _repository.UpdateBase(app_code, tables);
        }

        [HttpPost("UpdateTable/{app_code}")]
        //  [Route("UpdateBase/{app_code}")]
        public async Task<ActionResult<string>> UpdateTable(string tableName, string appCode, Table table)
        {
            return _repository.UpdateTable(tableName, appCode, table);
        }



        [HttpPost("DeleteFromBase/{app_code}")]
        //  [Route("DeleteFromBase/{app_code}")]
        public async Task<ActionResult<TResult>> DeleteFromBase(string app_code, List<TRowToDelete> rowsToDelete)
        {
            return _repository.DeleteFromBase(app_code, rowsToDelete);
        }

        //  [Route("UploadPhoto/{appCode}/{fileName}")]
        [HttpPost("UploadPhoto/{appCode}/{fileName}")]
        public async Task<ActionResult<TResult>> UploadPhoto(string appCode, string fileName, Stream fileContents)
        {
            return _repository.UploadPhoto(appCode, fileName, fileContents);
        }

        //   [Route("SetUpdateAllFlag/{app_code}")]
        [HttpPost("SetUpdateAllFlag/{app_code}")]
        public async Task<ActionResult<TResult>> SetUpdateAllFlag(string app_code)
        {
            return _repository.SetUpdateAllFlag(app_code);
        }

        //  [Route("AddInetMobileOrder2/{smsText}/{comment}")]
        [HttpPost("AddInetMobileOrder2/{smsText}/{comment}")]
        public async Task<ActionResult<TResult>> AddInetMobileOrder2(string smsText, string comment)
        {
            return _repository.AddInetMobileOrder2(smsText, comment);
        }

        //   [Route("AddInetMobileOrder3")]
        [HttpPost("AddInetMobileOrder3")]
        public async Task<ActionResult<TResult>> AddInetMobileOrder3()
        {
            return _repository.AddInetMobileOrder3();
        }

        [HttpPost("AddInetMobileOrder")]
        //   [Route("AddInetMobileOrder")]
        public async Task<ActionResult<TResult>> AddInetMobileOrder(TOrder order)
        {
            return _repository.AddInetMobileOrder(order);
        }
    }
}