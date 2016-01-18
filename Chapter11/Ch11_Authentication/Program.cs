using System;
using System.Security.Permissions;
using System.Security.Principal;
using static System.Console;

namespace Ch11_Authentication
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new WindowsPrincipal(WindowsIdentity.GetCurrent());
            WriteLine($"Name: {user.Identity.Name}");
            WriteLine($"IsAuthenticated: {user.Identity.IsAuthenticated}");
            WriteLine($"AuthenticationType: {user.Identity.AuthenticationType}");

            // to check if the current user belongs to a specific role
            WriteLine($"Is in Administrators group? {user.IsInRole("Administrators")}");
            WriteLine($"Is in Users group? {user.IsInRole("Users")}");
            WriteLine($"Is in Sales group? {user.IsInRole("Sales")}");
            WriteLine();
            WriteLine($"{user.Identity.Name} belongs to these roles/groups:");
            foreach (var claim in user.Claims)
            {
                if (claim.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/groupsid")
                {
                    WriteLine($"{claim.Value}: {(new SecurityIdentifier(claim.Value)).Translate(typeof(NTAccount)).Value}");
                }
            }

            if (user.IsInRole("Administrators")) // or Users
            {
                WriteLine("You are in the role so you are allowed access to this feature.");
            }
            else
            {
                WriteLine("You are NOT in the role so you are banned from this feature.");
            }

            // copy the current user principal to the current thread
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            try
            {
                SecureFeature();
            }
            catch (Exception ex)
            {
                WriteLine($"{ex.GetType()}: {ex.Message}");
            }

            ReadLine(); // keep the application running
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Administrators")] // or Users
        public static void SecureFeature()
        {
            WriteLine("This is a secure feature!");
        }
    }
}
