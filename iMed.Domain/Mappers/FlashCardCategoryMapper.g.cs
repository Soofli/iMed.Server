using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using iMed.Domain.Dtos.LargDtos;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Entities;
using Mapster.Models;

namespace iMed.Domain.Mappers
{
    public static partial class FlashCardCategoryMapper
    {
        public static FlashCardCategory AdaptToFlashCardCategory(this FlashCardCategorySDto p1)
        {
            return p1 == null ? null : new FlashCardCategory()
            {
                FlashCardCategoryId = p1.FlashCardCategoryId,
                Name = p1.Name,
                Detail = p1.Detail,
                Author = p1.Author,
                Price = p1.Price,
                IsFree = p1.IsFree,
                IsSuggested = p1.IsSuggested,
                RateAvg = p1.RateAvg,
                IsActive = p1.IsActive,
                Image = new FlashCardCategoryImage() {FileName = p1.ImageFileName}
            };
        }
        public static FlashCardCategory AdaptTo(this FlashCardCategorySDto p2, FlashCardCategory p3)
        {
            if (p2 == null)
            {
                return null;
            }
            FlashCardCategory result = p3 ?? new FlashCardCategory();
            
            result.FlashCardCategoryId = p2.FlashCardCategoryId;
            result.Name = p2.Name;
            result.Detail = p2.Detail;
            result.Author = p2.Author;
            result.Price = p2.Price;
            result.IsFree = p2.IsFree;
            result.IsSuggested = p2.IsSuggested;
            result.RateAvg = p2.RateAvg;
            result.IsActive = p2.IsActive;
            result.Image = funcMain1(new Never(), result.Image, p2);
            return result;
            
        }
        public static Expression<Func<FlashCardCategorySDto, FlashCardCategory>> ProjectToFlashCardCategory => p6 => new FlashCardCategory()
        {
            FlashCardCategoryId = p6.FlashCardCategoryId,
            Name = p6.Name,
            Detail = p6.Detail,
            Author = p6.Author,
            Price = p6.Price,
            IsFree = p6.IsFree,
            IsSuggested = p6.IsSuggested,
            RateAvg = p6.RateAvg,
            IsActive = p6.IsActive,
            Image = new FlashCardCategoryImage() {FileName = p6.ImageFileName}
        };
        public static FlashCardCategorySDto AdaptToSDto(this FlashCardCategory p7)
        {
            return p7 == null ? null : new FlashCardCategorySDto()
            {
                FlashCardCategoryId = p7.FlashCardCategoryId,
                Detail = p7.Detail,
                Author = p7.Author,
                Name = p7.Name,
                Price = p7.Price,
                IsFree = p7.IsFree,
                IsSuggested = p7.IsSuggested,
                RateAvg = p7.RateAvg,
                ImageFileName = p7.Image != null ? p7.Image.FileName : null,
                IsActive = p7.IsActive
            };
        }
        public static FlashCardCategorySDto AdaptTo(this FlashCardCategory p8, FlashCardCategorySDto p9)
        {
            if (p8 == null)
            {
                return null;
            }
            FlashCardCategorySDto result = p9 ?? new FlashCardCategorySDto();
            
            result.FlashCardCategoryId = p8.FlashCardCategoryId;
            result.Detail = p8.Detail;
            result.Author = p8.Author;
            result.Name = p8.Name;
            result.Price = p8.Price;
            result.IsFree = p8.IsFree;
            result.IsSuggested = p8.IsSuggested;
            result.RateAvg = p8.RateAvg;
            result.ImageFileName = p8.Image != null ? p8.Image.FileName : null;
            result.IsActive = p8.IsActive;
            return result;
            
        }
        public static Expression<Func<FlashCardCategory, FlashCardCategorySDto>> ProjectToSDto => p10 => new FlashCardCategorySDto()
        {
            FlashCardCategoryId = p10.FlashCardCategoryId,
            Detail = p10.Detail,
            Author = p10.Author,
            Name = p10.Name,
            Price = p10.Price,
            IsFree = p10.IsFree,
            IsSuggested = p10.IsSuggested,
            RateAvg = p10.RateAvg,
            ImageFileName = p10.Image != null ? p10.Image.FileName : null,
            IsActive = p10.IsActive
        };
        public static FlashCardCategory AdaptToFlashCardCategory(this FlashCardCategoryLDto p11)
        {
            return p11 == null ? null : new FlashCardCategory()
            {
                FlashCardCategoryId = p11.FlashCardCategoryId,
                Name = p11.Name,
                Detail = p11.Detail,
                Author = p11.Author,
                Price = p11.Price,
                IsFree = p11.IsFree,
                IsSuggested = p11.IsSuggested,
                RateAvg = p11.RateAvg,
                IsActive = p11.IsActive,
                Image = p11.Image == null ? null : new FlashCardCategoryImage()
                {
                    FlashCardCategoryId = p11.Image.FlashCardCategoryId,
                    ImageId = p11.Image.ImageId,
                    Name = p11.Image.Name,
                    FileLocation = p11.Image.FileLocation,
                    FileName = p11.Image.FileName,
                    RemovedAt = p11.Image.RemovedAt,
                    CreatedAt = p11.Image.CreatedAt,
                    CreatedBy = p11.Image.CreatedBy,
                    IsRemoved = p11.Image.IsRemoved,
                    ModifiedBy = p11.Image.ModifiedBy,
                    RemovedBy = p11.Image.RemovedBy,
                    ModifiedAt = p11.Image.ModifiedAt
                },
                FlashCardTags = funcMain2(p11.FlashCardTags)
            };
        }
        public static FlashCardCategory AdaptTo(this FlashCardCategoryLDto p13, FlashCardCategory p14)
        {
            if (p13 == null)
            {
                return null;
            }
            FlashCardCategory result = p14 ?? new FlashCardCategory();
            
            result.FlashCardCategoryId = p13.FlashCardCategoryId;
            result.Name = p13.Name;
            result.Detail = p13.Detail;
            result.Author = p13.Author;
            result.Price = p13.Price;
            result.IsFree = p13.IsFree;
            result.IsSuggested = p13.IsSuggested;
            result.RateAvg = p13.RateAvg;
            result.IsActive = p13.IsActive;
            result.Image = funcMain3(p13.Image, result.Image);
            result.FlashCardTags = funcMain4(p13.FlashCardTags, result.FlashCardTags);
            return result;
            
        }
        public static Expression<Func<FlashCardCategoryLDto, FlashCardCategory>> ProjectLDtoToFlashCardCategory => p19 => new FlashCardCategory()
        {
            FlashCardCategoryId = p19.FlashCardCategoryId,
            Name = p19.Name,
            Detail = p19.Detail,
            Author = p19.Author,
            Price = p19.Price,
            IsFree = p19.IsFree,
            IsSuggested = p19.IsSuggested,
            RateAvg = p19.RateAvg,
            IsActive = p19.IsActive,
            Image = p19.Image,
            FlashCardTags = p19.FlashCardTags.Select<FlashCardTagSDto, FlashCardTag>(p20 => new FlashCardTag()
            {
                FlashCardTagId = p20.FlashCardTagId,
                Name = p20.Name,
                FlashCardCategoryId = p20.FlashCardCategoryId
            }).ToList<FlashCardTag>()
        };
        public static FlashCardCategoryLDto AdaptToLDto(this FlashCardCategory p21)
        {
            return p21 == null ? null : new FlashCardCategoryLDto()
            {
                FlashCardCategoryId = p21.FlashCardCategoryId,
                Name = p21.Name,
                Detail = p21.Detail,
                Author = p21.Author,
                Price = p21.Price,
                ImageFileName = p21.Image != null ? p21.Image.FileName : null,
                IsSuggested = p21.IsSuggested,
                RateAvg = p21.RateAvg,
                IsFree = p21.IsFree,
                IsActive = p21.IsActive,
                Image = p21.Image == null ? null : new FlashCardCategoryImage()
                {
                    FlashCardCategoryId = p21.Image.FlashCardCategoryId,
                    ImageId = p21.Image.ImageId,
                    Name = p21.Image.Name,
                    FileLocation = p21.Image.FileLocation,
                    FileName = p21.Image.FileName,
                    RemovedAt = p21.Image.RemovedAt,
                    CreatedAt = p21.Image.CreatedAt,
                    CreatedBy = p21.Image.CreatedBy,
                    IsRemoved = p21.Image.IsRemoved,
                    ModifiedBy = p21.Image.ModifiedBy,
                    RemovedBy = p21.Image.RemovedBy,
                    ModifiedAt = p21.Image.ModifiedAt
                },
                FlashCardTags = funcMain5(p21.FlashCardTags)
            };
        }
        public static FlashCardCategoryLDto AdaptTo(this FlashCardCategory p23, FlashCardCategoryLDto p24)
        {
            if (p23 == null)
            {
                return null;
            }
            FlashCardCategoryLDto result = p24 ?? new FlashCardCategoryLDto();
            
            result.FlashCardCategoryId = p23.FlashCardCategoryId;
            result.Name = p23.Name;
            result.Detail = p23.Detail;
            result.Author = p23.Author;
            result.Price = p23.Price;
            result.ImageFileName = p23.Image != null ? p23.Image.FileName : null;
            result.IsSuggested = p23.IsSuggested;
            result.RateAvg = p23.RateAvg;
            result.IsFree = p23.IsFree;
            result.IsActive = p23.IsActive;
            result.Image = funcMain6(p23.Image, result.Image);
            result.FlashCardTags = funcMain7(p23.FlashCardTags, result.FlashCardTags);
            return result;
            
        }
        public static Expression<Func<FlashCardCategory, FlashCardCategoryLDto>> ProjectToLDto => p29 => new FlashCardCategoryLDto()
        {
            FlashCardCategoryId = p29.FlashCardCategoryId,
            Name = p29.Name,
            Detail = p29.Detail,
            Author = p29.Author,
            Price = p29.Price,
            ImageFileName = p29.Image != null ? p29.Image.FileName : null,
            IsSuggested = p29.IsSuggested,
            RateAvg = p29.RateAvg,
            IsFree = p29.IsFree,
            IsActive = p29.IsActive,
            Image = p29.Image,
            FlashCardTags = p29.FlashCardTags.Select<FlashCardTag, FlashCardTagSDto>(p30 => new FlashCardTagSDto()
            {
                FlashCardTagId = p30.FlashCardTagId,
                Name = p30.Name,
                FlashCardCategoryId = p30.FlashCardCategoryId
            }).ToList<FlashCardTagSDto>()
        };
        
