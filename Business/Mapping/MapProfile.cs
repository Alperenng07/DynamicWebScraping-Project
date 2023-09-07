using AutoMapper;
using Entities.DTOs;
using Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Mapping
{
    public class MapProfile : Profile {
        public MapProfile()

        {    // burda currency ile entity baðladýk
             //CreateMap<Product, ProductForListDto>().ForMember(dest => dest.Price,
             //    opt => opt.MapFrom(src => $"{src.Price} {src.Currency}"));







            //DTO ENTİTY BAĞLAMA
            CreateMap<User, UserForCreateDto>().ReverseMap();
            CreateMap<User, UserForGetDto>().ReverseMap();
            

        }
    }  
   
}
