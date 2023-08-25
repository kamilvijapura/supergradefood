<%@ Page Title="" Language="C#" MasterPageFile="~/supergrade.master" AutoEventWireup="true" CodeFile="product_details.aspx.cs" Inherits="product_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <main class="main single-product">
    <div class="page-header" style="background-color: #f9f8f4">
        <h1 class="page-title">Product Details</h1>
        </div>
        
<nav class="breadcrumb-nav">
<div class="container">
<div class="product-navigation">
<ul class="breadcrumb">
<li><a href="index.aspx">Home</a></li>
<li><a href="shop.aspx">Products</a></li>
<li>Default</li>
</ul>
<div class="product-image-nav">
<a href="#" class="product-nav product-nav-prev">

<i class="p-icon-arrow-long-left"></i>
</a>
<a href="#" class="product-nav product-nav-next">

<i class="p-icon-arrow-long-right"></i>
</a>
</div>
</div>
</div>
</nav>
<div class="page-content">
<div class="container">
<div class="product product-single product-simple row mb-8">
<div class="col-md-7">
<div class="product-gallery">
    
<div class="product-single-carousel owl-carousel owl-theme owl-nav-inner row cols-1 gutter-no">
    <asp:Repeater ID="rptPrdImages" runat="server">
                                <ItemTemplate>
<figure class="product-image">
    <img src='<%#Eval("pi_images").ToString().Replace("~/","") %>' data-zoom-image='<%#Eval("pi_images").ToString().Replace("~/","") %>' alt="1" width="800" height="1000"> 
</figure>

         </ItemTemplate>
                            </asp:Repeater>

</div>

                                           
</div>
</div>
<div class="col-md-5">
<div class="product-details">
<h1 class="product-name"><asp:Label ID="lblName" runat="server" /></h1>
<div class="ratings-container">
<div class="ratings-full">
<span class="ratings" style="width:60%"></span>
<span class="tooltiptext tooltip-top"></span>
</div>
<a href="#content-reviews" class="link-to-tab rating-reviews">( 12 Customer
Reviews )</a>
</div>
<p class="product-price mb-1">
<del class="old-price"> <asp:Label ID="lblPrice" runat="server" /></del>
<ins class="new-price"> <asp:Label ID="lbldealer" runat="server" /></ins>
</p>
<p class="product-short-desc" <asp:Label ID="lbltitle" runat="server" />
</p>




<hr class="product-divider">
<div class="product-meta">


<label class="social-label">share:</label>
<div class="social-links">
<a href="#" class="social-link fab fa-facebook-f"></a>
<a href="#" class="social-link fab fa-twitter"></a>
<a href="#" class="social-link fab fa-whatsapp" style="font-weight:bold;"></a>
<a href="#" class="social-link fab fa-linkedin-in"></a>
</div>
</div>
</div>
</div>
</div>
<div class="product-content">
<div class="content-description">
<h2 class="title title-line title-underline mb-lg-8">
<span>
Description
</span>
</h2>
<h3 class="content-title">

</h3>
<p class="mb-4 mb-lg-8"><asp:Label ID="lblDes" runat="server" />
</p>
<div class="row">


</div>

</div>
<div class="content-specification mt-10 pt-3">
<h2 class="title title-line title-underline">
<span>
Specifications
</span>
</h2>
<ul class="list-none">
      <asp:Repeater ID="rptFeature" runat="server">
                                    <ItemTemplate>

<li><label><%#Eval("pf_feature") %></label>
<p><%#Eval("pf_des") %></p>
</li>
       </ItemTemplate>
                                </asp:Repeater>
</ul>
</div>

</div>
</div>
</div>
<div class="container">

<section class="mt-8 mb-9">
<h2 class="text-center mb-6">Related Products</h2>
<div class="owl-carousel owl-theme row cols-lg-4 cols-md-3 cols-2" data-owl-options="{
                                                            'nav': false,
                                                            'dots': false,
                                                            'margin': 20,
                                                            'autoplay': false,
                                                            'autoplayTimeout': 5000,
                                                            'responsive': {
                                                                '0': {
                                                                    'items': 2,
                                                                    'autoplay': true
                                                                },
                                                                '768': {
                                                                    'items': 3,
                                                                    'nav': false,
                                                                    'autoplay': true
                                                                },
                                                                '992': {
                                                                    'items': 4
                                                                }
                                                            }
                                                   }">
     <asp:Repeater ID="rptBestSeller" runat="server">
                            <ItemTemplate>     
<div class="product-wrap">
<div class="product shadow-media text-center">
<figure class="product-media">
<a href="#">
<img src='<%#Eval("pi_images").ToString().Replace("~/","") %>'  alt="product" width="250" height="300" />
<img src='<%#Eval("pi_images").ToString().Replace("~/","") %>'  width="250" height="300" />
 </a>

</figure>
<div class="product-details">
<div class="ratings-container">
<div class="ratings-full">
<span class="ratings" style="width:60%"></span>
<span class="tooltiptext tooltip-top"></span>
</div>
<a href='Product-details.aspx?prd=<%#Eval("prd_id") %>' class="rating-reviews">(12)</a>
</div>
<h5 class="product-name">
<a href='Product_details.aspx?prd=<%#Eval("prd_id") %>'>
<%#Eval("prd_name") %></a>
</h5>
<span class="product-price">
<del class="old-price">₹ <%#Eval("prd_price") %></del>
<ins class="new-price">₹<%#Eval("prd_selling_price") %></ins>
</span>
</div>
</div>

</div>
                                </ItemTemplate>
                        </asp:Repeater>
</div>

</section>
</div>
</main>
</asp:Content>

