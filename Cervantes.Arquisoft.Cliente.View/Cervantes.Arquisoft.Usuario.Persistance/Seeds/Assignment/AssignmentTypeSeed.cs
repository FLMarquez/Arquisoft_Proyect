using Cervantes.Arquisoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Cervantes.Arquisoft.Data.Seeds
{
    public class AssignmentTypeSeed : IEntityTypeConfiguration<AssignmentType>
    {
        public void Configure(EntityTypeBuilder<AssignmentType> builder)
        {
            builder.HasData(
           new AssignmentType { AssignmentTypeId = 1, AssignmentTypeName = "Elaboración de Planos", AssignmentTypeDescription = "Elaboración de planos para Anteproyecto", ServiceTypeId = 1, Order = 1 },
           new AssignmentType { AssignmentTypeId = 2, AssignmentTypeName = "Presentación de Documentación", AssignmentTypeDescription = "Presentación de documentación para Anteproyecto", ServiceTypeId = 1, Order = 2 },
           new AssignmentType { AssignmentTypeId = 3, AssignmentTypeName = "Revisión de Costos", AssignmentTypeDescription = "Revisión de costos para Anteproyecto", ServiceTypeId = 1, Order = 3 },
           new AssignmentType { AssignmentTypeId = 4, AssignmentTypeName = "Diseño Conceptual", AssignmentTypeDescription = "Diseño conceptual para Anteproyecto", ServiceTypeId = 1, Order = 4 },
           new AssignmentType { AssignmentTypeId = 5, AssignmentTypeName = "Evaluación Ambiental", AssignmentTypeDescription = "Evaluación ambiental para Anteproyecto", ServiceTypeId = 1, Order = 5 },
           new AssignmentType { AssignmentTypeId = 6, AssignmentTypeName = "Planificación de Recursos", AssignmentTypeDescription = "Planificación de recursos para Proyecto Sin Detalle", ServiceTypeId = 2, Order = 1 },
           new AssignmentType { AssignmentTypeId = 7, AssignmentTypeName = "Diseño Preliminar", AssignmentTypeDescription = "Diseño preliminar para Proyecto Sin Detalle", ServiceTypeId = 2, Order = 2 },
           new AssignmentType { AssignmentTypeId = 8, AssignmentTypeName = "Adquisición de Materiales", AssignmentTypeDescription = "Adquisición de materiales para Proyecto Sin Detalle", ServiceTypeId = 2, Order = 3 },
           new AssignmentType { AssignmentTypeId = 9, AssignmentTypeName = "Supervisión de Construcción", AssignmentTypeDescription = "Supervisión de construcción para Proyecto Sin Detalle", ServiceTypeId = 2, Order = 4 },
           new AssignmentType { AssignmentTypeId = 10, AssignmentTypeName = "Control de Calidad", AssignmentTypeDescription = "Control de calidad para Proyecto Sin Detalle", ServiceTypeId = 2, Order = 5 },
           new AssignmentType { AssignmentTypeId = 11, AssignmentTypeName = "Diseño Detallado", AssignmentTypeDescription = "Diseño detallado para Proyecto Con Detalle", ServiceTypeId = 3, Order = 1 },
           new AssignmentType { AssignmentTypeId = 12, AssignmentTypeName = "Planificación de Recursos", AssignmentTypeDescription = "Planificación de recursos para Proyecto Con Detalle", ServiceTypeId = 3, Order = 2 },
           new AssignmentType { AssignmentTypeId = 13, AssignmentTypeName = "Adquisición de Materiales", AssignmentTypeDescription = "Adquisición de materiales para Proyecto Con Detalle", ServiceTypeId = 3, Order = 3 },
           new AssignmentType { AssignmentTypeId = 14, AssignmentTypeName = "Supervisión de Construcción", AssignmentTypeDescription = "Supervisión de construcción para Proyecto Con Detalle", ServiceTypeId = 3, Order = 4 },
           new AssignmentType { AssignmentTypeId = 15, AssignmentTypeName = "Control de Calidad", AssignmentTypeDescription = "Control de calidad para Proyecto Con Detalle", ServiceTypeId = 3, Order = 5 },
           new AssignmentType { AssignmentTypeId = 16, AssignmentTypeName = "Planificación de Ejecución", AssignmentTypeDescription = "Planificación de ejecución para Ejecución", ServiceTypeId = 4, Order = 1 },
           new AssignmentType { AssignmentTypeId = 17, AssignmentTypeName = "Adquisición de Recursos", AssignmentTypeDescription = "Adquisición de recursos para Ejecución", ServiceTypeId = 4, Order = 2 },
           new AssignmentType { AssignmentTypeId = 18, AssignmentTypeName = "Ejecución de Trabajos", AssignmentTypeDescription = "Ejecución de trabajos para Ejecución", ServiceTypeId = 4, Order = 3 },
           new AssignmentType { AssignmentTypeId = 19, AssignmentTypeName = "Seguimiento de Progreso", AssignmentTypeDescription = "Seguimiento de progreso para Ejecución", ServiceTypeId = 4, Order = 4 },
           new AssignmentType { AssignmentTypeId = 20, AssignmentTypeName = "Control de Calidad", AssignmentTypeDescription = "Control de calidad para Ejecución", ServiceTypeId = 4, Order = 5 },
           new AssignmentType { AssignmentTypeId = 21, AssignmentTypeName = "Planificación de Obra", AssignmentTypeDescription = "Planificación de obra para Obra", ServiceTypeId = 5, Order = 1 },
           new AssignmentType { AssignmentTypeId = 22, AssignmentTypeName = "Adquisición de Materiales", AssignmentTypeDescription = "Adquisición de materiales para Obra", ServiceTypeId = 5, Order = 2 },
           new AssignmentType { AssignmentTypeId = 23, AssignmentTypeName = "Construcción de Infraestructura", AssignmentTypeDescription = "Construcción de infraestructura para Obra", ServiceTypeId = 5, Order = 3 },
           new AssignmentType { AssignmentTypeId = 24, AssignmentTypeName = "Supervisión de Construcción", AssignmentTypeDescription = "Supervisión de construcción para Obra", ServiceTypeId = 5, Order = 4 },
           new AssignmentType { AssignmentTypeId = 25, AssignmentTypeName = "Entrega y Puesta en Marcha", AssignmentTypeDescription = "Entrega y puesta en marcha para Obra", ServiceTypeId = 5, Order = 5 }
       );
        }
    }
}