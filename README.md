# QiuLinFireWall
个人使用网盾、WindowsDefender防火墙IP黑名单、一键禁用国外IP访问、自定义防火墙规则

本程序基于.NET Framework 4.6.2 、操作系统COM组件 NetFwTypeLib来管理Windows防火墙规则 

程序自带国外IP地址库来源于 https://github.com/metowolf/iplist

使用说明：

1、一键禁用国外IP访问， 点击【启用禁止国外IP访问规则】即可

![image](https://user-images.githubusercontent.com/53858121/164968207-6433cfb5-4455-4454-b5a1-bea2f8d3b13b.png)

2、自定义IP黑名单：

               1、输入规则名称
               
               2、出入站类型选择：入站
               
               3、通讯协议选择：ANY（任何）
               
               4、连接类型选择：阻止连接
               
               5、应用程序：选填，不填表示所有程序
               
               6、在远程IP地址栏填写 ：黑名单IP
               
               7、点击【添加规则】
               


![企业微信截图_16507893898127](https://user-images.githubusercontent.com/53858121/164967861-d8007765-9ea7-4306-987b-7bf7910b7ad6.png)
