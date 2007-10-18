using System;
using System.Collections.Generic;
using System.Text;

namespace HSMS.Bo
{
    /// <summary>
    /// This interface represents a user account.
    /// </summary>
    interface IHSMSUser
    {
        /// <summary>
        /// Assigns a role (group) to this user account.
        /// </summary>
        /// <param name="group"></param>
        void AddRole(HSMSGroup group);

        /// <summary>
        /// Checks if this user account has a specific role.
        /// </summary>
        /// <param name="group"></param>
        /// <returns></returns>
        bool HasRole(HSMSGroup group);

        /// <summary>
        /// De-assigns a role (group) from this user account.
        /// </summary>
        /// <param name="group"></param>
        void RemoveRole(HSMSGroup group);
    }
}
