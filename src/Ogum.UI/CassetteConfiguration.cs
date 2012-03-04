using System.IO;
using System.Text.RegularExpressions;
using Cassette.Configuration;
using Cassette.HtmlTemplates;
using Cassette.Scripts;
using Cassette.Stylesheets;

namespace Ogum.UI
{
    /// <summary>
    /// Configures the Cassette asset modules for the web application.
    /// </summary>
    public class CassetteConfiguration : ICassetteConfiguration
    {
        public void Configure(BundleCollection bundles, CassetteSettings settings)
        {
            bundles.AddPerSubDirectory<HtmlTemplateBundle>("templates", new FileSearch
                                                                           {
                                                                               Pattern = "*.html",
                                                                               SearchOption =
                                                                                   SearchOption.AllDirectories
                                                                           });

            bundles.AddPerSubDirectory<StylesheetBundle>("css", new FileSearch
                                                                           {
                                                                               Pattern = "*.css",
                                                                               SearchOption =
                                                                                   SearchOption.AllDirectories
                                                                           });

            bundles.AddPerSubDirectory<ScriptBundle>("js", new FileSearch
                                                                      {
                                                                          Pattern = "*.js;*.coffee",
                                                                          SearchOption = SearchOption.AllDirectories,
                                                                          Exclude = new Regex("-vsdoc\\.js$")
                                                                      });

            
        }
    }
}