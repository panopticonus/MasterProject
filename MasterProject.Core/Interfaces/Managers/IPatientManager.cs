using System.Collections.Generic;
using MasterProject.Core.Dto;
using MasterProject.Core.Models;

namespace MasterProject.Core.Interfaces.Managers
{
    public interface IPatientManager
    {
        List<PatientDocumentsDto> GetPatientDocuments(List<PatientDocuments> patientDocuments);
    }
}
