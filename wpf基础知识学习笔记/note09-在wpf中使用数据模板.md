# 1.内容提要

![image-20260606150948349](./note09-在wpf中使用数据模板.assets/image-20260606150948349.png)

# 2.理解wpf中的灵活内容模型

<img src="./note09-在wpf中使用数据模板.assets/image-20260606151157694.png" alt="image-20260606151157694" style="zoom:50%;" />



![image-20260606151236674](./note09-在wpf中使用数据模板.assets/image-20260606151236674.png)

![image-20260606151334695](./note09-在wpf中使用数据模板.assets/image-20260606151334695.png)

![image-20260606151400618](./note09-在wpf中使用数据模板.assets/image-20260606151400618.png)

![image-20260606151541832](./note09-在wpf中使用数据模板.assets/image-20260606151541832.png)

![image-20260606151647008](./note09-在wpf中使用数据模板.assets/image-20260606151647008.png)

![image-20260606151738372](./note09-在wpf中使用数据模板.assets/image-20260606151738372.png)

![image-20260606151820192](./note09-在wpf中使用数据模板.assets/image-20260606151820192.png)

![image-20260606151947555](./note09-在wpf中使用数据模板.assets/image-20260606151947555.png)

![image-20260606152034300](./note09-在wpf中使用数据模板.assets/image-20260606152034300.png)

![image-20260606152059856](./note09-在wpf中使用数据模板.assets/image-20260606152059856.png)

![image-20260606152134180](./note09-在wpf中使用数据模板.assets/image-20260606152134180.png)

![image-20260606152206635](./note09-在wpf中使用数据模板.assets/image-20260606152206635.png)

# 3.使用DataTemplate与ItemControls

## 1.打开CustomersView.xaml文件，我们给客户列表这个ListView添加一个ItemTemplate，然后在里面添加一个数据模板，我们把客户的名和姓都显示出来

![image-20260606153649793](./note09-在wpf中使用数据模板.assets/image-20260606153649793.png)

### 运行程序，效果如下

![image-20260606153732141](./note09-在wpf中使用数据模板.assets/image-20260606153732141.png)

## 2.我们还可以把这个模板设置为资源，我们把数据模板从ListView里面剪切然后粘贴到UserControl.Resources标签里面，注意，此时是不需要ItemTemplate的，但是需要给他添加一个key

![image-20260606154221539](./note09-在wpf中使用数据模板.assets/image-20260606154221539.png)

##  3.然后我们在ListView中使用这个资源

![image-20260606154357242](./note09-在wpf中使用数据模板.assets/image-20260606154357242.png)

## 运行程序，一切正常

![image-20260606154502196](./note09-在wpf中使用数据模板.assets/image-20260606154502196.png)

### 此时这个程序有一个小问题，就是当客户的姓名长度改变时，左边导航条的宽度会跟着改变，我们需要把导航条的宽度固定，然后显示滚动条。这是有Grid的列的宽度="auto"引起的。

# 4.设置导航区域为固定宽度

## 回到CustomerView.xaml,我们把Grid第一列的宽度设置为固定的260

![image-20260606155431354](./note09-在wpf中使用数据模板.assets/image-20260606155431354.png)

### 此时你运行应用程序，发现导航区域宽度不变，但是当内容显示不下时会程序滚动条

![image-20260606155843257](./note09-在wpf中使用数据模板.assets/image-20260606155843257.png)

### 注意：这里又会有一个小问题，当你把导航区域移动到右边，左边就会有一个空白，怎么办？

![image-20260606163111731](./note09-在wpf中使用数据模板.assets/image-20260606163111731.png)

## 其实我们不应该在列上面设置宽度，我们需要它为"Auto",我们把它改回来

![image-20260606163309587](./note09-在wpf中使用数据模板.assets/image-20260606163309587.png)

## 我们应该设置客户列表对应的Grid的宽度为固定

![image-20260606163652312](./note09-在wpf中使用数据模板.assets/image-20260606163652312.png)



# 5.使用ContentControl的设计思路

## 我们将要添加一个MainWindow视图模型。把它作为MainWindow的DataContext，用它来协调不同视图的显示，因为我们还会有产品视图

