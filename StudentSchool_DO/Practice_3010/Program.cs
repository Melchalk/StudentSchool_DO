using DBModels;
using Provider;

var userRepository = new UserRepository();

List<DBUser> users = userRepository.GetUsersEF();

var newUser = new DBUser()
{
    id = Guid.NewGuid(),
    FirstName = "Mary",
    LastName = "Mel"
};

userRepository.CreateUser(newUser);

foreach (var user in users)
{
    Console.WriteLine($"{user.id} - {user.FirstName} - {user.LastName}");
}