using AutoMapper;
using MyBI.Domain1.Entities;

public class DomainToView : Profile
    {
        public DomainToView()
        {
            CreateMap<SupplierVM, Empresa>();
        }
    }