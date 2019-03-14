using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Project.Models
{
    public partial class user
    {
        /**
         * Logs the user in
         **/
        public static bool login(string email, string password)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    return db.users.SingleOrDefault(x => x.email.ToUpper() == email.ToUpper() && x.password == PasswordEncrypter.encrypt(email, password)) == null ? true : false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /**
         * Returns the currently logged in user
         **/
        public static user getUser()
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    if (HttpContext.Current.User.Identity.IsAuthenticated) {
                        return db.users.SingleOrDefault(x => x.email == HttpContext.Current.User.Identity.Name);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        /**
         * Update the profile of the user
         **/
        public static void updateProfile(user usr)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    if (HttpContext.Current.User.Identity.IsAuthenticated)
                    {
                        user us = db.users.SingleOrDefault(x => x.id == usr.id);
                        us.first_name = usr.first_name;
                        us.last_name = usr.last_name;
                        db.SubmitChanges();
                    }
                }
            }
            catch (Exception e)
            {
               
            }
        }
    }

    public class userlogin
    {
        [EmailAddress(ErrorMessage = "Het e-mail adres dat u hebt ingevoerd is ongeldig")]
        [Required(ErrorMessage = "please enter a email address")]
        public string email { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "please enter a password")]
        public string password { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class PasswordEncrypter
    {
        /**
         * Salts the password with the email of the user
         * add extra chars if the email is too short
         **/
        private static string getSalt(string email)
        {
            byte[] salt = Encoding.UTF8.GetBytes(email + "#45@27bf#43");
            return Convert.ToBase64String(salt);
        }

        /**
         * Add the salt to the password
         **/
        public static string encrypt(string email, string password)
        {
            SHA512 sha512 = new SHA512Managed();
            byte[] hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(password + getSalt(email)));
            return Convert.ToBase64String(hash);
        }


    }

}