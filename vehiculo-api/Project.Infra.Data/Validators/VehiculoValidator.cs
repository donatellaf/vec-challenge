using Project.Domain.Dtos;
using FluentValidation;

namespace Project.Infra.Data.Validators
{
    class VehiculoValidator : AbstractValidator<VehiculoDto>
    {
        public VehiculoValidator()
        {
            RuleFor(vehiculo => vehiculo.NumeroPatente)
                .NotNull()
                .WithMessage("Patente no puede ser nula");

            RuleFor(vehiculo => vehiculo.NumeroChasis)
                .NotNull()
                .WithMessage("Chasis no puede ser nulo");

            RuleFor(vehiculo => vehiculo.ModeloName)
                .NotNull()
                .WithMessage("Modelo no puede ser nulo");

            RuleFor(vehiculo => vehiculo.IdMarca)
                .NotNull()
                .WithMessage("Marca no puede ser nula");

            RuleFor(vehiculo => vehiculo.IdTipoVehiculo)
                .NotNull()
                .WithMessage("Tipo Vehiculo no puede ser nulo");

            RuleFor(vehiculo => vehiculo.IdCombustible)
                .NotNull()
                .WithMessage("Combustible no puede ser nulo");

            RuleFor(vehiculo => vehiculo.IdTransmision)
                 .NotNull()
                 .WithMessage("Transmision no puede ser nulo");
        }
    }
}
