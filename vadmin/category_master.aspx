<%@ Page Title="" Language="C#" MasterPageFile="~/vadmin/vadmin.master" AutoEventWireup="true" CodeFile="category_master.aspx.cs" Inherits="category_master" EnableEventValidation="false" %>

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
                      window.location.href = "category_master.aspx";
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
                window.location.href = "category_master.aspx";
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
                window.location.href = "category_master.aspx";
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

        
        
             
                    
                      <form>
                        <div class="mb-3">
                          <label class="form-label" for="basic-default-fullname">Enter Category</label>
                         <%-- <input type="text" class="form-control" id="basic-default-fullname" placeholder="John Doe">--%>
                         <asp:HiddenField ID="hfCatId" runat="server"></asp:HiddenField>
                        <asp:TextBox ID="txtCategory" CssClass="form-control" Placeholder="Enter Category" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ErrorMessage="Enter Category" Display="Dynamic" Font-Bold="true" ForeColor="Red" ControlToValidate="txtCategory" ValidationGroup="save" runat="server" />
                    
                        
                        
                        </div>
                          <div class="mb-3">
                          <label for="formFile" class="form-label">Choose File</label>
                       <%-- <input class="form-control" type="file" id="formFile">--%>
                              <asp:FileUpload  onchange="ShowImagePreview(this);" CssClass="form-control" ID="fu_img" runat="server" />
                             <asp:HiddenField runat="server" ID="hf_ext" />
                                <asp:HiddenField runat="server" ID="hf_name" />
                              <asp:RequiredFieldValidator Display="Dynamic" ControlToValidate="fu_img" runat="server" ID="rf_fu_img" ErrorMessage="Please Select Image" Font-Bold="true" ValidationGroup="save" ForeColor="Red"></asp:RequiredFieldValidator>
                  
                          </div>
                           <div class="mb-3">
                                <asp:Image runat="server" ID="img_img" Height="100" width="100" />

                               </div>
                          <div class="form-check mt-3">
                               <label class="col-form-label">Status</label>
                           <%-- <input class="form-check-input" type="checkbox" value="" id="defaultCheck1">--%>

                               <asp:CheckBox ID="chkbxStatus" Checked="true" runat="server" class="form-check-input" />
                            <label class="form-check-label" for="defaultCheck1"> Active </label>
                          </div>
                       
<%--                        <button type="submit" class="btn btn-primary mt-3">Send</button>--%>
                           <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary mt-3" Text="Save" ValidationGroup="save" OnClick="btnSave_Click1" />
           
                      </form>
                    </div>
                  </div>
          
           <div class="card mt-3">
          <div class ="container mt-3">

        
        

              <div class="wrapper_all">

        
                <h5 class="card-header">Category Lists</h5>
               <div class="input-group input-group-merge">
                        <span class="input-group-text" id="basic-addon-search31"><i class="bx bx-search"></i></span>
                        <input type="text" class="form-control" placeholder="Search..." aria-label="Search..." aria-describedby="basic-addon-search31" onkeyup="FilterkeyWord_all_table()"  id="search_input_all">
                      </div>
                <div class="table-responsive text-nowrap mt-3">
                  <table class="table" id="menu_item_table_all">
                    <thead class="table-light">
                      <tr>
                        <th>No</th>
                            <th>Name</th>
                           <th>Image</th>
                            <th>Status</th>
                            <th>Action</th>
                      </tr>
                    </thead>
                    <tbody class="table-border-bottom-0">
                         <asp:Repeater ID="rptCategory" OnItemCommand="rptCategory_ItemCommand" runat="server">
                            <ItemTemplate>
                      <tr>
                        <td><i class="fab fa-angular fa-lg text-danger me-3"></i> <strong><%#Container.ItemIndex +1 %></strong></td>
                        <td><%#Eval("cat_name") %></td>
                          <td>
                                            <asp:Image runat="server" ID="img_gallery_img" Height="100" Width="100" ImageUrl='<%#Eval("cat_image")%>' /></td>
									
                       
                        <td><%#Eval("cat_status").ToString() == "1"?"Active":"Deactive" %></span></td>
                        <td><asp:LinkButton CommandName="lnkbtnEdit" CommandArgument='<%#Eval("cat_id") %>' runat="server">Edit</asp:LinkButton></td>
                                
                      </tr>
                        </ItemTemplate>
                             </asp:Repeater>
                      
                    </tbody>
                  </table>
                </div>
              </div>
                  </div>
              </div>
    </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_javascript" Runat="Server">
     
</asp:Content>

