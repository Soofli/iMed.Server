using System;
using System.Linq.Expressions;
using iMed.Domain.Dtos.SmalDtos;
using iMed.Domain.Entities;
using Mapster.Models;

namespace iMed.Domain.Mappers
{
    public static partial class UserMapper
    {
        public static User AdaptToUser(this UserSDto p1)
        {
            return p1 == null ? null : new User()
            {
                WalletBalance = p1.WalletBalance,
                IdentityCode = p1.IdentityCode,
                StudentCode = p1.StudentCode,
                IsConfirmed = p1.IsConfirmed,
                Score = p1.Score,
                UserIdentityImage = new UserIdentityImage() {FileName = p1.UserIdentityImageFileName},
                FirstName = p1.FirstName,
                LastName = p1.LastName,
                BirthDate = p1.BirthDate,
                Gender = p1.Gender,
                Id = p1.Id,
                Email = p1.Email,
                PhoneNumber = p1.PhoneNumber
            };
        }
        public static User AdaptTo(this UserSDto p2, User p3)
        {
            if (p2 == null)
            {
                return null;
            }
            User result = p3 ?? new User();
            
            result.WalletBalance = p2.WalletBalance;
            result.IdentityCode = p2.IdentityCode;
            result.StudentCode = p2.StudentCode;
            result.IsConfirmed = p2.IsConfirmed;
            result.Score = p2.Score;
            result.UserIdentityImage = funcMain1(new Never(), result.UserIdentityImage, p2);
            result.FirstName = p2.FirstName;
            result.LastName = p2.LastName;
            result.BirthDate = p2.BirthDate;
            result.Gender = p2.Gender;
            result.Id = p2.Id;
            result.Email = p2.Email;
            result.PhoneNumber = p2.PhoneNumber;
            return result;
            
        }
        public static Expression<Func<UserSDto, User>> ProjectToUser => p6 => new User()
        {
            WalletBalance = p6.WalletBalance,
            IdentityCode = p6.IdentityCode,
            StudentCode = p6.StudentCode,
            IsConfirmed = p6.IsConfirmed,
            Score = p6.Score,
            UserIdentityImage = new UserIdentityImage() {FileName = p6.UserIdentityImageFileName},
            FirstName = p6.FirstName,
            LastName = p6.LastName,
            BirthDate = p6.BirthDate,
            Gender = p6.Gender,
            Id = p6.Id,
            Email = p6.Email,
            PhoneNumber = p6.PhoneNumber
        };
        public static UserSDto AdaptToSDto(this User p7)
        {
            return p7 == null ? null : new UserSDto()
            {
                Id = p7.Id,
                WalletBalance = p7.WalletBalance,
                IdentityCode = p7.IdentityCode,
                FirstName = p7.FirstName,
                LastName = p7.LastName,
                Score = p7.Score,
                BirthDate = p7.BirthDate,
                IsConfirmed = p7.IsConfirmed,
                Gender = p7.Gender,
                StudentCode = p7.StudentCode,
                PhoneNumber = p7.PhoneNumber,
                Email = p7.Email,
                UserIdentityImageFileName = p7.UserIdentityImage != null ? p7.UserIdentityImage.FileName : null
            };
        }
        public static UserSDto AdaptTo(this User p8, UserSDto p9)
        {
            if (p8 == null)
            {
                return null;
            }
            UserSDto result = p9 ?? new UserSDto();
            
            result.Id = p8.Id;
            result.WalletBalance = p8.WalletBalance;
            result.IdentityCode = p8.IdentityCode;
            result.FirstName = p8.FirstName;
            result.LastName = p8.LastName;
            result.Score = p8.Score;
            result.BirthDate = p8.BirthDate;
            result.IsConfirmed = p8.IsConfirmed;
            result.Gender = p8.Gender;
            result.StudentCode = p8.StudentCode;
            result.PhoneNumber = p8.PhoneNumber;
            result.Email = p8.Email;
            result.UserIdentityImageFileName = p8.UserIdentityImage != null ? p8.UserIdentityImage.FileName : null;
            return result;
            
        }
        public static Expression<Func<User, UserSDto>> ProjectToSDto => p10 => new UserSDto()
        {
            Id = p10.Id,
            WalletBalance = p10.WalletBalance,
            IdentityCode = p10.IdentityCode,
            FirstName = p10.FirstName,
            LastName = p10.LastName,
            Score = p10.Score,
            BirthDate = p10.BirthDate,
            IsConfirmed = p10.IsConfirmed,
            Gender = p10.Gender,
            StudentCode = p10.StudentCode,
            PhoneNumber = p10.PhoneNumber,
            Email = p10.Email,
            UserIdentityImageFileName = p10.UserIdentityImage != null ? p10.UserIdentityImage.FileName : null
        };
        
        private static UserIdentityImage funcMain1(Never p4, UserIdentityImage p5, UserSDto p2)
        {
            UserIdentityImage result = p5 ?? new UserIdentityImage();
            
            result.FileName = p2.UserIdentityImageFileName;
            return result;
            
        }
    }
}