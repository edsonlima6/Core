#pragma checksum "/home/edsonlima/Documents/GitHub/Core/NetDocsCore2_1/Pages/Supplier.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "95e765b910c8abbce5e0f30e30b24f273b5020d2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Supplier), @"mvc.1.0.razor-page", @"/Pages/Supplier.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure.RazorPageAttribute(@"/Pages/Supplier.cshtml", typeof(AspNetCore.Pages_Supplier), null)]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95e765b910c8abbce5e0f30e30b24f273b5020d2", @"/Pages/Supplier.cshtml")]
    public class Pages_Supplier : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 12, true);
            WriteLiteral("\n<div>\n\n<h1>");
            EndContext();
            BeginContext(63, 28, false);
#line 10 "/home/edsonlima/Documents/GitHub/Core/NetDocsCore2_1/Pages/Supplier.cshtml"
Write(Model._supplier.sRazaoSocial);

#line default
#line hidden
            EndContext();
            BeginContext(91, 11, true);
            WriteLiteral("</h1>\n\n<p> ");
            EndContext();
            BeginContext(103, 54, false);
#line 12 "/home/edsonlima/Documents/GitHub/Core/NetDocsCore2_1/Pages/Supplier.cshtml"
Write(Html.DisplayFor(model => model._supplier.sRazaoSocial));

#line default
#line hidden
            EndContext();
            BeginContext(157, 14, true);
            WriteLiteral("</p>\n\n<div>   ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<MyApp.Namespace.SupplierModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyApp.Namespace.SupplierModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<MyApp.Namespace.SupplierModel>)PageContext?.ViewData;
        public MyApp.Namespace.SupplierModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
