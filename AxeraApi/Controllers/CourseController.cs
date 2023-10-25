using AutoMapper;
using AxeraApi.CustomActionFilters;
using AxeraApi.Domain.DTO;
using AxeraApi.Domain.Models;
using AxeraApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AxeraApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository courseRepository;
    private readonly IMapper mapper;

    public CourseController(ICourseRepository courseRepository, IMapper mapper)
    {
        this.courseRepository = courseRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// api/course
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ValidationModel]
    public async Task<IActionResult> GetAll([FromQuery] string? filterOn, [FromQuery] bool? filterQuery)
    {
        List<Course> courseModel = await courseRepository.GetAllAsync(filterOn, filterQuery ?? false);

        List<CourseDTO> courseDTO = mapper.Map<List<CourseDTO>>(courseModel);
        return Ok(courseDTO);
    }

    /// <summary>
    /// api/course/{id}
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet]
    [ValidationModel]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var courseModel = await courseRepository.GetByIdAsync(id);
        if(courseModel == null)
        {
            return NotFound();
        }
        CourseDTO courseDTO = mapper.Map<CourseDTO>(courseModel);
        return Ok(courseDTO);
    }
    /// <summary>
    /// api/course
    /// </summary>
    /// <param name="addCourseRequestDTO"></param>
    /// <returns></returns>
    [HttpPost]
    [ValidationModel]
    public async Task<IActionResult> Create([FromBody]AddCourseRequestDTO addCourseRequestDTO)
    {
        Course course = mapper.Map<Course>(addCourseRequestDTO);
        await courseRepository.CreateAsync(course);
        CourseDTO courseDTO = mapper.Map<CourseDTO>(course);

        return CreatedAtAction(nameof(GetById), new { id = courseDTO.Id }, courseDTO);
    }
    /// <summary>
    /// api/course/{id}
    /// </summary>
    /// <param name="id"></param>
    /// <param name="updateCourseRequestDTO"></param>
    /// <returns></returns>
    [HttpPut]
    [ValidationModel]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateCourseRequestDTO updateCourseRequestDTO)
    {
        var courseModel = mapper.Map<Course>(updateCourseRequestDTO);

        courseModel = await courseRepository.UpdateAsync(id, courseModel);

        if(courseModel == null)
        {
            return NotFound();
        }

        CourseDTO courseDTO = mapper.Map<CourseDTO>(courseModel); 
        return Ok(courseDTO);
    }
    /// <summary>
    /// api/course/{id}
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [ValidationModel]
    [Route("Softdelete/{id:Guid}")]
    public async Task<IActionResult> SoftDelete([FromRoute] Guid id)
    {
        var courseModel = await courseRepository.SoftDeleteAsync(id);

        if (courseModel == null)
        {
            return NotFound();
        }

        DeleteCourseRequestDTO courseDTO = mapper.Map<DeleteCourseRequestDTO>(courseModel);
        return Ok(courseDTO);
    }
    /// <summary>
    /// api/course/{id}
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete]
    [ValidationModel]
    [Route("Delete/{id:Guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var courseModel = await courseRepository.DeleteAsync(id);

        if(courseModel == null)
        {
            return NotFound();
        }

        DeleteCourseRequestDTO courseDTO = mapper.Map<DeleteCourseRequestDTO>(courseModel);
        return Ok(courseDTO);
        
    }
}
