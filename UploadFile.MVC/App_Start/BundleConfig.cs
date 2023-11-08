using System.Web;
using System.Web.Optimization;

namespace UploadFile.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));





            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                      //"~/Scripts/kendo/jquery.min.js",
                      "~/Scripts/kendo/jszip.min.js",
                      "~/Scripts/kendo/kendo.all.min.js",
                      // "~/Scripts/kendo/kendo.timezones.min.js", // uncomment if using the Scheduler
                      "~/Scripts/kendo/kendo.aspnetmvc.min.js",
                      "~/Scripts/kendo/cultures/kendo.culture.fa-IR.min.js",
                      "~/Scripts/kendo/messages/kendo.messages.fa-IR.js"
                         ));

            bundles.Add(new StyleBundle("~/Content/kendo/css").Include(
                "~/Content/kendo/kendo.common-bootstrap.min.css",
                "~/Content/kendo/kendo.rtl.min.css",
                "~/Content/kendo/kendo.bootstrap.min.css"));

            bundles.Add(new ScriptBundle("~/bundles/LTE").Include(
                "~/Scripts/LTE/bower_components/jquery.slimscroll.min.js",
                "~/Scripts/LTE/bower_components/bootstrap.min.js",
                "~/Scripts/LTE/bower_components/fastclick.js",
                "~/Scripts/LTE/dist/adminlte.js"));

        }
    }
}
