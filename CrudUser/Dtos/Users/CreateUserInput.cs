namespace CrudUser.Dtos.Users
{
    public record CreateUserInput(string Name, string LastName, string Email, bool IsActive);
}
