using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using iMed.Domain.Dtos.LargDtos;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Entities;

namespace iMed.Domain.Mappers
{
    public static partial class CourseCategoryMapper
    {
        public static CourseCategory AdaptToCourseCategory(this CourseCategorySDto p1)
        {
            return p1 == null ? null : new CourseCategory()
            {
                CourseCategoryId = p1.CourseCategoryId,
                Name = p1.Name,
                CreatedAt = p1.CreatedAt
            };
        }
        public static CourseCategory AdaptTo(this CourseCategorySDto p2, CourseCategory p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CourseCategory result = p3 ?? new CourseCategory();
            
            result.CourseCategoryId = p2.CourseCategoryId;
            result.Name = p2.Name;
            result.CreatedAt = p2.CreatedAt;
            return result;
            
        }
        public static Expression<Func<CourseCategorySDto, CourseCategory>> ProjectToCourseCategory => p4 => new CourseCategory()
        {
            CourseCategoryId = p4.CourseCategoryId,
            Name = p4.Name,
            CreatedAt = p4.CreatedAt
        };
        public static CourseCategorySDto AdaptToSDto(this CourseCategory p5)
        {
            return p5 == null ? null : new CourseCategorySDto()
            {
                CourseCategoryId = p5.CourseCategoryId,
                Name = p5.Name,
                CreatedAt = p5.CreatedAt
            };
        }
        public static CourseCategorySDto AdaptTo(this CourseCategory p6, CourseCategorySDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            CourseCategorySDto result = p7 ?? new CourseCategorySDto();
            
            result.CourseCategoryId = p6.CourseCategoryId;
            result.Name = p6.Name;
            result.CreatedAt = p6.CreatedAt;
            return result;
            
        }
        public static Expression<Func<CourseCategory, CourseCategorySDto>> ProjectToSDto => p8 => new CourseCategorySDto()
        {
            CourseCategoryId = p8.CourseCategoryId,
            Name = p8.Name,
            CreatedAt = p8.CreatedAt
        };
        public static CourseCategory AdaptToCourseCategory(this CourseCategoryLDto p9)
        {
            return p9 == null ? null : new CourseCategory()
            {
                CourseCategoryId = p9.CourseCategoryId,
                Name = p9.Name,
                Courses = funcMain1(p9.Courses),
                CreatedAt = p9.CreatedAt
            };
        }
        public static CourseCategory AdaptTo(this CourseCategoryLDto p11, CourseCategory p12)
        {
            if (p11 == null)
            {
                return null;
            }
            CourseCategory result = p12 ?? new CourseCategory();
            
            result.CourseCategoryId = p11.CourseCategoryId;
            result.Name = p11.Name;
            result.Courses = funcMain2(p11.Courses, result.Courses);
            result.CreatedAt = p11.CreatedAt;
            return result;
            
        }
        public static Expression<Func<CourseCategoryLDto, CourseCategory>> ProjectLDtoToCourseCategory => p15 => new CourseCategory()
        {
            CourseCategoryId = p15.CourseCategoryId,
            Name = p15.Name,
            Courses = p15.Courses.Select<CourseSDto, Course>(p16 => new Course()
            {
                CourseId = p16.CourseId,
                IsSuggested = p16.IsSuggested,
                Name = p16.Name,
                Detail = p16.Detail,
                Teacher = p16.Teacher,
                Reference = p16.Reference,
                IsFree = p16.IsFree,
                Price = p16.Price,
                CourseCategoryId = p16.CourseCategoryId,
                RateAvg = p16.RateAvg,
                CourseCategory = new CourseCategory() {Name = p16.CourseCategoryName},
                Image = new CourseImage() {FileName = p16.ImageFileName},
                CreatedAt = p16.CreatedAt
            }).ToList<Course>(),
            CreatedAt = p15.CreatedAt
        };
        public static CourseCategoryLDto AdaptToLDto(this CourseCategory p17)
        {
            return p17 == null ? null : new CourseCategoryLDto()
            {
                CourseCategoryId = p17.CourseCategoryId,
                Name = p17.Name,
                CreatedAt = p17.CreatedAt,
                Courses = funcMain3(p17.Courses)
            };
        }
        public static CourseCategoryLDto AdaptTo(this CourseCategory p19, CourseCategoryLDto p20)
        {
            if (p19 == null)
            {
                return null;
            }
            CourseCategoryLDto result = p20 ?? new CourseCategoryLDto();
            
            result.CourseCategoryId = p19.CourseCategoryId;
            result.Name = p19.Name;
            result.CreatedAt = p19.CreatedAt;
            result.Courses = funcMain4(p19.Courses, result.Courses);
            return result;
            
        }
        public static Expression<Func<CourseCategory, CourseCategoryLDto>> ProjectToLDto => p23 => new CourseCategoryLDto()
        {
            CourseCategoryId = p23.CourseCategoryId,
            Name = p23.Name,
            CreatedAt = p23.CreatedAt,
            Courses = p23.Courses.Select<Course, CourseSDto>(p24 => new CourseSDto()
            {
                CourseId = p24.CourseId,
                Name = p24.Name,
                Detail = p24.Detail,
                Teacher = p24.Teacher,
                Reference = p24.Reference,
                IsFree = p24.IsFree,
                Price = p24.Price,
                IsSuggested = p24.IsSuggested,
                CourseCategoryId = p24.CourseCategoryId,
                CourseCategoryName = p24.CourseCategory != null ? p24.CourseCategory.Name : null,
                RateAvg = p24.RateAvg,
                ImageFileName = p24.Image != null ? p24.Image.FileName : null,
                CreatedAt = p24.CreatedAt
            }).ToList<CourseSDto>()
        };
        
