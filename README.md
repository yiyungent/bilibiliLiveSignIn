<h1 align="center">bilibiliLiveSignIn</h1>

> B站直播签到

[![repo size](https://img.shields.io/github/repo-size/yiyungent/bilibiliLiveSignIn.svg?style=flat)]()
[![LICENSE](https://img.shields.io/github/license/yiyungent/bilibiliLiveSignIn.svg?style=flat)](https://mit-license.org/)

## 简介

bilibiliLiveSignIn 告别每天手动签到，让程序每天帮你签到

## 功能

- [x] B站直播签到
- [x] B站银瓜子换硬币

## 快速搭建

1. 下载发布部署包 <a href="https://github.com/yiyungent/bilibiliLiveSignIn/releases/download/v0.1.0/bilibiliLiveSignIn_publish_0.1.0.zip" target="_blank">bilibiliLiveSignIn_publish_0.1.0.zip</a>
2. 浏览器打开 <a href="https://live.bilibili.com/" target="_blank">哔哩哔哩直播</a>，通过 F12 获取其中的 Cookie
3. 解压 Publish.zip，将获得的 cookie 保存到 cookie.txt，将 Publish 文件夹下的所有文件上传到 Web服务器的根目录（虚拟主机也可用，可使用 https://www.gearhost.com/ 提供的免费主机）
4. 如需每天自动签到，并自动将银瓜子兑换为硬币，则设置定时任务 每天访问 签到（http(s)://你的域名/api/signin.ashx ），银瓜子换硬币（http(s)://你的域名/api/silver2coin.ashx ）即可
5. 完成搭建

## 环境

- 运行环境：.NET Framework 4.5+    
- 开发环境：Visual Studio Community 2017
