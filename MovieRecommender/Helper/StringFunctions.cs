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
                try
                {
                    string genreFromDictionary = GenreDictionary.Genres[genres.ElementAt(i)];
                    // Determine when to add comma to list
                    if (i > 0 && genresString.Length != 0)
                    {
                        genresString += ", ";
                    }
                    genresString += genreFromDictionary;
                }
                catch (KeyNotFoundException ex)
                {
                    // TODO: log error about GenreDictionary key not found, what key was passed in
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

        public static string GetLanguageName(string languageCode)
        {
            if (String.IsNullOrWhiteSpace(languageCode))
            {
                return "";
            }

            return LanguageDictionary.Languages[languageCode];
        }

        public static string GetDomainFromUrl(string url)
        {
            if (String.IsNullOrWhiteSpace(url))
            {
                return "";
            }

            char[] delimeters = { '/' };
            string[] parts = url.Split(delimeters);

            return parts[2].Substring(4);
        }
    }
}
