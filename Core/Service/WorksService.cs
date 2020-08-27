using Core.DB;
using Core.ViewModel;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public class WorksService
    {
        private readonly ProfileViewerDBContext db;
        public WorksService()
        {
            db = DBFactory.GetDB();
        }

        public List<TaskViewModel> GetTaskForUser(string emailAddress)
        {
            try
            {
                var user = db.AspNetUsers.Where(x => x.Email.Equals(emailAddress)).FirstOrDefault();
                var userProfile = db.UserProfiles.Where(x => x.UserId.Equals(user.Id)).FirstOrDefault();
                var tasklist = (from uw in db.UserWorks
                                join w in db.Works on uw.WorkId equals w.Id
                                join up in db.UserProfiles on uw.UserProfileId equals up.Id
                                where uw.UserProfileId == userProfile.Id
                                select new TaskViewModel()
                                {
                                    Id=uw.Id,
                                    TaskName = w.WorkType,
                                    TaskDescription = w.TaskDescription,
                                    StartingDate = uw.StartingDate,
                                    NoOfDays = uw.NoOfDays,
                                    NameOfAssignee = up.FirstName + " " + up.LastName,
                                    Status = uw.StatusText
                                }).ToList();
                return tasklist;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
