using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using DomainModel.DTOS.Supplier;
using System.Reflection;

namespace Eshop
{
    public static class MyActionLink
    {
        private static Dictionary<string, string> GetProp(object model)
        {

            Dictionary<string, string> RefProperty = new Dictionary<string, string>();
            foreach (var propInfo in model.GetType().GetProperties())
            {
                RefProperty.Add(propInfo.Name, propInfo.GetValue(model).ToString());
            }
            return RefProperty;
        }
        public static TagBuilder CustomActionLink(this IHtmlHelper htmlHelper, string linkText, string actionName, string controllerName, bool ajax, string targetID, object obj,object htmlAttributes)
        {
            TagBuilder span = new TagBuilder("span");
            var attributes = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes) as IDictionary<string, object>;
            span.Attributes.Add("data-ajax", Convert.ToString(ajax));
            span.Attributes.Add("data-actionName", actionName);
            span.Attributes.Add("data-conterollerName", controllerName);
            span.Attributes.Add("data-targetID", targetID);
            var prop = GetProp(obj);
            foreach (KeyValuePair<string,string> item in prop)
            {
                span.Attributes.Add(String.Format("data-{0}", item.Key), item.Value);
            }
            span.MergeAttributes(attributes);
            span.InnerHtml.Append(linkText);
            return span;
        }


    }
}
