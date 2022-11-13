namespace worker_mngmt.DTOs
{
    public class AddReviewDto
    {
        public string ReviewerId { get; set; }

        public string OfferId { get; set; }

        public bool IsPositive { get; set; }
    }
}
