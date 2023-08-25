<%@ Page Title="" Language="C#" MasterPageFile="~/supergrade.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <main class="main">
<div class="page-content">
<section class="intro-section">
<div class="intro-slider owl-carousel owl-theme owl-nav-arrow row animation-slider cols-1 gutter-no mb-8" data-owl-options="{
                                'nav': true,
                                'dots': false,
                                'loop': false,
                                'items': 1,
                                'responsive': {
                                    '0': {
                                        'nav': false,
                                        'autoplay': true
                                    },
                                    '768': {
                                        'nav': true
                                    }
                                }
                            }">
<div class="banner banner-fixed banner1">
<figure>
<img src="images/demos/demo1/intro/slider1.jpg" alt="banner" width="1903" height="600" style="background-color: #f8f6f6;">
</figure>
<!-- <div class="banner-content y-50 pb-1">
<h4 class="banner-subtitle title-underline2 font-weight-normal text-dim slide-animate appear-animate" data-animation-options="{
                                                'name': 'fadeInUpShorter',
                                                'delay': '.2s'
                                            }">
<span>FROM ONLINE
STORE</span></h4>
<h3 class="banner-title text-dark lh-1 mb-7 slide-animate appear-animate" data-animation-options="{
                                                'name': 'fadeInUpShorter',
                                                'delay': '.4s'
                                            }">
Panda Birthday<br>Collection</h3>
<a href="shop.html" class="btn btn-dark slide-animate appear-animate" data-animation-options="{
                                                'name': 'fadeInUpShorter',
                                                'delay': '.6s'
                                            }">SHop
now<i class="p-icon-arrow-long-right"></i></a>
</div> -->
</div>
<!--<div class="banner banner-fixed banner2">
<figure>
<img src="images/demos/demo1/intro/slider2.jpg" alt="banner" width="1903" height="600" style="background-color: #F3F2EE;">
</figure>

</div>-->
    <div class="banner banner-fixed banner2">
<figure>
<img src="images/demos/demo1/intro/slider3.jpg" alt="banner" width="1903" height="600" style="background-color: #F3F2EE;">
</figure>

</div>
    <div class="banner banner-fixed banner2">
<figure>
<img src="images/demos/demo1/intro/slider4.jpg" alt="banner" width="1903" height="600" style="background-color: #F3F2EE;">
</figure>

</div>
    <div class="banner banner-fixed banner2">
<figure>
<img src="images/demos/demo1/intro/slider5.jpg" alt="banner" width="1903" height="600" style="background-color: #F3F2EE;">
</figure>

</div>
    <div class="banner banner-fixed banner2">
<figure>
<img src="images/demos/demo1/intro/slider6.jpg" alt="banner" width="1903" height="600" style="background-color: #F3F2EE;">
</figure>

</div>
        <div class="banner banner-fixed banner2">
<figure>
<img src="images/demos/demo1/intro/slider7.jpg" alt="banner" width="1903" height="600" style="background-color: #F3F2EE;">
</figure>

</div>
</div>
<div class="container">
<div class="owl-carousel owl-theme owl-box-border row cols-md-3 cols-sm-2 cols-1 appear-animate" data-owl-options="{
                                                'nav': false,
                                                'dots': false,
                                                'loop': false,
                                                'responsive': {
                                                    '0': {
                                                        'items': 1,
                                                        'autoplay': true
                                                    },
                                                    '576': {
                                                        'items': 2,
                                                        'autoplay': true
                                                    },
                                                    '768': {
                                                        'items': 3,
                                                        'dots': false
                                                    }
                                                }
                                            }">
<div class="icon-box icon-box-side">
<span class="icon-box-icon">
<i class="p-icon-shipping-solid"></i>
</span>
<div class="icon-box-content">
<h4 class="icon-box-title">FREE SHIPPING & RETURN</h4>
<p>Free shipping on order</p>
</div>
</div>
<div class="icon-box icon-box-side">
<span class="icon-box-icon">
<i class="p-icon-quality"></i>
</span>
<div class="icon-box-content">
<h4 class="icon-box-title">QUALITY GUARANTEED</h4>
<p>We offer high quality of products</p>
</div>
</div>
<div class="icon-box icon-box-side">
<span class="icon-box-icon">
<i class="p-icon-fax2"></i>
</span>
<div class="icon-box-content">
<h4 class="icon-box-title">SECURE PAYMENT</h4>
<p>We ensure secure payment!</p>
</div>
</div>
</div>
 </div>
