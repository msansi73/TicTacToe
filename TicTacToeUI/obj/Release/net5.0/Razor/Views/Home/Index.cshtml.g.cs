#pragma checksum "C:\Users\giorg\Desktop\ServerTris\Soluzione\TicTacToeApp\TicTacToeUI\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d978f47afdbd17cd16af687ee13a128f17fef523"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "C:\Users\giorg\Desktop\ServerTris\Soluzione\TicTacToeApp\TicTacToeUI\Views\_ViewImports.cshtml"
using TicTacToeUI;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\giorg\Desktop\ServerTris\Soluzione\TicTacToeApp\TicTacToeUI\Views\_ViewImports.cshtml"
using TicTacToeUI.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\giorg\Desktop\ServerTris\Soluzione\TicTacToeApp\TicTacToeUI\Views\_ViewImports.cshtml"
using TicTacToeDataAccessLibrary.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d978f47afdbd17cd16af687ee13a128f17fef523", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b1c82bb5ac71219da1737fed70291d34d2b53e8f", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\giorg\Desktop\ServerTris\Soluzione\TicTacToeApp\TicTacToeUI\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""text-center"">
    <h1 class=""display-4"">Benvenuto!</h1>
    <p>Divertiti giocando a <strong>TRIS</strong> online con i tuoi amici!</p>
</div>
<h2>Per iniziare...</h2>
<ul>
    <li>Prima di tutto accedi, o registrati se non lo hai ancora fatto cliccando rispettivamente ""<strong>Accedi</strong>"" o ""<strong>Registrati</strong>"" nel menu!</li>
    <li>Clicca sul pulsante ""<strong>Lobby</strong>"".</li>
    <li>
        Fai click su ""<strong>Crea una nuova stanza</strong>"", per averne una tutta tua.
        Potrai fare la prima mossa, ma dovrai attendere che un altro utente,
        si connetta.
    </li>
    <li>Se non vuoi aspettare clicca il punstante ""<strong>Accedi</strong>"" in una stanza tra quelle in matchmaking che puoi venere nell'apposita <strong>tabella</strong>.</li>
    <li>Ultimo per importanza: <strong>Divertiti!</strong></li>
    <li>Dopo aver vinto, guarda la tua posizione in classifica facendo click sul pulsante ""<strong>Leaderboard</strong>""nel menu.</li>
    <li><st");
            WriteLiteral("rong>Pro Tip</strong>: Se utilizzi pi?? browser puoi giocare anche da solo e <strong>ACCUMULARE PUNTI</strong>! ma non dirlo in giro...</li>\r\n</ul>");
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
