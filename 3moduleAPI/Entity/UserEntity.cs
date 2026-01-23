namespace _3moduleAPI.Entity
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;

        public string Password { get; set; } = null!;

        public UserEntity() { }
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

        public static UserEntity Create(Guid id, string name, string password) => new(id, name, password);
        public static UserEntity Create(string name, string password) => new(name, password);
    }
}
