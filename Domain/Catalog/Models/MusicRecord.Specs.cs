namespace SimpleMusicStore.Domain.Catalog.Models
{
    using FakeItEasy;
    using FluentAssertions;
    using SimpleMusicStore.Domain.Catalog.Exceptions;
    using System;
    using Xunit;

    public class MusicRecordSpecs
    {
        [Fact]
        public void ValidPriceShouldUpdatePriceAndAddPriceHistory()
        {
            // Arrange
            var musicRecord = A.Dummy<MusicRecord>();
            var validPrice = 50;

            // Act
            musicRecord.UpdatePrice(validPrice);

            // Assert
            musicRecord.Price.Should().Be(validPrice);
            musicRecord.PriceHistory.Count.Should().Be(2);
        }

        [Fact]
        public void InvalidPriceShouldThrowException()
        {
            // Arrange
            var musicRecord = A.Dummy<MusicRecord>();
            var invalidPrice = 51;

            // Act
            Action act = () => musicRecord.UpdatePrice(invalidPrice);

            // Assert
            act.Should().Throw<InvalidMusicRecordException>();
        }
    }
}
