using System.Collections.Generic;

namespace Models
{
    public class PlayerModel
    {
        public List<Resource> resources;

        public PlayerModel()
        {
            resources = new List<Resource>();
        }
    }
}