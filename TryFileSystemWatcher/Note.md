## FileSystemWatcher

可以使用FileSystemWatcher组件监视文件系统，并对文件系统的改变作出反应。
通过使用FileSystemWatcher组件，在特定的文件或目录被创建、修改或删除时，可以快速和便捷地启动业务流程。
例如，如果一组用户在合作处理一个存储在服务器共享目录下的文档时，可以使用FileSystemWatcher组件编写应用程序来监视对共享目录的更改情况。
当检测到更改时，该组件可以运行处理过程，通过电子邮件通知每个用户。

可以配置组件来监视整个目录及其内容，或特定目录下一个特定的文件或一组文件。
若要监视所有文件中的更改，应将Filter属性设置为空字符串（""）；
若要监视特定的文件，应将Filter属性设置为该文件的文件名（例如，若要监视文件MyDoc.txt中的更改，将Filter属性设置为"MyDoc.txt"）；
也可以监视特定文件类型中的更改，例如若要监视文本文件中的更改，将Fillter属性设置为"*.txt"。

【提示】不要忽略隐藏文件。

可监视目录或文件中的若干种更改。
例如，可监视文件或目录的Attributes、LastWrite的日期和时间或Size的更改。
通过将FileSystemWatcher.NotifyFilter属性设置为NotifyFilters中的某个值，就可以实现这个目标。

还可以监视文件或目录的重命名、删除或创建。
例如，若要监视文本文件的重命名，可将Filter属性设置为"*.txt"，并调用一个WaitForChanged方法，并设置该方法中WatcherChangeTypes的值为Renamed。