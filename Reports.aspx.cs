using System;
using Sbyt.App_Service;
using Sbyt.Sravnenie;

namespace Sbyt
{
    public partial class Reports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                MyLabel.Visible = false;
                StolbResultLinkButton.Visible = false;
                DergResultLinkButton.Visible = false;
                UzdaResultLinkButton.Visible = false;
                NesvResultLinkButton.Visible = false;
                KleckResultLinkButton.Visible = false;
                if (BLL.Instance.IsExistFileOnWebServer(Constants.StolbResultFileName))
                {
                    StolbResultLinkButton.Visible = true;
                }
                if (BLL.Instance.IsExistFileOnWebServer(Constants.DergResultFileName))
                {
                    DergResultLinkButton.Visible = true;
                }
                if (BLL.Instance.IsExistFileOnWebServer(Constants.UzdaResultFileName))
                {
                    UzdaResultLinkButton.Visible = true;
                }
                if (BLL.Instance.IsExistFileOnWebServer(Constants.NesvResultFileName))
                {

                    NesvResultLinkButton.Visible = true;
                }
                if (BLL.Instance.IsExistFileOnWebServer(Constants.KleckResultFileName))
                {

                    KleckResultLinkButton.Visible = true;
                }

            }
            else
            {
                MyLabel.Visible = true;
                StolbResultLinkButton.Visible = false;
                DergResultLinkButton.Visible = false;
                UzdaResultLinkButton.Visible = false;
                NesvResultLinkButton.Visible = false;
                KleckResultLinkButton.Visible = false;
                if (BLL.Instance.IsExistFileOnWebServer(Constants.StolbResultFileName))
                {
                    StolbResultLinkButton.Visible = true;
                }
                if (BLL.Instance.IsExistFileOnWebServer(Constants.DergResultFileName))
                {
                    DergResultLinkButton.Visible = true;
                }
                if (BLL.Instance.IsExistFileOnWebServer(Constants.UzdaResultFileName))
                {
                    UzdaResultLinkButton.Visible = true;
                }
                if (BLL.Instance.IsExistFileOnWebServer(Constants.NesvResultFileName))
                {

                    NesvResultLinkButton.Visible = true;
                }
                if (BLL.Instance.IsExistFileOnWebServer(Constants.KleckResultFileName))
                {

                    KleckResultLinkButton.Visible = true;
                }

              

            }

           

          
        }

        protected void Stolbbtn_Click(object sender, EventArgs e)
        {
          

            BLL.Instance.StolbReportView();

            MyLabel.Text = "Формирование результатов завершено";
        }

        protected void Dergbtn_Click(object sender, EventArgs e)
        {
           

            BLL.Instance.DergReportView();

            MyLabel.Text = "Формирование результатов завершено";

       }

        protected void Nesvbtn_Click(object sender, EventArgs e)
        {


            BLL.Instance.NesvReportView();

            MyLabel.Text = "Формирование результатов завершено";
            

        }

        protected void Uzdabtn_Click(object sender, EventArgs e)
        {


            BLL.Instance.UzdaReportView();

            MyLabel.Text = "Формирование результатов завершено";
        }

        protected void Kleckbtn_Click(object sender, EventArgs e)
        {


            BLL.Instance.KleckReportView();

            MyLabel.Text = "Формирование результатов завершено";
        }

        protected void StolbHyper(object sender, EventArgs e)
        {


            BLL.Instance.XmlFileDownload(Constants.StolbResultFileName);
        
        }
        protected void DergHyper(object sender, EventArgs e)
        {


            BLL.Instance.XmlFileDownload(Constants.DergResultFileName);

        }
        protected void NesvHyper(object sender, EventArgs e)
        {


            BLL.Instance.XmlFileDownload(Constants.NesvResultFileName);

        }
        protected void UzdaHyper(object sender, EventArgs e)
        {


            BLL.Instance.XmlFileDownload(Constants.UzdaResultFileName);

        }
        protected void KleckHyper(object sender, EventArgs e)
        {


            BLL.Instance.XmlFileDownload(Constants.KleckResultFileName);

        }

    }
}