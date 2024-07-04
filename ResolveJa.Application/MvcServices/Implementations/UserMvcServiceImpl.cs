﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ResolveJa.Application.MvcServices.Interfaces;
using ResolveJa.Application.ViewModels;
using ResolveJa.Web.MVC.Common;

namespace ResolveJa.Application.MvcServices.Implementations
{
    public class UserMvcServiceImpl : IUserMvcService
    {
        public void CreateGestorUser(EmpresaCreateInputModel model)
        {
            IdentityUser identityGestor = new IdentityUser();

            Guid guid = Guid.NewGuid();
            identityGestor.Id = guid.ToString();
            identityGestor.UserName = model.Empresa.Url.ToString();
            identityGestor.Email = (model.Empresa.Url.ToString() + "@email.com");
            identityGestor.NormalizedUserName = (model.Empresa.Url.ToString() + "@email.com");

            _context.Users.Add(identityGestor);

            var hashedPassword = _passwordHasher.HashPassword(identityGestor, model.SenhaGestor);
            identityGestor.SecurityStamp = Guid.NewGuid().ToString();
            identityGestor.PasswordHash = hashedPassword;

            _context.SaveChanges();

            var userManager = _services.GetRequiredService<UserManager<IdentityUser>>();
            userManager.AddToRoleAsync(identityGestor, Roles.Gestor);
        }
    }
}
