using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Project.Models
{
    public class UserRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    return db.groups.Select(x => x.name).ToArray();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /**
         * Gets the roles that the user has
         * username = the username of the user
         **/
        public override string[] GetRolesForUser(string username)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    user user = db.users.FirstOrDefault(x => x.email.Equals(username));
                    return db.usergroups.Where(x => x.user_id == user.id).Select(x => x.group.name).ToArray();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        /**
         * Checks the role of the user
         **/
        public override bool IsUserInRole(string username, string roleName)
        {
            try
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    string usergroup = db.usergroups.Where(x => x.user.email.Equals(username)).Select(x => x.group.name).SingleOrDefault();
                    return (roleName.Equals(usergroup));
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}