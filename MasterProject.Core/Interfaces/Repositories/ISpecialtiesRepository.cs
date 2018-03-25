namespace MasterProject.Core.Interfaces.Repositories
{
    using Models;
    using System.Collections.Generic;

    public interface ISpecialtiesRepository
    {
        List<Specialties> GetSpecialtyList();
    }
}
