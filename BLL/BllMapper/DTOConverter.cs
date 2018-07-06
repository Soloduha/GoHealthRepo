using AutoMapper;
using BLL.DTO;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.BllMapper
{
    public static class DTOConverter
    {
        public static void Convert<T,T1>(T source, out T1 destination)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<T,T1>()).CreateMapper();
            destination=mapper.Map<T, T1>(source);
        }
    }
}
