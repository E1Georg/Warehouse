using AutoMapper;
using Warehouse.Application.Common.Mappings;
using Warehouse.Application.Boxes.Commands.UpdateBox;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Warehouse.Application.Boxes.Queries.GetBoxDetails;
using Warehouse.Application.Pallets.Queries.GetPalletDetails;

namespace Warehouse.WebProject.Models.Box
{
    public class UpdateBoxDto : IMapWith<UpdateBoxCommand>, IMapWith<BoxDetailsVm>
    {
        public Guid ID { get; set; }
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

        public Guid PalletID { get; set; }
        public string PalletID_string { get; set; }
        public List<SelectListItem>? Pallets { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBoxDto, UpdateBoxCommand>()
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
                opt => opt.MapFrom(box => box.production_date));

            profile.CreateMap<BoxDetailsVm, UpdateBoxDto>()
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
                    .ForMember(boxVm => boxVm.PalletID,
                opt => opt.MapFrom(box => box.PalletID))
                .ForMember(boxVm => boxVm.production_date,
                opt => opt.MapFrom(box => box.production_date));
        }
    }
}
