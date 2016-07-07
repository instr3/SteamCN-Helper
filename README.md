# SteamCN-Helper

一个小程序，用于自动获取和比较steamcn.com中交易区的价格信息，为购买者提供便利（论坛不能搜索帖子内容）。

![maimaimai](http://steamcn.com/static/image/smiley/steamcn_8/kbc171.gif)
![maimaimai](http://steamcn.com/static/image/smiley/steamcn_8/kbc171.gif)
![maimaimai](http://steamcn.com/static/image/smiley/steamcn_8/kbc171.gif)

采用正则表达式匹配的方法，可以匹配交易区主题内每一行的价格信息（例如“xxx：十腿”）或者价格上下文（例如“以下每个5毛”），准确度接近90%。

## 使用方法

* 使用前请在程序中登陆，不然无法访问SteamCN交易区
* 设置页数并点击“加载”后可以自动扫描这几页的SteamCN交易区（文字版）中未缓存或者更新过的页面
* 点选“强制更新”强制刷新所有缓存过的页面
* 在搜索框中键入游戏名称（同一个游戏有不同名称可以用分号隔开），点击“新”可以插入到愿望单
* 双击结果视图中每个价格标签可以直接跳转到原贴页面买买买。

## 截图

![Test](https://github.com/instr3/SteamCN-Helper/raw/master/sample/sample.jpg)