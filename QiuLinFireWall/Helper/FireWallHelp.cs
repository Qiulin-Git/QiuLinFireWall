using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Principal;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using QiuLinFireWall.Model;
using NetFwTypeLib;
using Microsoft.Win32;

namespace QiuLinFireWall.Helper
{
    /// <summary>
    /// 防火墙帮助类
    /// </summary>
    public class FireWallHelp
    {




        #region 为WindowsDefender防火墙添加一条自定义类型规则


        /// <summary>
        /// 检查是否有同名规则组
        /// </summary>
        /// <param name="ruleName">规则组名称</param>
        /// <returns></returns>
        public static List<MyFireWallModel> GetMyFireWall(string grouping)
        {
            List<MyFireWallModel> myFireWallModels = new List<MyFireWallModel>();
            //创建防火墙策略类的实例
            INetFwPolicy2 policy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            //检查是否有同名规则
            foreach (INetFwRule item in policy2.Rules)
            {
                if ( item.Grouping != null && item.Grouping.Contains(grouping))
                {
                    #region 
                    string ruleDirectionTpye = "";
                    string ipPriticolTpye = "";
                    string actionType = "";

                    //获取出入站规则类型
                    if (item.Direction.ToString().ToUpper()== "NET_FW_RULE_DIR_IN")
                    {
                        ruleDirectionTpye = "入站";
                    }
                    else if (item.Direction.ToString().ToUpper() == "NET_FW_RULE_DIR_OUT")
                    {
                        ruleDirectionTpye = "出站";
                    }
                    else
                    {
                        ruleDirectionTpye = item.Direction.ToString();
                    }


                    //获取通讯类型
                    if (item.Protocol == 6)
                    {
                        ipPriticolTpye = "TCP";
                    }
                    else if (item.Protocol == 17)
                    {
                        ipPriticolTpye = "UDP";
                    }
                    else if (item.Protocol == 256)
                    {
                        ipPriticolTpye = "任何";
                    }
                    else
                    {
                        ipPriticolTpye = item.Protocol.ToString();
                    }



                    //获取操作类型
                    if (item.Action.ToString().ToUpper() == "NET_FW_ACTION_ALLOW")
                    {
                        actionType = "允许连接";
                    }
                    else if (item.Action.ToString().ToUpper() == "NET_FW_ACTION_BLOCK")
                    {
                        actionType = "阻止连接";
                    }
                    else
                    {
                        actionType = item.Action.ToString();
                    }
                    #endregion

                    MyFireWallModel fireWallModel = new MyFireWallModel();
                    fireWallModel.RuleName = item.Name;
                    fireWallModel.RuleDirectionTpye = ruleDirectionTpye;
                    fireWallModel.IpPriticolTpye = ipPriticolTpye;
                    fireWallModel.ActionType = actionType;
                    fireWallModel.AppPath = item.ApplicationName;
                    fireWallModel.Grouping = item.Grouping;
                    myFireWallModels.Add(fireWallModel);
                }
            }

            return myFireWallModels;
        }



        /// <summary>
        /// 为WindowsDefender防火墙添加一条自定义类型规则
        /// </summary>

