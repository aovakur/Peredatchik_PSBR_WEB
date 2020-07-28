using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (WebApplication2.Default.login != null || WebApplication2.Default.password != null)
            {


                GridView1.AllowPaging = true;
                GridView1.PageIndexChanging += new GridViewPageEventHandler(GridView1_PageIndexChanging);

                GridView1.DataSource = GetTable();
                GridView1.DataBind();
            }
            else
            {
                TextBox1.Text = "Ошибка доступа"; 
            }
        }

        private void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.DataSource = GetTable();
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private DataSet GetTable()
        {
            SqlConnection con = new SqlConnection("data source=127.0.0.1;initial catalog=ps_bankrussia_test;persist security info=True;user id=adminkbr;password=xX123456;MultipleActiveResultSets=True;App=EntityFramework");

            

            string strSQL = "Select id as 'Порядковый номер ПП', " +
                    "status as 'Статус'," +
                    "postinbank as 'Поступило в банк', " +
                    "spissoschet as 'Списано со счета плательщика'," +
                    "form_okyd as 'Номер формы ОКУД'," +
                    "name_bank_docum as 'Наименование банковской документации'," +
                    "number_pp as 'Номер платежного поручения'," +
                    "date_pp as 'Списано со счета плательщика'," +
                    "vid_platezha as 'Вид платежа'," +
                    "status_platelshik as 'Статус платежа'," +
                    "summa_propisiu as 'Сумма прописью'," +
                    "INN_platelshika as 'ИНН плательщика'," +
                    "KPP_platelshika as 'КПП плательщика'," +
                    "Summa_platelshika as 'Сумма платежа'," +
                    "Name_platelshika as 'Наименование организации плательщика'," +
                    "Acc_platelshika as 'Счет плательщика'," +
                    "bank_platelshika as 'Банк плательщика'," +
                    "BIK_platelshika as 'БИК плательщика'," +
                    "KOR_poluchat as 'Кор.счет получателя'," +
                    "BANK_poluchat as 'Банк получателя'," +
                    "BIK_poluchat as 'БИК получателя'," +
                    "ACC_bank_poluchat as 'Счет банк получатель'," +
                    "INN_poluchat as 'ИНН получателя'," +
                    "KPP_poluchat as 'КПП получателя'," +
                    "ACC_poluchat as 'Номер счета получателя'," +
                    "name_poluchat as 'Наименование компании-получателя'," +
                    "shifr_pp as 'Вид операции'," +
                    "srochnost as 'Срочность ПП'," +
                    "naznachenie as 'Назначение платежа'," +
                    "ocherednost as 'Очередность'," +
                    "kod as 'УИН платежа'," +
                    "rezerv as 'Резервное поле'," +
                    "KBK as 'КБК'," +
                    "OKTMO as 'ОКТМО'," +
                    "osnovanie_pp as 'Основание платежа'," +
                    "nalog_period as 'Налоговый период'," +
                    "Nomer_docum as 'Номер документа'," +
                    "date_docum as 'Дата документа'," +
                    "kod_vyplatu as 'Код выплаты'," +
                    "naznachenie_PP as 'Назначение ПП'," +
                    "MP 'МП'," +
                    "PODPIS as 'Подпись'," +
                    "BANK_OTMETK as 'Отметка банка'" +
                    "from create_pp ORDER BY id DESC";

            SqlDataAdapter dt = new SqlDataAdapter(strSQL, con);

            DataSet ds = new DataSet();

            dt.Fill(ds, "create_pp");

            con.Close();

            return ds;
        }
    }
}