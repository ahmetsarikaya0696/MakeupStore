using System.Threading.Tasks;

namespace Web.Interfaces
{
    public interface IBasketViewModelService
    {
        Task<int> AddItemToBasketAsync(int productId, int quantity);
    }
}