        public static bool CreateRule(FireWallModel fireWallModel)
        {
            try
            {
                //创建防火墙策略类的实例
                INetFwPolicy2 policy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

            //创建防火墙规则类的实例: 有关该接口的详细介绍：https://docs.microsoft.com/zh-cn/windows/win32/api/netfw/nn-netfw-inetfwrule
            INetFwRule rule = (INetFwRule)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwRule"));
            //为规则添加名称
            rule.Name = fireWallModel.RuleName;
            //为规则添加描述
            rule.Description = fireWallModel.RuleDescription;
            //选择入站规则还是出站规则，IN为入站，OUT为出站
            rule.Direction = fireWallModel.RuleDirectionTpye;
            //为规则添加协议类型
            rule.Protocol = (int)fireWallModel.IpPriticolTpye;
            //为规则添加应用程序（注意这里是应用程序的绝对路径名）
            if (!string.IsNullOrEmpty(fireWallModel.AppPath))
            {
                rule.ApplicationName = fireWallModel.AppPath;
            }

            try
            {
                //为规则添加本地IP地址    
                if (!string.IsNullOrEmpty(fireWallModel.LocalAddresses))
                {
                    rule.LocalAddresses = fireWallModel.LocalAddresses;
                }

                //为规则添加本地端口
                if (!string.IsNullOrEmpty(fireWallModel.LocalPorts))
                {
                    //需要移除空白字符（不能包含空白字符，下同）
                    rule.LocalPorts = fireWallModel.LocalPorts.Replace(" ", "");// "1-29999, 30003-33332, 33334-55554, 55556-60004, 60008-65535";
                }
                //为规则添加远程IP地址
                if (!string.IsNullOrEmpty(fireWallModel.RemoteAddresses))
                {
                    rule.RemoteAddresses = fireWallModel.RemoteAddresses;
                }
                //为规则添加远程端口
                if (!string.IsNullOrEmpty(fireWallModel.RemotePorts))
                {
                    rule.RemotePorts = fireWallModel.RemotePorts.Replace(" ", "");
                }
            }
            catch (Exception )
            {

                return false ;
            }
           

            //设置规则是阻止还是允许（ALLOW=允许，BLOCK=阻止）
            rule.Action = fireWallModel.ActionType;
            //分组 名
            rule.Grouping = fireWallModel.Grouping;
            //
            rule.InterfaceTypes = "All";
            //是否启用规则
            rule.Enabled = true;

           
                //添加规则到防火墙策略
                policy2.Rules.Add(rule);
            }
            catch (Exception )
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 检查是否有同名规则
        /// </summary>
        /// <param name="ruleName">规则名称</param>
        /// <returns></returns>
        public static bool IsExistenceRuleName(string ruleName)
        {
            //创建防火墙策略类的实例
            INetFwPolicy2 policy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            //检查是否有同名规则
            foreach (INetFwRule item in policy2.Rules)
            {
                if (item.Name == ruleName)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 删除WindowsDefender防火墙规则
        /// <summary>
        /// <param name="ruleName">规则名称</param>
        public static bool DeleteRule(string ruleName)
        {
            //创建防火墙策略类的实例
            INetFwPolicy2 policy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

            try
            {
                //根据规则名称移除规则
                policy2.Rules.Remove(ruleName);
            }
            catch (Exception e)
            {
                string error = $"防火墙删除规则出错：{ruleName} {e.Message}";

                throw new Exception(error);
            }
            return true;
        }


        /// <summary>
        /// 检查是否有同名规则
        /// </summary>
        /// <param name="ruleName">规则名称</param>
        /// <param name="groupings">规则名称组</param>
        /// <returns></returns>
        public static bool IsExistenceContainsRuleName(string ruleName, string groupings)
        {
            //创建防火墙策略类的实例
            INetFwPolicy2 policy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            //检查是否有同名规则
            foreach (INetFwRule item in policy2.Rules)
            {
                if (item.Name == ruleName && item.Grouping != null && item.Grouping.Contains(groupings))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 检查是否有同名规则组
        /// </summary>
        /// <param name="ruleName">规则组名称</param>
        /// <returns></returns>
        public static bool IsExistenceGrouping(string grouping)
        {
            //创建防火墙策略类的实例
            INetFwPolicy2 policy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            //检查是否有同名规则
            foreach (INetFwRule item in policy2.Rules)
            {
                if (item.Grouping == grouping)
                {
                    return true;
                }
            }

            return false;
        }



        /// <summary>
        /// 检查是否有同名规则组
        /// </summary>
        /// <param name="ruleName">规则组名称</param>
        /// <returns></returns>
        public static bool IsExistenceContainsGrouping(string grouping)
        {
            //创建防火墙策略类的实例
            INetFwPolicy2 policy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            //检查是否有同名规则
            foreach (INetFwRule item in policy2.Rules)
            {
               
                if (item.Grouping !=null && item.Grouping.Contains (grouping))
                {
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// 删除WindowsDefender防火墙规则
        /// <summary>
        /// <param name="ruleName">规则组名称</param>
        public static bool DeleteGrouping(string grouping)
        {
            //创建防火墙策略类的实例
            INetFwPolicy2 policy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            foreach (INetFwRule item in policy2.Rules)
            {
                if (item.Grouping == grouping)
                {
                    string ruleName = item.Name;

                    try
                    {
                        //根据规则名称移除规则
                        policy2.Rules.Remove(ruleName);
                    }
                    catch (Exception e)
                    {
                        string error = $"防火墙删除规则出错：{ruleName} {e.Message}";

                        throw new Exception(error);
                    }
                }
            }

            return true;
        }


        /// <summary>
        /// 删除WindowsDefender防火墙规则
        /// <summary>
        /// <param name="ruleName">规则组名称</param>
        public static bool DeleteAllGrouping(string grouping)
        {
            //创建防火墙策略类的实例
            INetFwPolicy2 policy2 = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
            foreach (INetFwRule item in policy2.Rules)
            {
                if (item.Grouping != null && item.Grouping.Contains ( grouping))
                {
                    string ruleName = item.Name;

                    try
                    {
                        //根据规则名称移除规则
                        policy2.Rules.Remove(ruleName);
                    }
                    catch (Exception e)
                    {
                        string error = $"防火墙删除规则出错：{ruleName} {e.Message}";

                        throw new Exception(error);
                    }
                }
            }

            return true;
        }

        #endregion



        #region C# 防火墙操作之启用与关闭

        /// <summary>
        /// 判断程序是否拥有管理员权限
        /// </summary>
        /// <returns>true:是管理员；false:不是管理员</returns>
        public static bool IsAdministrator()
        {
            WindowsIdentity current = WindowsIdentity.GetCurrent();
            WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
            return windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        /// <summary>
        /// 通过注册表操作防火墙
        /// </summary>
        /// <param name="domainState">域网络防火墙（禁用：0；启用（默认）：1）</param>
        /// <param name="publicState">公共网络防火墙（禁用：0；启用（默认）：1）</param>
        /// <param name="standardState">专用网络防火墙（禁用：0；启用（默认）：1）</param>
        /// <returns></returns>
        public static bool FirewallOperateByRegistryKey(int domainState = 1, int publicState = 1, int standardState = 1)
        {
            RegistryKey key = Registry.LocalMachine;
            try
            {
                string path = "HKEY_LOCAL_MACHINE\\SYSTEM\\ControlSet001\\Services\\SharedAccess\\Defaults\\FirewallPolicy";
                RegistryKey firewall = key.OpenSubKey(path, true);
                RegistryKey domainProfile = firewall.OpenSubKey("DomainProfile", true);
                RegistryKey publicProfile = firewall.OpenSubKey("PublicProfile", true);
                RegistryKey standardProfile = firewall.OpenSubKey("StandardProfile", true);
                domainProfile.SetValue("EnableFirewall", domainState, RegistryValueKind.DWord);
                publicProfile.SetValue("EnableFirewall", publicState, RegistryValueKind.DWord);
                standardProfile.SetValue("EnableFirewall", standardState, RegistryValueKind.DWord);
            }
            catch (Exception e)
            {
                string error = $"注册表修改出错：{e.Message}";
                throw new Exception(error);
            }
            return true;
        }



        /// <summary>
        /// 通过对象防火墙操作
        /// </summary>
        /// <param name="isOpenDomain">域网络防火墙（禁用：false；启用（默认）：true）</param>
        /// <param name="isOpenPublicState">公共网络防火墙（禁用：false；启用（默认）：true）</param>
        /// <param name="isOpenStandard">专用网络防火墙（禁用: false；启用（默认）：true）</param>
        /// <returns></returns>
        public static bool FirewallOperateByObject(bool isOpenDomain = true, bool isOpenPublicState = true, bool isOpenStandard = true)
        {
            try
            {
                INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));
                // 启用<高级安全Windows防火墙> - 专有配置文件的防火墙
                firewallPolicy.set_FirewallEnabled(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PRIVATE, isOpenStandard);
                // 启用<高级安全Windows防火墙> - 公用配置文件的防火墙
                firewallPolicy.set_FirewallEnabled(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_PUBLIC, isOpenPublicState);
                // 启用<高级安全Windows防火墙> - 域配置文件的防火墙
                firewallPolicy.set_FirewallEnabled(NET_FW_PROFILE_TYPE2_.NET_FW_PROFILE2_DOMAIN, isOpenDomain);
            }
            catch (Exception e)
            {
                string error = $"防火墙修改出错：{e.Message}";
                throw new Exception(error);
            }
            return true;
        }

        #endregion


        #region 

        /// <summary>
        /// 从IpList.xml 获取规则集
        /// </summary>
        /// <param name="path">IpList.xml 文件路径</param>
        /// <param name="NumberOfIp">多少个IP拆分成一个规则</param>
        /// <param name="prefix">规则前缀名称</param>
        /// <param name="ruleDirectionTpye">出入站规则类型  入站规则( NET_FW_RULE_DIR_IN ) or 出站规则( NET_FW_RULE_DIR_OUT )</param>
        /// <param name="ipPriticolTpye">通讯协议规则类型 TCP or UDP or  ANY</param>
        /// <param name="actionType">允许连接（NET_FW_ACTION_ALLOW）还是阻止连接（NET_FW_ACTION_BLOCK）</param>
        /// <param name="grouping">规则组名称</param>
        /// <returns></returns>
        public static List<FireWallModel> GetRuleList(string path, int NumberOfIp, string prefix, NET_FW_RULE_DIRECTION_ ruleDirectionTpye, NET_FW_IP_PROTOCOL_ ipPriticolTpye, NET_FW_ACTION_ actionType, string grouping)
        {
            List<FireWallModel> fireWallList = new List<FireWallModel>();

            //读取XML 获取各国家IP更新地址
            var ipDataBase = XmlHelp.ReadXML(path);

            foreach (var item in ipDataBase)
            {
                if (item.IsChina == 0)
                {
                    var allips = Regex.Matches(item.IpList, @"((\b((([0-9A-Fa-f]{1,4}:){7}([0-9A-Fa-f]{1,4}|:))|(([0-9A-Fa-f]{1,4}:){6}(:[0-9A-Fa-f]{1,4}|((25[0-5]|2[0-4]d|1dd|[1-9]?d)(.(25[0-5]|2[0-4]d|1dd|[1-9]?d)){3})|:))|(([0-9A-Fa-f]{1,4}:){5}(((:[0-9A-Fa-f]{1,4}){1,2})|:((25[0-5]|2[0-4]d|1dd|[1-9]?d)(.(25[0-5]|2[0-4]d|1dd|[1-9]?d)){3})|:))|(([0-9A-Fa-f]{1,4}:){4}(((:[0-9A-Fa-f]{1,4}){1,3})|((:[0-9A-Fa-f]{1,4})?:((25[0-5]|2[0-4]d|1dd|[1-9]?d)(.(25[0-5]|2[0-4]d|1dd|[1-9]?d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){3}(((:[0-9A-Fa-f]{1,4}){1,4})|((:[0-9A-Fa-f]{1,4}){0,2}:((25[0-5]|2[0-4]d|1dd|[1-9]?d)(.(25[0-5]|2[0-4]d|1dd|[1-9]?d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){2}(((:[0-9A-Fa-f]{1,4}){1,5})|((:[0-9A-Fa-f]{1,4}){0,3}:((25[0-5]|2[0-4]d|1dd|[1-9]?d)(.(25[0-5]|2[0-4]d|1dd|[1-9]?d)){3}))|:))|(([0-9A-Fa-f]{1,4}:){1}(((:[0-9A-Fa-f]{1,4}){1,6})|((:[0-9A-Fa-f]{1,4}){0,4}:((25[0-5]|2[0-4]d|1dd|[1-9]?d)(.(25[0-5]|2[0-4]d|1dd|[1-9]?d)){3}))|:))|(:(((:[0-9A-Fa-f]{1,4}){1,7})|((:[0-9A-Fa-f]{1,4}){0,5}:((25[0-5]|2[0-4]d|1dd|[1-9]?d)(.(25[0-5]|2[0-4]d|1dd|[1-9]?d)){3}))|:)))(%.+)?s*(\/([0-9]|[1-9][0-9]|1[0-1][0-9]|12[0-8]))?\b)(?!\/))|((\b([0-9]{1,3}\.){3}[0-9]{1,3}(\/([0-9]|[1-2][0-9]|3[0-2]))?\b)(?!\/))", RegexOptions.IgnoreCase)
                                 .Cast<Match>()
                                 .Select(m => m.Value)
                                 .ToList();


                    int frequency = 0;
                    while (allips.Count >= 1)
                    {
                        frequency++;
                        List<string> listIP = new List<string>();
                        listIP.AddRange(allips.Take(NumberOfIp));

                        if (allips.Count >= NumberOfIp)
                        {
                            allips.RemoveRange(0, NumberOfIp);
                        }
                        else if (allips.Count > 0 && allips.Count < NumberOfIp)
                        {
                            allips.RemoveRange(0, allips.Count);
                        }

                        string newIpList = "";
                        foreach (string ip in listIP)
                        {
                            newIpList += ip + ',';
                        }
                        newIpList = newIpList.Remove(newIpList.Length - 1);

                        FireWallModel ruleModel = new FireWallModel();
                        ruleModel.RuleName = prefix + item.Country + "_" + frequency.ToString();
                        ruleModel.RuleDescription = prefix + item.Country + "_" + frequency.ToString() + "规则描述";
                        ruleModel.RuleDirectionTpye = ruleDirectionTpye;
                        ruleModel.IpPriticolTpye = ipPriticolTpye;
                        ruleModel.ActionType = actionType;
                        ruleModel.AppPath = null;
                        ruleModel.LocalAddresses = null;
                        ruleModel.LocalPorts = null;
                        ruleModel.RemoteAddresses = newIpList;
                        ruleModel.RemotePorts = null;
                        ruleModel.Grouping = grouping;

                        fireWallList.Add(ruleModel);
                    }

                }
            }

            return fireWallList;

        }


        #endregion 
    }
}
