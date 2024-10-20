﻿using Api.CORE;
using Api.CORE.Models.Movie;
using Api.REPOSITORY.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.REPOSITORY.Reposotories
{
    public class MovieRepository(StreamLabContext entities) : IMovieRepository
    {

        protected StreamLabContext _entities = entities;
        public Movie CreateMovie(Movie movie)
        {
            var entity=_entities.Movies.Add(movie);
            _entities.SaveChanges();
            return entity.Entity;
        }

        public Movie DeleteMovie(Movie movie)
        {
            _entities.Movies.Remove(movie);
            _entities.SaveChanges();
            return movie;
        }

        public Movie? FindMovie(int id)
        {
            return _entities.Movies.Include(x => x.MovieCategory).FirstOrDefault(x=>x.Id==id) ;
        }

        public IEnumerable<Movie> GetMovies()
        {
            var movies = _entities.Movies.Include(x=>x.MovieCategory).ToList();
           return movies;
        }

        public Movie UpdateMovie(int id, Movie movie)
        {
            var emovie = FindMovie(id) ;
            if (emovie!=null)
            {
                emovie.Title = movie.Title;
                emovie.Thumbnail = movie.Thumbnail;
                emovie.MoviePath = movie.MoviePath;
                emovie.Language = movie.Language;
                emovie.TvPg = movie.TvPg;
                emovie.Description = movie.Description;
                emovie.Cast = movie.Cast;
                emovie.Tags = movie.Tags;
                emovie.Views = movie.Views;
                emovie.RunTime = movie.RunTime;
                emovie.ReleaseDate = movie.ReleaseDate;
                _entities.SaveChanges();
            }
                return movie;
        }
    }
}
