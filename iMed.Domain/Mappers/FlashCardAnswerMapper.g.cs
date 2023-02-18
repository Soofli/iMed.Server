using System;
using System.Linq.Expressions;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Entities;

namespace iMed.Domain.Mappers
{
    public static partial class FlashCardAnswerMapper
    {
        public static FlashCardAnswer AdaptToFlashCardAnswer(this FlashCardAnswerSDto p1)
        {
            return p1 == null ? null : new FlashCardAnswer()
            {
                FlashCardAnswerId = p1.FlashCardAnswerId,
                Answer = p1.Answer,
                Row = p1.Row,
                IsTrue = p1.IsTrue,
                FlashCardId = p1.FlashCardId
            };
        }
        public static FlashCardAnswer AdaptTo(this FlashCardAnswerSDto p2, FlashCardAnswer p3)
        {
            if (p2 == null)
            {
                return null;
            }
            FlashCardAnswer result = p3 ?? new FlashCardAnswer();
            
            result.FlashCardAnswerId = p2.FlashCardAnswerId;
            result.Answer = p2.Answer;
            result.Row = p2.Row;
            result.IsTrue = p2.IsTrue;
            result.FlashCardId = p2.FlashCardId;
            return result;
            
        }
        public static Expression<Func<FlashCardAnswerSDto, FlashCardAnswer>> ProjectToFlashCardAnswer => p4 => new FlashCardAnswer()
        {
            FlashCardAnswerId = p4.FlashCardAnswerId,
            Answer = p4.Answer,
            Row = p4.Row,
            IsTrue = p4.IsTrue,
            FlashCardId = p4.FlashCardId
        };
        public static FlashCardAnswerSDto AdaptToSDto(this FlashCardAnswer p5)
        {
            return p5 == null ? null : new FlashCardAnswerSDto()
            {
                FlashCardAnswerId = p5.FlashCardAnswerId,
                Answer = p5.Answer,
                IsTrue = p5.IsTrue,
                FlashCardId = p5.FlashCardId,
                Row = p5.Row
            };
        }
        public static FlashCardAnswerSDto AdaptTo(this FlashCardAnswer p6, FlashCardAnswerSDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            FlashCardAnswerSDto result = p7 ?? new FlashCardAnswerSDto();
            
            result.FlashCardAnswerId = p6.FlashCardAnswerId;
            result.Answer = p6.Answer;
            result.IsTrue = p6.IsTrue;
            result.FlashCardId = p6.FlashCardId;
            result.Row = p6.Row;
            return result;
            
        }
        public static Expression<Func<FlashCardAnswer, FlashCardAnswerSDto>> ProjectToSDto => p8 => new FlashCardAnswerSDto()
        {
            FlashCardAnswerId = p8.FlashCardAnswerId,
            Answer = p8.Answer,
            IsTrue = p8.IsTrue,
            FlashCardId = p8.FlashCardId,
            Row = p8.Row
        };
    }
}