﻿namespace ExpenseManager.Application.UserService
{
    public class CurrentUser
    {
        public CurrentUser(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}
