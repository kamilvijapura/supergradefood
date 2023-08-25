<%@ Page Title="" Language="C#" MasterPageFile="~/vadmin/vadmin.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <main>
        <div class="card mt-3">
        <div class="container mt-3">
            <div class="row">
                <div class="col-lg-6">
                    <div class="card-body">
                      <h5 class="card-title">Category</h5>
                      <p class="card-text">Total Numbers Of Category Are &#8628</p>
                      <a href="javascript:void(0)" class="btn btn-primary"><asp:Label ID="Label1" runat="server" ></asp:Label></a>
                    </div>
                </div>
                <div class="col-lg-6">
                    <div class="card-body">
                      <h5 class="card-title">Products</h5>
                      <p class="card-text">Total Numbers Of Products Are &#8628</p>
                      <a href="javascript:void(0)" class="btn btn-primary"><asp:Label ID="Label2" runat="server" ></asp:Label></a>
                    </div>      
                </div>
            </div>
 
            </div>
            </div>
        <div class="card mt-3">
        <div class="container mt-3">
            <div class="row">
                  <div class="col-lg-6">
                    <div class="card-body">
                      <h5 class="card-title">Inquiry</h5>
                      <p class="card-text">Total Numbers Of Inquiry Are &#8628</p>
                      <a href="javascript:void(0)" class="btn btn-primary"><asp:Label ID="Label5" runat="server" ></asp:Label></a>
                    </div>
                </div>
                <%--<div class="col-lg-6">
                    <div class="card-body">
                      <h5 class="card-title">Blog</h5>
                      <p class="card-text">Total Numbers Of Blog Are &#8628</p>
                      <a href="javascript:void(0)" class="btn btn-primary"><asp:Label ID="Label3" runat="server" ></asp:Label></a>
                    </div>
                </div>--%>
                <div class="col-lg-6">
                    <div class="card-body">
                      <h5 class="card-title">Testimonial</h5>
                      <p class="card-text">Total Numbers Of Testimonial Are &#8628</p>
                      <a href="javascript:void(0)" class="btn btn-primary"><asp:Label ID="Label4" runat="server" ></asp:Label></a>
                    </div>      
                </div>
            </div>
 
            </div>
            </div>
       <%-- <div class="card mt-3">
        <div class="container mt-3">
            <div class="row">
              
               <div class="col-lg-6">
                    <div class="card-body">
                      <h5 class="card-title">Review</h5>
                      <p class="card-text">Total Numbers Of Reviews Are &#8628</p>
                      <a href="javascript:void(0)" class="btn btn-primary"><asp:Label ID="Label6" runat="server" ></asp:Label></a>
                    </div>
                </div>
            </div>
 
            </div>
            </div>--%>
         <div class="card mt-3">
        <div class="container mt-3">
            <div class="row">
                <div class="col-lg-6">
                    <div class="card-body">
                      <h5 class="card-title">Gallery List</h5>
                      <p class="card-text">Total Numbers Of gallery Images Are &#8628</p>
                      <a href="javascript:void(0)" class="btn btn-primary"><asp:Label ID="Label7" runat="server" ></asp:Label></a>
                    </div>
                </div>
             
            </div>
            </div>
             </div>
    </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_javascript" Runat="Server">
</asp:Content>

