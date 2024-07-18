namespace MovieTheaterAPI.Entity
{
    public class Movies
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public DateOnly ReleaseDate { get; set; }

        public int DirectorID { get; set; }

        public int GenreID { get; set; }

    }
}