</section>
<section class="benefit-section appear-animate mt-5" style="background: #fafaf8;">
    <div class="container">
        <img class="food" src="images/demos/demo1/banner/cook.png">
   
    <div class="row">
       
            <div class="col-lg-6">
            <div class="pl-lg-8 pr-lg-3 pt-5 pt-lg-0">
                
            <h2 class="desc-title mb-4">Know More About us</h2>
            <p class="mb-3 ml-1">"100% pure and genuine edible oil Double filter and refined with very low cost and 100% replacement"
            
               </p>
                <p>We're committed to transparency and ethical sourcing, so you can feel good about using our products. We work with trusted suppliers who share our values and prioritize sustainability and fair trade practices. We also provide detailed information about the nutritional content and uses of each of our oils, so you can make informed choices about what you're putting into your body.</p>
            <p class="mb-8 ml-1">
                Supergrade Food ke saath banaye Swadisht aapki har recipee..... 
            </p>
            <a href="about.aspx" class="btn btn-outline btn-dark ml-1 mb-1">About US<i class="p-icon-arrow-long-right"></i></a>
            </div>
            </div>
            <div class="col-lg-6">
                
                <figure>
                <img src="images/subpage/about/about.jpg" width="610" height="450" alt="image" />
                </figure>
                </div>
    </div>
    
    </section>
<section class="container mt-10 pt-7 mb-7 appear-animate" style="background-image: url(./images/demos/demo1/banner/oil1.png);background-size: cover;background-position: center;">
<h2 class="title-underline2 text-center mb-2"><span>Top Products</span></h2>
<div class="slide-container">
    <div class="slide" data-slide-no="1"></div>
    <div class="slide" data-slide-no="2"></div>
    <div class="slide" data-slide-no="3"></div>
    <div class="slide" data-slide-no="4"></div>
    <div class="slide" data-slide-no="5"></div>
    <div class="slide" data-slide-no="6"></div>
    <div class="slide" data-slide-no="7"></div>
    <div class="slide" data-slide-no="8"></div>
    <!-- <div class="slide" data-slide-no="9"></div>
    <div class="slide" data-slide-no="10"></div>
    <div class="slide" data-slide-no="11"></div>
    <div class="slide" data-slide-no="12"></div> -->
  </div>
  <div class="button-wrap ">
    <button type="button" class="btn btn-prev">&#8592</button>
    <button type="button" class="btn btn-next">&#8594</button>
  </div>
</section>
<div class="floating-wpp"></div>


<section class="new-section container mt-10 pt-8 appear-animate">
 <h2 class="title title-underline2 justify-content-center mb-8"><span></span></h2>

<div class="row mt-10 appear-animate">
<div class="col-md-6">
<div class="banner banner-fixed banner3 mb-md-0 mb-4">
<figure>
<img src="images/demos/demo1/banner/banner2.png" alt="banner" width="610" height="250" style="background-color: #86786b;">
</figure>

</div>
</div>
<div class="col-md-6">
<div class="banner banner-fixed banner3">
<figure>
<img src="images/demos/demo1/banner/banner4.png" alt="banner" width="610" height="250" style="background-color: #ddd;">
</figure>

