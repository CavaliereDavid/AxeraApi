using AutoMapper;
using AxeraApi.CustomActionFilters;
using AxeraApi.Domain.DTO;
using AxeraApi.Domain.Models;
using AxeraApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AxeraApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MeetingController : ControllerBase
{
    private readonly IMeetingRepository meetingRepository;
    private readonly IMapper mapper;

    public MeetingController(IMeetingRepository meetingRepository, IMapper mapper)
    {
        this.meetingRepository = meetingRepository;
        this.mapper = mapper;
    }
    /// <summary>
    /// api/meeting
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ValidationModel]
    public async Task<IActionResult> GetAll()
    {
        List<Meeting> meetingModel = await meetingRepository.GetAllAsync();

        List<MeetingDTO> meetingDTO = mapper.Map<List<MeetingDTO>>(meetingModel);
        return Ok(meetingDTO);
    }
    /// <summary>
    /// api/meeting/{id}
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [ValidationModel]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var meetingModel = await meetingRepository.GetByIdAsync(id);
        if (meetingModel == null)
        {
            return NotFound();
        }
        MeetingDTO meetingDTO = mapper.Map<MeetingDTO>(meetingModel);
        return Ok(meetingDTO);
    }
    /// <summary>
    /// api/meeting
    /// </summary>
    /// <param name="createMeetingRequestDTO"></param>
    /// <returns></returns>
    [HttpPost]
    [ValidationModel]
    public async Task<IActionResult> Create([FromBody] CreateMeetingRequestDTO createMeetingRequestDTO)
    {
        Meeting meeting = mapper.Map<Meeting>(createMeetingRequestDTO);
        await meetingRepository.CreateAsync(meeting);
        MeetingDTO meetingDTO = mapper.Map<MeetingDTO>(meeting);

        return CreatedAtAction(nameof(GetById), new { id = meetingDTO.Id }, meetingDTO);
    }
    /// <summary>
    /// api/meeting/{id}
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateMeetingRequestDTO"></param>
    /// <returns></returns>
    [HttpPut]
    [ValidationModel]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateMeetingRequestDTO updateMeetingRequestDTO)
    {
        var meetingModel = mapper.Map<Meeting>(updateMeetingRequestDTO);

        meetingModel = await meetingRepository.UpdateAsync(id, meetingModel);

        if (meetingModel == null)
        {
            return NotFound();
        }

        MeetingDTO meetingDTO = mapper.Map<MeetingDTO>(meetingModel);
        return Ok(meetingDTO);
    }
    [HttpDelete]
    [ValidationModel]
    [Route("Softdelete/{id:Guid}")]
    public async Task<IActionResult> SoftDelete([FromRoute] Guid id)
    {
        var meetingModel = await meetingRepository.SoftDeleteAsync(id);

        if (meetingModel == null)
        {
            return NotFound();
        }

        DeleteMeetingRequestDTO meetingDTO = mapper.Map<DeleteMeetingRequestDTO>(meetingModel);
        return Ok(meetingDTO);
    }
    /// <summary>
    /// api/meeting/{id}
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [ValidationModel]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var meetingModel = await meetingRepository.DeleteAsync(id);

        if (meetingModel == null)
        {
            return NotFound();
        }

        MeetingDTO meetingDTO = mapper.Map<MeetingDTO>(meetingModel);
        return Ok(meetingDTO);
    }
}
