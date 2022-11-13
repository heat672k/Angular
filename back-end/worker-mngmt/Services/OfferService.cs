using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using worker_mngmt.Data;
using worker_mngmt.DTOs;
using worker_mngmt.Models;

namespace worker_mngmt.Services
{
    public class OfferService : IOfferService
    {
        private AppDbContext _appDbContext;

        public OfferService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int AddReview(AddReviewDto addReviewDto)
        {
            var offer = _appDbContext.Offers.SingleOrDefault(o => o.Id.Equals(new Guid(addReviewDto.OfferId)));
            var review = offer.Reviews.SingleOrDefault(r => r.Reviewer.Id.Equals(new Guid(addReviewDto.ReviewerId)));
            var revewer = _appDbContext.Users.SingleOrDefault(u => u.Id.Equals(new Guid(addReviewDto.ReviewerId)));

            if(review == null)
            {
                _appDbContext.Reviews.Add( new Review()
                {
                    Id = Guid.NewGuid(),
                    Offer = offer,
                    Reviewer = revewer
                });
            }
            else
            {
                _appDbContext.Reviews.Remove(review);
            }

            _appDbContext.SaveChanges();

            return offer.Reviews.Count();
        }

    public void Apply(ApplyToOfferDto applyToOfferDto)
        {
            var offer = _appDbContext.Offers.FirstOrDefault(o => o.Id.Equals(new Guid(applyToOfferDto.OfferId)));
            var user = _appDbContext.Users.FirstOrDefault(u => u.Id.Equals(new Guid(applyToOfferDto.UserId)));
            
            _appDbContext.Candidates.Add(new Candidate()
            {
                Id = Guid.NewGuid(),
                Status = CandidateStatus.Pending,
                Offer = offer,
                User = user
            });

            _appDbContext.SaveChanges();
        }

        public IEnumerable<OfferDetailDto> GetAll()
        {
            return _appDbContext.Offers.Select(o => new OfferDetailDto()
            {
                Id = o.Id,
                Title = o.Ttile,
                Description = o.Description,
                Category = o.Category,
                Type = o.Type,
                CandidatesId = o.Candidates.Select(c => c.User.Id),
                Likes = o.Reviews.Count(),
                OrgId = o.Publisher.Id
            });
        }

        public IEnumerable<OfferApplicantDto> GetApplicants(string id)
        {
            return _appDbContext.Candidates.Where(c => c.Offer.Id.Equals(new Guid(id))).Select(c => new OfferApplicantDto()
            {
                Id = c.Id,
                Email = c.User.Email,
                Name = c.User.Name,
                Status = c.Status
            });
        }

        public OfferDetailDto GetById(string id)
        {
            var offer = _appDbContext.Offers.FirstOrDefault(o => o.Id.Equals(new Guid(id)));

            return new OfferDetailDto()
            {
                Id = offer.Id,
                Title = offer.Ttile,
                Description = offer.Description,
                Category = offer.Category,
                Type = offer.Type,
                Likes = offer.Reviews.Count(),
                OrgId = offer.Publisher.Id,
                CandidatesId = offer.Candidates.Select(c => c.User.Id)
            };
        }

        public IEnumerable<OfferDetailDto> GetOffers(string id)
        {
            return _appDbContext.Offers.Where(o => o.Publisher.Id.Equals(new Guid(id))).Select(o => new OfferDetailDto()
            {
                Id = o.Id,
                Title = o.Ttile,
                Description = o.Description,
                Category = o.Category,
                Type = o.Type,
                CandidatesId = o.Candidates.Select(c => c.User.Id),
                Likes = o.Reviews.Count(),
                OrgId = o.Publisher.Id
            });
        }

        public void GiveApplicantResponse(OfferResponseDto offerResponseDto)
        {
            var candidate = _appDbContext.Candidates.FirstOrDefault(c => c.Id.Equals(new Guid(offerResponseDto.CandidateId)));

            candidate.Status = offerResponseDto.IsApproved ? CandidateStatus.Approved : CandidateStatus.Rejected;

            _appDbContext.SaveChanges();
        }

        public OfferDetailDto NewOffer(NewOfferDto newOffer)
        {
            var offer = new Offer()
            {
                Id = Guid.NewGuid(),
                Ttile = newOffer.Title,
                Description = newOffer.Description,
                Type = newOffer.Type,
                Category = newOffer.Category,
                Publisher = _appDbContext.Orgs.SingleOrDefault(o => o.Id.Equals(new Guid(newOffer.OrgId)))
            };

            _appDbContext.Offers.Add(offer);
            _appDbContext.SaveChanges();

            return new OfferDetailDto()
            {
                Id = offer.Id,
                Title = offer.Ttile,
                Description = offer.Description,
                Category = offer.Category,
                Type = offer.Type,
                Likes = offer.Reviews.Count(),
                OrgId = offer.Publisher.Id,
                CandidatesId = offer.Candidates.Select(c => c.User.Id)
            };
        }

    }
}
