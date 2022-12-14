using AutoMapper;
using Blockchain.Application.Common.Mappings;
using Blockchain.Domain;
using System;

namespace Blockchain.Application.Points.Queries.GetPointList
{
    public class PointListLookupDto : IMapWith<TrackerPoint>
    {
        public string id { get; set; }
        public DateTime timestamp { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TrackerPoint, PointListLookupDto>()
                .ForMember(pointDto => pointDto.id,
                    opt => opt.MapFrom(pointDto => pointDto.id))
                .ForMember(pointDto => pointDto.timestamp,
                    opt => opt.MapFrom(pointDto => pointDto.timestamp))
                .ForMember(pointDto => pointDto.latitude,
                    opt => opt.MapFrom(pointDto => pointDto.latitude))
                .ForMember(pointDto => pointDto.longitude,
                    opt => opt.MapFrom(pointDto => pointDto.longitude));
        }
    }
}