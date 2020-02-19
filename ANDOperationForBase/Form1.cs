using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ANDOperationForBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 窗体加载事件
        private void Form1_Load(object sender, EventArgs e)
        {
            //label1.Text = (128 & 256).ToString();
            chkBox1.Text = "污染源";
            chkBox2.Text = "客户";
            chkBox4.Text = "供应商";
            chkBox8.Text = "考核单位";
            chkBox16.Text = "分包商";
            chkBox32.Text = "生产厂商";
            chkBox64.Text = "鉴定机构";
            chkBox128.Text = "运营商";
            chkBox256.Text = "256";
            chkBox512.Text = "512";

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
    }
}