
// ## AdminController.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Project.Models;

namespace Project.Controllers
{
    [Authorize] // Ограничава достъпа до контролера само за оторизирани потребители
    public class AdminController : Controller
    {
        private readonly YourDbContext _db = new YourDbContext(); // Инстанция на контекста на базата данни

        // GET: Admin
        // Показва началната страница на административния панел
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Admins
        // Показва списък на всички администратори
        public ActionResult ListAdmins()
        {
            var admins = _db.Admins.ToList(); // Извлича всички записи от таблицата "Admins"
            return View(admins); // Предава списъка с администратори към изгледа
        }

        // GET: Admin/AddAdmin
        // Показва формуляр за добавяне на нов администратор
        public ActionResult AddAdmin()
        {
            return View();
        }

        // POST: Admin/AddAdmin
        // Обработва данните от формуляра за добавяне на нов администратор
        [HttpPost]
        [ValidateAntiForgeryToken] // Защита от CSRF атаки
        public ActionResult AddAdmin(Admin admin)
        {
            if (ModelState.IsValid) // Проверка за валидност на данните
            {
                _db.Admins.Add(admin); // Добавяне на нов запис в таблицата "Admins"
                _db.SaveChanges(); // Записване на промените в базата данни
                return RedirectToAction("ListAdmins"); // Пренасочване към списъка с администратори
            }

            return View(admin); // Показване на формуляра отново с валидационни съобщения
        }

        // GET: Admin/EditAdmin/{id}
        // Показва формуляр за редактиране на съществуващ администратор
        public ActionResult EditAdmin(int id)
        {
            var admin = _db.Admins.Find(id); // Намиране на администратор по ID
            if (admin == null) // Проверка за наличие на администратор
            {
                return HttpNotFound(); // Връщане на 404 код, ако администраторът не е намерен
            }

            return View(admin); // Предаване на администратора към изгледа за редактиране
        }

        // POST: Admin/EditAdmin/{id}
        // Обработва данните от формуляра за редактиране на съществуващ администратор
        [HttpPost]
        [ValidateAntiForgeryToken] // Защита от CSRF атаки
        public ActionResult EditAdmin(Admin admin)
        {
            if (ModelState.IsValid) // Проверка за валидност на данните
            {
                _db.Entry(admin).State = EntityState.Modified; // Маркиране на записа за промяна
                _db.SaveChanges(); // Записване на промените в базата данни
                return RedirectToAction("ListAdmins"); // Пренасочване към списъка с администратори
            }

            return View(admin); // Показване на формуляра отново с валидационни съобщения
        }

        // GET: Admin/DeleteAdmin/{id}
        // Показва потвърждение за изтриване на администратор
        public ActionResult DeleteAdmin(int id)
        {
            var admin = _db.Admins.Find(id); // Намиране на администратор по ID
            if (admin == null) // Проверка за наличие на администратор
            {
                return HttpNotFound(); // Връщане на 404 код, ако администраторът не е намерен
            }

            return View(admin); // Предаване на администратора към изгледа за потвърждение
        }

        // POST: Admin/DeleteAdmin/{id}
        // Изтрива администратор от базата данни
        [HttpPost, ActionName("DeleteAdmin")]
        [ValidateAntiForgeryToken] // Защита от CSRF атаки
        public ActionResult DeleteConfirmed(int id)
        {
            var admin = _db.Admins.Find(id
