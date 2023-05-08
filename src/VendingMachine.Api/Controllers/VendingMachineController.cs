using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using VendingMachine.Business.Models;
using VendingMachine.Business.Repository;
using VendingMachine.Business.Services;
namespace VendingMachine.Api.Controllers;

[ApiController]
[Route("api/vendingmachine/")]
[Produces("application/json")]
[EnableCors("AllowAll")]
public class VendingMachineController : ControllerBase
{
    private readonly ILogger<VendingMachineController> _logger;
    private readonly IVendingService _service;

    public VendingMachineController(ILogger<VendingMachineController> logger,
        IVendingService service)
    {
        _logger = logger;
        _service = service;
    }


    [HttpGet]
    [Route("")]
    public async Task<IActionResult> GetInventory()
    {
        _logger.LogInformation("Getting inventory");
        var items = await _service.GetProductInventory();
        return Ok(items);
    }

    [HttpGet]
    [Route("products/{productId}")]
    public async Task<IActionResult> GetProductById(int productId)
    {
        _logger.LogInformation("Getting inventory");
        var item = await _service.GetProductInventoryById(productId);

        return Ok( item);
    }

    [HttpGet]
    [Route("transactions")]
    public async Task<IActionResult> GetTransactions()
    {
        _logger.LogInformation("Getting transactions");
        var transactions = await _service.GetTransactions();
        return Ok(transactions);
    }

    [HttpGet]
    [Route("transactions/{id}")]
    public async Task<IActionResult> GetTransactionById(int id)
    {
        _logger.LogInformation("Getting transaction by id");
        var transaction = await _service.GetTransactionById(id);
        return Ok(transaction);
    }

    [HttpPost]
    [Route("purchase")]
    public async Task<IActionResult> Purchase([FromBody] Transaction transaction)
    {
        _logger.LogInformation("Purchasing");
        var newTransaction = await _service.Purchase(transaction);
        return Ok(newTransaction);
    }

    [HttpDelete("{id:int}")]
    [Route("transactions/{id}")]
    public async Task<IActionResult> VoidTransaction(int id)
    {
        _logger.LogInformation("Voiding transaction");
        var success = await _service.VoidTransaction(id);
        return Ok(success);
    }
}
