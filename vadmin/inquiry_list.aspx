<%@ Page Title="" Language="C#" MasterPageFile="~/vadmin/vadmin.master" AutoEventWireup="true" CodeFile="inquiry_list.aspx.cs" Inherits="inquiry_list" %>

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
                        <a class="nav-item nav-link active font-size-v" href="javascript:void(0)">Inquiry Lists</a>
                            </div>

                      
                    </div>
                  </div>
                </nav>
               </div>
          
        <div class="container mt-3">
             

            <div class="wrapper_all">

                 <div class="card">
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
                                <th>Name</th>
                                <th>Email</th>
                                <th>Contact</th>
                                <th>Message</th>
                                
                        </tr>
                      </thead>
                      <tbody>
                          <asp:Repeater runat="server" ID="rptInquiryDetails" >
                                                <ItemTemplate>
                        <tr>
                          <td>
                            <i class="fab fa-angular fa-lg text-danger me-3"></i> <strong><%#Container.ItemIndex +1 %></strong>
                          </td>
                          <td><%#Eval("inquiry_first_name") %></td>
                                        <td><%#Eval("inquiry_email") %></td>
                                          <td><%#Eval("inquiry_ctn") %></td>
                                          <td><%#Eval("inquiry_msg") %></td>

                                      
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

