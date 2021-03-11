using System.Web;
using System.Web.Optimization;

namespace SocialDisplay
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery")
                            .Include("~/Scripts/jquery-{version}.js"));


            bundles.Add(new ScriptBundle("~/bundles/backstretch").Include(
                 "~/Scripts/jquery.backstretch.js*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/custom.css", 
                "~/Content/bootstrap.css", 
                "~/Content/bootstrap-responsive.css",
                "~/Content/font-awesome.css"));
        }
    }
}