using System;
using System.Linq.Expressions;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Entities;

namespace iMed.Domain.Mappers
{
    public static partial class CourseHandoutMapper
    {
        public static CourseHandout AdaptToCourseHandout(this CourseHandoutSDto p1)
        {
            return p1 == null ? null : new CourseHandout()
            {
                HandoutId = p1.HandoutId,
                Name = p1.Name,
                Detail = p1.Detail,
                FileLocation = p1.FileLocation,
                FileName = p1.FileName,
                CreatedAt = p1.CreatedAt
            };
        }
        public static CourseHandout AdaptTo(this CourseHandoutSDto p2, CourseHandout p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CourseHandout result = p3 ?? new CourseHandout();
            
            result.HandoutId = p2.HandoutId;
            result.Name = p2.Name;
            result.Detail = p2.Detail;
            result.FileLocation = p2.FileLocation;
            result.FileName = p2.FileName;
            result.CreatedAt = p2.CreatedAt;
            return result;
            
        }
        public static Expression<Func<CourseHandoutSDto, CourseHandout>> ProjectToCourseHandout => p4 => new CourseHandout()
        {
            HandoutId = p4.HandoutId,
            Name = p4.Name,
            Detail = p4.Detail,
            FileLocation = p4.FileLocation,
            FileName = p4.FileName,
            CreatedAt = p4.CreatedAt
        };
        public static CourseHandoutSDto AdaptToSDto(this CourseHandout p5)
        {
            return p5 == null ? null : new CourseHandoutSDto()
            {
                HandoutId = p5.HandoutId,
                Name = p5.Name,
                Detail = p5.Detail,
                FileLocation = p5.FileLocation,
                FileName = p5.FileName,
                CreatedAt = p5.CreatedAt
            };
        }
        public static CourseHandoutSDto AdaptTo(this CourseHandout p6, CourseHandoutSDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            CourseHandoutSDto result = p7 ?? new CourseHandoutSDto();
            
            result.HandoutId = p6.HandoutId;
            result.Name = p6.Name;
            result.Detail = p6.Detail;
            result.FileLocation = p6.FileLocation;
            result.FileName = p6.FileName;
            result.CreatedAt = p6.CreatedAt;
            return result;
            
        }
        public static Expression<Func<CourseHandout, CourseHandoutSDto>> ProjectToSDto => p8 => new CourseHandoutSDto()
        {
            HandoutId = p8.HandoutId,
            Name = p8.Name,
            Detail = p8.Detail,
            FileLocation = p8.FileLocation,
            FileName = p8.FileName,
            CreatedAt = p8.CreatedAt
        };
    }
}