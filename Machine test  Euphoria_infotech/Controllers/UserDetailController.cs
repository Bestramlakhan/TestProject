using Machine_test__Euphoria_infotech.Models;
using Machine_test__Euphoria_infotech.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Machine_test__Euphoria_infotech.Controllers
{
    public class UserDetailController : Controller
    {
        // GET: UserDetail
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserRegistation userRegistratio)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserDetailRepository userDetailRepository = new UserDetailRepository();

                    if (userDetailRepository.AddReg(userRegistratio))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public ActionResult Login()
        {
            if (Session["LoggedInUserName"] == null)
                return View();
            else
                return RedirectToAction(nameof(AccountDetail));
        }


        [HttpPost]
        public ActionResult Login(UserLogin userLogin)
        {
            string SqlCon = ConfigurationManager.ConnectionStrings["EuphoriaDB"].ConnectionString;
            SqlConnection con = new SqlConnection(SqlCon);
            string SqlQuery = "select UserName,Password from UserRegistation where UserName=@UserName and Password=@Password";
            con.Open();
            SqlCommand cmd = new SqlCommand(SqlQuery, con);
            cmd.Parameters.AddWithValue("@UserName", userLogin.UserName);
            cmd.Parameters.AddWithValue("@Password", userLogin.Password);
            SqlDataReader sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                Session["LoggedInUserName"] = userLogin.UserName.ToString();
                return RedirectToAction(nameof(AccountDetail));
            }
            else
            {
                ViewData["Message"] = "Login Failed, Username OR Password incorrect!!";
            }
            con.Close();
            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            Session["LoggedInUserName"] = null;
            Session.Clear();
            return RedirectToAction(nameof(Login));
        }

        [HttpGet]
        public ActionResult AccountDetail()
        {
            if (Session["LoggedInUserName"] != null)
            {
                DataTable dt = new DataTable();
                string SqlCon = ConfigurationManager.ConnectionStrings["EuphoriaDB"].ConnectionString;
                using (SqlConnection cn = new SqlConnection(SqlCon))
                {
                    using (SqlCommand cmd = new SqlCommand($"select Name,Address,UserName,Age from UserRegistation where UserName='{Session["LoggedInUserName"]}'"))
                    {
                        cmd.Connection = cn;
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
                return View(dt);
            }
            return RedirectToAction(nameof(Login));
        }

    }
}
       




