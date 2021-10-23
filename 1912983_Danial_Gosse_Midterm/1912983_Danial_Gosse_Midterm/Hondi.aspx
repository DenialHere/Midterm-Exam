<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Hondi.aspx.cs" Inherits="_1912983_Danial_Gosse_Midterm.Hondi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hondi Purchase</title>

    <style type="text/css">
        body {
            font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background-color:coral;
        }
        .center {
            text-align:center;
        }
        .auto-style1 {
            display:inline-block;
            height: 200px;
        }
        .auto-style2 {
            padding-left:500px;
            width: 250px;
        }
        .auto-style3 {
            margin-top: 5px;
            background-color:black;
            color:white;
            font-weight:bold;
            padding:5px;
            float:right;
        }
    </style>

</head>
<body>

    <h1 class="center">Hondi Build & Price</h1>

    <form id="form1" runat="server">
        
        <%-- Panel Information --%>

        <div class="auto-style1">

            <asp:Panel ID="panInfo" runat="server" GroupingText="<b>Car Information</b>" Width="500px">

                <table>

                <%-- City --%>

                <tr>
                    <td>
                        <asp:Label ID="city" runat="server" Text="Your city"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>    
                    </td>
                </tr>

                <%-- Zip Code --%>

                <tr>
                    <td>
                        <asp:Label ID="zipcode" runat="server" Text="Zip Code"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtZipCode" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <%-- Car Model --%>

                <tr>
                   <td>
                       <asp:Label ID="carModel" runat="server" Text="Select Car model"></asp:Label>
                   </td>
                   <td>
                       <asp:DropDownList ID="dropdownCarModel" runat="server" OnSelectedIndexChanged="dropdownCarModel_SelectedIndexChanged" AutoPostBack="true">
                           <asp:ListItem > Select a model</asp:ListItem>
                       </asp:DropDownList>   
                       
                   </td>
               </tr>

              <%-- Interior Color --%>

                <tr>
                   <td>
                       <asp:Label ID="carColor" runat="server" Text="Interior Color"></asp:Label>
                   </td>
                   <td>
                       <asp:ListBox ID="listBoxColor" runat="server" AutoPostBack="true" OnSelectedIndexChanged="listBoxColor_SelectedIndexChanged" Height="55px"></asp:ListBox>  
                   </td>
               </tr>

              <%-- Accessories --%>

                <tr>
                   <td>
                       <asp:Label ID="accessories" runat="server" Text="Accessories" ></asp:Label>
                   </td>
                   <td>
                       <asp:CheckBoxList ID="chkAccessories" runat="server" AutoPostBack="true" OnSelectedIndexChanged="chkAccessories_SelectedIndexChanged">
                       </asp:CheckBoxList>
                   </td>
               </tr>

               <%-- Warranty --%>

                <tr>
                   <td>
                       <asp:Label ID="warranty" runat="server" Text="Warranty"></asp:Label>
                   </td>
                   <td>
                       <asp:RadioButtonList ID="radioButtonListWarranty" runat="server" OnSelectedIndexChanged="radioButtonListWarranty_SelectedIndexChanged" AutoPostBack="true">
                       </asp:RadioButtonList>
                   </td>
               </tr>

              <%-- Dealer contact --%>

                <tr>
                   <td>
                       <asp:Label ID="Label1" runat="server" Text="Dealer contact you by phone?"></asp:Label>
                   </td>
                   <td>
                       <asp:CheckBox ID="chckDealerContact" runat="server" AutoPostBack="true" OnCheckedChanged="chckDealerContact_CheckedChanged" />
                   </td>
               </tr>

              <%-- Phone Number --%>

                <tr>
                   <td>
                       <asp:Label ID="phoneNumber" runat="server" Text="Phone Number"></asp:Label>
                   </td>
                   <td>
                       <asp:TextBox ID="txtPhoneNumber" TextMode="Phone" runat="server"></asp:TextBox>
                   </td>
               </tr>

                </table>
            </asp:Panel>
        </div>

        <%-- Panel Pricing --%>

        <div class="auto-style1">
            <asp:Panel ID="panPrice" runat="server" GroupingText="<b>Price Resume</b>" Height="200px">

                <asp:Literal ID="litCarPrice" runat="server"></asp:Literal> 
                <br />
                <asp:Literal ID="litInterior" runat="server"></asp:Literal> 
                <br />
                <asp:Literal ID="litAcessories" runat="server"></asp:Literal> 
                <br />
                <asp:Literal ID="litWarranty" runat="server"></asp:Literal> 
                <br />
                <asp:Literal ID="litTotal" runat="server"></asp:Literal> 
                <br />
                <asp:Literal ID="litTotalWithTaxes" runat="server"></asp:Literal> 
                <br />
                <asp:Button ID="btnConclude" runat="server" Text="Conclude" OnClick="btnConclude_Click" CssClass="auto-style3" />
            </asp:Panel>
        </div>

        <%-- Panel Final Information --%>

        <div class="auto-style2">
            <asp:Panel ID="panFinalInfo" runat="server" GroupingText="<b>Final Information</b>">
                <asp:Literal ID="litFirstMessage" runat="server"></asp:Literal> 
                <br />
                <br />
                <asp:Literal ID="litSecondMessage" runat="server"></asp:Literal> 
                <br />
                <br />
                <asp:Literal ID="litThirdMessage" runat="server"></asp:Literal> 
                <br />
            </asp:Panel>
        </div>


    </form>






</body>
</html>
