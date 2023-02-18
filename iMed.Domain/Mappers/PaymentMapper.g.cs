using System;
using System.Linq.Expressions;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Entities;

namespace iMed.Domain.Mappers
{
    public static partial class PaymentMapper
    {
        public static Payment AdaptToPayment(this PaymentSDto p1)
        {
            return p1 == null ? null : new Payment()
            {
                PaymentId = p1.PaymentId,
                Amount = p1.Amount,
                TransactionCode = p1.TransactionCode,
                Mobile = p1.Mobile,
                Description = p1.Description,
                CardNumber = p1.CardNumber,
                PaymentTime = p1.PaymentTime,
                UserId = p1.UserId,
                CreatedAt = p1.CreatedAt
            };
        }
        public static Payment AdaptTo(this PaymentSDto p2, Payment p3)
        {
            if (p2 == null)
            {
                return null;
            }
            Payment result = p3 ?? new Payment();
            
            result.PaymentId = p2.PaymentId;
            result.Amount = p2.Amount;
            result.TransactionCode = p2.TransactionCode;
            result.Mobile = p2.Mobile;
            result.Description = p2.Description;
            result.CardNumber = p2.CardNumber;
            result.PaymentTime = p2.PaymentTime;
            result.UserId = p2.UserId;
            result.CreatedAt = p2.CreatedAt;
            return result;
            
        }
        public static Expression<Func<PaymentSDto, Payment>> ProjectToPayment => p4 => new Payment()
        {
            PaymentId = p4.PaymentId,
            Amount = p4.Amount,
            TransactionCode = p4.TransactionCode,
            Mobile = p4.Mobile,
            Description = p4.Description,
            CardNumber = p4.CardNumber,
            PaymentTime = p4.PaymentTime,
            UserId = p4.UserId,
            CreatedAt = p4.CreatedAt
        };
        public static PaymentSDto AdaptToSDto(this Payment p5)
        {
            return p5 == null ? null : new PaymentSDto()
            {
                PaymentId = p5.PaymentId,
                Amount = p5.Amount,
                TransactionCode = p5.TransactionCode,
                Mobile = p5.Mobile,
                Description = p5.Description,
                CardNumber = p5.CardNumber,
                UserFirstName = p5.User == null ? null : p5.User.FirstName,
                UserLastName = p5.User == null ? null : p5.User.LastName,
                PaymentTime = p5.PaymentTime,
                UserId = p5.UserId,
                CreatedAt = p5.CreatedAt
            };
        }
        public static PaymentSDto AdaptTo(this Payment p6, PaymentSDto p7)
        {
            if (p6 == null)
            {
                return null;
            }
            PaymentSDto result = p7 ?? new PaymentSDto();
            
            result.PaymentId = p6.PaymentId;
            result.Amount = p6.Amount;
            result.TransactionCode = p6.TransactionCode;
            result.Mobile = p6.Mobile;
            result.Description = p6.Description;
            result.CardNumber = p6.CardNumber;
            result.UserFirstName = p6.User == null ? null : p6.User.FirstName;
            result.UserLastName = p6.User == null ? null : p6.User.LastName;
            result.PaymentTime = p6.PaymentTime;
            result.UserId = p6.UserId;
            result.CreatedAt = p6.CreatedAt;
            return result;
            
        }
        public static Expression<Func<Payment, PaymentSDto>> ProjectToSDto => p8 => new PaymentSDto()
        {
            PaymentId = p8.PaymentId,
            Amount = p8.Amount,
            TransactionCode = p8.TransactionCode,
            Mobile = p8.Mobile,
            Description = p8.Description,
            CardNumber = p8.CardNumber,
            UserFirstName = p8.User.FirstName,
            UserLastName = p8.User.LastName,
            PaymentTime = p8.PaymentTime,
            UserId = p8.UserId,
            CreatedAt = p8.CreatedAt
        };
    }
}