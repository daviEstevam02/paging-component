using EasyDocs.Application.Interfaces;
using EasyDocs.Application.ViewModels.Companies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyDocs.WebApi.Controllers;

[Authorize]
[Route("companies")]
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
    /// Retorna a empresa com o código especificado dela
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpGet("{companyId}")]
    public async Task<ResponseCompanyViewModel> GetById(Guid companyId)
       => await _companyServices.GetById(companyId);

    /// <summary>
    /// Realiza a criação de uma Empresa, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PostCompanyViewModel viewModel)
       => CustomResponse(await _companyServices.Create(viewModel));

    /// <summary>
    /// Realiza a edição de uma Empresa através de um corpo JSON, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpPut]
    public async Task<IActionResult> Put([FromForm] PutCompanyViewModel viewModel)
        => CustomResponse(await _companyServices.Update(viewModel));

    /// <summary>
    /// Realiza a deleção (desativamento) de uma Empresa através de um corpo JSON, retornando uma mensagem. Caso haja falha, o retorno será uma lista de erros.
    /// </summary>
    /// <remarks>
    /// </remarks>
    [HttpDelete]
    public async Task<IActionResult> Delete([FromBody] DeleteCompanyViewModel viewModel)
        => CustomResponse(await _companyServices.Delete(viewModel));
}