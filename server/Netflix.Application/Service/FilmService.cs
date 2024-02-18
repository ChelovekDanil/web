﻿using Netflix.Domain.Interface;
using Netflix.Domain.Interface.Repositories;
using NetflixWebApi;

namespace Netflix.Application.Service
{
    public class FilmService : IMovieService
    {
        private readonly IFilmRepository _filmRepository;

       public FilmService (IFilmRepository filmRepository)
       {
            _filmRepository = filmRepository;
       }

        public async Task<List<MovieTodo>> GetMovieAsync(int count)
        {
            var movies = await _filmRepository.GetAsync(count);

            Random rand = new();

            for (int i = 0; i < movies.Count; i++)
            {
                int j = rand.Next(i, movies.Count);

                (movies[i], movies[j]) = (movies[j], movies[i]);
            }

            return movies;
        }
    }
}
