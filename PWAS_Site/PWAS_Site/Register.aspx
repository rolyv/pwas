<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="PWAS_Site.Register" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
            <td width="193">
                &nbsp;
            </td>
            <td width="69">
                <div align="right">
                    First Name</div>
            </td>
            <td width="6">
                &nbsp;
            </td>
            <td width="349">
                <asp:TextBox runat="server" id="f_name" />
                <img src="images/red_asterisk.png" id="assertFName" style="visibility: visible; vertical-align:top" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <div align="right">
                    Last Name</div>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox runat="server" id="l_name" />
                <img src="images/red_asterisk.png" id="assertLName" style="visibility: visible; vertical-align:top" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <div align="right">
                    Address</div>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox runat="server" id="address" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <div align="right">
                    City</div>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox runat="server" id="city" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <div align="right">
                    State</div>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
            <asp:DropDownList runat="server" ID="state" OnSelectedIndexChanged="ddState_SelectedIndexChanged">
                    <asp:ListItem value="selected" Selected="True">State...</asp:ListItem>
                    <asp:ListItem value="AL">Alabama</asp:ListItem>
                    <asp:ListItem value="AK">Alaska</asp:ListItem>
                    <asp:ListItem value="AZ">Arizona</asp:ListItem>
                    <asp:ListItem value="AR">Arkansas</asp:ListItem>
                    <asp:ListItem value="CA">California</asp:ListItem>
                    <asp:ListItem value="CO">Colorado</asp:ListItem>
                    <asp:ListItem value="CT">Connecticut</asp:ListItem>
                    <asp:ListItem value="DE">Delaware</asp:ListItem>
                    <asp:ListItem value="FL">Florida</asp:ListItem>
                    <asp:ListItem value="GA">Georgia</asp:ListItem>
                    <asp:ListItem value="HI">Hawaii</asp:ListItem>
                    <asp:ListItem value="ID">Idaho</asp:ListItem>
                    <asp:ListItem value="IL">Illinois</asp:ListItem>
                    <asp:ListItem value="IN">Indiana</asp:ListItem>
                    <asp:ListItem value="IA">Iowa</asp:ListItem>
                    <asp:ListItem value="KS">Kansas</asp:ListItem>
                    <asp:ListItem value="KY">Kentucky</asp:ListItem>
                    <asp:ListItem value="LA">Louisiana</asp:ListItem>
                    <asp:ListItem value="ME">Maine</asp:ListItem>
                    <asp:ListItem value="MD">Maryland</asp:ListItem>
                    <asp:ListItem value="MA">Massachusetts</asp:ListItem>
                    <asp:ListItem value="MI">Michigan</asp:ListItem>
                    <asp:ListItem value="MN">Minnesota</asp:ListItem>
                    <asp:ListItem value="MS">Mississippi</asp:ListItem>
                    <asp:ListItem value="MO">Missouri</asp:ListItem>
                    <asp:ListItem value="MT">Montana</asp:ListItem>
                    <asp:ListItem value="NE">Nebraska</asp:ListItem>
                    <asp:ListItem value="NV">Nevada</asp:ListItem>
                    <asp:ListItem value="NH">New Hampshire</asp:ListItem>
                    <asp:ListItem value="NJ">New Jersey</asp:ListItem>
                    <asp:ListItem value="NM">New Mexico</asp:ListItem>
                    <asp:ListItem value="NY">New York</asp:ListItem>
                    <asp:ListItem value="NC">North Carolina</asp:ListItem>
                    <asp:ListItem value="ND">North Dakota</asp:ListItem>
                    <asp:ListItem value="OH">Ohio</asp:ListItem>
                    <asp:ListItem value="OK">Oklahoma</asp:ListItem>
                    <asp:ListItem value="OR">Oregon</asp:ListItem>
                    <asp:ListItem value="PA">Pennsylvania</asp:ListItem>
                    <asp:ListItem value="RI">Rhode Island</asp:ListItem>
                    <asp:ListItem value="SC">South Carolina</asp:ListItem>
                    <asp:ListItem value="SD">South Dakota</asp:ListItem>
                    <asp:ListItem value="TN">Tennessee</asp:ListItem>
                    <asp:ListItem value="TX">Texas</asp:ListItem>
                    <asp:ListItem value="UT">Utah</asp:ListItem>
                    <asp:ListItem value="VT">Vermont</asp:ListItem>
                    <asp:ListItem value="VA">Virginia</asp:ListItem>
                    <asp:ListItem value="WA">Washington</asp:ListItem>
                    <asp:ListItem value="WV">West Virginia</asp:ListItem>
                    <asp:ListItem value="WI">Wisconsin</asp:ListItem>
                    <asp:ListItem value="WY">Wyoming</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <div align="right">
                    Zip Code</div>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox runat="server" id="zip_code" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <div align="right">
                    Phone Number</div>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox runat="server" id="phone" />
                <img src="images/red_asterisk.png" id="assertPhone" style="visibility: visible; vertical-align:top" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <div align="right">
                    Fax Number</div>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox runat="server" id="fax" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <div align="right">
                    Notes</div>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox runat="server" TextMode="MultiLine" id="notes" Columns="30" Rows="7" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <div align="right">
                    E-Mail</div>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox runat="server"  id="a_email" />
                <img src="images/red_asterisk.png" id="assertEmail" style="visibility: visible; vertical-align:top" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <div align="right">
                    Password</div>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:TextBox runat="server" TextMode="Password" id="password" />
                <img src="images/red_asterisk.png" id="assertPassword" style="visibility: visible; vertical-align:top" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                <div align="right">
                    Repeat Password</div>
            </td>
            <td>
            </td>
            <td>
                <asp:TextBox runat="server" TextMode="Password" id="re_password" />
                <img src="images/red_asterisk.png" id="assertRePassword" style="visibility: visible; vertical-align:top" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
            <td>
                <img src="images/cannotSubmit.png" id="cannotSubmit" style="visibility: hidden" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
            </td>
            <td>
                <asp:Button runat="server" ID="btnRegister" Text="Register" OnClick="btnRegister_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
