﻿<%@ Page Title="" Language="C#" MasterPageFile="~/vadmin/vadmin.master" AutoEventWireup="true" CodeFile="gallery_management.aspx.cs" Inherits="gallery_management" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
         function ShowImagePreview(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     $('#<%=img_gallery_img.ClientID%>').prop('src', e.target.result)
                         
                 };
                 reader.readAsDataURL(input.files[0]);
             }
         }
     </script>
     <link href="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.css"
        rel="stylesheet" type="text/css" />
     <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/sweetalert/1.1.0/sweetalert.min.js"></script>
          <script type="text/javascript">
              function successalert() {
                  swal({
                      title: "Success!",
                      text: "It has been succesfully Added",
                      type: "success",
                      timer: 2000,
                      showConfirmButton: false
                  }, function () {
                      window.location.href = "gallery_list.aspx";
                  });
              }
                     // function() {
                  //    window.location.href = "index.aspx";
                  //}
                    

                  //swal("Gotcha!", "Pikachu was caught!", "success");

            
   
          </script>
    <script type="text/javascript">
        function updatealert() {
            swal({
                title: "Success!",
                text: "Now,It is Updated",
                type: "success",
                timer: 2000,
                showConfirmButton: false
            }, function () {
                window.location.href = "gallery_list.aspx";
            });
        }
                     // function() {
                  //    window.location.href = "index.aspx";
                  //}


                  //swal("Gotcha!", "Pikachu was caught!", "success");



    </script>

    <script>
        function wrongalert() {
            swal({
                title: "Oops!",
                text: "It is Already Exits.", 
                type: "error",
                timer: 2500,
                showConfirmButton: false
            }, function () {
                window.location.href = "gallery_list.aspx";
            });

            //swal("Gotcha!", "Pikachu was caught!", "success");

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <style>
        .font-size-v {
    color: black;
    font-size: 20px !important;
    font-weight: 500;
}
    </style>
    
    <main>
 <div class="container mt-3">

     
         <nav class="navbar navbar-example navbar-expand-lg navbar-light bg-light">
                  <div class="container-fluid">
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbar-ex-2" aria-controls="navbar-ex-2" aria-expanded="false" aria-label="Toggle navigation">
                      <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbar-ex-2">
                      <div class="navbar-nav me-auto">
                           <a class="nav-item nav-link active font-size-v" href="javascript:void(0)">Home</a>
                        <a class="nav-item nav-link active font-size-v" href="javascript:void(0)">Category Management</a>
                       
                      </div>

                      
                    </div>
                  </div>
                </nav>
               </div>
        <div class="card mb-4 mt-3">
        <div class ="container mt-3">

        
        
             
                    
                     
                          <div class="mb-3 mt-3">
                                 <asp:HiddenField runat="server" ID="hf_gallerys_ext" />
                        <asp:HiddenField runat="server" ID="hf_gallerys_name" /> 
                            
                        <label for="formFileMultiple" class="form-label">Upload Image</label>
                        <%--<input class="form-control" type="file" id="formFileMultiple" multiple="">--%>
                   
                         <asp:FileUpload runat="server"  class="form-control"  onchange="ShowImagePreview(this);" accept=".xlsx,.xls,image/*,.doc,audio/*,.docx,video/*,.ppt,.pptx,.txt,.pdf" ID="fu_gallerys_img" AllowMultiple="True" />
                        
                              <asp:requiredfieldvalidator display="dynamic" controltovalidate="fu_gallerys_img" runat="server" id="rf_fu_gallerys_img" errormessage="please select gallery image" font-bold="true" validationgroup="save" forecolor="red"></asp:requiredfieldvalidator>
                        
                         
                          </div>
                           <div class="mb-3 ">
                                <asp:Image runat="server" ID="img_gallery_img"  class="form-control" Height="100" Width="100"  />
                          
                               </div>
                          <div class="form-check mt-3">
                               <label class="col-form-label">Status</label>
                           <%-- <input class="form-check-input" type="checkbox" value="" id="defaultCheck1">--%>

                               <asp:CheckBox ID="chkbxStatus" Checked="true" runat="server" class="form-check-input" />
                            <label class="form-check-label" for="defaultCheck1"> Active </label>
                          </div>
                          <div class="form-check mt-3">
                               <label class="col-form-label">Show On Home Page</label>
                           <%-- <input class="form-check-input" type="checkbox" value="" id="defaultCheck1">--%>

                               <asp:CheckBox ID="CheckBox1" Checked="true" runat="server" class="form-check-input" />
                            <label class="form-check-label" for="defaultCheck1"> Yes/No </label>
                          </div>
                       
<%--                        <button type="submit" class="btn btn-primary mt-3">Send</button>--%>
                               <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary mt-3" Text="Save" ValidationGroup="save" onclick="btnSave_Click"/>
           
                     
                    </div>
                 
            </div>
    </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_javascript" Runat="Server">
</asp:Content>

