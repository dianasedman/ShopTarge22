using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDto dto, Spaceship spaceship);
    }
}
