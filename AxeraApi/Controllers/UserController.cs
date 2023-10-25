using AutoMapper;
using AxeraApi.Domain.DTO;
using AxeraApi.Domain.Models;
using AxeraApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace AxeraApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserRepository userRepository;
    private readonly IMapper mapper;

    public UserController(IUserRepository userRepository, IMapper mapper)
    {
        this.userRepository = userRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Get all users.
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<User> userModel = await userRepository.GetAllAsync();
        List<UserDTO> userDTO = mapper.Map<List<UserDTO>>(userModel);
        return Ok(userDTO);
    }

    /// <summary>
    /// Get a user by ID.
    /// </summary>
    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var userModel = await userRepository.GetByIdAsync(id);
        if (userModel == null)
        {
            return NotFound();
        }
        UserDTO userDTO = mapper.Map<UserDTO>(userModel);
        return Ok(userDTO);
    }

    /// <summary>
    /// Create a new user.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] AddUserRequestDTO addUserRequestDTO)
    {
        User user = mapper.Map<User>(addUserRequestDTO);
        await userRepository.CreateAsync(user);
        UserDTO userDTO = mapper.Map<UserDTO>(user);
        return CreatedAtAction(nameof(GetById), new { id = userDTO.Id }, userDTO);
    }

    /// <summary>
    /// Update an existing user by ID.
    /// </summary>
    [HttpPut]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateUserRequestDTO updateUserRequestDTO)
    {
        var userModel = mapper.Map<User>(updateUserRequestDTO);
        userModel = await userRepository.UpdateAsync(id, userModel);

        if (userModel == null)
        {
            return NotFound();
        }

        UserDTO userDTO = mapper.Map<UserDTO>(userModel);
        return Ok(userDTO);
    }

    /// <summary>
    /// Soft delete a user by setting the IsDeleted property to true.
    /// </summary>
    [HttpDelete]
    [Route("Softdelete/{id:Guid}")]
    public async Task<IActionResult> SoftDelete([FromRoute] Guid id)
    {
        var userModel = await userRepository.SoftDeleteAsync(id);

        if (userModel == null)
        {
            return NotFound();
        }

        DeleteUserRequestDTO userDTO = mapper.Map<DeleteUserRequestDTO>(userModel);
        return Ok(userDTO);
    }

    /// <summary>
    /// Permanently delete a user.
    /// </summary>
    [HttpDelete]
    [Route("{id:Guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var userModel = await userRepository.DeleteAsync(id);

        if (userModel == null)
        {
            return NotFound();
        }

        UserDTO userDTO = mapper.Map<UserDTO>(userModel);
        return Ok(userDTO);
    }
}
