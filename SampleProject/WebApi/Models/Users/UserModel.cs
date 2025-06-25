using System.Collections.Generic;
using BusinessEntities;

namespace WebApi.Models.Users
{
    public class UserModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public UserTypes Type { get; set; }
        public int Age { get; set; }
        public decimal? AnnualSalary { get; set; }
        public IEnumerable<string> Tags { get; set; } // Note: I am assuming it is valid for a user to have no tags.
    }

    public static class UserModelExtensions
    {
        public static bool Validate(this UserModel model, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(model.Name))
            {
                errorMessage = "Name is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(model.Email)) // Additional validation for email can be added here
            {
                errorMessage = "Email is required.";
                return false;
            }
            
            if (model.Age <= 0)
            {
                errorMessage = "Invalid age. Age must be greater than zero.";
                return false;
            }

            if (model.AnnualSalary is null)
            {
                errorMessage = "AnnualSalary is required.";
                return false;
            }
            
            if (model.AnnualSalary < 0)
            {
                errorMessage = "Annual salary cannot be negative.";
                return false;
            }

            return true;
        }
    }
}