namespace Cervantes.Arquisoft.Application.DTOs
{
    public class ClientDashboardDTO
    {
        public ClientDto Client { get; set; }

        public IEnumerable<ProjectDto> ProjectList { get; set; }
        public IEnumerable<AssignmentDTO> AssignmentList { get; set; }
        public IEnumerable<HubDto> HubList { get; set; }

    }
}

