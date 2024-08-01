using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResolveJa.Application.Api.ViewModels
{
    public struct EmpresaUrlApiViewModel
    {
        public EmpresaUrlApiViewModel(string url)
        {
            Url = url;
        }

        public string Url { get; set; }
    }
}
