using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
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
                new Album("Cheat Codes", 1, new Artist("Danger Mouse"), 2022, 2, Genre.HipHop, "Danger Mouse and Black Thought"),
                new Album("Hanabi", 2, new Artist("Myghty Tommy"), 2024, 3, Genre.HipHop, "By Myghty Tommy"),
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
            Album album = new Album("Cheat Codes", 1, new Artist("Danger Mouse"), 2022, 2, Genre.HipHop, "Danger Mouse and Black Thought");
            _albumsModelMock.Setup(service => service.FindAlbumById(1)).Returns(album);

            // Act
            var result = _albumsService.GetAlbumById(1);

            // Assert
            result.Should().BeEquivalentTo(album);
        }
    }
}