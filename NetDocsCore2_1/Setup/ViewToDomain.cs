using AutoMapper;
using MyBI.Domain1.Entities;

public class ViewToDomain : Profile
    {
        public ViewToDomain()
        {
            CreateMap<Empresa, SupplierVM>();
        }
    }