namespace SchoolSystem.Core.Entities.Results
{
    public class StudentResult
    {
        //TODO
        public int StudentId { get; set; }
        public string Fullname { get; set; }
        public decimal? Q1 { get; set; }
        public decimal? Q2 { get; set; }
        public decimal? Q3 { get; set; }
        public decimal? Average { get; set; }
        public string Status { get; set; }
    }
}