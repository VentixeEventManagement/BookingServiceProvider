﻿using System.ComponentModel.DataAnnotations;
namespace Data.Entities;

public class BookingLocationEntity
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string State { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
}


