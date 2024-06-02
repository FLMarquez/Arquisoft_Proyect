namespace Cervantes.Arquisoft.Application.DTOs
{
    public class ProjectWithDetailDTO
    {
        //TODO: Estos dtos deberian estar separados sobre todo por que al estar modificados se deben requerir mas.
        //TODO: No se si este se esta usando.
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }

        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientLastName { get; set; }
        public int ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; }
        public int ProjectStateId { get; set; }

        public string Description { get; set; }





    }
}
