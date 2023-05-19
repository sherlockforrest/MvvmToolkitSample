namespace MvvmToolkit;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private Mutex mutex;
    protected override void OnStartup(StartupEventArgs e)
    {
        //防止程序多开
        mutex = new Mutex(true, nameof(MvvmToolkit.MainWindow), out bool ret);
        if (!ret)
        {
            MessageBox.Show("软件已经在运行中，请检查！！");
            Environment.Exit(0);
        }
        InitialServices();

        new MainWindow().Show();
        base.OnStartup(e);
    }

    private void InitialServices()
    {
        var services = new ServiceCollection();
        //单一实例服务 每一次获取的对象都是同一个
        // services.AddSingleton<IRecipient<InfoMessage>, MessengerViewModel>();

        //暂时性服务   请求获取-（GC回收-主动释放）  获取时创建 每一次获取的对象都不是同一个
        services.AddTransient<MainWindowViewModel>();

        services.AddTransient<MessengerViewModel>();
        
        var provider = services.BuildServiceProvider();
       
        Ioc.Default.ConfigureServices(provider);
    }
}