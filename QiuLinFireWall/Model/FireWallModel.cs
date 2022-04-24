using NetFwTypeLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QiuLinFireWall.Model
{
    public class FireWallModel
    {
        /// <summary>
        /// 规则名称
        /// </summary>
        public string RuleName { get; set; }
        /// <summary>
        /// 规则描述
        /// </summary>
        public string RuleDescription { get; set; }
        /// <summary>
        /// 出入站规则类型  入站规则( NET_FW_RULE_DIR_IN ) or 出站规则( NET_FW_RULE_DIR_OUT )
        /// </summary>
        public NET_FW_RULE_DIRECTION_ RuleDirectionTpye { get; set; } = NET_FW_RULE_DIRECTION_.NET_FW_RULE_DIR_IN;
        /// <summary>
        /// 通讯协议规则类型 TCP or UDP or  ANY
        /// </summary>
        public NET_FW_IP_PROTOCOL_ IpPriticolTpye { get; set; } = NET_FW_IP_PROTOCOL_.NET_FW_IP_PROTOCOL_ANY;
        /// <summary>
        /// 允许连接（NET_FW_ACTION_ALLOW）还是阻止连接（NET_FW_ACTION_BLOCK）
        /// </summary>
        public NET_FW_ACTION_ ActionType { get; set; } = NET_FW_ACTION_.NET_FW_ACTION_BLOCK;
        /// <summary>
        /// 应用程序完整路径 （null 表示所有程序）
        /// </summary>
        public string AppPath { get; set; }
        /// <summary>
        /// 本地地址
        /// </summary>
        public string LocalAddresses { get; set; }
        /// <summary>
        /// 本地端口
        /// </summary>
        public string LocalPorts { get; set; }
        /// <summary>
        /// 远端地址
        /// </summary>
        public string RemoteAddresses { get; set; }
        /// <summary>
        /// 远端端口
        /// </summary>
        public string RemotePorts { get; set; }

        /// <summary>
        /// 规则组名称
        /// </summary>
        public string Grouping { get; set; } = "QiuLinFireWallGroups";
    }
}
