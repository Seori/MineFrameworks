using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MineFramework;
using System.ServiceProcess;

namespace MineTestForm
{
    public partial class Form1 : Form
    {
        DtCls dtcls;
        DataTable _commonDt;

        public Form1()
        {
            InitializeComponent();

            dtcls = new DtCls();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable sampledt = new DataTable();
            string[][] sSource = { new string[] {"No", "1"}, new string[] {"No", "2"}, new string[] { "Name", "Kim Sook Hwan" } };
            sampledt = DtCls.ArrayToDataTable(sSource);

            originGrid.DataSource = sampledt;           
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            // postgresql 접속테스트
            //PostgreConCls.constrSet("127.0.0.1", "5432", "postgres", "postgres", "cys1203");
            //int conInt = PostgreConCls.connect();

            //if (conInt == 0)
            //{
            //    tbLog.Text = "접속완료";
            //}
            //else
            //{
            //    tbLog.Text = "접속실패" + conInt;
            //}

            //FileCls.getCertInfo();

            //tbLog.Text = "aaaaa";

            //ServiceRead("SysMain");

            //tbTarget.Text = StringCls.AmountComma(tbVal.Text);

            //DictionaryCls dic = new DictionaryCls();
            //dic.addOrUpdate("CHK", "1");

            //MessageBox.Show(dic["CHK"].ToString());

            getMember();
            //tbLog.Text = StringCls.fnDataTableToJson2(_commonDt);

            //string jsonStr = StringCls.fnDataTableToJsonString(_commonDt);

            //DataTable _oriDt = DtCls.ConvertJsonToDataTable(jsonStr);

            StringCls.fnDataTableToCsv(_commonDt);

            //tbLog.Text = "aaa";

            //XmlCls.fnJsonToXMLToFile(jsonStr, "CUBESTOCK", @"C:\CUBESTOCK\Config\", "JsonTest.xml");

            //_commonDt.DataSet.DataSetName = "QUU";
            //_commonDt.TableName = "CHANG";

            //string strxml = XmlCls.fnDtToXML("FINGER", _commonDt, false);
            //XmlCls.fnDtToXMLToFile(_commonDt, "FINGER", @"C:\CUBESTOCK\Config\", "dbCon.xml");
            //_commonDt.WriteXml(@"C:\CUBESTOCK\TEST.xml", true);

            //DataTable _tmp = XmlCls.fnXMLFileToDt(@"C:\CUBESTOCK\Config\dbCon.xml");

            //tbLog.Text = _tmp.TableName;

            //tbLog.Text = strxml;
        }

        public void getMember()
        {
            // Database 접속테스트
            DbConCls.constrSet("127.0.0.1", "1433", "CUBEDB", "su", "eoqkrskwk!@#");
            DbConCls.Connect("");

            SqlConnection _cons = DbConCls.connObject;
            string query = "select * from member";
            DataSet rds = DbConCls.MSsqlQueryExec(query);

            _commonDt = rds.Tables[0];

            tbLog.Text = "이름은" + _commonDt.Rows[0]["m_name"].ToString();
        }

        private void ServiceRead(string svrname)
        {
            ServiceController sc = new ServiceController(svrname);
            try
            {
                if (sc.Status.Equals(ServiceControllerStatus.Running))
                {
                    sc.Stop();
                }
                else
                {
                    tbLog.AppendText("실행중아님\r\n");
                }
                
            }
            catch(Exception ex)
            {
                tbLog.AppendText("Error : " + ex.Message + "\r\n");
            }

            //foreach (ServiceController service in services)
            //    tbLog.AppendText(service.ServiceName + "---" + service.DisplayName + "\r\n");
        }
    }
}
