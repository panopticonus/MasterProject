namespace MasterProject.Manager
{
    using Core.Dto;
    using Core.Interfaces.Managers;
    using Core.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class PatientManager : IPatientManager
    {
        public List<PatientDocumentsDto> GetPatientDocuments(List<PatientDocuments> patientDocuments)
        {
            var path = $"~/App_Data/PatientDocuments/{patientDocuments.First().PatientId}/";

            var patientDocumentsDto = (from document in patientDocuments
                                       select new PatientDocumentsDto
                                       {
                                           AdditionDateTime = document.AdditionDateTime,
                                           Path = path + document.FileName,
                                           FileName = document.FileName
                                       }).ToList();

            return patientDocumentsDto;
        }
    }
}
