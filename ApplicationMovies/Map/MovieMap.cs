using CsvHelper.Configuration;
using DomainMovies.Model;

namespace ApplicationMovies.Map
{
    public class MovieMap : ClassMap<Movies>
    {
        public MovieMap()
        {
            Map(m => m.Title).Name("title");
            Map(m => m.Year).Name("year");
            Map(m => m.Studios).Name("studios");
            Map(m => m.Producers).Name("producers");
            Map(m => m.Winner).Name("winner");
        }    
    }
}