![image-20260606164201924](./note09-在wpf中使用数据模板.assets/image-20260606164201924.png)

![image-20260606164243286](./note09-在wpf中使用数据模板.assets/image-20260606164243286.png)

![image-20260606164338652](./note09-在wpf中使用数据模板.assets/image-20260606164338652.png)

![image-20260606164423447](./note09-在wpf中使用数据模板.assets/image-20260606164423447.png)

![image-20260606164506151](./note09-在wpf中使用数据模板.assets/image-20260606164506151.png)

![image-20260606164558393](./note09-在wpf中使用数据模板.assets/image-20260606164558393.png)

![image-20260606164639164](./note09-在wpf中使用数据模板.assets/image-20260606164639164.png)







# 6.实现MainViewModel

## 在项目的ViewModel文件夹里面点击右键-》添加->类，起名：MainViewModel，点击添加就可以创建成功

![image-20260606165043529](./note09-在wpf中使用数据模板.assets/image-20260606165043529.png)



## 把它改为public并且继承我们的ViewModelBase基类，并且添加一个SelectedViewModel属性和一个_selectedViewModel私有字段

![image-20260606165524252](./note09-在wpf中使用数据模板.assets/image-20260606165524252.png)

## 把getter改为表达式体和在setter中添加基类的触发属性变更通知的函数

![image-20260606165705073](./note09-在wpf中使用数据模板.assets/image-20260606165705073.png)

## 还需要对字段进行可空处理

![image-20260606165852700](./note09-在wpf中使用数据模板.assets/image-20260606165852700.png)

## 然后给类创建一个构造函数，并且创建一个_customerViewModel并且接受一个CustomerViewModel类型的参数customerViewModel，然后把这个字段赋值给SelectedViewModel

![image-20260606171601384](./note09-在wpf中使用数据模板.assets/image-20260606171601384.png)

## 然后给这个类添加一个Task的LoadAsync方法，在里面调用ViewModelBase的LoadAsync方法，但是此时此方法还没有创建

![image-20260606172038680](./note09-在wpf中使用数据模板.assets/image-20260606172038680.png)

## 我们点击这个方法，按alt+enter,选择删除方法LoadAsync

![image-20260606172158804](./note09-在wpf中使用数据模板.assets/image-20260606172158804.png)

## 此时就会在ViewModelBase类在生成对应的方法，

![image-20260606172342627](./note09-在wpf中使用数据模板.assets/image-20260606172342627.png)

## 我们需要把它改为public virtual，也就是公共的虚函数，同时改为表达式体，注意这里不要提交async关键字，会报错

![image-20260606172716626](./note09-在wpf中使用数据模板.assets/image-20260606172716626.png)

## 然后回到CustomerViewModel类，发现他的LoadAsync(比基类的方法早创建)下面有绿色波浪线，它提示我们需要提交override或者添加new关键字

![image-20260606173000457](./note09-在wpf中使用数据模板.assets/image-20260606173000457.png)



## 我们就在方法前面添加override关键字

![image-20260606173351369](./note09-在wpf中使用数据模板.assets/image-20260606173351369.png)

## 回到MainViewModel.cs,在LoadAsync方法前面添加override关键字

![image-20260606173653846](./note09-在wpf中使用数据模板.assets/image-20260606173653846.png)

# 7.绑定到MainViewModel

## 打开CustomersView.xaml.cs,把我们以前添加的所有代码都移除。只剩下默认代码

![image-20260606185950818](./note09-在wpf中使用数据模板.assets/image-20260606185950818.png)

## 回到MainWindow.xaml.cs中，移除多余的using

![image-20260606190131071](./note09-在wpf中使用数据模板.assets/image-20260606190131071.png)

## 然后我们添加下面的代码

![image-20260606191038005](./note09-在wpf中使用数据模板.assets/image-20260606191038005.png)



## 打开MainWindow.xaml文件，找到客户视图控件，给他绑定DataContext

![image-20260606191532355](./note09-在wpf中使用数据模板.assets/image-20260606191532355.png)

## 运行程序，数据又回来了

![image-20260606191626216](./note09-在wpf中使用数据模板.assets/image-20260606191626216.png)

![image-20260606191644525](./note09-在wpf中使用数据模板.assets/image-20260606191644525.png)

