using golowinsky_mobile.Contract;
using golowinsky_mobile.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Threading.Tasks;

namespace golowinsky_mobile.Implementation
{
    public class Repository : ICarPrc
    {
        private readonly IConfiguration _config;
        public Repository(IConfiguration config)
        {
            _config = config;
        }
        public TCheckMobileAppCodeUrl CheckMobileAppCodeUrl(string app_code, string url)

        {
            SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            SqlCommand command = new SqlCommand("sp_CheckMobileAppCodeUrl", conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@AppCode", SqlDbType.VarChar, 10);
            param.Value = app_code;
            param = command.Parameters.Add("@URL", SqlDbType.VarChar, 80);
            param.Value = url;
            command.Parameters.Add("@Result", SqlDbType.Int);
            command.Parameters["@Result"].Direction = ParameterDirection.Output;
            conn.Open();
            command.ExecuteNonQuery();
            //da.SelectCommand = command;
            //da.Fill(CheckMobileAppCodeUrl);
            //string message = command.Parameters["@Result"].Value.ToString();
            int result = (int)command.Parameters["@Result"].Value;
            conn.Close();

            //DataSet CheckPasswordMobileChief = new DataSet();
            SqlConnection conn1 = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            SqlCommand command1 = new SqlCommand("sp_CheckPasswordMobileChief", conn1);
            command1.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter da1 = new SqlDataAdapter();
            SqlParameter param1 = new SqlParameter();
            param1 = command1.Parameters.Add("@AppCode", SqlDbType.VarChar, 10);
            param1.Value = result.ToString();
            param1 = command1.Parameters.Add("@UserName", SqlDbType.VarChar, 50);
            param1.Value = app_code;
            param1 = command1.Parameters.Add("@Password", SqlDbType.VarChar, 50);
            param1.Value = url;
            command1.Parameters.Add("@Result", SqlDbType.Int);
            command1.Parameters["@Result"].Direction = ParameterDirection.Output;
            conn1.Open();
            command1.ExecuteNonQuery();
            //da1.SelectCommand = command1;
            //da1.Fill(CheckPasswordMobileChief);
            int resultCanEdit = (int)command1.Parameters["@Result"].Value;
            conn1.Close();

            bool canEdit = false;
            if ((resultCanEdit > 0) && (resultCanEdit == result))
            {
                canEdit = true;
            }

            //return result;

            return new TCheckMobileAppCodeUrl()
            {
                Result = result,
                CanEdit = canEdit
            };
        }
       
        public TUpdateMarkMobileDB UpdateMarkMobileDB(string app_code, string code_mobile, string tablename)
        {
            DataSet UpdateMarkMobileDB = new DataSet();
            //SqlConnection conn = new SqlConnection(GetConnString());
            SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            SqlCommand command = new SqlCommand("sp_UpdateMarkMobileDB", conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@AppCode", SqlDbType.VarChar, 10);
            param.Value = app_code;
            param = command.Parameters.Add("@CodeMobile", SqlDbType.VarChar, 10);
            param.Value = code_mobile;
            param = command.Parameters.Add("@TableName", SqlDbType.VarChar, 20);
            param.Value = tablename;
            param = command.Parameters.Add("@Mark", SqlDbType.VarChar, 1);
            param.Value = "1";
            //command.Parameters.Add("@Result", SqlDbType.Int);
            //command.Parameters["@Result"].Direction = ParameterDirection.Output;
            conn.Open();
            command.ExecuteNonQuery();
            da.SelectCommand = command;
            da.Fill(UpdateMarkMobileDB);
            //string message = command.Parameters["@Result"].Value.ToString();
            //int result = (int)command.Parameters["@Result"].Value;
            conn.Close();
            //return result;
            // lookup person with the requested id 
            return new TUpdateMarkMobileDB()
            {
                Result = true,
            };
        }

       
        public TGetMobileShowLogin GetMobileShowLogin(string app_code)
        {
            DataSet GetMobileShowLogin = new DataSet();
            //SqlConnection conn = new SqlConnection(GetConnString());
            SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            SqlCommand command = new SqlCommand("sp_GetMobileShowLogin", conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@AppCodeMain", SqlDbType.VarChar, 10);
            param.Value = app_code;
            command.Parameters.Add("@ShowLogin", SqlDbType.VarChar, 10);
            command.Parameters["@ShowLogin"].Direction = ParameterDirection.Output;
            conn.Open();
            command.ExecuteNonQuery();
            da.SelectCommand = command;
            da.Fill(GetMobileShowLogin);
            string message = command.Parameters["@ShowLogin"].Value.ToString();
            //string message = command.Parameters["@ShowLogin"].Value;
            //int result = (int)command.Parameters["@Result"].Value;
            conn.Close();
            //return result;
            // lookup person with the requested id 
            return new TGetMobileShowLogin()
            {
                Result = message,
            };
        }

       public List<TGetNewTablesMobileDB> GetNewTablesMobileDB(string app_code, string code_mobile)

        {
            string strSQL;
            //strConn=GetConnString();
            strSQL = "sp_GetNewTablesMobileDB @AppCode='" + app_code + "', @CodeMobile='" + code_mobile + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, _config.GetConnectionString("DefaultConnection"));
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            List<TGetNewTablesMobileDB> result = new List<TGetNewTablesMobileDB>();
            foreach (DataRow row in dt.Rows)
            {
                var item = new TGetNewTablesMobileDB()
                {
                    t = row["t"].ToString(),
                };
                result.Add(item);
            }
            return result;
        }

      
        public List<TGetNewTablesMobileDB> GetAllTablesMobileDB(string app_code, string code_mobile)
        {
            string strSQL;
            //strConn=GetConnString();
            strSQL = "sp_GetNewTablesMobileDB @AppCode='" + app_code + "', @CodeMobile='" + code_mobile + "', @IsAll=1";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, _config.GetConnectionString("DefaultConnection"));
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            List<TGetNewTablesMobileDB> result = new List<TGetNewTablesMobileDB>();
            foreach (DataRow row in dt.Rows)
            {
                var item = new TGetNewTablesMobileDB()
                {
                    t = row["t"].ToString(),
                };
                result.Add(item);
            }
            return result;
        }

     
        public List<Tpredpr> GetMobileDBpredpr(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "predpr", code_mobile);
            List<Tpredpr> result = new List<Tpredpr>();
            foreach (DataRow row in dt.Rows)
            {
                Tpredpr item = new Tpredpr()
                {
                    p_id = row["p_id"].ToString(),
                    p_name = row["p_name"].ToString(),
                    p_catalog = row["p_catalog"].ToString(),
                    p_image = row["p_image"].ToString(),
                };
                result.Add(item);
            }
            return result;
        }
       
