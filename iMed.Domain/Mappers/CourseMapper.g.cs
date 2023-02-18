using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using iMed.Domain.Dtos.LargDtos;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Entities;
using Mapster;
using Mapster.Models;

namespace iMed.Domain.Mappers
{
    public static partial class CourseMapper
    {
        public static Course AdaptToCourse(this CourseSDto p1)
        {
            return p1 == null ? null : new Course()
            {
                CourseId = p1.CourseId,
                IsSuggested = p1.IsSuggested,
                Name = p1.Name,
                Detail = p1.Detail,
                Teacher = p1.Teacher,
                Reference = p1.Reference,
                IsFree = p1.IsFree,
                Price = p1.Price,
                CourseCategoryId = p1.CourseCategoryId,
                RateAvg = p1.RateAvg,
                CourseCategory = new CourseCategory() {Name = p1.CourseCategoryName},
                Image = new CourseImage() {FileName = p1.ImageFileName},
                CreatedAt = p1.CreatedAt
            };
        }
        public static Course AdaptTo(this CourseSDto p2, Course p3)
        {
            if (p2 == null)
            {
                return null;
            }
            Course result = p3 ?? new Course();
            
            result.CourseId = p2.CourseId;
            result.IsSuggested = p2.IsSuggested;
            result.Name = p2.Name;
            result.Detail = p2.Detail;
            result.Teacher = p2.Teacher;
            result.Reference = p2.Reference;
            result.IsFree = p2.IsFree;
            result.Price = p2.Price;
            result.CourseCategoryId = p2.CourseCategoryId;
            result.RateAvg = p2.RateAvg;
            result.CourseCategory = funcMain1(new Never(), result.CourseCategory, p2);
            result.Image = funcMain2(new Never(), result.Image, p2);
            result.CreatedAt = p2.CreatedAt;
            return result;
            
        }
        public static Expression<Func<CourseSDto, Course>> ProjectToCourse => p8 => new Course()
        {
            CourseId = p8.CourseId,
            IsSuggested = p8.IsSuggested,
            Name = p8.Name,
            Detail = p8.Detail,
            Teacher = p8.Teacher,
            Reference = p8.Reference,
            IsFree = p8.IsFree,
            Price = p8.Price,
            CourseCategoryId = p8.CourseCategoryId,
            RateAvg = p8.RateAvg,
            CourseCategory = new CourseCategory() {Name = p8.CourseCategoryName},
            Image = new CourseImage() {FileName = p8.ImageFileName},
            CreatedAt = p8.CreatedAt
        };
        public static CourseSDto AdaptToSDto(this Course p9)
        {
            return p9 == null ? null : new CourseSDto()
            {
                CourseId = p9.CourseId,
                Name = p9.Name,
                Detail = p9.Detail,
                Teacher = p9.Teacher,
                Reference = p9.Reference,
                IsFree = p9.IsFree,
                Price = p9.Price,
                IsSuggested = p9.IsSuggested,
                CourseCategoryId = p9.CourseCategoryId,
                CourseCategoryName = p9.CourseCategory != null ? p9.CourseCategory.Name : null,
                RateAvg = p9.RateAvg,
                ImageFileName = p9.Image != null ? p9.Image.FileName : null,
                CreatedAt = p9.CreatedAt
            };
        }
        public static CourseSDto AdaptTo(this Course p10, CourseSDto p11)
        {
            if (p10 == null)
            {
                return null;
            }
            CourseSDto result = p11 ?? new CourseSDto();
            
            result.CourseId = p10.CourseId;
            result.Name = p10.Name;
            result.Detail = p10.Detail;
            result.Teacher = p10.Teacher;
            result.Reference = p10.Reference;
            result.IsFree = p10.IsFree;
            result.Price = p10.Price;
            result.IsSuggested = p10.IsSuggested;
            result.CourseCategoryId = p10.CourseCategoryId;
            result.CourseCategoryName = p10.CourseCategory != null ? p10.CourseCategory.Name : null;
            result.RateAvg = p10.RateAvg;
            result.ImageFileName = p10.Image != null ? p10.Image.FileName : null;
            result.CreatedAt = p10.CreatedAt;
            return result;
            
        }
        public static Expression<Func<Course, CourseSDto>> ProjectToSDto => p12 => new CourseSDto()
        {
            CourseId = p12.CourseId,
            Name = p12.Name,
            Detail = p12.Detail,
            Teacher = p12.Teacher,
            Reference = p12.Reference,
            IsFree = p12.IsFree,
            Price = p12.Price,
            IsSuggested = p12.IsSuggested,
            CourseCategoryId = p12.CourseCategoryId,
            CourseCategoryName = p12.CourseCategory != null ? p12.CourseCategory.Name : null,
            RateAvg = p12.RateAvg,
            ImageFileName = p12.Image != null ? p12.Image.FileName : null,
            CreatedAt = p12.CreatedAt
        };
        public static Course AdaptToCourse(this CourseLDto p13)
        {
            return p13 == null ? null : new Course()
            {
                CourseId = p13.CourseId,
                IsSuggested = p13.IsSuggested,
                Name = p13.Name,
                Detail = p13.Detail,
                Teacher = p13.Teacher,
                Reference = p13.Reference,
                IsFree = p13.IsFree,
                Price = p13.Price,
                CourseCategoryId = p13.CourseCategoryId,
                CourseCategory = new CourseCategory() {Name = p13.CourseCategoryName},
                Image = funcMain3(p13.Image),
                Videos = funcMain32(p13.Videos),
                Handouts = funcMain33(p13.Handouts),
                CreatedAt = p13.CreatedAt
            };
        }
        public static Course AdaptTo(this CourseLDto p45, Course p46)
        {
            if (p45 == null)
            {
                return null;
            }
            Course result = p46 ?? new Course();
            
            result.CourseId = p45.CourseId;
            result.IsSuggested = p45.IsSuggested;
            result.Name = p45.Name;
            result.Detail = p45.Detail;
            result.Teacher = p45.Teacher;
            result.Reference = p45.Reference;
            result.IsFree = p45.IsFree;
            result.Price = p45.Price;
            result.CourseCategoryId = p45.CourseCategoryId;
            result.CourseCategory = funcMain34(new Never(), result.CourseCategory, p45);
            result.Image = funcMain35(p45.Image, result.Image);
            result.Videos = funcMain64(p45.Videos, result.Videos);
            result.Handouts = funcMain65(p45.Handouts, result.Handouts);
            result.CreatedAt = p45.CreatedAt;
            return result;
            
        }
        public static Expression<Func<CourseLDto, Course>> ProjectLDtoToCourse => p90 => new Course()
        {
            CourseId = p90.CourseId,
            IsSuggested = p90.IsSuggested,
            Name = p90.Name,
            Detail = p90.Detail,
            Teacher = p90.Teacher,
            Reference = p90.Reference,
            IsFree = p90.IsFree,
            Price = p90.Price,
            CourseCategoryId = p90.CourseCategoryId,
            CourseCategory = new CourseCategory() {Name = p90.CourseCategoryName},
            Image = p90.Image,
            Videos = p90.Videos.Select<VideoSDto, Video>(p91 => new Video()
            {
                VideoId = p91.VideoId,
                Row = p91.Row,
                Name = p91.Name,
                VideoTime = p91.VideoTime,
                FileLocation = p91.FileLocation,
                FileName = p91.FileName,
                IsFree = p91.IsFree,
                CourseId = p91.CourseId,
                CreatedAt = p91.CreatedAt
            }).ToList<Video>(),
            Handouts = p90.Handouts.Select<CourseHandoutSDto, CourseHandout>(p92 => new CourseHandout()
            {
                HandoutId = p92.HandoutId,
                Name = p92.Name,
                Detail = p92.Detail,
                FileLocation = p92.FileLocation,
                FileName = p92.FileName,
                CreatedAt = p92.CreatedAt
            }).ToList<CourseHandout>(),
            CreatedAt = p90.CreatedAt
        };
        public static CourseLDto AdaptToLDto(this Course p93)
        {
            return p93 == null ? null : new CourseLDto()
            {
                CourseId = p93.CourseId,
                Name = p93.Name,
                Detail = p93.Detail,
                Teacher = p93.Teacher,
                Reference = p93.Reference,
                ImageFileName = p93.Image != null ? p93.Image.FileName : null,
                Image = funcMain66(p93.Image),
                IsSuggested = p93.IsSuggested,
                IsFree = p93.IsFree,
                Price = p93.Price,
                CourseCategoryId = p93.CourseCategoryId,
                CourseCategoryName = p93.CourseCategory != null ? p93.CourseCategory.Name : null,
                CreatedAt = p93.CreatedAt,
                Videos = funcMain95(p93.Videos),
                Handouts = funcMain96(p93.Handouts)
            };
        }
        public static CourseLDto AdaptTo(this Course p125, CourseLDto p126)
        {
            if (p125 == null)
            {
                return null;
            }
            CourseLDto result = p126 ?? new CourseLDto();
            
            result.CourseId = p125.CourseId;
            result.Name = p125.Name;
            result.Detail = p125.Detail;
            result.Teacher = p125.Teacher;
            result.Reference = p125.Reference;
            result.ImageFileName = p125.Image != null ? p125.Image.FileName : null;
            result.Image = funcMain97(p125.Image, result.Image);
            result.IsSuggested = p125.IsSuggested;
            result.IsFree = p125.IsFree;
            result.Price = p125.Price;
            result.CourseCategoryId = p125.CourseCategoryId;
            result.CourseCategoryName = p125.CourseCategory != null ? p125.CourseCategory.Name : null;
            result.CreatedAt = p125.CreatedAt;
            result.Videos = funcMain126(p125.Videos, result.Videos);
            result.Handouts = funcMain127(p125.Handouts, result.Handouts);
            return result;
            
        }
        public static Expression<Func<Course, CourseLDto>> ProjectToLDto => p168 => new CourseLDto()
        {
            CourseId = p168.CourseId,
            Name = p168.Name,
            Detail = p168.Detail,
            Teacher = p168.Teacher,
            Reference = p168.Reference,
            ImageFileName = p168.Image != null ? p168.Image.FileName : null,
            Image = p168.Image,
            IsSuggested = p168.IsSuggested,
            IsFree = p168.IsFree,
            Price = p168.Price,
            CourseCategoryId = p168.CourseCategoryId,
            CourseCategoryName = p168.CourseCategory != null ? p168.CourseCategory.Name : null,
            CreatedAt = p168.CreatedAt,
            Videos = p168.Videos.Select<Video, VideoSDto>(p169 => new VideoSDto()
            {
                VideoId = p169.VideoId,
                Name = p169.Name,
                Row = p169.Row,
                VideoTime = p169.VideoTime,
                FileLocation = p169.FileLocation,
                FileName = p169.FileName,
                CourseId = p169.CourseId,
                IsFree = p169.IsFree,
                CreatedAt = p169.CreatedAt
            }).ToList<VideoSDto>(),
            Handouts = p168.Handouts.Select<CourseHandout, CourseHandoutSDto>(p170 => new CourseHandoutSDto()
            {
                HandoutId = p170.HandoutId,
                Name = p170.Name,
                Detail = p170.Detail,
                FileLocation = p170.FileLocation,
                FileName = p170.FileName,
                CreatedAt = p170.CreatedAt
            }).ToList<CourseHandoutSDto>()
        };
        
        private static CourseCategory funcMain1(Never p4, CourseCategory p5, CourseSDto p2)
        {
            CourseCategory result = p5 ?? new CourseCategory();
            
            result.Name = p2.CourseCategoryName;
            return result;
            
        }
        
        private static CourseImage funcMain2(Never p6, CourseImage p7, CourseSDto p2)
        {
            CourseImage result = p7 ?? new CourseImage();
            
            result.FileName = p2.ImageFileName;
            return result;
            
        }
        
        private static CourseImage funcMain3(CourseImage p14)
        {
            return p14 == null ? null : new CourseImage()
            {
                CourseId = p14.CourseId,
                Course = funcMain4(p14.Course),
                ImageId = p14.ImageId,
                Name = p14.Name,
                FileLocation = p14.FileLocation,
                FileName = p14.FileName,
                RemovedAt = p14.RemovedAt,
                CreatedAt = p14.CreatedAt,
                CreatedBy = p14.CreatedBy,
                IsRemoved = p14.IsRemoved,
                ModifiedBy = p14.ModifiedBy,
                RemovedBy = p14.RemovedBy,
                ModifiedAt = p14.ModifiedAt
            };
        }
        
        private static ICollection<Video> funcMain32(List<VideoSDto> p43)
        {
            if (p43 == null)
            {
                return null;
            }
            ICollection<Video> result = new List<Video>(p43.Count);
            
            int i = 0;
            int len = p43.Count;
            
            while (i < len)
            {
                VideoSDto item = p43[i];
                result.Add(item == null ? null : new Video()
                {
                    VideoId = item.VideoId,
                    Row = item.Row,
                    Name = item.Name,
                    VideoTime = item.VideoTime,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    IsFree = item.IsFree,
                    CourseId = item.CourseId,
                    CreatedAt = item.CreatedAt
                });
                i++;
            }
            return result;
            
        }
        
        private static ICollection<CourseHandout> funcMain33(List<CourseHandoutSDto> p44)
        {
            if (p44 == null)
            {
                return null;
            }
            ICollection<CourseHandout> result = new List<CourseHandout>(p44.Count);
            
            int i = 0;
            int len = p44.Count;
            
            while (i < len)
            {
                CourseHandoutSDto item = p44[i];
                result.Add(item == null ? null : new CourseHandout()
                {
                    HandoutId = item.HandoutId,
                    Name = item.Name,
                    Detail = item.Detail,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    CreatedAt = item.CreatedAt
                });
                i++;
            }
            return result;
            
        }
        
        private static CourseCategory funcMain34(Never p47, CourseCategory p48, CourseLDto p45)
        {
            CourseCategory result = p48 ?? new CourseCategory();
            
            result.Name = p45.CourseCategoryName;
            return result;
            
        }
        
