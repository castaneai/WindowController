WindowController
=================

.NETで他のプロセスのウィンドウを操作するクラス

使い方
-------------
WindowController.Windowクラスをプロセス名を引数としてnewする。

```c#
var window = new WindowController.Window("processName");
```

現在の機能
-----------------
- 指定ウィンドウを前面に表示する（アクティブにせずに）
```c#
window.BringWindowToTopWithoutActivation();
```


- 指定ウィンドウのスクリーンショットを撮影しBitmapオブジェクトで取得する
```c#
var bitmap = window.CaptureImage();
```