#pragma checksum "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ThongKeTheoDoanhThu.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "f1fd95905084e6c40f207f5345ec2eda85dbc810fbbe29cac3a2cd8ad82ebe9a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ThongKeTheoDoanhThu), @"mvc.1.0.view", @"/Views/Admin/ThongKeTheoDoanhThu.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"f1fd95905084e6c40f207f5345ec2eda85dbc810fbbe29cac3a2cd8ad82ebe9a", @"/Views/Admin/ThongKeTheoDoanhThu.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"6c328286c99cfdf6687849731f1d1bb0c56295f3e50ad8ca5904f32cf841e868", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_ThongKeTheoDoanhThu : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PPKBeverage.Models.ThongKeTheoDoanhThuModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "ThongKeTheoDoanhThu", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "get", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("mb-4"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ThongKeTheoDoanhThu.cshtml"
  
    ViewData["Title"] = "Thống kê theo doanh thu";
    Layout = "_Layout";


#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<div class=\"container mt-5\">\r\n    <h1 class=\"text-center mb-4\">Thống kê theo doanh thu</h1>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f1fd95905084e6c40f207f5345ec2eda85dbc810fbbe29cac3a2cd8ad82ebe9a4873", async() => {
                WriteLiteral(@"
        <div class=""form-row align-items-end"">
            <div class=""col-md-3"">
                <label for=""filter"">Lọc theo ngày:</label>
                <input type=""date"" id=""filter"" name=""kw"" class=""form-control"" />
            </div>
            <div class=""col-md-3"">
                <button type=""submit"" class=""btn btn-primary"">Gửi</button>
            </div>
        </div>
    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"

    <table class=""table table-hover table-striped"">
        <thead class=""thead-dark"">
            <tr>
                <th>Tên cà phê</th>
                <th>Doanh thu</th>
                <th>Hành động</th>
            </tr>
        </thead>
        <tbody>
");
#nullable restore
#line 33 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ThongKeTheoDoanhThu.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable

            WriteLiteral("                <tr>\r\n                    <td>");
            Write(
#nullable restore
#line 36 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ThongKeTheoDoanhThu.cshtml"
                         Html.DisplayFor(modelItem => item.Ten)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                    <td>");
            Write(
#nullable restore
#line 37 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ThongKeTheoDoanhThu.cshtml"
                         Html.DisplayFor(modelItem => item.DoanhThu)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 39 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ThongKeTheoDoanhThu.cshtml"
            }

#line default
#line hidden
#nullable disable

            WriteLiteral(@"        </tbody>
    </table>

    <div class=""card mt-4"">
        <div class=""card-body"">
            <canvas id=""myChart""></canvas>
        </div>
    </div>
</div>

<script src=""https://cdn.jsdelivr.net/npm/chart.js""></script>
<script src=""/js/JavaScript.js""></script>
<script>
    let labels = [];
    let data = [];
");
#nullable restore
#line 55 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ThongKeTheoDoanhThu.cshtml"
     foreach (var item in Model)
    {
        

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n            labels.push(\"");
            Write(
#nullable restore
#line 58 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ThongKeTheoDoanhThu.cshtml"
                          item.Ten

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\");\r\n        data.push(");
            Write(
#nullable restore
#line 59 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ThongKeTheoDoanhThu.cshtml"
                   item.DoanhThu

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(");\r\n        ");
#nullable restore
#line 60 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ThongKeTheoDoanhThu.cshtml"
               
    }

#line default
#line hidden
#nullable disable

            WriteLiteral(@"        window.onload = function () {
            let ctx1 = document.getElementById(""myChart"").getContext('2d');
            drawChartTheoSoLuong(ctx1, labels, data, ""THỐNG KÊ DOANH THU SẢN PHẨM BÁN"");
        }
</script>

<style>
    body {
        background-color: #f8f9fa;
        color: #343a40;
        font-family: 'Arial', sans-serif;
    }

    .container {
        background-color: #ffffff;
        padding: 30px;
        border-radius: 10px;
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.15);
    }

    h1 {
        color: #343a40;
    }

    .table-hover tbody tr:hover {
        background-color: #f5f5f5;
    }

    .thead-dark th {
        background-color: #343a40;
        color: #ffffff;
    }

    .btn-group .btn {
        margin-right: 5px;
    }

    .card {
        border: none;
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
    }

    .card-body {
        padding: 2rem;
    }

    .btn-primary {
        background-color: #007bff;
        bo");
            WriteLiteral(@"rder-color: #007bff;
    }

    .btn-warning {
        background-color: #ffc107;
        border-color: #ffc107;
    }

    .btn-info {
        background-color: #17a2b8;
        border-color: #17a2b8;
    }

    .btn-danger {
        background-color: #dc3545;
        border-color: #dc3545;
    }

    .form-row {
        align-items: flex-end;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PPKBeverage.Models.ThongKeTheoDoanhThuModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591