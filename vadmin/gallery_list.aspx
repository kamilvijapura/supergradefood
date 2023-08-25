<%@ Page Title="" Language="C#" MasterPageFile="~/vadmin/vadmin.master" AutoEventWireup="true" CodeFile="gallery_list.aspx.cs" Inherits="gallery_list" %>

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
                title: "Delete",
                text: "It is Deleted.", 
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
                        <a class="nav-item nav-link active font-size-v" href="javascript:void(0)">Gallery Lists</a>
                            </div>

                      
                    </div>
                  </div>
                </nav>
               </div>
          
        <div class="container mt-3">
             



                 <div class="card">
               
                     <a href="gallery_management.aspx" class="btn btn-primary float-right">Add Image</a>
                <div class="card-body">
                  <div class="table-responsive text-nowrap">
                    <table class="table table-bordered">
                      <thead>
                        <tr>
                           <th>Sr No.</th>
                                <th>Image</th>
                                <th>Status</th>
                                <th>Action</th>
                        </tr>
                      </thead>
                      <tbody>
                             <asp:Repeater runat="server" ID="rpt_gallery_list" OnItemCommand="rpt_gallery_list_ItemCommand">
                                  <ItemTemplate>
                        <tr>
                          <td>
                            <i class="fab fa-angular fa-lg text-danger me-3"></i> <strong><%#Container.ItemIndex +1 %></strong>
                          </td>
                           <td>
                                            <asp:Image runat="server" ID="img_gallery_img" Height="100" Width="100" ImageUrl='<%#Eval("gm_img")%>' /></td>
                                        <td><%#Eval("gm_status").ToString() == "1" ?"Active":"Deactive"%></td>
                                        <td>
                                            <a href='gallery_management.aspx?gmid=<%#Eval("gm_id")%>' class="btn btn-info mr-2"><i class="fa fa-pencil mr-2"></i>Edit</a>
                                            <asp:LinkButton runat="server" CommandName="lnkbtnDelete" CommandArgument='<%#Eval("gm_id")%>' class="btn btn-danger mr-2"><i class="fa fa-trash mr-2"></i>Delete</asp:LinkButton>
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
          
    </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_javascript" Runat="Server">
</asp:Content>

