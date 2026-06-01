# 0.课程大纲

![image-20260531093440410](./note06-应用数据绑定和mvvm.assets/image-20260531093440410.png)

# 1.绑定到另外一个元素

### 1》打开我们下coffee项目，打开CustomersView.xaml文件，给ListView添加一个名称引用customerListView.

![image-20260531093924768](./note06-应用数据绑定和mvvm.assets/image-20260531093924768.png)

### 2》然后我们在下面的客户详情的textbox中引用这个列表的数据，注意这种引用的语法

![image-20260531094622268](./note06-应用数据绑定和mvvm.assets/image-20260531094622268.png)

### 效果

![image-20260531094650916](./note06-应用数据绑定和mvvm.assets/image-20260531094650916.png)

### 注意，你修改右边的内容，左边没有改变但是如果你点击一下下面的文本框，它会更新，也就是默认是双向模型

![image-20260531094753117](./note06-应用数据绑定和mvvm.assets/image-20260531094753117.png)

![image-20260531094928767](./note06-应用数据绑定和mvvm.assets/image-20260531094928767.png)

### 你可以修改他的绑定模式

![image-20260531095831812](./note06-应用数据绑定和mvvm.assets/image-20260531095831812.png)

![image-20260531095939577](./note06-应用数据绑定和mvvm.assets/image-20260531095939577.png)

### 我们给他添加Mode="TwoWay" ,虽然他是默认值，但是这样子更加清晰，其实我们可以让数据马上更新，需要设置UpdateSourceTrigger属性为PropertyChanged

![image-20260531101359357](./note06-应用数据绑定和mvvm.assets/image-20260531101359357.png)



# 2.理解数据上下文工作原理

![image-20260531101940943](./note06-应用数据绑定和mvvm.assets/image-20260531101940943.png)

![image-20260531102026369](./note06-应用数据绑定和mvvm.assets/image-20260531102026369.png)

![image-20260531102239650](./note06-应用数据绑定和mvvm.assets/image-20260531102239650.png)

![image-20260531102417416](./note06-应用数据绑定和mvvm.assets/image-20260531102417416.png)

![image-20260531102545673](./note06-应用数据绑定和mvvm.assets/image-20260531102545673.png)

![image-20260531102711991](./note06-应用数据绑定和mvvm.assets/image-20260531102711991.png)

![image-20260531102805971](./note06-应用数据绑定和mvvm.assets/image-20260531102805971.png)

![image-20260531103024090](./note06-应用数据绑定和mvvm.assets/image-20260531103024090.png)

![image-20260531103144504](./note06-应用数据绑定和mvvm.assets/image-20260531103144504.png)

![image-20260531103230606](./note06-应用数据绑定和mvvm.assets/image-20260531103230606.png)

### 所谓的更复杂对象，就是指MVVM

# 3.MVVM （Model-View-ViewModel)

## 什么是wpf的mvvm？

