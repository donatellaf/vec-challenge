using AutoMapper;
using Project.API.Response;
using Project.Domain.CustomEntitites;
using Project.Domain.Dtos;
using Project.Domain.Interfaces.Services;
using Project.Domain.QueryFilters;
using Project.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Project.Infra.Data.Interfaces;

namespace Project.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TransmisionController : ControllerBase
    {
        private readonly ITransmisionService transmisionService;
        private readonly IMapper mapper;
        private readonly IUriService uriService;

        public TransmisionController(ITransmisionService transmisionService, IMapper mapper, IUriService uriService)
        {
            this.transmisionService = transmisionService;
            this.mapper = mapper;
            this.uriService = uriService;
        }

        /// <summary>
        /// Recuperar todas las transmisiones
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<TransmisionDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetAll([FromQuery] TransmisionQueryFilter filters)
        {
            var transmision = transmisionService.GetAllTransmisiones(filters);
            var transmisionDto = mapper.Map<IEnumerable<TransmisionDto>>(transmision);

            var metadata = new Metadata
            {
                TotalCount = transmision.TotalCount,
                PageSize = transmision.PageSize,
                CurrentPage = transmision.CurrentPage,
                TotalPages = transmision.TotalPages,
                HasNextPage = transmision.HasNextPage,
                HasPreviousPage = transmision.HasPreviousPage,
                NextPageUrl = uriService.GetTransmisionPaginationUri(filters, Url.RouteUrl(nameof(GetAll))).ToString(),
                PreviousPageUrl = uriService.GetTransmisionPaginationUri(filters, Url.RouteUrl(nameof(GetAll))).ToString()
            };

            var response = new ApiResponse<IEnumerable<TransmisionDto>>(transmisionDto)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        /// <summary>
        /// Recuperar transmisiones por Id
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var transmision = await transmisionService.GetTransmision(id);
            var transmisionDto = mapper.Map<TransmisionDto>(transmision);
            var response = new ApiResponse<TransmisionDto>(transmisionDto);
            return Ok(response);
        }

        /// <summary>
        /// Insertar nueva transmision
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SaveNewEntity(TransmisionDto transmisionDto)
        {
            var transmision = mapper.Map<Transmision>(transmisionDto);

            await transmisionService.InsertTransmision(transmision);

            transmisionDto = mapper.Map<TransmisionDto>(transmision);
            var response = new ApiResponse<TransmisionDto>(transmisionDto);
            return Ok(response);
        }

        /// <summary>
        /// Actualizar transmision por Id
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateEntity(int id, TransmisionDto transmisionDto)
        {
            var transmision = mapper.Map<Transmision>(transmisionDto);
            transmision.Id = id;

            var result = await transmisionService.UpdateTransmision(transmision);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        /// <summary>
        /// Eliminar transmision por Id
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await transmisionService.DeleteTransmision(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