        private static CourseImage funcMain35(CourseImage p49, CourseImage p50)
        {
            if (p49 == null)
            {
                return null;
            }
            CourseImage result = p50 ?? new CourseImage();
            
            result.CourseId = p49.CourseId;
            result.Course = funcMain36(p49.Course, result.Course);
            result.ImageId = p49.ImageId;
            result.Name = p49.Name;
            result.FileLocation = p49.FileLocation;
            result.FileName = p49.FileName;
            result.RemovedAt = p49.RemovedAt;
            result.CreatedAt = p49.CreatedAt;
            result.CreatedBy = p49.CreatedBy;
            result.IsRemoved = p49.IsRemoved;
            result.ModifiedBy = p49.ModifiedBy;
            result.RemovedBy = p49.RemovedBy;
            result.ModifiedAt = p49.ModifiedAt;
            return result;
            
        }
        
        private static ICollection<Video> funcMain64(List<VideoSDto> p86, ICollection<Video> p87)
        {
            if (p86 == null)
            {
                return null;
            }
            ICollection<Video> result = new List<Video>(p86.Count);
            
            int i = 0;
            int len = p86.Count;
            
            while (i < len)
            {
                VideoSDto item = p86[i];
                result.Add(item == null ? null : new Video()
                {
                    VideoId = item.VideoId,
                    Row = item.Row,
                    Name = item.Name,
                    VideoTime = item.VideoTime,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    IsFree = item.IsFree,
                    CourseId = item.CourseId,
                    CreatedAt = item.CreatedAt
                });
                i++;
            }
            return result;
            
        }
        
        private static ICollection<CourseHandout> funcMain65(List<CourseHandoutSDto> p88, ICollection<CourseHandout> p89)
        {
            if (p88 == null)
            {
                return null;
            }
            ICollection<CourseHandout> result = new List<CourseHandout>(p88.Count);
            
            int i = 0;
            int len = p88.Count;
            
            while (i < len)
            {
                CourseHandoutSDto item = p88[i];
                result.Add(item == null ? null : new CourseHandout()
                {
                    HandoutId = item.HandoutId,
                    Name = item.Name,
                    Detail = item.Detail,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    CreatedAt = item.CreatedAt
                });
                i++;
            }
            return result;
            
        }
        
        private static CourseImage funcMain66(CourseImage p94)
        {
            return p94 == null ? null : new CourseImage()
            {
                CourseId = p94.CourseId,
                Course = funcMain67(p94.Course),
                ImageId = p94.ImageId,
                Name = p94.Name,
                FileLocation = p94.FileLocation,
                FileName = p94.FileName,
                RemovedAt = p94.RemovedAt,
                CreatedAt = p94.CreatedAt,
                CreatedBy = p94.CreatedBy,
                IsRemoved = p94.IsRemoved,
                ModifiedBy = p94.ModifiedBy,
                RemovedBy = p94.RemovedBy,
                ModifiedAt = p94.ModifiedAt
            };
        }
        
        private static List<VideoSDto> funcMain95(ICollection<Video> p123)
        {
            if (p123 == null)
            {
                return null;
            }
            List<VideoSDto> result = new List<VideoSDto>(p123.Count);
            
            IEnumerator<Video> enumerator = p123.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Video item = enumerator.Current;
                result.Add(item == null ? null : new VideoSDto()
                {
                    VideoId = item.VideoId,
                    Name = item.Name,
                    Row = item.Row,
                    VideoTime = item.VideoTime,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    CourseId = item.CourseId,
                    IsFree = item.IsFree,
                    CreatedAt = item.CreatedAt
                });
            }
            return result;
            
        }
        
