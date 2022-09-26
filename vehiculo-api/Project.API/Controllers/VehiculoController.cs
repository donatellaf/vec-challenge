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
    public class VehiculoController : ControllerBase
    {
        private readonly IVehiculoService vehiculoService;
        private readonly IMapper mapper;
        private readonly IUriService uriService;

        public VehiculoController(IVehiculoService vehiculoService, IMapper mapper, IUriService uriService)
        {
            this.vehiculoService = vehiculoService;
            this.mapper = mapper;
            this.uriService = uriService;
        }

        /// <summary>
        /// Recuperar todos los vehiculos
        /// </summary>
        /// <param name="filters">Filters to apply</param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<VehiculoDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult GetAll([FromQuery] VehiculoQueryFilter filters)
        {
            var vehiculo = vehiculoService.GetAllVehiculos(filters);
            var vehiculoDto = mapper.Map<IEnumerable<VehiculoDto>>(vehiculo);

            var metadata = new Metadata
            {
                TotalCount = vehiculo.TotalCount,
                PageSize = vehiculo.PageSize,
                CurrentPage = vehiculo.CurrentPage,
                TotalPages = vehiculo.TotalPages,
                HasNextPage = vehiculo.HasNextPage,
                HasPreviousPage = vehiculo.HasPreviousPage,
                NextPageUrl = uriService.GetVehiculoPaginationUri(filters, Url.RouteUrl(nameof(GetAll))).ToString(),
                PreviousPageUrl = uriService.GetVehiculoPaginationUri(filters, Url.RouteUrl(nameof(GetAll))).ToString()
            };

            var response = new ApiResponse<IEnumerable<VehiculoDto>>(vehiculoDto)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(response);
        }

        /// <summary>
        /// Recuperar vehiculos por Id
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetById(int id)
        {
            var vehiculo = await vehiculoService.GetVehiculo(id);
            var vehiculoDto = mapper.Map<VehiculoDto>(vehiculo);
            var response = new ApiResponse<VehiculoDto>(vehiculoDto);
            return Ok(response);
        }

        /// <summary>
        /// Insertar nuevo vehiculo
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> SaveNewEntity(VehiculoDto vehiculoDto)
        {
            var vehiculo = mapper.Map<Vehiculo>(vehiculoDto);

            await vehiculoService.InsertVehiculo(vehiculo);

            vehiculoDto = mapper.Map<VehiculoDto>(vehiculo);
            var response = new ApiResponse<VehiculoDto>(vehiculoDto);
            return Ok(response);
        }

        /// <summary>
        /// Actualizar vehiculo por Id
        /// </summary>
        [HttpPut]
        public async Task<IActionResult> UpdateEntity(int id, VehiculoDto vehiculoDto)
        {
            var vehiculo = mapper.Map<Vehiculo>(vehiculoDto);
            vehiculo.Id = id;

            var result = await vehiculoService.UpdateVehiculo(vehiculo);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        /// <summary>
        /// Eliminar vehiculo por Id
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            var result = await vehiculoService.DeleteVehiculo(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }
    }
}
