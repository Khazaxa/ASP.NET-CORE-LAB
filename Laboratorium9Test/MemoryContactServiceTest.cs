using Lab_3.Controllers;
using Lab_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium9Test
{
    public class MemoryContactServiceTest
    {
        private MemoryContactService _controller;
        private IContactService _service;
        private readonly IDateTimeProvider _dateTimeProvider;

        public MemoryContactServiceTest(IDateTimeProvider dateTimeProvider)
        {
            _dateTimeProvider = dateTimeProvider;
            _service = new MemoryContactService(_dateTimeProvider);
            _service.Add(new Contact() { Id = 1 });
            _service.Add(new Contact() { Id = 2 });
            _controller = new MemoryContactService(_service);
        }

        [Fact]
        public void FindAllTest()
        {
            var result = _controller.FindAll();
            Assert.IsType<List<Contact>>(result);
        }

        [Fact]
        public void DetailsTest()
        {
            var result = _controller.Details(1);
            Assert.IsType<Contact>(result);
        }
    }
}