using System.Web;
using System.Web.Optimization;

namespace Annexio
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/dataTables.responsive.min.js",
                        "~/Scripts/datatables/dataTables.buttons.min.js",
                        "~/Scripts/datatables/dataTables.select.min.js",
                        "~/Scripts/datatables/datatables.bootstrap4.js"));

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
                      "~/Content/DataTables/css/dataTables.bootstrap4.css",
                      "~/Content/DataTables/css/jquery.dataTables.min.css",
                      "~/Content/DataTables/css/buttons.dataTables.min.css",
                      "~/Content/DataTables/css/select.dataTables.min.css",
                      "~/Content/DataTables/css/responsive.dataTables.min.css",
                      "~/Content/site.css"));
        }
    }
}
