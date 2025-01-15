using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordApplication.Controllers;
using RecordApplication.Entities;
using RecordApplication.Models;
using RecordApplication.Services;

namespace RecordApplicationTests
{
    public class ServiceTests
    {
        private Mock<IAlbumsModel> _albumsModelMock;
        private AlbumsService _albumsService;

        [SetUp]
        public void Setup()
        {
            _albumsModelMock = new Mock<IAlbumsModel>();
            _albumsService = new AlbumsService( _albumsModelMock.Object );
        }

        // GetAllAlbums Expected Functionality
        [Test]
        public void GetAllAlbums_Calls_Correct_Model_Method()
        {
            _albumsService.GetAllAlbums();

            _albumsModelMock.Verify(s => s.FindAlbums(), Times.Once());
        }

        [Test]
        public void GetAllAlbums_Returns_Correct_Value()
        {
            // Arrange 
            List<Album> albums = new List<Album>()
            {
                new Album("Cheat Codes", 1, "Danger Mouse", 2022, 2, Genre.HipHop, "Danger Mouse and Black Thought"),
                new Album("Hanabi", 2, "Myghty Tommy", 2024, 3, Genre.HipHop, "By Myghty Tommy"),
            };
            _albumsModelMock.Setup(service => service.FindAlbums()).Returns(albums);

            // Act
            var result = _albumsService.GetAllAlbums();

            // Assert
            result.Should().BeEquivalentTo(albums);
        }

        // GetAlbumByID Expected Functionality
        [Test]
        public void GetAllAlbumById_Calls_Correct_Model_Method()
        {
            _albumsService.GetAllAlbums();

            _albumsModelMock.Verify(s => s.FindAlbums(), Times.Once());
        }

        [Test]
        public void GetAllAlbumById_Returns_Correct_Value()
        {
            // Arrange 
            Album album = new Album("Cheat Codes", 1, "Danger Mouse", 2022, 2, Genre.HipHop, "Danger Mouse and Black Thought");
            _albumsModelMock.Setup(service => service.FindAlbumById(1)).Returns(album);

            // Act
            var result = _albumsService.GetAlbumById(1);

            // Assert
            result.Should().BeEquivalentTo(album);
        }

        // PostAlbum Expected Functionality
        [Test]
        public void PostAlbum_Calls_Correct_Model_Method()
        {
            // Arrange
            Album album = new Album("Cheat Codes", 1, "Danger Mouse", 2022, 2, Genre.HipHop, "Danger Mouse and Black Thought");

            // Act
            var postedAlbum = _albumsService.PostAlbum(album);

            // Assert
            _albumsModelMock.Verify(s => s.PostAlbum(It.IsAny<Album>()), Times.Once());
        }

        [Test]
        public void PostAlbum_Returns_Correct_Status_And_Value_When_Artist_Exists()
        {
            // Arrange 
            Album album = new Album("Cheat Codes", 1, "Danger Mouse", 2022, 2, Genre.HipHop, "Danger Mouse and Black Thought");

            _albumsModelMock.Setup(service => service.PostAlbum(It.IsAny<Album>())).Returns(album);

            // Act
            var result = _albumsService.PostAlbum(album);

            // Assert
            result.Should().BeEquivalentTo(album);
        }

        // PutAlbum Expected Functionality
        [Test]
        public void PutAlbum_Calls_Correct_Model_Method()
        {
            // Arrange
            Album album = new Album("Cheat Codes", 1, "Danger Mouse", 2022, 2, Genre.HipHop, "Danger Mouse and Black Thought");

            // Act
            var postedAlbum = _albumsService.UpdateAlbum(album);

            // Assert
            _albumsModelMock.Verify(s => s.UpdateAlbum(It.IsAny<Album>()), Times.Once());
        }

        [Test]
        public void PutAlbum_Returns_Correct_Status_And_Value_When_Artist_Exists()
        {
            // Arrange 
            Album album = new Album("Cheat Codes", 1, "Danger Mouse", 2022, 2, Genre.HipHop, "Danger Mouse and Black Thought");

            _albumsModelMock.Setup(service => service.UpdateAlbum(It.IsAny<Album>())).Returns(album);

            // Act
            var result = _albumsService.UpdateAlbum(album);

            // Assert
            result.Should().BeEquivalentTo(album);
        }

        // DeleteAlbum Expected Functionality
        [Test]
        public void DeleteAlbum_Calls_Correct_Model_Method()
        {
            // Act
            int id = 1;
            _albumsService.DeleteAlbum(id);

            // Assert
            _albumsModelMock.Verify(s => s.DeleteAlbum(id), Times.Once());
        }

        [Test]
        public void DeleteAlbum_Returns_Correct_Status_And_Boolean_When_Delete_Successful()
        {
            // Arrange 
            int id = 1;
            _albumsModelMock.Setup(service => service.DeleteAlbum(id)).Returns(true);

            // Act
            var result = _albumsService.DeleteAlbum(id);

            // Assert
            result.Should().Be(true);
        }
    }
}