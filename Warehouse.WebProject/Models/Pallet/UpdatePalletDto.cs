using AutoMapper;
using Warehouse.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;
using Warehouse.Application.Pallets.Commands.UpdatePallet;
using Warehouse.Application.Pallets.Queries.GetPalletDetails;


namespace Warehouse.WebProject.Models.Pallet
{
    public class UpdatePalletDto : IMapWith<UpdatePalletCommand>, IMapWith<PalletDetailsVm>
    {
        public Guid ID { get; set; }
        [Required(ErrorMessage = "Укажите ширину паллета")]
        public double width { get; set; }
        [Required(ErrorMessage = "Укажите высоту паллета")]
        public double height { get; set; }
        [Required(ErrorMessage = "Укажите длину паллета")]
        public double depth { get; set; }
        public double weight { get; set; }
        [DataType(DataType.Date)]
        public DateTime expiration_date { get; set; }
        public List<string>? Boxes { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdatePalletDto, UpdatePalletCommand>()
                .ForMember(palletVm => palletVm.ID,
                opt => opt.MapFrom(pallet => pallet.ID))
                .ForMember(palletVm => palletVm.width,
                opt => opt.MapFrom(pallet => pallet.width))
                .ForMember(palletVm => palletVm.height,
                opt => opt.MapFrom(pallet => pallet.height))
                 .ForMember(palletVm => palletVm.depth,
                opt => opt.MapFrom(pallet => pallet.depth));

            profile.CreateMap<PalletDetailsVm, UpdatePalletDto>()
               .ForMember(palletVm => palletVm.ID,
               opt => opt.MapFrom(pallet => pallet.ID))
               .ForMember(palletVm => palletVm.width,
               opt => opt.MapFrom(pallet => pallet.width))
               .ForMember(palletVm => palletVm.height,
               opt => opt.MapFrom(pallet => pallet.height))
                .ForMember(palletVm => palletVm.depth,
               opt => opt.MapFrom(pallet => pallet.depth))
                 .ForMember(palletVm => palletVm.weight,
               opt => opt.MapFrom(pallet => pallet.weight))
                  .ForMember(palletVm => palletVm.expiration_date,
               opt => opt.MapFrom(pallet => pallet.expiration_date));                
        }
    }
}
