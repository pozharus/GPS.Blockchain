using AutoMapper;
using Blockchain.Application.Common.Mappings;
using Blockchain.Application.Points.Commands.CreatePoint;
using System.ComponentModel.DataAnnotations;

namespace Blockchain.WebApi.Models
{
    public class CreatePointDto : IMapWith<CreatePointCommand>
    {
        [Required]
        public string timestamp { get; set; }
        [Required]
        public float latitude { get; set; }
        [Required]
        public float longitude { get; set; }
        public float altitude { get; set; }
        public float speed { get; set; }
        public int satelites { get; set; }
        public float delusionOfPresition { get; set; }
        public float horizontalDelusionOfPresition { get; set; }
        public float verticalDelusionOfPresition { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreatePointDto, CreatePointCommand>()
                .ForMember(point => point.timestamp,
                    opt => opt.MapFrom(point => point.timestamp))
                .ForMember(point => point.latitude,
                    opt => opt.MapFrom(point => point.latitude))
                .ForMember(point => point.longitude,
                    opt => opt.MapFrom(point => point.longitude))
                .ForMember(point => point.altitude,
                    opt => opt.MapFrom(point => point.altitude))
                .ForMember(point => point.speed,
                    opt => opt.MapFrom(point => point.speed))
                .ForMember(point => point.satelites,
                    opt => opt.MapFrom(point => point.satelites))
                .ForMember(point => point.delusionOfPresition,
                    opt => opt.MapFrom(point => point.delusionOfPresition))
                .ForMember(point => point.horizontalDelusionOfPresition,
                    opt => opt.MapFrom(point => point.horizontalDelusionOfPresition))
                .ForMember(point => point.verticalDelusionOfPresition,
                    opt => opt.MapFrom(point => point.verticalDelusionOfPresition));
        }
    }
}
