using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Sbyt.App_Service;
using Sbyt.Sravnenie;


namespace Sbyt
{
    public partial class Administration : System.Web.UI.Page
    {
        

        protected void Page_Load(Object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                ResList.SelectedIndex = 0;
                MyLabel.Visible = false;

            }
            else 
            {
                MyLabel.Visible = true;
                
            
            }
            
            



        }
        
        protected void SbytConvertBtn_Click(object sender, EventArgs e)
        {
            if (AbonentSbyt.HasFile)
            {                         
               
                String fileName = AbonentSbyt.FileName;
                String savePath = Constants.SavePathForFilesConvert;
                savePath += fileName;
                AbonentSbyt.SaveAs(savePath);
                string message = ChekODBCColumns.Instance.CheckColumnNamesSbyt(fileName);
                 if (message != string.Empty)
                 {
                     MyLabel.Text = message;
                 }
                 else
                 {
                     BLL.Instance.SbytFormFunction(ResList.SelectedValue, fileName);
                     MyLabel.Text = "Конвертация файла " + fileName + " закончена!";
                 }

            }
            else
            {
                MyLabel.Text = "Выберите файл для конвертации!";

            }

                     
            

        }

        protected void PasportConvertBtn_Click(object sender, EventArgs e)
        {
            

            if (AbonentPasport.HasFile)
            {
                
                // Get the name of the file to upload.
                
              String fileName = AbonentPasport.FileName;
                String savePath = Constants.SavePathForFilesConvert;
                savePath += fileName;
                AbonentPasport.SaveAs(savePath);

              
              
                String message = String.Empty;

                message = ChekODBCColumns.Instance.CheckColumnsNamesPasport(fileName);
               if (message != string.Empty)
               {
                   MyLabel.Text = message;
               }
               else
               {

                   BLL.Instance.PasportFormFunction(ResList.SelectedValue, fileName);
                   MyLabel.Text = "Конвертация файла " + fileName + " закончена!";
               }

            }
            else
            {
                MyLabel.Text = "Выберите файл для конвертации!";

            }

        }

        protected void StreetConvertBtn_Click(object sender, EventArgs e)
        {
           
            if (SprUlic.HasFile)
            {

                // Get the name of the file to upload.
          
                String fileName = SprUlic.FileName;
                String savePath = Constants.SavePathForFilesConvert;
                savePath += fileName;
                SprUlic.SaveAs(savePath);
                String message;
                message =  ChekODBCColumns.Instance.CheckColumnsNamesDerul(fileName);
                if (message != string.Empty)
                {
                    MyLabel.Text = message;
                }
                else
                {
                    BLL.Instance.StreetFormFunction(ResList.SelectedValue, fileName);
                    MyLabel.Text = "Конвертация файла " + fileName + " закончена!";
                }


            }
            else
            {
                MyLabel.Text = "Выберите файл для конвертации!";

            }

        }












        protected void TestBtn_Click(object sender, EventArgs e)
        {

         // TimePeriod.Instance.Getperiod("January", "2012", "Marth", "2012");


//
 //           TimePeriod.Instance.Getperiod("August", "2012", "Marth", "2012");








          //  TimePeriod.Instance.Getperiod("February", "2011", "Marth", "2013");

        //    TimePeriod.Instance.Getperiod("November", "2013", "Marth", "2011");
           

        }

        
    }
}