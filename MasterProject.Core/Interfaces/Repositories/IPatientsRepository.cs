namespace MasterProject.Core.Interfaces.Repositories
{
    using Dto;
    using Models;

    public interface IPatientsRepository
    {
        int AddPatient(PatientDto patient);
        DataTablesObject<PatientDto> GetPatientList(SearchFilters searchFilters);
        Patients GetPatient(int id);
        bool EditPatient(PatientDto patient);
        void AddNote(string content, int patientId, string userId);
        System.Collections.Generic.List<PatientNotesDto> GetPatientNotes(int id);
    }
}
