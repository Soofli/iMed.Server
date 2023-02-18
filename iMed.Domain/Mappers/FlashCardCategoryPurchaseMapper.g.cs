using System;
using System.Linq.Expressions;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Entities;

namespace iMed.Domain.Mappers
{
    public static partial class FlashCardCategoryPurchaseMapper
    {
        public static FlashCardCategoryPurchase AdaptToFlashCardCategoryPurchase(this FlashCardCategoryPurchaseSDto p1)
        {
            return p1 == null ? null : new FlashCardCategoryPurchase()
            {
                FlashCardCategoryId = p1.FlashCardCategoryId,
                PurchaseId = p1.PurchaseId,
                Price = p1.Price,
                IsFree = p1.IsFree,
                UserId = p1.UserId,
                CreatedAt = p1.CreatedAt
            };
        }
        public static FlashCardCategoryPurchase AdaptTo(this FlashCardCategoryPurchaseSDto p2, FlashCardCategoryPurchase p3)
        {
            if (p2 == null)
            {
                return null;
            }
            FlashCardCategoryPurchase result = p3 ?? new FlashCardCategoryPurchase();
            
            result.FlashCardCategoryId = p2.FlashCardCategoryId;
            result.PurchaseId = p2.PurchaseId;
            result.Price = p2.Price;
            result.IsFree = p2.IsFree;
            result.UserId = p2.UserId;
            result.CreatedAt = p2.CreatedAt;
            return result;
            
        }
        public static Expression<Func<FlashCardCategoryPurchaseSDto, FlashCardCategoryPurchase>> ProjectToFlashCardCategoryPurchase => p4 => new FlashCardCategoryPurchase()
        {
            FlashCardCategoryId = p4.FlashCardCategoryId,
            PurchaseId = p4.PurchaseId,
            Price = p4.Price,
            IsFree = p4.IsFree,
            UserId = p4.UserId,
            CreatedAt = p4.CreatedAt
        };
        public static FlashCardCategoryPurchaseSDto AdaptToSDto(this FlashCardCategoryPurchase p5)
        {
            return p5 == null ? null : new FlashCardCategoryPurchaseSDto()
            {
                PurchaseId = p5.PurchaseId,
                Price = p5.Price,
                IsFree = p5.IsFree,
                UserId = p5.UserId,
                UserFirstName = p5.User == null ? null : p5.User.FirstName,
                UserLastName = p5.User == null ? null : p5.User.LastName,
                FlashCardCategoryId = p5.FlashCardCategoryId,
                FlashCardCategoryName = p5.FlashCardCategory == null ? null : p5.FlashCardCategory.Name,
                CreatedAt = p5.CreatedAt
            };
        }
        public static FlashCardCategoryPurchaseSDto AdaptTo(this FlashCardCategoryPurchase p6, FlashCardCategoryPurchaseSDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            FlashCardCategoryPurchaseSDto result = p7 ?? new FlashCardCategoryPurchaseSDto();
            
            result.PurchaseId = p6.PurchaseId;
            result.Price = p6.Price;
            result.IsFree = p6.IsFree;
            result.UserId = p6.UserId;
            result.UserFirstName = p6.User == null ? null : p6.User.FirstName;
            result.UserLastName = p6.User == null ? null : p6.User.LastName;
            result.FlashCardCategoryId = p6.FlashCardCategoryId;
            result.FlashCardCategoryName = p6.FlashCardCategory == null ? null : p6.FlashCardCategory.Name;
            result.CreatedAt = p6.CreatedAt;
            return result;
            
        }
        public static Expression<Func<FlashCardCategoryPurchase, FlashCardCategoryPurchaseSDto>> ProjectToSDto => p8 => new FlashCardCategoryPurchaseSDto()
        {
            PurchaseId = p8.PurchaseId,
            Price = p8.Price,
            IsFree = p8.IsFree,
            UserId = p8.UserId,
            UserFirstName = p8.User.FirstName,
            UserLastName = p8.User.LastName,
            FlashCardCategoryId = p8.FlashCardCategoryId,
            FlashCardCategoryName = p8.FlashCardCategory.Name,
            CreatedAt = p8.CreatedAt
        };
    }
}