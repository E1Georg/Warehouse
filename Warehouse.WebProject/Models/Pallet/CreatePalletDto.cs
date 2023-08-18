using AutoMapper;
using Warehouse.Application.Common.Mappings;
using Warehouse.Application.Pallets.Commands.CreatePallet;
using System.ComponentModel.DataAnnotations;


namespace Warehouse.WebProject.Models.Pallet
{
    public class CreatePalletDto : IMapWith<CreatePalletCommand>
    {
        [Required(ErrorMessage = "Укажите ширину паллета")]
        public double width { get; set; }
        [Required(ErrorMessage = "Укажите высоту паллета")]
        public double height { get; set; }
        [Required(ErrorMessage = "Укажите длину паллета")]
        public double depth { get; set; }
        public double weight = 30;
        public DateTime expiration_date = DateTime.MinValue;      

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePalletDto, CreatePalletCommand>()   
                .ForMember(boxVm => boxVm.width,
                opt => opt.MapFrom(box => box.width))
                .ForMember(boxVm => boxVm.height,
                opt => opt.MapFrom(box => box.height))
                 .ForMember(boxVm => boxVm.depth,
                opt => opt.MapFrom(box => box.depth))
                   .ForMember(boxVm => boxVm.weight,
                opt => opt.MapFrom(box => box.weight))
                     .ForMember(boxVm => boxVm.expiration_date,
                opt => opt.MapFrom(box => box.expiration_date));
        }
    }
}
