using System.Collections.Generic;

namespace Models
{
    public class StorageModel
    {
        public List<Resource> haveResources;

        public StorageModel()
        {
            haveResources = new List<Resource>();
        }
    }
}