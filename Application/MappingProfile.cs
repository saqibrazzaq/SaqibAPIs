using Application.Country.Create;
using Application.Country.Update;
using Application.Models.Country;
using Application.Models.Dropdown;
using Application.Models.Paging;
using Application.Models.Person;
using Application.Models.State;
using Application.Person.Create;
using Application.Person.Update;
using Application.State.Create;
using Application.State.Update;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      // PagedResponse<>
      CreateMap(typeof(PagedResponse<>), typeof(PagedResponseDto<>));

      // Country
      CreateMap<Domain.Entities.Country, CountrySearchRes>();
      CreateMap<Domain.Entities.Country, CountryRes>();
      CreateMap<CountryCreateParams, Domain.Entities.Country>();
      CreateMap<CountryUpdateParams, Domain.Entities.Country>();

      // State
      CreateMap<Domain.Entities.State, StateSearchRes>();
      CreateMap<Domain.Entities.State, StateRes>();
      CreateMap<StateCreateParams, Domain.Entities.State>();
      CreateMap<StateUpdateParams, Domain.Entities.State>();

      // Person
      CreateMap<Domain.Entities.Person, PersonSearchRes>();
      CreateMap<Domain.Entities.Person, PersonRes>();
      CreateMap<PersonCreateParams, Domain.Entities.Person>();
      CreateMap<PersonUpdateParams, Domain.Entities.Person>();

      // Dropdowns
      CreateMap<Domain.Entities.State, DropdownRes>()
        .ForMember(d => d.Value, opt => opt.MapFrom(src => src.Id))
        .ForMember(d => d.Label, opt => opt.MapFrom(src => src.Name + ", " + src.Country.Name));
      CreateMap<Domain.Entities.Country, DropdownRes>()
        .ForMember(d => d.Value, opt => opt.MapFrom(src => src.Id))
        .ForMember(d => d.Label, opt => opt.MapFrom(src => src.Name));
    }
  }
}
