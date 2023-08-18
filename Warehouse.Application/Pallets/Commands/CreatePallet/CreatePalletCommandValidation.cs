using FluentValidation;


namespace Warehouse.Application.Pallets.Commands.CreatePallet
{
    public class CreatePalletCommandValidation : AbstractValidator<CreatePalletCommand>
    {
        public CreatePalletCommandValidation()
        {
            // Проверка полей сущности перед сохранением в БД
        }
    }
}
