using AutoMapper;
using Warehouse.Application.Common.Mappings;
using Warehouse.Domain;


namespace Warehouse.Application.Pallets.Queries.GetPalletDetails
{
    public class PalletDetailsVm : IMapWith<Pallet>
    {
        public Guid ID { get; set; }
        public double width { get; set; }
        public double height { get; set; }
        public double depth { get; set; }
        public double weight { get; set; }
        public DateTime expiration_date { get; set; }
        public List<Box>? Boxes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Pallet, PalletDetailsVm>()
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
                  .ForMember(boxVm => boxVm.Boxes,
                opt => opt.MapFrom(box => box.Boxes));
        }
    }
}
