﻿namespace Domain.Models;

public class User
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public int Id { get; set; }
    public int SecurityLevel { get; set; }
}