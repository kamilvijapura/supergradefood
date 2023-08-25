<%@ Page Title="" Language="C#" MasterPageFile="~/vadmin/vadmin.master" AutoEventWireup="true" CodeFile="product_list.aspx.cs" Inherits="product_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                window.location.href = "product_list.aspx";
            });
        }


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
                window.location.href = "product_list.aspx";
            });
        }
                     


    </script>

    <script>
        function wrongalert() {
            swal({
                title: "Delete",
                text: "It is Deleted.",
                type: "error",
                timer: 2500,
                showConfirmButton: false
            }, function () {
                window.location.href = "product_list.aspx";
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
                        <a class="nav-item nav-link active font-size-v" href="javascript:void(0)">Product Lists</a>
                            </div>

                      
                    </div>
                  </div>
                </nav>
               </div>
          
        <div class="container mt-3">
             

             <div class="wrapper_all">

                 <div class="card">
                     
               
                    <a href="product_management.aspx" class="btn btn-primary float-right" >Add Product</a>
           <div class="card-body">
                 <div class="input-group input-group-merge">
                        <span class="input-group-text" id="basic-addon-search31"><i class="bx bx-search"></i></span>
                        <input type="text" class="form-control" placeholder="Search..." aria-label="Search..." aria-describedby="basic-addon-search31" onkeyup="FilterkeyWord_all_table()"  id="search_input_all">
                      </div>
                  <div class="table-responsive text-nowrap">
                    <table class="table table-bordered mt-3" id="menu_item_table_all">
                      <thead>
                        <tr>
                            <th>No</th>
                              <th>Category</th>
                                <th> Name</th>
                          <%-- <th>Dealer price</th>--%>
                            <th>Selling price</th>
                            <th>Profit price</th>
                            
                            <th>Status</th>
                            <th>Action</th>
                        </tr>
                      </thead>
                      <tbody>
                          <asp:Repeater ID="rptProduct" OnItemCommand="rptProduct_ItemCommand" runat="server">
                            <ItemTemplate>
                        <tr>
                          <td>
                            <i class="fab fa-angular fa-lg text-danger me-3"></i> <strong><%#Container.ItemIndex +1 %></strong>
                          </td>
                         <td><%#Eval("prd_cat_id") %></td>
                                    <td><%#Eval("prd_name") %></td>
                           <%--  <td><%#Eval("prd_dealer_price") %></td>--%>
                           
                            <td><%#Eval("prd_selling_price") %></td>
                                   
                                  <td><%#Eval("prd_price") %></td>
                                   
                                    <td><%#Eval("prd_status").ToString() == "1"?"Active":"Deactive" %></td>
                                   
                                    <td><asp:LinkButton CommandName="lnkbtnEdit" CommandArgument='<%#Eval("prd_id") %>' runat="server">Edit</asp:LinkButton>
                                          <asp:LinkButton runat="server" CommandName="lnkbtnDelete" CommandArgument='<%#Eval("prd_id")%>' class="btn btn-danger mr-2"><i class="fa fa-trash mr-2"></i>Delete</asp:LinkButton>
                                    
                                    </td>
                                
                        </tr>
                       </ItemTemplate>
                            </asp:Repeater>
                      </tbody>
                    </table>
                  </div>
                </div>
              </div>
                 </div>
                 </div>
        </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_javascript" Runat="Server">
</asp:Content>

