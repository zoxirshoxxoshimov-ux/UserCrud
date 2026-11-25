using System;
using System.Collections.Generic;
using ConsoleUserCrud.Models;

namespace ConsoleUserCrud.Services;

public class UserServices : IUserServices
{
    private readonly List<User> _users = new();

    // CREATE USER
    public void CreateUser(User user)
    {
        if (user == null)
        {
            Console.WriteLine("User cannot be empty.");
            return;
        }

        if (string.IsNullOrWhiteSpace(user.Name))
        {
            Console.WriteLine("Name cannot be empty.");
            return;
        }

        if (string.IsNullOrWhiteSpace(user.Email))
        {
            Console.WriteLine("Email cannot be empty.");
            return;
        }

        foreach (User existingUser in _users)
        {
            if (existingUser.Email == user.Email)
            {
                Console.WriteLine("This email already exists.");
                return;
            }
        }

        User newUser = new User();

        newUser.Id = user.Id;
        newUser.Name = user.Name;
        newUser.Email = user.Email;
        newUser.Age = user.Age;
        newUser.PhoneNumber = user.PhoneNumber;

        _users.Add(newUser);

        Console.WriteLine("User created successfully.");
    }

    public User GetUserById(int userId)
    {
        foreach (User user in _users)
        {
            if (user.Id == userId)
            {
                User foundUser = new User();

                foundUser.Id = user.Id;
                foundUser.Name = user.Name;
                foundUser.Email = user.Email;
                foundUser.Age = user.Age;
                foundUser.PhoneNumber = user.PhoneNumber;

                return foundUser;
            }
        }

        return null;
    }

    public void PrintUser(User user)
    {
        if (user == null)
        {
            Console.WriteLine("User not found.");
            return;
        }

        Console.WriteLine("ID: " + user.Id);
        Console.WriteLine("Name: " + user.Name);
        Console.WriteLine("Email: " + user.Email);
        Console.WriteLine("Age: " + user.Age);
        Console.WriteLine("Phone: " + user.PhoneNumber);
    }

    public User[] GetAllUsers()
    {
        User[] usersArray = new User[_users.Count];

        for (int i = 0; i < _users.Count; i++)
        {
            User copiedUser = new User();

            copiedUser.Id = _users[i].Id;
            copiedUser.Name = _users[i].Name;
            copiedUser.Email = _users[i].Email;
            copiedUser.Age = _users[i].Age;
            copiedUser.PhoneNumber = _users[i].PhoneNumber;

            usersArray[i] = copiedUser;
        }

        return usersArray;
    }

    public void UpdateUser(User user)
    {
        if (user == null)
        {
            Console.WriteLine("User cannot be empty.");
            return;
        }

        foreach (User existingUser in _users)
        {
            if (existingUser.Id == user.Id)
            {
                if (string.IsNullOrWhiteSpace(user.Name))
                {
                    Console.WriteLine("Name cannot be empty.");
                    return;
                }

                if (string.IsNullOrWhiteSpace(user.Email))
                {
                    Console.WriteLine("Email cannot be empty.");
                    return;
                }

                foreach (User otherUser in _users)
                {
                    if (otherUser.Email == user.Email &&
                        otherUser.Id != user.Id)
                    {
                        Console.WriteLine("This email is already in use.");
                        return;
                    }
                }

                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
                existingUser.Age = user.Age;
                existingUser.PhoneNumber = user.PhoneNumber;

                Console.WriteLine("User updated successfully.");
                return;
            }
        }

        Console.WriteLine("User not found.");
    }

    public void DeleteUser(int id)
    {
        foreach (User user in _users)
        {
            if (user.Id == id)
            {
                _users.Remove(user);
                Console.WriteLine("User deleted successfully.");
                return;
            }
        }

        Console.WriteLine("User not found.");
    }
}
