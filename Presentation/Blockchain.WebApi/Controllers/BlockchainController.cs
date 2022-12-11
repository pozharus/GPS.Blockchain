using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System;
using Blockchain.Application.Points.Queries.GetPointList;
using Blockchain.Application.Points.Queries.GetPointDetails;
using Blockchain.WebApi.Models;
using Blockchain.Application.Points.Commands.CreatePoint;

namespace Blockchain.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class BlockchainController : BaseController
    {
        private readonly IMapper _mapper;
        public BlockchainController(IMapper mapper) => _mapper = mapper;

        /// <summary>
        /// Get the list of gps points
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /blockchain
        /// </remarks>
        /// <returns>Returns PointListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PointListVm>> GetAll()
        {
            var query = new GetPointListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the GPS point by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /blockchain/0f8fad5b-d9cb-469f-a165-70867728950e
        /// </remarks>
        /// <param name="id">Point id</param>
        /// <returns>Returns PointDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<PointDetailsVm>> Get(string id)
        {
            var query = new GetPointDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the GPS point
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /point
        /// 
        /// {
        ///     timestamp: "yyyy.mm.dd.yy.mm.ss",
        ///     latitude: "xx.xx"
        ///     longitude: "xx.xx"
        ///     altitude: "xx.xx"
        ///     speed: "xx.xx"
        ///     satelites: "xx"
        ///     delusionOfPresition: "xx.xx"
        ///     horizontalDelusionOfPresition: "xx.xx"
        ///     verticalDelusionOfPresition: "xx.xx"
        /// }
        /// </remarks>
        /// <param name="createPointDto">CreatePointDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreatePointDto createPointDto)
        {
            var command = _mapper.Map<CreatePointCommand>(createPointDto);
            var pointId = await Mediator.Send(command);
            return Ok(pointId);
        }
    }
}
