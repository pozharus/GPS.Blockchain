using AutoMapper;
using Blockchain.Application.Common.Mappings;
using Blockchain.Domain;
using System;

namespace Blockchain.Application.Points.Queries.GetPointDetails
{
    public class PointDetailsVm : IMapWith<TrackerPoint>
    {
        public Guid Id { get; set; }
        public DateTime timestamp { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public float altitude { get; set; }
        public float speed { get; set; }
        public int satelites { get; set; }
        public float delusionOfPresition { get; set; }
        public float horizontalDelusionOfPresition { get; set; }
        public float verticalDelusionOfPresition { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TrackerPoint, PointDetailsVm>()
                .ForMember(pointDto => pointDto.Id,
                    opt => opt.MapFrom(pointDto => pointDto.Id))
                .ForMember(pointDto => pointDto.timestamp,
                    opt => opt.MapFrom(pointDto => pointDto.timestamp))
                .ForMember(pointDto => pointDto.latitude,
                    opt => opt.MapFrom(pointDto => pointDto.latitude))
                .ForMember(pointDto => pointDto.longitude,
                    opt => opt.MapFrom(pointDto => pointDto.longitude))
                .ForMember(pointDto => pointDto.altitude,
                    opt => opt.MapFrom(pointDto => pointDto.altitude))
                .ForMember(pointDto => pointDto.speed,
                    opt => opt.MapFrom(pointDto => pointDto.speed))
                .ForMember(pointDto => pointDto.satelites,
                    opt => opt.MapFrom(pointDto => pointDto.satelites))
                .ForMember(pointDto => pointDto.delusionOfPresition,
                    opt => opt.MapFrom(pointDto => pointDto.delusionOfPresition))
                .ForMember(pointDto => pointDto.horizontalDelusionOfPresition,
                    opt => opt.MapFrom(pointDto => pointDto.horizontalDelusionOfPresition))
                .ForMember(pointDto => pointDto.verticalDelusionOfPresition,
                    opt => opt.MapFrom(pointDto => pointDto.verticalDelusionOfPresition));
        }
    }
}
