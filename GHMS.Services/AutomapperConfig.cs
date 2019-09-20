using AutoMapper;
using AutoMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
 

namespace GHMS.Services
{
    public class AutomapperConfig
    {
        public static void Configure()
        {

            MapperConfigurationExpression cfg = new MapperConfigurationExpression();

            
            //cfg.CreateMap<VerifyRequestsVm, VerifyRequests>().ReverseMap();
            //cfg.CreateMap<VerifyRequestsVm, VerifyRequestEmail>()
            //    .ForMember(dto => dto.SentTo, map =>
            //        map.MapFrom(a => a.Email)
            //    );
 
            Mapper.Reset();
            Mapper.Initialize(cfg);
            //Mapper.Initialize(cfgs => {
            //    cfgs.AllowNullCollections = true;
            //    //cfgs.CreateMap<Source, Destination>();
            //});
        }

    }
}