        private static FlashCardCategoryImage funcMain1(Never p4, FlashCardCategoryImage p5, FlashCardCategorySDto p2)
        {
            FlashCardCategoryImage result = p5 ?? new FlashCardCategoryImage();
            
            result.FileName = p2.ImageFileName;
            return result;
            
        }
        
        private static ICollection<FlashCardTag> funcMain2(List<FlashCardTagSDto> p12)
        {
            if (p12 == null)
            {
                return null;
            }
            ICollection<FlashCardTag> result = new List<FlashCardTag>(p12.Count);
            
            int i = 0;
            int len = p12.Count;
            
            while (i < len)
            {
                FlashCardTagSDto item = p12[i];
                result.Add(item == null ? null : new FlashCardTag()
                {
                    FlashCardTagId = item.FlashCardTagId,
                    Name = item.Name,
                    FlashCardCategoryId = item.FlashCardCategoryId
                });
                i++;
            }
            return result;
            
        }
        
        private static FlashCardCategoryImage funcMain3(FlashCardCategoryImage p15, FlashCardCategoryImage p16)
        {
            if (p15 == null)
            {
                return null;
            }
            FlashCardCategoryImage result = p16 ?? new FlashCardCategoryImage();
            
            result.FlashCardCategoryId = p15.FlashCardCategoryId;
            result.ImageId = p15.ImageId;
            result.Name = p15.Name;
            result.FileLocation = p15.FileLocation;
            result.FileName = p15.FileName;
            result.RemovedAt = p15.RemovedAt;
            result.CreatedAt = p15.CreatedAt;
            result.CreatedBy = p15.CreatedBy;
            result.IsRemoved = p15.IsRemoved;
            result.ModifiedBy = p15.ModifiedBy;
            result.RemovedBy = p15.RemovedBy;
            result.ModifiedAt = p15.ModifiedAt;
            return result;
            
        }
        
