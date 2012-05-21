using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace HandyToolsAndExtensions.HtmlHelpers
{
    public static class NavigationHelper
    {
        public static bool IsControllerAction(
            this ViewContext context, string controller, string action)
        {
            var valueProvider = context.Controller.ValueProvider;

            var currentAction = valueProvider.GetValue(
                "action").RawValue as string;
            var currentController = valueProvider.GetValue(
                "controller").RawValue as string;

            return currentController == controller && currentAction == action;
        }

        public static MvcHtmlString NavigationLink<T>(
            this HtmlHelper<T> helper, string text, 
            string action, string controller = null)
        {
            var valueProvider = helper.ViewContext.Controller.ValueProvider;
            var currentController = valueProvider.GetValue("controller").RawValue as string;

            controller = controller ?? currentController;

            var builder = new TagBuilder("li");

            builder.InnerHtml = helper.ActionLink(text, action, controller).ToHtmlString();

            if (helper.ViewContext.IsControllerAction(controller, action))
            {
                builder.AddCssClass("active");
            }

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }
    }
}