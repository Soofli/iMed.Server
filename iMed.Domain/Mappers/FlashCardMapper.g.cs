using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Entities;

namespace iMed.Domain.Mappers
{
    public static partial class FlashCardMapper
    {
        public static FlashCard AdaptToFlashCard(this FlashCardSDto p1)
        {
            return p1 == null ? null : new FlashCard()
            {
                FlashCardId = p1.FlashCardId,
                Question = p1.Question,
                FlashCardTagId = p1.FlashCardTagId,
                LongAnswer = p1.LongAnswer,
                FlashCardAnswers = funcMain1(p1.FlashCardAnswers)
            };
        }
        public static FlashCard AdaptTo(this FlashCardSDto p3, FlashCard p4)
        {
            if (p3 == null)
            {
                return null;
            }
            FlashCard result = p4 ?? new FlashCard();
            
            result.FlashCardId = p3.FlashCardId;
            result.Question = p3.Question;
            result.FlashCardTagId = p3.FlashCardTagId;
            result.LongAnswer = p3.LongAnswer;
            result.FlashCardAnswers = funcMain2(p3.FlashCardAnswers, result.FlashCardAnswers);
            return result;
            
        }
        public static Expression<Func<FlashCardSDto, FlashCard>> ProjectToFlashCard => p7 => new FlashCard()
        {
            FlashCardId = p7.FlashCardId,
            Question = p7.Question,
            FlashCardTagId = p7.FlashCardTagId,
            LongAnswer = p7.LongAnswer,
            FlashCardAnswers = p7.FlashCardAnswers.Select<FlashCardAnswerSDto, FlashCardAnswer>(p8 => new FlashCardAnswer()
            {
                FlashCardAnswerId = p8.FlashCardAnswerId,
                Answer = p8.Answer,
                Row = p8.Row,
                IsTrue = p8.IsTrue,
                FlashCardId = p8.FlashCardId
            }).ToList<FlashCardAnswer>()
        };
        public static FlashCardSDto AdaptToSDto(this FlashCard p9)
        {
            return p9 == null ? null : new FlashCardSDto()
            {
                FlashCardId = p9.FlashCardId,
                Question = p9.Question,
                FlashCardTagName = p9.FlashCardTag != null ? p9.FlashCardTag.Name : null,
                FlashCardCategoryId = p9.FlashCardTag != null ? p9.FlashCardTag.FlashCardCategoryId : 0,
                FlashCardTagId = p9.FlashCardTagId,
                LongAnswer = p9.LongAnswer,
                FlashCardAnswers = funcMain3(p9.FlashCardAnswers)
            };
        }
        public static FlashCardSDto AdaptTo(this FlashCard p11, FlashCardSDto p12)
        {
            if (p11 == null)
            {
                return null;
            }
            FlashCardSDto result = p12 ?? new FlashCardSDto();
            
            result.FlashCardId = p11.FlashCardId;
            result.Question = p11.Question;
            result.FlashCardTagName = p11.FlashCardTag != null ? p11.FlashCardTag.Name : null;
            result.FlashCardCategoryId = p11.FlashCardTag != null ? p11.FlashCardTag.FlashCardCategoryId : 0;
            result.FlashCardTagId = p11.FlashCardTagId;
            result.LongAnswer = p11.LongAnswer;
            result.FlashCardAnswers = funcMain4(p11.FlashCardAnswers, result.FlashCardAnswers);
            return result;
            
        }
        public static Expression<Func<FlashCard, FlashCardSDto>> ProjectToSDto => p15 => new FlashCardSDto()
        {
            FlashCardId = p15.FlashCardId,
            Question = p15.Question,
            FlashCardTagName = p15.FlashCardTag != null ? p15.FlashCardTag.Name : null,
            FlashCardCategoryId = p15.FlashCardTag != null ? p15.FlashCardTag.FlashCardCategoryId : 0,
            FlashCardTagId = p15.FlashCardTagId,
            LongAnswer = p15.LongAnswer,
            FlashCardAnswers = p15.FlashCardAnswers.Select<FlashCardAnswer, FlashCardAnswerSDto>(p16 => new FlashCardAnswerSDto()
            {
                FlashCardAnswerId = p16.FlashCardAnswerId,
                Answer = p16.Answer,
                IsTrue = p16.IsTrue,
                FlashCardId = p16.FlashCardId,
                Row = p16.Row
            }).ToList<FlashCardAnswerSDto>()
        };
        
        private static ICollection<FlashCardAnswer> funcMain1(List<FlashCardAnswerSDto> p2)
        {
            if (p2 == null)
            {
                return null;
            }
            ICollection<FlashCardAnswer> result = new List<FlashCardAnswer>(p2.Count);
            
            int i = 0;
            int len = p2.Count;
            
            while (i < len)
            {
                FlashCardAnswerSDto item = p2[i];
                result.Add(item == null ? null : new FlashCardAnswer()
                {
                    FlashCardAnswerId = item.FlashCardAnswerId,
                    Answer = item.Answer,
                    Row = item.Row,
                    IsTrue = item.IsTrue,
                    FlashCardId = item.FlashCardId
                });
                i++;
            }
            return result;
            
        }
        
        private static ICollection<FlashCardAnswer> funcMain2(List<FlashCardAnswerSDto> p5, ICollection<FlashCardAnswer> p6)
        {
            if (p5 == null)
            {
                return null;
            }
            ICollection<FlashCardAnswer> result = new List<FlashCardAnswer>(p5.Count);
            
            int i = 0;
            int len = p5.Count;
            
            while (i < len)
            {
                FlashCardAnswerSDto item = p5[i];
                result.Add(item == null ? null : new FlashCardAnswer()
                {
                    FlashCardAnswerId = item.FlashCardAnswerId,
                    Answer = item.Answer,
                    Row = item.Row,
                    IsTrue = item.IsTrue,
                    FlashCardId = item.FlashCardId
                });
                i++;
            }
            return result;
            
        }
        
        private static List<FlashCardAnswerSDto> funcMain3(ICollection<FlashCardAnswer> p10)
        {
            if (p10 == null)
            {
                return null;
            }
            List<FlashCardAnswerSDto> result = new List<FlashCardAnswerSDto>(p10.Count);
            
            IEnumerator<FlashCardAnswer> enumerator = p10.GetEnumerator();
            
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
        
        private static List<FlashCardAnswerSDto> funcMain4(ICollection<FlashCardAnswer> p13, List<FlashCardAnswerSDto> p14)
        {
            if (p13 == null)
            {
                return null;
            }
            List<FlashCardAnswerSDto> result = new List<FlashCardAnswerSDto>(p13.Count);
            
            IEnumerator<FlashCardAnswer> enumerator = p13.GetEnumerator();
            
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