#pragma checksum "C:\Users\genad\OneDrive\Работен плот\ASP.NET Core\CHUSHKA.Web\CHUSHKA.Web\Views\Shared\Components\action\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f9e24860095e5fc94f0274dbb7df0b1f3c0fbf17"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_action_Default), @"mvc.1.0.view", @"/Views/Shared/Components/action/Default.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/Components/action/Default.cshtml", typeof(AspNetCore.Views_Shared_Components_action_Default))]
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
#line 1 "C:\Users\genad\OneDrive\Работен плот\ASP.NET Core\CHUSHKA.Web\CHUSHKA.Web\Views\_ViewImports.cshtml"
using CHUSHKA.Web;

#line default
#line hidden
#line 2 "C:\Users\genad\OneDrive\Работен плот\ASP.NET Core\CHUSHKA.Web\CHUSHKA.Web\Views\_ViewImports.cshtml"
using CHUSHKA.Models;

#line default
#line hidden
#line 3 "C:\Users\genad\OneDrive\Работен плот\ASP.NET Core\CHUSHKA.Web\CHUSHKA.Web\Views\_ViewImports.cshtml"
using CHUSHKA.Web.Services;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f9e24860095e5fc94f0274dbb7df0b1f3c0fbf17", @"/Views/Shared/Components/action/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d6d275a790eee485da23eb09362f9083308c48f8", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_action_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<CHUSHKA.Web.ViewModels.ActionViewModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("nav-link"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\genad\OneDrive\Работен плот\ASP.NET Core\CHUSHKA.Web\CHUSHKA.Web\Views\Shared\Components\action\Default.cshtml"
 foreach (var action in Model)
{

#line default
#line hidden
            BeginContext(88, 25, true);
            WriteLiteral("    <li class=\"nav-item\">");
            EndContext();
            BeginContext(113, 101, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "49d2b2b2d0f44274854b147d2b66d345", async() => {
                BeginContext(198, 12, false);
#line 4 "C:\Users\genad\OneDrive\Работен плот\ASP.NET Core\CHUSHKA.Web\CHUSHKA.Web\Views\Shared\Components\action\Default.cshtml"
                                                                                                        Write(action.Title);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginWriteTagHelperAttribute();
#line 4 "C:\Users\genad\OneDrive\Работен плот\ASP.NET Core\CHUSHKA.Web\CHUSHKA.Web\Views\Shared\Components\action\Default.cshtml"
                                WriteLiteral(action.Controller);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-controller", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 4 "C:\Users\genad\OneDrive\Работен плот\ASP.NET Core\CHUSHKA.Web\CHUSHKA.Web\Views\Shared\Components\action\Default.cshtml"
                                                                WriteLiteral(action.Action);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-action", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(214, 7, true);
            WriteLiteral("</li>\r\n");
            EndContext();
#line 5 "C:\Users\genad\OneDrive\Работен плот\ASP.NET Core\CHUSHKA.Web\CHUSHKA.Web\Views\Shared\Components\action\Default.cshtml"
}

#line default
#line hidden
            BeginContext(224, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<CHUSHKA.Web.ViewModels.ActionViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
