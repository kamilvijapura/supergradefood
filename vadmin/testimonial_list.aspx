<%@ Page Title="" Language="C#" MasterPageFile="~/vadmin/vadmin.master" AutoEventWireup="true" CodeFile="testimonial_list.aspx.cs" Inherits="testimonial_list" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
                        <a class="nav-item nav-link active font-size-v" href="javascript:void(0)">Testimonial Lists</a>
                            </div>

                      
                    </div>
                  </div>
                </nav>
               </div>
          
        <div class="container mt-3">
             


             <div class="wrapper_all">
                 <div class="card">
               
                    <a class="btn btn-primary" href="testimonial_management.aspx">Add Testimonial</a>
                    
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
                                <th>Client Image</th>
                                                <th>Client Name</th>
                                                <th>Designation</th>
                                                <th>Status</th>
                                                <th>Action</th>
                        </tr>
                      </thead>
                      <tbody>
                         <asp:Repeater runat="server" ID="rpt_testimonial_list">
                                                <ItemTemplate>
                        <tr>
                          <td>
                            <i class="fab fa-angular fa-lg text-danger me-3"></i> <strong><%#Container.ItemIndex +1 %></strong>
                          </td>
                         <td>
                                                            <asp:Image runat="server" ID="img_client_img" ImageUrl='<%#Eval("tm_client_img")%>' Height="100" Width="100" />
                                                        </td>
                                                        <td><%#Eval("tm_client_name")%></td>
                                                        <td class="fix-width"><%#Eval("tm_designation")%></td>
                                                        <td><%#Eval("tm_status").ToString() == "1" ?"Active":"Deactive"%></td>
                                                        <td>
                                                            <a href='testimonial_management.aspx?tmid=<%#Eval("tm_id")%>' class="btn btn-info mr-2"><i class="fa fa-pencil mr-2"></i>Edit</a>
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