![image-20260606191701927](./note09-在wpf中使用数据模板.assets/image-20260606191701927.png)

![image-20260606191746619](./note09-在wpf中使用数据模板.assets/image-20260606191746619.png)



# 8.使用DataTemplate与ContentControls

## 回到MainWindow.xaml中，我们使用ContentControl来替代我们客户列表的视图控件

![image-20260606192251318](./note09-在wpf中使用数据模板.assets/image-20260606192251318.png)

## 运行程序，就会出现下面的效果

![image-20260606192338915](./note09-在wpf中使用数据模板.assets/image-20260606192338915.png)

## 此时我们需要使用数据模板来为这个控件设计外观

![image-20260606192817626](./note09-在wpf中使用数据模板.assets/image-20260606192817626.png)

## 运行程序,数据又回来了

![image-20260606192931197](./note09-在wpf中使用数据模板.assets/image-20260606192931197.png)

## 其实我们可以把这个数据模板定义为资源，我们把它放到Window.Resources标签里面

![image-20260606193439448](./note09-在wpf中使用数据模板.assets/image-20260606193439448.png)

## 然后我们在ContentControl里面引用它

![image-20260606193619033](./note09-在wpf中使用数据模板.assets/image-20260606193619033.png)

## 运行程序，一切正常

![image-20260606193801874](./note09-在wpf中使用数据模板.assets/image-20260606193801874.png)

![image-20260606193823070](./note09-在wpf中使用数据模板.assets/image-20260606193823070.png)

![image-20260606193851434](./note09-在wpf中使用数据模板.assets/image-20260606193851434.png)



# 9.理解隐式DataTemplate

## 这一节课我们来学习创建一个自动引用的隐式数据模板

### 打开项目，进入MainWindow.xaml,添加对ViewModel文件夹引用的xml命名空间映射

![image-20260606194419244](./note09-在wpf中使用数据模板.assets/image-20260606194419244.png)

## 然后给我们上一节课创建的数据模块资源设置DataType属性，并且移除x:Key属性

![image-20260606194835042](./note09-在wpf中使用数据模板.assets/image-20260606194835042.png)



## 回到ContentControl，把它的ContentTemplate属性移除

![image-20260606194947225](./note09-在wpf中使用数据模板.assets/image-20260606194947225.png)

## 运行程序一切正常

![image-20260606195211582](./note09-在wpf中使用数据模板.assets/image-20260606195211582.png)



# 10.引入另外一个详情视图

## 这一节我们来添加另外一个详情视图

### 在View文件夹上面点击右键-》添加-》用户控件，起名ProductsView

![image-20260606195631598](./note09-在wpf中使用数据模板.assets/image-20260606195631598.png)

![image-20260606203714867](./note09-在wpf中使用数据模板.assets/image-20260606203714867.png)

## 在Grid里面添加一个TextBlock控件，水平和垂直都设置居中

![image-20260608094734124](./note09-在wpf中使用数据模板.assets/image-20260608094734124.png)

## 然后我们在ViewModel文件夹上面点击右键-》添加-》类，添加一个ProductViewModel.cs类作为ProductsView视图的视图模型

![image-20260608095131730](./note09-在wpf中使用数据模板.assets/image-20260608095131730.png)



## 把这个类改为public类型，并且从ViewModelBase派生

![image-20260608100204875](./note09-在wpf中使用数据模板.assets/image-20260608100204875.png)

## 先不添加代码，转到MainViewModel视图模型，在里面连接它，给构造函数添加一个ProductViewModel类型的参数，然后创建一个私有字段_productViewModel来接受它

![image-20260608101050765](./note09-在wpf中使用数据模板.assets/image-20260608101050765.png)



## 转到MainWindow.xaml.cs文件中，先需要修改构造MainViewModel实例的代码

![image-20260608101353513](./note09-在wpf中使用数据模板.assets/image-20260608101353513.png)

## 现在需要给ProductsView添加一个隐式数据模板，我们打开MainWindow.xaml文件,在资源标签里面添加模板

![image-20260608112226209](./note09-在wpf中使用数据模板.assets/image-20260608112226209.png)





# 11.创建SelectViewModelCommand



# 12.将菜单项绑定到命令





