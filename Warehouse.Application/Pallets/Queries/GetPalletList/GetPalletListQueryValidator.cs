using FluentValidation;


namespace Warehouse.Application.Pallets.Queries.GetPalletList
{
    public class GetPalletListQueryValidator : AbstractValidator<GetPalletListQuery>
    {
        public GetPalletListQueryValidator()
        {
            // Окончательная проверка запроса на валидность
        }
    }
}
