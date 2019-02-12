using System.Web;
using System.Web.Optimization;

namespace DTS
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));


            ////
            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                            "~/SPA/app.js",
                            "~/SPA/controllers/homeController.js",
                            "~/SPA/controllers/loginController.js",
                            "~/SPA/controllers/JobController.js",
                            "~/SPA/controllers/projectController.js",
                            "~/SPA/controllers/defectController.js",
                            "~/SPA/controllers/salewithusController.js",
                            "~/SPA/controllers/BagController.js", 
                            "~/SPA/controllers/BottleController.js",
                            "~/SPA/controllers/CapController.js",
                            "~/SPA/controllers/salewithusinnerpage1Controller.js",
                            "~/SPA/controllers/salewithusinnerpage2Controller.js"));

            bundles.Add(new ScriptBundle("~/bundles/ngFactories").Include(
                            "~/SPA/factories/authService.js",
                            "~/SPA/factories/authintercepterService.js",
                            "~/SPA/services/projectService.js",
                            "~/SPA/services/salewithusService.js",
                            "~/SPA/services/jobsService.js",
                            "~/SPA/services/defectService.js",
                            "~/SPA/services/FileUploadservice.js",
                            "~/SPA/directives/fileuploaddirective.js"
                          
                            ));


            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                       "~/Scripts/angular.js",
                       "~/Scripts/angular-ui-router.js",
                        "~/Scripts/angular-animate/angular-animate.js",
                           "~/Scripts/angular-aria/angular-aria.js",
                         "~/Scripts/angular-messages.js",
                          "~/Scripts/angular-material/angular-material.js",
                            "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                          "~/Scripts/loading-bar.js",
                       "~/Scripts/angular-local-storage.js"
                       

                      ));


            bundles.Add(new ScriptBundle("~/bundles/DTSJs").Include(
                   "~/Scripts/js/contact_me.js",
                     "~/Scripts/js/freelancer.js",
                     "~/Scripts/js/jqBootstrapValidation.js",
                     "~/Scripts/js/loginjs.js"
                    ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                   "~/Content/bootstrap.css",
                   "~/Content/angular-material.css",
                   "~/Content/ui-bootstrap-csp.css",
                   "~/Content/loading-bar.css",
                     "~/Content/Mycss.css",
                       "~/Content/Customcss/form.css",
                        "~/Content/bootstrap-datepicker.css",

                        "~/Content/site.css",
                      "~/Content/style.css",
                       "~/Content/font-awesome.css",
                        "~/Content/easy-responsive-tabss.css"
                     ));

            bundles.Add(new StyleBundle("~/Content/DTScss").Include(
                  "~/Content/Customcss/freelancer.css",
                  "~/Content/Customcss/logincss.css",
                
                  "~/vendor/font-awesome/css/font-awesome.css"
                         ));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/vendor/jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                         "~/Scripts/bootstrap-datepicker.js"));


        }
    }
}
