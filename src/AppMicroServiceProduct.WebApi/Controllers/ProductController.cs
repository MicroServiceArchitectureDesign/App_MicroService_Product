using AppMicroServiceBuildingBlock.Contract.ApplicationContracts.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppMicroServiceProduct.WebApi.Controllers;

public class ProductController(IMediatorBus mediatorBus) : BaseApiController(mediatorBus)
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Get method called.");
    }
}