#pragma checksum "/home/ali/BookStore/Views/Publisher/getPublisher.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15f5ef3ec07e97bd7aaa5f6f9fb5298a06be4bc0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Publisher_getPublisher), @"mvc.1.0.view", @"/Views/Publisher/getPublisher.cshtml")]
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
#nullable restore
#line 1 "/home/ali/BookStore/Views/_ViewImports.cshtml"
using BookStore;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/ali/BookStore/Views/_ViewImports.cshtml"
using BookStore.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15f5ef3ec07e97bd7aaa5f6f9fb5298a06be4bc0", @"/Views/Publisher/getPublisher.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"970ad2232b60c18355d1b72e2ff9366751045b67", @"/Views/_ViewImports.cshtml")]
    public class Views_Publisher_getPublisher : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/home/ali/BookStore/Views/Publisher/getPublisher.cshtml"
  
    ViewBag.Title = "Get Publisher"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<table class=\"table table-striped\">\n            \n            <tr>\n                <td>Publisher Code</td>\n                <td>Name</td>\n                <td>City</td>\n                <td>Phone_1</td>\n                <td>Phone_2</td>\n            </tr>\n\n");
#nullable restore
#line 15 "/home/ali/BookStore/Views/Publisher/getPublisher.cshtml"
             foreach(BookStore.Models.Publisher publisher in Model){

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\n                <td>");
#nullable restore
#line 17 "/home/ali/BookStore/Views/Publisher/getPublisher.cshtml"
               Write(publisher.Code);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 18 "/home/ali/BookStore/Views/Publisher/getPublisher.cshtml"
               Write(publisher.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 19 "/home/ali/BookStore/Views/Publisher/getPublisher.cshtml"
               Write(publisher.City);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 20 "/home/ali/BookStore/Views/Publisher/getPublisher.cshtml"
               Write(publisher.Phone_1);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                <td>");
#nullable restore
#line 21 "/home/ali/BookStore/Views/Publisher/getPublisher.cshtml"
               Write(publisher.Phone_2);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n            </tr>\n");
#nullable restore
#line 23 "/home/ali/BookStore/Views/Publisher/getPublisher.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            \n        </table>");
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
