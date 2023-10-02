using Microsoft.AspNetCore.Mvc;
using Warehouse.Application.Pallets.Queries.GetPalletDetails;
using Warehouse.Application.Pallets.Queries.GetPalletList;
using Warehouse.Application.Pallets.Commands.CreatePallet;
using Warehouse.Application.Pallets.Commands.UpdatePallet;
using Warehouse.Application.Pallets.Commands.DeletePallet;
using Warehouse.WebProject.Models.Pallet;
using AutoMapper;
using Warehouse.WebProject.Models.Box;
using System.ComponentModel.DataAnnotations;
using Warehouse.Application.Boxes.Commands.CreateBox;
using Warehouse.Application.Pallets.Commands.ChangePalletWeigthAndExpirationDate;

namespace Warehouse.WebProject.Controllers
{
    [Route("api/{controller}/{action}")]
    public class PalletController : BaseController
    {
        private readonly IMapper _mapper;
        public PalletController(IMapper mapper) => _mapper = mapper;

         // Task 1
        public async Task<IActionResult> palletsGroup_Task1()
        {
            var query = new GetPalletListQuery { };
            var vm = await Mediator.Send(query);           

            var results = vm.Pallets
               .OrderBy(pallet => pallet.expiration_date)
               .ThenBy(pallet => pallet.weight)
               .GroupBy(p => p.expiration_date)
               .ToList();

            return View(results);            
        }

       // Task 2
        public async Task<IActionResult> pallets_Task2()
        {
            var query = new GetPalletListQuery { };
            var vm = await Mediator.Send(query);

            foreach (var pallet in vm.Pallets)
            {
                pallet.volume = pallet.depth * pallet.height * pallet.width;
                foreach (var box in pallet.Boxes)
                    pallet.volume += box.depth * box.height * box.width;

                pallet.volume = Math.Round(pallet.volume, 2);
            }            

            var results = vm.Pallets
                .OrderByDescending(i => i.expiration_date)
                .ThenBy(i => i.volume).Take(3).ToList();

            return View(results);
        }

        public async Task<IActionResult> generatePalletsAndBoxes()
        {
            CreatePalletDto pallet;
            CreateBoxDto box;

            CreatePalletCommand command_pallet;
            CreateBoxCommand command_box;
            ChangePalletCommand command_change;

            Guid palletId;
            Guid boxId;
            DateTime tmp_production_date;

            var random = new Random();

            for (int i = 0; i < 5; i++)
            {
                pallet = new CreatePalletDto()
                {
                    width = Math.Round((random.NextDouble() * (600 - 200)) + 200, 2),
                    height = Math.Round((random.NextDouble() * (600 - 200)) + 200, 2),
                    depth = Math.Round((random.NextDouble() * (600 - 200)) + 200, 2)                   
                };

                command_pallet = _mapper.Map<CreatePalletCommand>(pallet);
                command_pallet.ID = Id;                

                palletId = await Mediator.Send(command_pallet);

                for (int j = 0; j < 2; j++)
                {
                    tmp_production_date = (new DateTime(2023, 8, 1)).AddDays(random.Next(1, 7));

                    box = new CreateBoxDto()
                    {
                        width = Math.Round((random.NextDouble() * (200 - 30)) + 30, 2),
                        height = Math.Round((random.NextDouble() * (200 - 30)) + 30, 2),
                        depth = Math.Round((random.NextDouble() * (200 - 30)) + 30, 2),
                        weight = Math.Round((random.NextDouble() * (50 - 1)) + 1, 2),
                        production_date = tmp_production_date,
                        expiration_date = tmp_production_date.AddDays(100),
                        PalletID_string = ""
                    };

                    command_box = _mapper.Map<CreateBoxCommand>(box);
                    command_box.PalletID = palletId;
                    boxId = await Mediator.Send(command_box);

                    command_change = _mapper.Map<ChangePalletCommand>(box);
                    command_change.ID = command_box.PalletID;
                    await Mediator.Send(command_change);
                }

            }
            return RedirectToAction(nameof(Index));
        }        

        public async Task<IActionResult> Index()
        {
            var query = new GetPalletListQuery { };
            var vm = await Mediator.Send(query);
            return View(vm.Pallets.ToList());
        }

        public async Task<IActionResult> Create()
        {           
            return View(new CreatePalletDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreatePalletDto createPalletDto)
        {
            if (ModelState.IsValid)
            {
                var command = _mapper.Map<CreatePalletCommand>(createPalletDto);
                command.ID = Id;
                command.weight = 30;
                command.expiration_date = DateTime.MinValue;

                var palletId = await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(createPalletDto);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var query = new GetPalletDetailsQuery { ID = id };
            var vm = await Mediator.Send(query);

            return View(_mapper.Map<UpdatePalletDto>(vm));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] UpdatePalletDto updatePalletDto)
        {
            if (ModelState.IsValid)
            {  
                var command = _mapper.Map<UpdatePalletCommand>(updatePalletDto);
                await Mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(updatePalletDto);
        }

        public async Task<IActionResult> Details(Guid id)
        {
            var query = new GetPalletDetailsQuery { ID = id };
            var vm = await Mediator.Send(query);
            var results = _mapper.Map<UpdatePalletDto>(vm);
          
            results.Boxes = vm.Boxes.Select(e => e.ID.ToString() + ", " +
                                                    e.depth.ToString() + "x" +
                                                    e.weight.ToString() + "x" +
                                                    e.height.ToString())
                                                        .ToList();

            return View(results);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var query = new GetPalletDetailsQuery { ID = id };
            var vm = await Mediator.Send(query);
            return View(_mapper.Map<UpdatePalletDto>(vm));
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var command = new DeletePalletCommand { ID = id };
            await Mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

    }
}
