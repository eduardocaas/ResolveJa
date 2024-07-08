using Microsoft.AspNetCore.Identity;
using ResolveJa.Application.MvcServices.Interfaces;
using ResolveJa.Application.ViewModels;
using ResolveJa.Infrastructure.Data.Persistence;
namespace ResolveJa.Application.MvcServices.Implementations
{
    public class EmpresaMvcServiceImpl : IEmpresaMvcService
    {
        private readonly ResolveJaDbContext _context;
        private readonly IUserMvcService _userMvcService;
        private readonly IFuncionarioMvcService _funcionarioMvcService;

        public EmpresaMvcServiceImpl(
            ResolveJaDbContext context,
            IUserMvcService userMvcService,
            IFuncionarioMvcService funcionarioMvcService)
        {
            _context = context;
            _userMvcService = userMvcService;
            _funcionarioMvcService = funcionarioMvcService;
        }
        
        public async Task CreateEmpresa(EmpresaCreateInputModel model) // Realiza persistência da Empresa e cria usuário padrão
        {
            _context.Empresas.Add(model.Empresa);
            _context.SaveChanges();

            await _userMvcService.CreateGestor(model);
            await _funcionarioMvcService.CreateGestor(model);
        }

        public async Task DeleteEmpresa(int id)
        {
            var empresa = _context.Empresa.FirstOrDefault(x => x.Id == id);
            _context.Empresa.Remove(empresa);

            string? url = _context.Empresa.Select(e => e.Url).FirstOrDefault();
            IdentityUser user = (IdentityUser) _context.Users.Where(u => u.Email.StartsWith(url));
            _context.Users.Remove(user);
        }
    }
}
