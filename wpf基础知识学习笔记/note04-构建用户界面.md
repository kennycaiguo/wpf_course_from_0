# 0.内容提要

![image-20260528114854162](./note04-构建用户界面.assets/image-20260528114854162.png)

# 1.理解WPF布局面板p16

## 布局面板用来排列和容纳你的元素，只有的布局面板有以下几种

![image-20260528115050069](./note04-构建用户界面.assets/image-20260528115050069.png)

### 先来看看StackPanel，他默认的堆叠方向是垂直方向

![image-20260528115215876](./note04-构建用户界面.assets/image-20260528115215876.png)

### 上面的代码可以简化

![image-20260528115342008](./note04-构建用户界面.assets/image-20260528115342008.png)

### 可以修改堆叠方向为水平方向，此时需要设置元素的宽度

![image-20260528115453897](./note04-构建用户界面.assets/image-20260528115453897.png)

### Grid是wpf中最强大的面板，我们通常用它来排列主窗口的元素

![image-20260528120208184](./note04-构建用户界面.assets/image-20260528120208184.png)

### 其实需要设置显示网格线，才能够看到网格线

![image-20260528120328672](./note04-构建用户界面.assets/image-20260528120328672.png)

### 放置第一个元素

![image-20260528120458621](./note04-构建用户界面.assets/image-20260528120458621.png)

### 我们可以在矩形上面设置矩形的放置位置，注意这个是附加属性

![image-20260528120635074](./note04-构建用户界面.assets/image-20260528120635074.png)

![image-20260528120907292](./note04-构建用户界面.assets/image-20260528120907292.png)

### 面板是可以互相嵌套的

![image-20260528121015445](./note04-构建用户界面.assets/image-20260528121015445.png)

### Canvas面板用来绝对定位元素

![image-20260528121223216](./note04-构建用户界面.assets/image-20260528121223216.png)

### 注意：在wpf中。元素是有层级的，先创建的元素在下一层，后创建的元素在上一层，我们可以通过修改ZIndex属性来修改层级顺序，ZIndex的默认值是0，这个值越大，层级越靠上

![image-20260528121540015](./note04-构建用户界面.assets/image-20260528121540015.png)

### Canvas最好用来放置图形，如果需要放置UI元素，Cavas不好用，因为Cavas中的元素不会根据剩余空间自动调整大小，而Grid里面的元素可以根据空间自动调整大小

# 2.使用Grid构建面板

### 我们还是我们的WiredBrainCoffeeApp，我们先给Grid添加一个4行2列的布局

![image-20260528122645960](./note04-构建用户界面.assets/image-20260528122645960.png)

## 然后我们给他修改内容，添加菜单和按钮和状态栏，代码如下

```
<Window x:Class="WiredbrainCoffeeApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WiredbrainCoffeeApp"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800" FontSize="20">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <!--主菜单-->
        <Menu FontSize="20">
            <MenuItem Header="_View">
                <MenuItem Header="_Customers"/>
                <MenuItem Header="_Products"/>
            </MenuItem>
        </Menu>
        <!--Headers-->
        <StackPanel Background="#F05A28" Orientation="Horizontal" >
            <Image Source="/Images/logo.png" Width="100" />
            <TextBlock Text="Customer App" FontSize="30" Foreground="White"/>
            <TextBlock Text="Version 1,0" FontSize="16" Foreground="#333333" />
        </StackPanel>
        <!--Customer List-->
        <StackPanel Background="#777">
            <StackPanel Orientation="Horizontal">
                <Button Margin="10" Width="75">
                    <StackPanel Orientation="Horizontal">
                        <Image Source="/Images/add.png"  Height="18" Margin="0 0 5 0 "/>
                        <TextBlock Text="Add"/>
                    </StackPanel>
                </Button>
                <Button Content="Delete" Width="75" Margin="0 10 10 10"/>
                <Button  Margin="0 10 10 10">
                    <Image Source="/Images/move.png"  Height="18" />
                </Button>
            </StackPanel>
            <ListView Margin="10 0 10 10">
                <ListViewItem Content="Julia"/>
                <ListViewItem Content="Alex"/>
                <ListViewItem Content="Thomas"/>
            </ListView>
        </StackPanel>
        <!--Customer Detail-->
        <StackPanel Margin="10">
            <Label Content="First Name:" />
            <TextBox />
            <Label Content="Last Name:" />
            <TextBox />
            <CheckBox Margin="0 10 0 0" >
                IsDeveloper
            </CheckBox>
        </StackPanel>
        <!--Status Bar-->
        <StatusBar>
            <StatusBarItem FontSize="20" Content="(C) WiredBrain Coffee" />
        </StatusBar>
        
    </Grid>
</Window>

```

### 因为我们没有给这些元素设置行列附加属性，此时他们全都挤在（0，0）的位置，也就是第一个单元格，并且后面的都在前面的上面，所以现在只能够看到状态栏

![image-20260528131115158](./note04-构建用户界面.assets/image-20260528131115158.png)

### 我们可以通过设计器来修改窗口的宽高，使用d:DesignWidth he d:DesignHeight来修改

