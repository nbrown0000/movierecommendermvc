using MovieRecommender.Helper;
using MovieRecommender.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommender.Test
{
    public class StringFunctionsTests
    {
        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void GetDomainFromUrl_ShouldReturnEmptyString_WhenInputIsNullOrEmpty(string url)
        {
            // Arrange
            var expectedResult = string.Empty;

            // Act
            var result = StringFunctions.GetDomainFromUrl(url);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void GetDomainFromUrl_ShouldReturnCorrectString_WhenInputIsValid()
        {
            // Arrange
            var fakeUrl = "https://www.foxmovies.com/movies/die-hard";
            var expectedResult = "foxmovies.com";

            // Act
            var result = StringFunctions.GetDomainFromUrl(fakeUrl);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData(null)]
        public void GetLanguageName_ShouldReturnEmptyString_WhenInputIsNullOrEmpty(string languageName) {
            // Arrange
            var expectedResult = string.Empty;

            // Act
            var result = StringFunctions.GetLanguageName(languageName);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void ConvertGenreObjectsListToStringOfNames_ShouldReturnEmptyString_WhenInputIsNullOrEmpty()
        {
            // Arrange
            List<Genre>? input1 = null;
            List<Genre> input2 = new List<Genre> { };

            var expectedResult = "";

            // Act
            var result1 = StringFunctions.ConvertGenreObjectsListToStringOfNames(input1);
            var result2 = StringFunctions.ConvertGenreObjectsListToStringOfNames(input2);

            // Assert
            Assert.Equal(result1, expectedResult);
            Assert.Equal(result2, expectedResult);
        }

        [Fact]
        public void ConvertGenreObjectsListToStringOfNames_ShouldReturnCorrectString_WhenInputIsValid()
        {
            // Arrange
            List<Genre> input1 = new List<Genre> {
                new Genre { Id = 1, Name = "Action" }
            };
            List<Genre> input2 = new List<Genre> {
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 2, Name = "Comedy" },
                new Genre { Id = 3, Name = "Drama" }
            };

            var expectedResult1 = "Action";
            var expectedResult2 = "Action, Comedy, Drama";

            // Act
            var result1 = StringFunctions.ConvertGenreObjectsListToStringOfNames(input1);
            var result2 = StringFunctions.ConvertGenreObjectsListToStringOfNames(input2);

            // Assert
            Assert.Equal(result1, expectedResult1);
            Assert.Equal(result2 , expectedResult2);
        }

        [Fact]
        public void ConvertGenreObjectsListToStringOfIds_ShouldReturnEmptyString_WhenInputIsNullOrEmpty()
        {
            // Arrange
            List<Genre>? input1 = null;
            List<Genre> input2 = new List<Genre> { };

            var expectedResult = "";

            // Act
            var result1 = StringFunctions.ConvertGenreObjectsListToStringOfIds(input1);
            var result2 = StringFunctions.ConvertGenreObjectsListToStringOfIds(input2);

            // Assert
            Assert.Equal(result1, expectedResult);
            Assert.Equal(result2, expectedResult);
        }

        [Fact]
        public void ConvertGenreObjectsListToStringOfIds_ShouldReturnCorrectString_WhenInputIsValid()
        {
            // Arrange
            List<Genre> input1 = new List<Genre> {
                new Genre { Id = 1, Name = "Action" }
            };
            List<Genre> input2 = new List<Genre> {
                new Genre { Id = 1, Name = "Action" },
                new Genre { Id = 5, Name = "Comedy" },
                new Genre { Id = 6, Name = "Drama" }
            };

            var expectedResult1 = "1";
            var expectedResult2 = "1,5,6";

            // Act
            var result1 = StringFunctions.ConvertGenreObjectsListToStringOfIds(input1);
            var result2 = StringFunctions.ConvertGenreObjectsListToStringOfIds(input2);

            // Assert
            Assert.Equal(result1, expectedResult1);
            Assert.Equal(result2, expectedResult2);
        }

        [Fact]
        public void ConvertGenreIdsToNames_ShouldReturnEmptyString_WhenInputIsNullOrEmpty()
        {
            // Arrange
            List<int> input1 = new List<int> { };
            List<int> input2 = null;

            var expectedResult = "";

            // Act
            var result1 = StringFunctions.ConvertGenreIdsToNames(input1);
            var result2 = StringFunctions.ConvertGenreIdsToNames(input2);

            // Assert
            Assert.Equal(result1, expectedResult);
            Assert.Equal(result2, expectedResult);
        }

        [Fact]
        public void ConvertGenreIdsToNames_ShouldReturnCorrectString_WhenInputIsValid()
        {
            // Arrange
            List<int> input1 = new List<int> { 28, 18 };
            List<int> input2 = new List<int> { 28, 12, 35 };

            var expectedResult1 = "Action, Drama";
            var expectedResult2 = "Action, Adventure, Comedy";

            // Act
            var result1 = StringFunctions.ConvertGenreIdsToNames(input1);
            var result2 = StringFunctions.ConvertGenreIdsToNames(input2);

            // Assert
            Assert.Equal(result1, expectedResult1);
            Assert.Equal(result2, expectedResult2);
        }

        [Fact]
        public void ConvertGenreIdsToNames_ShouldOmitInvalidGenres_AndReturnRemainingStrin_WhenInputIsValid()
        {
            // Arrange
            List<int> input1 = new List<int> { 28, 1 };
            List<int> input2 = new List<int> { 1, 12, 35 };
            List<int> input3 = new List<int> { 80, 1, 9648 };

            var expectedResult1 = "Action";
            var expectedResult2 = "Adventure, Comedy";
            var expectedResult3 = "Crime, Mystery";

            // Act
            var result1 = StringFunctions.ConvertGenreIdsToNames(input1);
            var result2 = StringFunctions.ConvertGenreIdsToNames(input2);
            var result3 = StringFunctions.ConvertGenreIdsToNames(input3);

            // Assert
            Assert.Equal(result1, expectedResult1);
            Assert.Equal(result2, expectedResult2);
            Assert.Equal(result3, expectedResult3);
        }

        [Fact]
        public void FormatMovieYear_ShouldReturnTBA_WhenInputIsNull()
        {
            // Arrange
            DateTime? input = null;
            string expectedResult = "TBA";

            // Act
            var result = StringFunctions.FormatMovieYear(input);

            // Assert
            Assert.Equal(expectedResult, result);
        }
    }
}
