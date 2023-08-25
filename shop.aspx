<%@ Page Title="" Language="C#" MasterPageFile="~/supergrade.master" AutoEventWireup="true" CodeFile="shop.aspx.cs" Inherits="shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <main class="main">
<div class="page-header cph-header pl-4 pr-4" style="background-color: #fff7ec">
<h1 class="page-title font-weight-light text-capitalize">Shop</h1>
<div class="category-container row justify-content-center cols-2 cols-xs-3 cols-sm-4 cols-md-6 pt-6 new-shop">
<div class="category category-ellipse mb-4 mb-md-0">
<a href="#">
<figure>
<img src="images/products/sunflower.png" alt="category" width="160" height="161">
</figure>
</a>
<div class="category-content">
<h3 class="category-name"><a href="#">Sunflower</a>
</h3>
</div>
</div>
<div class="category category-ellipse mb-4 mb-md-0">
<a href="#">
<figure>
<img src="images/products/soya.png" alt="category" width="160" height="161">
</figure>
</a>
<div class="category-content">
<h3 class="category-name"><a href="#">Soya</a>
</h3>
</div>
</div>
<div class="category category-ellipse mb-4 mb-md-0">
<a href="#">
<figure>
<img src="images/products/seasame.png" alt="category" width="160" height="161">
</figure>
</a>
<div class="category-content">
<h3 class="category-name"><a href="#">Seasame</a>
</h3>
</div>
</div>
<div class="category category-ellipse">
<a href="#">
<figure>
<img src="images/products/sarso.png" alt="category" width="160" height="161">
</figure>
</a>
<div class="category-content">
<h3 class="category-name"><a href="#">Sarso</a>
</h3>
</div>
</div>
<div class="category category-ellipse">
<a href="#">
<figure>
<img src="images/products/groundnut.png" alt="category" width="160" height="161">
</figure>
</a>
<div class="category-content">
<h3 class="category-name"><a href="#">Groundnut</a>
</h3>
</div>
</div>
<div class="category category-ellipse">
<a href="#">
<figure>
<img src="images/products/cottonseeds.png" alt="category" width="160" height="161">
</figure>
</a>
<div class="category-content">
<h3 class="category-name"><a href="#">Cootonseeds</a>
</h3>
</div>
</div>
</div>
</div>
<nav class="breadcrumb-nav has-border">
<div class="container">
<ul class="breadcrumb">
<li><a href="index.aspx">Home</a></li>
<li>Shop</li>
</ul>
</div>
 </nav>
<div class="page-content mb-10 shop-page">
<div class="container">
<div class="row main-content-wrap">
<aside class="col-lg-3 sidebar widget-sidebar sidebar-fixed sidebar-toggle-remain shop-sidebar sticky-sidebar-wrapper">
<div class="sidebar-overlay"></div>
<a class="sidebar-close" href="#"><i class="p-icon-times"></i></a>
<div class="sidebar-content">
<div class="sticky-sidebar pt-7" data-sticky-options="{'top': 10}">
<%--<div class="widget widget-collapsible">
<h3 class="widget-title title-underline"><span class="title-text">filter by
price</span></h3>
<div class="widget-body">
<form action="#" class="pt-2">
<div class="filter-price-slider"></div>
<div class="filter-actions">
<button type="submit" class="btn btn-dim btn-filter">filter</button>
</div>
</form>
</div>
</div>--%>
<div class="widget widget-collapsible">
<h3 class="widget-title title-underline"><span class="title-text">Category</span></h3>
<%--<ul class="widget-body filter-items">
      <asp:Repeater ID="rptCategory" runat="server">
                                        <ItemTemplate>
                                            <li>
<a href='shop.aspx?cat=<%#Eval("cat_id") %>'><%#Eval("cat_name") %></a>
                                                </li>
      </ItemTemplate>
                                    </asp:Repeater>

</ul>--%>
</div>
<!-- <div class="widget widget-collapsible">
<h3 class="widget-title title-underline"><span class="title-text">brand</span>
</h3>
<ul class="widget-body filter-items">
<li><a href="#">nestle</a></li>
<li><a href="#">nescafe</a></li>
<li><a href="#">tropicana</a></li>
<li><a href="#">coca cola</a></li>
<li><a href="#">benecol</a></li>
<li><a href="#">alpro</a></li>
</ul>
</div>
<div class="widget widget-collapsible">
<h3 class="widget-title title-underline"><span class="title-text">filter by
rating</span></h3>
<div class="widget-body">
<ul class="rating-group filter-items">
<li class="ratings-container">
<div class="ratings-full">
<span class="ratings" style="width:100%"></span>
 <span class="tooltiptext tooltip-top"></span>
