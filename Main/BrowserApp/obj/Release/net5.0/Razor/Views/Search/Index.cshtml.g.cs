#pragma checksum "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d1c7370c96d349b3268a4ed9c157739300eba2b8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Search_Index), @"mvc.1.0.view", @"/Views/Search/Index.cshtml")]
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
#line 1 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\_ViewImports.cshtml"
using BrowserApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\_ViewImports.cshtml"
using BrowserApp.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
using Utils.TextUtils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
using Utils.TimeSpanUtils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
using BrowserApp.Utils;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
using static BrowserApp.Utils.Constant;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d1c7370c96d349b3268a4ed9c157739300eba2b8", @"/Views/Search/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3f7464e6cd704e1debcbbc32634bbf6e2b817ed9", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Search_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<BrowserApp.Models.SearchModel<MovieModel>>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Search/Movies/"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-bottom:15px; margin-top:15px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/Search/Actors/"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin-bottom:50px; margin-top:25px;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 6 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
  
    ViewData["Title"] = "Search";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- -->
<style>
    .container {
        background: #fff;
        width: 100%;
    }

    .container .header {
        width: 100%;
        background: black;
        height: 70px;
    }

    .header h1 {
        color: #fff;
        font-size: 20px;
        line-height: 70px;
        margin: 0 20px;
    }

    .container ul {
        padding:0px;
        list-style-type: none;
        text-align: center;
    }

    .container ul li {
        padding: 20px;
        border-bottom: 1px solid #ccc;
    }

    ul li img {
        border-radius: 50%;
        width: 50px;
        height: 50px;
    }

    ul li h1 {
        margin-left: 70px;
        margin-top: -50px;
        font-size: 17px;
        font-weight: 550;
    }

    ul li p {
        margin-left: 0px;
        margin-top: 0px;
    }

    ul li:hover {
        background: gray;
    }

    .Text {
        font-family: Arial;
    }

    .Navigation {
        margin-left: auto;
        margin-ri");
            WriteLiteral(@"ght: auto;
        margin-top: 40px;
        margin-bottom: 100px;
        width: fit-content;
    }

    .ButtonNavigation {
        font-family: Arial;
        font-size: 20px;
        cursor: pointer;
        font-weight: bold;
        background: none;
        border: none;
        vertical-align: middle;
    }

    .NumberPage {
        font-family: Arial;
        font-size: 25px;
        font-weight: bold;
        vertical-align: middle;
        display: inline;
        width: fit-content;
    }


</style>
<div class=""text-center"" style=""margin-top: 55px;"">
    <div class=""container"">
        <div class=""header"">
            <h1>Keywords</h1>
        </div>
        <ul style=""text-align: center;"">
            <li>
                <p>OR = <span style=""color: brown;"">Spiderman OR StarWars</span></p>
            </li>
            <li>
                <p>AND = <span style=""color: brown;"">Harisson Ford AND Tom Holland</span></p>
            </li>
            <li>
     ");
            WriteLiteral("           <p>NOT = <span style=\"color: brown;\">NOT Spiderman</span></p>\r\n            </li>\r\n            <li>\r\n                <p>| = <span style=\"color: brown;\">Spiderman | NOT StarWars</span></p>\r\n            </li>\r\n        </ul>\r\n    </div>\r\n\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1c7370c96d349b3268a4ed9c157739300eba2b88667", async() => {
                WriteLiteral("\r\n        <input placeholder=\"Title\" id=\"Title\" type=\"text\" name=\"title\"");
                BeginWriteAttribute("value", " value=\"", 2657, "\"", 2716, 1);
#nullable restore
#line 118 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
WriteAttributeValue("", 2665, Utils.GetValue(Model.TypeSearch, Model.Search, ""), 2665, 51, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" onkeyup=\"Disable(\'Title\', \'TitleSearch\')\" /><br />\r\n        <input id=\"TitleSearch\" type=\"submit\" value=\"Search\" disabled />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <br />\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d1c7370c96d349b3268a4ed9c157739300eba2b810793", async() => {
                WriteLiteral("\r\n        <input placeholder=\"Name\'s actor\" id=\"Name\" type=\"text\" name=\"name\"");
                BeginWriteAttribute("value", " value=\"", 3026, "\"", 3085, 1);
#nullable restore
#line 123 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
WriteAttributeValue("", 3034, Utils.GetValue(Model.TypeSearch, "", Model.Search), 3034, 51, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" onkeyup=\"Disable(\'Name\', \'NameSearch\')\" /><br />\r\n        <input id=\"NameSearch\" type=\"submit\" value=\"Search\" disabled />\r\n    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
#nullable restore
#line 126 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
     if (!string.IsNullOrWhiteSpace(Model.Search))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <hr style=\"margin-bottom:25px;\" />\r\n");
#nullable restore
#line 129 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
         if (Model.TotalRecords > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <table class=""table-bordered"" style=""margin-left: auto; margin-right: auto;"">
                <thead>
                    <tr>
                        <th class=""Text"" width=""50"">Id</th>
                        <th class=""Text"" width=""150"">Poster</th>
                        <th class=""Text"" width=""175"">Title</th>
                        <th class=""Text"" width=""100"">Release date</th>
                        <th class=""Text"" width=""100"">Runtime</th>
                        <th class=""Text"" width=""100"">Rating</th>
                        <th class=""Text"" width=""125"">Rating( <img style=""vertical-align:middle;"" src=""https://raw.githubusercontent.com/Arilam8/Images/main/Images/TheMovieDBLogo.png"" height=""15"" alt=""TheMovieDB"" /> )</th>
                        <th class=""Text"" width=""200"">Overview</th>
                        <th class=""Text"" width=""100"">More information</th>
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 146 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                     foreach (MovieModel movieUiModel in Model.Datas)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <tr height=\"250\">\r\n                            <th class=\"Text\" scope=\"row\">");
#nullable restore
#line 149 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                                                    Write(movieUiModel.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral("</th>\r\n                            <td>\r\n\r\n                                <img class=\"Text\"");
            BeginWriteAttribute("src", " src=\"", 4661, "\"", 4687, 1);
#nullable restore
#line 152 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
WriteAttributeValue("", 4667, movieUiModel.Poster, 4667, 20, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" width=\"150\" alt=\"No poster found!\" onerror=\"this.src=\'https://raw.githubusercontent.com/Arilam8/Images/main/Images/PosterNotFound.png\'\" />\r\n\r\n                            </td>\r\n                            <td class=\"Text\" style=\"text-align:center;\">");
#nullable restore
#line 155 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                                                                   Write(movieUiModel.Title);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"Text\" style=\"text-align:center;\">");
#nullable restore
#line 156 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                                                                    Write((movieUiModel.ReleaseDate == (DateTime)System.Data.SqlTypes.SqlDateTime.MinValue) ? "N/A" : movieUiModel.ReleaseDate.Year);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"Text\" style=\"text-align:center;\">");
#nullable restore
#line 157 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                                                                   Write(TimeSpanUtils.GetRuntime(movieUiModel.Runtime));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"Text\" style=\"text-align:center;font-size:20px;color: orange;\">");
#nullable restore
#line 158 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                                                                                                Write(movieUiModel.RatingStar);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"Text\" style=\"text-align:center;font-size:20px;color: orange;\">");
#nullable restore
#line 159 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                                                                                                Write(movieUiModel.RatingTheMovieDBStar);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td class=\"Text\">");
#nullable restore
#line 160 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                                         Write(string.IsNullOrWhiteSpace(movieUiModel.Overview) == false ? TextUtils.GetTextMaxLength(movieUiModel.Overview, 315) : "N/A");

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                            <td style=\"text-align:center;\"><input type=\"button\" class=\"Text\" value=\"More\"");
            BeginWriteAttribute("id", " id=\"", 5849, "\"", 5870, 1);
#nullable restore
#line 161 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
WriteAttributeValue("", 5854, movieUiModel.Id, 5854, 16, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" name=\"SelectedMovie\"");
            BeginWriteAttribute("onclick", " onclick=\"", 5892, "\"", 5981, 3);
            WriteAttributeValue("", 5902, "location.href=\'", 5902, 15, true);
#nullable restore
#line 161 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
WriteAttributeValue("", 5917, Url.Action("", "FullMovie", new { idmovie = movieUiModel.Id }), 5917, 63, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5980, "\'", 5980, 1, true);
            EndWriteAttribute();
            WriteLiteral(" /></td>\r\n                        </tr>\r\n");
#nullable restore
#line 163 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr><td class=\"Text\" colspan=\"9\">");
#nullable restore
#line 164 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                                                Write(Model.TotalRecords);

#line default
#line hidden
#nullable disable
            WriteLiteral(" movies</td></tr>\r\n                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 167 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
             if (Model.TypeSearch == SEARCH_TYPE_MOVIE_TITLE)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"Navigation\">\r\n                    <div style=\"position:relative;\">\r\n");
#nullable restore
#line 171 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                         if (Model.IsFirstPage)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input type=\"button\" value=\"<<\" class=\"ButtonNavigation\"");
            BeginWriteAttribute("onclick", " onclick=\"", 6519, "\"", 6603, 3);
            WriteAttributeValue("", 6529, "location.href=\'", 6529, 15, true);
#nullable restore
#line 173 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
WriteAttributeValue("", 6544, Url.Action("Movies", new{title = Model.Search, page = 1}), 6544, 58, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 6602, "\'", 6602, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 174 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input disabled type=\"button\" value=\"<<\" class=\"ButtonNavigation\" style=\"cursor:none;\" />\r\n");
#nullable restore
#line 178 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 179 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                         if (Model.IsPreviousPage)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input type=\"button\" value=\"<\" class=\"ButtonNavigation\"");
            BeginWriteAttribute("onclick", " onclick=\"", 7001, "\"", 7104, 3);
            WriteAttributeValue("", 7011, "location.href=\'", 7011, 15, true);
#nullable restore
#line 181 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
WriteAttributeValue("", 7026, Url.Action("Movies", new{title = Model.Search, page = Model.PageNumber - 1}), 7026, 77, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7103, "\'", 7103, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 182 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input disabled type=\"button\" value=\"<\" class=\"ButtonNavigation\" style=\"cursor:none;\" />\r\n");
#nullable restore
#line 186 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h3 class=\"NumberPage\">");
#nullable restore
#line 187 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                                          Write(Model.PageNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 188 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                         if (Model.IsNextPage)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input type=\"button\" value=\">\" class=\"ButtonNavigation\"");
            BeginWriteAttribute("onclick", " onclick=\"", 7568, "\"", 7691, 3);
            WriteAttributeValue("", 7578, "location.href=\'", 7578, 15, true);
#nullable restore
#line 190 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
WriteAttributeValue("", 7593, Url.Action("Movies", new{title = Model.Search, name = Model.Search,page = Model.PageNumber + 1}), 7593, 97, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 7690, "\'", 7690, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 191 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input disabled type=\"button\" value=\">\" class=\"ButtonNavigation\" style=\"cursor:none;\" />\r\n");
#nullable restore
#line 195 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 196 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                         if (Model.IsLastPage)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input type=\"button\" value=\">>\" class=\"ButtonNavigation\"");
            BeginWriteAttribute("onclick", " onclick=\"", 8085, "\"", 8184, 3);
            WriteAttributeValue("", 8095, "location.href=\'", 8095, 15, true);
#nullable restore
#line 198 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
WriteAttributeValue("", 8110, Url.Action("Movies", new{title = Model.Search, page = Model.TotalPages}), 8110, 73, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 8183, "\'", 8183, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 199 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input disabled type=\"button\" value=\">>\" class=\"ButtonNavigation\" style=\"cursor:none;\" />\r\n");
#nullable restore
#line 203 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n");
#nullable restore
#line 206 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <div class=\"Navigation\">\r\n                    <div style=\"position:relative;\">\r\n");
#nullable restore
#line 211 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                         if (Model.IsFirstPage)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input type=\"button\" value=\"<<\" class=\"ButtonNavigation\"");
            BeginWriteAttribute("onclick", " onclick=\"", 8776, "\"", 8859, 3);
            WriteAttributeValue("", 8786, "location.href=\'", 8786, 15, true);
#nullable restore
#line 213 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
WriteAttributeValue("", 8801, Url.Action("Actors", new{name = Model.Search, page = 1}), 8801, 57, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 8858, "\'", 8858, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 214 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input disabled type=\"button\" value=\"<<\" class=\"ButtonNavigation\" style=\"cursor:none;\" />\r\n");
#nullable restore
#line 218 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 219 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                         if (Model.IsPreviousPage)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input type=\"button\" value=\"<\" class=\"ButtonNavigation\"");
            BeginWriteAttribute("onclick", " onclick=\"", 9257, "\"", 9359, 3);
            WriteAttributeValue("", 9267, "location.href=\'", 9267, 15, true);
#nullable restore
#line 221 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
WriteAttributeValue("", 9282, Url.Action("Actors", new{name = Model.Search, page = Model.PageNumber - 1}), 9282, 76, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 9358, "\'", 9358, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 222 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input disabled type=\"button\" value=\"<\" class=\"ButtonNavigation\" style=\"cursor:none;\" />\r\n");
#nullable restore
#line 226 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h3 class=\"NumberPage\">");
#nullable restore
#line 227 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                                          Write(Model.PageNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h3>\r\n");
#nullable restore
#line 228 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                         if (Model.IsNextPage)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input type=\"button\" value=\">\" class=\"ButtonNavigation\"");
            BeginWriteAttribute("onclick", " onclick=\"", 9823, "\"", 9925, 3);
            WriteAttributeValue("", 9833, "location.href=\'", 9833, 15, true);
#nullable restore
#line 230 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
WriteAttributeValue("", 9848, Url.Action("Actors", new{name = Model.Search ,page = Model.PageNumber + 1}), 9848, 76, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 9924, "\'", 9924, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 231 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input disabled type=\"button\" value=\">\" class=\"ButtonNavigation\" style=\"cursor:none;\" />\r\n");
#nullable restore
#line 235 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 236 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                         if (Model.IsLastPage)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input type=\"button\" value=\">>\" class=\"ButtonNavigation\"");
            BeginWriteAttribute("onclick", " onclick=\"", 10319, "\"", 10417, 3);
            WriteAttributeValue("", 10329, "location.href=\'", 10329, 15, true);
#nullable restore
#line 238 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
WriteAttributeValue("", 10344, Url.Action("Actors", new{name = Model.Search, page = Model.TotalPages}), 10344, 72, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 10416, "\'", 10416, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n");
#nullable restore
#line 239 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <input disabled type=\"button\" value=\">>\" class=\"ButtonNavigation\" style=\"cursor:none;\" />\r\n");
#nullable restore
#line 243 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </div>\r\n                </div>\r\n");
#nullable restore
#line 246 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 246 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
             
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"            <div style=""margin-left: auto; margin-right: auto; margin-top:auto;margin-bottom:auto;width:fit-content"">
                <div style=""position:relative"">
                    <img style=""margin-left: auto;margin-right: auto;display: block;"" src=""https://static.thenounproject.com/png/1152691-200.png"" height=""100"" />
                    <h1 class=""Text"" style=""text-align:center;font-size:30px; font-weight:bold;width:fit-content;"">No result !</h1>
                </div>
            </div>
");
#nullable restore
#line 256 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 256 "C:\Users\lambe\Desktop\Github\programmation-net-csharp-avance-2021-2022-2325-ezzayri-sami-lambert-aristide\Main\BrowserApp\Views\Search\Index.cshtml"
         
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<BrowserApp.Models.SearchModel<MovieModel>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
