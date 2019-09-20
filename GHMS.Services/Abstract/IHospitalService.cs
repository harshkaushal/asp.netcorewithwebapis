using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHMS.Service.Abstract
{
    public interface IHospitalService
    {
          Task<bool> CheckHospitalCode(string HostitalCode);
    }
}