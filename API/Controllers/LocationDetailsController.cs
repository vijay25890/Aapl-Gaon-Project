using API.Data.DTO;
using API.Models.Domain;
using API.Repository.Implimentation;
using API.Repository.Interface;
using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationDetailsController : ControllerBase
    {
        private readonly ILocationsRepository locationsRepository;
        //localhost/api/categories/
        public LocationDetailsController(ILocationsRepository locationsRepository)
        {
            this.locationsRepository = locationsRepository;
        }

        [HttpGet]
        [Route("get-location-details")]
        public async Task<IActionResult> getLocationDetails()
        {
            var res = await locationsRepository.GetLocationDetails();
            var response = new List<LocationsDTO>();

            foreach (var item in res)
                {
                response.Add(new LocationsDTO
                    {
                        Name = item.Name,
                        Show = item.Show
                    });
                }
                return Ok(response);
        }

        [HttpPost]
        [Route("add-location-details")]
        public async Task<IActionResult> postLocationDetails([FromBody] LocationsDTO locationsDTO)
        {
            var Locations = new Locations
            {
                Name = locationsDTO.Name,
                Show = locationsDTO.Show
            };

            await locationsRepository.PostLocationDetails(Locations);

            var response = new LocationsDTO
            {
                Name = Locations.Name,
                Show = Locations.Show
            };

            return Ok(response);
        }

        [HttpPut]
        [Route("edit-location-details/{id}")]
        public async Task<IActionResult> updateLocationDetailsById([FromRoute] Guid id, [FromBody] LocationsDTO locationsDTO)
        {
            var locations = new Locations
            {
               Name = locationsDTO.Name,
               Show = locationsDTO.Show,
            };
            var isPresent = await locationsRepository.UpdateLocationDetails(id, locations);
            return Ok(isPresent);
        }

        [HttpDelete]
        [Route("delete-location-details/{id}")]
        public async Task<IActionResult> DeleteLocationDetailsById([FromRoute] Guid id)
        {
            var isDeleted = await locationsRepository.DeleteLocationDetails(id);
            return Ok(isDeleted);
        }

    }
}