        private static ICollection<FlashCardTag> funcMain4(List<FlashCardTagSDto> p17, ICollection<FlashCardTag> p18)
        {
            if (p17 == null)
            {
                return null;
            }
            ICollection<FlashCardTag> result = new List<FlashCardTag>(p17.Count);
            
            int i = 0;
            int len = p17.Count;
            
            while (i < len)
            {
                FlashCardTagSDto item = p17[i];
                result.Add(item == null ? null : new FlashCardTag()
                {
                    FlashCardTagId = item.FlashCardTagId,
                    Name = item.Name,
                    FlashCardCategoryId = item.FlashCardCategoryId
                });
                i++;
            }
            return result;
            
        }
        
        private static List<FlashCardTagSDto> funcMain5(ICollection<FlashCardTag> p22)
        {
            if (p22 == null)
            {
                return null;
            }
            List<FlashCardTagSDto> result = new List<FlashCardTagSDto>(p22.Count);
            
            IEnumerator<FlashCardTag> enumerator = p22.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardTag item = enumerator.Current;
                result.Add(item == null ? null : new FlashCardTagSDto()
                {
                    FlashCardTagId = item.FlashCardTagId,
                    Name = item.Name,
                    FlashCardCategoryId = item.FlashCardCategoryId
                });
            }
            return result;
            
        }
        
