#pragma checksum "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "8cd588d2d5a0ef82b8ca9d17b1f7006983bf42d55e6f124d96fc00e8569b3902"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_GioHang_ListCarts), @"mvc.1.0.view", @"/Views/GioHang/ListCarts.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"8cd588d2d5a0ef82b8ca9d17b1f7006983bf42d55e6f124d96fc00e8569b3902", @"/Views/GioHang/ListCarts.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"Sha256", @"6c328286c99cfdf6687849731f1d1bb0c56295f3e50ad8ca5904f32cf841e868", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_GioHang_ListCarts : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<PPKBeverage.Models.GioHang>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
  
    ViewData["Title"] = "Danh sách đơn hàng";
    Layout = "_NewLayout";
    ViewData["ShowFooter"] = true;

#line default
#line hidden
#nullable disable

            WriteLiteral("\r\n<div class=\"container mt-5\">\r\n    <h1 class=\"text-center my-4\">CHÀO MỪNG ");
            Write(
#nullable restore
#line 10 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                                            ViewData["FullName"]

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@" ĐẾN VỚI TRANG GIỎ HÀNG</h1>
    <div class=""cart-table"">
        <table class=""table table-hover"">
            <thead class=""thead-light"">
                <tr>
                    <th>Ảnh</th>
                    <th>Tên cà phê</th>
                    <th>Size</th>
                    <th>Giá tiền</th>
                    <th>Số lượng</th>
                    <th>Tổng tiền</th>
                    <th>Hành động</th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 25 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
#nullable disable

            WriteLiteral("                    <tr data-item-id=\"");
            Write(
#nullable restore
#line 27 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                                       item.Id

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\">\r\n                        <td><img width=\"100px\"");
            BeginWriteAttribute("src", " src=\"", 925, "\"", 970, 1);
            WriteAttributeValue("", 931, 
#nullable restore
#line 28 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                                                     Html.DisplayFor(modelItem => item.Anh)

#line default
#line hidden
#nullable disable
            , 931, 39, false);
            EndWriteAttribute();
            WriteLiteral(" class=\"img-fluid rounded shadow-sm\" /></td>\r\n                        <td>");
            Write(
#nullable restore
#line 29 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                             Html.DisplayFor(modelItem => item.Ten)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                        <td>");
            Write(
#nullable restore
#line 30 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                             Html.DisplayFor(modelItem => item.TenSize)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                        <td class=\"price\">");
            Write(
#nullable restore
#line 31 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                                           Html.DisplayFor(modelItem => item.Tien)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"</td>
                        <td>
                            <div class=""quantity-controls"">
                                <button class=""btn btn-outline-secondary adjust-quantity"" data-action=""decrease"">-</button>
                                <input type=""text"" class=""form-control quantity-input""");
            BeginWriteAttribute("value", " value=\"", 1560, "\"", 1581, 1);
            WriteAttributeValue("", 1568, 
#nullable restore
#line 35 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                                                                                               item.SoLuong

#line default
#line hidden
#nullable disable
            , 1568, 13, false);
            EndWriteAttribute();
            WriteLiteral(" readonly />\r\n                                <button class=\"btn btn-outline-secondary adjust-quantity\" data-action=\"increase\">+</button>\r\n                            </div>\r\n                        </td>\r\n                        <td class=\"total\">");
            Write(
#nullable restore
#line 39 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                                           Html.DisplayFor(modelItem => item.TongTien)

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                        <td>\r\n                            ");
            Write(
#nullable restore
#line 41 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                             Html.ActionLink("Xóa", "Delete", new { id = item.Id }, new { @class = "btn btn-danger btn-sm delete-item" })

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 44 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                }

#line default
#line hidden
#nullable disable

            WriteLiteral("                <tr class=\"summary\">\r\n                    <td colspan=\"3\"><strong>Số lượng sản phẩm:</strong> ");
            Write(
#nullable restore
#line 46 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                                                                         ViewBag.CountProduct

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                    <td colspan=\"2\"><strong>Thành tiền:</strong> ");
            Write(
#nullable restore
#line 47 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                                                                  ViewBag.Total

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("</td>\r\n                    <td colspan=\"3\">\r\n                        <div class=\"btn-group\">\r\n                            ");
            Write(
#nullable restore
#line 50 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                             Html.ActionLink("Thanh toán tại chỗ", "Order", "GioHang", null, new { @class = "btn btn-warning btn-sm" })

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                            ");
            Write(
#nullable restore
#line 51 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                             Html.ActionLink("Thanh toán PayPal", "ThanhToanPayPal", "GioHang", null, new { @class = "btn btn-primary btn-sm" })

#line default
#line hidden
#nullable disable
            );
            WriteLiteral("\r\n                            ");
            Write(
#nullable restore
#line 52 "D:\2151050338_LuuVanPhuc_DoAnNganh\PPKBeverage\PPKBeverage\Views\GioHang\ListCarts.cshtml"
                             Html.ActionLink("Quay lại", "ListBeverage", "KhachHang", null, new { @class = "btn btn-info btn-sm" })

#line default
#line hidden
#nullable disable
            );
            WriteLiteral(@"
                        </div>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <!-- Scroll to Top Button -->
    <button id=""scrollToTop"" class=""scroll-to-top"">
        <i class=""fas fa-arrow-up""></i>
    </button>

</div>


<script>
    document.addEventListener(""DOMContentLoaded"", function () {
        const quantityControls = document.querySelectorAll("".quantity-controls"");
        quantityControls.forEach(control => {
            const decreaseButton = control.querySelector(""[data-action='decrease']"");
            const increaseButton = control.querySelector(""[data-action='increase']"");
            const quantityInput = control.querySelector("".quantity-input"");
            const row = control.closest(""tr"");
            const priceElement = row.querySelector("".price"");
            const totalElement = row.querySelector("".total"");

            decreaseButton.addEventListener(""click"", () => {
                let quantity = parse");
            WriteLiteral(@"Int(quantityInput.value);
                if (quantity > 1) {
                    quantity--;
                    updateQuantity(row, quantity);
                }
            });

            increaseButton.addEventListener(""click"", () => {
                let quantity = parseInt(quantityInput.value);
                quantity++;
                updateQuantity(row, quantity);
            });

            function updateQuantity(row, quantity) {
                quantityInput.value = quantity;

                const price = parseFloat(priceElement.textContent.replace(/[^0-9.-]+/g, """"));
                const total = price * quantity;
                totalElement.textContent = total.toFixed(2);

                updateOverallTotal();

                const itemId = row.getAttribute(""data-item-id"");
                const requestData = {
                    itemId: parseInt(itemId),
                    quantity: parseInt(quantity),
                };

                fetch('/GioHang/Updat");
            WriteLiteral(@"eQuantityAsync', {
                    method: 'POST',
                    headers: {
                        'Content-Type': 'application/json'
                    },
                    body: JSON.stringify(requestData)
                })
                    .then(response => response.json())
                    .then(data => {
                        if (data.success) {
                            console.log('Quantity updated successfully');
                        } else {
                            console.error('Failed to update quantity:', data.message);
                        }
                    })
                    .catch(error => console.error('Fetch error:', error));
            }

            function updateOverallTotal() {
                let overallTotal = 0;
                let overallQuantity = 0;

                document.querySelectorAll(""tbody tr"").forEach(row => {
                    const totalElement = row.querySelector("".total"");
                    const ");
            WriteLiteral(@"quantityInput = row.querySelector("".quantity-input"");

                    if (totalElement && quantityInput) {
                        overallTotal += parseFloat(totalElement.textContent.replace(/[^0-9.-]+/g, """"));
                        overallQuantity += parseInt(quantityInput.value);
                    }
                });

                document.querySelector("".summary"").querySelector(""td:nth-child(1)"").innerHTML = `<strong>Số lượng sản phẩm: </strong> ${overallQuantity}`;
                document.querySelector("".summary"").querySelector(""td:nth-child(2)"").innerHTML = `<strong>Thành tiền: </strong> ${overallTotal.toFixed(2)}`;
            }
        });

        // Additional JavaScript for buttons, confirmation, and scroll to top

        // Hover effects for buttons
        const buttons = document.querySelectorAll("".btn"");
        buttons.forEach(button => {
            button.addEventListener(""mouseenter"", () => {
                button.style.transform = ""scale(1.05)"";
        ");
            WriteLiteral(@"        button.style.boxShadow = ""0 6px 12px rgba(0, 0, 0, 0.2)"";
            });

            button.addEventListener(""mouseleave"", () => {
                button.style.transform = ""scale(1)"";
                button.style.boxShadow = ""none"";
            });
        });

        // Confirmation before deleting an item
        const deleteButtons = document.querySelectorAll("".delete-item"");
        deleteButtons.forEach(button => {
            button.addEventListener(""click"", function (event) {
                if (!confirm(""Bạn có chắc chắn muốn xóa sản phẩm này khỏi giỏ hàng?"")) {
                    event.preventDefault();
                }
            });
        });

        // Smooth scroll to top
        document.querySelector(""#scrollToTop"").addEventListener(""click"", function () {
            window.scrollTo({
                top: 0,
                behavior: ""smooth""
            });
        });
    });

</script>

<style>

    body {
        background-color: #f8f9fa;
");
            WriteLiteral(@"        color: #343a40;
        font-family: 'Roboto', sans-serif;
    }

    .container {
        padding: 30px;
        border-radius: 10px;
        box-shadow: 0 4px 12px rgba(0, 0, 0, 0.1);
    }

    h1 {
        color: #343a40;
        font-size: 2rem;
        text-transform: uppercase;
        letter-spacing: 2px;
        font-weight: 700;
    }

    .table {
        width: 100%;
        margin-bottom: 1rem;
        background-color: #fff;
    }
    /* Scroll to Top Button */
    .scroll-to-top {
        position: fixed;
        bottom: 20px;
        right: 20px;
        background-color: #3498db;
        color: #fff;
        border: none;
        border-radius: 50%;
        width: 50px;
        height: 50px;
        display: flex;
        align-items: center;
        justify-content: center;
        box-shadow: 0 4px 8px rgba(0, 0, 0, 0.3);
        cursor: pointer;
        transition: background-color 0.3s ease, transform 0.3s ease;
        z-index:2000;
    }");
            WriteLiteral(@"

        .scroll-to-top:hover {
            background-color: #2980b9;
            transform: scale(1.1);
        }

        .scroll-to-top i {
            font-size: 24px;
        }

    .thead-light th {
        background-color: #e9ecef;
        color: #495057;
        text-transform: uppercase;
        font-size: 0.9rem;
        letter-spacing: 1px;
        padding: 15px;
        font-weight: 500;
    }

    .table-hover tbody tr:hover {
        background-color: #f1f3f5;
    }

    td, th {
        vertical-align: middle;
        text-align: center;
        padding: 15px;
    }

    .quantity-controls {
        display: flex;
        align-items: center;
        justify-content: center;
    }

        .quantity-controls .btn {
            margin: 0;
            padding: 5px 10px;
            font-size: 1rem;
        }

    .quantity-input {
        width: 60px;
        text-align: center;
        border: 1px solid #ced4da;
        border-radius: 4px;
      ");
            WriteLiteral(@"  padding: 5px;
        margin: 0 5px;
    }

    .btn-group {
        display: flex;
        justify-content: space-around;
        margin-top: 20px;
    }

    .btn {
        margin: 5px;
        padding: 10px 20px;
        font-size: 1rem;
        text-transform: uppercase;
        letter-spacing: 1px;
        transition: all 0.3s ease;
        border-radius: 5px;
        display: flex;
        align-items: center;
        justify-content: center;
        font-weight: 600;
        color: #fff;
        border: none;
    }

    .btn-warning {
        background-color: #f39c12;
        border-color: #f39c12;
    }

    .btn-primary {
        background-color: #2980b9;
        border-color: #2980b9;
    }

    .btn-info {
        background-color: #3498db;
        border-color: #3498db;
    }

    .btn-warning:hover {
        background-color: #e67e22;
        box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2);
        transform: scale(1.05);
    }

    .btn-primary:hover ");
            WriteLiteral(@"{
        background-color: #1c5987;
        box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2);
        transform: scale(1.05);
    }

    .btn-info:hover {
        background-color: #2980b9;
        box-shadow: 0 6px 12px rgba(0, 0, 0, 0.2);
        transform: scale(1.05);
    }

    .btn::before {
        font-family: 'Font Awesome 5 Free';
        font-weight: 900;
        margin-right: 8px;
    }

    .btn-warning::before {
        content: ""\f07a""; /* FontAwesome icon for shopping bag */
    }

    .btn-primary::before {
        content: ""\f154""; /* FontAwesome icon for credit card */
    }

    .btn-info::before {
        content: ""\f021""; /* FontAwesome icon for arrow-circle-left */
    }
    /* Add icons to the buttons */

    img {
        border-radius: 8px;
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<PPKBeverage.Models.GioHang>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
