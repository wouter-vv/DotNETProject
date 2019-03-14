using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Project.Models;
using System.Web.Security;


namespace Project.Pages
{
    public partial class Register : System.Web.UI.Page
    {
        /**
         * Page load 
         **/
        protected void Page_Load(object sender, EventArgs e)
        {
            //Validators tijdens runtime aanspreken
            foreach (BaseValidator bv in Page.Validators)
            {
                bv.EnableClientScript = false;
            }
        }

        /**
         * Method the check if the email is not used yet 
         **/
        protected void EmailValidate(object source, ServerValidateEventArgs args)
        {
            using (PopItUpDataContext db = new PopItUpDataContext())
            {
                try
                {
                    user usr = db.users.SingleOrDefault(x => x.email == args.Value);

                    if (usr == null)
                    {
                        args.IsValid = true;
                    }
                    else { args.IsValid = false; }
                    
                }
                catch (Exception ex) { }
            }
        }
        /**
         * Registers the user and logs in
         * checks if the emailadress or username is not taken yet
         **/
        protected void login_button_Click(object sender, EventArgs e)
        {
            if (Page.IsValid && txt_password.Text.Equals(txt_confirm_password.Text))
            {
                using (PopItUpDataContext db = new PopItUpDataContext())
                {
                    try
                    {
                        user usr = db.users.SingleOrDefault(x => x.email == txt_email.Text || x.username == txt_username.Text);

                        if (usr == null)
                        {
                            usr = new user();
                            usr.username = txt_username.Text; 
                            usr.password = PasswordEncrypter.encrypt(txt_email.Text, txt_password.Text);
                            usr.email = txt_email.Text;
                            usr.first_name = txt_first_name.Text;
                            usr.last_name = txt_last_name.Text;

                            db.users.InsertOnSubmit(usr);
                            db.SubmitChanges();

                            usr = db.users.SingleOrDefault(x => x.email == usr.email && x.password == usr.password);
                            
                            usergroup ug = new usergroup();
                            ug.group_id = 2;
                            ug.user_id = usr.id;

                            db.usergroups.InsertOnSubmit(ug);
                            db.SubmitChanges();

                            FormsAuthentication.SetAuthCookie(usr.email, true);
                            Response.Redirect("~/Home/Index");
                        }
                    }
                    catch (Exception ex) { Console.WriteLine(ex.Message); }
                }
            }
        }
    }
}