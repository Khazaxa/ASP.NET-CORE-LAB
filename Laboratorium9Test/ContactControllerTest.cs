using Lab_3.Controllers;
using Lab_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium9Test
{
    public class ContactControllerTest
    {
        private ContactController _controller;
        private IContactService _service;
        private readonly IDateTimeProvider _dateTimeProvider;
        ContactControllerTest(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
            _service = new MemoryContactService(_dateTimeProvider);
            _service.Add(new Contact() { Id = 1 });
            _service.Add(new Contact() { Id = 2 });
            _controller = new ContactController(_service);
        }

        [Fact]
        public void IndexTest()
        {
            var result = _controller.Index();
            Assert.IsType<ViewResult>(result);

            var view = result as ViewResult;
            Assert.Equal("Index", view.ViewName);

            var model = view.Model;
            Assert.IsType<List<Contact>>(model);

            Assert.Equal(1, (model as List<Contact>).Count);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void DetailsTestForExistingContacts(int id)
        {
            var result = _controller.Details(id);
            Assert.IsType<ViewResult>(result);

            var view = result as ViewResult;
            Assert.Equal("Index", view.ViewName);

            var model = view.Model as Contact;
            Assert.Equal(id, model.Id);
        }

        [Fact]
        public void DetailsTestForNonExistingContact()
        {
            var result = _controller.Details(100);
            Assert.IsType<NotFoundResult>(result);
        }
    }
}