using FluentValidation;


namespace Warehouse.Application.Boxes.Queries.GetBoxDetails
{
    public class GetBoxDetailsQueryValidator : AbstractValidator<GetBoxDetailsQuery>
    {
        public GetBoxDetailsQueryValidator()
        {
            // Возможна окончательная проверка запроса на валидность
        }
    }
}
