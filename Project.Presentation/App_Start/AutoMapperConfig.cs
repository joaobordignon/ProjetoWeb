using AutoMapper;
using Project.DAL.Entities;
using Project.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Presentation.App_Start
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<EstoqueCadastroModel, Estoque>();
            CreateMap<Estoque, EstoqueConsultaModel>();
        }
    }
}