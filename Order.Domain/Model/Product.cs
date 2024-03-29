﻿using Order.Domain.DomainValidations;

namespace Order.Domain.Model;

/// <summary>
///     Klasa koja se odnosi na proizvode
/// </summary>
public class Product
{
    private decimal? _discount;
    private int? _id;
    private string _name;
    private decimal _price;

    /// <summary>
    ///     Bezparametarski konstruktor klase Product
    /// </summary>
    public Product()
    {
    }

    /// <summary>
    ///     Parametarski konstruktor klase Product
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="price"></param>
    /// <param name="discount"></param>
    public Product(int id, string name, decimal price, decimal? discount)
    {
        Id = id;
        Name = name;
        Price = price;
        Discount = discount;
    }

    /// <summary>
    ///     Id proizvoda
    /// </summary>
    public int? Id
    {
        get => _id;
        set
        {
            Validations.NotNull(value);
            Validations.NumberNotNegativeOrEqualTo0(value);
            _id = value;
        }
    }

    /// <summary>
    ///     Ime proizvoda
    /// </summary>
    public string Name
    {
        get => _name;
        set
        {
            Validations.NotNullOrEmpty(value);
            Validations.StringLengthLessThanOrEqualTo(value, 25);
            _name = value;
        }
    }

    /// <summary>
    ///     Cena proizvoda
    /// </summary>
    public decimal Price
    {
        get => _price;
        set
        {
            Validations.NumberNotNegativeOrEqualTo0(value);
            _price = value;
        }
    }

    /// <summary>
    ///     Popust na proizvod
    /// </summary>
    public decimal? Discount
    {
        get => _discount;
        set
        {
            Validations.NumberNotNegativeOrEqualTo0(value);
            _discount = value;
        }
    }
}