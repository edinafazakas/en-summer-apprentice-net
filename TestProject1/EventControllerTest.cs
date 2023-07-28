using Microsoft.AspNetCore.Mvc;
using Moq;
using TMS.API.Controllers;
using TMS.API.Models;
using TMS.API.Models.Dto;
using TMS.API.Services;

[TestClass]
public class EventControllerTests
{
    // Mocks
    private Mock<IEventService> mockEventService;
    private EventController eventController;

    [TestInitialize]
    public void Initialize()
    {
        // Arrange
        mockEventService = new Mock<IEventService>();
        eventController = new EventController(mockEventService.Object);
    }

    [TestMethod]
    public void GetAll_Should_Return_OkResult_With_EventDtos()
    {
        // Arrange
        List<EventDto> expectedDtoEvents = new List<EventDto>
        {
            new EventDto { EventId = 1, Name = "Event 1" },
            new EventDto { EventId = 2, Name = "Event 2" }
        };

        mockEventService.Setup(s => s.GetAll()).Returns(expectedDtoEvents);

        // Act
        var result = eventController.GetAll();

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult.Value);
        Assert.IsInstanceOfType(okResult.Value, typeof(List<EventDto>));

        var dtoEvents = okResult.Value as List<EventDto>;
        Assert.AreEqual(expectedDtoEvents.Count, dtoEvents.Count);
        Assert.AreEqual(expectedDtoEvents[0].EventId, dtoEvents[0].EventId);
        Assert.AreEqual(expectedDtoEvents[1].Name, dtoEvents[1].Name);
    }

    [TestMethod]
    public async Task GetById_Should_Return_OkResult_With_EventDto()
    {
        // Arrange
        int eventId = 1;
        EventDto expectedDtoEvent = new EventDto { EventId = eventId, Name = "Event 1" };

        mockEventService.Setup(s => s.GetById(eventId)).ReturnsAsync(expectedDtoEvent);

        // Act
        var result = await eventController.GetById(eventId);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult.Value);
        Assert.IsInstanceOfType(okResult.Value, typeof(EventDto));

        var dtoEvent = okResult.Value as EventDto;
        Assert.AreEqual(expectedDtoEvent.EventId, dtoEvent.EventId);
        Assert.AreEqual(expectedDtoEvent.Name, dtoEvent.Name);
    }


    [TestMethod]
    public async Task Delete_Should_Return_OkResult_With_DeletedEvent()
    {
        // Arrange
        int eventId = 1;
        EventDto expectedDeletedEvent = new EventDto { EventId = eventId, Name = "Event 1" };

        mockEventService.Setup(s => s.GetById(eventId)).ReturnsAsync(expectedDeletedEvent);

        // Act
        var result = await eventController.Delete(eventId);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result.ExecuteResult, typeof(OkObjectResult));

        var okResult = result as OkObjectResult;
        Assert.IsNotNull(okResult.Value);
        Assert.IsInstanceOfType(okResult.Value, typeof(EventDto));

        var deletedEvent = okResult.Value as EventDto;
        Assert.AreEqual(expectedDeletedEvent.EventId, deletedEvent.EventId);
        Assert.AreEqual(expectedDeletedEvent.Name, deletedEvent.Name);

        mockEventService.Verify(s => s.Delete(eventId), Times.Once);
    }

    [TestMethod]
    public async Task Patch_Should_Return_OkResult_With_PatchedEvent()
    {
        // Arrange
        EventPatchDto eventPatchDto = new EventPatchDto { EventId = 1, EventName = "Updated Event Name" };
        Event expectedPatchedEvent = new Event { EventId = 1, Name = "Updated Event Name" };

        mockEventService.Setup(s => s.Patch(It.IsAny<EventPatchDto>())).ReturnsAsync(expectedPatchedEvent);

        // Act
        var result = await eventController.Patch(eventPatchDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult.Value);
        Assert.IsInstanceOfType(okResult.Value, typeof(Event));

        var patchedEvent = okResult.Value as Event;
        Assert.AreEqual(expectedPatchedEvent.EventId, patchedEvent.EventId);
        Assert.AreEqual(expectedPatchedEvent.Name, patchedEvent.Name);
    }

    [TestMethod]
    public void AddEvent_Should_Return_OkResult_With_EventId()
    {
        // Arrange
        EventAddDto eventAddDto = new EventAddDto { Name = "New Event" };
        int expectedEventId = 1;

        mockEventService.Setup(s => s.AddEvent(It.IsAny<EventAddDto>())).Returns(expectedEventId);

        // Act
        var result = eventController.AddEvent(eventAddDto);

        // Assert
        Assert.IsNotNull(result);
        Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));

        var okResult = result.Result as OkObjectResult;
        Assert.IsNotNull(okResult.Value);
        Assert.IsInstanceOfType(okResult.Value, typeof(int));

        var eventId = (int)okResult.Value;
        Assert.AreEqual(expectedEventId, eventId);
    }


}
