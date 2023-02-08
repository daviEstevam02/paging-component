using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.Companies;
using Gooders.Services.WebApi.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyDocs.WebApi.Controllers;

[Route("companies")]
[Authorize]
public sealed class CompanyController : ApiController
{
    private readonly ICompanyServices _companyServices;

    public CompanyController(ICompanyServices companyServices)
    {
        _companyServices = companyServices;
    }

    /// <summary>
    /// Retorna todas as Empresas cadastradas interligadas com o Licenciado especificado.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpGet("all/{licenciadoId}")]
    public async Task<IEnumerable<ResponseCompanyViewModel>> GetAll(Guid licenciadoId)
       => await _companyServices.GetAll(licenciadoId);

    /// <summary>
    /// Realiza a criação de uma Empresa, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostCompanyViewModel viewModel)
       => CustomResponse(await _companyServices.Create(viewModel));
}