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
    public class TipoVehiculoController : ControllerBase
    {
        private readonly ITipoVehiculoService tipoVehiculoService;
        private readonly IMapper mapper;
        private readonly IUriService uriService;

        public TipoVehiculoController(ITipoVehiculoService tipoVehiculoService, IMapper mapper, IUriService uriService)
        {
            this.tipoVehiculoService = tipoVehiculoService;
            this.mapper = mapper;
            this.uriService = uriService;
        }

        /// <summary>
        /// Recuperar todos los vehiculos
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<TipoVehiculoDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetAll([FromQuery] TipoVehiculoQueryFilter filters)
        {
            var tipoVehiculo = tipoVehiculoService.GetAllTipoVehiculos(filters);
            var tipoVehiculoDto = mapper.Map<IEnumerable<TipoVehiculoDto>>(tipoVehiculo);

            var metadata = new Metadata
            {
                TotalCount = tipoVehiculo.TotalCount,
                PageSize = tipoVehiculo.PageSize,
                CurrentPage = tipoVehiculo.CurrentPage,
                TotalPages = tipoVehiculo.TotalPages,
                HasNextPage = tipoVehiculo.HasNextPage,
                HasPreviousPage = tipoVehiculo.HasPreviousPage,
                NextPageUrl = uriService.GetTipoVehiculoPaginationUri(filters, Url.RouteUrl(nameof(GetAll))).ToString(),
                PreviousPageUrl = uriService.GetTipoVehiculoPaginationUri(filters, Url.RouteUrl(nameof(GetAll))).ToString()
            };

            var response = new ApiResponse<IEnumerable<TipoVehiculoDto>>(tipoVehiculoDto)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        /// <summary>
        /// Recuperar tipo de vehiculos por Id
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var tipoVehiculo = await tipoVehiculoService.GetTipoVehiculo(id);
            var tipoVehiculoDto = mapper.Map<TipoVehiculoDto>(tipoVehiculo);
            var response = new ApiResponse<TipoVehiculoDto>(tipoVehiculoDto);
            return Ok(response);
        }

        /// <summary>
        /// Insertar nuevo tipo de vehiculo
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SaveNewEntity(TipoVehiculoDto tipoVehiculoDto)
        {
            var tipoVehiculo = mapper.Map<TipoVehiculo>(tipoVehiculoDto);

            await tipoVehiculoService.InsertTipoVehiculo(tipoVehiculo);

            tipoVehiculoDto = mapper.Map<TipoVehiculoDto>(tipoVehiculo);
            var response = new ApiResponse<TipoVehiculoDto>(tipoVehiculoDto);
            return Ok(response);
        }

        /// <summary>
        /// Actualizar tipo de vehiculo por Id
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateEntity(int id, TipoVehiculoDto tipoVehiculoDto)
        {
            var tipoVehiculo = mapper.Map<TipoVehiculo>(tipoVehiculoDto);
            tipoVehiculo.Id = id;

            var result = await tipoVehiculoService.UpdateTipoVehiculo(tipoVehiculo);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        /// <summary>
        /// Eliminar tipo de vehiculo por Id
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await tipoVehiculoService.DeleteTipoVehiculo(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
