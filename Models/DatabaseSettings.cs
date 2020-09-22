﻿using System;
namespace TracerBreaker.Models
{
    public class DatabaseSettings: IDatabaseSettings
    {
           public string CollectionName { get; set; }
           public string ConnectionString { get; set; }
           public string DatabaseName { get; set; }
    }

    public interface IDatabaseSettings
    {
            string CollectionName { get; set; }
            string ConnectionString { get; set; }
            string DatabaseName { get; set; }
     }
}
