using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Boxes.Queries.GetBoxDetails;
using Warehouse.Application.Boxes.Queries.GetBoxList;
using Warehouse.Application.Boxes.Commands.CreateBox;
using Warehouse.Application.Boxes.Commands.UpdateBox;
using Warehouse.Application.Boxes.Commands.DeleteBox;
using Warehouse.WebProject.Models.Box;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Warehouse.Application.Pallets.Queries.GetPalletList;
using Warehouse.Application.Pallets.Commands.ChangePalletWeigthAndExpirationDate;
using Warehouse.Application.Pallets.Commands.UpdatePallet;
using Warehouse.Application.Pallets.Queries.GetPalletDetails;
using Warehouse.WebProject.Models.Pallet;
using Warehouse.Application.Pallets.Commands.DeletePallet;

namespace Warehouse.WebProject.Controllers
{
    [Route("api/{controller}/{action}")]
    public class BoxController : BaseController
    {
        private readonly IMapper _mapper;
        public BoxController(IMapper mapper) => _mapper = mapper;

        public async Task<IActionResult> Index()
        {
            var query = new GetBoxListQuery { };
            var vm = await Mediator.Send(query);
            return View(vm.Boxes.ToList());
        }

        public async Task<IActionResult> Create()
        {
            var query = new GetPalletListQuery { };
            var vm = await Mediator.Send(query);

            var result = new CreateBoxDto();
            result.Pallets = vm.Pallets
                .Select(e => new SelectListItem {
                    Value = e.ID.ToString(),
                    Text = e.depth.ToString() + " x " +
                        e.width.ToString() + " x " +
                        e.height.ToString()
                }).ToList();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateBoxDto createBoxDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CreateBoxCommand>(createBoxDto);
                command.ID = Id;

                if (createBoxDto.expiration_date == DateTime.MinValue && createBoxDto.production_date == DateTime.MinValue)
                {
                    ModelState.AddModelError("", "Укажите дату изготовления и/или срок годности");                    
                    return View(createBoxDto);
                }

                if(createBoxDto.production_date != DateTime.MinValue)
                    if (createBoxDto.expiration_date != DateTime.MinValue)
                    {
                        command.production_date = createBoxDto.production_date.Date;
                        command.expiration_date = createBoxDto.expiration_date.Date;
                    }
                    else
                    {
                        command.production_date = createBoxDto.production_date.Date;
                        command.expiration_date = createBoxDto.production_date.AddDays(100).Date;
                    }
                else
                {
                    command.production_date = createBoxDto.expiration_date.AddDays(-100).Date;
                    command.expiration_date = createBoxDto.expiration_date.Date;
                }

                command.PalletID = new Guid(createBoxDto.PalletID_string);
                var boxId = await Mediator.Send(command);

                var commandOfUpdatePallet = _mapper.Map<ChangePalletCommand>(createBoxDto);
                commandOfUpdatePallet.ID = command.PalletID;
                var palletId = await Mediator.Send(commandOfUpdatePallet);

                return RedirectToAction(nameof(Index));
            }
            return View(createBoxDto);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var query_Box = new GetBoxDetailsQuery { ID = id };
            var vm_Box = await Mediator.Send(query_Box);
            var result = _mapper.Map<UpdateBoxDto>(vm_Box);

            var query_pallets = new GetPalletListQuery { };
            var vm_pallets = await Mediator.Send(query_pallets);           

            result.Pallets = vm_pallets.Pallets
                .Select(e => new SelectListItem {
                    Value = e.ID.ToString(),
                    Text = e.depth.ToString() + " x " +
                        e.width.ToString() + " x " +
                        e.height.ToString()
                }).ToList();

            return View(result);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] UpdateBoxDto updateBoxDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<UpdateBoxCommand>(updateBoxDto);
                await Mediator.Send(command);

                if (updateBoxDto.expiration_date == DateTime.MinValue && updateBoxDto.production_date == DateTime.MinValue)
                {
                    ModelState.AddModelError("", "Укажите дату изготовления и/или срок годности");
                    return View(updateBoxDto);
                }

                if (updateBoxDto.production_date != DateTime.MinValue)
                    if (updateBoxDto.expiration_date != DateTime.MinValue)
                    {
                        command.production_date = updateBoxDto.production_date.Date;
                        command.expiration_date = updateBoxDto.expiration_date.Date;
                    }
                    else
                    {
                        command.production_date = updateBoxDto.production_date.Date;
                        command.expiration_date = updateBoxDto.production_date.AddDays(100).Date;
                    }
                else
                {
                    command.production_date = updateBoxDto.expiration_date.AddDays(-100).Date;
                    command.expiration_date = updateBoxDto.expiration_date.Date;
                }

                command.PalletID = new Guid(updateBoxDto.PalletID_string);

                var commandOfUpdatePallet = new ChangePalletCommand
                {
                    ID = command.PalletID,
                    weight = command.weight,
                    expiration_date = command.expiration_date
                };

                var palletId = await Mediator.Send(commandOfUpdatePallet);

                return RedirectToAction(nameof(Index));
            }
            return View(updateBoxDto);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var query_box = new GetBoxDetailsQuery { ID = id };
            var vm_box = await Mediator.Send(query_box);
            var result = _mapper.Map<UpdateBoxDto>(vm_box);

            var query_pallet = new GetPalletDetailsQuery { ID = result.PalletID };
            var vm_pallet = await Mediator.Send(query_pallet);

            result.PalletID_string = vm_pallet.ID.ToString() + ", " +
                                       vm_pallet.depth.ToString() + "x" +
                                       vm_pallet.width.ToString() + "x" +
                                       vm_pallet.height.ToString();

            return View(result);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var query_box = new GetBoxDetailsQuery { ID = id };
            var vm_box = await Mediator.Send(query_box);
            var result = _mapper.Map<UpdateBoxDto>(vm_box);

            var query_pallet = new GetPalletDetailsQuery { ID = result.PalletID };
            var vm_pallet = await Mediator.Send(query_pallet);

            result.PalletID_string = vm_pallet.ID.ToString() + ", " +
                                       vm_pallet.depth.ToString() + "x" +
                                       vm_pallet.width.ToString() + "x" +
                                       vm_pallet.height.ToString();
            return View(result);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var query_box = new GetBoxDetailsQuery { ID = id };
            var vm_box = await Mediator.Send(query_box);

            var command = new DeleteBoxCommand { ID = id };
            await Mediator.Send(command);

            var commandOfUpdatePallet = new ChangePalletCommand
            {
                ID = vm_box.PalletID,
                weight = vm_box.weight * (-1),
                expiration_date= DateTime.MaxValue,

            };
            
            var palletId = await Mediator.Send(commandOfUpdatePallet);
            return RedirectToAction(nameof(Index));
        }
    }
}
