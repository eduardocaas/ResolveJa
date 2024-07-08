using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
            _funcionarioMvcService.DeleteFuncionarioEmpresa(id);

            var empresa = _context.Empresa.FirstOrDefault(x => x.Id == id);
            if (empresa != null) 
                _context.Empresa.Remove(empresa);

            string? url = _context.Empresa.Select(e => e.Url).FirstOrDefault();
            var likeExpression = url+"%";

            IdentityUser? user = _context.Users.Where(u => EF.Functions.Like(u.Email, likeExpression)).FirstOrDefault();
            if (user != null)
                _context.Users.Remove(user);
        }
    }
}
