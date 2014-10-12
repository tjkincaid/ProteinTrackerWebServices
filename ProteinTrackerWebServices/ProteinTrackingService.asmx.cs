using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace ProteinTrackerWebServices
{

    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]

    public class ProteinTrackingService : WebService
    {
        private UserRepository repository = new UserRepository();


        [WebMethod (Description= "Adds the amount to the total", EnableSession = true)]
        public int  AddProtein(int amount, int userId)
        {
            //if (Session["user"+userId]==null)
            //{
            //    return -1;
            //}
            //else
            //{
            //    var user = (User)Session["user" + userId];
            //    user.Total += amount;
            //    Session["user" + userId] = user;
            //    return user.Total;
            //}

            var user = repository.GetById(userId);
            if (user == null)
            {
                return -1;

            }
            user.Total += amount;
            repository.Save(user);
            return user.Total;
        }

        [WebMethod(Description = "lets you add a user", EnableSession = true)]
        public int AddUser(string name, int goal)
        {
            //var userId = 0;
            //var protein = goal;
            //var user = name;

            //if (Session["userId"]!=null)
            //{
            //    userId = (int)Session["userId"];
            //}

            //Session["user" + userId] = new User { Goal = goal, Name = name, Total = 0, UserId = userId };
            //Session["userId"] = userId + 1;



            //return userId;

            var user = new User { Goal = goal, Name = name, Total = 0};
            repository.Add(user);
            return user.UserId;



        }
        [WebMethod(Description = "lets you list users", EnableSession = true)]
        public List<User> ListUsers()
        {
            //var users = new List<User>();
            //var userId = 0;
            //if (Session["userId"]!= null)
            //{
            //    userId = (int)Session["userId"];

            //}
            //for (var i = 0; i < userId; i++)
            //{
            //    users.Add((User)Session["user" + i]);
            //}
            //return users;

            return new List<User>(repository.GetAll());
        }

    }
}
