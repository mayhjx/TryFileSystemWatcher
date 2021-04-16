using System;
using System.IO;

namespace TryFileSystemWatcher
{
    class Watcher
    {
        static void Main(string[] args)
        {
            // 如果没有指定目录，则退出程序
            if (args.Length != 1)
            {
                // 显示调用程序的正确方法
                Console.WriteLine("usage: Watcher.ext(directory)");
                return;
            }

            FileSystemWatcher watcher = new FileSystemWatcher();
            watcher.Path = args[0];

            // 监视LastAccess和LastWrite时间的更改以及文件或目录的重命名
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite |
                NotifyFilters.FileName | NotifyFilters.DirectoryName;

            // 只监视文本文件
            watcher.Filter = "*.txt";

            // 添加事件句柄
            // 当由FileSystemWatcher所指定的路径中的文件或目录的
            // 大小、系统属性、最后写时间、最后访问时间或安全权限
            // 发生更改时，更改事件就会发生。
            watcher.Changed += new FileSystemEventHandler(OnChange);
            //文件或目录被创建时触发
            watcher.Created += new FileSystemEventHandler(OnChange);
            //文件或目录被删除时触发
            watcher.Deleted += new FileSystemEventHandler(OnChange);
            //文件或目录被重命名时触发
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // 开始监视
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press\'q\' to quit the sample.");
            while (Console.Read() != 'q') ;
        }

        public static void OnChange(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"File: {e.FullPath} {e.ChangeType}");
        }
        public static void OnRenamed(object sender, RenamedEventArgs e)
        {
            Console.WriteLine($"File:{e.OldFullPath} renamed to {e.FullPath}");
        }
    }
}
