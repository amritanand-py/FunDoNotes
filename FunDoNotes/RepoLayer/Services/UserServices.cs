﻿using CommonLayer.RequestModel;
using RepoLayer.Context;
using RepoLayer.Entity;
using RepoLayer.Interfaces;
using CommonLayer.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;


namespace RepoLayer.Services
{
    public class UserServices : IUserRepo
    {
        public readonly FunDoContext FunDoContext;
        public readonly IConfiguration config;
        public UserServices(FunDoContext FunDoContext, IConfiguration config)
        {
            this.FunDoContext = FunDoContext;
            this.config = config;
        }
        public UserEntity registration(RegisterReqModel model)
        {
            UserEntity userobj = new UserEntity();
            userobj.Email = model.Email;
            userobj.Fname = model.Fname;
            userobj.Password = EncryptDecryptClass.EncryptionPass(model.Password);
            userobj.Lname = model.Lname;

            FunDoContext.UserTable.Add(userobj);
            FunDoContext.SaveChanges();

            return userobj;
        }

        public string UserLogin(LoginReqModel model)
        {
            var tempvar = FunDoContext.UserTable.FirstOrDefault(x=>x.Email == model.Email);
            if (tempvar == null) {
                return null;
            }
            else
            {
                // tempvar[0].Password == model.Password
                if (EncryptDecryptClass.MatchPass(tempvar.Password,model.Password))
                {
                    var token = genrateToken(tempvar.Email, tempvar.UserId);
                    return token;
                }

                return null;
            }


        }


        private string genrateToken(string email,int userID )
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim("Email",email),
                new Claim("UserId", userID.ToString())
            };
            var token = new JwtSecurityToken(
                config["Jwt:Issuer"],
                config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1), // Token expiration time
                signingCredentials: credentials
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;

        }

        public ForgetPassModel ForgetPassword(string Email)
        {
            UserEntity User = FunDoContext.UserTable.FirstOrDefault(x => x.Email == Email);
            ForgetPassModel forgetPassword = new ForgetPassModel();
            forgetPassword.Email = User.Email;
            forgetPassword.userID = User.UserId;
            forgetPassword.Token = genrateToken(User.Email, User.UserId);
            return forgetPassword;
        }

        public bool checker(string Email)
        {
            if (FunDoContext.UserTable.ToList().Find(x => x.Email == Email) != null)
            {
                return true;
            }
            return false;
        }


        public bool ResetPassword(string Email, ResetPasswordModel reset)
        {
            UserEntity User = FunDoContext.UserTable.FirstOrDefault(x => x.Email == Email);

            if (User != null)
            {
                User.Password = EncryptDecryptClass.EncryptionPass(reset.Password);
                FunDoContext.SaveChanges();
                return true;
            }
            return false;
        }

        // Review

        public UserEntity ReviewRegistration(RegisterReqModel model)
        {
            var existing = FunDoContext.UserTable.FirstOrDefault(x=> x.Email == model.Email);
            UserEntity userobj = new UserEntity();
            if (existing == null)
            {
               
                userobj.Email = model.Email;
                userobj.Fname = model.Fname;
                userobj.Password = EncryptDecryptClass.EncryptionPass(model.Password);
                userobj.Lname = model.Lname;

                FunDoContext.UserTable.Add(userobj);
                FunDoContext.SaveChanges();
                return userobj;

            }
            existing.Lname = model.Lname;
            existing.Fname = model.Fname;
            FunDoContext.SaveChanges();
            return userobj;
        }





    }
}
