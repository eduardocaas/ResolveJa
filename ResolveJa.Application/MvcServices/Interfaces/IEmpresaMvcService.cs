﻿using ResolveJa.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Application.MvcServices.Interfaces
{
    public interface IEmpresaMvcService
    {
        Task CreateEmpresa(EmpresaCreateInputModel model);
        Task DeleteEmpresa(int id);
    }
}
