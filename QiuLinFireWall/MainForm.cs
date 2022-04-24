using NetFwTypeLib;
using QiuLinFireWall.Helper;
using QiuLinFireWall.Loading;
using QiuLinFireWall.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QiuLinFireWall
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        private List<MyFireWallModel>  myFireWall = new List<MyFireWallModel>();
        private void MainForm_Load(object sender, EventArgs e)
        {
            
            this.LoadMyFireWall();//加载我的规则
        }

        /// <summary>
        /// 加载我的规则
        /// </summary>
        private void LoadMyFireWall()
        {
            LoadingHelper.ShowLoading("正在加载我的规则，请稍候。。。", this, (obj) =>
            {
                myFireWall = FireWallHelp.GetMyFireWall("QiuLinFireWallGroups");
            });
            this.dvgData.AutoGenerateColumns = false;
            this.dvgData.DataSource = new BindingList<MyFireWallModel>(myFireWall);
        }

        /// <summary>
        /// 启用WindowsDefender防火墙
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEnable_Click(object sender, EventArgs e)
        {
            LoadingHelper.ShowLoading("正在设置中，请稍候。。。", this, (obj) =>
            {
                if (FireWallHelp.FirewallOperateByObject(true, true, true))
                {
                    MessageBox.Show("成功启用WindowsDefender防火墙", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("启用WindowsDefender防火墙失败！！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            });

        }

        /// <summary>
        /// 启用WindowsDefender防火墙
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonClose_Click(object sender, EventArgs e)
        {
            LoadingHelper.ShowLoading("正在设置中，请稍候。。。", this, (obj) =>
            {
                if (FireWallHelp.FirewallOperateByObject(false, false, false))
                {
                    MessageBox.Show("成功关闭WindowsDefender防火墙", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("关闭WindowsDefender防火墙失败！！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            });
        }

        /// <summary>
        /// 更新IP地址库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonUpIpList_Click(object sender, EventArgs e)
        {
            int ipListCount = 0;//XML里面条数
            int isSuccessCount = 0;//更新成功数
            LoadingHelper.ShowLoading("正在更新中，更新大概需要3-5分钟\nIp从https://github.com/metowolf/iplist里获取\n请确保您能访问GitHub", this, (obj) =>
            {

                string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "IpList.xml";
                //读取XML 获取各国家IP更新地址
                var ipLists = XmlHelp.ReadXML(path);
                ipListCount = ipLists.Count;
                foreach (var item in ipLists)
                {
                    //循环从https://github.com/metowolf/iplist里读取各国IP
                    string newIpList = HttpHelper.GetIpList(item.IpSourceAddress);

                    if (newIpList.Length > 3)
                    {
                        newIpList = Regex.Replace(newIpList, "\n", ",");
                        //更新IP
                        if (XmlHelp.UpdateXML(path, item.Country, newIpList))
                        {
                            isSuccessCount++;
                        }

                    }

                }



            });


            if (ipListCount == isSuccessCount)
            {
                MessageBox.Show("更新IP成功", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("更新IP失败！！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        /// <summary>
        /// 删除禁止国外IP访问规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteGW_Click(object sender, EventArgs e)
        {
            LoadingHelper.ShowLoading("正在删除中，请稍候。。。", this, (obj) =>
            {
                string grouping = "QiuLinFireWallGroups_一键禁用国外入口规则组";
                if (FireWallHelp.IsExistenceGrouping(grouping))
                {
                    if (FireWallHelp.DeleteGrouping(grouping))
                    {
                        MessageBox.Show("成功删除WindowsDefender防火墙规则组：" + grouping, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("删除WindowsDefender防火墙规则组失败！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("成功删除WindowsDefender防火墙规则组：" + grouping, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });


            //刷新列表
            this.LoadMyFireWall();//加载我的规则
        }

        /// <summary>
        /// 启用禁止国外IP访问规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonEnableGW_Click(object sender, EventArgs e)
        {
            int listRuleCount = 0;
            int createCount = 0;

            LoadingHelper.ShowLoading("正在设置中，请稍候。。。\n由于IP库比较大，每1000个IP设置一个规则", this, (obj) =>
            {
                string path = System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "IpList.xml";
                string grouping = "QiuLinFireWallGroups_一键禁用国外入口规则组";
                if (FireWallHelp.IsExistenceGrouping(grouping))
                {
                    MessageBox.Show("操作失败,系统已经存在此规则！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var listRule = FireWallHelp.GetRuleList(path, 1000, grouping.Replace("QiuLinFireWallGroups_", "")
                                                        , NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN
                                                        , NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY
                                                        , NET_FW_ACTION_.NET_FW_ACTION_BLOCK
                                                        , grouping);

                listRuleCount = listRule.Count;
                foreach (var item in listRule)
                {
                    if (!FireWallHelp.IsExistenceRuleName(item.RuleName))
                    {
                        if (FireWallHelp.CreateRule(item))
                        {
                            createCount++;
                        }
                    }

                }

            });

            if (listRuleCount > 0 && createCount == listRuleCount)
            {
                MessageBox.Show("操作成功！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else if (listRuleCount > 0 && createCount > 0 && createCount < listRuleCount)
            {
                MessageBox.Show("部分操作成功！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {
                MessageBox.Show("操作失败！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

            //刷新列表
            this.LoadMyFireWall();//加载我的规则

        }

        /// <summary>
        /// 自定义规则选择应用程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSelectApp_Click(object sender, EventArgs e)
        {
            
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = true;
            fileDialog.Title = "请选择应用程序";
            fileDialog.Filter = "(*exe)|*.exe"; //设置要选择的文件的类型
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;//返回文件的完整路径

                if (Path.GetExtension(filePath).ToUpper() !=".EXE")
                {
                    MessageBox.Show("请选择EXE应用程序！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxExCustomApp.Text = "";
                    return;
                }
                else
                {
                    textBoxExCustomApp.Text = filePath;
                }
            }
        }


        /// <summary>
        /// 添加自定义规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCustomAdd_Click(object sender, EventArgs e)
        {
            string localIps = richTextBoxCustomLocalIp.Text;
            string remoteIps = richTextBoxCustomRemoteIp.Text;
            if (textBoxExCustomRuleName.Text.ToString().Trim() == "")
            {
                MessageBox.Show("请输入规则名称！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxExCustomRuleName.Focus();
                return;
            }
            if (textBoxExCustomApp.Text.ToString().Trim() != "")
            {
                if (System.IO.File.Exists(textBoxExCustomApp.Text.ToString().Trim()) == false)
                {
                    MessageBox.Show("未找到程序文件！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxExCustomApp.Focus();
                    return;
                }
            }

            LoadingHelper.ShowLoading("正在添加自定义规则中，请稍候。。。", this, (obj) =>
            {
                #region 

      
                #region 
                NET_FW_RULE_DIRECTION_ ruleDirectionTpye = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;

                if (radioButtonCustomIn.Checked)
                {
                    ruleDirectionTpye = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
                }
                else
                {
                    ruleDirectionTpye = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_OUT;
                }

                NET_FW_IP_PROTOCOL_ ipPriticolTpye = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY;
                if (radioButtonCustomTCP.Checked)
                {
                    ipPriticolTpye = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_TCP;
                }
                else if (radioButtonCustomUDP.Checked)
                {
                    ipPriticolTpye = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_UDP;
                }
                else
                {
                    ipPriticolTpye = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY;
                }

                NET_FW_ACTION_ actionType = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;

                if (radioButtonCustomAllow.Checked)
                {
                    actionType = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
                }
                else
                {
                    actionType = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
                }
                #endregion


                FireWallModel ruleModel = new FireWallModel();
                ruleModel.RuleName = textBoxExCustomRuleName.Text.ToString().Trim();
                ruleModel.RuleDescription = textBoxExCustomRuleName.Text.ToString().Trim() + "自定义规则描述";
                ruleModel.RuleDirectionTpye = ruleDirectionTpye;
                ruleModel.IpPriticolTpye = ipPriticolTpye;
                ruleModel.ActionType = actionType;
                ruleModel.AppPath = textBoxExCustomApp.Text.Trim().ToString();
               
                ruleModel.LocalAddresses = GetIpList(localIps);
                ruleModel.LocalPorts = null;

                ruleModel.RemoteAddresses = GetIpList(remoteIps);
                ruleModel.RemotePorts = null;
                ruleModel.Grouping = "QiuLinFireWallGroups_自定义规则之"+ textBoxExCustomRuleName.Text.ToString().Trim();
                #endregion

                if (!FireWallHelp.IsExistenceRuleName(ruleModel.RuleName))
                {
                    if (FireWallHelp.CreateRule(ruleModel))
                    {
                        MessageBox.Show("添加成功！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("添加失败！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("添加失败,已经操作此规则！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                
            });

            //刷新列表
            this.LoadMyFireWall();//加载我的规则
        }



        /// <summary>
        /// 获取IP
        /// </summary>
        /// <param name="ips"></param>
        /// <returns></returns>
        private string GetIpList(string ips) 
        {
            string newIpList = null;
            if (!string.IsNullOrEmpty(ips))
            {
                var allips = Regex.Matches(ips, @"((\b((([0-9A-Fa-f]{1,4}:){7}([0-9A-Fa-f]{1,4}|:))|(([0-9A-Fa-f]{1,4}:){6}(:[0-9A-Fa-f]{1,4}|((25[0-5]|2[0-4]d|1dd|[1-9]?d)(.(25[0-5]|2[0-4]d|1dd|[1-9]?d)){3})|:))|(([0-9A-Fa-f]{1,4}:){5}(((:[0-9A-Fa-f]{1,4}){1,2})|:((25[0-5]|2[0-4]d|1dd|[1-9]?d)(.(25[0-5]|2[0-4]d|1dd|[1-9]?d)){3})|:))|(([0-9A-Fa-f]{1,4}:){4}(((:[0-9A-Fa-f]{1,4}){1,3})|((:[0-9A-Fa-f]{1,4})?:((25[0-5]|2[0-4]d|1dd|[1-9]?d)(.(25[0-5]|2[0-4]d|1dd|[1-9]?d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){3}(((:[0-9A-Fa-f]{1,4}){1,4})|((:[0-9A-Fa-f]{1,4}){0,2}:((25[0-5]|2[0-4]d|1dd|[1-9]?d)(.(25[0-5]|2[0-4]d|1dd|[1-9]?d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){2}(((:[0-9A-Fa-f]{1,4}){1,5})|((:[0-9A-Fa-f]{1,4}){0,3}:((25[0-5]|2[0-4]d|1dd|[1-9]?d)(.(25[0-5]|2[0-4]d|1dd|[1-9]?d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){1}(((:[0-9A-Fa-f]{1,4}){1,6})|((:[0-9A-Fa-f]{1,4}){0,4}:((25[0-5]|2[0-4]d|1dd|[1-9]?d)(.(25[0-5]|2[0-4]d|1dd|[1-9]?d)){3}))|:))|(:(((:[0-9A-Fa-f]{1,4}){1,7})|((:[0-9A-Fa-f]{1,4}){0,5}:((25[0-5]|2[0-4]d|1dd|[1-9]?d)(.(25[0-5]|2[0-4]d|1dd|[1-9]?d)){3}))|:)))(%.+)?s*(\/([0-9]|[1-9][0-9]|1[0-1][0-9]|12[0-8]))?\b)(?!\/))|((\b([0-9]{1,3}\.){3}[0-9]{1,3}(\/([0-9]|[1-2][0-9]|3[0-2]))?\b)(?!\/))", RegexOptions.IgnoreCase)
                                              .Cast<Match>()
                                              .Select(m => m.Value)
                                              .ToList();
               
                foreach (string ip in allips)
                {
                    newIpList += ip + ',';
                }
                newIpList = newIpList.Remove(newIpList.Length - 1);
            }
            

            return newIpList;
        }

        /// <summary>
        /// 删除所有自定义规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonDeleteAll_Click(object sender, EventArgs e)
        {
            LoadingHelper.ShowLoading("正在删除中，请稍候。。。", this, (obj) =>
            {
                string grouping = "QiuLinFireWallGroups";
                if (FireWallHelp.IsExistenceContainsGrouping(grouping))
                {
                    if (FireWallHelp.DeleteAllGrouping(grouping))
                    {
                        MessageBox.Show("成功删除本程序设置的所有规则" , "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("删除WindowsDefender防火墙规则失败！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("成功删除本程序设置的所有规则" , "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            });

            //刷新列表
            this.LoadMyFireWall();//加载我的规则
        }

        /// <summary>
        /// 删除自定义规则
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCustomDelete_Click(object sender, EventArgs e)
        {
            if (textBoxExCustomRuleName.Text.ToString().Trim() == "")
            {
                MessageBox.Show("请输入规则名称！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBoxExCustomRuleName.Focus();
                return;
            }
            LoadingHelper.ShowLoading("正在删除自定义规则中，请稍候。。。", this, (obj) =>
            { 
                if ( FireWallHelp.IsExistenceContainsRuleName(textBoxExCustomRuleName.Text.ToString(), "QiuLinFireWallGroups_自定义规则之"))
                {
                    if (FireWallHelp.DeleteRule(textBoxExCustomRuleName.Text.ToString()))
                    {
                        MessageBox.Show("删除成功！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    else
                    {
                        MessageBox.Show("删除失败！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("不存在此规则！！！", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

               
            });

            //刷新列表
            this.LoadMyFireWall();//加载我的规则

        }

        
    }
}
