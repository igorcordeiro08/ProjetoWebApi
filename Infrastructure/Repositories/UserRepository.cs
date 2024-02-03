using Domain.Entities;

namespace Infrastructure.Repositories;


public interface IUserRepository
{
    List<User> List();
    User? GetById(int id);
    User Create(User newUser);
    User? FindByEmail(string email);
    User Update(User updatedUser);
    void Delete(int id);
}
public class UserRepository: IUserRepository
    {
    private List<User> _users = new List<User>();// "Banco de Dados"

    public List<User> List() 
    {
        return _users;
    }
    public User? GetById(int id)
    {
        return _users.FirstOrDefault(x => x.Id == id);
    }
    public User? FindByEmail(string email)
    {
        return _users.FirstOrDefault(x=>x.Email== email);
    }

    public User Create(User newUser)
    {
        newUser.Id = _users.Count + 1;
        _users.Add(newUser);
        return newUser;
         

    }

    public User Update(User updatedUser)
    {
        //var user = GetById(updatedUser.Id);
        var user=_users.FirstOrDefault(x=>x.Id==updatedUser.Id);

        if (user is null)
            throw new Exception("User not found");

        user.Name= updatedUser.Name;
        user.Email= updatedUser.Email;
        user.Password= updatedUser.Password;
        return user;

    }
    public void Delete(int id)
    {
        var user=GetById(id);
        if (user is null)
            throw new Exception("User not found");
        _users.Remove(user);
    }







}

