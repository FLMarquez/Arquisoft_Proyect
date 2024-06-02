using Cervantes.Arquisoft.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cervantes.Arquisoft.Data.Seeds
{
    public class ServiceTypeSeed : IEntityTypeConfiguration<ServiceType>
    {
        public void Configure(EntityTypeBuilder<ServiceType> builder)
        {
            builder.HasData(
                new ServiceType { ServiceTypeId = 1, ServiceTypeName = "Proyecto con detalle", ServiceTypeDescription = "Se trabajará en el completamiento del anteproyecto, desarrollando el material necesario para la ejecución en obra." },
                new ServiceType { ServiceTypeId = 2, ServiceTypeName = "Conducción Técnica", ServiceTypeDescription = "Control de obra Planificación de obra (secuencia lógica de ejecución de cada actividad o rubro) Programación de obra (Estimación de tiempo para ejecutar cada actividad y rendimiento)" },
                new ServiceType { ServiceTypeId = 3, ServiceTypeName = "Anteproyecto", ServiceTypeDescription = "Se trabajará con la IDEA DE PROYECTO, atendiendo a la situación particular del cliente según la información brindada por el mismo (necesidades, deseos, recursos disponibles, lote, orientaciones, implantación, programa, usuario) Se escucha del cliente, se capta y procesa la información, estudian y analizan todas estas variables, brindando asesoramiento profesional y personalizado, determinando las mejores alernativas para llevar a cabo el encargo, según cada caso en particular." },
                new ServiceType { ServiceTypeId = 4, ServiceTypeName = "Proyecto sin detalle", ServiceTypeDescription = "Se trabajará con la ." },
                new ServiceType { ServiceTypeId = 5, ServiceTypeName = "Proyecto y Ejecucion", ServiceTypeDescription = "Se trabajará con la " }
            );
        }
    }
}