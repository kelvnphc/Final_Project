#pragma checksum "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\PaymentSuccess.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "a7e222ac9cf2dac476cb8c5622144e5235e76922b15f15bf4c70dc089c595448"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GioHang_PaymentSuccess), @"mvc.1.0.view", @"/Views/GioHang/PaymentSuccess.cshtml")]
namespace AspNetCore
{
    #line default
    using global::System;
    using global::System.Collections.Generic;
    using global::System.Linq;
    using global::System.Threading.Tasks;
    using global::Microsoft.AspNetCore.Mvc;
    using global::Microsoft.AspNetCore.Mvc.Rendering;
    using global::Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\_ViewImports.cshtml"
using PPKBeverage

#nullable disable
    ;
#nullable restore
#line 2 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\_ViewImports.cshtml"
using PPKBeverage.Models

#line default
#line hidden
#nullable disable
    ;
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"a7e222ac9cf2dac476cb8c5622144e5235e76922b15f15bf4c70dc089c595448", @"/Views/GioHang/PaymentSuccess.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"6c328286c99cfdf6687849731f1d1bb0c56295f3e50ad8ca5904f32cf841e868", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_GioHang_PaymentSuccess : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "KhachHang", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ListBeverage", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("type", new global::Microsoft.AspNetCore.Html.HtmlString("submit"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-primary btn-lg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
#nullable restore
#line 1 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\PaymentSuccess.cshtml"
  
    ViewBag.Title = "Payment Success";
    Layout = "_NewLayout";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<div class=\"container mt-5 fixed-container\">\r\n    <div class=\"alert alert-success text-center p-5\">\r\n        <h2 class=\"display-4\">Thành Công</h2>\r\n        <p class=\"lead\">Giao dịch của bạn đã thành công đơn hàng: <strong>");
            Write(
#nullable restore
#line 9 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\PaymentSuccess.cshtml"
                                                                           ViewBag.OrderId

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</strong> - <strong>");
            Write(
#nullable restore
#line 9 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\PaymentSuccess.cshtml"
                                                                                                               ViewBag.TongTien

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(" VNĐ</strong></p>\r\n        <p class=\"mb-4\">Cảm ơn bạn đã mua hàng!</p>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a7e222ac9cf2dac476cb8c5622144e5235e76922b15f15bf4c70dc089c5954485918", async() => {
                WriteLiteral("Quay lại trang chủ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
    </div>
</div>
<script src=""https://www.gstatic.com/dialogflow-console/fast/messenger/bootstrap.js?v=1""></script>
<df-messenger intent=""WELCOME""
              chat-title=""CSKH-PPK-Coffee""
              agent-id=""66dfadc2-e7dc-4761-9ada-f796b9eabad2""
              language-code=""vi""></df-messenger>
<style>
    body {
        background: linear-gradient(135deg, #ffcc00 0%, #ff6600 100%) !important;
        color: #ffffff !important;
        font-family: 'Arial', sans-serif !important;
    }

    .fixed-container {
        position: fixed !important;
        top: 50% !important;
        left: 50% !important;
        transform: translate(-50%, -50%) !important;
        z-index: 1000 !important;
        max-width: 700px;
        background-color: #ffffff !important;
        padding: 40px !important;
        border-radius: 15px !important;
        box-shadow: 0 10px 20px rgba(0, 0, 0, 0.2) !important;
    }

    .alert-success {
        background-color: #28a745 !important;
       ");
            WriteLiteral(@" border-color: #28a745 !important;
        color: #ffffff !important;
    }

    .display-4 {
        font-family: 'Georgia', serif !important;
        color: #ff6600 !important;
        font-weight: bold !important;
    }

    .lead {
        font-size: 1.25rem !important;
    }

    .btn-primary {
        background-color: #007bff !important;
        border-color: #007bff !important;
        color: #ffffff !important;
        font-size: 1.1rem !important;
        padding: 10px 20px !important;
        border-radius: 5px !important;
    }

        .btn-primary:hover {
            background-color: #0056b3 !important;
            border-color: #0056b3 !important;
        }
</style>
");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591