        private static FlashCardCategoryImage funcMain6(FlashCardCategoryImage p25, FlashCardCategoryImage p26)
        {
            if (p25 == null)
            {
                return null;
            }
            FlashCardCategoryImage result = p26 ?? new FlashCardCategoryImage();
            
            result.FlashCardCategoryId = p25.FlashCardCategoryId;
            result.ImageId = p25.ImageId;
            result.Name = p25.Name;
            result.FileLocation = p25.FileLocation;
            result.FileName = p25.FileName;
            result.RemovedAt = p25.RemovedAt;
            result.CreatedAt = p25.CreatedAt;
            result.CreatedBy = p25.CreatedBy;
            result.IsRemoved = p25.IsRemoved;
            result.ModifiedBy = p25.ModifiedBy;
            result.RemovedBy = p25.RemovedBy;
            result.ModifiedAt = p25.ModifiedAt;
            return result;
            
        }
        
        private static List<FlashCardTagSDto> funcMain7(ICollection<FlashCardTag> p27, List<FlashCardTagSDto> p28)
        {
            if (p27 == null)
            {
                return null;
            }
            List<FlashCardTagSDto> result = new List<FlashCardTagSDto>(p27.Count);
            
            IEnumerator<FlashCardTag> enumerator = p27.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardTag item = enumerator.Current;
                result.Add(item == null ? null : new FlashCardTagSDto()
                {
                    FlashCardTagId = item.FlashCardTagId,
                    Name = item.Name,
                    FlashCardCategoryId = item.FlashCardCategoryId
                });
            }
            return result;
            
        }
    }
}