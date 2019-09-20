using System.Linq;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using GHMS.DataModel.Data;
using GHMS.DataModel.Models.Common;
using GHMS.Repository.Abstract;
using System.Threading.Tasks;

namespace GHMS.Repository.Concrete
{
    public class HospitalRepository : IHospitalRepository
    {
        private readonly GHMSDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public HospitalRepository(GHMSDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<bool>  CheckHospitalCode(string HostitalCode)
        {
            return await _context.Hospitals.AnyAsync(a=>a.Code== HostitalCode);
        }
       
    }
}