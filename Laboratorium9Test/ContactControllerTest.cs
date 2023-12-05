using Lab_3.Controllers;
using Lab_3.Models;

namespace Laboratorium9Test
{
    public class ContactControllerTest
    {
        private ContactController _controller;
        private IContactService _service;
        private readonly IDateTimeProvider _dateTimeProvider;

        ContactControllerTest()
        {
            _service = new MemoryContactService(dateTimeProvider: _dateTimeProvider);
            _service.Add(new Contact() { Id = 1 });
            _controller = new ContactController(_service);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}