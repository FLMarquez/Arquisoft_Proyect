using Cervantes.Arquisoft.Data.Repositories;
using Cervantes.Arquisoft.Data.Repositories.Assignment;
using Cervantes.Arquisoft.Data.Repositories.Project;

namespace Cervantes.Arquisoft.View.Services
{

    public class HandleProjectState
    {
        private readonly IAssignmentRepository assignmentRepository;
        private readonly IProjectRepository projectRepository;
        private readonly IHistoricalProjectRepository historicalProjectRepository;


        public HandleProjectState(IProjectRepository projectRepository, IAssignmentRepository assignmentRepository, IHistoricalProjectRepository historicalProjectRepository)
        {
            this.projectRepository = projectRepository;
            this.assignmentRepository = assignmentRepository;
            this.historicalProjectRepository = historicalProjectRepository;
        }
        #region Activo

        // En el create
        public async Task HandleProjectActive(int projectId)
        {

            var project = await projectRepository.GetById(projectId);
            project.ProjectStateId = 1;
            await projectRepository.Update(project);
            await historicalProjectRepository.InsertHistorical(project);
        }
        #endregion

        #region Inactivo
        public async Task HandleProjectInactive(int projectId)
        {
            var project = await projectRepository.GetById(projectId);
            if (project.ProjectStateId != 2)
            {
                project.ProjectStateId = 2;
                await projectRepository.Update(project);
                await historicalProjectRepository.InsertHistorical(project);
            }



        }

        #endregion

        #region Iniciado
        public async Task HandleProjectStarted(int projectId)
        {
            var project = await projectRepository.GetById(projectId);
            if (project.ProjectStateId != 3)
            {
                project.ProjectStateId = 3;
                await projectRepository.Update(project);
                await historicalProjectRepository.InsertHistorical(project);
            }
        }
        #endregion

        #region Complete
        public async Task HandleProjectCompletion(int projectId)
        {
            var assignments = await assignmentRepository.GetAllByProjectId(projectId);
            bool anyCompletedOrOmitted = assignments.Any(a => a.IsCompleted || a.IsSkipped);

            var project = await projectRepository.GetById(projectId);
            if (anyCompletedOrOmitted && project.ProjectStateId != 4)
            {
                project.ProjectStateId = 4;
                await projectRepository.Update(project);
                await historicalProjectRepository.InsertHistorical(project);
            }
        }
        #endregion

        #region En Espera
        public async Task HandleProjectOnWait(int projectId)
        {
            var project = await projectRepository.GetById(projectId);
            if (project.ProjectStateId != 2)
            {
                project.ProjectStateId = 5;
                await projectRepository.Update(project);
            }
        }
        #endregion
    }
}
