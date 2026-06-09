# 1.课程大纲

![image-20260608180057165](./note10-设置依赖注入.assets/image-20260608180057165.png)

# 2.在c#代码在实例化主窗口

## 打开我们的项目，打开App.xaml,可以看到Application标签有一个属性： StartupUri="MainWindow.xaml"，它指向我们的主窗口的界面文件。

![image-20260608181717263](./note10-设置依赖注入.assets/image-20260608181717263.png)

### 但是如果你需要在程序中使用依赖注入，我们需要用c#代码来创建主窗口的实例

## 我们把这个属性删除

![image-20260608183036794](./note10-设置依赖注入.assets/image-20260608183036794.png)

## 然后我们进入App.xaml.cs代码中，重写OnStartup方法，在里面调用玩基类的OnStartup方法后，创建一个MainWindow类的实例标签调用他的Show方法来显示窗口

![image-20260608192015804](./note10-设置依赖注入.assets/image-20260608192015804.png)



## 运行程序，一切正常

![image-20260608192056961](./note10-设置依赖注入.assets/image-20260608192056961.png)

## 我们回到MainWindow.xaml.cs,修改MainWindow的构造函数的参数

![image-20260608192935374](./note10-设置依赖注入.assets/image-20260608192935374.png)

## 然后我们回到App.xaml.cs，修改一下创建主窗口的代码

![image-20260608193815282](./note10-设置依赖注入.assets/image-20260608193815282.png)

## 运行程序，一切正常

![image-20260608193857280](./note10-设置依赖注入.assets/image-20260608193857280.png)

## 注意，这种方式还是不够好，我们下一节会学习如何使用依赖注入来实现



# 3.设置依赖注入

## 1.我们在项目的依赖项文件夹上面点击右键-》管理nuget程序包

![image-20260608194257736](./note10-设置依赖注入.assets/image-20260608194257736.png)



## 2.点击浏览选项卡，然后在搜索框里面输入：dependencyinject，然后选择：Microsoft.Extensions.DependencyInjection，选择6.0.0版本，然后点击安装

![image-20260608200158434](./note10-设置依赖注入.assets/image-20260608200158434.png)

## 3.在弹出的窗口中点击应用

![image-20260608200214556](./note10-设置依赖注入.assets/image-20260608200214556.png)

## 4.然后就安装好了，注意版本太高可能不能使用。

![image-20260608200331319](./note10-设置依赖注入.assets/image-20260608200331319.png)

## 5.回到App.xaml.cs中，给App类创建一个构造函数，在里面创建一个ServiceCollection对象（需要引入我们上面的包），然后把它作为参数传递给还没有创建的方法ConfigureServices，然后我们创建这个方法

![image-20260608200725192](./note10-设置依赖注入.assets/image-20260608200725192.png)

## 6.我们在ConfigureServices方法在注册所有我们需要的依赖项

![image-20260608201414877](./note10-设置依赖注入.assets/image-20260608201414877.png)

## 7.回到App类的构造函数，添加一个ServiceProvider类型的只读字段 _serviceProvider并且接受services对象的BuildServiceProvider()方法的返回值

![image-20260608201937848](./note10-设置依赖注入.assets/image-20260608201937848.png)

## 然后我们来修改一下创建主窗口的代码，用这个访问提供对象的getService方法来创建对象

![image-20260608202319582](./note10-设置依赖注入.assets/image-20260608202319582.png)

## 运行程序一切正常

![image-20260608202511582](./note10-设置依赖注入.assets/image-20260608202511582.png)

## App.xaml.cs的完整代码如下

```
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WiredbrainCoffeeApp.Data;
using WiredbrainCoffeeApp.ViewModel;

namespace WiredbrainCoffeeApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider _serviceProvider;

        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            _serviceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {   //添加所有依赖
            services.AddTransient<MainWindow>();
            services.AddTransient<MainViewModel>();
            services.AddTransient<CustomerViewModel>();
            services.AddTransient<ProductViewModel>();
            services.AddTransient<ICustomerDataProvider, CustomerDataProvider>();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //创建MainWindow类的实例
            var mainWin = _serviceProvider.GetService<MainWindow>();
            mainWin?.Show(); 
        }
    }

}

```



# 4.注册并且使用其他类型

## 1.我们需要在Model文件夹里面创建一个Product类，内容如下

```
namespace WiredbrainCoffeeApp.Model
{
    public class Product
    {
        public string? Name { get; set; } 
        public string? Description { get; set; }  
    }
}

```

## 2.然后我们需要在Data文件夹里面创建一个ProductDataProvider类，代码如下

```
using WiredbrainCoffeeApp.Model;

namespace WiredbrainCoffeeApp.Data
{
    public interface IProductDataProvider
    {
        Task<IEnumerable<Product>> getAllAsync();   
    }
    public class ProductDataProvider : IProductDataProvider
    {
        public async Task<IEnumerable<Product>?> getAllAsync()
        {
            await Task.Delay(100); // Simulate a bit of server work

            return new List<Product>
            {
                new Product{Name="Cappuccino",Description="Espresso with milk and milk foam"},
                new Product{Name="Doppio",Description="Double espresso"},
                new Product{Name="Espresso",Description="Pure coffee to keep you awake! :-)"},
                new Product{Name="Latte",Description="Cappuccino with more streamed milk"},
                new Product{Name="Macchiato",Description="Espresso with milk foam"},
                new Product{Name="Mocha",Description="Espresso with hot chocolate and milk foam"}
            };
        }
    }
}

```

## 3.然后转到App.xaml.cs,利用依赖注入来正常这个ProductDataProvider类供其他视图使用

![image-20260609105016751](./note10-设置依赖注入.assets/image-20260609105016751.png)

## 4.转到ProductDataProvider.cs视图模型类，在这里获取调用获取数据的方法

### 4.1 给它添加一个构造函数，并且创建一个私有字段来接受传递过来的对象（依赖注入)

![image-20260609110438454](./note10-设置依赖注入.assets/image-20260609110438454.png)

### 4.2 然后我们在构造函数里面设置一个断点调试发现它的确有值，说明依赖注入有效

![image-20260609110348138](./note10-设置依赖注入.assets/image-20260609110348138.png)

### 4.3创建一个ObservableCollection\<Product>类型的属性Products,是一个只读属性，只有getter

![image-20260609110946820](./note10-设置依赖注入.assets/image-20260609110946820.png)



### 4.4重写基类的LoadAsync方法

![image-20260609111810575](./note10-设置依赖注入.assets/image-20260609111810575.png)

## 5.转到ProductsView.xaml中，我们来显示产品

### 5.1把TextBlock删除，然后添加一个DataGrid

![image-20260609112253735](./note10-设置依赖注入.assets/image-20260609112253735.png)

## 运行程序，选择Products菜单，效果如下

![image-20260609112407204](./note10-设置依赖注入.assets/image-20260609112407204.png)

![image-20260609112438268](./note10-设置依赖注入.assets/image-20260609112438268.png)
