# 0.课程概要

![image-20260601132607960](./note07-使用命令在视图中执行代码.assets/image-20260601132607960.png)

# 1.理解命令与MVVM

### 视图- 视图模型的缺点

![image-20260601132753769](./note07-使用命令在视图中执行代码.assets/image-20260601132753769.png)

![image-20260601132900619](./note07-使用命令在视图中执行代码.assets/image-20260601132900619.png)

![image-20260601133011035](./note07-使用命令在视图中执行代码.assets/image-20260601133011035.png)

![image-20260601133207742](./note07-使用命令在视图中执行代码.assets/image-20260601133207742.png)

![image-20260601133248869](./note07-使用命令在视图中执行代码.assets/image-20260601133248869.png)

## 更好的方法是使用命令属性和视图模型的事件处理方法连接起来，我们先来了解按钮的Command属性

![image-20260601133331425](./note07-使用命令在视图中执行代码.assets/image-20260601133331425.png)

![image-20260601134928625](./note07-使用命令在视图中执行代码.assets/image-20260601134928625.png)

![image-20260601135006746](./note07-使用命令在视图中执行代码.assets/image-20260601135006746.png)

![image-20260601135032294](./note07-使用命令在视图中执行代码.assets/image-20260601135032294.png)

![image-20260601135102455](./note07-使用命令在视图中执行代码.assets/image-20260601135102455.png)

![image-20260601135135052](./note07-使用命令在视图中执行代码.assets/image-20260601135135052.png)

![image-20260601135202175](./note07-使用命令在视图中执行代码.assets/image-20260601135202175.png)

![image-20260601135224874](./note07-使用命令在视图中执行代码.assets/image-20260601135224874.png)

![image-20260601135255359](./note07-使用命令在视图中执行代码.assets/image-20260601135255359.png)

![image-20260601135320242](./note07-使用命令在视图中执行代码.assets/image-20260601135320242.png)

## 那么按钮和视图模型的事件处理方法如何连接呢

![image-20260601140924444](./note07-使用命令在视图中执行代码.assets/image-20260601140924444.png)

![image-20260601140316553](./note07-使用命令在视图中执行代码.assets/image-20260601140316553.png)

## 问题来了，这个AddCommand应该任何把视图上面的按钮和视图模型里面的事件处理函数连接起来呢，答案是需要应该实现了ICommand接口的代理类

![image-20260601140607292](./note07-使用命令在视图中执行代码.assets/image-20260601140607292.png)

![image-20260601141007131](./note07-使用命令在视图中执行代码.assets/image-20260601141007131.png)

![image-20260601141041191](./note07-使用命令在视图中执行代码.assets/image-20260601141041191.png)

![image-20260601141139198](./note07-使用命令在视图中执行代码.assets/image-20260601141139198.png)

![image-20260601141230882](./note07-使用命令在视图中执行代码.assets/image-20260601141230882.png)

![image-20260601141345878](./note07-使用命令在视图中执行代码.assets/image-20260601141345878.png)

![image-20260601141426891](./note07-使用命令在视图中执行代码.assets/image-20260601141426891.png)

# 2.创建DelegateCommand类p48

## 1》给项目添加应该Command文件夹并且在里面创建一个DelegateCommand类，注意，必须是public的而且需要实现ICommand接口

![image-20260601145636653](./note07-使用命令在视图中执行代码.assets/image-20260601145636653.png)



## 2》然后，我们需要给他添加一个带参数构造函数并且创建一个_execute私有字段来接收它

![image-20260601150919206](./note07-使用命令在视图中执行代码.assets/image-20260601150919206.png)



## 注意：此时this关键字可以移除

## 然后我们给Execute方法添加代码

![image-20260601151220345](./note07-使用命令在视图中执行代码.assets/image-20260601151220345.png)

## 由于这个方法只有一句代码所以可以简化如下

![image-20260601151357716](./note07-使用命令在视图中执行代码.assets/image-20260601151357716.png)

## 然后我们需要对菜单进来的execute对象进行空值处理，还需要给构造函数添加一个参数方便我们编写CanExecute方法，注意这个参数可以为空

![image-20260601152825734](./note07-使用命令在视图中执行代码.assets/image-20260601152825734.png)

## 然后我们来编写CanExecute方法

![image-20260601153223635](./note07-使用命令在视图中执行代码.assets/image-20260601153223635.png)

## 这个方法与可以简写

![image-20260601153423937](./note07-使用命令在视图中执行代码.assets/image-20260601153423937.png)

## 然后我们需要创建一个RaiseCanExecuteChanged方法来触发属性变更通知机制，代码如下

![image-20260601172338596](./note07-使用命令在视图中执行代码.assets/image-20260601172338596.png)

## 这个类的完整的代码如下

