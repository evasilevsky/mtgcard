using System.Web.Optimization;

namespace MtgCard
{
	public class BundleConfig
	{
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/generalScripts").Include(
						"~/Scripts/jquery-{version}.js",
						"~/Scripts/jquery-ui-{version}.js",
						"~/Scripts/jquery.validate.js",
						"~/Scripts/jquery.validate.unobtrusive.js",
						"~/Scripts/bootstrap.js",
						"~/Scripts/common.js"));

			bundles.Add(new ScriptBundle("~/bundles/additionalScripts").Include(
				"~/Scripts/angular.js"));

			bundles.Add(new ScriptBundle("~/bundles/customScripts").Include(
				"~/js/app.js"
				));


			bundles.Add(new StyleBundle("~/bundles/styles").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css",
					  "~/Content/themes/base/*.css"));




			BundleTable.EnableOptimizations = true;
		}
	}
}
