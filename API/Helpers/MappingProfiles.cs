using API.Core.DbModels;
using API.Dtos;
using AutoMapper;

namespace API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
            ///Farklı tipler ve isimlerdeki fieldları maplemek için kullanılır. 
            ///For seçer map from seçileni yine seçilen alandakine eşler.
           .ForMember(x => x.ProdutBrand,
              o => o
           .MapFrom(s => s.ProdutBrand.Name))

           .ForMember(x => x.ProdutType,
              o => o
           .MapFrom(s => s.ProdutType.Name))

           .ForMember(x => x.PictureUrl,
              o => o
           .MapFrom<ProductUrlResolver>());
        }
    }
}
