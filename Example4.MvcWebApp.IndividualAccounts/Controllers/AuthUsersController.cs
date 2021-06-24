﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthPermissions.AdminCode;
using AuthPermissions.AspNetCore;
using AuthPermissions.DataKeyCode;
using Example4.MvcWebApp.IndividualAccounts.Models;
using Example4.MvcWebApp.IndividualAccounts.PermissionsCode;
using Microsoft.EntityFrameworkCore;

namespace Example4.MvcWebApp.IndividualAccounts.Controllers
{
    public class AuthUsersController : Controller
    {
        private IAuthUsersAdminService _authUsersAdmin;

        public AuthUsersController(IAuthUsersAdminService authUsersAdmin)
        {
            _authUsersAdmin = authUsersAdmin;
        }

        // List users filtered by authUser tenant
        [HasPermission(Example4Permissions.UserRead)]
        public async Task<ActionResult> Index()
        {
            var authDataKey = User.GetAuthDataKey();
            var userQuery = _authUsersAdmin.QueryAuthUsers();
            if (authDataKey != null)
                userQuery = userQuery.Where(x => x.UserTenant.TenantDataKey.StartsWith(authDataKey));
            var usersToShow = await AuthUserDisplay.SelectQuery(userQuery.OrderBy(x => x.Email)).ToListAsync();

            return View(usersToShow);
        }

        // GET: AuthUsersController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AuthUsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AuthUsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthUsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AuthUsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AuthUsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AuthUsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}