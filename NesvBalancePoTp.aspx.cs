using System;
using System.Web.UI.WebControls;

namespace Sbyt
{
    public partial class NesvBalancePoTp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            testLabel.Text = "Список ТП Несвижского РЭС";
            testLabel1.Text = "Выберите месяц и год для отчета или интервал отчетного периода (не более 12-ти месяцев): ";
            FromLbl.Text = "с:";
            ToLbl.Text = "по:";
            SearchTP.DataBind();

            if (!Page.IsPostBack)
            {
                Session.Clear();

                #region VisibleControl


                MonthDropdwn1.Visible = false;
                MonthDropdwn2.Visible = false;

                MonthDropdwn3.Visible = false;

                MonthDropdwn4.Visible = false;

                MonthDropdwn5.Visible = false;
                MonthDropdwn6.Visible = false;
                MonthDropdwn7.Visible = false;
                MonthDropdwn8.Visible = false;
                MonthDropdwn9.Visible = false;
                MonthDropdwn10.Visible = false;
                MonthDropdwn11.Visible = false;

                YearDropDwn1.Visible = false;
                YearDropDwn2.Visible = false;
                YearDropDwn3.Visible = false;

                YearDropDwn4.Visible = false;

                YearDropDwn5.Visible = false;
                YearDropDwn6.Visible = false;
                YearDropDwn7.Visible = false;
                YearDropDwn8.Visible = false;
                YearDropDwn9.Visible = false;
                YearDropDwn10.Visible = false;
                YearDropDwn11.Visible = false;
                SearchTP.Visible = false;
                #endregion

            }



        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            ListTPs.Visible = false;
            SearchTP.Visible = true;
        }

        protected void NextYearVisible(object sender, EventArgs e)
        {


            //  Session.Add("MonthYear", MonthDropdwn.SelectedValue + "_" + YearDropDwn.SelectedValue);

            Session.Add("Year1", YearDropDwn.SelectedItem);

            MonthDropdwn1.Visible = true;
            YearDropDwn1.Visible = true;

        }

        protected void NextYearVisible1(object sender, EventArgs e)
        {
            Session.Add("Year2", YearDropDwn1.SelectedItem);

            MonthDropdwn2.Visible = true;
            YearDropDwn2.Visible = true;

        }

        protected void NextYearVisible2(object sender, EventArgs e)
        {
            Session.Add("Year3", YearDropDwn2.SelectedItem);

            MonthDropdwn3.Visible = true;
            YearDropDwn3.Visible = true;

        }

        protected void NextYearVisible3(object sender, EventArgs e)
        {
            Session.Add("Year4", YearDropDwn3.SelectedItem);

            MonthDropdwn4.Visible = true;
            YearDropDwn4.Visible = true;

        }

        protected void NextYearVisible4(object sender, EventArgs e)
        {
            Session.Add("Year5", YearDropDwn4.SelectedItem);

             MonthDropdwn5.Visible = true;
             YearDropDwn5.Visible = true;

        }

        protected void NextYearVisible5(object sender, EventArgs e)
        {
            Session.Add("Year6", YearDropDwn5.SelectedItem);

            MonthDropdwn6.Visible = true;
            YearDropDwn6.Visible = true;

        }

        protected void NextYearVisible6(object sender, EventArgs e)
        {
            Session.Add("Year7", YearDropDwn6.SelectedItem);

            MonthDropdwn7.Visible = true;
            YearDropDwn7.Visible = true;

        }

        protected void NextYearVisible7(object sender, EventArgs e)
        {
            Session.Add("Year8", YearDropDwn7.SelectedItem);

            MonthDropdwn8.Visible = true;
            YearDropDwn8.Visible = true;

        }

        protected void NextYearVisible8(object sender, EventArgs e)
        {
            Session.Add("Year9", YearDropDwn8.SelectedItem);

            MonthDropdwn9.Visible = true;
            YearDropDwn9.Visible = true;

        }

        protected void NextYearVisible9(object sender, EventArgs e)
        {
            Session.Add("Year10", YearDropDwn9.SelectedItem);

            MonthDropdwn10.Visible = true;
            YearDropDwn10.Visible = true;

        }

        protected void NextYearVisible10(object sender, EventArgs e)
        {
            Session.Add("Year11", YearDropDwn10.SelectedItem);

            MonthDropdwn11.Visible = true;
            YearDropDwn11.Visible = true;

        }

        protected void NextYearVisible11(object sender, EventArgs e)
        {
            Session.Add("Year12", YearDropDwn11.SelectedItem);

        }


        protected void NextMonthSession(object sender, EventArgs e)
        {


            Session.Add("Month1", MonthDropdwn.SelectedValue);




        }

        protected void NextMonthSession1(object sender, EventArgs e)
        {


            Session.Add("Month2", MonthDropdwn1.SelectedValue);



        }

        protected void NextMonthSession2(object sender, EventArgs e)
        {


            Session.Add("Month3", MonthDropdwn2.SelectedValue);



        }

        protected void NextMonthSession3(object sender, EventArgs e)
        {


            Session.Add("Month4", MonthDropdwn3.SelectedValue);



        }

        protected void NextMonthSession4(object sender, EventArgs e)
        {


            Session.Add("Month5", MonthDropdwn4.SelectedValue);


        }

        protected void NextMonthSession5(object sender, EventArgs e)
        {


            Session.Add("Month6", MonthDropdwn5.SelectedValue);



        }

        protected void NextMonthSession6(object sender, EventArgs e)
        {


            Session.Add("Month7", MonthDropdwn6.SelectedValue);



        }

        protected void NextMonthSession7(object sender, EventArgs e)
        {


            Session.Add("Month8", MonthDropdwn7.SelectedValue);



        }

        protected void NextMonthSession8(object sender, EventArgs e)
        {


            Session.Add("Month9", MonthDropdwn8.SelectedValue);




        }

        protected void NextMonthSession9(object sender, EventArgs e)
        {


            Session.Add("Month10", MonthDropdwn9.SelectedValue);



        }

        protected void NextMonthSession10(object sender, EventArgs e)
        {


            Session.Add("Month11", MonthDropdwn10.SelectedValue);



        }

        protected void NextMonthSession11(object sender, EventArgs e)
        {


            Session.Add("Month12", MonthDropdwn11.SelectedValue);



        }

       
        protected void TPsSearchObjectDataSource_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            string tpName = search.Text;// method to get a tp name

            if (tpName == null)
                return;
            else

                // There was one parameter with NULL value in the collection
                // but you have to clear it and add it with a value
                e.InputParameters.Clear();
            e.InputParameters.Add("DOC_NAME", tpName);
            // this would not working! e.InputParameters["PARAMETERDATE"] = dt;

        }

        protected void FromMonthSessionAdd(object sender, EventArgs e)
        {


            Session.Add("FromMonth", FromMonthDropDownList.SelectedValue);



        }

        protected void FromYearSessionAdd(object sender, EventArgs e)
        {


            Session.Add("FromYear", FromYearDropDownList.SelectedValue);



        }

        protected void ToMonthSessionAdd(object sender, EventArgs e)
        {


            Session.Add("ToMonth", ToMonthDropDownList.SelectedValue);



        }

        protected void ToYearSessionAdd(object sender, EventArgs e)
        {


            Session.Add("ToYear", ToYearDropDownList.SelectedValue);



        }

    }
}