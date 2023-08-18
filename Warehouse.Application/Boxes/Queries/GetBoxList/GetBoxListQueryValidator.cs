using FluentValidation;


namespace Warehouse.Application.Boxes.Queries.GetBoxList
{
    public class GetBoxListQueryValidator : AbstractValidator<GetBoxListQuery>
    {
        public GetBoxListQueryValidator()
        {
            // Окончательная проверка запроса на валидность
        }
    }
}
