using System;
using System.Linq;
using AutoFixture;
using FluentAssertions;
using GlobalBlue.VATCalculator.Data.Repository.Interfaces;
using GlobalBlue.VATCalculator.Model.Entities;
using GlobalBlue.VATCalculator.Service;
using GlobalBlue.VATCalculator.Service.Abstractions;
using NSubstitute;
using Xunit;

namespace GlobalBlue.VATCalculator.Test.Service;

public class CountryRateServiceTests
{
    private readonly IFixture _fixture;

    private readonly ICountryRateRepository _countryRateRepository;

    private readonly ICountryRateService _countryRateService;

    public CountryRateServiceTests()
    {
        _fixture = new Fixture();

        _countryRateRepository = Substitute.For<ICountryRateRepository>();

        _countryRateService = new CountryRateService(_countryRateRepository);
    }

}