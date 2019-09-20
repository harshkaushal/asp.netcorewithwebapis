using System.Collections.Generic;
using System.Threading.Tasks;
using GHMS.DataModel.Models.Common;
using GHMS.Repository.Abstract;
using GHMS.Service.Abstract;
using Microsoft.AspNetCore.Identity;


namespace GHMS.Service.Concrete
{
    public class HospitalService : IHospitalService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IHospitalRepository _hospitalRepository;

        public HospitalService(
            IHospitalRepository hospitalRepository
            , UserManager<ApplicationUser> userManager
        )
        {
            _userManager = userManager;
            _hospitalRepository = hospitalRepository;
        }

        public async Task<bool> CheckHospitalCode(string HostitalCode)
        {
            return await _hospitalRepository.CheckHospitalCode(HostitalCode);
        }
    }
}