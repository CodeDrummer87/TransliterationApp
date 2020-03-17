using System;
using System.Collections.Generic;
using System.Linq;
using TransliterationApp.Models;
using Xunit;

namespace TransliterationApp.Tests
{
    public class SourceTransferTests
    {
        #region Method_TryToSaveSourceInDb
        [Fact]
        public void TryToSaveSourceInDb_ReturnsZero_WhenSourceIsEqualNull()
        {
            // Arrange
            SourceText data = null;

            // Act
            var result = TryToSaveSourceInDb(data);

            // Assert
            int expected = 0;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TryToSaveSourceInDb_ReturnsOne_WhenSourceIsNotNull()
        {
            // Arrange
            SourceText data = new SourceText() { };

            // Act
            int result = TryToSaveSourceInDb(data);

            //Assert
            int expected = 0;
            Assert.NotEqual(expected, result);
        }

        [Fact]
        public void TryToSaveSourceInDb_ReturnsMinusOne_WhenStorageIsFull()
        {
            // Arrange
            int currentCounter = 20;
            int sourceLimit = 20;

            // Act
            int result = currentCounter < sourceLimit ? 0 : -1;

            //Assert
            var expected = -1;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TryToSaveSourceInDb_ReturnsZero_WhenStorageIsNotFull()
        {
            // Arrange
            int currentCounter = 17;
            int sourceLimit = 20;

            // Act
            int result = currentCounter < sourceLimit ? 0 : -1;

            // Assert
            var expected = -1;
            Assert.NotEqual(expected, result);
        }

        [Fact]
        public void TryToSaveSourceInDb_ReturnsOne_WhenTheSourceNameIsUnique()
        {
            // Arrange
            SourceText data = new SourceText { TextName = "Forth" };

            // Act
            int result = TryToSaveSourceInDb(data);

            // Assert
            var expected = 1;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TryToSaveSourceInDb_ReturnsMinusTwo_WhenSourceNameIsNotUnique()
        {
            // Arrange
            SourceText data = new SourceText { TextName = "First" };

            // Act
            var result = TryToSaveSourceInDb(data);

            // Assert
            var expected = 1;
            Assert.NotEqual(expected, result);
        }

        private bool CheckForExist(SourceText data)
        {
            string[] sourceNames = { "First", "Second", "Third" };
            for (int i = 0; i < sourceNames.Length; i++)
            {
                if (data.TextName == sourceNames[i])
                {
                    return false;
                }
            }
            return true;
        }

        private int TryToSaveSourceInDb(SourceText data)
        {
            if (data != null)
            {
                if (CheckForExist(data))
                {
                    return 1;
                }
                else
                {
                    return -2;
                }
            }
            else
            {
                return 0;
            }
        }
        #endregion

        #region GetSourceByName
        [Fact]
        public void GetSourceByName_ReturnsNull_WhenTextNameIsNull()
        {
            // Arrange
            string textName = null;

            // Act
            var result = GetSourceByName(textName);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetSourceByName_ReturnsIQueryable_WhenTextNameNotNull()
        {
            // Arrange
            string textName = "First";

            //Act
            var result = GetSourceByName(textName);

            // Assert
            Assert.NotNull(result);
        }

        private IQueryable GetSourceByName(string textName)
        {
            if (textName != null)
            {
                return list.Where(t => t.TextName == textName).AsQueryable();
            }
            else
                return null;
        }

        List<SourceText> list = new List<SourceText>()
        {
            new SourceText() { TextId = 1, TextName = "First", TextDescription = "first text", TextContent = "first", UploadDate = new DateTime() },
            new SourceText() { TextId = 2, TextName = "Second", TextDescription = "second text", TextContent = "second", UploadDate = new DateTime() },
            new SourceText() { TextId = 3, TextName = "Third", TextDescription = "third text", TextContent = "third", UploadDate = new DateTime() }
        };
        #endregion

        #region DeleteSource
        [Fact]
        public void DeleteSource_0Returns_WhenParameterIsNull()
        {
            // Arrange
            string textName = null;

            // Act
            var result = DeleteSource(textName);

            // Assert
            var expected = 0;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DeleteSource_2Returns_WhenSourceTextNotExists()
        {
            // Arrange
            string textName = "Forth";

            // Act
            var result = DeleteSource(textName);

            // Assert
            var expected = 2;
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DeleteSource_1Returns_WhenSourceTextExists()
        {
            // Arrange
            string textName = "First";

            // Act
            var result = DeleteSource(textName);

            // Assert
            var expected = 1;
            Assert.Equal(expected, result);
        }

        private int DeleteSource(string text)
        {
            if (text != null)
            {
                var temp = list.Where(t => t.TextName == text).FirstOrDefault();
                if (temp != null)
                    return 1;
                else
                    return 2;
            }
            else
                return 0;
        }
        #endregion

        #region CheckForExist
        [Fact]
        public void CheckForExist_TrueReturns_WhenSourceTextExists()
        {
            // Arrange
            string textName = "First";

            // Act
            var result = CheckExist(textName);

            // Assert
            Assert.True(result);

        }

        [Fact]
        public void CheckForExist_FalseReturns_WhenSourceTextNotExists()
        {
            // Arrange
            string textName = "Forth";

            // Act
            var result = CheckExist(textName);

            // Assert
            Assert.False(result);
            
        }
        private bool CheckExist(string text)
        {
            var temp = list.FirstOrDefault(t => t.TextName == text);
            if (temp != null)
                return true;
            else
                return false;
        }
        #endregion
    }
}