using FluentValidation;


namespace Warehouse.Application.Pallets.Commands.UpdatePallet
{
    public class UpdatePalletCommandValidation : AbstractValidator<UpdatePalletCommand>
    {
        public UpdatePalletCommandValidation()
        {
            // Окончательная проверка полей сущности перед обновлением данных в БД
        }
    }
}
