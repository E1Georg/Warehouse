using AutoMapper;
using Warehouse.Application.Common.Mappings;
using Warehouse.Application.Boxes.Commands.CreateBox;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Warehouse.Application.Pallets.Commands.ChangePalletWeigthAndExpirationDate;


namespace Warehouse.WebProject.Models.Box
{
    public class CreateBoxDto : IMapWith<CreateBoxCommand>, IMapWith<ChangePalletCommand>
    {
        [Required(ErrorMessage = "Укажите ширину коробки")]
        public double width { get; set; }
        [Required(ErrorMessage = "Укажите высоту коробки")]
        public double height { get; set; }
        [Required(ErrorMessage = "Укажите длину коробки")]
        public double depth { get; set; }
        [Required(ErrorMessage = "Укажите массу коробки")]
        public double weight { get; set; }
        [DataType(DataType.Date)]
        public DateTime expiration_date { get; set; }
        [DataType(DataType.Date)]
        public DateTime production_date { get; set; }

       
        public string PalletID_string { get; set; }
        public List<SelectListItem>? Pallets { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBoxDto, CreateBoxCommand>()               
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
                opt => opt.MapFrom(box => box.production_date));

            profile.CreateMap<CreateBoxDto, ChangePalletCommand>()               
                .ForMember(boxVm => boxVm.expiration_date,
               opt => opt.MapFrom(pallet => pallet.expiration_date))
                 .ForMember(boxVm => boxVm.weight,
               opt => opt.MapFrom(pallet => pallet.weight));
        }
    }
}
