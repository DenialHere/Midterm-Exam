using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _1912983_Danial_Gosse_Midterm
{
    public partial class Hondi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                //Adding dropdown options *CAR MODEL*
                dropdownCarModel.Items.Add(new ListItem("DRV (+30 000)", "30000"));
                dropdownCarModel.Items.Add(new ListItem("RBV (+25 000)", "25000"));
                dropdownCarModel.Items.Add(new ListItem("TZM (+40 000)", "40000"));

                //Adding listbox options *INTERIOR COLOR*
                listBoxColor.Items.Add(new ListItem("White (Free)", "0"));
                listBoxColor.Items.Add(new ListItem("Dark (+ 300$)", "300"));
                listBoxColor.Items.Add(new ListItem("Pearl (+ 900$)", "900"));

                chkAccessories.Items.Add(new ListItem("Aero Kit (+ 1300$)", "1300"));
                chkAccessories.Items.Add(new ListItem("Film (+ 600$)", "600"));
                chkAccessories.Items.Add(new ListItem("Cold Weather (+ 900$)", "900"));
                chkAccessories.Items.Add(new ListItem("Hondi Emblem (+ 150$)", "150"));
                chkAccessories.Items.Add(new ListItem("Snow Tire Package (+ 1800$)", "1800"));


                //Adding Radio button options *WARRANTY*
                radioButtonListWarranty.Items.Add(new ListItem("3 years (Included)", "0"));
                radioButtonListWarranty.Items.Add(new ListItem("5 years (+ 1000$)", "1000"));
                radioButtonListWarranty.Items.Add(new ListItem("7 years (+ 1500$)", "1500"));

                //Hiding Elements
                phoneNumber.Visible = false;
                txtPhoneNumber.Visible = false;
                panPrice.Visible = false;
                panFinalInfo.Visible = false;

                //Default selection
                listBoxColor.SelectedIndex = 0;
                radioButtonListWarranty.SelectedIndex = 0;
            }
        }

        protected void chckDealerContact_CheckedChanged(object sender, EventArgs e)
        {
            //Hiding phone number input if contact by phone is not checked
            if (chckDealerContact.Checked)
            {
                phoneNumber.Visible = true;
                txtPhoneNumber.Visible = true;
            }
            else 
            {
                phoneNumber.Visible = false;
                txtPhoneNumber.Visible = false;
            }
        }

        protected void dropdownCarModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        protected void listBoxColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        protected void radioButtonListWarranty_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        public void CalculatePrice()
        {
            //Whenever we need to recalculate the price hide the final pane;
            panFinalInfo.Visible = false;

            //Defining variables for calculation of price
            int carModel, intColor, acc, warranty;
            double total, totalWithTaxes;

            //If a car model is selected
            if (dropdownCarModel.SelectedIndex > 0)
            {
                //Converting and setting prices got from inputs
                carModel = Convert.ToInt32(dropdownCarModel.SelectedValue);
                intColor = Convert.ToInt32(listBoxColor.SelectedItem.Value);
                acc = 0;
                warranty = 0;

                //Show panel pric resume
                panPrice.Visible = true;

                //Showing the text with inputted values
                litCarPrice.Text = "Car price: " + "<b>$" + dropdownCarModel.SelectedValue + "</b>";
                litInterior.Text = "Interior Color: " + "<b>$"  + listBoxColor.SelectedItem.Value + "</b>";

                //Adding each of the optional accessories to our variable
                foreach (ListItem item in chkAccessories.Items)
                {
                    if (item.Selected) 
                    {
                        acc += Convert.ToInt32(item.Value);
                    }
                }

                //Checking which option is selected in radio button and setting our variable to it
                foreach (ListItem item in radioButtonListWarranty.Items)
                {
                    if (item.Selected)
                    {
                        warranty = Convert.ToInt32(item.Value);
                    }
                }
                //Showing the text with inputted values
                litAcessories.Text = "Accessories: " + "<b>$" + acc.ToString() + "</b>";
                litWarranty.Text = "Warranty: " + "<b>$" + warranty.ToString() + "</b>";

                //Calculating totals
                total = carModel + intColor + acc + warranty;
                totalWithTaxes = total * 1.15;

                //Showing the text with inputted values
                litTotal.Text = "Total without taxes: " +"<b>$" + total.ToString() + "</b>";
                litTotalWithTaxes.Text = "Total with taxes (15%): " + "<b>$" + totalWithTaxes.ToString() + "</b>";

            }
            //If a car model is not chosen hide panel Price Resume
            else
            {
                panPrice.Visible = false;
            }
        }

        protected void chkAccessories_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculatePrice();
        }

        protected void btnConclude_Click(object sender, EventArgs e)
        {
            //Showing final information Panel
            panFinalInfo.Visible = true;
            //Defining a regex pattern to remove the content in ()
            var regexPattern = @"\((.*?)\)";

            //Using the regex to remove the () from the input values
            string carmodel = Regex.Replace(dropdownCarModel.SelectedItem.Text , regexPattern, string.Empty);
            string interiorColor = Regex.Replace(listBoxColor.SelectedItem.Text, regexPattern, string.Empty);
            string warranty = Regex.Replace(radioButtonListWarranty.SelectedItem.Text, regexPattern, string.Empty);

            //Setting accessories as empty since its an optional parameter
            string accessories = "";

            //Checking which items have been chosen from the checkbox
            foreach (ListItem item in chkAccessories.Items)
            {
                if (item.Selected)
                {
                    if (accessories != "") 
                    {
                        accessories += ", ";
                    }
                    accessories += Regex.Replace(item.Text, regexPattern, string.Empty);

                }
            }

            //If no item is chosen change the text that will be displayed to reflect that
            if (accessories == "") { accessories = "and no "; }

            //Setting the final messages
            litFirstMessage.Text = "Congratulations in obtaining your new Hondi " + carmodel  + " in " + txtCity.Text + " " + txtZipCode.Text + ".";
            litSecondMessage.Text = "Your car comes with " + interiorColor + " Interior Color," + " " + accessories + "accessories.";

            //If phone number is not checked then show a different messgae
            if (chckDealerContact.Checked)
            {
                litThirdMessage.Text = "You chose " + warranty + " of warranty and a dealer will contact you by the phone number " + txtPhoneNumber.Text + ".";
            }
            else 
            {
                litThirdMessage.Text = "You chose " + warranty + " of warranty.";
            }
        }

    }
   
}