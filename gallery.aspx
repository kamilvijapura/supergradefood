<%@ Page Title="" Language="C#" MasterPageFile="~/supergrade.master" AutoEventWireup="true" CodeFile="gallery.aspx.cs" Inherits="gallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <main class="main">
<div class="page-header pl-4 pr-4" style="background-color: #faf8f5">
<h1 class="page-title"> Gallery </h1>
</div>
<nav class="breadcrumb-nav has-border">
<div class="container">
<ul class="breadcrumb">
<li><a href="index.aspx">Home</a></li>
<li>Gallery</li>
</ul>
</div>
</nav>
<div class="page-content image-gallery-page">
<div class="container mb-6 pb-10">
<h2 class="text-center mt-10 pt-8 mb-8">    </h2>
<div class="row cols-lg-4 cols-md-3 cols-2">
     <asp:Repeater ID="rptGallery" runat="server">
                <ItemTemplate>
<figure class="mb-4">
    <a href='<%#Eval("gm_img").ToString().Replace("~/","") %>' data-fancybox="gallery" data-caption="Oil">
        <img class="oil-img" src='<%#Eval("gm_img").ToString().Replace("~/","") %>'>
          </a>
</figure>
                    
                      </ItemTemplate>
            </asp:Repeater>
            

</div>
</div>
    </div>


</main>
</asp:Content>

