using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;


namespace DemoToken.Models
{
    public class MyAuthorication: OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        //public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext db)
        //{
        //    db.Validated();
        //}
        //public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext db)
        //{
        //    using (UserMasterRepository test = new UserMasterRepository())
        //    {
        //        var user = test.ValidateUser(db.UserName, db.Password);
        //        if (user == null)
        //        {
        //            db.SetError("Khong truy cap duoc", "Nhap sai thong tin user va passs");
        //            return;
        //        }
        //        var dinhdanh = new ClaimsIdentity(db.Options.AuthenticationType);
        //        dinhdanh.AddClaim(new Claim(ClaimTypes.Role, user.UserRoles));
        //        dinhdanh.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
        //        dinhdanh.AddClaim(new Claim("Email", user.UserEmailID));
        //        db.Validated(dinhdanh);
        //    }
        //}

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            
            using (UserMasterRepository _repo = new UserMasterRepository())
            {
                var user = _repo.ValidateUser(context.UserName, context.Password);
                if (user == null)
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    return;
                }
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                identity.AddClaim(new Claim(ClaimTypes.Role, user.UserRoles));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
                identity.AddClaim(new Claim("Email", user.UserEmailID));

                context.Validated(identity);
            }
        }

    }
}