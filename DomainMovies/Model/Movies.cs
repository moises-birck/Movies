namespace DomainMovies.Model
{
    public class Movies : Base
    {       
        public string Title { get; set; }
        public int Year { get; set; }
        public string Studios { get; set; }
        public string Producers { get; set; }
        public string Winner { get; set; }
    }
}
