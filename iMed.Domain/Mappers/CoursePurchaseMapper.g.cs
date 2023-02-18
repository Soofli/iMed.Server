using System;
using System.Linq.Expressions;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Entities;

namespace iMed.Domain.Mappers
{
    public static partial class CoursePurchaseMapper
    {
        public static CoursePurchase AdaptToCoursePurchase(this CoursePurchaseSDto p1)
        {
            return p1 == null ? null : new CoursePurchase()
            {
                CourseId = p1.CourseId,
                PurchaseId = p1.PurchaseId,
                Price = p1.Price,
                IsFree = p1.IsFree,
                UserId = p1.UserId,
                CreatedAt = p1.CreatedAt
            };
        }
        public static CoursePurchase AdaptTo(this CoursePurchaseSDto p2, CoursePurchase p3)
        {
            if (p2 == null)
            {
                return null;
            }
            CoursePurchase result = p3 ?? new CoursePurchase();
            
            result.CourseId = p2.CourseId;
            result.PurchaseId = p2.PurchaseId;
            result.Price = p2.Price;
            result.IsFree = p2.IsFree;
            result.UserId = p2.UserId;
            result.CreatedAt = p2.CreatedAt;
            return result;
            
        }
        public static Expression<Func<CoursePurchaseSDto, CoursePurchase>> ProjectToCoursePurchase => p4 => new CoursePurchase()
        {
            CourseId = p4.CourseId,
            PurchaseId = p4.PurchaseId,
            Price = p4.Price,
            IsFree = p4.IsFree,
            UserId = p4.UserId,
            CreatedAt = p4.CreatedAt
        };
        public static CoursePurchaseSDto AdaptToSDto(this CoursePurchase p5)
        {
            return p5 == null ? null : new CoursePurchaseSDto()
            {
                PurchaseId = p5.PurchaseId,
                Price = p5.Price,
                IsFree = p5.IsFree,
                UserId = p5.UserId,
                UserFirstName = p5.User == null ? null : p5.User.FirstName,
                UserLastName = p5.User == null ? null : p5.User.LastName,
                CourseId = p5.CourseId,
                CourseName = p5.Course == null ? null : p5.Course.Name,
                CreatedAt = p5.CreatedAt
            };
        }
        public static CoursePurchaseSDto AdaptTo(this CoursePurchase p6, CoursePurchaseSDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            CoursePurchaseSDto result = p7 ?? new CoursePurchaseSDto();
            
            result.PurchaseId = p6.PurchaseId;
            result.Price = p6.Price;
            result.IsFree = p6.IsFree;
            result.UserId = p6.UserId;
            result.UserFirstName = p6.User == null ? null : p6.User.FirstName;
            result.UserLastName = p6.User == null ? null : p6.User.LastName;
            result.CourseId = p6.CourseId;
            result.CourseName = p6.Course == null ? null : p6.Course.Name;
            result.CreatedAt = p6.CreatedAt;
            return result;
            
        }
        public static Expression<Func<CoursePurchase, CoursePurchaseSDto>> ProjectToSDto => p8 => new CoursePurchaseSDto()
        {
            PurchaseId = p8.PurchaseId,
            Price = p8.Price,
            IsFree = p8.IsFree,
            UserId = p8.UserId,
            UserFirstName = p8.User.FirstName,
            UserLastName = p8.User.LastName,
            CourseId = p8.CourseId,
            CourseName = p8.Course.Name,
            CreatedAt = p8.CreatedAt
        };
    }
}