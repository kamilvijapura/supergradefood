<%@ Page Title="" Language="C#" MasterPageFile="~/vadmin/vadmin.master" AutoEventWireup="true" CodeFile="product_management.aspx.cs" Inherits="product_management" EnableEventValidation="false" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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
                window.location.href = "product_list.aspx";
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
                title: "success!",
                text: "now,it is updated",
                type: "success",
                timer: 2000,
                showconfirmbutton: false
            }, function () {
                window.location.href = "product_list.aspx";
            });
        }
                     // function() {
                  //    window.location.href = "index.aspx";
                  //}


                  //swal("gotcha!", "pikachu was caught!", "success");

    </script>
    <script>
        function wrongalert() {
            swal({
                title: "oops!",
                text: "it is already exits.",
                type: "error",
                timer: 2500,
                showconfirmbutton: false
            }, function () {
                window.location.href = "product_list.aspx";
            });
            //swal("gotcha!", "pikachu was caught!", "success");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <main>
        <style>
            .font-size-v {
                color: black;
                font-size: 20px !important;
                font-weight: 500;
            }
        </style>


        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true"></asp:ScriptManager>

        <div class="container mt-3">
            <nav class="navbar navbar-example navbar-expand-lg navbar-light bg-light">
                <div class="container-fluid">
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbar-ex-2" aria-controls="navbar-ex-2" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbar-ex-2">
                        <div class="navbar-nav me-auto">
                            <a class="nav-item nav-link active font-size-v" href="javascript:void(0)">Home</a>
                            <a class="nav-item nav-link active font-size-v" href="javascript:void(0)">Product Management</a>
                        </div>
                    </div>
                </div>
            </nav>
        </div>
        <div class="container mt-3">
            <div class="card mb-4">
                <asp:UpdatePanel class="w-100 row" runat="server">
                    <ContentTemplate>
                        <div class="input-group">
                            <label class="input-group-text" for="inputGroupSelect01">Select Category</label>
                            <asp:DropDownList ID="drCategory" CssClass="form-select" AutoPostBack="true" OnSelectedIndexChanged="drCategory_SelectedIndexChanged" Placeholder="Enter Category" runat="server"></asp:DropDownList>
                            <asp:RequiredFieldValidator ErrorMessage="Select Category" InitialValue="0" Display="Dynamic" Font-Bold="true" ForeColor="Red" ControlToValidate="drCategory" ValidationGroup="save" runat="server" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
                <div class="mb-3">
                    <label class="form-label" for="basic-default-fullname">Name</label>
                    <asp:TextBox CssClass="form-control" ID="txtName"  runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Please Enter  Name" ControlToValidate="txtName" Display="Dynamic" Font-Bold="true" ForeColor="Red" ValidationGroup="save" runat="server" />
                </div>
                <div class="mb-3">
                    <label class="form-label" for="basic-default-fullname">Title</label>
                    <asp:TextBox CssClass="form-control" ID="txttitle" runat="server" />
                    <asp:RequiredFieldValidator ErrorMessage="Please Enter  Title" ControlToValidate="txttitle" Display="Dynamic" Font-Bold="true" ForeColor="Red" ValidationGroup="save" runat="server" />
                </div>
              
                     <div class="form-group">
                    <div class="col-lg-12">
                        <asp:Panel ID="pnlUpdate" Visible="false" runat="server">


                            <table class="table table-bordered table-hover" id="dataTable1" width="100%" cellspacing="0">
                                <thead>
                                    <tr>

                                        <th>Feature</th>
                                        <th>Description</th>
                                        <th>Action</th>
                                    </tr>
                                </thead>
                                <tbody>

                                    <asp:Repeater runat="server" ID="repProductFeature" OnItemCommand="repProductFeature_ItemCommand">
                                        <ItemTemplate>
                                            <tr>
                                            <tr>
                                                <td>
                                                    <asp:HiddenField ID="hfPfid" Value='<%#Eval("pf_id")%>' runat="server" />
                                                    <asp:TextBox runat="server" ID="txtFeature" TextMode="MultiLine" CssClass="form-control" Text='<%#Eval("pf_feature")%>'></asp:TextBox>
                                                </td>

                                                <td>
                                                    <asp:TextBox runat="server" ID="txtFeatureDes" CssClass="form-control" Text='<%#Eval("pf_des")%>'></asp:TextBox>
                                                </td>

                                                <td>

                                                    <asp:LinkButton runat="server" ID="lnk_delete" CommandArgument='<%#Eval("pf_id") %>' CssClass="btn btn-danger" CommandName="lnk_delete"><i class="fa fa-trash"></i></asp:LinkButton>
                                                </td>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>

                            </table>
                        </asp:Panel>



                        <div class="overflow-x-scroll">

                            <asp:GridView CssClass="table dt-responsive nowrap w-100 dataTable no-footer dtr-inline" ID="grdview_area_of_painting" Width="100%" runat="server" ShowFooter="true" AutoGenerateColumns="false" OnRowCreated="grdview_area_of_painting_RowCreated">
                               
                                <Columns>
                                    <asp:BoundField DataField="RowNumber" HeaderStyle-CssClass="sorting" HeaderText="No." />
                                    <asp:TemplateField HeaderStyle-CssClass="min-w-gid-th2" HeaderText="Feature">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFeature" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator Font-Bold="true" ID="rftxtFeature" runat="server" ErrorMessage="Please Fill Feature" ControlToValidate="txtFeature" ValidationGroup="add" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderStyle-CssClass="min-w-gid-th2" HeaderText="Description">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtFeatureDes" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator Font-Bold="true" ID="rftxtFeatureDes" runat="server" ErrorMessage="Please Fill Description" ControlToValidate="txtFeatureDes" ValidationGroup="add" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                   <asp:TemplateField HeaderStyle-CssClass="sorting min-w-gid-th3" HeaderText="Action">
                                        <ItemTemplate>
                                          <%--  <asp:LinkButton ID="btn_remove"  Css="btn btn-danger" runat="server" CssClass="btn-sm btn-danger" OnClick="btn_remove_Click"><i class="fa fa-trash"></i></asp:LinkButton>
                               --%>       

                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <asp:Button ID="btn_add" CssClass="btn btn-info" runat="server" Text="Add New" OnClick="btn_add_Click" ValidationGroup="add" />
                                        </FooterTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                 <asp:HiddenField ID="hfextension" runat="server" />
                    <asp:HiddenField ID="hffilenewname" runat="server" />
                    <asp:Repeater ID="rptProductImages" OnItemCommand="rptProductImages_ItemCommand" runat="server">
                        <ItemTemplate>
                            <div class="mb-3">
                                <asp:ImageButton CommandName="lnkbtnDelete" CommandArgument='<%#Eval("pi_id") %>' Width="100px" Height="100px" ImageUrl='<%#Eval("pi_images") %>' runat="server" ID="imgBtn" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div class="mb-3">
                        <label for="formFile" class="form-label">Choose File</label>
                        <asp:FileUpload runat="server" ID="fuImages" accept=".xlsx,.xls,image/*,.doc,audio/*,.docx,video/*,.ppt,.pptx,.txt,.pdf" AllowMultiple="True" />
                    </div>
                    <asp:Image runat="server" ID="img_img" Height="100" Width="100" />
                    <div class="container mb-3 d-none">
                        <div>
                            <label>Upload PDF</label>
                            <asp:FileUpload onchange="ShowImagePreview(this);" runat="server" ID="fuPDF" accept=".xlsx,.xls,image/*,.doc,audio/*,.docx,video/*,.ppt,.pptx,.txt,.pdf" AllowMultiple="True" />
                            <asp:HyperLink ID="hlPDF" runat="server" />
                        </div>
                    </div>
                   
                    <div class="mb-3">
                        <label class="form-label" for="basic-default-fullname">Selling Price</label>
                        <asp:TextBox CssClass="form-control" ID="txtSellingPrice" runat="server" TextMode="Number" />
                        <asp:RequiredFieldValidator ErrorMessage="Please Enter Selling Price" ControlToValidate="txtSellingPrice" Display="Dynamic" Font-Bold="true" ForeColor="Red" ValidationGroup="save" runat="server" />
                    </div>
                    <div class="mb-3">
                        <label class="form-label" for="basic-default-fullname">Profit Price</label>
                        <asp:TextBox CssClass="form-control" ID="txtPrice" runat="server" TextMode="Number" />
                    </div>

              <div class="mb-3">
                         <%-- <label class="form-label" for="basic-default-fullname">Dealer Price</label>
                      <asp:TextBox CssClass="form-control" ID="TextBox1" runat="server" TextMode="Number" />
                    <asp:RequiredFieldValidator ErrorMessage="Please Enter Dealer Price" ControlToValidate="TextBox1" Display="Dynamic" Font-Bold="true" ForeColor="Red" ValidationGroup="save" runat="server" />--%>
                    
                   </div>

                  
              <div class="mb-3">
                    <label class="form-label" for="basic-default-fullname">Description</label>


                    <asp:TextBox CssClass="form-control" TextMode="MultiLine" ID="txtDescription" runat="server" />
            </div>

            <div class="form-check mt-3">
                <label class="col-form-label">Status</label>
                <asp:CheckBox ID="chkbxStatus" Checked="true" runat="server" class="form-check-input" />
                <label class="form-check-label" for="defaultCheck1">Active </label>
            </div>
            <div class="form-check mt-3">
                <label class="col-form-label">Show On Home Page</label>
                <asp:CheckBox ID="CheckBox1" Checked="true" runat="server" class="form-check-input" />
                <label class="form-check-label" for="defaultCheck1">Yes/No </label>
            </div>
                
                              
            <asp:LinkButton ID="btnSave" ValidationGroup="save" CssClass="btn  btn-primary mt-3" OnClick="btnSave_Click" runat="server">Save</asp:LinkButton>
        </div>
       </div>






            
         
    </main>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_javascript" runat="Server">
</asp:Content>

