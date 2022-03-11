namespace Domain.Interfaces.Services
{
    public interface IServiceManager
    {
        public IFridgeService FridgeService { get; }
        public IFridgeProductService FridgeProductService { get; }
        public IProductService ProductService { get; }
        public IFridgeModelService FridgeModelService { get; }
        public IUserManagementService UserManagementService { get; }

    }
}