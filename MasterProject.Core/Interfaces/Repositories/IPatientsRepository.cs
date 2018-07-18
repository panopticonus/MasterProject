namespace MasterProject.Core.Interfaces.Repositories
{
    using Dto;
    using Models;
    using System.Collections.Generic;

    public interface IPatientsRepository
    {
        int AddPatient(PatientDto patient);
        DataTablesObject<PatientDto> GetPatientList(SearchFilters searchFilters);
        Patients GetPatient(int id);
        bool EditPatient(PatientDto patient, string userId);
        void AddNote(string content, int patientId, string userId);
        List<PatientNotesDto> GetPatientNotes(int id);
        void AddDocument(string fileName, int patientId, string userId);
    }
}