WPF的MVVM是一种专为WPF设计的软件架构模式，它通过将UI界面（View）、业务数据（Model）和控制逻辑（ViewModel）彻底分离，实现代码的高内聚、低耦合。 [[1](https://learn.microsoft.com/zh-tw/dotnet/architecture/maui/mvvm), [2](https://blog.csdn.net/lweiyue/article/details/88861896), [3](https://cloud.tencent.com/developer/article/1493711)]

它主要由以下三个部分组成：

- **View（视图）**：用户的交互界面，通常由 XAML 文件定义。它只负责展示数据，不编写任何业务逻辑。
- **ViewModel（视图模型）**：视图的抽象，是 MVVM 的核心。它包含了界面的状态数据和触发逻辑（如点击按钮后的操作），但不直接引用 View。
- **Model（模型）**：包含真实的业务逻辑、数据实体和数据访问操作（如调用API、数据库读写等）。 [[1](https://www.cnblogs.com/mingupupu/p/18218027), [2](https://developer.aliyun.com/article/1330825), [3](https://learn.microsoft.com/zh-tw/dotnet/architecture/maui/mvvm)]

为什么在WPF中要使用MVVM？

WPF 拥有强大的**数据绑定（Data Binding）**和**命令（Command）**机制，MVVM 完美契合了这一特性。它的优势包括： [[1](https://cloud.tencent.com/developer/article/1493711), [2](https://developer.aliyun.com/article/1330825)]

1. **彻底解耦**：UI 界面和业务逻辑分离，设计师可以专心设计 XAML，开发人员编写后台逻辑，互不干扰。
2. **便于测试**：因为 ViewModel 不依赖具体的 UI 控件，开发者可以很容易地编写单元测试来验证业务逻辑。
3. **易于维护**：当 UI 样式改变时，后台逻辑代码通常不需要修改；反之亦然。 [[1](https://learn.microsoft.com/zh-tw/dotnet/architecture/maui/mvvm), [2](https://cloud.tencent.com/developer/article/1493711)]

它们是如何协同工作的？

- **数据绑定 (Binding)**：当 ViewModel 中的数据改变时，View 会自动同步更新显示；当用户在 View 中输入数据时，ViewModel 中的对应属性也会自动更新（双向绑定）。 [[1](https://cloud.tencent.com/developer/article/1493711), [2](https://developer.aliyun.com/article/1330825)]

- **命令绑定 (Command)**：View 中的操作（如点击按钮）会通过 `Command` 属性直接映射到 ViewModel 中的方法，从而代替了传统的事件响应。

  ### 了解更多开发细节，可参考微软官方的 [WPF MVVM 架构指南](https://learn.microsoft.com/zh-tw/dotnet/architecture/maui/mvvm)。在实际开发中，开发者通常会借助如 CommunityToolkit.Mvvm、Prism 或 MVVM Light 等现成的 MVVM 框架来简化开发流程

## 使用MVVM的好处

在WPF中使用MVVM（Model-View-ViewModel）的核心好处是**彻底分离UI界面与业务逻辑**。这得益于WPF强大的**数据绑定（Data Binding）**机制，它能带来以下显著优势： [[1](https://www.reddit.com/r/csharp/comments/8dlt0s/eli5_mvvm_and_its_benefits/?tl=zh-hans), [2](https://opc.csdn.net/696df41e437a6b4033690b10.html), [3](https://www.volcengine.com/article/603695)]

- **高度解耦：** 视图（XAML）和业务逻辑（ViewModel）完全独立。UI设计师可以专注于界面外观，开发人员可以专注于数据和逻辑，互不干扰。
- **便于单元测试：** 业务逻辑被封装在ViewModel中，不依赖具体的UI控件，因此可以非常轻松地为ViewModel编写自动化单元测试。
- **提升代码复用性：** 一个ViewModel可以被多个不同的View复用，或者针对不同平台（如UWP、MAUI）使用相同的业务逻辑。
- **自动同步与高效开发：** 通过双向数据绑定，无需编写复杂的代码来手动更新UI或捕获输入，数据状态改变时界面会自动刷新

## MVVM设计模式图解

![image-20260531111736119](./note06-应用数据绑定和mvvm.assets/image-20260531111736119.png)

![image-20260531111807468](./note06-应用数据绑定和mvvm.assets/image-20260531111807468.png)

![image-20260531111917162](./note06-应用数据绑定和mvvm.assets/image-20260531111917162.png)

![image-20260531112053109](./note06-应用数据绑定和mvvm.assets/image-20260531112053109.png)

![image-20260531112130395](./note06-应用数据绑定和mvvm.assets/image-20260531112130395.png)

# 4.创建CustomersViewModel

### 打开我们的coffeeapp项目，在项目名称上面点击右键-》添加-》文件夹，改名给为Model，然后创建一个Customer类

![image-20260531120007771](./note06-应用数据绑定和mvvm.assets/image-20260531120007771.png)

### 在项目名称上面点击右键-》添加-》文件夹，改名给为Data，然后创建一个DataProvider类，

![image-20260531121742867](./note06-应用数据绑定和mvvm.assets/image-20260531121742867.png)

### 代码如下

```
using System.Collections.Generic;
using System.Threading.Tasks;
using WiredbrainCoffeeApp.Model;

namespace WiredbrainCoffeeApp.Data
{
  public interface ICustomerDataProvider
  {
    Task<IEnumerable<Customer>?> GetAllAsync();
  }

  public class CustomerDataProvider : ICustomerDataProvider
  {
    public async Task<IEnumerable<Customer>?> GetAllAsync()
    {
      await Task.Delay(100); // Simulate a bit of server work

      return new List<Customer>
      {
        new Customer{Id=1,FirstName="Rudy",LastName="Yang",IsDeveloper=true},
        new Customer{Id=2,FirstName="Angus",LastName="Burns"},
        new Customer{Id=3, FirstName="Nigel",LastName="Woodhouse",IsDeveloper=true},
        new Customer{Id=4,FirstName="Miles",LastName="Foster"},
        new Customer{Id=5,FirstName="Nirmal",LastName="Chaudhury",IsDeveloper=true},
        new Customer{Id=6,FirstName="Chen",LastName="Qian",IsDeveloper=true},
      };
    }
  }
}

```

### 然后我们给项目添加一个ViewModel文件夹

![image-20260531124140976](./note06-应用数据绑定和mvvm.assets/image-20260531124140976.png)

### 然后在里面新建一个CustomerViewModel类

![image-20260531125619162](./note06-应用数据绑定和mvvm.assets/image-20260531125619162.png)

### 这个类的代码如下

```
using System.Collections.ObjectModel;
using WiredbrainCoffeeApp.Data;
using WiredbrainCoffeeApp.Model;



namespace WiredbrainCoffeeApp.ViewModel
{
    public class CustomerViewModel
    {
        public CustomerViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }
        public ObservableCollection<Customer> Customers { get; } = new();
        private readonly ICustomerDataProvider _customerDataProvider;
        public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }
            var customers = await _customerDataProvider.GetAllAsync();
            if (customers is not null)
            {
                foreach (var c in customers)
                {
                    Customers.Add(c);
                }
            }
            
        }
    }
}

```

# 5.在CustomerView中使用ViewModel

## 这一节我们需要把我们的数据绑定到我们的视图中

### 打开CustomerView.xaml.cs，然后添加一些代码，修改后的内容如下

```
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WiredbrainCoffeeApp.Data;
using WiredbrainCoffeeApp.ViewModel;

namespace WiredbrainCoffeeApp.view
{
    /// <summary>
    /// CustomersView.xaml 的交互逻辑
    /// </summary>
    public partial class CustomersView : UserControl
    {
        private CustomerViewModel _viewModel;

        public CustomersView()
        {
            InitializeComponent();
            _viewModel = new CustomerViewModel(new CustomerDataProvider());
            DataContext = _viewModel;
            Loaded += CustomersView_Loaded;
        }

        private async void CustomersView_Loaded(object sender, RoutedEventArgs e)
        {
           await _viewModel.LoadAsync();
        }

        private void BtnMove_Click(object sender, RoutedEventArgs e)
        {
            //写法1，需要强制类型转换，不太好
            //var column = (int)customerListGrid.GetValue(Grid.ColumnProperty);
            //var col = column == 0 ? 2 : 0;
            //customerListGrid.SetValue(Grid.ColumnProperty, col);

            //写法2.使用Grid类的静态方法，不需要转换类型，比较好
            var column = Grid.GetColumn(customerListGrid);
            var col = column == 0 ? 2 : 0;
            Grid.SetColumn(customerListGrid, col);


        }
    }
}

```

### 然后我们回到CustomersView.xaml文件，把以前ListView的硬编码数据删除，然后使用我们在后台代码设置的DataContext属性来作为类别项的数据来源，但是你必须指定使用那个类，以及显示这个类的什么属性

![image-20260531144820625](./note06-应用数据绑定和mvvm.assets/image-20260531144820625.png)

### 需要注意的是，我们下面客户详情的第一个文本框是绑定这个ListView的，但是他的项的数据类型已经从字符串变为对象，我们需要做相应的修改，否则文本框里面不会有任何数据

# 6.添加SelectedCustomer属性

## 在上一节课中，我们成功用后台代码模拟数据库获取客户数据集然后给ListView添加数据绑定，并且修改了文本框和ListView的绑定数据绑定的显示成员

![image-20260531145639482](./note06-应用数据绑定和mvvm.assets/image-20260531145639482.png)

![image-20260531145851672](./note06-应用数据绑定和mvvm.assets/image-20260531145851672.png)

### 这是xaml中的ui逻辑

![image-20260531145950754](./note06-应用数据绑定和mvvm.assets/image-20260531145950754.png)

## 这一节课我们来学习如何将选择逻辑引入视图模型类

![image-20260531150144791](./note06-应用数据绑定和mvvm.assets/image-20260531150144791.png)

![image-20260531150213957](./note06-应用数据绑定和mvvm.assets/image-20260531150213957.png)

![image-20260531150240204](./note06-应用数据绑定和mvvm.assets/image-20260531150240204.png)

## 下面我们就来为我们的CustomerViewModel添加SelectedCustomer属性

### 1》打开我们的项目，然后进入CustomerViewModel.cs文件里面，给这个类添加一个SelectedCustomer属性，注意同时一个可空类型

![image-20260531154657027](./note06-应用数据绑定和mvvm.assets/image-20260531154657027.png)

### 2》回到CustomerView.xaml,用CustomerViewModel的SelectedCustomer给ListView设置SelectedItem属性，然后修改下面的文本框的绑定方式

![image-20260531151946090](./note06-应用数据绑定和mvvm.assets/image-20260531151946090.png)

### 3》我们用同样的方式给第二个文本框和复选框绑定数据

![image-20260531155210593](./note06-应用数据绑定和mvvm.assets/image-20260531155210593.png)

## 运行程序，效果如下

![image-20260531155245073](./note06-应用数据绑定和mvvm.assets/image-20260531155245073.png)

![image-20260531155323176](./note06-应用数据绑定和mvvm.assets/image-20260531155323176.png)

### 一切正常

# 7.实现添加客户的逻辑

### 进入CustomerView.xaml中，给Add按钮添加一个点击事件处理函数BtnAdd_Click,在他的上面点击右键-》转到定义，就可以进入他的代码，我们在那里调用视图模型的Add方法。

![image-20260531162004397](./note06-应用数据绑定和mvvm.assets/image-20260531162004397.png)

### 8》此时此方法还没有创建，我们转到视图模型里面定义这个方法，我们下添加下面的代码

![image-20260531163606660](./note06-应用数据绑定和mvvm.assets/image-20260531163606660.png)



### 运行程序，发现可以添加数据了，但是为什么没有自动选中？因为视图模型没有调整视图修改选中项

![image-20260531163746444](./note06-应用数据绑定和mvvm.assets/image-20260531163746444.png)

# 8.通知属性值变化

## 要实现能够把属性改变通知给视图的功能，我们的视图模型类需要实现一个INotifyPropertyChanged，我们进入这个视图模型类，给他添加这个接口的继承

![image-20260531175716013](./note06-应用数据绑定和mvvm.assets/image-20260531175716013.png)

### 可以看到它只添加了一个event，我们需要从属性的设置器中触发它，我们可以在视图模型中创建一个方法来触发它。

![image-20260531183759663](./note06-应用数据绑定和mvvm.assets/image-20260531183759663.png)

## 然后我们找到SelectedCustomer属性，选中他并且按alt+enter，在弹出窗口中选中转换为完整属性

![image-20260531184141572](./note06-应用数据绑定和mvvm.assets/image-20260531184141572.png)

### 然后这个属性就会生成getter和setter代码

![image-20260531184257627](./note06-应用数据绑定和mvvm.assets/image-20260531184257627.png)

### 然后我们找到selectedCustomer字段，按alt+enter把它改名为_selectedCustomer

![image-20260531184649527](./note06-应用数据绑定和mvvm.assets/image-20260531184649527.png)

![image-20260531184714091](./note06-应用数据绑定和mvvm.assets/image-20260531184714091.png)

### 然后我们需要重构SelectedCustomer中的setter代码，给他添加触发属性更改事件的代码

![image-20260531185127187](./note06-应用数据绑定和mvvm.assets/image-20260531185127187.png)

### 我们可以回到下面的触发方法里面，把参数改为可空类型，并且给他添加一个特性

![image-20260531185422394](./note06-应用数据绑定和mvvm.assets/image-20260531185422394.png)

### 如果添加这个特性后报错，可以按alt+enter，选择using System.Runtime.CompilerService

### 然后我们可以回到上面的setter代码，把触发方法调用的参数删除

![image-20260531190138118](./note06-应用数据绑定和mvvm.assets/image-20260531190138118.png)

### 运行程序，点击添加按钮，发现新添加的项目会被自动选中了。声明调整机制设置成功

![image-20260531190308830](./note06-应用数据绑定和mvvm.assets/image-20260531190308830.png)

# 9.将逻辑重构到ViewModelBase中

### 为了能够把上一节课的事件触发代码可以重复使用，我们可以创建一个视图模型的基类，然后把这个方法剪切到它里面，此外我们还应该让基类属性接口，然后我们的类继承自这个基类，重构后如图

![image-20260531191245687](./note06-应用数据绑定和mvvm.assets/image-20260531191245687.png)

### 然后我们需要把这个基类独立放到应该cs文件中

![image-20260531191328942](./note06-应用数据绑定和mvvm.assets/image-20260531191328942.png)

### 然后这个基类就在应该叫做ViewModelBase.cs的文件中了

![image-20260531191439002](./note06-应用数据绑定和mvvm.assets/image-20260531191439002.png)

### 因为在同一个文件夹中，使用其他类也可以非常容易找到这个基类

# 10.创建CustomerItemViewModel

## 我们以前是直接把数据暴露给视图，这样子有一个弊端，就是数据更改后视图不会更新，我们可以让模型类实现调整接口，但是更好的方法是创建一个代表该模型的一个ViewModel类，这样子视图不需要理解如何模型的信息，是架构上的更好方法。下面，我们就给单个客户创建一个ViewModel类，叫做CustomerItemViewModel

### 1》在ViewModel文件夹下面点击右键-》添加->类，然后创建一个CustomerItemViewModel类，创建后让他继承ViewModelBase类，并且给他创建一个构造函数，添加一个Customer 类型的参数model，然后给类也添加一个model字段

![image-20260531192826806](./note06-应用数据绑定和mvvm.assets/image-20260531192826806.png)

![image-20260531192853539](./note06-应用数据绑定和mvvm.assets/image-20260531192853539.png)

### 然后我们把类的字段添加一个下划线

![image-20260531193049087](./note06-应用数据绑定和mvvm.assets/image-20260531193049087.png)

### 然后我们需要添加必须的属性，修改后的CustomerItemViewModel.cs的代码如下

```
using WiredbrainCoffeeApp.Model;

namespace WiredbrainCoffeeApp.ViewModel
{
    public class CustomerItemViewModel:ViewModelBase
    {
        private readonly Customer _model;

        public CustomerItemViewModel(Customer model)
        {
            _model = model;
        }
        public int Id => _model.Id;
        public string? FirstName { 
            get => _model.FirstName;
            set { 
               _model.FirstName = value;
                RaisePropertyChanged();
            }
        }
        public string? LastName { 
            get => _model.LastName;
            set { 
               _model.LastName = value;
                RaisePropertyChanged();
            }
        }
        public bool IsDeveloper { 
            get => _model.IsDeveloper;
            set { 
               _model.IsDeveloper = value;
                RaisePropertyChanged();
            }
        }


    }

    
}

```

### 然后我们需要回到CustomViewModel中修改一些直接暴露模型数据给view的代码,修改后的代码如下

```
using System.Collections.ObjectModel;
using WiredbrainCoffeeApp.Data;
using WiredbrainCoffeeApp.Model;



namespace WiredbrainCoffeeApp.ViewModel
{
    public class CustomerViewModel:ViewModelBase
    {
        public CustomerViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
        }
        
        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();
        public CustomerItemViewModel? SelectedCustomer { get => _selectedCustomer; 
            set { 
                _selectedCustomer = value; 
                //RaisePropertyChanged(nameof(SelectedCustomer)); //触发属性更改事件
                RaisePropertyChanged(); //触发属性更改事件
            } 
        }
        private readonly ICustomerDataProvider _customerDataProvider;
        private CustomerItemViewModel? _selectedCustomer;

    public async Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }
            var customers = await _customerDataProvider.GetAllAsync();
            if (customers is not null)
            {
                foreach (var c in customers)
                {
                    Customers.Add(new CustomerItemViewModel(c));
                }
            }
            
        }

        internal void Add()
        {
            var customer = new Customer { FirstName = "New" };
            var viewModel = new CustomerItemViewModel(customer); 
            Customers.Add(viewModel);
            SelectedCustomer = viewModel;
        }

    }
}

```

### 运行程序，效果是一样的（略）