```
using System.Windows.Input;

namespace WiredbrainCoffeeApp.Command
{
    public class DelegateCommand : ICommand
    {
        private readonly Action<object?> _exectue;
        private readonly Func<object?, bool>? _canExecute;

        public DelegateCommand(Action<object?> exectue,Func<object?,bool>? canExecute =null) 
        {
            ArgumentNullException.ThrowIfNull(exectue);
            _exectue = exectue;
            _canExecute = canExecute;
        }
        public event EventHandler? CanExecuteChanged;
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object? parameter) => _canExecute is null || _canExecute(parameter);

        public void Execute(object? parameter)=> _exectue(parameter);
        
    }
}

```

# 3.在ViewModel中使用DelegateCommand

## 这一节课我们把CustomersView的后台代码中的事件处理函数移除，然后CustomersView.xaml的按钮直接和视图模型的函数绑定，首先我们需要进入CustomerViewModel类，给Add方法和MoveNavigation方法添加一个参数，并且把他们变为private

![image-20260601174323926](./note07-使用命令在视图中执行代码.assets/image-20260601174323926.png)

## 然后创建一个只读属性AddCommand，进入构造函数用它来接受一个DelegateCommand类的实例

![image-20260601175034643](./note07-使用命令在视图中执行代码.assets/image-20260601175034643.png)

## 然后我们创建一个MoveNavigationCommand属性在构造函数中用它来接受一个DelegateCommand对象，参数是我们的MoveNavigation方法

![image-20260601175400753](./note07-使用命令在视图中执行代码.assets/image-20260601175400753.png)

## 现在需要在CustomersView.xaml中给按钮绑定我们的AddCommand和MoveNavigationCommand，我们先进入这个视图的后台文件，把那两个按钮的事件处理函数删除，因为我们现在不需要他们

![image-20260601180002268](./note07-使用命令在视图中执行代码.assets/image-20260601180002268.png)

## 回到CustomerView.xaml文件，给按钮绑定Command属性并且删除Click事件绑定，因为已经不需要了

![image-20260601180532777](./note07-使用命令在视图中执行代码.assets/image-20260601180532777.png)

## 运行程序一切正常

![image-20260601180636886](./note07-使用命令在视图中执行代码.assets/image-20260601180636886.png)

![image-20260601180657453](./note07-使用命令在视图中执行代码.assets/image-20260601180657453.png)

![image-20260601180716099](./note07-使用命令在视图中执行代码.assets/image-20260601180716099.png)

![image-20260601180731400](./note07-使用命令在视图中执行代码.assets/image-20260601180731400.png)

# 4.触发Commands CanExecuteChanged事件

## 在前面的课程中，我们已经为添加和移动按钮添加了命令绑定，这里我们需要给Delete按钮添加命令绑定，注意这个Delete按钮默认是不能够使用的，只有当我们选中一位客户，它才能够启用，因为只有选中的才能够删除，否则逻辑是不对的。我们进入CustomersView.xaml文件，我们给删除按钮绑定一个DeleteCommand属性，

![image-20260601181631834](./note07-使用命令在视图中执行代码.assets/image-20260601181631834.png)

## 此时它还没有创建出来，我们可以在视图模型类里面创建他的定义，我们创建一个DeleteCommand属性并且在构造函数里面用它来接受2个DeletagateCommand实例，一个是我们的Delete方法，另外一个是CanDelete方法，

![image-20260601182548808](./note07-使用命令在视图中执行代码.assets/image-20260601182548808.png)

## 然后我们需要定义这两个方法

![image-20260601182619023](./note07-使用命令在视图中执行代码.assets/image-20260601182619023.png)



![image-20260601183228337](./note07-使用命令在视图中执行代码.assets/image-20260601183228337.png)

## 此时运行应用程序，刚开始delete按钮是灰色的，这个很正常因为我们没有选中然后客户

![image-20260601183333760](./note07-使用命令在视图中执行代码.assets/image-20260601183333760.png)

## 我们选中一个客户，分析按钮仍然是灰色的。这是为什么？

![image-20260601183415326](./note07-使用命令在视图中执行代码.assets/image-20260601183415326.png)

## 原因是我们还没有触发通知机制，视图不知道CanDelete已经修改，我们找到SelectedCustomer属性，在他的setter代码在添加触CanExecutChanged的代码，也就是调用DeleteCommand.RaiseCanExecuteChanged()

![image-20260601183934684](./note07-使用命令在视图中执行代码.assets/image-20260601183934684.png)

## 运行程序，刚开始，按钮是禁用的

![image-20260601184208781](./note07-使用命令在视图中执行代码.assets/image-20260601184208781.png)

## 我们选中一位客户，此时按钮变为可用状态

![image-20260601184241761](./note07-使用命令在视图中执行代码.assets/image-20260601184241761.png)

## 点击删除按钮，客户就会被删除，同时按钮再次变灰，因为我们在代码里面设置了删除一位客户后，选中客户就会清空。

![image-20260601184314980](./note07-使用命令在视图中执行代码.assets/image-20260601184314980.png)

