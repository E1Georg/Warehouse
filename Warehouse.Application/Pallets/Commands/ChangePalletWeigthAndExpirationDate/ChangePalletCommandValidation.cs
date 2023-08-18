using FluentValidation;


namespace Warehouse.Application.Pallets.Commands.ChangePalletWeigthAndExpirationDate
{
    public class ChangePalletCommandValidation : AbstractValidator<ChangePalletCommand>
    {
        public ChangePalletCommandValidation()
        {
            // Окончательная проверка полей сущности перед обновлением данных в БД
        }
    }
}
