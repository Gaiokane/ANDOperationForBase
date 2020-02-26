using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gaiokane;

namespace ANDOperationForBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string appsetting1, appsetting2, appsetting4, appsetting8, appsetting16, appsetting32, appsetting64, appsetting128, appsetting256, appsetting512;

        #region 窗体加载事件
        private void Form1_Load(object sender, EventArgs e)
        {
            getDefaultAppSettings();
            setDefaultAppSettingsIfIsNullOrEmpty();
            getDefaultAppSettings();

            //label1.Text = (128 & 256).ToString();
            chkBox1.Text = appsetting1;// "污染源";
            chkBox2.Text = appsetting2;// "客户";
            chkBox4.Text = appsetting4;// "供应商";
            chkBox8.Text = appsetting8;// "考核单位";
            chkBox16.Text = appsetting16;// "分包商";
            chkBox32.Text = appsetting32;// "生产厂商";
            chkBox64.Text = appsetting64;// "鉴定机构";
            chkBox128.Text = appsetting128;// "运营商";
            chkBox256.Text = appsetting256;// "256";
            chkBox512.Text = appsetting512;// "512";

            txtBoxValue.Focus();
        }
        #endregion

        #region 复选框转数字 按钮单击事件
        private void btnNumToChkBox_Click(object sender, EventArgs e)
        {
            string str = txtBoxValue.Text.Trim();
            if (IsNumber(str) == false || string.IsNullOrEmpty(str))
            {
                MessageBox.Show("只能输入数字！");
                txtBoxValue.Focus();
            }
            else
            {
                resetChkBoxChecked();
                int value = Convert.ToInt32(txtBoxValue.Text.Trim());
                if (getAndOperationResult(value, 1) != 0)
                {
                    chkBox1.Checked = true;
                }
                if (getAndOperationResult(value, 2) != 0)
                {
                    chkBox2.Checked = true;
                }
                if (getAndOperationResult(value, 4) != 0)
                {
                    chkBox4.Checked = true;
                }
                if (getAndOperationResult(value, 8) != 0)
                {
                    chkBox8.Checked = true;
                }
                if (getAndOperationResult(value, 16) != 0)
                {
                    chkBox16.Checked = true;
                }
                if (getAndOperationResult(value, 32) != 0)
                {
                    chkBox32.Checked = true;
                }
                if (getAndOperationResult(value, 64) != 0)
                {
                    chkBox64.Checked = true;
                }
                if (getAndOperationResult(value, 128) != 0)
                {
                    chkBox128.Checked = true;
                }
                if (getAndOperationResult(value, 256) != 0)
                {
                    chkBox256.Checked = true;
                }
                if (getAndOperationResult(value, 512) != 0)
                {
                    chkBox512.Checked = true;
                }
            }
        }
        #endregion

        #region 数字转复选框 按钮单击事件
        private void btnChkBoxToNum_Click(object sender, EventArgs e)
        {
            int result = 0;
            int num = 0;
            if (chkBox1.Checked == true)
            {
                num = 1;
                result += num;
            }
            if (chkBox2.Checked == true)
            {
                num = 2;
                result += num;
            }
            if (chkBox4.Checked == true)
            {
                num = 4;
                result += num;
            }
            if (chkBox8.Checked == true)
            {
                num = 8;
                result += num;
            }
            if (chkBox16.Checked == true)
            {
                num = 16;
                result += num;
            }
            if (chkBox32.Checked == true)
            {
                num = 32;
                result += num;
            }
            if (chkBox64.Checked == true)
            {
                num = 64;
                result += num;
            }
            if (chkBox128.Checked == true)
            {
                num = 128;
                result += num;
            }
            if (chkBox256.Checked == true)
            {
                num = 256;
                result += num;
            }
            if (chkBox512.Checked == true)
            {
                num = 512;
                result += num;
            }
            txtBoxValue.Text = result.ToString();
        }
        #endregion

        #region 将所有chkbox的checked属性置为false
        /// <summary>
        /// 将所有chkbox的checked属性置为false
        /// </summary>
        private void resetChkBoxChecked()
        {
            chkBox1.Checked = false;
            chkBox2.Checked = false;
            chkBox4.Checked = false;
            chkBox8.Checked = false;
            chkBox16.Checked = false;
            chkBox32.Checked = false;
            chkBox64.Checked = false;
            chkBox128.Checked = false;
            chkBox256.Checked = false;
            chkBox512.Checked = false;
        }
        #endregion

        #region 与运算，返回结果，0 or 非0
        /// <summary>
        /// 与运算，返回结果，0 or 非0
        /// </summary>
        /// <param name="value">value & num</param>
        /// <param name="num">value & num</param>
        /// <returns></returns>
        private int getAndOperationResult(int value, int num)
        {
            int result = value & num;
            return result;
        }
        #endregion

        #region 判断字符串是否为数字
        /// <summary>
        /// 判断字符串是否为数字
        /// </summary>
        /// <param name="str">待验证的字符串</param>
        /// <returns>bool</returns>
        public static bool IsNumber(string str)
        {
            bool result = true;
            foreach (char ar in str)
            {
                if (!char.IsNumber(ar))
                {
                    result = false;
                    break;
                }
            }
            return result;
        }
        #endregion

        private void getDefaultAppSettings()
        {
            appsetting1 = RWConfig.GetappSettingsValue("1", "./ANDOperationForBase.exe");
            appsetting2 = RWConfig.GetappSettingsValue("2", "./ANDOperationForBase.exe");
            appsetting4 = RWConfig.GetappSettingsValue("4", "./ANDOperationForBase.exe");
            appsetting8 = RWConfig.GetappSettingsValue("8", "./ANDOperationForBase.exe");
            appsetting16 = RWConfig.GetappSettingsValue("16", "./ANDOperationForBase.exe");
            appsetting32 = RWConfig.GetappSettingsValue("32", "./ANDOperationForBase.exe");
            appsetting64 = RWConfig.GetappSettingsValue("64", "./ANDOperationForBase.exe");
            appsetting128 = RWConfig.GetappSettingsValue("128", "./ANDOperationForBase.exe");
            appsetting256 = RWConfig.GetappSettingsValue("256", "./ANDOperationForBase.exe");
            appsetting512 = RWConfig.GetappSettingsValue("512", "./ANDOperationForBase.exe");
        }

        private void setDefaultAppSettingsIfIsNullOrEmpty()
        {
            if (string.IsNullOrEmpty(appsetting1))
            {
                RWConfig.SetappSettingsValue("1", "1", "./ANDOperationForBase.exe");
            }
            if (string.IsNullOrEmpty(appsetting2))
            {
                RWConfig.SetappSettingsValue("2", "2", "./ANDOperationForBase.exe");
            }
            if (string.IsNullOrEmpty(appsetting4))
            {
                RWConfig.SetappSettingsValue("4", "4", "./ANDOperationForBase.exe");
            }
            if (string.IsNullOrEmpty(appsetting8))
            {
                RWConfig.SetappSettingsValue("8", "8", "./ANDOperationForBase.exe");
            }
            if (string.IsNullOrEmpty(appsetting16))
            {
                RWConfig.SetappSettingsValue("16", "16", "./ANDOperationForBase.exe");
            }
            if (string.IsNullOrEmpty(appsetting32))
            {
                RWConfig.SetappSettingsValue("32", "32", "./ANDOperationForBase.exe");
            }
            if (string.IsNullOrEmpty(appsetting64))
            {
                RWConfig.SetappSettingsValue("64", "64", "./ANDOperationForBase.exe");
            }
            if (string.IsNullOrEmpty(appsetting128))
            {
                RWConfig.SetappSettingsValue("128", "128", "./ANDOperationForBase.exe");
            }
            if (string.IsNullOrEmpty(appsetting256))
            {
                RWConfig.SetappSettingsValue("256", "256", "./ANDOperationForBase.exe");
            }
            if (string.IsNullOrEmpty(appsetting512))
            {
                RWConfig.SetappSettingsValue("512", "512", "./ANDOperationForBase.exe");
            }
        }
    }
}