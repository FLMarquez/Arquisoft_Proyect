using Cervantes.Arquisoft.Application.DTOs;

namespace Cervantes.Arquisoft.View.Models
{
    public class DashboardClientViewModel
    {
        public ClientDto Client { get; set; }
        public IEnumerable<ProjectDto> ProjectList { get; set; }
        public IEnumerable<AssignmentDTO> AssignmentList { get; set; }
        public IEnumerable<HubDto> HubList { get; set; }
        public int SelectedProjectId { get; set; }
        public int SelectedAssigmentId { get; set; }
    }
}
