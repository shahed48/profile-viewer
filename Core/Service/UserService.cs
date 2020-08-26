using Core.DB;
using Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
