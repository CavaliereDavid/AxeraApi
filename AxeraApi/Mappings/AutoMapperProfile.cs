using AutoMapper;
using AxeraApi.Domain.DTO;
using AxeraApi.Domain.Models;

namespace AxeraApi.Mappings;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CourseDTO, Course>().ReverseMap();
        CreateMap<AddCourseRequestDTO, Course>().ReverseMap();
        CreateMap<UpdateCourseRequestDTO, Course>().ReverseMap();
        CreateMap<DeleteCourseRequestDTO, Course>().ReverseMap();

        CreateMap<MeetingDTO, Meeting>().ReverseMap();
        CreateMap<CreateMeetingRequestDTO, Meeting>().ReverseMap();
        CreateMap<UpdateMeetingRequestDTO, Meeting>().ReverseMap();
        CreateMap<DeleteMeetingRequestDTO, Meeting>().ReverseMap();

        CreateMap<ReservationDTO, Reservation>().ReverseMap();
        CreateMap<CreateReservationRequestDTO, Reservation>().ReverseMap();
        CreateMap<UpdateReservationRequestDTO, Reservation>().ReverseMap();
        CreateMap<DeleteReservationRequestDTO, Reservation>().ReverseMap();

        CreateMap<UserDTO, User>().ReverseMap();
        CreateMap<AddUserRequestDTO, User>().ReverseMap();
        CreateMap<UpdateUserRequestDTO, User>().ReverseMap();
        CreateMap<DeleteUserRequestDTO, User>().ReverseMap();

    }
}
