using System;
using System.Linq.Expressions;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Entities;
using Mapster.Models;

namespace iMed.Domain.Mappers
{
    public static partial class FlashCardCategoryRateMapper
    {
        public static FlashCardCategoryRate AdaptToFlashCardCategoryRate(this FlashCardCategoryRateSDto p1)
        {
            return p1 == null ? null : new FlashCardCategoryRate()
            {
                FlashCardCategoryId = p1.FlashCardCategoryId,
                FlashCardCategory = new FlashCardCategory() {Name = p1.FlashCardCategoryName},
                RateId = p1.RateId,
                RateMessage = p1.RateMessage,
                Author = p1.Author,
                Score = p1.Score,
                IsConfirmed = p1.IsConfirmed,
                CreatedAt = p1.CreatedAt
            };
        }
        public static FlashCardCategoryRate AdaptTo(this FlashCardCategoryRateSDto p2, FlashCardCategoryRate p3)
        {
            if (p2 == null)
            {
                return null;
            }
            FlashCardCategoryRate result = p3 ?? new FlashCardCategoryRate();
            
            result.FlashCardCategoryId = p2.FlashCardCategoryId;
            result.FlashCardCategory = funcMain1(new Never(), result.FlashCardCategory, p2);
            result.RateId = p2.RateId;
            result.RateMessage = p2.RateMessage;
            result.Author = p2.Author;
            result.Score = p2.Score;
            result.IsConfirmed = p2.IsConfirmed;
            result.CreatedAt = p2.CreatedAt;
            return result;
            
        }
        public static Expression<Func<FlashCardCategoryRateSDto, FlashCardCategoryRate>> ProjectToFlashCardCategoryRate => p6 => new FlashCardCategoryRate()
        {
            FlashCardCategoryId = p6.FlashCardCategoryId,
            FlashCardCategory = new FlashCardCategory() {Name = p6.FlashCardCategoryName},
            RateId = p6.RateId,
            RateMessage = p6.RateMessage,
            Author = p6.Author,
            Score = p6.Score,
            IsConfirmed = p6.IsConfirmed,
            CreatedAt = p6.CreatedAt
        };
        public static FlashCardCategoryRateSDto AdaptToSDto(this FlashCardCategoryRate p7)
        {
            return p7 == null ? null : new FlashCardCategoryRateSDto()
            {
                RateId = p7.RateId,
                FlashCardCategoryId = p7.FlashCardCategoryId,
                FlashCardCategoryName = p7.FlashCardCategory != null ? p7.FlashCardCategory.Name : null,
                RateMessage = p7.RateMessage,
                Author = p7.Author,
                IsConfirmed = p7.IsConfirmed,
                Score = p7.Score,
                CreatedAt = p7.CreatedAt
            };
        }
        public static FlashCardCategoryRateSDto AdaptTo(this FlashCardCategoryRate p8, FlashCardCategoryRateSDto p9)
        {
            if (p8 == null)
            {
                return null;
            }
            FlashCardCategoryRateSDto result = p9 ?? new FlashCardCategoryRateSDto();
            
            result.RateId = p8.RateId;
            result.FlashCardCategoryId = p8.FlashCardCategoryId;
            result.FlashCardCategoryName = p8.FlashCardCategory != null ? p8.FlashCardCategory.Name : null;
            result.RateMessage = p8.RateMessage;
            result.Author = p8.Author;
            result.IsConfirmed = p8.IsConfirmed;
            result.Score = p8.Score;
            result.CreatedAt = p8.CreatedAt;
            return result;
            
        }
        public static Expression<Func<FlashCardCategoryRate, FlashCardCategoryRateSDto>> ProjectToSDto => p10 => new FlashCardCategoryRateSDto()
        {
            RateId = p10.RateId,
            FlashCardCategoryId = p10.FlashCardCategoryId,
            FlashCardCategoryName = p10.FlashCardCategory != null ? p10.FlashCardCategory.Name : null,
            RateMessage = p10.RateMessage,
            Author = p10.Author,
            IsConfirmed = p10.IsConfirmed,
            Score = p10.Score,
            CreatedAt = p10.CreatedAt
        };
        
        private static FlashCardCategory funcMain1(Never p4, FlashCardCategory p5, FlashCardCategoryRateSDto p2)
        {
            FlashCardCategory result = p5 ?? new FlashCardCategory();
            
            result.Name = p2.FlashCardCategoryName;
            return result;
            
        }
    }
}