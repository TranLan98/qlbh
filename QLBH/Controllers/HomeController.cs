using QLBH.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;




namespace QLBH.Controllers
{
    public class HomeController : Controller
    {
        private QLBHDbContext db = new QLBHDbContext();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //GET : Register
        public ActionResult Register()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //POST : Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(user _user)
        {
            if (ModelState.IsValid)
            {
                var checkEmail = db.users.FirstOrDefault(m => m.email == _user.email); //m = model, kiểm tra xem email có trong database hay chưa
                if(checkEmail == null) // check email
                {
                    _user.password = GETMD5(_user.password); //mã hóa password người dùng nhập
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.users.Add(_user);
                    db.SaveChanges();
                    return RedirectToAction("Login");// đăng kí thành công trả về trang login
                }    
                else
                {
                    ViewBag.EmailError = " Email đã tồn tại ";
                    return RedirectToAction("Register");
                }
            }
            return View();

        }
        //GET:Login
        public ActionResult Login()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //POST : Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email, string password)
        {
            var passToMD5 = GETMD5(password);
            var ktra_tk = db.users.Where(m => m.email.Equals(email) &&  m.password.Equals(passToMD5)).ToList();
            if (ktra_tk != null) 
            {
                Session["id_user"] = ktra_tk.FirstOrDefault().id;
                Session["name_user"] = ktra_tk.FirstOrDefault().name;
                var checkAdmin = ktra_tk.FirstOrDefault().role;// kiểm tra có phải admin 
                if ( checkAdmin == "Admin" )
                {
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                } 
                else
                {
                    return RedirectToAction("Index");
                }
                //return RedirectToAction("Index");
            }
            else
            {
                ViewBag.LoginError = "Đăng nhập thất bại";
                return View();
            }
        }
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }

        // CREATE MD5 : mã hóa dữ liệu 1 chiều
        public static string GETMD5(string Str) //Getmd5 truyền đến 1 mảng
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(Str);
            byte[] targetData = md5.ComputeHash(fromData);
            string mahoa = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                mahoa += targetData[i].ToString("x2");

            }
            return mahoa;
        }
        //linq: tạo action trả về dữ liệu bảng account 
        /*public ActionResult DemoLinq ()
        {
            var list = ( from acc in db.users
                       join role in db.Roles on acc.RoleID equals role.RoleID
                       select new
                       {
                           acc.user,
                           role.RoleName,
                       }).ToList();
            var ac = db.users.ToList();
            return (View(ac));
        }*/
        
    }
}