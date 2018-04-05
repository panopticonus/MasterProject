namespace MasterProject.Core.Interfaces.Repositories
{
    using Dto;

    public interface IPatientsRepository
    {
        int AddPatient(PatientDto patient);
    }
}
