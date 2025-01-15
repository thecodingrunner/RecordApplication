using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RecordApplication.Controllers;
using RecordApplication.Entities;
using RecordApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecordApplicationTests
{
    internal class ControllerTests
    {
        private Mock<IAlbumsService> _albumsServiceMock;
        private Mock<IArtistService> _artistServiceMock;
        private AlbumsController _albumsController;

        [SetUp]
        public void Setup()
        {
            _albumsServiceMock = new Mock<IAlbumsService>();
            _artistServiceMock = new Mock<IArtistService>();
            _albumsController = new AlbumsController( _albumsServiceMock.Object, _artistServiceMock.Object );
        }

        // GetAlbums Expected Functionality
        [Test]
        public void GetAlbums_Calls_Correct_Service_Method()
        {
            _albumsController.GetAlbums();

            _albumsServiceMock.Verify(s => s.GetAllAlbums(), Times.Once());
        }

        [Test]
        public void GetAlbums_Returns_Correct_Status_And_Value()
        {
            // Arrange 
            List<Album> albums = new List<Album>()
            {
                new Album("Cheat Codes", 1, "Danger Mouse", 2022, 2, Genre.HipHop, "Danger Mouse and Black Thought"),
                new Album("Hanabi", 2, "Myghty Tommy", 2024, 3, Genre.HipHop, "By Myghty Tommy"),
            };
            _albumsServiceMock.Setup(service => service.GetAllAlbums()).Returns(albums);

            // Act
            var result = _albumsController.GetAlbums();

            // Assert
            result.Should()
                .BeOfType<OkObjectResult>()
                .Which.Value.Should().Be(albums);
        }

        // GetAlbums Edge Cases and Error Handling

        // GetAlbumById Expected Functionality
        [Test]
        public void GetAlbumById_Calls_Correct_Service_Method()
        {
            _albumsController.GetAlbumById(1);

            _albumsServiceMock.Verify(s => s.GetAlbumById(1), Times.Once());
        }

        [Test]
        public void GetAlbumById_Returns_Correct_Status_And_Value()
        {
            // Arrange 
            Album album = new Album("Cheat Codes", 1, "Danger Mouse", 2022, 2, Genre.HipHop, "Danger Mouse and Black Thought");

            _albumsServiceMock.Setup(service => service.GetAlbumById(1)).Returns(album);

            // Act
            var result = _albumsController.GetAlbumById(1);

            // Assert
            result.Should()
                .BeOfType<OkObjectResult>()
                .Which.Value.Should().Be(album);
        }

        // GetAlbumById Edge Cases and Error Handling

        // PostAlbum Expected Functionality
        [Test]
        public void PostAlbum_Calls_Correct_Service_Method_When_Artist_Exists()
        {
            // Arrange
            AlbumInput albumInput = new AlbumInput("Cheat Codes", "Danger Mouse", 2022, 2, "HipHop", "Danger Mouse and Black Thought");
            Artist artist = new Artist("Danger Mouse");

            _artistServiceMock.Setup(service => service.CheckIfArtistExists(albumInput.ArtistName)).Returns(artist);

            // Act
            _albumsController.PostAlbum(albumInput);

            // Assert
            _albumsServiceMock.Verify(s => s.PostAlbum(It.IsAny<Album>()), Times.Once());
        }

        [Test]
        public void PostAlbum_Returns_Correct_Status_And_Value_When_Artist_Exists()
        {
            // Arrange 
            AlbumInput albumInput = new AlbumInput("Cheat Codes", "Danger Mouse", 2022, 2, "HipHop", "Danger Mouse and Black Thought");
            Artist artist = new Artist("Danger Mouse");
            Album album = new Album("Cheat Codes", artist.Id, artist.Name, 2022, 2, Genre.HipHop, "Danger Mouse and Black Thought");

            _artistServiceMock.Setup(service => service.CheckIfArtistExists(albumInput.ArtistName)).Returns(artist);
            _albumsServiceMock.Setup(service => service.PostAlbum(It.IsAny<Album>())).Returns(album);

            // Act
            var result = _albumsController.PostAlbum(albumInput);

            // Assert
            result.Should()
                .BeOfType<OkObjectResult>()
                .Which.Value.Should().Be(album);
        }

        // PutAlbum Expected Functionality
        [Test]
        public void PutAlbum_Calls_Correct_Service_Method()
        {
            // Arrange
            AlbumInput albumInput = new AlbumInput("Cheat Codes", "Danger Mouse", 2022, 2, "HipHop", "Danger Mouse and Black Thought");
            Artist artist = new Artist("Danger Mouse");
            Album album = new Album("Cheat Codes", artist.Id, artist.Name, 2022, 2, Genre.HipHop, "Danger Mouse and Black Thought");
            int id = 1;

            _artistServiceMock.Setup(service => service.CheckIfArtistExists(albumInput.ArtistName)).Returns(artist);
            _artistServiceMock.Setup(service => service.ConvertInputToAlbum(albumInput)).Returns(album);

            // Act
            _albumsController.PutAlbum(id, albumInput);

            // Assert
            _albumsServiceMock.Verify(s => s.UpdateAlbum(It.IsAny<Album>()), Times.Once());
        }

        [Test]
        public void PutAlbum_Returns_Correct_Status_And_Value_When_Artist_Exists()
        {
            // Arrange 
            AlbumInput albumInput = new AlbumInput("Cheat Codes", "Danger Mouse", 2022, 2, "HipHop", "Danger Mouse and Black Thought");
            Artist artist = new Artist("Danger Mouse");
            Album album = new Album("Cheat Codes", artist.Id, artist.Name, 2022, 2, Genre.HipHop, "Danger Mouse and Black Thought");
            int id = 1;

            _artistServiceMock.Setup(service => service.CheckIfArtistExists(albumInput.ArtistName)).Returns(artist);
            _artistServiceMock.Setup(service => service.ConvertInputToAlbum(albumInput)).Returns(album);
            _albumsServiceMock.Setup(service => service.UpdateAlbum(It.IsAny<Album>())).Returns(album);

            // Act
            var result = _albumsController.PutAlbum(id, albumInput);

            // Assert
            result.Should()
                .BeOfType<OkObjectResult>()
                .Which.Value.Should().Be(album);
        }

        // PutAlbum Expected Functionality
        [Test]
        public void DeleteAlbum_Calls_Correct_Service_Method()
        {
            // Act
            int id = 1;
            _albumsController.DeleteAlbum(id);

            // Assert
            _albumsServiceMock.Verify(s => s.DeleteAlbum(id), Times.Once());
        }

        [Test]
        public void DeleteAlbum_Returns_NoContent_Status_And_Boolean_When_Delete_Successful()
        {
            // Arrange 
            int id = 1;
            _albumsServiceMock.Setup(service => service.DeleteAlbum(id)).Returns(true);

            // Act
            var result = _albumsController.DeleteAlbum(id);

            // Assert
            result.Should()
                .BeOfType<NoContentResult>();
        }

        [Test]
        public void DeleteAlbum_Returns_NotFound_Status_And_Boolean_When_Delete_Successful()
        {
            // Arrange 
            int id = 1;
            _albumsServiceMock.Setup(service => service.DeleteAlbum(id)).Returns(false);

            // Act
            var result = _albumsController.DeleteAlbum(id);

            // Assert
            result.Should()
                .BeOfType<NotFoundResult>();
        }

        // GetAlbumsByArtist Expected Functionality
        [Test]
        public void GetAlbumsByArtist_Calls_Correct_Service_Method()
        {
            string artistName = "Danger Mouse";
            _albumsController.GetAlbumsByArtist(artistName);

            _albumsServiceMock.Verify(s => s.GetAlbumsByArtist(artistName), Times.Once());
        }

        [Test]
        public void GetAlbumsByArtist_Returns_Correct_Status_And_Value()
        {
            // Arrange 
            string artistName = "Danger Mouse";
            List<Album> albums = new List<Album>()
            {
                new Album("Cheat Codes", 1, "Danger Mouse", 2022, 2, Genre.HipHop, "Danger Mouse and Black Thought"),
            };

            _albumsServiceMock.Setup(service => service.GetAlbumsByArtist(artistName)).Returns(albums);

            // Act
            var result = _albumsController.GetAlbumsByArtist(artistName);

            // Assert
            result.Should()
                .BeOfType<OkObjectResult>()
                .Which.Value.Should().Be(albums);
        }
    }
}