</div>
</div>
</div>
</section>
<div class="banner banner-fixed banner1 appear-animate mt-5">
    <figure>
    <img class="bg-oil" src="images/demos/demo1/banner/oil-drop.webp" height="500px" alt="banner" style="background: #f6f1ec;" />
    </figure>
    <div class="banner-content y-50 pb-1">
    <h3 class="banner-subtitle title-underline2 font-weight-normal text-uppercase text-dim pb-1 appear-animate" data-animation-options="{
                                                'name': 'fadeInUpShorter',
                                                'delay': '.2s'
                                            }">
    <span>100% Organic</span></h3>
    <h2 class="banner-title text-dark lh-1 mb-7 appear-animate" data-animation-options="{
                                                'name': 'fadeInUpShorter',
                                                'delay': '.4s'
                                            }">
   Get Creative in the Kitchen with Our Range of Specialty Oils</h2>
    <a href="shop.aspx" class="btn btn-dark appear-animate" data-animation-options="{
                                                'name': 'fadeInUpShorter',
                                                'delay': '.6s'
                                            }">SHop
    now<i class="p-icon-arrow-long-right"></i></a>
    </div>
    </div>
<section class="feature-section appear-animate">
<div class="container mt-10 pt-8 mb-10 pb-2">
<h2 class="title title-underline2 justify-content-center mb-8"><span>Our Featured</span>
</h2>
<div class="owl-carousel owl-theme owl-nav-arrow owl-nav-outer owl-nav-image-center row cols-lg-5 cols-md-3 cols-2" data-owl-options="{
                                            'items': 5,
                                            'nav': false,
                                            'dots': true,
                                            'margin': 20,
                                            'loop': false,
                                            'responsive': {
                                                '0': {
                                                    'items': 2
                                                },
                                                '768': {
                                                    'items': 3,
                                                    'dots': true
                                                },
                                                '992': {
                                                    'items': 5
                                                },
                                                '1400': {
                                                    'nav': true,
                                                    'dots': false
                                                }
                                            }
                                        }">
    <asp:Repeater ID="rptBestSeller" runat="server">
                        <ItemTemplate>
<div class="product shadow-media text-center">
<figure class="product-media">
<a href="product_details.aspx">
<img src='<%#Eval("pi_images").ToString().Replace("~/","") %>'  alt="product" width="250" height="300" />
<img src='<%#Eval("pi_images").ToString().Replace("~/","") %>'  width="250" height="300" />
 </a>

</figure>
<div class="product-details">
<div class="ratings-container">

</div>
<h5 class="product-name">
<a href='product_details.aspx?prd=<%#Eval("prd_id") %>'>
<%#Eval("prd_name") %></a>
</h5>
<span class="product-price">
<del class="old-price">₹ <%#Eval("prd_price") %></del>
<ins class="new-price">₹<%#Eval("prd_selling_price") %></ins>
</span>
</div>
    </div>
</ItemTemplate>
        </asp:Repeater>

</div>
</div>

</section>

</div>
<section style="background-color:#f9f8f4; padding-bottom: 2rem;padding-top: 2rem;">
  <div class="container text-center">
  <h4 class="text-uppercase text-body font-weight-normal ls-1 mb-3">Testimonial</h4>
  <h2 class="desc-title mb-4">Why You Choose US</h2>
  <div class="owl-carousel owl-theme row owl-nav-box cols-1" data-owl-options="{
                                  'items': 1,
                                  'nav': false,
                                  'dots': false,
                                  'autoplay': true,
                                  'loop': true,
                                  'margin': 20,
                                  'responsive': {
                                      '0': {
                                          'nav': false
                                      },
                                      '1600': {
                                          'nav': true
                                      }
                                  }
                              }">
  <div class="testimonial testimonial-centered with-double-quote pt-5">
      <asp:Repeater ID="rptTestimonial" runat="server">
                        <ItemTemplate>

  <blockquote>
  <figure class="testimonial-author-thumbnail">
  <img src='<%#Eval("tm_client_img").ToString().Replace("~/","") %>' alt="user" width="120" height="120" />
  </figure>
  <p>“ <%#Eval("tm_description") %>. ”</p>
  <div class="testimonial-info">
  <cite class="text-black">
  <%#Eval("tm_client_name") %>
  <span>Customer</span>
  </cite>
  </div>
  </blockquote>
                            </ItemTemplate>
                    </asp:Repeater>
  </div>
 
  </div>
  </div>
  </section> 
</main>
</asp:Content>

