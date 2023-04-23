using DeliveryService.DTO;
using DeliveryService.Model;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryService.Mappers
{
    public static class AddressMapper
    {
        private static DsContext _context = App.ServiceProvider.GetRequiredService<DsContext>();

        public static AddressDTO Map(Address address)
        {
            return new AddressDTO
            {
                Id = address.Id,
                Country = address.Country?.Title,
                City = address.City?.Title,
                Street = address.Street?.Title,
                House = address.House?.Number,
                Postcode = address.Postcode
            };
        }

        public static void Map(AddressDTO addressDto, Address address)
        {
            address.Postcode = addressDto.Postcode;

            if (addressDto.CountryId != null)
            {
                if (addressDto.Country != null)
                {
                    Country? country = _context.Countries.FirstOrDefault(x => x.Title == addressDto.Country);
                    if (country != null)
                    {
                        address.CountryId = country.Id;
                        address.Country = country;
                    }
                    else
                    {
                        country = _context.Countries.Find(addressDto.CountryId);
                        if (country != null)
                        {
                            country.Title = addressDto.Country;

                            _context.Countries.Update(country);
                            _context.SaveChanges();

                            address.CountryId = country.Id;
                            address.Country = country;
                        }
                        else
                        {
                            country = new Country() { Title = addressDto.Country };

                            _context.Countries.Add(country);
                            _context.SaveChanges();

                            address.CountryId = null;
                            address.Country = country;
                        }
                    }
                }
                else
                {
                    Country? country = _context.Countries.Find(addressDto.CountryId);
                    if (country != null)
                    {
                        address.CountryId = country.Id;
                        address.Country = country;
                    }
                    else
                    {
                        address.CountryId = null;
                        address.Country = null;
                    }
                }
            }
            else
            {
                if (addressDto.Country != null)
                {
                    Country? country = _context.Countries.FirstOrDefault(x => x.Title == addressDto.Country);
                    if (country != null)
                    {
                        address.CountryId = country.Id;
                        address.Country = country;
                    }
                    else
                    {
                        country = new Country() { Title = addressDto.Country };

                        _context.Countries.Add(country);
                        _context.SaveChanges();

                        address.CountryId = null;
                        address.Country = country;
                    }
                }
                else
                {
                    address.CountryId = null;
                    address.Country = null;
                }
            }

            if (addressDto.CityId != null)
            {
                if (addressDto.City != null)
                {
                    City? city = _context.Cities.FirstOrDefault(x => x.Title == addressDto.City);
                    if (city != null)
                    {
                        address.CityId = city.Id;
                        address.City = city;
                    }
                    else
                    {
                        city = _context.Cities.Find(addressDto.CityId);
                        if (city != null)
                        {
                            city.Title = addressDto.City;

                            _context.Cities.Update(city);
                            _context.SaveChanges();

                            address.CityId = city.Id;
                            address.City = city;
                        }
                        else
                        {
                            city = new City() { Title = addressDto.City };

                            _context.Cities.Add(city);
                            _context.SaveChanges();

                            address.CityId = null;
                            address.City = city;
                        }
                    }
                }
                else
                {
                    City? city = _context.Cities.Find(addressDto.CityId);
                    if (city != null)
                    {
                        address.CityId = city.Id;
                        address.City = city;
                    }
                    else
                    {
                        address.CityId = null;
                        address.City = null;
                    }
                }
            }
            else
            {
                if (addressDto.City != null)
                {
                    City? city = _context.Cities.FirstOrDefault(x => x.Title == addressDto.City);
                    if (city != null)
                    {
                        address.CityId = city.Id;
                        address.City = city;
                    }
                    else
                    {
                        city = new City() { Title = addressDto.City };

                        _context.Cities.Add(city);
                        _context.SaveChanges();

                        address.CityId = null;
                        address.City = city;
                    }
                }
                else
                {
                    address.CityId = null;
                    address.City = null;
                }
            }

            if (addressDto.StreetId != null)
            {
                if (addressDto.Street != null)
                {
                    Street? street = _context.Streets.FirstOrDefault(x => x.Title == addressDto.Street);
                    if (street != null)
                    {
                        address.StreetId = street.Id;
                        address.Street = street;
                    }
                    else
                    {
                        street = _context.Streets.Find(addressDto.StreetId);
                        if (street != null)
                        {
                            street.Title = addressDto.Street;

                            _context.Streets.Update(street);
                            _context.SaveChanges();

                            address.StreetId = street.Id;
                            address.Street = street;
                        }
                        else
                        {
                            street = new Street() { Title = addressDto.Street };

                            _context.Streets.Add(street);
                            _context.SaveChanges();

                            address.StreetId = null;
                            address.Street = street;
                        }
                    }
                }
                else
                {
                    Street? street = _context.Streets.Find(addressDto.StreetId);
                    if (street != null)
                    {
                        address.StreetId = street.Id;
                        address.Street = street;
                    }
                    else
                    {
                        address.StreetId = null;
                        address.Street = null;
                    }
                }
            }
            else
            {
                if (addressDto.Street != null)
                {
                    Street? street = _context.Streets.FirstOrDefault(x => x.Title == addressDto.Street);
                    if (street != null)
                    {
                        address.StreetId = street.Id;
                        address.Street = street;
                    }
                    else
                    {
                        street = new Street() { Title = addressDto.Street };

                        _context.Streets.Add(street);
                        _context.SaveChanges();

                        address.StreetId = null;
                        address.Street = street;
                    }
                }
                else
                {
                    address.StreetId = null;
                    address.Street = null;
                }
            }

            if (addressDto.HouseId != null)
            {
                if (addressDto.House != null)
                {
                    House? house = _context.Houses.FirstOrDefault(x => x.Number == addressDto.House);
                    if (house != null)
                    {
                        address.HouseId = house.Id;
                        address.House = house;
                    }
                    else
                    {
                        house = _context.Houses.Find(addressDto.HouseId);
                        if (house != null)
                        {
                            house.Number = addressDto.House;

                            _context.Houses.Update(house);
                            _context.SaveChanges();

                            address.HouseId = house.Id;
                            address.House = house;
                        }
                        else
                        {
                            house = new House() { Number = addressDto.House };

                            _context.Houses.Add(house);
                            _context.SaveChanges();

                            address.HouseId = null;
                            address.House = house;
                        }
                    }
                }
                else
                {
                    House? house = _context.Houses.Find(addressDto.HouseId);
                    if (house != null)
                    {
                        address.HouseId = house.Id;
                        address.House = house;
                    }
                    else
                    {
                        address.HouseId = null;
                        address.House = null;
                    }
                }
            }
            else
            {
                if (addressDto.House != null)
                {
                    House? house = _context.Houses.FirstOrDefault(x => x.Number == addressDto.House);
                    if (house != null)
                    {
                        address.HouseId = house.Id;
                        address.House = house;
                    }
                    else
                    {
                        house = new House() { Number = addressDto.House };

                        _context.Houses.Add(house);
                        _context.SaveChanges();

                        address.HouseId = null;
                        address.House = house;
                    }
                }
                else
                {
                    address.HouseId = null;
                    address.House = null;
                }
            }
        }

        public static IEnumerable<AddressDTO> MapAll(IEnumerable<Address> addresses)
        {
            return addresses.ToList().ConvertAll(Map);
        }
    }
}
