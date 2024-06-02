using global::Cervantes.Arquisoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cervantes.Arquisoft.Data.Seeds
{
    public class AssignmentSeed : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasData(
              new Assignment
              {
                  AssignmentId = 1,
                  ProjectId = 1,
                  AssignmentTypeId = 1,
                  AssignmentName = "Tarea 1 de Anteproyecto",
                  AssignmentDescription = "Descripción de la tarea 1 de Anteproyecto",
                  IsCompleted = false,
                  NotVisible = true,
                  IsStarted = false,
                  IsSkipped = false
              },
              new Assignment
              {
                  AssignmentId = 2,
                  ProjectId = 1,
                  AssignmentTypeId = 2,
                  AssignmentName = "Tarea 2 de Anteproyecto",
                  AssignmentDescription = "Descripción de la tarea 2 de Anteproyecto",
                  IsCompleted = false,
                  NotVisible = true,
                  IsStarted = false,
                  IsSkipped = false

              },
              new Assignment
              {
                  AssignmentId = 3,
                  ProjectId = 2,
                  AssignmentTypeId = 6,
                  AssignmentName = "Tarea 1 de Proyecto Sin Detalle",
                  AssignmentDescription = "Descripción de la tarea 1 de Proyecto Sin Detalle",
                  IsCompleted = false,
                  NotVisible = true,
                  IsStarted = false,
                  IsSkipped = false

              },
              new Assignment
              {
                  AssignmentId = 4,
                  ProjectId = 2,
                  AssignmentTypeId = 7,
                  AssignmentName = "Tarea 2 de Proyecto Sin Detalle",
                  AssignmentDescription = "Descripción de la tarea 2 de Proyecto Sin Detalle",
                  IsCompleted = false,
                  NotVisible = true,
                  IsStarted = false,
                  IsSkipped = false
              },
              // Agregar Assignment para "Proyecto Con Detalle"
              new Assignment
              {
                  AssignmentId = 5,
                  ProjectId = 3,
                  AssignmentTypeId = 11,
                  AssignmentName = "Tarea 1 de Proyecto Con Detalle",
                  AssignmentDescription = "Descripción de la tarea 1 de Proyecto Con Detalle",
                  IsCompleted = false,
                  NotVisible = true,
                  IsStarted = false,
                  IsSkipped = false

              },
              new Assignment
              {
                  AssignmentId = 6,
                  ProjectId = 3,
                  AssignmentTypeId = 12,
                  AssignmentName = "Tarea 2 de Proyecto Con Detalle",
                  AssignmentDescription = "Descripción de la tarea 2 de Proyecto Con Detalle",
                  IsCompleted = false,
                  NotVisible = true,
                  IsStarted = false,
                  IsSkipped = false
              },
              // Agregar Assignment para "Ejecución"
              new Assignment
              {
                  AssignmentId = 7,
                  ProjectId = 4,
                  AssignmentTypeId = 16,
                  AssignmentName = "Tarea 1 de Ejecución",
                  AssignmentDescription = "Descripción de la tarea 1 de Ejecución",
                  IsCompleted = false,
                  NotVisible = true,
                  IsStarted = false,
                  IsSkipped = false
              },
              new Assignment
              {
                  AssignmentId = 8,
                  ProjectId = 4,
                  AssignmentTypeId = 17,
                  AssignmentName = "Tarea 2 de Ejecución",
                  AssignmentDescription = "Descripción de la tarea 2 de Ejecución",
                  IsCompleted = false,
                  NotVisible = true,
                  IsStarted = false,
                  IsSkipped = false
              },
              // Agregar Assignment para "Obra"
              new Assignment
              {
                  AssignmentId = 9,
                  ProjectId = 5,
                  AssignmentTypeId = 21,
                  AssignmentName = "Tarea 1 de Obra",
                  AssignmentDescription = "Descripción de la tarea 1 de Obra",
                  IsCompleted = false,
                  NotVisible = true,
                  IsStarted = false,
                  IsSkipped = false
              },
              new Assignment
              {
                  AssignmentId = 10,
                  ProjectId = 5,
                  AssignmentTypeId = 1,
                  AssignmentName = "Tarea 2 de Obra",
                  AssignmentDescription = "Descripción de la tarea 2 de Obra",
                  IsCompleted = false,
                  NotVisible = true,
                  IsStarted = false,
                  IsSkipped = false
              }
          // Agregar más Assignment aquí...
          );
        }
    }
}