</div>
<a href="#" class="rating-reviews hash-scroll">22</a>
</li>
<li class="ratings-container">
<div class="ratings-full">
<span class="ratings" style="width:80%"></span>
<span class="tooltiptext tooltip-top"></span>
</div>
<a href="#" class="rating-reviews hash-scroll">15</a>
</li>
<li class="ratings-container">
<div class="ratings-full">
<span class="ratings" style="width:60%"></span>
<span class="tooltiptext tooltip-top"></span>
</div>
<a href="#" class="rating-reviews hash-scroll">18</a>
</li>
<li class="ratings-container">
<div class="ratings-full">
<span class="ratings" style="width:40%"></span>
<span class="tooltiptext tooltip-top"></span>
</div>
<a href="#" class="rating-reviews hash-scroll">0</a>
</li>
<li class="ratings-container">
<div class="ratings-full">
<span class="ratings" style="width:20%"></span>
<span class="tooltiptext tooltip-top"></span>
</div>
<a href="#" class="rating-reviews hash-scroll">0</a>
</li>
</ul>
</div>
</div>
<div class="widget widget-collapsible">
<h3 class="widget-title title-underline"><span class="title-text">product
tags</span></h3>
<div class="widget-body mt-1">
<a href="#" class="tag">
organic
</a>
<a href="#" class="tag">
greenhouse
</a>
<a href="#" class="tag">
fat
</a>
<a href="#" class="tag">
healthy
</a>
<a href="#" class="tag">
dairy
</a>
<a href="#" class="tag">
 vitamin
</a>
<a href="#" class="tag">
diet
</a>
<a href="#" class="tag">
nutrition
</a>
<a href="#" class="tag">
cholesterol
</a>
</div>
</div> -->
</div>
</div>
</aside>

<div class="col-lg-9 main-content pl-lg-6">
<nav class="toolbox sticky-toolbox sticky-content fix-top">
<div class="toolbox-left">
<a href="#" class="toolbox-item left-sidebar-toggle btn btn-outline btn-primary btn-icon-right d-lg-none"><span>Filter</span><i class="p-icon-category-1 ml-md-1"></i></a>
<%--<div class="toolbox-item toolbox-sort select-menu">
<label>Sort By :</label>
<select name="orderby">
<option value="default" selected="selected">Default Sorting</option>
<option value="popularity">Sort By Popularity</option>
<option value="rating">Sort By The Latest</option>
<option value="date">Sort By Average Rating</option>
<option value="price-low">Sort By Price: Low To High</option>
<option value="price-high">Sort By Price: High To Low</option>
</select>
</div>--%>
</div>
<div class="toolbox-right">
<div class="toolbox-item toolbox-show select-box">
<label>Show :</label>
<select name="count">
<option>
<asp:Label runat="server" ID="lblProductCount">10000 </asp:Label>
    </option>
</select>
</div>
<div class="toolbox-item toolbox-layout">
<a href="shop.aspx" class="p-icon-list btn-layout active"></a>
<a href="shop.aspx" class="p-icon-grid btn-layout"></a>
</div>
</div>
</nav>
<div class="row product-wrapper cols-lg-3 cols-2">
    <asp:Repeater ID="rptProduct" runat="server">
                            <ItemTemplate>
<div class="product-wrap">
<div class="product shadow-media text-center">
<figure class="product-media">
<a href='Product_details.aspx?prd=<%#Eval("prd_id") %>'>
<img src='<%#Eval("pi_images").ToString().Replace("~/","") %>'  alt="product" width="250" height="300" />
<img src='<%#Eval("pi_images").ToString().Replace("~/","") %>'  width="250" height="300" />
 </a>

</figure>
<div class="product-details">
<div class="ratings-container">

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
<!-- <nav class="toolbox toolbox-pagination pt-2 pb-6">
<p class="toolbox-item show-info">Showing <span>1-6 of 30</span> Products
</p>
<ul class="pagination">
<li class="page-item disabled">
<a class="page-link page-link-prev" href="#" aria-label="Previous" tabindex="-1" aria-disabled="true">
<i class="p-icon-angle-left"></i>
</a>
</li>
<li class="page-item active" aria-current="page"><a class="page-link" href="#">1</a>
</li>
<li class="page-item"><a class="page-link" href="#">2</a></li>
<li class="page-item page-item-dots"></li>
<li class="page-item"><a class="page-link" href="#">5</a></li>
<li class="page-item">
<a class="page-link page-link-next" href="#" aria-label="Next">
<i class="p-icon-angle-right"></i>
</a>
</li>
</ul>
</nav> -->
</div>
</div>
</div>
</div>

</main>
</asp:Content>

