using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Nebula.Cinema.Domain.Models.AggregateRoots;

namespace Cinema.Website.Areas.Manager.Models
{
    public class MovieView : Movie
    {
        static MovieView()
        {
            //Mapper
        }
    }

    public static class MovieDtoExtension
    {
        public static MovieView ViewModel(this Movie value)
        {
            
        }

    }
}
