using System.Collections.Generic;
using worker_mngmt.DTOs;

namespace worker_mngmt.Services
{
    public interface IOfferService
    {
        int AddReview(AddReviewDto addReviewDto);
        void Apply(ApplyToOfferDto applyToOfferDto);
        IEnumerable<OfferDetailDto> GetAll();
        IEnumerable<OfferApplicantDto> GetApplicants(string id);
        OfferDetailDto GetById(string id);
        IEnumerable<OfferDetailDto> GetOffers(string id);
        void GiveApplicantResponse(OfferResponseDto offerResponseDto);
        OfferDetailDto NewOffer(NewOfferDto newOffer);
    }
}