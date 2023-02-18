using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static CricketScoringAppLibrary.Tournament.Tournament_DAM;

namespace CricketScoringAppController.Controllers.Tournament
{
    public class TournamentController : Controller
    {
        // GET: Tournament
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTournamentData(string UserId)
        {
            string Result = string.Empty;
            TournamentMgr tournamentMgr = new TournamentMgr();
            SqlConnection con = new SqlConnection("Data Source = LAPTOP-LHA9RHCA\\SQLEXPRESS; Initial Catalog = CricketScoringApp; Integrated Security = True");
            try
            {
                con.Open();
                Result = tournamentMgr.GetTournamentData(UserId, con);
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