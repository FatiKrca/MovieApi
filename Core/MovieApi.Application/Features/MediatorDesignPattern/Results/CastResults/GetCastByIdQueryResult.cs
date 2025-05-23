﻿ 

namespace MovieApi.Application.Features.MediatorDesignPattern.Results.CastResults
{
    public class GetCastByIdQueryResult
    {    // GetCastByIdQueryResult sınıfı, bir oyuncunun (cast) detaylarını içeren bir sonucu temsil eder.

        public int CastId { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ImageUrl { get; set; }
        public string? Overview { get; set; }
        public string? Biography { get; set; }
    }
}
