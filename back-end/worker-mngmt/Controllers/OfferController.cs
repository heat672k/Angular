using Microsoft.AspNetCore.Mvc;
using worker_mngmt.DTOs;
using worker_mngmt.Services;

namespace worker_mngmt.Controllers
{
    [ApiController]
    [Route("api/OfferController")]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetById([FromRoute] string id)
        {
            var result = _offerService.GetById(id);

            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetApplicants([FromRoute] string id)
        {
            var result = _offerService.GetApplicants(id);

            return Ok(result);
        }

        [HttpGet("[action]/{id}")]
        public IActionResult GetOffers([FromRoute] string id)
        {
            var result = _offerService.GetOffers(id);

            return Ok(result);
        }

        [HttpPost("[action]")]
        public IActionResult AddReview([FromBody] AddReviewDto addReviewDto)
        {
            var result = _offerService.AddReview(addReviewDto);

            return Ok(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetAll()
        {
            var result = _offerService.GetAll();

            return Ok(result);
        }

        [HttpPost("[action]")]
        public IActionResult Apply([FromBody] ApplyToOfferDto applyToOfferDto)
        {
            _offerService.Apply(applyToOfferDto);

            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult GiveApplicantResponse([FromBody] OfferResponseDto offerResponseDto)
        {
            _offerService.GiveApplicantResponse(offerResponseDto);

            return Ok();
        }

        [HttpPost("[action]")]
        public IActionResult NewOffer([FromBody] NewOfferDto newOfferDto)
        {
            var responese = _offerService.NewOffer(newOfferDto);

            return Ok(responese);
        }
    }
}