        public List<Ttov_gr> GetMobileDBtov_gr(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "tov_gr", code_mobile);
            List<Ttov_gr> result = new List<Ttov_gr>();
            foreach (DataRow row in dt.Rows)
            {
                Ttov_gr item = new Ttov_gr()
                {
                    p_id = row["p_id"].ToString(),
                    g_id = row["g_id"].ToString(),
                    g_name = row["g_name"].ToString(),
                    g_image = row["g_image"].ToString(),
                    g_sup = row["g_sup"].ToString(),
                };
                result.Add(item);
            }
            return result;
        }

      
        public List<Ttov_art> GetMobileDBtov_art(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "tov_art", code_mobile);
            List<Ttov_art> result = new List<Ttov_art>();
            foreach (DataRow row in dt.Rows)
            {
                Ttov_art item = new Ttov_art()
                {
                    g_id = row["g_id"].ToString(),
                    t_article = row["t_article"].ToString(),
                    t_name = row["t_name"].ToString(),
                    t_cost = row["t_cost"].ToString(),
                    //fl_mark = int.Parse(row["fl_mark"].ToString()), 
                    //fl_mark = row["fl_mark"].ToString(), 
                    //fl_mark = 0, 
                    fl_mark = Convert.ToInt32(row["fl_mark"]),
                    ctlg_id = row["ctlg_id"].ToString(),
                    t_description = row["t_description"].ToString(),
                    t_image = row["t_image"].ToString(),
                    t_namebasket = row["t_namebasket"].ToString(),
                    t_imageprev = row["t_imageprev"].ToString(),
                };
                result.Add(item);
            }
            return result;
        }

       
        public List<Ttov_img> GetMobileDBtov_img(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "tov_img", code_mobile);
            List<Ttov_img> result = new List<Ttov_img>();
            foreach (DataRow row in dt.Rows)
            {
                Ttov_img item = new Ttov_img()
                {
                    filename = row["filename"].ToString(),
                    //img = row["img"].ToString(), 
                    //img = RetrieveFile(row["filename"].ToString(), app_code),
                };
                result.Add(item);
            }
            return result;
        }

       
        public List<Ttov_img> GetMobileDBtov_img_async(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "tov_img_async", code_mobile);
            List<Ttov_img> result = new List<Ttov_img>();
            foreach (DataRow row in dt.Rows)
            {
                Ttov_img item = new Ttov_img()
                {
                    filename = row["filename"].ToString(),
                    //img = row["img"].ToString(), 
                    //img = RetrieveFile(row["filename"].ToString(), app_code),
                };
                result.Add(item);
            }
            return result;
        }

       public List<Ttov_img_base64> GetMobileDBtov_img_base64_async(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "tov_img_async", code_mobile);
            List<Ttov_img_base64> result = new List<Ttov_img_base64>();
            foreach (DataRow row in dt.Rows)
            {
                Ttov_img_base64 item = new Ttov_img_base64()
                {
                    filename = row["filename"].ToString(),
                    //img = row["img"].ToString(), 
                    //img = RetrieveFile(row["filename"].ToString(), app_code),
                    imgBase64 = Convert.ToBase64String(ReadFully(GetImageMobile(app_code, row["filename"].ToString()))),
                    //imgBase64 = "",
                };
                result.Add(item);
            }
            return result;
        }

       public List<Ttov_img> GetMobileDBtov_img_sync(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "tov_img_sync", code_mobile);
            List<Ttov_img> result = new List<Ttov_img>();
            foreach (DataRow row in dt.Rows)
            {
                Ttov_img item = new Ttov_img()
                {
                    filename = row["filename"].ToString(),
                    //img = row["img"].ToString(), 
                    //img = RetrieveFile(row["filename"].ToString(), app_code),
                };
                result.Add(item);
            }
            return result;
        }

        public List<Ttov_contacts> GetMobileDBtov_contacts(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "tov_contacts", code_mobile);
            List<Ttov_contacts> result = new List<Ttov_contacts>();
            foreach (DataRow row in dt.Rows)
            {
                Ttov_contacts item = new Ttov_contacts()
                {
                    t_article = row["t_article"].ToString(),
                    phone = row["phone"].ToString(),
                    email = row["email"].ToString(),
                    newappcode = row["newappcode"].ToString(),
                    latitude = row["latitude"].ToString(),
                    longitude = row["longitude"].ToString(),
                    mapOfflineRadius = row["mapOfflineRadius"].ToString(),
                    mapOfflineZoomMin = Convert.ToInt32(row["mapOfflineZoomMin"]),
                    mapOfflineZoomMax = Convert.ToInt32(row["mapOfflineZoomMax"]),
                };
                result.Add(item);
            }
            return result;
        }

       public List<Tctlg> GetMobileDBctlg(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "ctlg", code_mobile);
            List<Tctlg> result = new List<Tctlg>();
            foreach (DataRow row in dt.Rows)
            {
                Tctlg item = new Tctlg()
                {
                    ctlg_id = row["ctlg_id"].ToString(),
                    ctlg_name = row["ctlg_name"].ToString(),
                };
                result.Add(item);
            }
            return result;
        }

        
        public List<Tsettings> GetMobileDBsettings(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "settings", code_mobile);
            List<Tsettings> result = new List<Tsettings>();
            foreach (DataRow row in dt.Rows)
            {
                Tsettings item = new Tsettings()
                {
                    name = row["name"].ToString(),
                    value = row["value"].ToString(),
                };
                result.Add(item);
            }
            return result;
        }

        
        public List<Tquestions> GetMobileDBquestions(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "questions", code_mobile);
            List<Tquestions> result = new List<Tquestions>();
            foreach (DataRow row in dt.Rows)
            {
                Tquestions item = new Tquestions()
                {
                    q_id = row["q_id"].ToString(),
                    q_description = row["q_description"].ToString(),
                    q_rightansid = row["q_rightansid"].ToString(),
                    q_image = row["q_image"].ToString(),
                    q_anstext = row["q_anstext"].ToString(),
                };
                result.Add(item);
            }
            return result;
        }

        public List<Tanswers> GetMobileDBanswers(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "answers", code_mobile);
            List<Tanswers> result = new List<Tanswers>();
            foreach (DataRow row in dt.Rows)
            {
                Tanswers item = new Tanswers()
                {
                    a_id = row["a_id"].ToString(),
                    a_description = row["a_description"].ToString(),
                    q_id = row["q_id"].ToString(),
                };
                result.Add(item);
            }
            return result;
        }



        public List<Tstyles> GetMobileDBstyles(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "styles", code_mobile);
            List<Tstyles> result = new List<Tstyles>();
            foreach (DataRow row in dt.Rows)
            {
                Tstyles item = new Tstyles()
                {
                    element = row["element"].ToString(),
                    property = row["property"].ToString(),
                    value = row["value"].ToString(),
                };
                result.Add(item);
            }
            return result;
        }

  
        public List<Tpredpr_kart> GetMobileDBpredpr_kart(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "predpr_kart", code_mobile);
            List<Tpredpr_kart> result = new List<Tpredpr_kart>();
            foreach (DataRow row in dt.Rows)
            {
                Tpredpr_kart item = new Tpredpr_kart()
                {
                    p_id = row["p_id"].ToString(),
                    p_descr = row["p_descr"].ToString(),
                    p_image = row["p_image"].ToString(),
                };
                result.Add(item);
            }
            return result;
        }

       
        public List<Tpredpr_tov_art> GetMobileDBpredpr_tov_art(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "predpr_tov_art", code_mobile);
            List<Tpredpr_tov_art> result = new List<Tpredpr_tov_art>();
            foreach (DataRow row in dt.Rows)
            {
                Tpredpr_tov_art item = new Tpredpr_tov_art()
                {
                    p_id = row["p_id"].ToString(),
                    t_article = row["t_article"].ToString(),
                };
                result.Add(item);
            }
            return result;
        }

        
        public List<Tpredpr_tov_gr> GetMobileDBpredpr_tov_gr(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "predpr_tov_gr", code_mobile);
            List<Tpredpr_tov_gr> result = new List<Tpredpr_tov_gr>();
            foreach (DataRow row in dt.Rows)
            {
                Tpredpr_tov_gr item = new Tpredpr_tov_gr()
                {
                    p_id = row["p_id"].ToString(),
                    g_id = row["g_id"].ToString(),
                };
                result.Add(item);
            }
            return result;
        }

        
        public List<Ttov_gr_tov_art> GetMobileDBtov_gr_tov_art(string app_code, string code_mobile)
        {
            DataTable dt = GetDataTable(app_code, "tov_gr_tov_art", code_mobile);
            List<Ttov_gr_tov_art> result = new List<Ttov_gr_tov_art>();
            foreach (DataRow row in dt.Rows)
            {
                Ttov_gr_tov_art item = new Ttov_gr_tov_art()
                {
                    g_id = row["g_id"].ToString(),
                    t_article = row["t_article"].ToString(),
                };
                result.Add(item);
            }
            return result;
        }

       
        public byte[] RetrieveFile(string filename, string app_code)
        {

            //    SqlConnection connection = new SqlConnection
            //       (GetConnString());

            SqlConnection connection = new SqlConnection
               (_config.GetConnectionString("DefaultConnection"));

            //    SqlCommand command = new SqlCommand
            //        ("sp_GetMobileDB @AppCode='"+app_code+"', @tablename='tov_img'", connection);

            SqlCommand command = new SqlCommand
                ("sp_GetImageMobile @AppCode='" + app_code + "', @img_filename='" + filename + "'", connection);


            //command.Parameters.AddWithValue("@Filename", filename);

            connection.Open();

            SqlDataReader reader =
                command.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);

            reader.Read();

            MemoryStream memory = new MemoryStream();

            long startIndex = 0;
            const int ChunkSize = 256;
            while (true)
            {
                byte[] buffer = new byte[ChunkSize];

                long retrievedBytes = reader.GetBytes(0, startIndex, buffer, 0, ChunkSize);

                memory.Write(buffer, 0, (int)retrievedBytes);

                startIndex += retrievedBytes;

                if (retrievedBytes != ChunkSize)
                    break;
            }

            connection.Close();

            byte[] data = memory.ToArray();

            memory.Dispose();

            return data;
        }

        
        public Stream GetImageMobile(string app_code, string img_filename)
        {
            //    SqlConnection connection = new SqlConnection
            //       (GetConnString());
            SqlConnection connection = new SqlConnection
               (_config.GetConnectionString("DefaultConnection"));
            SqlCommand command = new SqlCommand
                ("sp_GetImageMobile @AppCode='" + app_code + "', @img_filename='" + img_filename + "'", connection);
            connection.Open();
            SqlDataReader reader =
                command.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
            MemoryStream memory = new MemoryStream();
            if (reader.Read())
            {
                long startIndex = 0;
                const int ChunkSize = 256;
                while (true)
                {
                    byte[] buffer = new byte[ChunkSize];
                    if (reader.IsDBNull(0))
                    {
                        break;
                    }
                    long retrievedBytes = reader.GetBytes(0, startIndex, buffer, 0, ChunkSize);
                    memory.Write(buffer, 0, (int)retrievedBytes);
                    startIndex += retrievedBytes;
                    if (retrievedBytes != ChunkSize)
                        break;
                }
            }
            connection.Close();
            byte[] data = memory.ToArray();
            memory.Dispose();
            MemoryStream stream = new MemoryStream(data);
           // WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg"; //or whatever your mime type is
            stream.Position = 0;
            return stream;
        }

       
        public string GetImageMobileBase64(string app_code, string img_filename)
        {
            //    SqlConnection connection = new SqlConnection
            //       (GetConnString());
            SqlConnection connection = new SqlConnection
               (_config.GetConnectionString("DefaultConnection"));
            SqlCommand command = new SqlCommand
                ("sp_GetImageMobile @AppCode='" + app_code + "', @img_filename='" + img_filename + "'", connection);
            connection.Open();
            SqlDataReader reader =
                command.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
            MemoryStream memory = new MemoryStream();
            if (reader.Read())
            {
                long startIndex = 0;
                const int ChunkSize = 256;
                while (true)
                {
                    byte[] buffer = new byte[ChunkSize];
                    if (reader.IsDBNull(0))
                    {
                        break;
                    }
                    long retrievedBytes = reader.GetBytes(0, startIndex, buffer, 0, ChunkSize);
                    memory.Write(buffer, 0, (int)retrievedBytes);
                    startIndex += retrievedBytes;
                    if (retrievedBytes != ChunkSize)
                        break;
                }
            }
            connection.Close();
            byte[] data = memory.ToArray();
            memory.Dispose();
            string base64String = Convert.ToBase64String(data);
            //WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg"; //or whatever your mime type is
            return base64String;
        }

      
        public Stream GetVideoMobile(string app_code, string img_filename)
        {
            //    SqlConnection connection = new SqlConnection
            //       (GetConnString());
            SqlConnection connection = new SqlConnection
               (_config.GetConnectionString("DefaultConnection"));
            SqlCommand command = new SqlCommand
                ("sp_GetImageMobile @AppCode='" + app_code + "', @img_filename='" + img_filename + "'", connection);
            connection.Open();
            SqlDataReader reader =
                command.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);
            reader.Read();
            MemoryStream memory = new MemoryStream();
            long startIndex = 0;
            const int ChunkSize = 256;
            while (true)
            {
                byte[] buffer = new byte[ChunkSize];
                long retrievedBytes = reader.GetBytes(0, startIndex, buffer, 0, ChunkSize);
                memory.Write(buffer, 0, (int)retrievedBytes);
                startIndex += retrievedBytes;
                if (retrievedBytes != ChunkSize)
                    break;
            }
            connection.Close();
            byte[] data = memory.ToArray();
            memory.Dispose();
            MemoryStream stream = new MemoryStream(data);
            string img_ext = "";
            if (img_filename.Length > 4)
            {
                img_ext = img_filename.Substring(img_filename.Length - 4);
            }
            if (img_ext.Equals(".3gp", StringComparison.Ordinal))
            {
               // WebOperationContext.Current.OutgoingResponse.ContentType = "video/3gpp"; //or whatever your mime type is
            }
            else if (img_ext.Equals(".mov", StringComparison.Ordinal))
            {
               // WebOperationContext.Current.OutgoingResponse.ContentType = "video/quicktime"; //or whatever your mime type is
            }
            else
            {
               // WebOperationContext.Current.OutgoingResponse.ContentType = "video/mp4"; //or whatever your mime type is
            }
            stream.Position = 0;
            return stream;
        }
       
        public TVideoFileSave VideoFileSave(string app_code, string code_mobile, string filename)
        {

            //Stream stream = GetVideoMobile(app_code, filename);
            byte[] videoBytes = RetrieveFile(filename, app_code);
            bool result = false;
            string resfilename = code_mobile + "_" + app_code + "_" + filename;
            string errortext = "";

            FileStream writeStream;
            try
            {
                writeStream = new FileStream("C:\\InetPub\\wwwroot\\video\\" + resfilename, FileMode.Create);
                BinaryWriter writeBinary = new BinaryWriter(writeStream);

                //        byte[] dataArray = new byte[10];
                //        new Random().NextBytes(dataArray);

                writeBinary.Write(videoBytes);


                //writeBinary.Write(stream);

                //writeBinay.Write("CSharp.net-informations.com binary writer test");
                writeBinary.Close();
                result = true;
                //resfilename=code_mobile+".mp4";
            }
            catch (Exception ex)
            {
                //MessageBox.Show (ex.ToString());
                errortext = ex.ToString();
                resfilename = "";
            }

            return new TVideoFileSave()
            {
                Result = result,
                FileName = resfilename,
                ErrorText = errortext,
            };
        }

       
        public TVideoFileDelete VideoFileDelete(string app_code, string code_mobile, string filename)
        {

            bool result = false;

            string resfilename = code_mobile + "_" + app_code + "_" + filename;

            File.Delete("C:\\InetPub\\wwwroot\\video\\" + resfilename);

            result = true;

            return new TVideoFileDelete()
            {
                Result = result,
            };
        }


        

        public Tmessage GetImageMobile1(string app_code, string img_filename)
        {
            string m;
            m = "q";
            //    SqlConnection connection = new SqlConnection
            //       (GetConnString());

            SqlConnection connection = new SqlConnection
               (_config.GetConnectionString("DefaultConnection"));

            //    SqlCommand command = new SqlCommand
            //        ("sp_GetMobileDB @AppCode='"+app_code+"', @tablename='tov_img'", connection);

            SqlCommand command = new SqlCommand
                ("sp_GetImageMobile @AppCode='" + app_code + "', @img_filename='" + img_filename + "'", connection);


            //command.Parameters.AddWithValue("@Filename", filename);

            connection.Open();

            SqlDataReader reader =
                command.ExecuteReader(System.Data.CommandBehavior.SequentialAccess);

            reader.Read();

            MemoryStream memory = new MemoryStream();
            long retrievedBytes = 0;
            long startIndex = 0;
            const int ChunkSize = 256;
            //    while (true)
            //    {
            byte[] buffer = new byte[ChunkSize];
            try
            {
                retrievedBytes = reader.GetBytes(0, startIndex, buffer, 0, ChunkSize);
            }
            catch (Exception e)
            {
                m = e.Message;
                retrievedBytes = 0;
            }
            memory.Write(buffer, 0, (int)retrievedBytes);

            startIndex += retrievedBytes;

            //        if (retrievedBytes != ChunkSize)
            //            break;
            //    }

            connection.Close();

            byte[] data = memory.ToArray();

            memory.Dispose();
            Tmessage result = new Tmessage() { message = m };

            return result;
        }

       
        public int ServerTest()
        {
            int result = 0;
            string strSQL;
            strSQL = "sp_GetClass";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, _config.GetConnectionString("DefaultConnection"));
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                result = Convert.ToInt32(row["Mark"]);
                result = result + 1;
            }
            return 1 / result;
        }

        
        public TResult UpdateBase(string app_code, List<Table> tables)
        //public TResult UpdateBase(string app_code, RequestData rData)
        //public string UpdateTable(string app_code, string code_mobile, string tablename)
        {
            //List<Table> tables = tables;

            string resultStr = "";
            foreach (Table table in tables)
            {
                string tableName = table.tableName;
                resultStr = resultStr + tableName;

                resultStr = resultStr + UpdateTable(tableName, app_code, table);
            }

            TResult result = new TResult() { type = "success", value = "" };
            //TResult result = new TResult() {type = "success", value = resultStr};
            //TResult result = new TResult() {type = "error", value = resultStr};
            return result;
        }

        public string UpdateTable(string tableName, string appCode, Table table)
        {
            string result = "";

            switch (tableName)
            {
                case "predpr":
                    foreach (Tpredpr row in table.predpr)
                    {
                        result = result + UpdateRow(tableName, appCode, row);
                    }
                    break;
                case "tov_gr":
                    foreach (Ttov_gr row in table.tov_gr)
                    {
                        result = result + UpdateRow(tableName, appCode, row);
                    }
                    break;
                case "tov_art":
                    foreach (Ttov_art row in table.tov_art)
                    {
                        result = result + UpdateRow(tableName, appCode, row);
                    }
                    break;
                case "tov_img":
                    foreach (Ttov_img row in table.tov_img)
                    {
                        result = result + UpdateRow(tableName, appCode, row);
                    }
                    break;
                case "predpr_kart":
                    foreach (Tpredpr_kart row in table.predpr_kart)
                    {
                        result = result + UpdateRow(tableName, appCode, row);
                    }
                    break;
                case "predpr_tov_gr":
                    foreach (Tpredpr_tov_gr row in table.predpr_tov_gr)
                    {
                        result = result + UpdateRow(tableName, appCode, row);
                    }
                    break;
                case "predpr_tov_art":
                    foreach (Tpredpr_tov_art row in table.predpr_tov_art)
                    {
                        result = result + UpdateRow(tableName, appCode, row);
                    }
                    break;
                case "tov_gr_tov_art":
                    foreach (Ttov_gr_tov_art row in table.tov_gr_tov_art)
                    {
                        result = result + UpdateRow(tableName, appCode, row);
                    }
                    break;
                case "settings":
                    foreach (Tsettings row in table.settings)
                    {
                        result = result + UpdateRow(tableName, appCode, row);
                    }
                    break;
                case "tov_contacts":
                    foreach (Ttov_contacts row in table.tov_contacts)
                    {
                        result = result + UpdateRow(tableName, appCode, row);
                    }
                    break;
                case "styles":
                    foreach (Tstyles row in table.styles)
                    {
                        result = result + UpdateRow(tableName, appCode, row);
                    }
                    break;
                case "questions":
                    foreach (Tquestions row in table.questions)
                    {
                        result = result + UpdateRow(tableName, appCode, row);
                    }
                    break;
                case "answers":
                    foreach (Tanswers row in table.answers)
                    {
                        result = result + UpdateRow(tableName, appCode, row);
                    }
                    break;
                default:
                    //InvalidCommand(command);
                    break;
            }


            return result;

        }

        public string UpdateRow(string tableName, string appCode, object row)
        {

            string result = "";

            DataSet UpdateMarkMobileDB = new DataSet();
            SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            SqlCommand command = new SqlCommand("sp_zMobile_" + tableName, conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@appcode", SqlDbType.VarChar, 10);
            param.Value = appCode;

            Type myType = row.GetType();
            PropertyInfo[] myPropertyInfo = myType.GetProperties();
            for (int i = 0; i < myPropertyInfo.Length; i++)
            {

                PropertyInfo propValue = myPropertyInfo[i];
                result = result + propValue.Name;
                if (propValue.PropertyType == typeof(string))
                {
                    result = result + (string)propValue.GetValue(row, null);
                }
                else
                {
                    result = result + (string)propValue.GetValue(row, null).ToString();
                }

                if (propValue.GetValue(row, null) != null)
                {
                    if (propValue.PropertyType == typeof(string))
                    {
                        param = command.Parameters.Add("@" + propValue.Name, SqlDbType.NVarChar, 4000);
                        //    param = command.Parameters.Add("@"+propValue.Name, SqlDbType.NVarChar, Max);
                        param.Value = (string)propValue.GetValue(row, null);
                    }
                    if (propValue.PropertyType == typeof(int))
                    {
                        param = command.Parameters.Add("@" + propValue.Name, SqlDbType.Int);
                        param.Value = (int)propValue.GetValue(row, null);
                    }
                    if (propValue.PropertyType == typeof(float))
                    {
                        param = command.Parameters.Add("@" + propValue.Name, SqlDbType.Real);
                        param.Value = (float)propValue.GetValue(row, null);
                    }
                    if (propValue.PropertyType == typeof(byte[]))
                    {
                        param = command.Parameters.Add("@" + propValue.Name, SqlDbType.Binary);
                        param.Value = (byte[])propValue.GetValue(row, null);
                    }
                }
                else
                {
                    param = command.Parameters.Add("@" + propValue.Name, SqlDbType.Variant);
                    param.Value = null;
                }
            }

            //command.Parameters.Add("@Result", SqlDbType.Int);
            //command.Parameters["@Result"].Direction = ParameterDirection.Output;
            conn.Open();
            command.ExecuteNonQuery();
            //da.SelectCommand = command; ??????????
            //da.Fill(UpdateMarkMobileDB); ??????????
            //string message = command.Parameters["@Result"].Value.ToString();
            //int result = (int)command.Parameters["@Result"].Value;
            conn.Close();

            return result;
        }

        
        public TResult DeleteFromBase(string app_code, List<TRowToDelete> rowsToDelete)
        //public TResult UpdateBase(string app_code, RequestData rData)
        //public string UpdateTable(string app_code, string code_mobile, string tablename)
        {
            //List<Table> tables = tables;

            string resultStr = "";
            foreach (TRowToDelete rtd in rowsToDelete)
            {
                //string tableName = table.tableName;
                //resultStr = resultStr + tableName;

                resultStr = resultStr + DeleteRow(app_code, rtd);
            }

            TResult result = new TResult() { type = "success", value = "" };
            //TResult result = new TResult() {type = "error", value = resultStr};
            return result;
        }

       
        public TResult UploadPhoto(string appCode, string fileName, Stream fileContents)
        {
            TResult result;
            try
            {
                //var conv= new ImageConverter();
                var image = new Bitmap(fileContents);

                //MultipartParser parser = new MultipartParser(fileContents);
                byte[] img;
                using (var ms = new MemoryStream())
                {
                    image.Save(ms, image.RawFormat);
                    img = ms.ToArray();
                }
                DataSet UpdateMarkMobileDB = new DataSet();
                SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
                SqlCommand command = new SqlCommand("sp_zMobile_tov_img", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                SqlParameter param = new SqlParameter();
                param = command.Parameters.Add("@appcode", SqlDbType.VarChar, 10);
                param.Value = appCode;
                param = command.Parameters.Add("@filename", SqlDbType.VarChar, 4000);
                param.Value = fileName;
                param = command.Parameters.Add("@img", SqlDbType.Binary);
                //param.Value = ms.ToArray();
                param.Value = img;
                //command.Parameters.Add("@Result", SqlDbType.Int);
                //command.Parameters["@Result"].Direction = ParameterDirection.Output;
                conn.Open();
                command.ExecuteNonQuery();
                //da.SelectCommand = command; ??????????
                //da.Fill(UpdateMarkMobileDB); ??????????
                //string message = command.Parameters["@Result"].Value.ToString();
                //int result = (int)command.Parameters["@Result"].Value;
                conn.Close();

                result = new TResult() { type = "success", value = "" };
            }
             catch (ArgumentException)
            {
                result = new TResult() { type = "error", value = "Failed to parse multipart data!" };
            }
            //TResult result = new TResult() {type = "error", value = resultStr};
            return result;
        }

       
        public TResult SetUpdateAllFlag(string app_code)
        {
            /*
                DataSet UpdateMarkMobileDB = new DataSet();
                SqlConnection conn = new SqlConnection(Constants.strConn);
                SqlCommand command = new SqlCommand("sp_zMobile_updateall", conn);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                SqlParameter param = new SqlParameter();
                param = command.Parameters.Add("@appcode", SqlDbType.VarChar, 10);
                param.Value = app_code;
                //param.Value = ms.ToArray();
                //param.Value = img;
                //command.Parameters.Add("@Result", SqlDbType.Int);
                //command.Parameters["@Result"].Direction = ParameterDirection.Output;
                conn.Open();
                command.ExecuteNonQuery();
                //da.SelectCommand = command; ??????????
                //da.Fill(UpdateMarkMobileDB); ??????????
                //string message = command.Parameters["@Result"].Value.ToString();
                //int result = (int)command.Parameters["@Result"].Value;
                conn.Close();
            */
            TResult result = new TResult() { type = "error", value = "" };



            string strSQL = "sp_zMobile_updateall @appcode='" + app_code + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, _config.GetConnectionString("DefaultConnection"));
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            foreach (DataRow row in dt.Rows)
            {
                String resultString = row["ExecSql"].ToString();
                if (resultString.Equals("0", StringComparison.Ordinal))
                {
                    result.type = "success";
                }
                else if (resultString.Equals("1", StringComparison.Ordinal))
                {
                    result.value = "locked";
                }
            }

            return result;
        }

       
        public TResult AddInetMobileOrder2(string smsText, string comment)
        {
            TResult result = new TResult() { type = "error", value = "" };

            string strSQL = "sp_AddInetMobileOrder @String='" + smsText + "', @Note='" + comment + "'";
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, _config.GetConnectionString("DefaultConnection"));
            da.Fill(ds);

            result.type = "success";
            result.value = smsText;

            return result;
        }

      
        public TResult AddInetMobileOrder3()
        {
            TResult result = new TResult() { type = "error", value = "" };

            return result;
        }

       
        public TResult AddInetMobileOrder(TOrder order)
        {

            TResult result = new TResult() { type = "error", value = "" };
            try
            {

                string orderContent = order.orderContent;
                string orderComment = order.orderComment;
                string orderPhone = order.orderPhone;

                string strSQL = "sp_AddInetMobileOrder @String='" + orderContent + "', @Note='" + orderComment + "', @Phone='" + orderPhone + "'";
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(strSQL, _config.GetConnectionString("DefaultConnection"));
                da.Fill(ds);
                result.type = "success";

            }
            catch (Exception ex)
            {
                //Debug.WriteLine("Exception: " + ex.Message);
                result.value = ex.Message;
            }

            return result;
        }

        public string DeleteRow(string appCode, TRowToDelete rtd)
        {

            string result = "";

            DataSet UpdateMarkMobileDB = new DataSet();
            SqlConnection conn = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            SqlCommand command = new SqlCommand("sp_zMobile_" + rtd.tableName, conn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter();
            SqlParameter param = new SqlParameter();
            param = command.Parameters.Add("@appcode", SqlDbType.VarChar, 10);
            param.Value = appCode;
            param = command.Parameters.Add("@" + rtd.keyName, SqlDbType.NVarChar, 4000);
            param.Value = rtd.keyValue;
            if (rtd.key2Name.Length > 0)
            {
                param = command.Parameters.Add("@" + rtd.key2Name, SqlDbType.NVarChar, 4000);
                param.Value = rtd.key2Value;
            }
            param = command.Parameters.Add("@del", SqlDbType.Bit);
            param.Value = 1;
            //command.Parameters.Add("@Result", SqlDbType.Int);
            //command.Parameters["@Result"].Direction = ParameterDirection.Output;
            conn.Open();
            command.ExecuteNonQuery();
            //da.SelectCommand = command; ??????????
            //da.Fill(UpdateMarkMobileDB); ??????????
            //string message = command.Parameters["@Result"].Value.ToString();
            //int result = (int)command.Parameters["@Result"].Value;
            conn.Close();

            return result;
        }

        public DataTable GetDataTable(string app_code, string tablename, string code_mobile)
        //public DataTable GetDataTable(string app_code, string tablename)
        {
            string strSQL;
            //strConn=GetConnString();
            //strSQL = "sp_GetMobileDB @AppCode='"+app_code+"', @tablename='"+tablename+"'";

            if (tablename.Equals("tov_img_async", StringComparison.Ordinal))
            {
                strSQL = "sp_GetMobileDB @AppCode='" + app_code + "', @tablename='tov_img', @CodeMobile='" + code_mobile + "', @IsFirstImages=2";
            }
            else if (tablename.Equals("tov_img_sync", StringComparison.Ordinal))
            {
                strSQL = "sp_GetMobileDB @AppCode='" + app_code + "', @tablename='tov_img', @CodeMobile='" + code_mobile + "', @IsFirstImages=1";
            }
            else
            {
                strSQL = "sp_GetMobileDB @AppCode='" + app_code + "', @tablename='" + tablename + "'";
            }
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(strSQL, _config.GetConnectionString("DefaultConnection"));
            da.Fill(ds);
            DataTable dt = ds.Tables[0];
            return dt;
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

    }
}

