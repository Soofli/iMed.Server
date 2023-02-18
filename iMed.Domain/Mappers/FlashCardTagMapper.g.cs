using System;
using System.Linq.Expressions;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Entities;

namespace iMed.Domain.Mappers
{
    public static partial class FlashCardTagMapper
    {
        public static FlashCardTag AdaptToFlashCardTag(this FlashCardTagSDto p1)
        {
            return p1 == null ? null : new FlashCardTag()
            {
                FlashCardTagId = p1.FlashCardTagId,
                Name = p1.Name,
                FlashCardCategoryId = p1.FlashCardCategoryId
            };
        }
        public static FlashCardTag AdaptTo(this FlashCardTagSDto p2, FlashCardTag p3)
        {
            if (p2 == null)
            {
                return null;
            }
            FlashCardTag result = p3 ?? new FlashCardTag();
            
            result.FlashCardTagId = p2.FlashCardTagId;
            result.Name = p2.Name;
            result.FlashCardCategoryId = p2.FlashCardCategoryId;
            return result;
            
        }
        public static Expression<Func<FlashCardTagSDto, FlashCardTag>> ProjectToFlashCardTag => p4 => new FlashCardTag()
        {
            FlashCardTagId = p4.FlashCardTagId,
            Name = p4.Name,
            FlashCardCategoryId = p4.FlashCardCategoryId
        };
        public static FlashCardTagSDto AdaptToSDto(this FlashCardTag p5)
        {
            return p5 == null ? null : new FlashCardTagSDto()
            {
                FlashCardTagId = p5.FlashCardTagId,
                Name = p5.Name,
                FlashCardCategoryId = p5.FlashCardCategoryId
            };
        }
        public static FlashCardTagSDto AdaptTo(this FlashCardTag p6, FlashCardTagSDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            FlashCardTagSDto result = p7 ?? new FlashCardTagSDto();
            
            result.FlashCardTagId = p6.FlashCardTagId;
            result.Name = p6.Name;
            result.FlashCardCategoryId = p6.FlashCardCategoryId;
            return result;
            
        }
        public static Expression<Func<FlashCardTag, FlashCardTagSDto>> ProjectToSDto => p8 => new FlashCardTagSDto()
        {
            FlashCardTagId = p8.FlashCardTagId,
            Name = p8.Name,
            FlashCardCategoryId = p8.FlashCardCategoryId
        };
    }
}