        private static List<CourseHandoutSDto> funcMain96(ICollection<CourseHandout> p124)
        {
            if (p124 == null)
            {
                return null;
            }
            List<CourseHandoutSDto> result = new List<CourseHandoutSDto>(p124.Count);
            
            IEnumerator<CourseHandout> enumerator = p124.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                CourseHandout item = enumerator.Current;
                result.Add(item == null ? null : new CourseHandoutSDto()
                {
                    HandoutId = item.HandoutId,
                    Name = item.Name,
                    Detail = item.Detail,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    CreatedAt = item.CreatedAt
                });
            }
            return result;
            
        }
        
        private static CourseImage funcMain97(CourseImage p127, CourseImage p128)
        {
            if (p127 == null)
            {
                return null;
            }
            CourseImage result = p128 ?? new CourseImage();
            
            result.CourseId = p127.CourseId;
            result.Course = funcMain98(p127.Course, result.Course);
            result.ImageId = p127.ImageId;
            result.Name = p127.Name;
            result.FileLocation = p127.FileLocation;
            result.FileName = p127.FileName;
            result.RemovedAt = p127.RemovedAt;
            result.CreatedAt = p127.CreatedAt;
            result.CreatedBy = p127.CreatedBy;
            result.IsRemoved = p127.IsRemoved;
            result.ModifiedBy = p127.ModifiedBy;
            result.RemovedBy = p127.RemovedBy;
            result.ModifiedAt = p127.ModifiedAt;
            return result;
            
        }
        
        private static List<VideoSDto> funcMain126(ICollection<Video> p164, List<VideoSDto> p165)
        {
            if (p164 == null)
            {
                return null;
            }
            List<VideoSDto> result = new List<VideoSDto>(p164.Count);
            
            IEnumerator<Video> enumerator = p164.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Video item = enumerator.Current;
                result.Add(item == null ? null : new VideoSDto()
                {
                    VideoId = item.VideoId,
                    Name = item.Name,
                    Row = item.Row,
                    VideoTime = item.VideoTime,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    CourseId = item.CourseId,
                    IsFree = item.IsFree,
                    CreatedAt = item.CreatedAt
                });
            }
            return result;
            
        }
        
        private static List<CourseHandoutSDto> funcMain127(ICollection<CourseHandout> p166, List<CourseHandoutSDto> p167)
        {
            if (p166 == null)
            {
                return null;
            }
            List<CourseHandoutSDto> result = new List<CourseHandoutSDto>(p166.Count);
            
            IEnumerator<CourseHandout> enumerator = p166.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                CourseHandout item = enumerator.Current;
                result.Add(item == null ? null : new CourseHandoutSDto()
                {
                    HandoutId = item.HandoutId,
                    Name = item.Name,
                    Detail = item.Detail,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    CreatedAt = item.CreatedAt
                });
            }
            return result;
            
        }
        
        private static Course funcMain4(Course p15)
        {
            return p15 == null ? null : new Course()
            {
                CourseId = p15.CourseId,
                IsSuggested = p15.IsSuggested,
                Name = p15.Name,
                Detail = p15.Detail,
                Teacher = p15.Teacher,
                Reference = p15.Reference,
                IsFree = p15.IsFree,
                Price = p15.Price,
                CourseCategoryId = p15.CourseCategoryId,
                RateAvg = p15.RateAvg,
                CourseCategory = funcMain5(p15.CourseCategory),
                Image = TypeAdapter<CourseImage, CourseImage>.Map.Invoke(p15.Image),
                Videos = funcMain7(p15.Videos),
                Handouts = funcMain8(p15.Handouts),
                CourseRates = funcMain9(p15.CourseRates),
                CoursePurchases = funcMain10(p15.CoursePurchases),
                RemovedAt = p15.RemovedAt,
                CreatedAt = p15.CreatedAt,
                CreatedBy = p15.CreatedBy,
                IsRemoved = p15.IsRemoved,
                ModifiedBy = p15.ModifiedBy,
                RemovedBy = p15.RemovedBy,
                ModifiedAt = p15.ModifiedAt
            };
        }
        
        private static Course funcMain36(Course p51, Course p52)
        {
            if (p51 == null)
            {
                return null;
            }
            Course result = p52 ?? new Course();
            
            result.CourseId = p51.CourseId;
            result.IsSuggested = p51.IsSuggested;
            result.Name = p51.Name;
            result.Detail = p51.Detail;
            result.Teacher = p51.Teacher;
            result.Reference = p51.Reference;
            result.IsFree = p51.IsFree;
            result.Price = p51.Price;
            result.CourseCategoryId = p51.CourseCategoryId;
            result.RateAvg = p51.RateAvg;
            result.CourseCategory = funcMain37(p51.CourseCategory, result.CourseCategory);
            result.Image = TypeAdapterConfig.GlobalSettings.GetMapToTargetFunction<CourseImage, CourseImage>().Invoke(p51.Image, result.Image);
            result.Videos = funcMain39(p51.Videos, result.Videos);
            result.Handouts = funcMain40(p51.Handouts, result.Handouts);
            result.CourseRates = funcMain41(p51.CourseRates, result.CourseRates);
            result.CoursePurchases = funcMain42(p51.CoursePurchases, result.CoursePurchases);
            result.RemovedAt = p51.RemovedAt;
            result.CreatedAt = p51.CreatedAt;
            result.CreatedBy = p51.CreatedBy;
            result.IsRemoved = p51.IsRemoved;
            result.ModifiedBy = p51.ModifiedBy;
            result.RemovedBy = p51.RemovedBy;
            result.ModifiedAt = p51.ModifiedAt;
            return result;
            
        }
        
        private static Course funcMain67(Course p95)
        {
            return p95 == null ? null : new Course()
            {
                CourseId = p95.CourseId,
                IsSuggested = p95.IsSuggested,
                Name = p95.Name,
                Detail = p95.Detail,
                Teacher = p95.Teacher,
                Reference = p95.Reference,
                IsFree = p95.IsFree,
                Price = p95.Price,
                CourseCategoryId = p95.CourseCategoryId,
                RateAvg = p95.RateAvg,
                CourseCategory = funcMain68(p95.CourseCategory),
                Image = TypeAdapter<CourseImage, CourseImage>.Map.Invoke(p95.Image),
                Videos = funcMain70(p95.Videos),
                Handouts = funcMain71(p95.Handouts),
                CourseRates = funcMain72(p95.CourseRates),
                CoursePurchases = funcMain73(p95.CoursePurchases),
                RemovedAt = p95.RemovedAt,
                CreatedAt = p95.CreatedAt,
                CreatedBy = p95.CreatedBy,
                IsRemoved = p95.IsRemoved,
                ModifiedBy = p95.ModifiedBy,
                RemovedBy = p95.RemovedBy,
                ModifiedAt = p95.ModifiedAt
            };
        }
        
        private static Course funcMain98(Course p129, Course p130)
        {
            if (p129 == null)
            {
                return null;
            }
            Course result = p130 ?? new Course();
            
            result.CourseId = p129.CourseId;
            result.IsSuggested = p129.IsSuggested;
            result.Name = p129.Name;
            result.Detail = p129.Detail;
            result.Teacher = p129.Teacher;
            result.Reference = p129.Reference;
            result.IsFree = p129.IsFree;
            result.Price = p129.Price;
            result.CourseCategoryId = p129.CourseCategoryId;
            result.RateAvg = p129.RateAvg;
            result.CourseCategory = funcMain99(p129.CourseCategory, result.CourseCategory);
            result.Image = TypeAdapterConfig.GlobalSettings.GetMapToTargetFunction<CourseImage, CourseImage>().Invoke(p129.Image, result.Image);
            result.Videos = funcMain101(p129.Videos, result.Videos);
            result.Handouts = funcMain102(p129.Handouts, result.Handouts);
            result.CourseRates = funcMain103(p129.CourseRates, result.CourseRates);
            result.CoursePurchases = funcMain104(p129.CoursePurchases, result.CoursePurchases);
            result.RemovedAt = p129.RemovedAt;
            result.CreatedAt = p129.CreatedAt;
            result.CreatedBy = p129.CreatedBy;
            result.IsRemoved = p129.IsRemoved;
            result.ModifiedBy = p129.ModifiedBy;
            result.RemovedBy = p129.RemovedBy;
            result.ModifiedAt = p129.ModifiedAt;
            return result;
            
        }
        
        private static CourseCategory funcMain5(CourseCategory p16)
        {
            return p16 == null ? null : new CourseCategory()
            {
                CourseCategoryId = p16.CourseCategoryId,
                Name = p16.Name,
                Courses = funcMain6(p16.Courses),
                RemovedAt = p16.RemovedAt,
                CreatedAt = p16.CreatedAt,
                CreatedBy = p16.CreatedBy,
                IsRemoved = p16.IsRemoved,
                ModifiedBy = p16.ModifiedBy,
                RemovedBy = p16.RemovedBy,
                ModifiedAt = p16.ModifiedAt
            };
        }
        
        private static ICollection<Video> funcMain7(ICollection<Video> p18)
        {
            if (p18 == null)
            {
                return null;
            }
            ICollection<Video> result = new List<Video>(p18.Count);
            
            IEnumerator<Video> enumerator = p18.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Video item = enumerator.Current;
                result.Add(item == null ? null : new Video()
                {
                    VideoId = item.VideoId,
                    Row = item.Row,
                    Name = item.Name,
                    VideoTime = item.VideoTime,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    IsFree = item.IsFree,
                    CourseId = item.CourseId,
                    Course = TypeAdapter<Course, Course>.Map.Invoke(item.Course),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<CourseHandout> funcMain8(ICollection<CourseHandout> p19)
        {
            if (p19 == null)
            {
                return null;
            }
            ICollection<CourseHandout> result = new List<CourseHandout>(p19.Count);
            
            IEnumerator<CourseHandout> enumerator = p19.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                CourseHandout item = enumerator.Current;
                result.Add(item == null ? null : new CourseHandout()
                {
                    CourseId = item.CourseId,
                    Course = TypeAdapter<Course, Course>.Map.Invoke(item.Course),
                    HandoutId = item.HandoutId,
                    Name = item.Name,
                    Detail = item.Detail,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<CourseRate> funcMain9(ICollection<CourseRate> p20)
        {
            if (p20 == null)
            {
                return null;
            }
            ICollection<CourseRate> result = new List<CourseRate>(p20.Count);
            
            IEnumerator<CourseRate> enumerator = p20.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                CourseRate item = enumerator.Current;
                result.Add(item == null ? null : new CourseRate()
                {
                    CourseId = item.CourseId,
                    Course = TypeAdapter<Course, Course>.Map.Invoke(item.Course),
                    RateId = item.RateId,
                    RateMessage = item.RateMessage,
                    Author = item.Author,
                    Score = item.Score,
                    IsConfirmed = item.IsConfirmed,
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<CoursePurchase> funcMain10(ICollection<CoursePurchase> p21)
        {
            if (p21 == null)
            {
                return null;
            }
            ICollection<CoursePurchase> result = new List<CoursePurchase>(p21.Count);
            
            IEnumerator<CoursePurchase> enumerator = p21.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                CoursePurchase item = enumerator.Current;
                result.Add(funcMain11(item));
            }
            return result;
            
        }
        
        private static CourseCategory funcMain37(CourseCategory p53, CourseCategory p54)
        {
            if (p53 == null)
            {
                return null;
            }
            CourseCategory result = p54 ?? new CourseCategory();
            
            result.CourseCategoryId = p53.CourseCategoryId;
            result.Name = p53.Name;
            result.Courses = funcMain38(p53.Courses, result.Courses);
            result.RemovedAt = p53.RemovedAt;
            result.CreatedAt = p53.CreatedAt;
            result.CreatedBy = p53.CreatedBy;
            result.IsRemoved = p53.IsRemoved;
            result.ModifiedBy = p53.ModifiedBy;
            result.RemovedBy = p53.RemovedBy;
            result.ModifiedAt = p53.ModifiedAt;
            return result;
            
        }
        
        private static ICollection<Video> funcMain39(ICollection<Video> p57, ICollection<Video> p58)
        {
            if (p57 == null)
            {
                return null;
            }
            ICollection<Video> result = new List<Video>(p57.Count);
            
            IEnumerator<Video> enumerator = p57.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Video item = enumerator.Current;
                result.Add(item == null ? null : new Video()
                {
                    VideoId = item.VideoId,
                    Row = item.Row,
                    Name = item.Name,
                    VideoTime = item.VideoTime,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    IsFree = item.IsFree,
                    CourseId = item.CourseId,
                    Course = TypeAdapter<Course, Course>.Map.Invoke(item.Course),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<CourseHandout> funcMain40(ICollection<CourseHandout> p59, ICollection<CourseHandout> p60)
        {
            if (p59 == null)
            {
                return null;
            }
            ICollection<CourseHandout> result = new List<CourseHandout>(p59.Count);
            
            IEnumerator<CourseHandout> enumerator = p59.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                CourseHandout item = enumerator.Current;
                result.Add(item == null ? null : new CourseHandout()
                {
                    CourseId = item.CourseId,
                    Course = TypeAdapter<Course, Course>.Map.Invoke(item.Course),
                    HandoutId = item.HandoutId,
                    Name = item.Name,
                    Detail = item.Detail,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<CourseRate> funcMain41(ICollection<CourseRate> p61, ICollection<CourseRate> p62)
        {
            if (p61 == null)
            {
                return null;
            }
            ICollection<CourseRate> result = new List<CourseRate>(p61.Count);
            
            IEnumerator<CourseRate> enumerator = p61.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                CourseRate item = enumerator.Current;
                result.Add(item == null ? null : new CourseRate()
                {
                    CourseId = item.CourseId,
                    Course = TypeAdapter<Course, Course>.Map.Invoke(item.Course),
                    RateId = item.RateId,
                    RateMessage = item.RateMessage,
                    Author = item.Author,
                    Score = item.Score,
                    IsConfirmed = item.IsConfirmed,
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<CoursePurchase> funcMain42(ICollection<CoursePurchase> p63, ICollection<CoursePurchase> p64)
        {
            if (p63 == null)
            {
                return null;
            }
            ICollection<CoursePurchase> result = new List<CoursePurchase>(p63.Count);
            
            IEnumerator<CoursePurchase> enumerator = p63.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                CoursePurchase item = enumerator.Current;
                result.Add(funcMain43(item));
            }
            return result;
            
        }
        
        private static CourseCategory funcMain68(CourseCategory p96)
        {
            return p96 == null ? null : new CourseCategory()
            {
                CourseCategoryId = p96.CourseCategoryId,
                Name = p96.Name,
                Courses = funcMain69(p96.Courses),
                RemovedAt = p96.RemovedAt,
                CreatedAt = p96.CreatedAt,
                CreatedBy = p96.CreatedBy,
                IsRemoved = p96.IsRemoved,
                ModifiedBy = p96.ModifiedBy,
                RemovedBy = p96.RemovedBy,
                ModifiedAt = p96.ModifiedAt
            };
        }
        
        private static ICollection<Video> funcMain70(ICollection<Video> p98)
        {
            if (p98 == null)
            {
                return null;
            }
            ICollection<Video> result = new List<Video>(p98.Count);
            
            IEnumerator<Video> enumerator = p98.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Video item = enumerator.Current;
                result.Add(item == null ? null : new Video()
                {
                    VideoId = item.VideoId,
                    Row = item.Row,
                    Name = item.Name,
                    VideoTime = item.VideoTime,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    IsFree = item.IsFree,
                    CourseId = item.CourseId,
                    Course = TypeAdapter<Course, Course>.Map.Invoke(item.Course),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<CourseHandout> funcMain71(ICollection<CourseHandout> p99)
        {
            if (p99 == null)
            {
                return null;
            }
            ICollection<CourseHandout> result = new List<CourseHandout>(p99.Count);
            
            IEnumerator<CourseHandout> enumerator = p99.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                CourseHandout item = enumerator.Current;
                result.Add(item == null ? null : new CourseHandout()
                {
                    CourseId = item.CourseId,
                    Course = TypeAdapter<Course, Course>.Map.Invoke(item.Course),
                    HandoutId = item.HandoutId,
                    Name = item.Name,
                    Detail = item.Detail,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<CourseRate> funcMain72(ICollection<CourseRate> p100)
        {
            if (p100 == null)
            {
                return null;
            }
            ICollection<CourseRate> result = new List<CourseRate>(p100.Count);
            
            IEnumerator<CourseRate> enumerator = p100.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                CourseRate item = enumerator.Current;
                result.Add(item == null ? null : new CourseRate()
                {
                    CourseId = item.CourseId,
                    Course = TypeAdapter<Course, Course>.Map.Invoke(item.Course),
                    RateId = item.RateId,
                    RateMessage = item.RateMessage,
                    Author = item.Author,
                    Score = item.Score,
                    IsConfirmed = item.IsConfirmed,
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<CoursePurchase> funcMain73(ICollection<CoursePurchase> p101)
        {
            if (p101 == null)
            {
                return null;
            }
            ICollection<CoursePurchase> result = new List<CoursePurchase>(p101.Count);
            
            IEnumerator<CoursePurchase> enumerator = p101.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                CoursePurchase item = enumerator.Current;
                result.Add(funcMain74(item));
            }
            return result;
            
        }
        
        private static CourseCategory funcMain99(CourseCategory p131, CourseCategory p132)
        {
            if (p131 == null)
            {
                return null;
            }
            CourseCategory result = p132 ?? new CourseCategory();
            
            result.CourseCategoryId = p131.CourseCategoryId;
            result.Name = p131.Name;
            result.Courses = funcMain100(p131.Courses, result.Courses);
            result.RemovedAt = p131.RemovedAt;
            result.CreatedAt = p131.CreatedAt;
            result.CreatedBy = p131.CreatedBy;
            result.IsRemoved = p131.IsRemoved;
            result.ModifiedBy = p131.ModifiedBy;
            result.RemovedBy = p131.RemovedBy;
            result.ModifiedAt = p131.ModifiedAt;
            return result;
            
        }
        
        private static ICollection<Video> funcMain101(ICollection<Video> p135, ICollection<Video> p136)
        {
            if (p135 == null)
            {
                return null;
            }
            ICollection<Video> result = new List<Video>(p135.Count);
            
            IEnumerator<Video> enumerator = p135.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Video item = enumerator.Current;
                result.Add(item == null ? null : new Video()
                {
                    VideoId = item.VideoId,
                    Row = item.Row,
                    Name = item.Name,
                    VideoTime = item.VideoTime,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    IsFree = item.IsFree,
                    CourseId = item.CourseId,
                    Course = TypeAdapter<Course, Course>.Map.Invoke(item.Course),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<CourseHandout> funcMain102(ICollection<CourseHandout> p137, ICollection<CourseHandout> p138)
        {
            if (p137 == null)
            {
                return null;
            }
            ICollection<CourseHandout> result = new List<CourseHandout>(p137.Count);
            
            IEnumerator<CourseHandout> enumerator = p137.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                CourseHandout item = enumerator.Current;
                result.Add(item == null ? null : new CourseHandout()
                {
                    CourseId = item.CourseId,
                    Course = TypeAdapter<Course, Course>.Map.Invoke(item.Course),
                    HandoutId = item.HandoutId,
                    Name = item.Name,
                    Detail = item.Detail,
                    FileLocation = item.FileLocation,
                    FileName = item.FileName,
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<CourseRate> funcMain103(ICollection<CourseRate> p139, ICollection<CourseRate> p140)
        {
            if (p139 == null)
            {
                return null;
            }
            ICollection<CourseRate> result = new List<CourseRate>(p139.Count);
            
            IEnumerator<CourseRate> enumerator = p139.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                CourseRate item = enumerator.Current;
                result.Add(item == null ? null : new CourseRate()
                {
                    CourseId = item.CourseId,
                    Course = TypeAdapter<Course, Course>.Map.Invoke(item.Course),
                    RateId = item.RateId,
                    RateMessage = item.RateMessage,
                    Author = item.Author,
                    Score = item.Score,
                    IsConfirmed = item.IsConfirmed,
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<CoursePurchase> funcMain104(ICollection<CoursePurchase> p141, ICollection<CoursePurchase> p142)
        {
            if (p141 == null)
            {
                return null;
            }
            ICollection<CoursePurchase> result = new List<CoursePurchase>(p141.Count);
            
            IEnumerator<CoursePurchase> enumerator = p141.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                CoursePurchase item = enumerator.Current;
                result.Add(funcMain105(item));
            }
            return result;
            
        }
        
        private static ICollection<Course> funcMain6(ICollection<Course> p17)
        {
            if (p17 == null)
            {
                return null;
            }
            ICollection<Course> result = new List<Course>(p17.Count);
            
            IEnumerator<Course> enumerator = p17.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Course item = enumerator.Current;
                result.Add(TypeAdapter<Course, Course>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static CoursePurchase funcMain11(CoursePurchase p22)
        {
            return p22 == null ? null : new CoursePurchase()
            {
                CourseId = p22.CourseId,
                Course = TypeAdapter<Course, Course>.Map.Invoke(p22.Course),
                PurchaseId = p22.PurchaseId,
                Price = p22.Price,
                IsFree = p22.IsFree,
                UserId = p22.UserId,
                User = funcMain12(p22.User),
                RemovedAt = p22.RemovedAt,
                CreatedAt = p22.CreatedAt,
                CreatedBy = p22.CreatedBy,
                IsRemoved = p22.IsRemoved,
                ModifiedBy = p22.ModifiedBy,
                RemovedBy = p22.RemovedBy,
                ModifiedAt = p22.ModifiedAt
            };
        }
        
        private static ICollection<Course> funcMain38(ICollection<Course> p55, ICollection<Course> p56)
        {
            if (p55 == null)
            {
                return null;
            }
            ICollection<Course> result = new List<Course>(p55.Count);
            
            IEnumerator<Course> enumerator = p55.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Course item = enumerator.Current;
                result.Add(TypeAdapter<Course, Course>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static CoursePurchase funcMain43(CoursePurchase p65)
        {
            return p65 == null ? null : new CoursePurchase()
            {
                CourseId = p65.CourseId,
                Course = TypeAdapter<Course, Course>.Map.Invoke(p65.Course),
                PurchaseId = p65.PurchaseId,
                Price = p65.Price,
                IsFree = p65.IsFree,
                UserId = p65.UserId,
                User = funcMain44(p65.User),
                RemovedAt = p65.RemovedAt,
                CreatedAt = p65.CreatedAt,
                CreatedBy = p65.CreatedBy,
                IsRemoved = p65.IsRemoved,
                ModifiedBy = p65.ModifiedBy,
                RemovedBy = p65.RemovedBy,
                ModifiedAt = p65.ModifiedAt
            };
        }
        
        private static ICollection<Course> funcMain69(ICollection<Course> p97)
        {
            if (p97 == null)
            {
                return null;
            }
            ICollection<Course> result = new List<Course>(p97.Count);
            
            IEnumerator<Course> enumerator = p97.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Course item = enumerator.Current;
                result.Add(TypeAdapter<Course, Course>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static CoursePurchase funcMain74(CoursePurchase p102)
        {
            return p102 == null ? null : new CoursePurchase()
            {
                CourseId = p102.CourseId,
                Course = TypeAdapter<Course, Course>.Map.Invoke(p102.Course),
                PurchaseId = p102.PurchaseId,
                Price = p102.Price,
                IsFree = p102.IsFree,
                UserId = p102.UserId,
                User = funcMain75(p102.User),
                RemovedAt = p102.RemovedAt,
                CreatedAt = p102.CreatedAt,
                CreatedBy = p102.CreatedBy,
                IsRemoved = p102.IsRemoved,
                ModifiedBy = p102.ModifiedBy,
                RemovedBy = p102.RemovedBy,
                ModifiedAt = p102.ModifiedAt
            };
        }
        
        private static ICollection<Course> funcMain100(ICollection<Course> p133, ICollection<Course> p134)
        {
            if (p133 == null)
            {
                return null;
            }
            ICollection<Course> result = new List<Course>(p133.Count);
            
            IEnumerator<Course> enumerator = p133.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Course item = enumerator.Current;
                result.Add(TypeAdapter<Course, Course>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static CoursePurchase funcMain105(CoursePurchase p143)
        {
            return p143 == null ? null : new CoursePurchase()
            {
                CourseId = p143.CourseId,
                Course = TypeAdapter<Course, Course>.Map.Invoke(p143.Course),
                PurchaseId = p143.PurchaseId,
                Price = p143.Price,
                IsFree = p143.IsFree,
                UserId = p143.UserId,
                User = funcMain106(p143.User),
                RemovedAt = p143.RemovedAt,
                CreatedAt = p143.CreatedAt,
                CreatedBy = p143.CreatedBy,
                IsRemoved = p143.IsRemoved,
                ModifiedBy = p143.ModifiedBy,
                RemovedBy = p143.RemovedBy,
                ModifiedAt = p143.ModifiedAt
            };
        }
        
        private static User funcMain12(User p23)
        {
            return p23 == null ? null : new User()
            {
                WalletBalance = p23.WalletBalance,
                IdentityCode = p23.IdentityCode,
                StudentCode = p23.StudentCode,
                IsConfirmed = p23.IsConfirmed,
                Score = p23.Score,
                SignUpAt = p23.SignUpAt,
                UserIdentityImage = p23.UserIdentityImage == null ? null : new UserIdentityImage()
                {
                    UserId = p23.UserIdentityImage.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(p23.UserIdentityImage.User),
                    ImageId = p23.UserIdentityImage.ImageId,
                    Name = p23.UserIdentityImage.Name,
                    FileLocation = p23.UserIdentityImage.FileLocation,
                    FileName = p23.UserIdentityImage.FileName,
                    RemovedAt = p23.UserIdentityImage.RemovedAt,
                    CreatedAt = p23.UserIdentityImage.CreatedAt,
                    CreatedBy = p23.UserIdentityImage.CreatedBy,
                    IsRemoved = p23.UserIdentityImage.IsRemoved,
                    ModifiedBy = p23.UserIdentityImage.ModifiedBy,
                    RemovedBy = p23.UserIdentityImage.RemovedBy,
                    ModifiedAt = p23.UserIdentityImage.ModifiedAt
                },
                Payments = funcMain13(p23.Payments),
                VideoPurchases = TypeAdapter<ICollection<CoursePurchase>, ICollection<CoursePurchase>>.Map.Invoke(p23.VideoPurchases),
                HandoutPurchases = funcMain14(p23.HandoutPurchases),
                SubmittedAnswers = funcMain15(p23.SubmittedAnswers),
                FirstName = p23.FirstName,
                LastName = p23.LastName,
                BirthDate = p23.BirthDate,
                Gender = p23.Gender,
                Id = p23.Id,
                UserName = p23.UserName,
                NormalizedUserName = p23.NormalizedUserName,
                Email = p23.Email,
                NormalizedEmail = p23.NormalizedEmail,
                EmailConfirmed = p23.EmailConfirmed,
                PasswordHash = p23.PasswordHash,
                SecurityStamp = p23.SecurityStamp,
                ConcurrencyStamp = p23.ConcurrencyStamp,
                PhoneNumber = p23.PhoneNumber,
                PhoneNumberConfirmed = p23.PhoneNumberConfirmed,
                TwoFactorEnabled = p23.TwoFactorEnabled,
                LockoutEnd = p23.LockoutEnd,
                LockoutEnabled = p23.LockoutEnabled,
                AccessFailedCount = p23.AccessFailedCount
            };
        }
        
        private static User funcMain44(User p66)
        {
            return p66 == null ? null : new User()
            {
                WalletBalance = p66.WalletBalance,
                IdentityCode = p66.IdentityCode,
                StudentCode = p66.StudentCode,
                IsConfirmed = p66.IsConfirmed,
                Score = p66.Score,
                SignUpAt = p66.SignUpAt,
                UserIdentityImage = p66.UserIdentityImage == null ? null : new UserIdentityImage()
                {
                    UserId = p66.UserIdentityImage.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(p66.UserIdentityImage.User),
                    ImageId = p66.UserIdentityImage.ImageId,
                    Name = p66.UserIdentityImage.Name,
                    FileLocation = p66.UserIdentityImage.FileLocation,
                    FileName = p66.UserIdentityImage.FileName,
                    RemovedAt = p66.UserIdentityImage.RemovedAt,
                    CreatedAt = p66.UserIdentityImage.CreatedAt,
                    CreatedBy = p66.UserIdentityImage.CreatedBy,
                    IsRemoved = p66.UserIdentityImage.IsRemoved,
                    ModifiedBy = p66.UserIdentityImage.ModifiedBy,
                    RemovedBy = p66.UserIdentityImage.RemovedBy,
                    ModifiedAt = p66.UserIdentityImage.ModifiedAt
                },
                Payments = funcMain45(p66.Payments),
                VideoPurchases = TypeAdapter<ICollection<CoursePurchase>, ICollection<CoursePurchase>>.Map.Invoke(p66.VideoPurchases),
                HandoutPurchases = funcMain46(p66.HandoutPurchases),
                SubmittedAnswers = funcMain47(p66.SubmittedAnswers),
                FirstName = p66.FirstName,
                LastName = p66.LastName,
                BirthDate = p66.BirthDate,
                Gender = p66.Gender,
                Id = p66.Id,
                UserName = p66.UserName,
                NormalizedUserName = p66.NormalizedUserName,
                Email = p66.Email,
                NormalizedEmail = p66.NormalizedEmail,
                EmailConfirmed = p66.EmailConfirmed,
                PasswordHash = p66.PasswordHash,
                SecurityStamp = p66.SecurityStamp,
                ConcurrencyStamp = p66.ConcurrencyStamp,
                PhoneNumber = p66.PhoneNumber,
                PhoneNumberConfirmed = p66.PhoneNumberConfirmed,
                TwoFactorEnabled = p66.TwoFactorEnabled,
                LockoutEnd = p66.LockoutEnd,
                LockoutEnabled = p66.LockoutEnabled,
                AccessFailedCount = p66.AccessFailedCount
            };
        }
        
        private static User funcMain75(User p103)
        {
            return p103 == null ? null : new User()
            {
                WalletBalance = p103.WalletBalance,
                IdentityCode = p103.IdentityCode,
                StudentCode = p103.StudentCode,
                IsConfirmed = p103.IsConfirmed,
                Score = p103.Score,
                SignUpAt = p103.SignUpAt,
                UserIdentityImage = p103.UserIdentityImage == null ? null : new UserIdentityImage()
                {
                    UserId = p103.UserIdentityImage.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(p103.UserIdentityImage.User),
                    ImageId = p103.UserIdentityImage.ImageId,
                    Name = p103.UserIdentityImage.Name,
                    FileLocation = p103.UserIdentityImage.FileLocation,
                    FileName = p103.UserIdentityImage.FileName,
                    RemovedAt = p103.UserIdentityImage.RemovedAt,
                    CreatedAt = p103.UserIdentityImage.CreatedAt,
                    CreatedBy = p103.UserIdentityImage.CreatedBy,
                    IsRemoved = p103.UserIdentityImage.IsRemoved,
                    ModifiedBy = p103.UserIdentityImage.ModifiedBy,
                    RemovedBy = p103.UserIdentityImage.RemovedBy,
                    ModifiedAt = p103.UserIdentityImage.ModifiedAt
                },
                Payments = funcMain76(p103.Payments),
                VideoPurchases = TypeAdapter<ICollection<CoursePurchase>, ICollection<CoursePurchase>>.Map.Invoke(p103.VideoPurchases),
                HandoutPurchases = funcMain77(p103.HandoutPurchases),
                SubmittedAnswers = funcMain78(p103.SubmittedAnswers),
                FirstName = p103.FirstName,
                LastName = p103.LastName,
                BirthDate = p103.BirthDate,
                Gender = p103.Gender,
                Id = p103.Id,
                UserName = p103.UserName,
                NormalizedUserName = p103.NormalizedUserName,
                Email = p103.Email,
                NormalizedEmail = p103.NormalizedEmail,
                EmailConfirmed = p103.EmailConfirmed,
                PasswordHash = p103.PasswordHash,
                SecurityStamp = p103.SecurityStamp,
                ConcurrencyStamp = p103.ConcurrencyStamp,
                PhoneNumber = p103.PhoneNumber,
                PhoneNumberConfirmed = p103.PhoneNumberConfirmed,
                TwoFactorEnabled = p103.TwoFactorEnabled,
                LockoutEnd = p103.LockoutEnd,
                LockoutEnabled = p103.LockoutEnabled,
                AccessFailedCount = p103.AccessFailedCount
            };
        }
        
        private static User funcMain106(User p144)
        {
            return p144 == null ? null : new User()
            {
                WalletBalance = p144.WalletBalance,
                IdentityCode = p144.IdentityCode,
                StudentCode = p144.StudentCode,
                IsConfirmed = p144.IsConfirmed,
                Score = p144.Score,
                SignUpAt = p144.SignUpAt,
                UserIdentityImage = p144.UserIdentityImage == null ? null : new UserIdentityImage()
                {
                    UserId = p144.UserIdentityImage.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(p144.UserIdentityImage.User),
                    ImageId = p144.UserIdentityImage.ImageId,
                    Name = p144.UserIdentityImage.Name,
                    FileLocation = p144.UserIdentityImage.FileLocation,
                    FileName = p144.UserIdentityImage.FileName,
                    RemovedAt = p144.UserIdentityImage.RemovedAt,
                    CreatedAt = p144.UserIdentityImage.CreatedAt,
                    CreatedBy = p144.UserIdentityImage.CreatedBy,
                    IsRemoved = p144.UserIdentityImage.IsRemoved,
                    ModifiedBy = p144.UserIdentityImage.ModifiedBy,
                    RemovedBy = p144.UserIdentityImage.RemovedBy,
                    ModifiedAt = p144.UserIdentityImage.ModifiedAt
                },
                Payments = funcMain107(p144.Payments),
                VideoPurchases = TypeAdapter<ICollection<CoursePurchase>, ICollection<CoursePurchase>>.Map.Invoke(p144.VideoPurchases),
                HandoutPurchases = funcMain108(p144.HandoutPurchases),
                SubmittedAnswers = funcMain109(p144.SubmittedAnswers),
                FirstName = p144.FirstName,
                LastName = p144.LastName,
                BirthDate = p144.BirthDate,
                Gender = p144.Gender,
                Id = p144.Id,
                UserName = p144.UserName,
                NormalizedUserName = p144.NormalizedUserName,
                Email = p144.Email,
                NormalizedEmail = p144.NormalizedEmail,
                EmailConfirmed = p144.EmailConfirmed,
                PasswordHash = p144.PasswordHash,
                SecurityStamp = p144.SecurityStamp,
                ConcurrencyStamp = p144.ConcurrencyStamp,
                PhoneNumber = p144.PhoneNumber,
                PhoneNumberConfirmed = p144.PhoneNumberConfirmed,
                TwoFactorEnabled = p144.TwoFactorEnabled,
                LockoutEnd = p144.LockoutEnd,
                LockoutEnabled = p144.LockoutEnabled,
                AccessFailedCount = p144.AccessFailedCount
            };
        }
        
        private static ICollection<Payment> funcMain13(ICollection<Payment> p24)
        {
            if (p24 == null)
            {
                return null;
            }
            ICollection<Payment> result = new List<Payment>(p24.Count);
            
            IEnumerator<Payment> enumerator = p24.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Payment item = enumerator.Current;
                result.Add(item == null ? null : new Payment()
                {
                    PaymentId = item.PaymentId,
                    Amount = item.Amount,
                    TransactionCode = item.TransactionCode,
                    Mobile = item.Mobile,
                    Description = item.Description,
                    CardNumber = item.CardNumber,
                    PaymentTime = item.PaymentTime,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<HandoutPurchase> funcMain14(ICollection<HandoutPurchase> p25)
        {
            if (p25 == null)
            {
                return null;
            }
            ICollection<HandoutPurchase> result = new List<HandoutPurchase>(p25.Count);
            
            IEnumerator<HandoutPurchase> enumerator = p25.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                HandoutPurchase item = enumerator.Current;
                result.Add(item == null ? null : new HandoutPurchase()
                {
                    HandoutId = item.HandoutId,
                    Handout = item.Handout == null ? null : new Handout()
                    {
                        HandoutId = item.Handout.HandoutId,
                        Name = item.Handout.Name,
                        Detail = item.Handout.Detail,
                        FileLocation = item.Handout.FileLocation,
                        FileName = item.Handout.FileName,
                        RemovedAt = item.Handout.RemovedAt,
                        CreatedAt = item.Handout.CreatedAt,
                        CreatedBy = item.Handout.CreatedBy,
                        IsRemoved = item.Handout.IsRemoved,
                        ModifiedBy = item.Handout.ModifiedBy,
                        RemovedBy = item.Handout.RemovedBy,
                        ModifiedAt = item.Handout.ModifiedAt
                    },
                    PurchaseId = item.PurchaseId,
                    Price = item.Price,
                    IsFree = item.IsFree,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<FlashCardSubmittedAnswer> funcMain15(ICollection<FlashCardSubmittedAnswer> p26)
        {
            if (p26 == null)
            {
                return null;
            }
            ICollection<FlashCardSubmittedAnswer> result = new List<FlashCardSubmittedAnswer>(p26.Count);
            
            IEnumerator<FlashCardSubmittedAnswer> enumerator = p26.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardSubmittedAnswer item = enumerator.Current;
                result.Add(funcMain16(item));
            }
            return result;
            
        }
        
        private static ICollection<Payment> funcMain45(ICollection<Payment> p67)
        {
            if (p67 == null)
            {
                return null;
            }
            ICollection<Payment> result = new List<Payment>(p67.Count);
            
            IEnumerator<Payment> enumerator = p67.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Payment item = enumerator.Current;
                result.Add(item == null ? null : new Payment()
                {
                    PaymentId = item.PaymentId,
                    Amount = item.Amount,
                    TransactionCode = item.TransactionCode,
                    Mobile = item.Mobile,
                    Description = item.Description,
                    CardNumber = item.CardNumber,
                    PaymentTime = item.PaymentTime,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<HandoutPurchase> funcMain46(ICollection<HandoutPurchase> p68)
        {
            if (p68 == null)
            {
                return null;
            }
            ICollection<HandoutPurchase> result = new List<HandoutPurchase>(p68.Count);
            
            IEnumerator<HandoutPurchase> enumerator = p68.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                HandoutPurchase item = enumerator.Current;
                result.Add(item == null ? null : new HandoutPurchase()
                {
                    HandoutId = item.HandoutId,
                    Handout = item.Handout == null ? null : new Handout()
                    {
                        HandoutId = item.Handout.HandoutId,
                        Name = item.Handout.Name,
                        Detail = item.Handout.Detail,
                        FileLocation = item.Handout.FileLocation,
                        FileName = item.Handout.FileName,
                        RemovedAt = item.Handout.RemovedAt,
                        CreatedAt = item.Handout.CreatedAt,
                        CreatedBy = item.Handout.CreatedBy,
                        IsRemoved = item.Handout.IsRemoved,
                        ModifiedBy = item.Handout.ModifiedBy,
                        RemovedBy = item.Handout.RemovedBy,
                        ModifiedAt = item.Handout.ModifiedAt
                    },
                    PurchaseId = item.PurchaseId,
                    Price = item.Price,
                    IsFree = item.IsFree,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<FlashCardSubmittedAnswer> funcMain47(ICollection<FlashCardSubmittedAnswer> p69)
        {
            if (p69 == null)
            {
                return null;
            }
            ICollection<FlashCardSubmittedAnswer> result = new List<FlashCardSubmittedAnswer>(p69.Count);
            
            IEnumerator<FlashCardSubmittedAnswer> enumerator = p69.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardSubmittedAnswer item = enumerator.Current;
                result.Add(funcMain48(item));
            }
            return result;
            
        }
        
        private static ICollection<Payment> funcMain76(ICollection<Payment> p104)
        {
            if (p104 == null)
            {
                return null;
            }
            ICollection<Payment> result = new List<Payment>(p104.Count);
            
            IEnumerator<Payment> enumerator = p104.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Payment item = enumerator.Current;
                result.Add(item == null ? null : new Payment()
                {
                    PaymentId = item.PaymentId,
                    Amount = item.Amount,
                    TransactionCode = item.TransactionCode,
                    Mobile = item.Mobile,
                    Description = item.Description,
                    CardNumber = item.CardNumber,
                    PaymentTime = item.PaymentTime,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<HandoutPurchase> funcMain77(ICollection<HandoutPurchase> p105)
        {
            if (p105 == null)
            {
                return null;
            }
            ICollection<HandoutPurchase> result = new List<HandoutPurchase>(p105.Count);
            
            IEnumerator<HandoutPurchase> enumerator = p105.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                HandoutPurchase item = enumerator.Current;
                result.Add(item == null ? null : new HandoutPurchase()
                {
                    HandoutId = item.HandoutId,
                    Handout = item.Handout == null ? null : new Handout()
                    {
                        HandoutId = item.Handout.HandoutId,
                        Name = item.Handout.Name,
                        Detail = item.Handout.Detail,
                        FileLocation = item.Handout.FileLocation,
                        FileName = item.Handout.FileName,
                        RemovedAt = item.Handout.RemovedAt,
                        CreatedAt = item.Handout.CreatedAt,
                        CreatedBy = item.Handout.CreatedBy,
                        IsRemoved = item.Handout.IsRemoved,
                        ModifiedBy = item.Handout.ModifiedBy,
                        RemovedBy = item.Handout.RemovedBy,
                        ModifiedAt = item.Handout.ModifiedAt
                    },
                    PurchaseId = item.PurchaseId,
                    Price = item.Price,
                    IsFree = item.IsFree,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<FlashCardSubmittedAnswer> funcMain78(ICollection<FlashCardSubmittedAnswer> p106)
        {
            if (p106 == null)
            {
                return null;
            }
            ICollection<FlashCardSubmittedAnswer> result = new List<FlashCardSubmittedAnswer>(p106.Count);
            
            IEnumerator<FlashCardSubmittedAnswer> enumerator = p106.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardSubmittedAnswer item = enumerator.Current;
                result.Add(funcMain79(item));
            }
            return result;
            
        }
        
        private static ICollection<Payment> funcMain107(ICollection<Payment> p145)
        {
            if (p145 == null)
            {
                return null;
            }
            ICollection<Payment> result = new List<Payment>(p145.Count);
            
            IEnumerator<Payment> enumerator = p145.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Payment item = enumerator.Current;
                result.Add(item == null ? null : new Payment()
                {
                    PaymentId = item.PaymentId,
                    Amount = item.Amount,
                    TransactionCode = item.TransactionCode,
                    Mobile = item.Mobile,
                    Description = item.Description,
                    CardNumber = item.CardNumber,
                    PaymentTime = item.PaymentTime,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<HandoutPurchase> funcMain108(ICollection<HandoutPurchase> p146)
        {
            if (p146 == null)
            {
                return null;
            }
            ICollection<HandoutPurchase> result = new List<HandoutPurchase>(p146.Count);
            
            IEnumerator<HandoutPurchase> enumerator = p146.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                HandoutPurchase item = enumerator.Current;
                result.Add(item == null ? null : new HandoutPurchase()
                {
                    HandoutId = item.HandoutId,
                    Handout = item.Handout == null ? null : new Handout()
                    {
                        HandoutId = item.Handout.HandoutId,
                        Name = item.Handout.Name,
                        Detail = item.Handout.Detail,
                        FileLocation = item.Handout.FileLocation,
                        FileName = item.Handout.FileName,
                        RemovedAt = item.Handout.RemovedAt,
                        CreatedAt = item.Handout.CreatedAt,
                        CreatedBy = item.Handout.CreatedBy,
                        IsRemoved = item.Handout.IsRemoved,
                        ModifiedBy = item.Handout.ModifiedBy,
                        RemovedBy = item.Handout.RemovedBy,
                        ModifiedAt = item.Handout.ModifiedAt
                    },
                    PurchaseId = item.PurchaseId,
                    Price = item.Price,
                    IsFree = item.IsFree,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<FlashCardSubmittedAnswer> funcMain109(ICollection<FlashCardSubmittedAnswer> p147)
        {
            if (p147 == null)
            {
                return null;
            }
            ICollection<FlashCardSubmittedAnswer> result = new List<FlashCardSubmittedAnswer>(p147.Count);
            
            IEnumerator<FlashCardSubmittedAnswer> enumerator = p147.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardSubmittedAnswer item = enumerator.Current;
                result.Add(funcMain110(item));
            }
            return result;
            
        }
        
        private static FlashCardSubmittedAnswer funcMain16(FlashCardSubmittedAnswer p27)
        {
            return p27 == null ? null : new FlashCardSubmittedAnswer()
            {
                FlashCardSubmittedAnswerId = p27.FlashCardSubmittedAnswerId,
                IsTrue = p27.IsTrue,
                Row = p27.Row,
                ElapsedTimePerSecond = p27.ElapsedTimePerSecond,
                FlashCardId = p27.FlashCardId,
                FlashCard = funcMain17(p27.FlashCard),
                FlashCardAnswerId = p27.FlashCardAnswerId,
                FlashCardAnswer = funcMain24(p27.FlashCardAnswer),
                UserId = p27.UserId,
                User = TypeAdapter<User, User>.Map.Invoke(p27.User),
                RemovedAt = p27.RemovedAt,
                CreatedAt = p27.CreatedAt,
                CreatedBy = p27.CreatedBy,
                IsRemoved = p27.IsRemoved,
                ModifiedBy = p27.ModifiedBy,
                RemovedBy = p27.RemovedBy,
                ModifiedAt = p27.ModifiedAt
            };
        }
        
        private static FlashCardSubmittedAnswer funcMain48(FlashCardSubmittedAnswer p70)
        {
            return p70 == null ? null : new FlashCardSubmittedAnswer()
            {
                FlashCardSubmittedAnswerId = p70.FlashCardSubmittedAnswerId,
                IsTrue = p70.IsTrue,
                Row = p70.Row,
                ElapsedTimePerSecond = p70.ElapsedTimePerSecond,
                FlashCardId = p70.FlashCardId,
                FlashCard = funcMain49(p70.FlashCard),
                FlashCardAnswerId = p70.FlashCardAnswerId,
                FlashCardAnswer = funcMain56(p70.FlashCardAnswer),
                UserId = p70.UserId,
                User = TypeAdapter<User, User>.Map.Invoke(p70.User),
                RemovedAt = p70.RemovedAt,
                CreatedAt = p70.CreatedAt,
                CreatedBy = p70.CreatedBy,
                IsRemoved = p70.IsRemoved,
                ModifiedBy = p70.ModifiedBy,
                RemovedBy = p70.RemovedBy,
                ModifiedAt = p70.ModifiedAt
            };
        }
        
        private static FlashCardSubmittedAnswer funcMain79(FlashCardSubmittedAnswer p107)
        {
            return p107 == null ? null : new FlashCardSubmittedAnswer()
            {
                FlashCardSubmittedAnswerId = p107.FlashCardSubmittedAnswerId,
                IsTrue = p107.IsTrue,
                Row = p107.Row,
                ElapsedTimePerSecond = p107.ElapsedTimePerSecond,
                FlashCardId = p107.FlashCardId,
                FlashCard = funcMain80(p107.FlashCard),
                FlashCardAnswerId = p107.FlashCardAnswerId,
                FlashCardAnswer = funcMain87(p107.FlashCardAnswer),
                UserId = p107.UserId,
                User = TypeAdapter<User, User>.Map.Invoke(p107.User),
                RemovedAt = p107.RemovedAt,
                CreatedAt = p107.CreatedAt,
                CreatedBy = p107.CreatedBy,
                IsRemoved = p107.IsRemoved,
                ModifiedBy = p107.ModifiedBy,
                RemovedBy = p107.RemovedBy,
                ModifiedAt = p107.ModifiedAt
            };
        }
        
        private static FlashCardSubmittedAnswer funcMain110(FlashCardSubmittedAnswer p148)
        {
            return p148 == null ? null : new FlashCardSubmittedAnswer()
            {
                FlashCardSubmittedAnswerId = p148.FlashCardSubmittedAnswerId,
                IsTrue = p148.IsTrue,
                Row = p148.Row,
                ElapsedTimePerSecond = p148.ElapsedTimePerSecond,
                FlashCardId = p148.FlashCardId,
                FlashCard = funcMain111(p148.FlashCard),
                FlashCardAnswerId = p148.FlashCardAnswerId,
                FlashCardAnswer = funcMain118(p148.FlashCardAnswer),
                UserId = p148.UserId,
                User = TypeAdapter<User, User>.Map.Invoke(p148.User),
                RemovedAt = p148.RemovedAt,
                CreatedAt = p148.CreatedAt,
                CreatedBy = p148.CreatedBy,
                IsRemoved = p148.IsRemoved,
                ModifiedBy = p148.ModifiedBy,
                RemovedBy = p148.RemovedBy,
                ModifiedAt = p148.ModifiedAt
            };
        }
        
        private static FlashCard funcMain17(FlashCard p28)
        {
            return p28 == null ? null : new FlashCard()
            {
                FlashCardId = p28.FlashCardId,
                Question = p28.Question,
                FlashCardType = p28.FlashCardType,
                FlashCardTagId = p28.FlashCardTagId,
                LongAnswer = p28.LongAnswer,
                FlashCardTag = funcMain18(p28.FlashCardTag),
                FlashCardAnswers = funcMain22(p28.FlashCardAnswers),
                UserFlashCardStatus = funcMain23(p28.UserFlashCardStatus),
                SubmittedAnswers = TypeAdapter<ICollection<FlashCardSubmittedAnswer>, ICollection<FlashCardSubmittedAnswer>>.Map.Invoke(p28.SubmittedAnswers),
                RemovedAt = p28.RemovedAt,
                CreatedAt = p28.CreatedAt,
                CreatedBy = p28.CreatedBy,
                IsRemoved = p28.IsRemoved,
                ModifiedBy = p28.ModifiedBy,
                RemovedBy = p28.RemovedBy,
                ModifiedAt = p28.ModifiedAt
            };
        }
        
        private static FlashCardAnswer funcMain24(FlashCardAnswer p35)
        {
            return p35 == null ? null : new FlashCardAnswer()
            {
                FlashCardAnswerId = p35.FlashCardAnswerId,
                Answer = p35.Answer,
                Row = p35.Row,
                IsTrue = p35.IsTrue,
                FlashCardId = p35.FlashCardId,
                FlashCard = funcMain25(p35.FlashCard),
                RemovedAt = p35.RemovedAt,
                CreatedAt = p35.CreatedAt,
                CreatedBy = p35.CreatedBy,
                IsRemoved = p35.IsRemoved,
                ModifiedBy = p35.ModifiedBy,
                RemovedBy = p35.RemovedBy,
                ModifiedAt = p35.ModifiedAt
            };
        }
        
        private static FlashCard funcMain49(FlashCard p71)
        {
            return p71 == null ? null : new FlashCard()
            {
                FlashCardId = p71.FlashCardId,
                Question = p71.Question,
                FlashCardType = p71.FlashCardType,
                FlashCardTagId = p71.FlashCardTagId,
                LongAnswer = p71.LongAnswer,
                FlashCardTag = funcMain50(p71.FlashCardTag),
                FlashCardAnswers = funcMain54(p71.FlashCardAnswers),
                UserFlashCardStatus = funcMain55(p71.UserFlashCardStatus),
                SubmittedAnswers = TypeAdapter<ICollection<FlashCardSubmittedAnswer>, ICollection<FlashCardSubmittedAnswer>>.Map.Invoke(p71.SubmittedAnswers),
                RemovedAt = p71.RemovedAt,
                CreatedAt = p71.CreatedAt,
                CreatedBy = p71.CreatedBy,
                IsRemoved = p71.IsRemoved,
                ModifiedBy = p71.ModifiedBy,
                RemovedBy = p71.RemovedBy,
                ModifiedAt = p71.ModifiedAt
            };
        }
        
        private static FlashCardAnswer funcMain56(FlashCardAnswer p78)
        {
            return p78 == null ? null : new FlashCardAnswer()
            {
                FlashCardAnswerId = p78.FlashCardAnswerId,
                Answer = p78.Answer,
                Row = p78.Row,
                IsTrue = p78.IsTrue,
                FlashCardId = p78.FlashCardId,
                FlashCard = funcMain57(p78.FlashCard),
                RemovedAt = p78.RemovedAt,
                CreatedAt = p78.CreatedAt,
                CreatedBy = p78.CreatedBy,
                IsRemoved = p78.IsRemoved,
                ModifiedBy = p78.ModifiedBy,
                RemovedBy = p78.RemovedBy,
                ModifiedAt = p78.ModifiedAt
            };
        }
        
        private static FlashCard funcMain80(FlashCard p108)
        {
            return p108 == null ? null : new FlashCard()
            {
                FlashCardId = p108.FlashCardId,
                Question = p108.Question,
                FlashCardType = p108.FlashCardType,
                FlashCardTagId = p108.FlashCardTagId,
                LongAnswer = p108.LongAnswer,
                FlashCardTag = funcMain81(p108.FlashCardTag),
                FlashCardAnswers = funcMain85(p108.FlashCardAnswers),
                UserFlashCardStatus = funcMain86(p108.UserFlashCardStatus),
                SubmittedAnswers = TypeAdapter<ICollection<FlashCardSubmittedAnswer>, ICollection<FlashCardSubmittedAnswer>>.Map.Invoke(p108.SubmittedAnswers),
                RemovedAt = p108.RemovedAt,
                CreatedAt = p108.CreatedAt,
                CreatedBy = p108.CreatedBy,
                IsRemoved = p108.IsRemoved,
                ModifiedBy = p108.ModifiedBy,
                RemovedBy = p108.RemovedBy,
                ModifiedAt = p108.ModifiedAt
            };
        }
        
        private static FlashCardAnswer funcMain87(FlashCardAnswer p115)
        {
            return p115 == null ? null : new FlashCardAnswer()
            {
                FlashCardAnswerId = p115.FlashCardAnswerId,
                Answer = p115.Answer,
                Row = p115.Row,
                IsTrue = p115.IsTrue,
                FlashCardId = p115.FlashCardId,
                FlashCard = funcMain88(p115.FlashCard),
                RemovedAt = p115.RemovedAt,
                CreatedAt = p115.CreatedAt,
                CreatedBy = p115.CreatedBy,
                IsRemoved = p115.IsRemoved,
                ModifiedBy = p115.ModifiedBy,
                RemovedBy = p115.RemovedBy,
                ModifiedAt = p115.ModifiedAt
            };
        }
        
        private static FlashCard funcMain111(FlashCard p149)
        {
            return p149 == null ? null : new FlashCard()
            {
                FlashCardId = p149.FlashCardId,
                Question = p149.Question,
                FlashCardType = p149.FlashCardType,
                FlashCardTagId = p149.FlashCardTagId,
                LongAnswer = p149.LongAnswer,
                FlashCardTag = funcMain112(p149.FlashCardTag),
                FlashCardAnswers = funcMain116(p149.FlashCardAnswers),
                UserFlashCardStatus = funcMain117(p149.UserFlashCardStatus),
                SubmittedAnswers = TypeAdapter<ICollection<FlashCardSubmittedAnswer>, ICollection<FlashCardSubmittedAnswer>>.Map.Invoke(p149.SubmittedAnswers),
                RemovedAt = p149.RemovedAt,
                CreatedAt = p149.CreatedAt,
                CreatedBy = p149.CreatedBy,
                IsRemoved = p149.IsRemoved,
                ModifiedBy = p149.ModifiedBy,
                RemovedBy = p149.RemovedBy,
                ModifiedAt = p149.ModifiedAt
            };
        }
        
        private static FlashCardAnswer funcMain118(FlashCardAnswer p156)
        {
            return p156 == null ? null : new FlashCardAnswer()
            {
                FlashCardAnswerId = p156.FlashCardAnswerId,
                Answer = p156.Answer,
                Row = p156.Row,
                IsTrue = p156.IsTrue,
                FlashCardId = p156.FlashCardId,
                FlashCard = funcMain119(p156.FlashCard),
                RemovedAt = p156.RemovedAt,
                CreatedAt = p156.CreatedAt,
                CreatedBy = p156.CreatedBy,
                IsRemoved = p156.IsRemoved,
                ModifiedBy = p156.ModifiedBy,
                RemovedBy = p156.RemovedBy,
                ModifiedAt = p156.ModifiedAt
            };
        }
        
        private static FlashCardTag funcMain18(FlashCardTag p29)
        {
            return p29 == null ? null : new FlashCardTag()
            {
                FlashCardTagId = p29.FlashCardTagId,
                Name = p29.Name,
                FlashCardCategoryId = p29.FlashCardCategoryId,
                FlashCardCategory = funcMain19(p29.FlashCardCategory),
                FlashCards = funcMain21(p29.FlashCards),
                RemovedAt = p29.RemovedAt,
                CreatedAt = p29.CreatedAt,
                CreatedBy = p29.CreatedBy,
                IsRemoved = p29.IsRemoved,
                ModifiedBy = p29.ModifiedBy,
                RemovedBy = p29.RemovedBy,
                ModifiedAt = p29.ModifiedAt
            };
        }
        
        private static ICollection<FlashCardAnswer> funcMain22(ICollection<FlashCardAnswer> p33)
        {
            if (p33 == null)
            {
                return null;
            }
            ICollection<FlashCardAnswer> result = new List<FlashCardAnswer>(p33.Count);
            
            IEnumerator<FlashCardAnswer> enumerator = p33.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardAnswer item = enumerator.Current;
                result.Add(item == null ? null : new FlashCardAnswer()
                {
                    FlashCardAnswerId = item.FlashCardAnswerId,
                    Answer = item.Answer,
                    Row = item.Row,
                    IsTrue = item.IsTrue,
                    FlashCardId = item.FlashCardId,
                    FlashCard = TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item.FlashCard),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<UserFlashCardStatus> funcMain23(ICollection<UserFlashCardStatus> p34)
        {
            if (p34 == null)
            {
                return null;
            }
            ICollection<UserFlashCardStatus> result = new List<UserFlashCardStatus>(p34.Count);
            
            IEnumerator<UserFlashCardStatus> enumerator = p34.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                UserFlashCardStatus item = enumerator.Current;
                result.Add(item == null ? null : new UserFlashCardStatus()
                {
                    UserFlashCardStatusId = item.UserFlashCardStatusId,
                    FlashCardStatus = item.FlashCardStatus,
                    NextReviewAt = item.NextReviewAt,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    FlashCardId = item.FlashCardId,
                    FlashCard = TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item.FlashCard),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static FlashCard funcMain25(FlashCard p36)
        {
            return p36 == null ? null : new FlashCard()
            {
                FlashCardId = p36.FlashCardId,
                Question = p36.Question,
                FlashCardType = p36.FlashCardType,
                FlashCardTagId = p36.FlashCardTagId,
                LongAnswer = p36.LongAnswer,
                FlashCardTag = funcMain26(p36.FlashCardTag),
                FlashCardAnswers = funcMain30(p36.FlashCardAnswers),
                UserFlashCardStatus = funcMain31(p36.UserFlashCardStatus),
                SubmittedAnswers = TypeAdapter<ICollection<FlashCardSubmittedAnswer>, ICollection<FlashCardSubmittedAnswer>>.Map.Invoke(p36.SubmittedAnswers),
                RemovedAt = p36.RemovedAt,
                CreatedAt = p36.CreatedAt,
                CreatedBy = p36.CreatedBy,
                IsRemoved = p36.IsRemoved,
                ModifiedBy = p36.ModifiedBy,
                RemovedBy = p36.RemovedBy,
                ModifiedAt = p36.ModifiedAt
            };
        }
        
        private static FlashCardTag funcMain50(FlashCardTag p72)
        {
            return p72 == null ? null : new FlashCardTag()
            {
                FlashCardTagId = p72.FlashCardTagId,
                Name = p72.Name,
                FlashCardCategoryId = p72.FlashCardCategoryId,
                FlashCardCategory = funcMain51(p72.FlashCardCategory),
                FlashCards = funcMain53(p72.FlashCards),
                RemovedAt = p72.RemovedAt,
                CreatedAt = p72.CreatedAt,
                CreatedBy = p72.CreatedBy,
                IsRemoved = p72.IsRemoved,
                ModifiedBy = p72.ModifiedBy,
                RemovedBy = p72.RemovedBy,
                ModifiedAt = p72.ModifiedAt
            };
        }
        
        private static ICollection<FlashCardAnswer> funcMain54(ICollection<FlashCardAnswer> p76)
        {
            if (p76 == null)
            {
                return null;
            }
            ICollection<FlashCardAnswer> result = new List<FlashCardAnswer>(p76.Count);
            
            IEnumerator<FlashCardAnswer> enumerator = p76.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardAnswer item = enumerator.Current;
                result.Add(item == null ? null : new FlashCardAnswer()
                {
                    FlashCardAnswerId = item.FlashCardAnswerId,
                    Answer = item.Answer,
                    Row = item.Row,
                    IsTrue = item.IsTrue,
                    FlashCardId = item.FlashCardId,
                    FlashCard = TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item.FlashCard),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<UserFlashCardStatus> funcMain55(ICollection<UserFlashCardStatus> p77)
        {
            if (p77 == null)
            {
                return null;
            }
            ICollection<UserFlashCardStatus> result = new List<UserFlashCardStatus>(p77.Count);
            
            IEnumerator<UserFlashCardStatus> enumerator = p77.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                UserFlashCardStatus item = enumerator.Current;
                result.Add(item == null ? null : new UserFlashCardStatus()
                {
                    UserFlashCardStatusId = item.UserFlashCardStatusId,
                    FlashCardStatus = item.FlashCardStatus,
                    NextReviewAt = item.NextReviewAt,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    FlashCardId = item.FlashCardId,
                    FlashCard = TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item.FlashCard),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static FlashCard funcMain57(FlashCard p79)
        {
            return p79 == null ? null : new FlashCard()
            {
                FlashCardId = p79.FlashCardId,
                Question = p79.Question,
                FlashCardType = p79.FlashCardType,
                FlashCardTagId = p79.FlashCardTagId,
                LongAnswer = p79.LongAnswer,
                FlashCardTag = funcMain58(p79.FlashCardTag),
                FlashCardAnswers = funcMain62(p79.FlashCardAnswers),
                UserFlashCardStatus = funcMain63(p79.UserFlashCardStatus),
                SubmittedAnswers = TypeAdapter<ICollection<FlashCardSubmittedAnswer>, ICollection<FlashCardSubmittedAnswer>>.Map.Invoke(p79.SubmittedAnswers),
                RemovedAt = p79.RemovedAt,
                CreatedAt = p79.CreatedAt,
                CreatedBy = p79.CreatedBy,
                IsRemoved = p79.IsRemoved,
                ModifiedBy = p79.ModifiedBy,
                RemovedBy = p79.RemovedBy,
                ModifiedAt = p79.ModifiedAt
            };
        }
        
        private static FlashCardTag funcMain81(FlashCardTag p109)
        {
            return p109 == null ? null : new FlashCardTag()
            {
                FlashCardTagId = p109.FlashCardTagId,
                Name = p109.Name,
                FlashCardCategoryId = p109.FlashCardCategoryId,
                FlashCardCategory = funcMain82(p109.FlashCardCategory),
                FlashCards = funcMain84(p109.FlashCards),
                RemovedAt = p109.RemovedAt,
                CreatedAt = p109.CreatedAt,
                CreatedBy = p109.CreatedBy,
                IsRemoved = p109.IsRemoved,
                ModifiedBy = p109.ModifiedBy,
                RemovedBy = p109.RemovedBy,
                ModifiedAt = p109.ModifiedAt
            };
        }
        
        private static ICollection<FlashCardAnswer> funcMain85(ICollection<FlashCardAnswer> p113)
        {
            if (p113 == null)
            {
                return null;
            }
            ICollection<FlashCardAnswer> result = new List<FlashCardAnswer>(p113.Count);
            
            IEnumerator<FlashCardAnswer> enumerator = p113.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardAnswer item = enumerator.Current;
                result.Add(item == null ? null : new FlashCardAnswer()
                {
                    FlashCardAnswerId = item.FlashCardAnswerId,
                    Answer = item.Answer,
                    Row = item.Row,
                    IsTrue = item.IsTrue,
                    FlashCardId = item.FlashCardId,
                    FlashCard = TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item.FlashCard),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<UserFlashCardStatus> funcMain86(ICollection<UserFlashCardStatus> p114)
        {
            if (p114 == null)
            {
                return null;
            }
            ICollection<UserFlashCardStatus> result = new List<UserFlashCardStatus>(p114.Count);
            
            IEnumerator<UserFlashCardStatus> enumerator = p114.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                UserFlashCardStatus item = enumerator.Current;
                result.Add(item == null ? null : new UserFlashCardStatus()
                {
                    UserFlashCardStatusId = item.UserFlashCardStatusId,
                    FlashCardStatus = item.FlashCardStatus,
                    NextReviewAt = item.NextReviewAt,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    FlashCardId = item.FlashCardId,
                    FlashCard = TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item.FlashCard),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static FlashCard funcMain88(FlashCard p116)
        {
            return p116 == null ? null : new FlashCard()
            {
                FlashCardId = p116.FlashCardId,
                Question = p116.Question,
                FlashCardType = p116.FlashCardType,
                FlashCardTagId = p116.FlashCardTagId,
                LongAnswer = p116.LongAnswer,
                FlashCardTag = funcMain89(p116.FlashCardTag),
                FlashCardAnswers = funcMain93(p116.FlashCardAnswers),
                UserFlashCardStatus = funcMain94(p116.UserFlashCardStatus),
                SubmittedAnswers = TypeAdapter<ICollection<FlashCardSubmittedAnswer>, ICollection<FlashCardSubmittedAnswer>>.Map.Invoke(p116.SubmittedAnswers),
                RemovedAt = p116.RemovedAt,
                CreatedAt = p116.CreatedAt,
                CreatedBy = p116.CreatedBy,
                IsRemoved = p116.IsRemoved,
                ModifiedBy = p116.ModifiedBy,
                RemovedBy = p116.RemovedBy,
                ModifiedAt = p116.ModifiedAt
            };
        }
        
        private static FlashCardTag funcMain112(FlashCardTag p150)
        {
            return p150 == null ? null : new FlashCardTag()
            {
                FlashCardTagId = p150.FlashCardTagId,
                Name = p150.Name,
                FlashCardCategoryId = p150.FlashCardCategoryId,
                FlashCardCategory = funcMain113(p150.FlashCardCategory),
                FlashCards = funcMain115(p150.FlashCards),
                RemovedAt = p150.RemovedAt,
                CreatedAt = p150.CreatedAt,
                CreatedBy = p150.CreatedBy,
                IsRemoved = p150.IsRemoved,
                ModifiedBy = p150.ModifiedBy,
                RemovedBy = p150.RemovedBy,
                ModifiedAt = p150.ModifiedAt
            };
        }
        
        private static ICollection<FlashCardAnswer> funcMain116(ICollection<FlashCardAnswer> p154)
        {
            if (p154 == null)
            {
                return null;
            }
            ICollection<FlashCardAnswer> result = new List<FlashCardAnswer>(p154.Count);
            
            IEnumerator<FlashCardAnswer> enumerator = p154.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardAnswer item = enumerator.Current;
                result.Add(item == null ? null : new FlashCardAnswer()
                {
                    FlashCardAnswerId = item.FlashCardAnswerId,
                    Answer = item.Answer,
                    Row = item.Row,
                    IsTrue = item.IsTrue,
                    FlashCardId = item.FlashCardId,
                    FlashCard = TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item.FlashCard),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<UserFlashCardStatus> funcMain117(ICollection<UserFlashCardStatus> p155)
        {
            if (p155 == null)
            {
                return null;
            }
            ICollection<UserFlashCardStatus> result = new List<UserFlashCardStatus>(p155.Count);
            
            IEnumerator<UserFlashCardStatus> enumerator = p155.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                UserFlashCardStatus item = enumerator.Current;
                result.Add(item == null ? null : new UserFlashCardStatus()
                {
                    UserFlashCardStatusId = item.UserFlashCardStatusId,
                    FlashCardStatus = item.FlashCardStatus,
                    NextReviewAt = item.NextReviewAt,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    FlashCardId = item.FlashCardId,
                    FlashCard = TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item.FlashCard),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static FlashCard funcMain119(FlashCard p157)
        {
            return p157 == null ? null : new FlashCard()
            {
                FlashCardId = p157.FlashCardId,
                Question = p157.Question,
                FlashCardType = p157.FlashCardType,
                FlashCardTagId = p157.FlashCardTagId,
                LongAnswer = p157.LongAnswer,
                FlashCardTag = funcMain120(p157.FlashCardTag),
                FlashCardAnswers = funcMain124(p157.FlashCardAnswers),
                UserFlashCardStatus = funcMain125(p157.UserFlashCardStatus),
                SubmittedAnswers = TypeAdapter<ICollection<FlashCardSubmittedAnswer>, ICollection<FlashCardSubmittedAnswer>>.Map.Invoke(p157.SubmittedAnswers),
                RemovedAt = p157.RemovedAt,
                CreatedAt = p157.CreatedAt,
                CreatedBy = p157.CreatedBy,
                IsRemoved = p157.IsRemoved,
                ModifiedBy = p157.ModifiedBy,
                RemovedBy = p157.RemovedBy,
                ModifiedAt = p157.ModifiedAt
            };
        }
        
        private static FlashCardCategory funcMain19(FlashCardCategory p30)
        {
            return p30 == null ? null : new FlashCardCategory()
            {
                FlashCardCategoryId = p30.FlashCardCategoryId,
                Name = p30.Name,
                Detail = p30.Detail,
                Author = p30.Author,
                Price = p30.Price,
                IsFree = p30.IsFree,
                IsSuggested = p30.IsSuggested,
                RateAvg = p30.RateAvg,
                IsActive = p30.IsActive,
                Image = p30.Image == null ? null : new FlashCardCategoryImage()
                {
                    FlashCardCategoryId = p30.Image.FlashCardCategoryId,
                    ImageId = p30.Image.ImageId,
                    Name = p30.Image.Name,
                    FileLocation = p30.Image.FileLocation,
                    FileName = p30.Image.FileName,
                    RemovedAt = p30.Image.RemovedAt,
                    CreatedAt = p30.Image.CreatedAt,
                    CreatedBy = p30.Image.CreatedBy,
                    IsRemoved = p30.Image.IsRemoved,
                    ModifiedBy = p30.Image.ModifiedBy,
                    RemovedBy = p30.Image.RemovedBy,
                    ModifiedAt = p30.Image.ModifiedAt
                },
                FlashCardTags = funcMain20(p30.FlashCardTags),
                RemovedAt = p30.RemovedAt,
                CreatedAt = p30.CreatedAt,
                CreatedBy = p30.CreatedBy,
                IsRemoved = p30.IsRemoved,
                ModifiedBy = p30.ModifiedBy,
                RemovedBy = p30.RemovedBy,
                ModifiedAt = p30.ModifiedAt
            };
        }
        
        private static ICollection<FlashCard> funcMain21(ICollection<FlashCard> p32)
        {
            if (p32 == null)
            {
                return null;
            }
            ICollection<FlashCard> result = new List<FlashCard>(p32.Count);
            
            IEnumerator<FlashCard> enumerator = p32.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCard item = enumerator.Current;
                result.Add(TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static FlashCardTag funcMain26(FlashCardTag p37)
        {
            return p37 == null ? null : new FlashCardTag()
            {
                FlashCardTagId = p37.FlashCardTagId,
                Name = p37.Name,
                FlashCardCategoryId = p37.FlashCardCategoryId,
                FlashCardCategory = funcMain27(p37.FlashCardCategory),
                FlashCards = funcMain29(p37.FlashCards),
                RemovedAt = p37.RemovedAt,
                CreatedAt = p37.CreatedAt,
                CreatedBy = p37.CreatedBy,
                IsRemoved = p37.IsRemoved,
                ModifiedBy = p37.ModifiedBy,
                RemovedBy = p37.RemovedBy,
                ModifiedAt = p37.ModifiedAt
            };
        }
        
        private static ICollection<FlashCardAnswer> funcMain30(ICollection<FlashCardAnswer> p41)
        {
            if (p41 == null)
            {
                return null;
            }
            ICollection<FlashCardAnswer> result = new List<FlashCardAnswer>(p41.Count);
            
            IEnumerator<FlashCardAnswer> enumerator = p41.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardAnswer item = enumerator.Current;
                result.Add(TypeAdapter<FlashCardAnswer, FlashCardAnswer>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<UserFlashCardStatus> funcMain31(ICollection<UserFlashCardStatus> p42)
        {
            if (p42 == null)
            {
                return null;
            }
            ICollection<UserFlashCardStatus> result = new List<UserFlashCardStatus>(p42.Count);
            
            IEnumerator<UserFlashCardStatus> enumerator = p42.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                UserFlashCardStatus item = enumerator.Current;
                result.Add(item == null ? null : new UserFlashCardStatus()
                {
                    UserFlashCardStatusId = item.UserFlashCardStatusId,
                    FlashCardStatus = item.FlashCardStatus,
                    NextReviewAt = item.NextReviewAt,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    FlashCardId = item.FlashCardId,
                    FlashCard = TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item.FlashCard),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static FlashCardCategory funcMain51(FlashCardCategory p73)
        {
            return p73 == null ? null : new FlashCardCategory()
            {
                FlashCardCategoryId = p73.FlashCardCategoryId,
                Name = p73.Name,
                Detail = p73.Detail,
                Author = p73.Author,
                Price = p73.Price,
                IsFree = p73.IsFree,
                IsSuggested = p73.IsSuggested,
                RateAvg = p73.RateAvg,
                IsActive = p73.IsActive,
                Image = p73.Image == null ? null : new FlashCardCategoryImage()
                {
                    FlashCardCategoryId = p73.Image.FlashCardCategoryId,
                    ImageId = p73.Image.ImageId,
                    Name = p73.Image.Name,
                    FileLocation = p73.Image.FileLocation,
                    FileName = p73.Image.FileName,
                    RemovedAt = p73.Image.RemovedAt,
                    CreatedAt = p73.Image.CreatedAt,
                    CreatedBy = p73.Image.CreatedBy,
                    IsRemoved = p73.Image.IsRemoved,
                    ModifiedBy = p73.Image.ModifiedBy,
                    RemovedBy = p73.Image.RemovedBy,
                    ModifiedAt = p73.Image.ModifiedAt
                },
                FlashCardTags = funcMain52(p73.FlashCardTags),
                RemovedAt = p73.RemovedAt,
                CreatedAt = p73.CreatedAt,
                CreatedBy = p73.CreatedBy,
                IsRemoved = p73.IsRemoved,
                ModifiedBy = p73.ModifiedBy,
                RemovedBy = p73.RemovedBy,
                ModifiedAt = p73.ModifiedAt
            };
        }
        
        private static ICollection<FlashCard> funcMain53(ICollection<FlashCard> p75)
        {
            if (p75 == null)
            {
                return null;
            }
            ICollection<FlashCard> result = new List<FlashCard>(p75.Count);
            
            IEnumerator<FlashCard> enumerator = p75.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCard item = enumerator.Current;
                result.Add(TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static FlashCardTag funcMain58(FlashCardTag p80)
        {
            return p80 == null ? null : new FlashCardTag()
            {
                FlashCardTagId = p80.FlashCardTagId,
                Name = p80.Name,
                FlashCardCategoryId = p80.FlashCardCategoryId,
                FlashCardCategory = funcMain59(p80.FlashCardCategory),
                FlashCards = funcMain61(p80.FlashCards),
                RemovedAt = p80.RemovedAt,
                CreatedAt = p80.CreatedAt,
                CreatedBy = p80.CreatedBy,
                IsRemoved = p80.IsRemoved,
                ModifiedBy = p80.ModifiedBy,
                RemovedBy = p80.RemovedBy,
                ModifiedAt = p80.ModifiedAt
            };
        }
        
        private static ICollection<FlashCardAnswer> funcMain62(ICollection<FlashCardAnswer> p84)
        {
            if (p84 == null)
            {
                return null;
            }
            ICollection<FlashCardAnswer> result = new List<FlashCardAnswer>(p84.Count);
            
            IEnumerator<FlashCardAnswer> enumerator = p84.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardAnswer item = enumerator.Current;
                result.Add(TypeAdapter<FlashCardAnswer, FlashCardAnswer>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<UserFlashCardStatus> funcMain63(ICollection<UserFlashCardStatus> p85)
        {
            if (p85 == null)
            {
                return null;
            }
            ICollection<UserFlashCardStatus> result = new List<UserFlashCardStatus>(p85.Count);
            
            IEnumerator<UserFlashCardStatus> enumerator = p85.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                UserFlashCardStatus item = enumerator.Current;
                result.Add(item == null ? null : new UserFlashCardStatus()
                {
                    UserFlashCardStatusId = item.UserFlashCardStatusId,
                    FlashCardStatus = item.FlashCardStatus,
                    NextReviewAt = item.NextReviewAt,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    FlashCardId = item.FlashCardId,
                    FlashCard = TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item.FlashCard),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static FlashCardCategory funcMain82(FlashCardCategory p110)
        {
            return p110 == null ? null : new FlashCardCategory()
            {
                FlashCardCategoryId = p110.FlashCardCategoryId,
                Name = p110.Name,
                Detail = p110.Detail,
                Author = p110.Author,
                Price = p110.Price,
                IsFree = p110.IsFree,
                IsSuggested = p110.IsSuggested,
                RateAvg = p110.RateAvg,
                IsActive = p110.IsActive,
                Image = p110.Image == null ? null : new FlashCardCategoryImage()
                {
                    FlashCardCategoryId = p110.Image.FlashCardCategoryId,
                    ImageId = p110.Image.ImageId,
                    Name = p110.Image.Name,
                    FileLocation = p110.Image.FileLocation,
                    FileName = p110.Image.FileName,
                    RemovedAt = p110.Image.RemovedAt,
                    CreatedAt = p110.Image.CreatedAt,
                    CreatedBy = p110.Image.CreatedBy,
                    IsRemoved = p110.Image.IsRemoved,
                    ModifiedBy = p110.Image.ModifiedBy,
                    RemovedBy = p110.Image.RemovedBy,
                    ModifiedAt = p110.Image.ModifiedAt
                },
                FlashCardTags = funcMain83(p110.FlashCardTags),
                RemovedAt = p110.RemovedAt,
                CreatedAt = p110.CreatedAt,
                CreatedBy = p110.CreatedBy,
                IsRemoved = p110.IsRemoved,
                ModifiedBy = p110.ModifiedBy,
                RemovedBy = p110.RemovedBy,
                ModifiedAt = p110.ModifiedAt
            };
        }
        
        private static ICollection<FlashCard> funcMain84(ICollection<FlashCard> p112)
        {
            if (p112 == null)
            {
                return null;
            }
            ICollection<FlashCard> result = new List<FlashCard>(p112.Count);
            
            IEnumerator<FlashCard> enumerator = p112.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCard item = enumerator.Current;
                result.Add(TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static FlashCardTag funcMain89(FlashCardTag p117)
        {
            return p117 == null ? null : new FlashCardTag()
            {
                FlashCardTagId = p117.FlashCardTagId,
                Name = p117.Name,
                FlashCardCategoryId = p117.FlashCardCategoryId,
                FlashCardCategory = funcMain90(p117.FlashCardCategory),
                FlashCards = funcMain92(p117.FlashCards),
                RemovedAt = p117.RemovedAt,
                CreatedAt = p117.CreatedAt,
                CreatedBy = p117.CreatedBy,
                IsRemoved = p117.IsRemoved,
                ModifiedBy = p117.ModifiedBy,
                RemovedBy = p117.RemovedBy,
                ModifiedAt = p117.ModifiedAt
            };
        }
        
        private static ICollection<FlashCardAnswer> funcMain93(ICollection<FlashCardAnswer> p121)
        {
            if (p121 == null)
            {
                return null;
            }
            ICollection<FlashCardAnswer> result = new List<FlashCardAnswer>(p121.Count);
            
            IEnumerator<FlashCardAnswer> enumerator = p121.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardAnswer item = enumerator.Current;
                result.Add(TypeAdapter<FlashCardAnswer, FlashCardAnswer>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<UserFlashCardStatus> funcMain94(ICollection<UserFlashCardStatus> p122)
        {
            if (p122 == null)
            {
                return null;
            }
            ICollection<UserFlashCardStatus> result = new List<UserFlashCardStatus>(p122.Count);
            
            IEnumerator<UserFlashCardStatus> enumerator = p122.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                UserFlashCardStatus item = enumerator.Current;
                result.Add(item == null ? null : new UserFlashCardStatus()
                {
                    UserFlashCardStatusId = item.UserFlashCardStatusId,
                    FlashCardStatus = item.FlashCardStatus,
                    NextReviewAt = item.NextReviewAt,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    FlashCardId = item.FlashCardId,
                    FlashCard = TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item.FlashCard),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static FlashCardCategory funcMain113(FlashCardCategory p151)
        {
            return p151 == null ? null : new FlashCardCategory()
            {
                FlashCardCategoryId = p151.FlashCardCategoryId,
                Name = p151.Name,
                Detail = p151.Detail,
                Author = p151.Author,
                Price = p151.Price,
                IsFree = p151.IsFree,
                IsSuggested = p151.IsSuggested,
                RateAvg = p151.RateAvg,
                IsActive = p151.IsActive,
                Image = p151.Image == null ? null : new FlashCardCategoryImage()
                {
                    FlashCardCategoryId = p151.Image.FlashCardCategoryId,
                    ImageId = p151.Image.ImageId,
                    Name = p151.Image.Name,
                    FileLocation = p151.Image.FileLocation,
                    FileName = p151.Image.FileName,
                    RemovedAt = p151.Image.RemovedAt,
                    CreatedAt = p151.Image.CreatedAt,
                    CreatedBy = p151.Image.CreatedBy,
                    IsRemoved = p151.Image.IsRemoved,
                    ModifiedBy = p151.Image.ModifiedBy,
                    RemovedBy = p151.Image.RemovedBy,
                    ModifiedAt = p151.Image.ModifiedAt
                },
                FlashCardTags = funcMain114(p151.FlashCardTags),
                RemovedAt = p151.RemovedAt,
                CreatedAt = p151.CreatedAt,
                CreatedBy = p151.CreatedBy,
                IsRemoved = p151.IsRemoved,
                ModifiedBy = p151.ModifiedBy,
                RemovedBy = p151.RemovedBy,
                ModifiedAt = p151.ModifiedAt
            };
        }
        
        private static ICollection<FlashCard> funcMain115(ICollection<FlashCard> p153)
        {
            if (p153 == null)
            {
                return null;
            }
            ICollection<FlashCard> result = new List<FlashCard>(p153.Count);
            
            IEnumerator<FlashCard> enumerator = p153.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCard item = enumerator.Current;
                result.Add(TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static FlashCardTag funcMain120(FlashCardTag p158)
        {
            return p158 == null ? null : new FlashCardTag()
            {
                FlashCardTagId = p158.FlashCardTagId,
                Name = p158.Name,
                FlashCardCategoryId = p158.FlashCardCategoryId,
                FlashCardCategory = funcMain121(p158.FlashCardCategory),
                FlashCards = funcMain123(p158.FlashCards),
                RemovedAt = p158.RemovedAt,
                CreatedAt = p158.CreatedAt,
                CreatedBy = p158.CreatedBy,
                IsRemoved = p158.IsRemoved,
                ModifiedBy = p158.ModifiedBy,
                RemovedBy = p158.RemovedBy,
                ModifiedAt = p158.ModifiedAt
            };
        }
        
        private static ICollection<FlashCardAnswer> funcMain124(ICollection<FlashCardAnswer> p162)
        {
            if (p162 == null)
            {
                return null;
            }
            ICollection<FlashCardAnswer> result = new List<FlashCardAnswer>(p162.Count);
            
            IEnumerator<FlashCardAnswer> enumerator = p162.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardAnswer item = enumerator.Current;
                result.Add(TypeAdapter<FlashCardAnswer, FlashCardAnswer>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<UserFlashCardStatus> funcMain125(ICollection<UserFlashCardStatus> p163)
        {
            if (p163 == null)
            {
                return null;
            }
            ICollection<UserFlashCardStatus> result = new List<UserFlashCardStatus>(p163.Count);
            
            IEnumerator<UserFlashCardStatus> enumerator = p163.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                UserFlashCardStatus item = enumerator.Current;
                result.Add(item == null ? null : new UserFlashCardStatus()
                {
                    UserFlashCardStatusId = item.UserFlashCardStatusId,
                    FlashCardStatus = item.FlashCardStatus,
                    NextReviewAt = item.NextReviewAt,
                    UserId = item.UserId,
                    User = TypeAdapter<User, User>.Map.Invoke(item.User),
                    FlashCardId = item.FlashCardId,
                    FlashCard = TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item.FlashCard),
                    RemovedAt = item.RemovedAt,
                    CreatedAt = item.CreatedAt,
                    CreatedBy = item.CreatedBy,
                    IsRemoved = item.IsRemoved,
                    ModifiedBy = item.ModifiedBy,
                    RemovedBy = item.RemovedBy,
                    ModifiedAt = item.ModifiedAt
                });
            }
            return result;
            
        }
        
        private static ICollection<FlashCardTag> funcMain20(ICollection<FlashCardTag> p31)
        {
            if (p31 == null)
            {
                return null;
            }
            ICollection<FlashCardTag> result = new List<FlashCardTag>(p31.Count);
            
            IEnumerator<FlashCardTag> enumerator = p31.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardTag item = enumerator.Current;
                result.Add(TypeAdapter<FlashCardTag, FlashCardTag>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static FlashCardCategory funcMain27(FlashCardCategory p38)
        {
            return p38 == null ? null : new FlashCardCategory()
            {
                FlashCardCategoryId = p38.FlashCardCategoryId,
                Name = p38.Name,
                Detail = p38.Detail,
                Author = p38.Author,
                Price = p38.Price,
                IsFree = p38.IsFree,
                IsSuggested = p38.IsSuggested,
                RateAvg = p38.RateAvg,
                IsActive = p38.IsActive,
                Image = p38.Image == null ? null : new FlashCardCategoryImage()
                {
                    FlashCardCategoryId = p38.Image.FlashCardCategoryId,
                    ImageId = p38.Image.ImageId,
                    Name = p38.Image.Name,
                    FileLocation = p38.Image.FileLocation,
                    FileName = p38.Image.FileName,
                    RemovedAt = p38.Image.RemovedAt,
                    CreatedAt = p38.Image.CreatedAt,
                    CreatedBy = p38.Image.CreatedBy,
                    IsRemoved = p38.Image.IsRemoved,
                    ModifiedBy = p38.Image.ModifiedBy,
                    RemovedBy = p38.Image.RemovedBy,
                    ModifiedAt = p38.Image.ModifiedAt
                },
                FlashCardTags = funcMain28(p38.FlashCardTags),
                RemovedAt = p38.RemovedAt,
                CreatedAt = p38.CreatedAt,
                CreatedBy = p38.CreatedBy,
                IsRemoved = p38.IsRemoved,
                ModifiedBy = p38.ModifiedBy,
                RemovedBy = p38.RemovedBy,
                ModifiedAt = p38.ModifiedAt
            };
        }
        
        private static ICollection<FlashCard> funcMain29(ICollection<FlashCard> p40)
        {
            if (p40 == null)
            {
                return null;
            }
            ICollection<FlashCard> result = new List<FlashCard>(p40.Count);
            
            IEnumerator<FlashCard> enumerator = p40.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCard item = enumerator.Current;
                result.Add(TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<FlashCardTag> funcMain52(ICollection<FlashCardTag> p74)
        {
            if (p74 == null)
            {
                return null;
            }
            ICollection<FlashCardTag> result = new List<FlashCardTag>(p74.Count);
            
            IEnumerator<FlashCardTag> enumerator = p74.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardTag item = enumerator.Current;
                result.Add(TypeAdapter<FlashCardTag, FlashCardTag>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static FlashCardCategory funcMain59(FlashCardCategory p81)
        {
            return p81 == null ? null : new FlashCardCategory()
            {
                FlashCardCategoryId = p81.FlashCardCategoryId,
                Name = p81.Name,
                Detail = p81.Detail,
                Author = p81.Author,
                Price = p81.Price,
                IsFree = p81.IsFree,
                IsSuggested = p81.IsSuggested,
                RateAvg = p81.RateAvg,
                IsActive = p81.IsActive,
                Image = p81.Image == null ? null : new FlashCardCategoryImage()
                {
                    FlashCardCategoryId = p81.Image.FlashCardCategoryId,
                    ImageId = p81.Image.ImageId,
                    Name = p81.Image.Name,
                    FileLocation = p81.Image.FileLocation,
                    FileName = p81.Image.FileName,
                    RemovedAt = p81.Image.RemovedAt,
                    CreatedAt = p81.Image.CreatedAt,
                    CreatedBy = p81.Image.CreatedBy,
                    IsRemoved = p81.Image.IsRemoved,
                    ModifiedBy = p81.Image.ModifiedBy,
                    RemovedBy = p81.Image.RemovedBy,
                    ModifiedAt = p81.Image.ModifiedAt
                },
                FlashCardTags = funcMain60(p81.FlashCardTags),
                RemovedAt = p81.RemovedAt,
                CreatedAt = p81.CreatedAt,
                CreatedBy = p81.CreatedBy,
                IsRemoved = p81.IsRemoved,
                ModifiedBy = p81.ModifiedBy,
                RemovedBy = p81.RemovedBy,
                ModifiedAt = p81.ModifiedAt
            };
        }
        
        private static ICollection<FlashCard> funcMain61(ICollection<FlashCard> p83)
        {
            if (p83 == null)
            {
                return null;
            }
            ICollection<FlashCard> result = new List<FlashCard>(p83.Count);
            
            IEnumerator<FlashCard> enumerator = p83.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCard item = enumerator.Current;
                result.Add(TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<FlashCardTag> funcMain83(ICollection<FlashCardTag> p111)
        {
            if (p111 == null)
            {
                return null;
            }
            ICollection<FlashCardTag> result = new List<FlashCardTag>(p111.Count);
            
            IEnumerator<FlashCardTag> enumerator = p111.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardTag item = enumerator.Current;
                result.Add(TypeAdapter<FlashCardTag, FlashCardTag>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static FlashCardCategory funcMain90(FlashCardCategory p118)
        {
            return p118 == null ? null : new FlashCardCategory()
            {
                FlashCardCategoryId = p118.FlashCardCategoryId,
                Name = p118.Name,
                Detail = p118.Detail,
                Author = p118.Author,
                Price = p118.Price,
                IsFree = p118.IsFree,
                IsSuggested = p118.IsSuggested,
                RateAvg = p118.RateAvg,
                IsActive = p118.IsActive,
                Image = p118.Image == null ? null : new FlashCardCategoryImage()
                {
                    FlashCardCategoryId = p118.Image.FlashCardCategoryId,
                    ImageId = p118.Image.ImageId,
                    Name = p118.Image.Name,
                    FileLocation = p118.Image.FileLocation,
                    FileName = p118.Image.FileName,
                    RemovedAt = p118.Image.RemovedAt,
                    CreatedAt = p118.Image.CreatedAt,
                    CreatedBy = p118.Image.CreatedBy,
                    IsRemoved = p118.Image.IsRemoved,
                    ModifiedBy = p118.Image.ModifiedBy,
                    RemovedBy = p118.Image.RemovedBy,
                    ModifiedAt = p118.Image.ModifiedAt
                },
                FlashCardTags = funcMain91(p118.FlashCardTags),
                RemovedAt = p118.RemovedAt,
                CreatedAt = p118.CreatedAt,
                CreatedBy = p118.CreatedBy,
                IsRemoved = p118.IsRemoved,
                ModifiedBy = p118.ModifiedBy,
                RemovedBy = p118.RemovedBy,
                ModifiedAt = p118.ModifiedAt
            };
        }
        
        private static ICollection<FlashCard> funcMain92(ICollection<FlashCard> p120)
        {
            if (p120 == null)
            {
                return null;
            }
            ICollection<FlashCard> result = new List<FlashCard>(p120.Count);
            
            IEnumerator<FlashCard> enumerator = p120.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCard item = enumerator.Current;
                result.Add(TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<FlashCardTag> funcMain114(ICollection<FlashCardTag> p152)
        {
            if (p152 == null)
            {
                return null;
            }
            ICollection<FlashCardTag> result = new List<FlashCardTag>(p152.Count);
            
            IEnumerator<FlashCardTag> enumerator = p152.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardTag item = enumerator.Current;
                result.Add(TypeAdapter<FlashCardTag, FlashCardTag>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static FlashCardCategory funcMain121(FlashCardCategory p159)
        {
            return p159 == null ? null : new FlashCardCategory()
            {
                FlashCardCategoryId = p159.FlashCardCategoryId,
                Name = p159.Name,
                Detail = p159.Detail,
                Author = p159.Author,
                Price = p159.Price,
                IsFree = p159.IsFree,
                IsSuggested = p159.IsSuggested,
                RateAvg = p159.RateAvg,
                IsActive = p159.IsActive,
                Image = p159.Image == null ? null : new FlashCardCategoryImage()
                {
                    FlashCardCategoryId = p159.Image.FlashCardCategoryId,
                    ImageId = p159.Image.ImageId,
                    Name = p159.Image.Name,
                    FileLocation = p159.Image.FileLocation,
                    FileName = p159.Image.FileName,
                    RemovedAt = p159.Image.RemovedAt,
                    CreatedAt = p159.Image.CreatedAt,
                    CreatedBy = p159.Image.CreatedBy,
                    IsRemoved = p159.Image.IsRemoved,
                    ModifiedBy = p159.Image.ModifiedBy,
                    RemovedBy = p159.Image.RemovedBy,
                    ModifiedAt = p159.Image.ModifiedAt
                },
                FlashCardTags = funcMain122(p159.FlashCardTags),
                RemovedAt = p159.RemovedAt,
                CreatedAt = p159.CreatedAt,
                CreatedBy = p159.CreatedBy,
                IsRemoved = p159.IsRemoved,
                ModifiedBy = p159.ModifiedBy,
                RemovedBy = p159.RemovedBy,
                ModifiedAt = p159.ModifiedAt
            };
        }
        
        private static ICollection<FlashCard> funcMain123(ICollection<FlashCard> p161)
        {
            if (p161 == null)
            {
                return null;
            }
            ICollection<FlashCard> result = new List<FlashCard>(p161.Count);
            
            IEnumerator<FlashCard> enumerator = p161.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCard item = enumerator.Current;
                result.Add(TypeAdapter<FlashCard, FlashCard>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<FlashCardTag> funcMain28(ICollection<FlashCardTag> p39)
        {
            if (p39 == null)
            {
                return null;
            }
            ICollection<FlashCardTag> result = new List<FlashCardTag>(p39.Count);
            
            IEnumerator<FlashCardTag> enumerator = p39.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardTag item = enumerator.Current;
                result.Add(TypeAdapter<FlashCardTag, FlashCardTag>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<FlashCardTag> funcMain60(ICollection<FlashCardTag> p82)
        {
            if (p82 == null)
            {
                return null;
            }
            ICollection<FlashCardTag> result = new List<FlashCardTag>(p82.Count);
            
            IEnumerator<FlashCardTag> enumerator = p82.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardTag item = enumerator.Current;
                result.Add(TypeAdapter<FlashCardTag, FlashCardTag>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<FlashCardTag> funcMain91(ICollection<FlashCardTag> p119)
        {
            if (p119 == null)
            {
                return null;
            }
            ICollection<FlashCardTag> result = new List<FlashCardTag>(p119.Count);
            
            IEnumerator<FlashCardTag> enumerator = p119.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardTag item = enumerator.Current;
                result.Add(TypeAdapter<FlashCardTag, FlashCardTag>.Map.Invoke(item));
            }
            return result;
            
        }
        
        private static ICollection<FlashCardTag> funcMain122(ICollection<FlashCardTag> p160)
        {
            if (p160 == null)
            {
                return null;
            }
            ICollection<FlashCardTag> result = new List<FlashCardTag>(p160.Count);
            
            IEnumerator<FlashCardTag> enumerator = p160.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardTag item = enumerator.Current;
                result.Add(TypeAdapter<FlashCardTag, FlashCardTag>.Map.Invoke(item));
            }
            return result;
            
        }
    }
}