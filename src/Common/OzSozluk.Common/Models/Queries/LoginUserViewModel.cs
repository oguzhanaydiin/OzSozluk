﻿namespace OzSozluk.Common.Models.Queries;

public class LoginUserViewModel

{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Token { get; set; }

}
