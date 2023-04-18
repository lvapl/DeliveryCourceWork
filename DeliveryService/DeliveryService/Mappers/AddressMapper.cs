using DeliveryService.DTO;
using DeliveryService.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Mappers
{
    public class AddressMapper
    {
        private static DsContext _context = App.ServiceProvider.GetRequiredService<DsContext>();

        public static AddressDTO Map(Address address)
        {
            return new AddressDTO
            {
                Id = address.Id,
                Country = address.Country == null ? null : address.Country.Title,
                City = address.City == null ? null : address.City.Title,
                Street = address.Street == null ? null : address.Street.Title,
                House = address.House == null ? null : address.House.Number,
                Postcode = address.Postcode
            };
        }

        public static void Map(AddressDTO addressDTO, Address address)
        {
            address.Postcode = addressDTO.Postcode;

            if (addressDTO.CountryId != null)
            {
                if (addressDTO.Country != null)
                {
                    Country? country = _context.Countries.FirstOrDefault(x => x.Title == addressDTO.Country);
                    if (country != null)
                    {
                        address.CountryId = country.Id;
                        address.Country = country;
                    }
                    else
                    {
                        country = _context.Countries.Find(addressDTO.CountryId);
                        if (country != null)
                        {
                            country.Title = addressDTO.Country;

                            _context.Countries.Update(country);
                            _context.SaveChanges();

                            address.CountryId = country.Id;
                            address.Country = country;
                        }
                        else
                        {
                            country = new Country() { Title = addressDTO.Country };

                            _context.Countries.Add(country);
                            _context.SaveChanges();

                            address.CountryId = null;
                            address.Country = country;
                        }
                    }
                }
                else
                {
                    Country? country = _context.Countries.Find(addressDTO.CountryId);
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
                if (addressDTO.Country != null)
                {
                    Country? country = _context.Countries.FirstOrDefault(x => x.Title == addressDTO.Country);
                    if (country != null)
                    {
                        address.CountryId = country.Id;
                        address.Country = country;
                    }
                    else
                    {
                        country = new Country() { Title = addressDTO.Country };

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

            if (addressDTO.CityId != null)
            {
                if (addressDTO.City != null)
                {
                    City? city = _context.Cities.FirstOrDefault(x => x.Title == addressDTO.City);
                    if (city != null)
                    {
                        address.CityId = city.Id;
                        address.City = city;
                    }
                    else
                    {
                        city = _context.Cities.Find(addressDTO.CityId);
                        if (city != null)
                        {
                            city.Title = addressDTO.City;

                            _context.Cities.Update(city);
                            _context.SaveChanges();

                            address.CityId = city.Id;
                            address.City = city;
                        }
                        else
                        {
                            city = new City() { Title = addressDTO.City };

                            _context.Cities.Add(city);
                            _context.SaveChanges();

                            address.CityId = null;
                            address.City = city;
                        }
                    }
                }
                else
                {
                    City? city = _context.Cities.Find(addressDTO.CityId);
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
                if (addressDTO.City != null)
                {
                    City? city = _context.Cities.FirstOrDefault(x => x.Title == addressDTO.City);
                    if (city != null)
                    {
                        address.CityId = city.Id;
                        address.City = city;
                    }
                    else
                    {
                        city = new City() { Title = addressDTO.City };

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

            if (addressDTO.StreetId != null)
            {
                if (addressDTO.Street != null)
                {
                    Street? street = _context.Streets.FirstOrDefault(x => x.Title == addressDTO.Street);
                    if (street != null)
                    {
                        address.StreetId = street.Id;
                        address.Street = street;
                    }
                    else
                    {
                        street = _context.Streets.Find(addressDTO.StreetId);
                        if (street != null)
                        {
                            street.Title = addressDTO.Street;

                            _context.Streets.Update(street);
                            _context.SaveChanges();

                            address.StreetId = street.Id;
                            address.Street = street;
                        }
                        else
                        {
                            street = new Street() { Title = addressDTO.Street };

                            _context.Streets.Add(street);
                            _context.SaveChanges();

                            address.StreetId = null;
                            address.Street = street;
                        }
                    }
                }
                else
                {
                    Street? street = _context.Streets.Find(addressDTO.StreetId);
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
                if (addressDTO.Street != null)
                {
                    Street? street = _context.Streets.FirstOrDefault(x => x.Title == addressDTO.Street);
                    if (street != null)
                    {
                        address.StreetId = street.Id;
                        address.Street = street;
                    }
                    else
                    {
                        street = new Street() { Title = addressDTO.Street };

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

            if (addressDTO.HouseId != null)
            {
                if (addressDTO.House != null)
                {
                    House? house = _context.Houses.FirstOrDefault(x => x.Number == addressDTO.House);
                    if (house != null)
                    {
                        address.HouseId = house.Id;
                        address.House = house;
                    }
                    else
                    {
                        house = _context.Houses.Find(addressDTO.HouseId);
                        if (house != null)
                        {
                            house.Number = addressDTO.House;

                            _context.Houses.Update(house);
                            _context.SaveChanges();

                            address.HouseId = house.Id;
                            address.House = house;
                        }
                        else
                        {
                            house = new House() { Number = addressDTO.House };

                            _context.Houses.Add(house);
                            _context.SaveChanges();

                            address.HouseId = null;
                            address.House = house;
                        }
                    }
                }
                else
                {
                    House? house = _context.Houses.Find(addressDTO.HouseId);
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
                if (addressDTO.House != null)
                {
                    House? house = _context.Houses.FirstOrDefault(x => x.Number == addressDTO.House);
                    if (house != null)
                    {
                        address.HouseId = house.Id;
                        address.House = house;
                    }
                    else
                    {
                        house = new House() { Number = addressDTO.House };

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
            return addresses.ToList().ConvertAll<AddressDTO>(x => Map(x));
        }
    }
}
