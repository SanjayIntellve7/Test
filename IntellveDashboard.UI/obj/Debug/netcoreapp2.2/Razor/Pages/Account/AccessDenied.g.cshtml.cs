#pragma checksum "C:\Users\admin\Desktop\copy to New UI\IntellveDashboard\IntellveDashboard.UI\IntellveDashboard.UI\Pages\Account\AccessDenied.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6373c5167f010913a4057cf0dcb80af392878f7f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Account_AccessDenied), @"mvc.1.0.razor-page", @"/Pages/Account/AccessDenied.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Account/AccessDenied.cshtml", typeof(AspNetCore.Pages_Account_AccessDenied), null)]
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
#line 1 "C:\Users\admin\Desktop\copy to New UI\IntellveDashboard\IntellveDashboard.UI\IntellveDashboard.UI\Pages\_ViewImports.cshtml"
using IntellveDashboard.UI;

#line default
#line hidden
#line 2 "C:\Users\admin\Desktop\copy to New UI\IntellveDashboard\IntellveDashboard.UI\IntellveDashboard.UI\Pages\_ViewImports.cshtml"
using IntellveDashboard.UI.Models;

#line default
#line hidden
#line 2 "C:\Users\admin\Desktop\copy to New UI\IntellveDashboard\IntellveDashboard.UI\IntellveDashboard.UI\Pages\Account\_ViewImports.cshtml"
using IntellveDashboard.UI.Pages.Account;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6373c5167f010913a4057cf0dcb80af392878f7f", @"/Pages/Account/AccessDenied.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"757321506072e5aea5ea40371f14b550f633ae30", @"/Pages/_ViewImports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4730aa60e3b691fb9c63119fa25059a973797fd4", @"/Pages/Account/_ViewImports.cshtml")]
    public class Pages_Account_AccessDenied : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 3 "C:\Users\admin\Desktop\copy to New UI\IntellveDashboard\IntellveDashboard.UI\IntellveDashboard.UI\Pages\Account\AccessDenied.cshtml"
  
    ViewData["Title"] = "Access denied";

#line default
#line hidden
            BeginContext(82, 26, true);
            WriteLiteral("\r\n<h2 class=\"text-danger\">");
            EndContext();
            BeginContext(109, 17, false);
#line 7 "C:\Users\admin\Desktop\copy to New UI\IntellveDashboard\IntellveDashboard.UI\IntellveDashboard.UI\Pages\Account\AccessDenied.cshtml"
                   Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(126, 84, true);
            WriteLiteral("</h2>\r\n<p class=\"text-danger\">\r\n    You do not have access to this resource.\r\n</p>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<AccessDeniedModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AccessDeniedModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<AccessDeniedModel>)PageContext?.ViewData;
        public AccessDeniedModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591