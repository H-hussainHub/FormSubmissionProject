<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="housing21Project._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main class="container">

       <section class="card row bg-light">
           <article class="card-body mx-auto" style="max-width: 400px;">
	            <h4 class="card-title mt-3 text-center me-5">User Details</h4>
	            <p class="ms-5">Fill out all details to submit</p>

                <div class="form-group input-group mb-3">
		                <span class="input-group-text"><i class="fa fa-user"></i> </span>
                    <div class="form-floating">
                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Full name" type="text" required/>
                         <label for="floatingInput">Full name</label>
                        <div class="invalid-feedback">
                              Please provide your full name.
                        </div>
                    </div>
                 </div>
           

                <div class="form-group input-group mb-3">
		                <span class="input-group-text"><i class="fa fa-calendar"></i> </span>
                     <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" CssClass="form-control" type="date" required/>
                    <div class="invalid-feedback">
                          Please provide a date.
                    </div>
                 </div>

                 <div class="form-group input-group mb-3">
		                <span class="input-group-text"> <i class="fa fa-phone"></i> </span> 
                     <div class="form-floating">
                        <asp:TextBox ID="txtTelephone" runat="server" class="form-control" type="tel" pattern="^[\+]?\d{11,14}$" placeholder="Phone number" required/>          
                        <label for="floatingInput">Phone number</label>
                       <div class="invalid-feedback">
                             Please provide a valid phone number.
                        </div>
                     </div>                    
                 </div>

                <div class="form-group input-group mb-3">
		                <span class="input-group-text"> <i class="fa fa-envelope"></i> </span>
                    <div class="form-floating">
                     <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="Email address" type="email" required/>                    
                     <label for="floatingInput">Email address</label>
                      <div class="invalid-feedback">
                          Please provide a valid email address.
                      </div>
                    </div>                 
               </div>


                <div class="form-group">
                   <asp:Button ID="btnSubmit" class="btn btn-primary btn-block col-12 ms-3" runat="server" Text="Submit" onclick="btnSubmit_Click" OnClientClick="return validateForm();" />
                </div>

               <div class="form-group mt-3">
                  <asp:Label ID="lblNewId" runat="server" />
               </div>

               <div class="form-group mt-3">
                  <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label>
               </div>

          </article>
      </section> 
  
    </main>

<script>
    function validateForm() {
        var form = document.querySelector('form');
        if (!form.checkValidity()) {
            // Form is not valid
            form.classList.add('was-validated');
            return false; // Prevent postback
        }
        // Form is valid
        return true; // Allow postback
    }
</script>


</asp:Content>
