﻿using ShopTARge22.Core.Dto.ChuckNorrisDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IChuckNorrisServices
    {
        Task<OpenChuckNorrisResultDto> OpenChuckNorrisResult(OpenChuckNorrisResultDto dto);
    }
}
