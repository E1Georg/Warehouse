using AutoMapper;
using Warehouse.Application.Common.Mappings;
using Warehouse.Domain;


namespace Warehouse.Application.Boxes.Queries.GetBoxList
{
    public class BoxLookupDto : IMapWith<Box>
    {
        public Guid ID { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }
        public double weight { get; set; }
        public DateTime expiration_date { get; set; }
        public DateTime production_date { get; set; }
        public Guid PalletID { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Box, BoxLookupDto>()
                .ForMember(boxVm => boxVm.ID,
                opt => opt.MapFrom(box => box.ID))
                .ForMember(boxVm => boxVm.width,
                opt => opt.MapFrom(box => box.width))
                .ForMember(boxVm => boxVm.height,
                opt => opt.MapFrom(box => box.height))
                 .ForMember(boxVm => boxVm.depth,
                opt => opt.MapFrom(box => box.depth))
                  .ForMember(boxVm => boxVm.weight,
                opt => opt.MapFrom(box => box.weight))
                   .ForMember(boxVm => boxVm.expiration_date,
                opt => opt.MapFrom(box => box.expiration_date))
                .ForMember(boxVm => boxVm.production_date,
                opt => opt.MapFrom(box => box.production_date))
                 .ForMember(boxVm => boxVm.PalletID,
                opt => opt.MapFrom(box => box.PalletID));
        }
    }
}
