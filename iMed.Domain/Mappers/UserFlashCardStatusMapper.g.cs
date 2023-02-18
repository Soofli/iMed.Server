using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using iMed.Domain.Dtos.LargDtos;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Entities;
using iMed.Domain.Enums;

namespace iMed.Domain.Mappers
{
    public static partial class UserFlashCardStatusMapper
    {
        public static UserFlashCardStatus AdaptToUserFlashCardStatus(this UserFlashCardStatusLDto p1)
        {
            return p1 == null ? null : new UserFlashCardStatus()
            {
                UserFlashCardStatusId = p1.UserFlashCardStatusId,
                FlashCardStatus = p1.FlashCardStatus,
                NextReviewAt = p1.NextReviewAt,
                FlashCardId = p1.FlashCardId
            };
        }
        public static UserFlashCardStatus AdaptTo(this UserFlashCardStatusLDto p2, UserFlashCardStatus p3)
        {
            if (p2 == null)
            {
                return null;
            }
            UserFlashCardStatus result = p3 ?? new UserFlashCardStatus();
            
            result.UserFlashCardStatusId = p2.UserFlashCardStatusId;
            result.FlashCardStatus = p2.FlashCardStatus;
            result.NextReviewAt = p2.NextReviewAt;
            result.FlashCardId = p2.FlashCardId;
            return result;
            
        }
        public static Expression<Func<UserFlashCardStatusLDto, UserFlashCardStatus>> ProjectToUserFlashCardStatus => p4 => new UserFlashCardStatus()
        {
            UserFlashCardStatusId = p4.UserFlashCardStatusId,
            FlashCardStatus = p4.FlashCardStatus,
            NextReviewAt = p4.NextReviewAt,
            FlashCardId = p4.FlashCardId
        };
        public static UserFlashCardStatusLDto AdaptToLDto(this UserFlashCardStatus p5)
        {
            return p5 == null ? null : new UserFlashCardStatusLDto()
            {
                UserFlashCardStatusId = p5.UserFlashCardStatusId,
                FlashCardId = p5.FlashCardId,
                FlashCardCategoryId = funcMain1(p5.FlashCard == null ? null : (p5.FlashCard.FlashCardTag == null ? null : (int?)p5.FlashCard.FlashCardTag.FlashCardCategoryId)),
                FlashCardStatus = p5.FlashCardStatus,
                FlashCardType = p5.FlashCard != null ? p5.FlashCard.FlashCardType : FlashCardType.SingleAnswer,
                NextReviewAt = p5.NextReviewAt,
                Question = p5.FlashCard != null ? p5.FlashCard.Question : null,
                LongAnswer = p5.FlashCard != null ? p5.FlashCard.LongAnswer : null,
                FlashCardAnswers = funcMain2(p5.FlashCard != null ? p5.FlashCard.FlashCardAnswers : null),
                FlashCardTagName = p5.FlashCard.FlashCardTag != null ? p5.FlashCard.FlashCardTag.Name : null,
                FlashCardCategoryName = p5.FlashCard.FlashCardTag.FlashCardCategory != null ? p5.FlashCard.FlashCardTag.FlashCardCategory.Name : null
            };
        }
        public static UserFlashCardStatusLDto AdaptTo(this UserFlashCardStatus p8, UserFlashCardStatusLDto p9)
        {
            if (p8 == null)
            {
                return null;
            }
            UserFlashCardStatusLDto result = p9 ?? new UserFlashCardStatusLDto();
            
            result.UserFlashCardStatusId = p8.UserFlashCardStatusId;
            result.FlashCardId = p8.FlashCardId;
            result.FlashCardCategoryId = funcMain3(p8.FlashCard == null ? null : (p8.FlashCard.FlashCardTag == null ? null : (int?)p8.FlashCard.FlashCardTag.FlashCardCategoryId), result.FlashCardCategoryId);
            result.FlashCardStatus = p8.FlashCardStatus;
            result.FlashCardType = p8.FlashCard != null ? p8.FlashCard.FlashCardType : FlashCardType.SingleAnswer;
            result.NextReviewAt = p8.NextReviewAt;
            result.Question = p8.FlashCard != null ? p8.FlashCard.Question : null;
            result.LongAnswer = p8.FlashCard != null ? p8.FlashCard.LongAnswer : null;
            result.FlashCardAnswers = funcMain4(p8.FlashCard != null ? p8.FlashCard.FlashCardAnswers : null, result.FlashCardAnswers);
            result.FlashCardTagName = p8.FlashCard.FlashCardTag != null ? p8.FlashCard.FlashCardTag.Name : null;
            result.FlashCardCategoryName = p8.FlashCard.FlashCardTag.FlashCardCategory != null ? p8.FlashCard.FlashCardTag.FlashCardCategory.Name : null;
            return result;
            
        }
        public static Expression<Func<UserFlashCardStatus, UserFlashCardStatusLDto>> ProjectToLDto => p14 => new UserFlashCardStatusLDto()
        {
            UserFlashCardStatusId = p14.UserFlashCardStatusId,
            FlashCardId = p14.FlashCardId,
            FlashCardCategoryId = p14.FlashCard.FlashCardTag.FlashCardCategoryId,
            FlashCardStatus = p14.FlashCardStatus,
            FlashCardType = p14.FlashCard != null ? p14.FlashCard.FlashCardType : FlashCardType.SingleAnswer,
            NextReviewAt = p14.NextReviewAt,
            Question = p14.FlashCard != null ? p14.FlashCard.Question : null,
            LongAnswer = p14.FlashCard != null ? p14.FlashCard.LongAnswer : null,
            FlashCardAnswers = (p14.FlashCard != null ? p14.FlashCard.FlashCardAnswers : null).Select<FlashCardAnswer, FlashCardAnswerSDto>(p15 => new FlashCardAnswerSDto()
            {
                FlashCardAnswerId = p15.FlashCardAnswerId,
                Answer = p15.Answer,
                IsTrue = p15.IsTrue,
                FlashCardId = p15.FlashCardId,
                Row = p15.Row
            }).ToList<FlashCardAnswerSDto>(),
            FlashCardTagName = p14.FlashCard.FlashCardTag != null ? p14.FlashCard.FlashCardTag.Name : null,
            FlashCardCategoryName = p14.FlashCard.FlashCardTag.FlashCardCategory != null ? p14.FlashCard.FlashCardTag.FlashCardCategory.Name : null
        };
        
