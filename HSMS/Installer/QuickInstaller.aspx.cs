using System;
using System.Collections;
using System.Reflection;
using System.Web.UI;
using HSMS.Bo;
using HSMS.Bo.Config;
using HSMS.Bo.User;
using HSMS.Db;
using NHibernate;

namespace HSMS.Installer
{
    public partial class QuickInstaller : Page
    {
        private static HSMSGroup groupAdmin;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                MsgPreInstall.Visible = false;
                BtnInstall.Visible = false;
                MsgInstall.Visible = true;
                MsgSchoolName.Visible = false;
                InputSchoolName.Visible = false;
            }
        }

        private static void DeleteTable(Type type)
        {
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                IList result = session.CreateQuery("FROM " + type).List();
                if (result != null)
                {
                    foreach (object o in result)
                    {
                        session.Delete(o);
                    }
                }
            }
            catch (HibernateException)
            {
                NHibernateHelper.MarkError();
            }
            finally
            {
                NHibernateHelper.CloseSession();
            }
        }

        protected void BtnInstall_Click(object sender, EventArgs e)
        {
            MsgInstall.Text = "";

            //delete existing data (if any)
            DeleteTable(typeof (HSMSConfig));
            DeleteTable(typeof (HSMSPermission));
            DeleteTable(typeof (HSMSGroup));
            DeleteTable(typeof (HSMSGroupRule));
            DeleteTable(typeof (HSMSUser));

            ISession session = NHibernateHelper.GetCurrentSession();
            HSMSConfig config = new HSMSConfig(ConfigManager.CONFIG_NAME_SCHOOL_NAME, InputSchoolName.Text.Trim());
            session.Save(config);
            config = new HSMSConfig(ConfigManager.CONFIG_NAME_SCHOOL_YEAR, Utils.CalcSchoolYear().ToString());
            session.Save(config);

            try
            {
                PopulatePermissions(MsgInstall);
                PopulateGroups(MsgInstall);
                PopulateUsers(MsgInstall);
            }
            catch (HibernateException)
            {
                NHibernateHelper.MarkError();
                throw;
            }
        }

        private static void PopulateUsers(ITextControl message)
        {
            message.Text += "<b>Populating user accounts:</b><br/>";

            HSMSUser user = new HSMSUser();
            user.LoginName = "admin";
            user.Password = Utils.Md5("password");
            user.Email = "admin@localhost";
            user.CreationTimestamp = Utils.GetCurrentUnixTimestamp();
            user.FullName = "Administrator";
            user.SetRole(groupAdmin);
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                message.Text += "- " + user.LoginName + "...";
                session.Save(user);
                message.Text += "done<br/>";
            }
            catch (HibernateException e)
            {
                message.Text += "failed [" + e.Message + "]<br>";
                throw;
            }
        }

        private static void PopulateGroups(ITextControl message)
        {
            message.Text += "<b>Populating groups:</b><br/>";

            HSMSGroup group;
            HSMSGroupRule gr;
            ISession session = NHibernateHelper.GetCurrentSession();
            try
            {
                group = new HSMSGroup();
                group.IsGod = false;
                group.Name = "Administrator";
                group.Description = "System Administrator";
                group.Prefix = "<font color='red'>";
                group.Suffix = "</font>";
                message.Text += "- " + group.Name + "...";
                session.Save(group);
                gr = new HSMSGroupRule();
                gr.IsGlobal = true;
                //gr.Group = group;
                //gr.Permission = PermissionConstants.PERMISSION_ADMIN;
                gr.GroupId = group.Id;
                gr.PermissionName = PermissionConstants.PERMISSION_ADMIN.Name;
                session.Save(gr);
                message.Text += "done<br/>";
                groupAdmin = group;

                group = new HSMSGroup();
                group.IsGod = false;
                group.Name = "Teacher";
                group.Description = "Teacher";
                group.Prefix = "<font color='blue'>";
                group.Suffix = "</font>";
                message.Text += "- " + group.Name + "...";
                session.Save(group);
                gr = new HSMSGroupRule();
                gr.IsGlobal = true;
                //gr.Group = group;
                //gr.Permission = PermissionConstants.PERMISSION_TEACHER;
                gr.GroupId = group.Id;
                gr.PermissionName = PermissionConstants.PERMISSION_TEACHER.Name;
                session.Save(gr);
                message.Text += "done<br/>";

                group = new HSMSGroup();
                group.IsGod = false;
                group.Name = "Parent";
                group.Description = "Parent";
                group.Prefix = "<font color='green'>";
                group.Suffix = "</font>";
                message.Text += "- " + group.Name + "...";
                session.Save(group);
                gr = new HSMSGroupRule();
                gr.IsGlobal = true;
                //gr.Group = group;
                //gr.Permission = PermissionConstants.PERMISSION_PARENT;
                gr.GroupId = group.Id;
                gr.PermissionName = PermissionConstants.PERMISSION_PARENT.Name;
                session.Save(gr);
                message.Text += "done<br/>";

                group = new HSMSGroup();
                group.IsGod = false;
                group.Name = "Pupil";
                group.Description = "Pupil";
                group.Prefix = "";
                group.Suffix = "";
                message.Text += "- " + group.Name + "...";
                session.Save(group);
                gr = new HSMSGroupRule();
                gr.IsGlobal = true;
                //gr.Group = group;
                //gr.Permission = PermissionConstants.PERMISSION_PUPIL;
                gr.GroupId = group.Id;
                gr.PermissionName = PermissionConstants.PERMISSION_PUPIL.Name;
                session.Save(gr);
                message.Text += "done<br/>";
            }
            catch (HibernateException e)
            {
                message.Text += "failed [" + e.Message + "]<br>";
                throw;
            }
        }

        private static void PopulatePermissions(ITextControl message)
        {
            message.Text += "<b>Populating permissions:</b><br/>";

            Type permType = typeof (HSMSPermission);
            FieldInfo[] fields = typeof (PermissionConstants).GetFields();
            ISession session = NHibernateHelper.GetCurrentSession();
            foreach (FieldInfo field in fields)
            {
                if (field.IsStatic && field.FieldType.Equals(permType))
                {
                    HSMSPermission perm = (HSMSPermission) field.GetValue(null);
                    if (perm != null)
                    {
                        message.Text += "- " + perm.Name + "...";
                        try
                        {
                            session.Save(perm);
                            message.Text += "done<br/>";
                        }
                        catch (HibernateException e)
                        {
                            message.Text += "failed [" + e.Message + "]<br>";
                            throw;
                        }
                    }
                }
            }
        }
    }
}