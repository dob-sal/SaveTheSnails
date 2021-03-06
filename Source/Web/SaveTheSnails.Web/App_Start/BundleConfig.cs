﻿using System.Web;
using System.Web.Optimization;

namespace SaveTheSnails.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            RegisterScriptBundles(bundles);
            RegisterStyleBundles(bundles);

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }

        private static void RegisterStyleBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/googlemaps").Include(
                                "~/Content/googleMaps/google-maps.css"));

            bundles.Add(new StyleBundle("~/Content/custom").Include(
                                "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                                "~/Content/bootstrap.css"));

            bundles.Add(new StyleBundle("~/Content/kendo").Include(
                                "~/Content/kendo/kendo.common.min.css",
                                "~/Content/kendo/kendo.common-bootstrap.min.css",
                                "~/Content/kendo/kendo.silver.min.css"));
        }

        private static void RegisterScriptBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/kendo").Include(
                                           "~/Scripts/kendo/kendo.all.min.js",
                                           "~/Scripts/kendo/kendo.aspnetmvc.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery")
                         .Include("~/Scripts/kendo/jquery.min.js"));
                       // .Include( "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery-ajax")
                                        .Include("~/Scripts/jquery-{version}.js",
                                                    "~/Scripts/jquery.unobtrusive-ajax.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                                             "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/googlemaps").Include(
                      "~/Scripts/googleMaps/initialize.js"));

            bundles.Add(new ScriptBundle("~/bundles/googlemapsSetMarkers").Include(
                     "~/Scripts/googleMaps/set-markers.js"));
                     
        }
    }
}
