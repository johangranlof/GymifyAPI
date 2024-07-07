using api.Dtos.Exercise;
using api.Dtos.User;
using api.Models;

namespace api.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto(this User userModel)
        {
            return new UserDto
            {
                Id = userModel.Id,
                Name = userModel.Name,
                Email = userModel.Email,
            };
        }

        public static User ToUserFromCreateDto(this CreateUserRequestDto userDto)
        {
            return new User
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,

            };
        }

        public static void UpdateUserFromDto(this User user, UpdateUserRequestDto dto)
        {
            user.Name = dto.Name;
            user.Email = dto.Email;
        }
    }
}
