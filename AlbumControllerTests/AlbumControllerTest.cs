using Lab3___zadanieContextConnection;
using Lab3___zadanieContextConnection.Entities;
using Lab3zadanie.Controllers;
using Lab3zadanie.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AlbumControllerTests
{
        public class AlbumControllerTests
        {
            private readonly Mock<IAlbumService> _albumServiceMock;
            private readonly Mock<AppDbContext> _contextMock;
            private readonly AlbumController _controller;

            public AlbumControllerTests()
            {
                _albumServiceMock = new Mock<IAlbumService>();
                _contextMock = new Mock<AppDbContext>();
                _controller = new AlbumController(_albumServiceMock.Object, _contextMock.Object);
            }

            [Fact]
            public void Index_ReturnsAViewResult_WithAListOfAlbums()
            {
                var albums = new List<AlbumEntity>
            {
                new AlbumEntity
                {
                    AlbumId = 1,
                    Title = "Album Testowy 1",
                    Band = "Zespó³ Testowy 1",
                    Genre = "Rock",
                    ChartPosition = "1",
                    ReleaseYear = 1999,
                    Duration = 45
                },
                new AlbumEntity
                {
                    AlbumId = 2,
                    Title = "Album Testowy 2",
                    Band = "Zespó³ Testowy 2",
                    Genre = "Pop",
                    ChartPosition = "2",
                    ReleaseYear = 2001,
                    Duration = 50
                }
            };

                _albumServiceMock.Setup(service => service.FindAll()).Returns(albums);

                var result = _controller.Index();

                var viewResult = Assert.IsType<ViewResult>(result);

                var model = Assert.IsAssignableFrom<IEnumerable<Album>>(viewResult.ViewData.Model);

                Assert.Equal(albums.Count, model.Count());
            }


            [Fact]
            public void Create_Post_ValidModel_ReturnsRedirectToIndex()
            {
                var album = new Album { /* Ustaw odpowiednie w³aœciwoœci */ };
                _albumServiceMock.Setup(x => x.Add(It.IsAny<AlbumEntity>()));

                var result = _controller.Create(album);

                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirectToActionResult.ActionName);
            }

            [Fact]
            public void Create_Post_InvalidModel_ReturnsViewWithModel()
            {
                var album = new Album { /* Ustaw odpowiednie w³aœciwoœci */ };
                _controller.ModelState.AddModelError("Error", "Model error");

                var result = _controller.Create(album);

                var viewResult = Assert.IsType<ViewResult>(result);
                Assert.IsType<Album>(viewResult.Model);
            }

            [Fact]
            public void DeleteConfirmed_ExistingAlbum_ReturnsRedirectToIndex()
            {
                // Arrange
                var albumId = 1;
                _albumServiceMock.Setup(x => x.FindById(albumId))
                    .Returns(new AlbumEntity { /* Ustaw odpowiednie w³aœciwoœci */ });
                _albumServiceMock.Setup(x => x.Delete(albumId));

                var result = _controller.DeleteConfirmed(albumId);

                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Equal("Index", redirectToActionResult.ActionName);
            }

            [Fact]
            public void DeleteConfirmed_NonExistingAlbum_ReturnsNotFound()
            {
                var albumId = 1;
                _albumServiceMock.Setup(x => x.FindById(albumId))
                    .Returns((AlbumEntity)null);

                var result = _controller.DeleteConfirmed(albumId);

                Assert.IsType<NotFoundResult>(result);
            }
        }
}
