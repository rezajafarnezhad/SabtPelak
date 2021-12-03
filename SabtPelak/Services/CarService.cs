using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using SabtPelak.Data;
using SabtPelak.Entities;
using SabtPelak.Models.Dto;

namespace SabtPelak.Services
{


    public interface ICarService
    {
        Task Delete(int id);
        Task Save(CarDto carDto);
        Task<CarDto> GetById(int carid);
        Task Update(CarDto carDto);
        Task<List<CarDto>> GetAll();
    }



    public class CarService: ICarService
    {

        private readonly DataBaseContext _context;

        public CarService(DataBaseContext context)
        {
            _context = context;
        }

        public async Task Delete(int id)
        {
            var _Car = await _context.Cars.FindAsync(id);

            if (_Car != null)
            {
                _context.Cars.Remove(_Car);
                await _context.SaveChangesAsync();
            }
            
        }


        public async Task Save(CarDto carDto)
        {
            var _Car = new tblCar();

            _Car.Name = carDto.Name;
            _Car.Color = carDto.Color;
            _Car.Year = carDto.Year;
            _Car.Pelak = carDto.Pelak;

            await _context.Cars.AddAsync(_Car);
            await _context.SaveChangesAsync();

        }

        public async Task<CarDto> GetById(int carid)
        {
            var _Car = await _context.Cars.Where(c=>c.Id == carid).Select(c => new CarDto()
            {
                Color = c.Color,
                Pelak = c.Pelak,
                Name = c.Name,
                Year = c.Year

            }).SingleOrDefaultAsync();

            return _Car;
        }

        public async Task Update(CarDto carDto)
        {
            var _Car = await _context.Cars.FindAsync(carDto.Id);

            _Car.Name = carDto.Name;
            _Car.Color = carDto.Color;
            _Car.Year = carDto.Year;
            _Car.Pelak = carDto.Pelak;

            _context.Cars.Update(_Car);
            await _context.SaveChangesAsync();      


        }

        public async Task<List<CarDto>> GetAll()
        {
           var cars= await _context.Cars.Select(c => new CarDto()
            {
                Id = c.Id,
                Name = c.Name,
                Pelak = c.Pelak,
                Color = c.Color,
                Year = c.Year,

            }).ToListAsync();

           return cars;

        }


    }
}
