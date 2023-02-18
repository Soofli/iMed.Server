using System;
using System.Linq.Expressions;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Entities;

namespace iMed.Domain.Mappers
{
    public static partial class VideoMapper
    {
        public static Video AdaptToVideo(this VideoSDto p1)
        {
            return p1 == null ? null : new Video()
            {
                VideoId = p1.VideoId,
                Row = p1.Row,
                Name = p1.Name,
                VideoTime = p1.VideoTime,
                FileLocation = p1.FileLocation,
                FileName = p1.FileName,
                IsFree = p1.IsFree,
                CourseId = p1.CourseId,
                CreatedAt = p1.CreatedAt
            };
        }
        public static Video AdaptTo(this VideoSDto p2, Video p3)
        {
            if (p2 == null)
            {
                return null;
            }
            Video result = p3 ?? new Video();
            
            result.VideoId = p2.VideoId;
            result.Row = p2.Row;
            result.Name = p2.Name;
            result.VideoTime = p2.VideoTime;
            result.FileLocation = p2.FileLocation;
            result.FileName = p2.FileName;
            result.IsFree = p2.IsFree;
            result.CourseId = p2.CourseId;
            result.CreatedAt = p2.CreatedAt;
            return result;
            
        }
        public static Expression<Func<VideoSDto, Video>> ProjectToVideo => p4 => new Video()
        {
            VideoId = p4.VideoId,
            Row = p4.Row,
            Name = p4.Name,
            VideoTime = p4.VideoTime,
            FileLocation = p4.FileLocation,
            FileName = p4.FileName,
            IsFree = p4.IsFree,
            CourseId = p4.CourseId,
            CreatedAt = p4.CreatedAt
        };
        public static VideoSDto AdaptToSDto(this Video p5)
        {
            return p5 == null ? null : new VideoSDto()
            {
                VideoId = p5.VideoId,
                Name = p5.Name,
                Row = p5.Row,
                VideoTime = p5.VideoTime,
                FileLocation = p5.FileLocation,
                FileName = p5.FileName,
                CourseId = p5.CourseId,
                IsFree = p5.IsFree,
                CreatedAt = p5.CreatedAt
            };
        }
        public static VideoSDto AdaptTo(this Video p6, VideoSDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            VideoSDto result = p7 ?? new VideoSDto();
            
            result.VideoId = p6.VideoId;
            result.Name = p6.Name;
            result.Row = p6.Row;
            result.VideoTime = p6.VideoTime;
            result.FileLocation = p6.FileLocation;
            result.FileName = p6.FileName;
            result.CourseId = p6.CourseId;
            result.IsFree = p6.IsFree;
            result.CreatedAt = p6.CreatedAt;
            return result;
            
        }
        public static Expression<Func<Video, VideoSDto>> ProjectToSDto => p8 => new VideoSDto()
        {
            VideoId = p8.VideoId,
            Name = p8.Name,
            Row = p8.Row,
            VideoTime = p8.VideoTime,
            FileLocation = p8.FileLocation,
            FileName = p8.FileName,
            CourseId = p8.CourseId,
            IsFree = p8.IsFree,
            CreatedAt = p8.CreatedAt
        };
    }
}