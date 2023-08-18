using FluentValidation;


namespace Warehouse.Application.Boxes.Commands.CreateBox
{
    public class CreateBoxCommandValidation : AbstractValidator<CreateBoxCommand>
    {
        public CreateBoxCommandValidation()
        {
            // Проверка полей сущности перед сохранением в БД
        }
    }
}
