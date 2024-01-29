#pragma checksum "C:\Project\OnlineTour\Snapp.Taxi\Snapp.Site\Views\Admin\weeklyFactor.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f2dd542bdc78c478f8d8e84074fadc76e4a56800"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_weeklyFactor), @"mvc.1.0.view", @"/Views/Admin/weeklyFactor.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Admin/weeklyFactor.cshtml", typeof(AspNetCore.Views_Admin_weeklyFactor))]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f2dd542bdc78c478f8d8e84074fadc76e4a56800", @"/Views/Admin/weeklyFactor.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b853c2693020103458b52d8246f923ca3fd89014", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_weeklyFactor : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Snapp.Core.ViewModels.ChartViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Project\OnlineTour\Snapp.Taxi\Snapp.Site\Views\Admin\weeklyFactor.cshtml"
  
    ViewData["Title"] = "پرداخت های هفتگی";
    Layout = "~/Views/Shared/_DashbordLayout.cshtml";


    var xLabels = Newtonsoft.Json.JsonConvert.SerializeObject(Model.Select(x => x.Label).ToList());
    var yValues = Newtonsoft.Json.JsonConvert.SerializeObject(Model.Select(y => y.Value).ToList());
    var zColors = Newtonsoft.Json.JsonConvert.SerializeObject(Model.Select(z => z.Color).ToList());

#line default
#line hidden
            BeginContext(472, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            DefineSection("mySection", async() => {
                BeginContext(494, 327, true);
                WriteLiteral(@"

    <script src=""https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.2/Chart.bundle.min.js""></script>

    <script>

        //2d=2 یعدی
        var ctx = document.getElementById('chart').getContext('2d');

        var chart = new Chart(ctx, {
            type: 'bar',
            data: {
                labels: ");
                EndContext();
                BeginContext(822, 17, false);
#line 24 "C:\Project\OnlineTour\Snapp.Taxi\Snapp.Site\Views\Admin\weeklyFactor.cshtml"
                   Write(Html.Raw(xLabels));

#line default
#line hidden
                EndContext();
                BeginContext(839, 107, true);
                WriteLiteral(",\r\n                datasets: [{\r\n                    label: \"پرداخت های هفتگی\",\r\n                    data: ");
                EndContext();
                BeginContext(947, 17, false);
#line 27 "C:\Project\OnlineTour\Snapp.Taxi\Snapp.Site\Views\Admin\weeklyFactor.cshtml"
                     Write(Html.Raw(yValues));

#line default
#line hidden
                EndContext();
                BeginContext(964, 40, true);
                WriteLiteral(",\r\n                    backgroundColor: ");
                EndContext();
                BeginContext(1005, 17, false);
#line 28 "C:\Project\OnlineTour\Snapp.Taxi\Snapp.Site\Views\Admin\weeklyFactor.cshtml"
                                Write(Html.Raw(zColors));

#line default
#line hidden
                EndContext();
                BeginContext(1022, 353, true);
                WriteLiteral(@",
                    borderWodth: 1
                }]
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true
                        }
                    }]
                }
            }
        });

    </script>
");
                EndContext();
            }
            );
            BeginContext(1378, 148, true);
            WriteLiteral("\r\n<div class=\"col-lg-12 col-md-12 col-sm-12 col-xs-12\">\r\n\r\n    <canvas id=\"chart\" style=\"width: 100%; height: 500px\"></canvas>\r\n\r\n</div>\r\n\r\n\r\n\r\n\r\n\r\n");
            EndContext();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Snapp.Core.ViewModels.ChartViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591