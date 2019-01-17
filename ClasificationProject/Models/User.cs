﻿using System.Collections.Generic;

namespace ClasificationProject.Models
{
    public class User
    {
        public string Ip { get; set; }
        public List<Session> UserSession { get; set; }
        public double AverageNumberOfRequest { get; set; }

        public User()
        {
            UserSession = new List<Session>();
        }
    }
}