        private static int funcMain1(int? p6)
        {
            return p6 == null ? 0 : (int)p6;
        }
        
        private static List<FlashCardAnswerSDto> funcMain2(ICollection<FlashCardAnswer> p7)
        {
            if (p7 == null)
            {
                return null;
            }
            List<FlashCardAnswerSDto> result = new List<FlashCardAnswerSDto>(p7.Count);
            
            IEnumerator<FlashCardAnswer> enumerator = p7.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardAnswer item = enumerator.Current;
                result.Add(item == null ? null : new FlashCardAnswerSDto()
                {
                    FlashCardAnswerId = item.FlashCardAnswerId,
                    Answer = item.Answer,
                    IsTrue = item.IsTrue,
                    FlashCardId = item.FlashCardId,
                    Row = item.Row
                });
            }
            return result;
            
        }
        
        private static int funcMain3(int? p10, int p11)
        {
            return p10 == null ? 0 : (int)p10;
        }
        
        private static List<FlashCardAnswerSDto> funcMain4(ICollection<FlashCardAnswer> p12, List<FlashCardAnswerSDto> p13)
        {
            if (p12 == null)
            {
                return null;
            }
            List<FlashCardAnswerSDto> result = new List<FlashCardAnswerSDto>(p12.Count);
            
            IEnumerator<FlashCardAnswer> enumerator = p12.GetEnumerator();
            
            while (enumerator.MoveNext())
            {
                FlashCardAnswer item = enumerator.Current;
                result.Add(item == null ? null : new FlashCardAnswerSDto()
                {
                    FlashCardAnswerId = item.FlashCardAnswerId,
                    Answer = item.Answer,
                    IsTrue = item.IsTrue,
                    FlashCardId = item.FlashCardId,
                    Row = item.Row
                });
            }
            return result;
            
        }
    }
}