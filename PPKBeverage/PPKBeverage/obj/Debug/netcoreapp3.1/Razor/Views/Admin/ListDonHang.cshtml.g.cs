#pragma checksum "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "027010d2abf3059ba14db37ed83db0e632f02dc2fcb3c7cec01055b8bffa8377"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_ListDonHang), @"mvc.1.0.view", @"/Views/Admin/ListDonHang.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"027010d2abf3059ba14db37ed83db0e632f02dc2fcb3c7cec01055b8bffa8377", @"/Views/Admin/ListDonHang.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"6c328286c99cfdf6687849731f1d1bb0c56295f3e50ad8ca5904f32cf841e868", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Admin_ListDonHang : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PPKBeverage.Models.DonHang>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
  
    ViewData["Title"] = "Danh sách đơn hàng";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<div class=\"container-fluid mt-4\">\r\n    <h1 class=\"text-center\">DANH SÁCH CÁC ĐƠN HÀNG MÀ KHÁCH HÀNG ĐÃ ĐẶT</h1>\r\n\r\n    <!-- Pagination -->\r\n    <ul class=\"pagination justify-content-center\">\r\n        <!-- Nút Previous -->\r\n");
#nullable restore
#line 14 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
         if (ViewBag.CurrentPage > 1)
        {

#line default
#line hidden
#nullable disable

            WriteLiteral("            <li class=\"page-item\">\r\n                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 477, "\"", 534, 2);
            WriteAttributeValue("", 484, "/Admin/ListDonHang?page=", 484, 24, true);
            WriteAttributeValue("", 508, 
#nullable restore
#line 17 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
                                                                     ViewBag.CurrentPage - 1

#line default
#line hidden
#nullable disable
            , 508, 26, false);
            EndWriteAttribute();
            WriteLiteral(">Previous</a>\r\n            </li>\r\n");
#nullable restore
#line 19 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
        }

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n        <!-- Hiển thị các số trang -->\r\n");
#nullable restore
#line 22 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
         for (int i = 1; i <= ViewBag.TotalPages; i++)
        {

#line default
#line hidden
#nullable disable

            WriteLiteral("            <li");
            BeginWriteAttribute("class", " class=\"", 704, "\"", 765, 2);
            WriteAttributeValue("", 712, "page-item", 712, 9, true);
            WriteAttributeValue(" ", 721, 
#nullable restore
#line 24 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
                                   i == ViewBag.CurrentPage ? "active" : ""

#line default
#line hidden
#nullable disable
            , 722, 43, false);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 805, "\"", 838, 2);
            WriteAttributeValue("", 812, "/Admin/ListDonHang?page=", 812, 24, true);
            WriteAttributeValue("", 836, 
#nullable restore
#line 25 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
                                                                    i

#line default
#line hidden
#nullable disable
            , 836, 2, false);
            EndWriteAttribute();
            WriteLiteral(">");
            Write(
#nullable restore
#line 25 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
                                                                        i

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</a>\r\n            </li>\r\n");
#nullable restore
#line 27 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
        }

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n        <!-- Nút Next -->\r\n");
#nullable restore
#line 30 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
         if (ViewBag.CurrentPage < ViewBag.TotalPages)
        {

#line default
#line hidden
#nullable disable

            WriteLiteral("            <li class=\"page-item\">\r\n                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 1046, "\"", 1103, 2);
            WriteAttributeValue("", 1053, "/Admin/ListDonHang?page=", 1053, 24, true);
            WriteAttributeValue("", 1077, 
#nullable restore
#line 33 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
                                                                     ViewBag.CurrentPage + 1

#line default
#line hidden
#nullable disable
            , 1077, 26, false);
            EndWriteAttribute();
            WriteLiteral(">Next</a>\r\n            </li>\r\n");
#nullable restore
#line 35 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
        }

#line default
#line hidden
#nullable disable

            WriteLiteral(@"    </ul>

    <!-- Table -->
    <div class=""table-responsive"">
        <table class=""table table-striped table-hover"">
            <thead class=""thead-dark"">
                <tr>
                    <th scope=""col"">Mã đơn hàng</th>
                    <th scope=""col"">Mã khách hàng</th>
                    <th scope=""col"">Ngày tạo đơn</th>
                    <th scope=""col"">Mã PayPal (nếu có)</th>
                    <th scope=""col"">Thao tác</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 51 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                    <tr>\r\n                        <td>");
            Write(
#nullable restore
#line 54 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
                             Html.DisplayFor(modelItem => item.Id)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                        <td>");
            Write(
#nullable restore
#line 55 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
                             Html.DisplayFor(modelItem => item.KhachHangId)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                        <td>");
            Write(
#nullable restore
#line 56 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
                             Html.DisplayFor(modelItem => item.NgayTao)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                        <td>");
            Write(
#nullable restore
#line 57 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
                             Html.DisplayFor(modelItem => item.PayPalKey)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                        <td>\r\n                            <div class=\"btn-group\" role=\"group\">\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 2210, "\"", 2277, 1);
            WriteAttributeValue("", 2217, 
#nullable restore
#line 60 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
                                          Url.Action("DonHangDetails", "Admin", new { id = item.Id })

#line default
#line hidden
#nullable disable
            , 2217, 60, false);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-primary btn-sm\">Chi tiết</a>\r\n                                <a");
            BeginWriteAttribute("href", " href=\"", 2358, "\"", 2424, 1);
            WriteAttributeValue("", 2365, 
#nullable restore
#line 61 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
                                          Url.Action("DeleteDonHang", "Admin", new { id = item.Id })

#line default
#line hidden
#nullable disable
            , 2365, 59, false);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-sm\">Xóa</a>\r\n                            </div>\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 65 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\Admin\ListDonHang.cshtml"
                }

#line default
#line hidden
#nullable disable

            WriteLiteral(@"            </tbody>
        </table>
    </div>
</div>


<style>
    .pagination .active .page-link {
        background-color: #007bff;
        border-color: #007bff;
        color: white;
    }

    .table-responsive {
        overflow-x: auto;
    }

    /* Tối ưu cho phần table và container */
    .container-fluid {
        padding: 0 15px;
    }

    table {
        width: 100%;
    }

    .table th, .table td {
        text-align: center;
        vertical-align: middle;
    }

    /* Tạo nhóm nút để canh giữa */
    .btn-group {
        display: flex;
        justify-content: center;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PPKBeverage.Models.DonHang>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
