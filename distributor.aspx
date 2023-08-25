<%@ Page Title="" Language="C#" MasterPageFile="~/supergrade.master" AutoEventWireup="true" CodeFile="distributor.aspx.cs" Inherits="distributor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="page-header" style="background-color: #f9f8f4">
<h1 class="page-title font-weight-light text-capitalize pt-2">Distributorship</h1>
</div>
<nav class="breadcrumb-nav has-border">
<div class="container">
<ul class="breadcrumb">
<li><a href="index.html">Home</a></li>
<li>Distributorship</li>
</ul>
</div>
</nav>

    <section class="mt-10 pt-2 mb-10 pb-8">
        <div class="container">
<div class="row align-items-center">

<div class="col-md-12 pl-md-4 mt-8 mt-md-0">

<form action="#">
<div class="row">
<div class="col-md-6 mb-4">
<input type="text" id="comment-name" name="comment-name" placeholder="Your Name" required>
</div>
<div class="col-md-6 mb-4">
<input type="email" id="comment-email" name="comment-email" placeholder="Your Email" required>
</div>
<div class="col-6 mb-4">
<input type="number" id="comment-number" name="comment-number" placeholder="Your Number" required>
</div>
    <div class="col-6 mb-4">
<input type="text" id="comment-cname" name="comment-cname" placeholder="Your Company Name" required>
</div>
<div class="col-12 mb-4">
<textarea id="comment-message" placeholder="Your Message" required rows="10"></textarea>
</div>
</div>
<button type="submit" class="btn btn-dark">Send Message</button>    
</form>
</div>
</div>
            </div>
</section>
</asp:Content>

