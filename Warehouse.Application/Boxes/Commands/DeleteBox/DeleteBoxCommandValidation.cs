using FluentValidation;


namespace Warehouse.Application.Boxes.Commands.DeleteBox
{
    public class DeleteBoxCommandValidation : AbstractValidator<DeleteBoxCommand>
    {
        public DeleteBoxCommandValidation()
        {
            // Можно проверить валидность команды удаления
        }
    }
}
