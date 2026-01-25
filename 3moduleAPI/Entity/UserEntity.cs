namespace _3moduleAPI.Entity;

public class UserEntity
{
    public UserEntity()
    {
    }

    public UserEntity(Guid id, string name, string password)
    {
        Id = id;
        Name = name;
        Password = password;
    }

    public UserEntity(string name, string password)
    {
        Name = name;
        Password = password;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public string Password { get; set; } = null!;

    public static UserEntity Create(Guid id, string name, string password)
    {
        return new UserEntity(id, name, password);
    }

    public static UserEntity Create(string name, string password)
    {
        return new UserEntity(name, password);
    }
}