using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IFridgeRepository _fridgeRepository;
        private readonly IFridgeProductRepository _fridgeProductRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFridgeModelRepository _fridgeModelRepository;
        private readonly IUserManagementRepository _userManagementRepository;

        private IFridgeService _fridgeService;
        private IProductService _productService;
        private IFridgeModelService _fridgeModelService;
        private IFridgeProductService _fridgeProductService;
        private IUserManagementService _userManagementService;

        public ServiceManager(IFridgeRepository fridgeRepository, IFridgeProductRepository fridgeProductRepository,
            IProductRepository productRepository, IFridgeModelRepository fridgeModelRepository,
            IUserManagementRepository userManagementRepository)
        {
            _fridgeModelRepository = fridgeModelRepository;
            _productRepository = productRepository;
            _userManagementRepository = userManagementRepository;
            _fridgeRepository = fridgeRepository;
            _fridgeProductRepository = fridgeProductRepository;
        }

        public IFridgeService FridgeService
        {
            get => _fridgeService ??=
                new FridgeService(_fridgeRepository);
        }

        public IFridgeProductService FridgeProductService
        {
            get => _fridgeProductService ??=
                new FridgeProductService(_fridgeProductRepository);
        }

        public IProductService ProductService
        {
            get => _productService ??=
                new ProductService(_productRepository);
        }

        public IFridgeModelService FridgeModelService
        {
            get => _fridgeModelService ??=
                new FridgeModelService(_fridgeModelRepository);
        }

        public IUserManagementService UserManagementService
        {
            get => _userManagementService ??=
                new UserManagementService(_userManagementRepository);
        }
    }
}