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
    public class MarcaController : ControllerBase
    {
        private readonly IMarcaService marcaService;
        private readonly IMapper mapper;
        private readonly IUriService uriService;

        public MarcaController(IMarcaService marcaService, IMapper mapper, IUriService uriService)
        {
            this.marcaService = marcaService;
            this.mapper = mapper;
            this.uriService = uriService;
        }

        /// <summary>
        /// Recuperar todos las marcas
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<MarcaDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetAll([FromQuery] MarcaQueryFilter filters)
        {
            var marca = marcaService.GetAllMarcas(filters);
            var marcaDto = mapper.Map<IEnumerable<MarcaDto>>(marca);

            var metadata = new Metadata
            {
                TotalCount = marca.TotalCount,
                PageSize = marca.PageSize,
                CurrentPage = marca.CurrentPage,
                TotalPages = marca.TotalPages,
                HasNextPage = marca.HasNextPage,
                HasPreviousPage = marca.HasPreviousPage,
                NextPageUrl = uriService.GetMarcaPaginationUri(filters, Url.RouteUrl(nameof(GetAll))).ToString(),
                PreviousPageUrl = uriService.GetMarcaPaginationUri(filters, Url.RouteUrl(nameof(GetAll))).ToString()
            };

            var response = new ApiResponse<IEnumerable<MarcaDto>>(marcaDto)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        /// <summary>
        /// Recuperar marcas por Id
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var marca = await marcaService.GetMarca(id);
            var marcaDto = mapper.Map<MarcaDto>(marca);
            var response = new ApiResponse<MarcaDto>(marcaDto);
            return Ok(response);
        }

        /// <summary>
        /// Insertar nueva marca
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SaveNewEntity(MarcaDto marcaDto)
        {
            var marca = mapper.Map<Marca>(marcaDto);

            await marcaService.InsertMarca(marca);

            marcaDto = mapper.Map<MarcaDto>(marca);
            var response = new ApiResponse<MarcaDto>(marcaDto);
            return Ok(response);
        }

        /// <summary>
        /// Actualizar marca por Id
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateEntity(int id, MarcaDto marcaDto)
        {
            var marca = mapper.Map<Marca>(marcaDto);
            marca.Id = id;

            var result = await marcaService.UpdateMarca(marca);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        /// <summary>
        /// Eliminar marca por Id
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await marcaService.DeleteMarca(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
