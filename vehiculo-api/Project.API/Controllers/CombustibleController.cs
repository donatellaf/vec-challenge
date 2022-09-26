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
    public class CombustibleController : ControllerBase
    {
        private readonly ICombustibleService combustibleService;
        private readonly IMapper mapper;
        private readonly IUriService uriService;

        public CombustibleController(ICombustibleService combustibleService, IMapper mapper, IUriService uriService)
        {
            this.combustibleService = combustibleService;
            this.mapper = mapper;
            this.uriService = uriService;
        }

        /// <summary>
        /// Recuperar todos los combustibles
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<CombustibleDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetAll([FromQuery] CombustibleQueryFilter filters)
        {
            var combustible = combustibleService.GetAllCombustibles(filters);
            var combustibleDto = mapper.Map<IEnumerable<CombustibleDto>>(combustible);

            var metadata = new Metadata
            {
                TotalCount = combustible.TotalCount,
                PageSize = combustible.PageSize,
                CurrentPage = combustible.CurrentPage,
                TotalPages = combustible.TotalPages,
                HasNextPage = combustible.HasNextPage,
                HasPreviousPage = combustible.HasPreviousPage,
                NextPageUrl = uriService.GetCombustiblePaginationUri(filters, Url.RouteUrl(nameof(GetAll))).ToString(),
                PreviousPageUrl = uriService.GetCombustiblePaginationUri(filters, Url.RouteUrl(nameof(GetAll))).ToString()
            };

            var response = new ApiResponse<IEnumerable<CombustibleDto>>(combustibleDto)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        /// <summary>
        /// Recuperar combustibles por Id
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var combustible = await combustibleService.GetCombustible(id);
            var combustibleDto = mapper.Map<CombustibleDto>(combustible);
            var response = new ApiResponse<CombustibleDto>(combustibleDto);
            return Ok(response);
        }

        /// <summary>
        /// Insertar nuevo combustible
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SaveNewEntity(CombustibleDto combustibleDto)
        {
            var combustible = mapper.Map<Combustible>(combustibleDto);

            await combustibleService.InsertCombustible(combustible);

            combustibleDto = mapper.Map<CombustibleDto>(combustible);
            var response = new ApiResponse<CombustibleDto>(combustibleDto);
            return Ok(response);
        }

        /// <summary>
        /// Actualizar combustible por Id
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateEntity(int id, CombustibleDto combustibleDto)
        {
            var combustible = mapper.Map<Combustible>(combustibleDto);
            combustible.Id = id;

            var result = await combustibleService.UpdateCombustible(combustible);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        /// <summary>
        /// Eliminar combustible por Id
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await combustibleService.DeleteCombustible(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
