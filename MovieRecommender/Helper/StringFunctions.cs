using MovieRecommender.Data;
using MovieRecommender.Interfaces;
using MovieRecommender.Models;

namespace MovieRecommender.Helper
{
    public class StringFunctions
    {
        public static string FormatMovieYear(DateTime? date)
        {
            if (date == null) {
                return "TBA";
            }
            return date.Value.Year.ToString();
        }
        public static string ConvertGenreIdsToNames(List<int> genres)
        {
            if (genres == null || genres.Count() == 0)
            {
                return "";
            }

            var genresString = "";
            for (int i = 0; i < genres.Count(); i++)
            {
                genresString += GenreDictionary.Genres[genres.ElementAt(i)];
                if (i < genres.Count() - 1)
                {
                    genresString += ", ";
                }
            }
            return genresString;
        }

        public static string ConvertGenreIdsListToString(List<int> genres)
        {
            if (genres == null || genres.Count() == 0)
            {
                return "";
            }

            var genresString = "";
            for (int i = 0; i < genres.Count(); i++)
            {
                genresString += genres.ElementAt(i).ToString();
                if (i < genres.Count() - 1)
                {
                    genresString += ",";
                }
            }
            return genresString;
        }

        public static string ConvertGenreObjectsListToStringOfIds(List<Genre> genres)
        {
            if (genres == null || genres.Count() == 0)
            {
                return "";
            }

            var genresString = "";
            for (int i = 0; i < genres.Count(); i++)
            {
                genresString += genres.ElementAt(i).Id.ToString();
                if (i < genres.Count() - 1)
                {
                    genresString += ",";
                }
            }
            return genresString;
        }

        public static string ConvertGenreObjectsListToStringOfNames(List<Genre> genres)
        {
            if (genres == null || genres.Count() == 0)
            {
                return "";
            }

            var genresString = "";
            for (int i = 0; i < genres.Count(); i++)
            {
                genresString += genres.ElementAt(i).Name;
                if (i < genres.Count() - 1)
                {
                    genresString += ", ";
                }
            }
            return genresString;
        }
    }
}
