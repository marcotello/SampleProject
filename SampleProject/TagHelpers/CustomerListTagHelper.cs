using Microsoft.AspNetCore.Razor.TagHelpers;
using SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.TagHelpers
{
    [HtmlTargetElement("customer-list")]
    public class CustomerListTagHelper : TagHelper
    {
        List<CustomerViewModel> _customers;

        public CustomerListTagHelper()
        {
            _customers = new List<CustomerViewModel>()
            {
                new CustomerViewModel { ContactName="Joe Montana", CompanyName="Teilus", CustomerId="001", Country="USA", City="San Francisco"},
                new CustomerViewModel { ContactName="Michael Schultz", CompanyName="Audi", CustomerId="023", Country="Germany", City="Hamburg"},
                new CustomerViewModel { ContactName="Christina Silver", CompanyName="Macys", CustomerId="43234", Country="USA", City="San Diego"}
            };
        }

        private const string ListCountAttributeName = "count";

        [HtmlAttributeName(ListCountAttributeName)]
        public int ListCount { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            StringBuilder stringBuilder = new StringBuilder();

            var query = _customers.Take(ListCount);

            foreach(var customer in query)
            {
                stringBuilder.AppendFormat("<h2><a href='/home/index/{0}'>{1}</a></h2>", customer.CustomerId, customer.ContactName);
            }

            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);
        }
    }
}