![image-20260528131531569](./note04-构建用户界面.assets/image-20260528131531569.png)



### 然后我们来给他们添加定位，修改后的代码如下

```
<Window x:Class="WiredbrainCoffeeApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WiredbrainCoffeeApp"
        mc:Ignorable="d"
        Title="MainWindow" d:DesignHeight="600" d:DesignWidth="500" FontSize="20">
    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition/>
            <ColumnDefinition/>
        </Grid.ColumnDefinitions>
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <!--主菜单-->
        <Menu Grid.ColumnSpan="2" FontSize="20">
            <MenuItem Header="_View">
                <MenuItem Header="_Customers"/>
                <MenuItem Header="_Products"/>
            </MenuItem>
        </Menu>
        <!--Headers-->
        <StackPanel Grid.Row="1" Grid.ColumnSpan="2" Background="#F05A28" Orientation="Horizontal" >
            <Image Source="/Images/logo.png" Width="100" />
            <TextBlock Text="Customer App" FontSize="30" Foreground="White"/>
            <TextBlock Text="Version 1,0" FontSize="16" Foreground="#333333" />
        </StackPanel>
        <!--Customer List-->
        <StackPanel Grid.Row="2" Background="#777">
            <StackPanel Orientation="Horizontal">
                <Button Margin="10" Width="75">
                    <StackPanel Orientation="Horizontal">
                        <Image Source="/Images/add.png"  Height="18" Margin="0 0 5 0 "/>
                        <TextBlock Text="Add"/>
                    </StackPanel>
                </Button>
                <Button Content="Delete" Width="75" Margin="0 10 10 10"/>
                <Button  Margin="0 10 10 10">
                    <Image Source="/Images/move.png"  Height="18" />
                </Button>
            </StackPanel>
            <ListView Margin="10 0 10 10">
                <ListViewItem Content="Julia"/>
                <ListViewItem Content="Alex"/>
                <ListViewItem Content="Thomas"/>
            </ListView>
        </StackPanel>
        <!--Customer Detail-->
        <StackPanel  Grid.Row="2" Grid.Column="1" Margin="10">
            <Label Content="First Name:" />
            <TextBox />
            <Label Content="Last Name:" />
            <TextBox />
            <CheckBox Margin="0 10 0 0" >
                IsDeveloper
            </CheckBox>
        </StackPanel>
        <!--Status Bar-->
        <StatusBar Grid.Row="3" Grid.ColumnSpan="2">
            <StatusBarItem FontSize="20" Content="(C) WiredBrain Coffee" />
        </StatusBar>
    </Grid>
</Window>

```

### 视觉效果如下

![image-20260528132507739](./note04-构建用户界面.assets/image-20260528132507739.png)



# 3.理解行与列的尺寸设置

## 行高度的调整

![image-20260530110742659](./note04-构建用户界面.assets/image-20260530110742659.png)

![image-20260530110841385](./note04-构建用户界面.assets/image-20260530110841385.png)

![image-20260530110937846](./note04-构建用户界面.assets/image-20260530110937846.png)

![image-20260530111059617](./note04-构建用户界面.assets/image-20260530111059617.png)

![image-20260530111157472](./note04-构建用户界面.assets/image-20260530111157472.png)

![image-20260530111237988](./note04-构建用户界面.assets/image-20260530111237988.png)

## 列宽度的调整也是一样的道理

### 我们的项目在调整行高度之前是这样子的

![image-20260530111825009](./note04-构建用户界面.assets/image-20260530111825009.png)

### 我们把第一行和第二行的高度都设置为Auto，效果如下

![image-20260530111927227](./note04-构建用户界面.assets/image-20260530111927227.png)

### 我们完成所有的行高度设置后，效果如下

![image-20260530112212737](./note04-构建用户界面.assets/image-20260530112212737.png)

### 我们修改窗口的宽度然后设置列宽后，效果如下

![image-20260530112436709](./note04-构建用户界面.assets/image-20260530112436709.png)

### 还可以把第一列定义为自动

![image-20260530114940059](./note04-构建用户界面.assets/image-20260530114940059.png)

# 4.使用布局属性定位元素

### 1》对齐方式

![image-20260530122430542](./note04-构建用户界面.assets/image-20260530122430542.png)

![image-20260530122503451](./note04-构建用户界面.assets/image-20260530122503451.png)

![image-20260530122526123](./note04-构建用户界面.assets/image-20260530122526123.png)

![image-20260530122602043](./note04-构建用户界面.assets/image-20260530122602043.png)

![image-20260530122649856](./note04-构建用户界面.assets/image-20260530122649856.png)

![image-20260530122726493](./note04-构建用户界面.assets/image-20260530122726493.png)

![image-20260530123050429](./note04-构建用户界面.assets/image-20260530123050429.png)

### 2》设置边距

![image-20260530123145643](./note04-构建用户界面.assets/image-20260530123145643.png)

![image-20260530123245424](./note04-构建用户界面.assets/image-20260530123245424.png)

