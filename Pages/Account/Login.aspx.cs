﻿using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

public partial class Pages_Account_Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSignIn_OnClick(object sender, EventArgs e)
    {
        UserStore<IdentityUser> userStore = new UserStore<IdentityUser>();

        userStore.Context.Database.Connection.ConnectionString =
            System.Configuration.ConfigurationManager.
            ConnectionStrings["GarageConnectionString"].ConnectionString;
        //GarageEntities6
        UserManager<IdentityUser> manager = new UserManager<IdentityUser>(userStore);

        var user = manager.Find(txtUserName.Text, txtPassword.Text);

        if (user != null)
        {
            //Call OWIN functionality
            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

            //Sign in user
            authenticationManager.SignIn(new AuthenticationProperties
            {
                IsPersistent = false
            }, userIdentity);

            //Redirect user to homepage
            Response.Redirect("~/Index.aspx");
        }
        else
        {
            //litStatus.Text = "Invalid username or password";
        }
    }
}