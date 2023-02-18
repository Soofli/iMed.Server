using System;
using System.Linq.Expressions;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Entities;
using Mapster.Models;

namespace iMed.Domain.Mappers
{
    public static partial class CourseRateMapper
    {
        public static CourseRate AdaptToCourseRate(this CourseRateSDto p1)
        {
            return p1 == null ? null : new CourseRate()
            {
                CourseId = p1.CourseId,
                Course = new Course() {Name = p1.CourseName},
                RateId = p1.RateId,
                RateMessage = p1.RateMessage,
                Author = p1.Author,
                Score = p1.Score,
                IsConfirmed = p1.IsConfirmed,
                CreatedAt = p1.CreatedAt
            };
        }
        public static CourseRate AdaptTo(this CourseRateSDto p2, CourseRate p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CourseRate result = p3 ?? new CourseRate();
            
            result.CourseId = p2.CourseId;
            result.Course = funcMain1(new Never(), result.Course, p2);
            result.RateId = p2.RateId;
            result.RateMessage = p2.RateMessage;
            result.Author = p2.Author;
            result.Score = p2.Score;
            result.IsConfirmed = p2.IsConfirmed;
            result.CreatedAt = p2.CreatedAt;
            return result;
            
        }
        public static Expression<Func<CourseRateSDto, CourseRate>> ProjectToCourseRate => p6 => new CourseRate()
        {
            CourseId = p6.CourseId,
            Course = new Course() {Name = p6.CourseName},
            RateId = p6.RateId,
            RateMessage = p6.RateMessage,
            Author = p6.Author,
            Score = p6.Score,
            IsConfirmed = p6.IsConfirmed,
            CreatedAt = p6.CreatedAt
        };
        public static CourseRateSDto AdaptToSDto(this CourseRate p7)
        {
            return p7 == null ? null : new CourseRateSDto()
            {
                RateId = p7.RateId,
                CourseId = p7.CourseId,
                CourseName = p7.Course != null ? p7.Course.Name : null,
                RateMessage = p7.RateMessage,
                Author = p7.Author,
                IsConfirmed = p7.IsConfirmed,
                Score = p7.Score,
                CreatedAt = p7.CreatedAt
            };
        }
        public static CourseRateSDto AdaptTo(this CourseRate p8, CourseRateSDto p9)
        {
            if (p8 == null)
            {
                return null;
            }
            CourseRateSDto result = p9 ?? new CourseRateSDto();
            
            result.RateId = p8.RateId;
            result.CourseId = p8.CourseId;
            result.CourseName = p8.Course != null ? p8.Course.Name : null;
            result.RateMessage = p8.RateMessage;
            result.Author = p8.Author;
            result.IsConfirmed = p8.IsConfirmed;
            result.Score = p8.Score;
            result.CreatedAt = p8.CreatedAt;
            return result;
            
        }
        public static Expression<Func<CourseRate, CourseRateSDto>> ProjectToSDto => p10 => new CourseRateSDto()
        {
            RateId = p10.RateId,
            CourseId = p10.CourseId,
            CourseName = p10.Course != null ? p10.Course.Name : null,
            RateMessage = p10.RateMessage,
            Author = p10.Author,
            IsConfirmed = p10.IsConfirmed,
            Score = p10.Score,
            CreatedAt = p10.CreatedAt
        };
        
        private static Course funcMain1(Never p4, Course p5, CourseRateSDto p2)
        {
            Course result = p5 ?? new Course();
            
            result.Name = p2.CourseName;
            return result;
            
        }
    }
}