![image-20260530123357442](./note04-构建用户界面.assets/image-20260530123357442.png)

## 我们也来调整一下我们项目的header区域的元素定位

### 我们先调整Image元素的边距

![image-20260530123840554](./note04-构建用户界面.assets/image-20260530123840554.png)

### 导入还可以使用设计器来调整

![image-20260530123918997](./note04-构建用户界面.assets/image-20260530123918997.png)

### 在vs的属性窗口也可以设置

![image-20260530124023124](./note04-构建用户界面.assets/image-20260530124023124.png)

![image-20260530124205185](./note04-构建用户界面.assets/image-20260530124205185.png)

### 注意，在水平排列的StackPanel中，你无法在水平方向移动元素，所以此时设置水平对齐是没有作用的，但是你可以设置垂直对齐

![image-20260530130811382](./note04-构建用户界面.assets/image-20260530130811382.png)

### 我们把图片下面的文本设置为垂直居中

![image-20260530131112925](./note04-构建用户界面.assets/image-20260530131112925.png)

### 把版本信息也调整为垂直居中，并且添加边距

![image-20260530131337823](./note04-构建用户界面.assets/image-20260530131337823.png)

### 我们还可以把这两个文本设置为底部基线对齐

![image-20260530135450753](./note04-构建用户界面.assets/image-20260530135450753.png)

# 5.标题栏居中

### 我们给代表标题栏的StackPanel添加水平居中

![image-20260530135755924](./note04-构建用户界面.assets/image-20260530135755924.png)

### 此时的效果还不够好，我们在StackPanel套一个Grid，此时效果就ok了

![image-20260530141858732](./note04-构建用户界面.assets/image-20260530141858732.png)



# 6.为导航创建Grid

### 我们需要拉伸我们客户列表里面的ListView，但是他的父元素是StackPanel，设置垂直对齐没有任何效果，把它改为Grid

![image-20260530142715735](./note04-构建用户界面.assets/image-20260530142715735.png)

### 然后，需要给这个Grid分为2行，第一行的高度是自动，第二行的高度是"*****",可以不写，默认就是"*"

![image-20260530143317962](./note04-构建用户界面.assets/image-20260530143317962.png)

# 7.在xaml中设置附加属性

![image-20260530144842169](./note04-构建用户界面.assets/image-20260530144842169.png)

# 8.在c#中设置附加属性

![image-20260530145128942](./note04-构建用户界面.assets/image-20260530145128942.png)

![image-20260530145241475](./note04-构建用户界面.assets/image-20260530145241475.png)

### 回到我们的项目，把最外面的Grid的列数改为3，第二列宽度使用“*”

![image-20260530145809823](./note04-构建用户界面.assets/image-20260530145809823.png)

### 注意：这里的技巧就是使用列宽=“Auto”，因为这个设置是有内容才有宽度，没有内容时，宽度为0.然后我们转到客户列表，把这个Grid的列设置到第三列

![image-20260530150331367](./note04-构建用户界面.assets/image-20260530150331367.png)

### 那么问题来了，此时客户列表上面有一个空白的地方不好看，我们需要修复一下，我们把标题所在的Grid元素设置为占3列，把菜单也设置为占用3列

![image-20260530150712996](./note04-构建用户界面.assets/image-20260530150712996.png)

### 把状态栏也设置为占用3列

![image-20260530150929673](./note04-构建用户界面.assets/image-20260530150929673.png)

### 然后我们把客户列表的Grid的列的定位代码输出，让它默认在左边

![image-20260530151450654](./note04-构建用户界面.assets/image-20260530151450654.png)

### 然后我们需要给这个Grid添加名称引用，以便我们可以在后台代码中获取到它。

![image-20260530151807425](./note04-构建用户界面.assets/image-20260530151807425.png)

### 然后我们展开有3个按钮的StackPanel，给最后那个按钮添加点击事件处理代码

![image-20260530152208747](./note04-构建用户界面.assets/image-20260530152208747.png)

### 然后转到这个事件处理函数，我们添加下面的后台代码

```
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WiredbrainCoffeeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnMove_Click(object sender, RoutedEventArgs e)
        {
            var column = (int)customerListGrid.GetValue(Grid.ColumnProperty);
            var col = column == 0 ? 2 : 0;
            customerListGrid.SetValue(Grid.ColumnProperty, col);
        }
    }
}
```

### 效果，程序刚启动是这样子的

![image-20260530153343562](./note04-构建用户界面.assets/image-20260530153343562.png)

### 然后我们点击delete按钮右边的按钮，这个组件会移动到右侧

![image-20260530153442030](./note04-构建用户界面.assets/image-20260530153442030.png)

### 再点击一下，它有移动会左侧

![image-20260530153522887](./note04-构建用户界面.assets/image-20260530153522887.png)

# 9.使用Grid的静态方法访问附加属性

###  我们上面修改组件位置的代码使用的是GetValue方法，它得到的是一个object，我们需要使用强制类型转换把它变为int，这里我们可以使用Grid的静态方法

```
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WiredbrainCoffeeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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

### 效果是一样的

