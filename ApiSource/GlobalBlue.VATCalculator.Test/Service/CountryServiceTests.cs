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

public class CountryServiceTests
{
    private readonly IFixture _fixture;

    private readonly ICountryRepository _countryRepository;

    private readonly ICountryService _countryService;

    public CountryServiceTests()
    {
        _fixture = new Fixture();

        _countryRepository = Substitute.For<ICountryRepository>();

        _countryService = new CountryService(_countryRepository);
    }

    [Fact]
    public async void GetAllCountries_Should_Return_AllEntities()
    {
        var countries = _fixture.CreateMany<Country>();

        _countryRepository.ListAllAsync().Returns(countries);

        var result = await _countryService.GetAllCountries();

        result.Should().HaveCount(countries.Count());
    }
}