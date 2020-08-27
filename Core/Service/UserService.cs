using Core.DB;
using Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Core.Service
{
    public class UserService
    {
        private readonly ProfileViewerDBContext db;
        public UserService()
        {
            db = DBFactory.GetDB();
        }

        public ProfileViewModel GetUserProfileByEmail(string emailAddress)
        {
            try
            {
                var user = (from us in db.AspNetUsers
                            join up in db.UserProfiles on us.Id equals up.UserId
                            where us.Email.Equals(emailAddress)
                            select new ProfileViewModel()
                            {
                                Id = up.Id,
                                ParimaryEmailAddress = us.Email,
                                AlternateEmailAddress = string.IsNullOrEmpty(up.AlternateEmailAddress)? "": up.AlternateEmailAddress,
                                FirstName = up.FirstName,
                                LastName = string.IsNullOrEmpty(up.LastName) ? "" : up.LastName,
                                PrimaryPhone = up.PhoneNumber,
                                AlternatePhone = string.IsNullOrEmpty(up.AlternatePhoneNumber)? "": up.AlternatePhoneNumber
                            }).FirstOrDefault();
                if (null == user)
                    return new ProfileViewModel();

                return user;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string UpdateProfile(ProfileViewModel model)
        {
            string message = string.Empty;
            try
            {
                var userProfile = db.UserProfiles.Find(model.Id);
                var user = db.AspNetUsers.Find(userProfile.UserId);
                bool isEmailAvailable = db.AspNetUsers.Where(x => x.Email.Equals(model.ParimaryEmailAddress)).FirstOrDefault() == null ? true : false;
                if (isEmailAvailable || user.Email.Equals(model.ParimaryEmailAddress))
                {
                    user.Email = model.ParimaryEmailAddress;
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();

                    userProfile.AlternateEmailAddress = model.AlternateEmailAddress;
                    userProfile.FirstName = model.FirstName;
                    userProfile.LastName = model.LastName;
                    userProfile.PhoneNumber = model.PrimaryPhone;
                    userProfile.AlternatePhoneNumber = model.AlternatePhone;
                    db.Entry(userProfile).State = EntityState.Modified;
                    db.SaveChanges();
                    message = "Successfully Updated";
                }
                else
                {
                    message = "Primary Email is already associated with an account. Please try another one";
                }
            }
            catch (Exception e)
            {
                message = "Oops! Something Went wrong. Please Try Again";
            }

            return message;
        }
    }
}
