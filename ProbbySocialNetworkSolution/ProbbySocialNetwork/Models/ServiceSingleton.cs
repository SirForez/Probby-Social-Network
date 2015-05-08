using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProbbySocialNetwork.Models
{
    public class ServiceSingleton
    {
        private static ApplicationDbContext db = null;
        private static ServiceSingleton instance = null;

        private static StatusService statusService = null;
        private static HobbyService hobbyService = null;
        private static GroupService groupService = null;
        private static AccountService accountService = null;

        private ServiceSingleton()
        {

        }

        public static ServiceSingleton GetInstance
        {
            get
            {
                if (instance == null)
                {
                    db = new ApplicationDbContext();
                    instance = new ServiceSingleton();
                }

                return instance;
            }
        }

        public static StatusService GetStatusService
        {
            get
            {
                if (statusService == null)
                {
                    statusService = new StatusService(db);
                }

                return statusService;
            }
        }

        public static HobbyService GetHobbyService
        {
            get
            {
                if (hobbyService == null)
                {
                    hobbyService = new HobbyService(db);
                }

                return hobbyService;
            }
        }

        public static GroupService GetGroupService
        {
            get
            {
                if (groupService == null)
                {
                    groupService = new GroupService(db);
                }

                return groupService;
            }
        }

        public static AccountService GetAccountService
        {
            get
            {
                if (accountService == null)
                {
                    accountService = new AccountService(db);
                }

                return accountService;
            }
        }
    }
}