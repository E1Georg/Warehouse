using FluentValidation;


namespace Warehouse.Application.Pallets.Queries.GetPalletDetails
{
    public class GetPalletDetailsQueryValidator : AbstractValidator<GetPalletDetailsQuery>
    {
        public GetPalletDetailsQueryValidator()
        {
            // Возможна окончательная проверка запроса на валидность
        }
    }
}
