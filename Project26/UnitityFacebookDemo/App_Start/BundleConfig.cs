using System.Web.Optimization;

namespace UnitityFacebookDemo.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js", 
                                                                     "~/Scripts/script.js", 
                                                                     "~/Scripts/jquery.countdown.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css", 
                                                                 "~/Content/pure.css",
                                                                 "~/Content/style.css",
                                                                 "~/Contentjquery.countdown.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include());

	
        }
    }
}