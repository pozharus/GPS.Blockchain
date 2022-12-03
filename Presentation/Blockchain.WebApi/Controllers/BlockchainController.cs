using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using Blockchain.Application.Points.Queries.GetPointList;
using Blockchain.Application.Points.Queries.GetPointDetails;
using Blockchain.WebApi.Models;
using Blockchain.Application.Points.Commands.CreatePoint;

namespace Blockchain.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class BlockchainController : BaseController
    {
        private readonly IMapper _mapper;
        public BlockchainController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<PointListVm>> GetAll()
        {
            var query = new GetPointListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PointDetailsVm>> Get(Guid id)
        {
            var query = new GetPointDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePointDto createPointDto)
        {
            var command = _mapper.Map<CreatePointCommand>(createPointDto);
            var pointId = await Mediator.Send(command);
            return Ok(pointId);
        }
    }
}