        private static ICollection<Course> funcMain1(List<CourseSDto> p10)
        {
            if (p10 == null)
            {
                return null;
            }
            ICollection<Course> result = new List<Course>(p10.Count);
            
            int i = 0;
            int len = p10.Count;
            
            while (i < len)
            {
                CourseSDto item = p10[i];
                result.Add(item == null ? null : new Course()
                {
                    CourseId = item.CourseId,
                    IsSuggested = item.IsSuggested,
                    Name = item.Name,
                    Detail = item.Detail,
                    Teacher = item.Teacher,
                    Reference = item.Reference,
                    IsFree = item.IsFree,
                    Price = item.Price,
                    CourseCategoryId = item.CourseCategoryId,
                    RateAvg = item.RateAvg,
                    CourseCategory = new CourseCategory() {Name = item.CourseCategoryName},
                    Image = new CourseImage() {FileName = item.ImageFileName},
                    CreatedAt = item.CreatedAt
                });
                i++;
            }
            return result;
            
        }
        
        private static ICollection<Course> funcMain2(List<CourseSDto> p13, ICollection<Course> p14)
        {
            if (p13 == null)
            {
                return null;
            }
            ICollection<Course> result = new List<Course>(p13.Count);
            
            int i = 0;
            int len = p13.Count;
            
            while (i < len)
            {
                CourseSDto item = p13[i];
                result.Add(item == null ? null : new Course()
                {
                    CourseId = item.CourseId,
                    IsSuggested = item.IsSuggested,
                    Name = item.Name,
                    Detail = item.Detail,
                    Teacher = item.Teacher,
                    Reference = item.Reference,
                    IsFree = item.IsFree,
                    Price = item.Price,
                    CourseCategoryId = item.CourseCategoryId,
                    RateAvg = item.RateAvg,
                    CourseCategory = new CourseCategory() {Name = item.CourseCategoryName},
                    Image = new CourseImage() {FileName = item.ImageFileName},
                    CreatedAt = item.CreatedAt
                });
                i++;
            }
            return result;
            
        }
        
        private static List<CourseSDto> funcMain3(ICollection<Course> p18)
        {
            if (p18 == null)
            {
                return null;
            }
            List<CourseSDto> result = new List<CourseSDto>(p18.Count);
            
            IEnumerator<Course> enumerator = p18.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Course item = enumerator.Current;
                result.Add(item == null ? null : new CourseSDto()
                {
                    CourseId = item.CourseId,
                    Name = item.Name,
                    Detail = item.Detail,
                    Teacher = item.Teacher,
                    Reference = item.Reference,
                    IsFree = item.IsFree,
                    Price = item.Price,
                    IsSuggested = item.IsSuggested,
                    CourseCategoryId = item.CourseCategoryId,
                    CourseCategoryName = item.CourseCategory != null ? item.CourseCategory.Name : null,
                    RateAvg = item.RateAvg,
                    ImageFileName = item.Image != null ? item.Image.FileName : null,
                    CreatedAt = item.CreatedAt
                });
            }
            return result;
            
        }
        
        private static List<CourseSDto> funcMain4(ICollection<Course> p21, List<CourseSDto> p22)
        {
            if (p21 == null)
            {
                return null;
            }
            List<CourseSDto> result = new List<CourseSDto>(p21.Count);
            
            IEnumerator<Course> enumerator = p21.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                Course item = enumerator.Current;
                result.Add(item == null ? null : new CourseSDto()
                {
                    CourseId = item.CourseId,
                    Name = item.Name,
                    Detail = item.Detail,
                    Teacher = item.Teacher,
                    Reference = item.Reference,
                    IsFree = item.IsFree,
                    Price = item.Price,
                    IsSuggested = item.IsSuggested,
                    CourseCategoryId = item.CourseCategoryId,
                    CourseCategoryName = item.CourseCategory != null ? item.CourseCategory.Name : null,
                    RateAvg = item.RateAvg,
                    ImageFileName = item.Image != null ? item.Image.FileName : null,
                    CreatedAt = item.CreatedAt
                });
            }
            return result;
            
        }
    }
}