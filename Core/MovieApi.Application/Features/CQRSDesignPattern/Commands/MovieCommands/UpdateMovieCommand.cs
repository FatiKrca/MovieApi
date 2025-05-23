﻿namespace MovieApi.Application.Features.CQRSDesignPattern.Commands.MovieCommands
{
    // Komut (Command) sınıfı: Var olan bir filmi güncelleme işlemi için kullanılır.
    public class UpdateMovieCommand
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public decimal Rating { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public DateTime RelaseDate { get; set; }
        public string CreatedYear { get; set; }
        public bool Status { get; set; }
    }
}
