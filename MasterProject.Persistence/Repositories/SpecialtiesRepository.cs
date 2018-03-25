namespace MasterProject.Persistence.Repositories
{
    using Core;
    using Core.Interfaces.Repositories;
    using Core.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class SpecialtiesRepository : ISpecialtiesRepository
    {
        private readonly IHospitalContext _context;

        public SpecialtiesRepository(IHospitalContext context)
        {
            _context = context;
        }

        public List<Specialties> GetSpecialtyList()
        {
            return _context.Specialties.ToList();
        }
    }
}
