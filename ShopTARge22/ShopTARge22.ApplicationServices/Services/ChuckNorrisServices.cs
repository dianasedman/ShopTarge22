using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Core.Dto;
using Nancy.Json;
using ShopTARge22.Core.Dto.WeatherDtos;
using System.Net;
using ShopTARge22.Core.Dto.ChuckNorrisDtos;

namespace ShopTARge22.ApplicationServices.Services
{
    public class ChuckNorrisServices : IChuckNorrisServices
    {
        public async Task<OpenChuckNorrisResultDto> OpenChuckNorrisResult(OpenChuckNorrisResultDto dto)
        {
            string url = $"https://api.chucknorris.io/jokes/random";

            //mis peab tegema andmetega api call puhul
            //andmed tulevas Json kujul siia ja mis peab tegema, et need muuta Csharp arusaadavaks
            using (WebClient client = new WebClient())
            {
                string json = client.DownloadString(url);
                ChuckNorrisResponseDto chuckNorrisResult = new JavaScriptSerializer().Deserialize<ChuckNorrisResponseDto>(json);

                //dto.Categories = chuckNorrisResult.Categories;
                dto.Created_At = chuckNorrisResult.Created_at;
                dto.Icon_Url = chuckNorrisResult.Icon_url;
                dto.Updated_At = chuckNorrisResult.Updated_at;
                dto.Url = chuckNorrisResult.Url;
                dto.Value = chuckNorrisResult.Value;

            }
            return dto;
        }
    }
}
