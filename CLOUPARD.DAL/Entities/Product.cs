﻿using CLOUPARD.Domain;

namespace CLOUPARD.DAL.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string? Description { get; set; }
}
