using CursoMVC.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMVC.Controllers
{
    public class UserController : Controller
    {
        private UserDBContext db = new UserDBContext();

        // GET: User
        public ActionResult RegisterUser()
        {
            return View();
        }

        /// <summary>
        /// Método encargado de recibir desde la vista un objeto para el registro de usuarios
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RegisterUser(UserModel model)
        {
            try
            {
                model.Perfil = "Nivel_1";

                // Se agrega el modelo al dbContext
                db.User.Add(model);

                // Guarda los cambio
                db.SaveChanges();

                return RedirectToAction("ListUser");

            }
            catch (Exception ex)
            {
                return View();
            }
        }


        public ActionResult ListUser()
        {
            List<UserModel> listUser = (from usuario in db.User
                                        orderby usuario.Cedula
                                        select usuario).ToList();

            return View(listUser);
        }
    }
}