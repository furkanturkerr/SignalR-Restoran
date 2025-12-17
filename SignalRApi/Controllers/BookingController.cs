using AutoMapper;
using BusinessLayer.Abstract;
using DTOLayer.BookingDTO;
using EntityLayer.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace SignalRApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BookingController : Controller
{
    private readonly IBookingService _bookingService;
    private readonly IMapper _mapper;
    private readonly IValidator<CreateBookingDto> _validator;
    public BookingController(IBookingService bookingService, IMapper mapper, IValidator<CreateBookingDto> validator)
    {
        _bookingService = bookingService;
        _validator = validator;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IActionResult BookingList()
    {
        var values = _bookingService.TGetListAll();
        return Ok(_mapper.Map<List<ResultBookingDto>>(values));
    }

    [HttpPost]
    public IActionResult CreateBooking(CreateBookingDto createBookingDto)
    {
        var validationResult = _validator.Validate(createBookingDto);
        if (!validationResult.IsValid) return BadRequest(validationResult.Errors);
        var values = _mapper.Map<Booking>(createBookingDto);
        _bookingService.TAdd(values);
        return Ok("Rezervasyon Yapıldı");
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteBooking(int id)
    {
        var value = _bookingService.TGetById(id);
        _bookingService.TDelete(value);
        return Ok("Rezervasyon Silindi");
    }

    [HttpPut]
    public IActionResult UpdateBooking(UpdateBookingDto updateBookingDto)
    {
        var value = _mapper.Map<Booking>(updateBookingDto);
        _bookingService.TUpdate(value);
        return Ok("Rezervasyon Güncellendi");
    }
    
    [HttpGet("{id}")]
    public IActionResult GetBooking(int id)
    {
        var value = _bookingService.TGetById(id);
        return Ok(_mapper.Map<GetBookingDto>(value));
    }

    [HttpGet("BookingStatusApprove/{id}")]
    public IActionResult BookingStatusApprove(int id)
    {
        _bookingService.TBookingStatusApprove(id);
        return Ok("Açıklama Değiştirildi");
    }
    
    [HttpGet("BookingStatusReject/{id}")]
    public IActionResult BookingStatusReject(int id)
    {
        _bookingService.TBookingStatusReject(id);
        return Ok("Açıklama Değiştirildi");
    }
}