#pragma checksum "C:\Users\admin\Desktop\copy to New UI\IntellveDashboard\IntellveDashboard.UI\IntellveDashboard.UI\Views\Shared\Main\_frequentMostAlertGeneratingBranches.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee62be1ee703620535641d221268b745c20fb4d3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Main__frequentMostAlertGeneratingBranches), @"mvc.1.0.view", @"/Views/Shared/Main/_frequentMostAlertGeneratingBranches.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Main/_frequentMostAlertGeneratingBranches.cshtml", typeof(AspNetCore.Views_Shared_Main__frequentMostAlertGeneratingBranches))]
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
#line 1 "C:\Users\admin\Desktop\copy to New UI\IntellveDashboard\IntellveDashboard.UI\IntellveDashboard.UI\Views\_ViewImports.cshtml"
using IntellveDashboard.UI;

#line default
#line hidden
#line 2 "C:\Users\admin\Desktop\copy to New UI\IntellveDashboard\IntellveDashboard.UI\IntellveDashboard.UI\Views\_ViewImports.cshtml"
using IntellveDashboard.UI.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee62be1ee703620535641d221268b745c20fb4d3", @"/Views/Shared/Main/_frequentMostAlertGeneratingBranches.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ba553298c38b237868e67a4a5a81a50990939fcf", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Main__frequentMostAlertGeneratingBranches : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("Chart-loading-image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Images/ajax-loader.gif"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("display:none;height:30px;width:30px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/icon/Barchart.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString("Image"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/icon/Donut.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/assets/img/icon/Pyramidchart.svg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 476, true);
            WriteLiteral(@"

<div class=""col-md-12 col-lg-12 col-sm-12 col-xs-12 three-items"" style=""position:relative;height:100%;width:100%"">
    <div id=""chart"" style=""position:absolute;height:100%;width:100%"">
        <div class=""col-md-3 col-lg-3 col-sm-6 chart-items"">
            <h4>Top 10 Frequent Most Alert Generating Banches</h4>
            <button type=""button"" style=""float:right;"" class=""btn btn-default btn-sm"" onclick=""Show()"">Apply Filter</button>
        </div>
        <div>");
            EndContext();
            BeginContext(476, 107, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ee62be1ee703620535641d221268b745c20fb4d36990", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(583, 1332, true);
            WriteLiteral(@"</div>
        <div class=""chart-div"">
            <p id=""ChartLabel"" style=""padding-top: 25px;""></p>
            <div id=""ChartContainer"" style=""height: 400px; padding-top:40px; ""></div>
        </div>
    </div>
    <div id=""ChartFilters"" style=""visibility:collapse;position:absolute;background-color:grey;height:100%;width:100%"">
        <h4>Apply Filters</h4>
        <div class=""toggle-div"">
            <div class=""two one"">
                <div class=""form-group"">
                    <label for=""ChartstartDate"">Start Date</label>
                    <input id=""ChartstartDate"" name=""ChartstartDate"" type=""text"" class=""form-control"" value=""10-07-2019"" />
                    &nbsp;
                    <label for=""ChartendDate"">End Date</label>
                    <input id=""ChartendDate"" name=""ChartendDate"" type=""text"" class=""form-control"" value=""12-07-2019"" />
                </div>
                <ul class=""RightChartTopList"" id=""ChartType"">
                    <li class=""nav-item"" data-va");
            WriteLiteral(@"lue=""pie""><i class=""fas fa-chart-pie""></i></li>
                    <li class=""nav-item"" data-value=""column""><i class=""far fa-chart-bar""></i></li>
                    <li class=""nav-item"" data-value=""line""><i class=""fas fa-chart-line""></i>  </li>
                    <li class=""nav-item"" data-value=""bar"">");
            EndContext();
            BeginContext(1915, 70, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ee62be1ee703620535641d221268b745c20fb4d39759", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1985, 176, true);
            WriteLiteral(" </li>\r\n                    <li class=\"nav-item\" data-value=\"splineArea\"><i class=\"fas fa-chart-area\"></i></li>\r\n                    <li class=\"nav-item\" data-value=\"doughnut\">");
            EndContext();
            BeginContext(2161, 67, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ee62be1ee703620535641d221268b745c20fb4d311283", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2228, 69, true);
            WriteLiteral("</li>\r\n                    <li class=\"nav-item\" data-value=\"pyramid\">");
            EndContext();
            BeginContext(2297, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ee62be1ee703620535641d221268b745c20fb4d312692", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2371, 403, true);
            WriteLiteral(@"</li>
                </ul>
                <input type=""hidden"" id=""hdnChartType"" />
            </div>
            <div class=""two twice"">
                <div class=""col-md-12 col-lg-12 col-sm-6"" style=""float:right; width: 50%;"">
                    <div class=""col-md-12 col-lg-12 col-sm-6 col-xs-12"" style=""max-width:70%;"">
                        Select DeviceType
                        ");
            EndContext();
            BeginContext(2775, 120, false);
#line 41 "C:\Users\admin\Desktop\copy to New UI\IntellveDashboard\IntellveDashboard.UI\IntellveDashboard.UI\Views\Shared\Main\_frequentMostAlertGeneratingBranches.cshtml"
                   Write(Html.ListBox("ChartDeviceTypes", new MultiSelectList(Model.deviceTypelist, "Text", "Value"), new { @class = "listbox" }));

#line default
#line hidden
            EndContext();
            BeginContext(2895, 67, true);
            WriteLiteral("\r\n                        Select BranchId\r\n                        ");
            EndContext();
            BeginContext(2963, 116, false);
#line 43 "C:\Users\admin\Desktop\copy to New UI\IntellveDashboard\IntellveDashboard.UI\IntellveDashboard.UI\Views\Shared\Main\_frequentMostAlertGeneratingBranches.cshtml"
                   Write(Html.ListBox("ChartBranchIds", new MultiSelectList(Model.branchIdlist, "Text", "Value"), new { @class = "listbox" }));

#line default
#line hidden
            EndContext();
            BeginContext(3079, 67, true);
            WriteLiteral("\r\n                        Select Operator\r\n                        ");
            EndContext();
            BeginContext(3147, 116, false);
#line 45 "C:\Users\admin\Desktop\copy to New UI\IntellveDashboard\IntellveDashboard.UI\IntellveDashboard.UI\Views\Shared\Main\_frequentMostAlertGeneratingBranches.cshtml"
                   Write(Html.ListBox("ChartOperators", new MultiSelectList(Model.operatorlist, "Text", "Value"), new { @class = "listbox" }));

#line default
#line hidden
            EndContext();
            BeginContext(3263, 3651, true);
            WriteLiteral(@"
                    </div>
                </div>
            </div>
        </div>
        <div class=""toggle-div-one"">
            <div style=""margin: 0 auto; width: 210px;"">
                <button type=""button"" class=""btn btn-default"" onclick=""drawChart()"">Apply</button>
                <button type=""button"" class=""btn btn-default"" onclick=""Hide()"">Cancel</button>
            </div>
        </div>
    </div>
</div>

<link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/bootstrap-multiselect/0.9.13/css/bootstrap-multiselect.css"" />
<link rel=""stylesheet"" type=""text/css"" href=""https://cdn.rawgit.com/wenzhixin/multiple-select/e14b36de/multiple-select.css"" />

<script src=""https://cdnjs.cloudflare.com/ajax/libs/moment.js/2.24.0/moment.min.js""></script>
<script src=""https://cdn.rawgit.com/wenzhixin/multiple-select/e14b36de/multiple-select.js""></script>

<script>
    function Show() {
        document.getElementById('ChartFilters').style.visibility = ""visible"";
    }
    f");
            WriteLiteral(@"unction Hide() {
        document.getElementById('ChartFilters').style.visibility = ""collapse"";
    }

    $(""#ChartType li"").click(function () {
        $(""#hdnChartType"").val($(this).data('value'));
    });

    function drawChart() {

        let From = $('#ChartstartDate').val();
        let To = $('#ChartendDate').val();

        let ChartType = $(""#hdnChartType"").val();
        console.log(ChartType);

        let DeviceTypesSelected = $('#ChartDeviceTypes').val();

        let BranchIdsSelected = $('#ChartBranchIds').val();

        let OperatorsSelected = $('#ChartOperators').val();

        drawChartWithFilter(From, To, ChartType, DeviceTypesSelected, BranchIdsSelected, OperatorsSelected);

        $(""#ChartLabel"").html(""From:"" + From + "" To:"" + To);
        document.getElementById('ChartFilters').style.visibility = ""collapse"";
    }

    $(""#ChartDeviceTypes"").multipleSelect({ filter: true });
    $(""#ChartBranchIds"").multipleSelect({ filter: true });
    $(""#ChartOpera");
            WriteLiteral(@"tors"").multipleSelect({ filter: true });

</script>

<style>
    .canvasjs-chart-credit {
        display: none !important;
    }

    .two-box .ms-parent {
        width: 200% !important;
    }

    #daterangePickerContainer {
        padding: 10px 0px 10px 20px;
        width: auto;
    }

    .float {
        float: left;
    }

    .calContainer {
        margin - right: 3px;
    }

        .calContainer input {
            width: 100%;
            text-align: center;
        }

    .list-group {
        margin - bottom: none;
    }

    .list-group {
        padding: 0px;
    }

        .list-group a {
            line - height: 4px;
            font-size: 12px;
            border: 1px solid;
            width: 84%;
            text-align: center;
            color: #808080;
        }

    #timeContainer {
        background: #e4e4e4;
    }

    .third-row .toggle-div {
        width: 100% !important;
        height: 400px;
    }

    .toggle-div .");
            WriteLiteral(@"two {
        width: 49% !important;
        display: inline-block;
    }

        .toggle-div .two.one {
            margin - right: 5px;
            float: left;
            width: 59% !important;
        }

        .toggle-div .two.twice {
            width: 40% !important;
            float: right;
        }

    .toggle-div-one {
        width: 100% !important;
        height: 50px;
    }

    .toggle-box {
        background - color: rgba(255, 255, 255, 0.75) !important;
        max-width: 100% !important;
        width: 100%;
    }
</style>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
