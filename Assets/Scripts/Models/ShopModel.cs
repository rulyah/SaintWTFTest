using Configs;

namespace Models
{
    public class ShopModel
    {
        public Resource haveResources;
        
        public ShopModel(ShopConfig config)
        {
            haveResources = new Resource(config.capacityResources.type, 0);
        }
    }
}