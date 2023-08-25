<%@ Page Title="" Language="C#" MasterPageFile="~/supergrade.master" AutoEventWireup="true" CodeFile="contact.aspx.cs" Inherits="contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css"
        rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
    <script type="text/javascript">
        function successalert() {
            swal({
                title: "Success!",
                text: "It has been succesfully Added your Contact",
                type: "success",
                timer: 3000,
                showConfirmButton: false
            }, function () {
                window.location.href = "contact.aspx";
            });
        }



    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main class="main">
        <div class="page-header" style="background-color: #f9f8f4">
            <h1 class="page-title font-weight-light text-capitalize pt-2">Contact Us</h1>
        </div>
        <nav class="breadcrumb-nav has-border">
            <div class="container">
                <ul class="breadcrumb">
                    <li><a href="index.aspx">Home</a></li>
                    <li>Contact Us</li>
                </ul>
            </div>
        </nav>
        <div class="page-content contact-page">
            <div class="container">
                <section class="mt-10 pt-8">
                    <h2 class="title title-center mb-8">Contact Information</h2>
                    <div class="owl-carousel owl-theme row cols-lg-4 cols-md-3 cols-sm-2 cols-1 mb-10" data-owl-options="{
                                'nav': false,
                                'dots': false,
                                'loop': false,
                                'margin': 20,
                                'autoplay': true,
                                'responsive': {
                                    '0': {
                                        'items': 1,
                                        'autoplay': true
                                    },
                                    '576': {
                                        'items': 2
                                    },
                                    '768': {
                                        'items': 3
                                    },
                                    '992': {
                                        'items': 4,
                                        'autoplay': false
                                    }
                                }
                            }">
                        <div class="icon-box text-center">
                            <span class="icon-box-icon mb-4">
                                <i class="p-icon-map"></i>
                            </span>
                            <div class="icon-box-content">
                                <h4 class="icon-box-title">Address</h4>
                                <p class="text-dim">SUPERONE OIL MILL,
Himatnagar - Vijapur Highway,
Himatnagar, Gujarat</p>
                            </div>
                        </div>
                        <div class="icon-box text-center">
                            <span class="icon-box-icon mb-4">
                                <i class="p-icon-phone-solid"></i>
                            </span>
                            <div class="icon-box-content">
                                <h4 class="icon-box-title">Phone Number</h4>
                                <p class="text-dim">+91 72658 02892</p>
                            </div>
                        </div>
                        <div class="icon-box text-center">
                            <span class="icon-box-icon mb-4">
                                <i class="p-icon-message"></i>
                            </span>
                            <div class="icon-box-content">
                                <h4 class="icon-box-title">E-mail Address</h4>
                                <p class="text-dim"><a href="mailto:info@supergradefood.in" class="__cf_email__" data-cfemail="573a363e3b17322f363a273b327934383a">info@supergradefood.in</a></p>
                            </div>
                        </div>
                        <div class="icon-box text-center">
                            <span class="icon-box-icon mb-4">
                                <i class="p-icon-clock"></i>
                            </span>
                            <div class="icon-box-content">
                                <h4 class="icon-box-title">Opening Hours</h4>
                                <p class="text-dim">Mon-Sat: 10:00 - 8:00<p>
                            </div>
                        </div>
                    </div>
                    <hr>
                </section>
                <section class="mt-10 pt-2 mb-10 pb-8" runat="Server">
                    <div class="row align-items-center">
                        <div class="col-md-6">
                            <figure>
                                <img src="images/subpage/contact/contact.gif" width="600" height="557" alt="About Image" />
                            </figure>
                        </div>
                        <div class="col-md-6 pl-md-4 mt-8 mt-md-0">
                            <h2 class="title mb-1">Leave a Comment</h2>
                            <p class="mb-6">
                                Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod.
                            </p>
                            <form id="frm" runat="server">
    

                            <div class="row">
                                <div class="col-md-6 mb-4">

                                    <asp:TextBox CssClass="comment-name" placeholder="Name" ID="txtFirstName" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfTxtFirstName" runat="server" ErrorMessage="Please Enter First Name" ControlToValidate="txtFirstName" ValidationGroup="save" Display="None"></asp:RequiredFieldValidator>


                                </div>
                                <div class="col-md-6 mb-4">

                                    <asp:TextBox CssClass="comment-email" placeholder="Email" ID="txtEmail" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfTxtEmail" runat="server" ErrorMessage="Please Enter Email" ControlToValidate="txtEmail" ValidationGroup="save" Display="None"></asp:RequiredFieldValidator>


                                </div>
                                <div class="col-12 mb-4">
                                    <asp:TextBox CssClass="comment-subject" placeholder="Mobile Number" TextMode="Number" ID="txtCtn" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfTxtCtn" runat="server" ErrorMessage="Please Enter Contact Number" ControlToValidate="txtCtn" ValidationGroup="save" Display="None"></asp:RequiredFieldValidator>


                                </div>
                                <div class="col-12 mb-4">

                                    <asp:TextBox TextMode="MultiLine" CssClass="comment-message" placeholder="Message" ID="txtMsg" Columns="40" Rows="10" runat="server" />
                                    <asp:RequiredFieldValidator ID="rfTxtMsg" runat="server" ErrorMessage="Please Enter Messege" ControlToValidate="txtMsg" ValidationGroup="save" Display="None"></asp:RequiredFieldValidator>

                                </div>
                            </div>
                            
                            <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="True" ShowSummary="False" ValidationGroup="save" runat="server" />
                            <asp:LinkButton Text="Send Message" ValidationGroup="save" CssClass="btn btn-dark" ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" />
                                    </form>

                        </div>
                    </div>
                </section>
            </div>
            <div class="new-map">
                <div class="container">
                    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3655.92552674123!2d72.90591987425384!3d23.60700369426837!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x395db9c35b6778d1%3A0x243ecd8a4ca80ce0!2sSUPERONE%20OIL%20MILL!5e0!3m2!1sen!2sin!4v1683626438980!5m2!1sen!2sin" width="100%" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                </div>
            </div>
        </div>
    </main>
</asp:Content>

