using AutoMapper;
using AxeraApi.CustomActionFilters;
using AxeraApi.Domain.DTO;
using AxeraApi.Domain.Models;
using AxeraApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AxeraApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ReservationController : ControllerBase
{
    private readonly IReservationRepository reservationRepository;
    private readonly IMapper mapper;

    public ReservationController(IReservationRepository reservationRepository, IMapper mapper)
    {
        this.reservationRepository = reservationRepository;
        this.mapper = mapper;
    }

    [HttpGet]
    [ValidationModel]
    public async Task<IActionResult> GetAll()
    {
        List<Reservation> reservationModel = await reservationRepository.GetAllAsync();

        List<ReservationDTO> reservationDTO = mapper.Map<List<ReservationDTO>>(reservationModel);
        return Ok(reservationDTO);
    }

    [HttpGet]
    [ValidationModel]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var reservationModel = await reservationRepository.GetByIdAsync(id);
        if (reservationModel == null)
        {
            return NotFound();
        }
        ReservationDTO reservationDTO = mapper.Map<ReservationDTO>(reservationModel);
        return Ok(reservationDTO);
    }

    [HttpPost]
    [ValidationModel]
    public async Task<IActionResult> Create([FromBody] CreateReservationRequestDTO createReservationRequestDTO)
    {
        Reservation reservation = mapper.Map<Reservation>(createReservationRequestDTO);
        await reservationRepository.CreateAsync(reservation);
        ReservationDTO reservationDTO = mapper.Map<ReservationDTO>(reservation);

        return CreatedAtAction(nameof(GetById), new { id = reservationDTO.Id }, reservationDTO);
    }

    [HttpPut]
    [ValidationModel]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateReservationRequestDTO updateReservationRequestDTO)
    {
        var reservationModel = mapper.Map<Reservation>(updateReservationRequestDTO);

        reservationModel = await reservationRepository.UpdateAsync(id, reservationModel);

        if (reservationModel == null)
        {
            return NotFound();
        }

        ReservationDTO reservationDTO = mapper.Map<ReservationDTO>(reservationModel);
        return Ok(reservationDTO);
    }

    [HttpDelete]
    [ValidationModel]
    [Route("SoftDelete/{id:Guid}")]
    public async Task<IActionResult> SoftDelete([FromRoute] Guid id)
    {
        var reservationModel = await reservationRepository.SoftDeleteAsync(id);

        if (reservationModel == null)
        {
            return NotFound();
        }

        DeleteReservationRequestDTO reservationDTO = mapper.Map<DeleteReservationRequestDTO>(reservationModel);
        return Ok(reservationDTO);
    }

    [HttpDelete]
    [ValidationModel]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var reservationModel = await reservationRepository.DeleteAsync(id);

        if (reservationModel == null)
        {
            return NotFound();
        }

        ReservationDTO reservationDTO = mapper.Map<ReservationDTO>(reservationModel);
        return Ok(reservationDTO);
    }
}
