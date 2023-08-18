using FluentValidation;


namespace Warehouse.Application.Pallets.Commands.DeletePallet
{
    public class DeletePalletCommandValidation : AbstractValidator<DeletePalletCommand>
    {
        public DeletePalletCommandValidation()
        {
            // Можно проверить валидность команды удаления
        }
    }
}
