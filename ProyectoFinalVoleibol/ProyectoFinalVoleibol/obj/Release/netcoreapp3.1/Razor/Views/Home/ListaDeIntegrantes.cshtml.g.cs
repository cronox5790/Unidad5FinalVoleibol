#pragma checksum "C:\Users\robca\Desktop\ProyectoFinalVoleibol\ProyectoFinalVoleibol\Views\Home\ListaDeIntegrantes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "beb1c61ad3fa076e53a9d105956c6d917e1cf296"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_ListaDeIntegrantes), @"mvc.1.0.view", @"/Views/Home/ListaDeIntegrantes.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"beb1c61ad3fa076e53a9d105956c6d917e1cf296", @"/Views/Home/ListaDeIntegrantes.cshtml")]
    public class Views_Home_ListaDeIntegrantes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ProyectoFinalVoleibol.Models.Directortecnico>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/Home/IndexAdminDt"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", new global::Microsoft.AspNetCore.Html.HtmlString("post"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("~/Home/EliminarIntegrante"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\robca\Desktop\ProyectoFinalVoleibol\ProyectoFinalVoleibol\Views\Home\ListaDeIntegrantes.cshtml"
   Layout = "_LayoutAdmin"; 

#line default
#line hidden
#nullable disable
            WriteLiteral("<main>\n    <section id=\"integrantestable\">\n        <h1>Lista de integrantes del director tecnico ");
#nullable restore
#line 5 "C:\Users\robca\Desktop\ProyectoFinalVoleibol\ProyectoFinalVoleibol\Views\Home\ListaDeIntegrantes.cshtml"
                                                 Write(Model.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "beb1c61ad3fa076e53a9d105956c6d917e1cf2964354", async() => {
                WriteLiteral("Agregar nuevo integrante");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 215, "~/Home/AgregarIntegrante/", 215, 25, true);
#nullable restore
#line 6 "C:\Users\robca\Desktop\ProyectoFinalVoleibol\ProyectoFinalVoleibol\Views\Home\ListaDeIntegrantes.cshtml"
AddHtmlAttributeValue("", 240, Model.Id, 240, 9, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        <table id=""tablas"">
            <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Posición</th>

                    <th></th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 18 "C:\Users\robca\Desktop\ProyectoFinalVoleibol\ProyectoFinalVoleibol\Views\Home\ListaDeIntegrantes.cshtml"
                 foreach (var integrantes in Model.Integrantes)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\n                    <td>");
#nullable restore
#line 21 "C:\Users\robca\Desktop\ProyectoFinalVoleibol\ProyectoFinalVoleibol\Views\Home\ListaDeIntegrantes.cshtml"
                   Write(integrantes.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n                    <td>");
#nullable restore
#line 22 "C:\Users\robca\Desktop\ProyectoFinalVoleibol\ProyectoFinalVoleibol\Views\Home\ListaDeIntegrantes.cshtml"
                   Write(integrantes.Posicion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\n\n                    <td>\n                        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "beb1c61ad3fa076e53a9d105956c6d917e1cf2967159", async() => {
                WriteLiteral("Editar");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 809, "~/Home/EditarIntegrante/", 809, 24, true);
#nullable restore
#line 25 "C:\Users\robca\Desktop\ProyectoFinalVoleibol\ProyectoFinalVoleibol\Views\Home\ListaDeIntegrantes.cshtml"
AddHtmlAttributeValue("", 833, integrantes.Id, 833, 15, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n                    </td>\n                    <td>\n                        <a href=\"#\"");
            BeginWriteAttribute("onclick", " onclick=\"", 947, "\"", 982, 3);
            WriteAttributeValue("", 957, "eliminar(", 957, 9, true);
#nullable restore
#line 28 "C:\Users\robca\Desktop\ProyectoFinalVoleibol\ProyectoFinalVoleibol\Views\Home\ListaDeIntegrantes.cshtml"
WriteAttributeValue("", 966, integrantes.Id, 966, 15, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 981, ")", 981, 1, true);
            EndWriteAttribute();
            WriteLiteral(">Eliminar</a>\n                    </td>\n                </tr>\n");
#nullable restore
#line 31 "C:\Users\robca\Desktop\ProyectoFinalVoleibol\ProyectoFinalVoleibol\Views\Home\ListaDeIntegrantes.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\n        </table>\n");
#nullable restore
#line 34 "C:\Users\robca\Desktop\ProyectoFinalVoleibol\ProyectoFinalVoleibol\Views\Home\ListaDeIntegrantes.cshtml"
         if (User.IsInRole("DirectorTecnico"))
        {

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "beb1c61ad3fa076e53a9d105956c6d917e1cf2969901", async() => {
                WriteLiteral("Cancelar");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" ");
#nullable restore
#line 36 "C:\Users\robca\Desktop\ProyectoFinalVoleibol\ProyectoFinalVoleibol\Views\Home\ListaDeIntegrantes.cshtml"
                                           }
else if (User.IsInRole("Administrador"))
{

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "beb1c61ad3fa076e53a9d105956c6d917e1cf29611248", async() => {
                WriteLiteral("Cancelar");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1239, "~/Home/ListaDeDt/", 1239, 17, true);
#nullable restore
#line 39 "C:\Users\robca\Desktop\ProyectoFinalVoleibol\ProyectoFinalVoleibol\Views\Home\ListaDeIntegrantes.cshtml"
AddHtmlAttributeValue("", 1256, Model.Id, 1256, 9, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
#nullable restore
#line 39 "C:\Users\robca\Desktop\ProyectoFinalVoleibol\ProyectoFinalVoleibol\Views\Home\ListaDeIntegrantes.cshtml"
                                                 }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </section>\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "beb1c61ad3fa076e53a9d105956c6d917e1cf29613058", async() => {
                WriteLiteral("\n        <input type=\"number\" name=\"Id\" id=\"IdIntegrante\" hidden />\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n    <script>function eliminar(id) {\n    document.getElementById(\"IdIntegrante\").value = id;\n            document.querySelector(\"form\").submit();\n        }</script>\n</main>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ProyectoFinalVoleibol.Models.Directortecnico> Html { get; private set; }
    }
}
#pragma warning restore 1591
