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

        /// <summary>
        /// Método encargado de Listar los usuarios que se encuentran creados
        /// </summary>
        /// <returns></returns>
        public ActionResult ListUser()
        {
            List<UserModel> listUser = (from usuario in db.User
                                        orderby usuario.Cedula
                                        select usuario).ToList();

            return View(listUser);
        }

        /// <summary>
        /// Método encargado de consultar el usuario seleccionado 
        /// a través del ID (Cedula)
        /// </summary>
        /// <param name="id">Dato clave único del usuario</param>
        /// <returns>Vista de tipo UserModel con el usuario consultado</returns>
        public ActionResult EditUser(string id)
        {
            UserModel User = db.User.Single(edit => edit.Cedula == id);
            return View(User);
        }


        /// <summary>
        /// Método encargado de consultar el usuario seleccionado que será modificado 
        /// y reflejado en base de datos
        /// </summary>
        /// <param name="cedula">Clave única del registro</param>
        /// <param name="collection">Formulario Actual</param>
        /// <returns>Vista actual o que lista los usuarios</returns>
        [HttpPost]
        public ActionResult EditUser(string cedula, FormCollection collection)
        {
            UserModel User = db.User.Single(edit => edit.Cedula == cedula);
            if (TryUpdateModel(User))
            {
                db.SaveChanges();
                return RedirectToAction("ListUser");
            }

            return View(User);
        }

        /// <summary>
        /// Método encargado de consultar el usuario seleccionado que será eliminado 
        /// y reflejado en base de datos
        /// </summary>
        /// <param name="id">Dato clave único del usuario</param>
        /// <returns>Vista de tipo UserModel con el usuario consultado</returns>
        public ActionResult DeleteUser(string id)
        {
            UserModel User = db.User.Single(delete => delete.Cedula == id);
            return View(User);
        }


        /// <summary>
        /// Método encargado de consultar el usuario seleccionado que será eliminado
        /// y reflejado en base de datos
        /// </summary>        
        /// <param name="cedula">Clave única del registro</param>
        /// <param name="collection">Formulario Actual</param>
        /// <returns>Vista actual o que lista los usuarios</returns>
        [HttpPost]
        public ActionResult DeleteUser(string id, FormCollection collection)
        {
            UserModel User = db.User.Single(delete => delete.Cedula == id);
            try
            {
                db.User.Remove(User);
                db.SaveChanges();
                return RedirectToAction("ListUser");
            }
            catch (Exception)
            {
                return View(User);
            }


        }
    }
}