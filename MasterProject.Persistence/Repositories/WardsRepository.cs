namespace MasterProject.Persistence.Repositories
{
    using Core;
    using Core.Interfaces.Repositories;
    using Core.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class WardsRepository : IWardsRepository
    {
        private readonly IHospitalContext _context;

        public WardsRepository(IHospitalContext context)
        {
            _context = context;
        }

        public List<Wards> GetWardList()
        {
            return _context.Wards.ToList();
        }
    }
}
