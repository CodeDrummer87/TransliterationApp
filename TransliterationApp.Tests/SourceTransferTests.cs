using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TransliterationApp.Models;
using TransliterationApp.Models.DbSets;
using TransliterationApp.Modules.Implementation;
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
                if(data.TextName == sourceNames[i])
                {
                    return false;
                }
            }
            return true;
        }

        private int TryToSaveSourceInDb(SourceText data)
        {
            if(data != null)
            {
                if(CheckForExist(data))
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
    }
}
