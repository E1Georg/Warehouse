using FluentValidation;


namespace Warehouse.Application.Boxes.Commands.UpdateBox
{
    public class UpdateBoxCommandValidation : AbstractValidator<UpdateBoxCommand>
    {
        public UpdateBoxCommandValidation()
        {
            // Окончательная проверка полей сущности перед обновлением данных в БД
        }
    }
}
