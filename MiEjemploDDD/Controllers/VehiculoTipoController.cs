
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json.Serialization;
using MiEjemploDDD.Domain;
using MiEjemploDDD.Infrastructure.Persistence;
using MiEjemploDDD.Infrastructure.Repositories;


namespace EjemploDDD.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class VehiculoTipoController : ControllerBase
    {
        MiEjemploDDDDbContext _context;
        RepositoryBase<VehiculoTipo> _repository;
        //Serilog.ILogger _logger;

        public VehiculoTipoController(MiEjemploDDDDbContext context)
        {
            _context = context;
            _repository = new RepositoryBase<VehiculoTipo>(context);            
        }


        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyList<VehiculoTipo>), (int)HttpStatusCode.OK)]
        public async Task<IReadOnlyList<VehiculoTipo>> Get()
        {
            //_logger.Information("listando todos los VehiculoTipo");
            return await _repository.GetAllAsync();
        }

        [HttpGet("id/{id}", Order = 0)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<VehiculoTipo> GetById(int id)
        {
            //_logger.Information("buscando VehiculoTipo por Id: " + id.ToString());
            var resul = await _repository.GetByIdAsync(id);
            //if (resul == null)
                //_logger.Warning("VehiculoTipo no encontrado por Id {id} ", id);
            return resul;
        }

        [HttpGet("tipo/{tipo}", Order = 1)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IReadOnlyList<VehiculoTipo>> GetByTipo(string tipo)
        {
            //_logger.Information("buscando VehiculoTipo por tipo: " + tipo);
            var resul = await _repository.GetAsync(u => u.Tipo == tipo);
            //if (resul.Count == 0)
            //    _logger.Warning("VehiculoTipo no encontrado por Tipo {tipo} ", tipo);
            return resul;
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.OK)]

        public async Task<VehiculoTipo> Add(VehiculoTipo entity)
        {
            //_logger.Information("creando {@entity}", entity);
            return await _repository.AddAsync(entity);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<VehiculoTipo> Update(VehiculoTipo entity)
        {
            //_logger.Information("actualizando {@entity}", entity);
            return await _repository.UpdateAsync(entity);

        }

    }
}
