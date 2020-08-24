using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop.MVC.Extensions
{
    public static class Extensions
    {
        public static List<string> GenerateValidations(this System.Web.Http.ModelBinding.ModelStateDictionary dictionary)
        {
            List<string> output = new List<string>();

            foreach (var dictionaryValue in dictionary.Values)
            {
                foreach (var error in dictionaryValue.Errors)
                {
                    output.Add(error.ErrorMessage);
                }
            }

            return output;
        }
    }
}