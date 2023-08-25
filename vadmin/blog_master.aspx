<%@ Page Title="" Language="C#" MasterPageFile="~/vadmin/vadmin.master" AutoEventWireup="true" CodeFile="blog_master.aspx.cs" Inherits="blog_master" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <script type="text/javascript">
         function ShowImagePreview(input) {
             if (input.files && input.files[0]) {
                 var reader = new FileReader();
                 reader.onload = function (e) {
                     $('#<%=img_img.ClientID%>').prop('src', e.target.result)
                         .width(100)
                         .height(100);
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
                      window.location.href = "blog_list.aspx";
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
                window.location.href = "blog_master.aspx";
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
                window.location.href = "blog_master.aspx";
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
                        <a class="nav-item nav-link active font-size-v" href="javascript:void(0)">Blog Management</a>
                       
                      </div>

                      
                    </div>
                  </div>
                </nav>
               </div>
         <div class="card mb-4 mt-3">
        <div class ="container mt-3">

        
       
             
                    
                      <form>
                           <asp:HiddenField runat="server" ID="hfblogId" />
                        <asp:HiddenField runat="server" ID="hfRedirect" />
                        <div class="mb-3">
                          <label class="form-label" for="basic-default-fullname">Name</label>
                         <%-- <input type="text" class="form-control" id="basic-default-fullname" placeholder="John Doe">--%>
                            
                        <asp:TextBox ID="txtCategory" CssClass="form-control" Placeholder="Enter Name" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ErrorMessage=" Please Enter Name" Display="Dynamic" Font-Bold="true" ForeColor="Red" ControlToValidate="txtCategory" ValidationGroup="save" runat="server" />
                    
                        
                        
                        </div>
                             <div class="mb-3">
                        <label>Content</label>
                         <asp:TextBox CssClass="form-control" TextMode="MultiLine" ID="txtDescription" runat="server" /> </div>
                    <div class="mb-3">
                        <label>Client</label>
                        <asp:TextBox ID="txt_author" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ErrorMessage="This Field is Mandatory" Display="Dynamic" ForeColor="Red" Font-Bold="true" ControlToValidate="txt_author" ValidationGroup="save" runat="server" />
                    </div>
                      <div class="mb-3">
                        <label>Date</label>
                        <asp:TextBox ID="txt_date" CssClass="form-control" runat="server" TextMode="Date"></asp:TextBox>
                    </div>
                          <div class="mb-3">
                          <label for="formFile" class="form-label">Choose File</label>
                       <%-- <input class="form-control" type="file" id="formFile">--%>
                              <asp:FileUpload   onchange="ShowImagePreview(this);" CssClass="form-control" ID="fu_img" runat="server" />
                             <asp:HiddenField runat="server" ID="hf_ext" />
                                <asp:HiddenField runat="server" ID="hf_name" />
                              <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="fu_img" runat="server" ID="rf_fu_img" ErrorMessage="Please Select Image" Font-Bold="true" ValidationGroup="save" ForeColor="Red"></asp:RequiredFieldValidator>
                  
                          </div>
                           <div class="mb-3">
                                <asp:Image runat="server" ID="img_img" Height="100" Width="100" />

                               </div>
                          <div class="form-check mt-3">
                               <label class="col-form-label">Status</label>
                           <%-- <input class="form-check-input" type="checkbox" value="" id="defaultCheck1">--%>

                               <asp:CheckBox ID="chkbxStatus" Checked="true" runat="server" class="form-check-input" />
                            <label class="form-check-label" for="defaultCheck1"> Active </label>
                          </div>
                       
<%--                        <button type="submit" class="btn btn-primary mt-3">Send</button>--%>
                           <asp:LinkButton ID="btnSave" ValidationGroup="save" CssClass="btn  btn-primary mt-3" OnClick="btnSave_Click" runat="server">Save</asp:LinkButton>

                      </form>
                    </div>
                  </div>
           
    </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_javascript" Runat="Server">
     

</asp:Content>

