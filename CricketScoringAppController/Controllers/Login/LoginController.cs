using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static CricketScoringAppLibrary.Login_DAM;

namespace CricketScoringAppController.Controllers.Login
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetUserData(string LoginData)
        {
            string Result = string.Empty;
            LoginMgr loginMgr = new LoginMgr();
            LoginData loginData = JsonConvert.DeserializeObject<LoginData>(LoginData);
            SqlConnection con = new SqlConnection("Data Source = LAPTOP-LHA9RHCA\\SQLEXPRESS; Initial Catalog = CricketScoringApp; Integrated Security = True");
            try
            {
                con.Open();
                Result = loginMgr.GetUserData(loginData, con);
            }
            catch (Exception ex)
            {
                Result = "Error : " + ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetEditData(string UserId)
        {
            string Result = string.Empty;
            LoginMgr loginMgr = new LoginMgr();
            SqlConnection con = new SqlConnection("Data Source = LAPTOP-LHA9RHCA\\SQLEXPRESS; Initial Catalog = CricketScoringApp; Integrated Security = True");
            try
            {
                con.Open();
                Result = loginMgr.GetEditData(UserId, con);
            }
            catch (Exception ex)
            {
                Result = "Error : " + ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetLastUserId(string UserName, string Password)
        {
            string Result = string.Empty;
            LoginMgr loginMgr = new LoginMgr();
            SqlConnection con = new SqlConnection("Data Source = LAPTOP-LHA9RHCA\\SQLEXPRESS; Initial Catalog = CricketScoringApp; Integrated Security = True");
            try
            {
                con.Open();
                Result = loginMgr.GetLastUserId(con);
            }
            catch (Exception ex)
            {
                Result = "Error : " + ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult SaveUserData(string UserData,int Uid)
        {
            string Result = string.Empty;
            LoginMgr loginMgr = new LoginMgr();
            LoginData loginData = JsonConvert.DeserializeObject<LoginData>(UserData);
            SqlConnection con = new SqlConnection("Data Source = LAPTOP-LHA9RHCA\\SQLEXPRESS; Initial Catalog = CricketScoringApp; Integrated Security = True");
            try
            {
                con.Open();
                Result = loginMgr.SaveUserData(loginData, Uid,con);
            }
            catch (Exception ex)
            {
                Result = "Error : " + ex;
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return Json(Result, JsonRequestBehavior.AllowGet);
        }
    }
}