using CriptografiasClassicas.Models;
using CriptografiasClassicas.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CriptografiasClassicas.Pages
{
    public class IndexModel : PageModel
    {
        private readonly CriptografiaService _criptografiaService;

        public IndexModel(CriptografiaService criptografiaService)
        {
            _criptografiaService = criptografiaService;
        }

        [BindProperty]
        public CriptografiaModel Criptografia { get; set; } = new();

        public void OnGet()
        {
        }

        public void OnPost()
        {
            try
            {
                Criptografia.Resultado =
                    _criptografiaService.Executar(
                        Criptografia.Texto,
                        Criptografia.Chave,
                        Criptografia.Cifra,
                        Criptografia.Operacao);
            }
            catch (ArgumentException ex)
            {
                Criptografia.Resultado = ex.Message;
            }
        }
    }
}