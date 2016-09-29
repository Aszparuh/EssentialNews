namespace MvcEssentials.Web
{
    using System.Web.Mvc;

    public class ViewEnginesConfig
    {
        public static void RegisterViewEngines(ViewEngineCollection viewEngines)
        {
            /////Remove All Engine
            viewEngines.Clear();
            /////Add Razor Engine
            viewEngines.Add(new RazorViewEngine());
        }
    }
}