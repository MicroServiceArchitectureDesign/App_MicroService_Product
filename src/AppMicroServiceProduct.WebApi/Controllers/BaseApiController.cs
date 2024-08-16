using AppMicroServiceBuildingBlock.Contract.ApplicationContracts.Contracts.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AppMicroServiceProduct.WebApi.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public abstract class BaseApiController(IMediatorBus mediatorBus) : ControllerBase
{
    protected readonly IMediatorBus MediatorBus = mediatorBus;
}