using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHMS.Repository.Abstract
{
    public interface IHospitalRepository
    {
          Task<bool> CheckHospitalCode(string HostitalCode);
    }
}