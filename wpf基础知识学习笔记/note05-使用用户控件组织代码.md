# 0.内容提要

## 我们会把xaml代码放入一些叫做用户控件的可重用代码中

![image-20260530161604263](./note05-使用用户控件组织代码.assets/image-20260530161604263.png)

# 1.将标题栏提取为用户控件

### 1》打开我们的项目的MainWindow.xaml文件，找到header所在的Grid代码，我们需要把这段代码保存到另外一个文件中。

### 2》在项目文件上面点击右键-》添加-》新建文件夹

![image-20260530162129697](./note05-使用用户控件组织代码.assets/image-20260530162129697.png)

### 3》给生成的文件夹改名：Controls

![image-20260530162333488](./note05-使用用户控件组织代码.assets/image-20260530162333488.png)

### 4》然后在Controls文件夹上面点击右键-》添加-》UserControl

![image-20260530162439567](./note05-使用用户控件组织代码.assets/image-20260530162439567.png)

### 5》在打开的窗口的左侧点击wpf，然后选择用户控件，起名HeaderControl，然后点击添加

![image-20260530162753109](./note05-使用用户控件组织代码.assets/image-20260530162753109.png)

### 6》然后就会生成一个用户控件

![image-20260530163814660](./note05-使用用户控件组织代码.assets/image-20260530163814660.png)

### 7》然后把MainWindow.xaml中作为Header的Grid代码剪切然后粘贴到HeaderControl.xaml中并且把行和列的定位代码删除

![image-20260530164257713](./note05-使用用户控件组织代码.assets/image-20260530164257713.png)

### 8》回到MainWindow.xaml中，添加HeaderControl 控件标签，然后它会有波浪线并且在左侧重新一个灯泡，我们点击这个灯泡，添加需要的命名空间

![image-20260530164543242](./note05-使用用户控件组织代码.assets/image-20260530164543242.png)

### 9》然后这个controls命名空间就成功导入了，然后HeaderControl变为controls:HeaderControl

![image-20260530164854845](./note05-使用用户控件组织代码.assets/image-20260530164854845.png)

### 10>我们给它设置行和列

![image-20260530165148143](./note05-使用用户控件组织代码.assets/image-20260530165148143.png)

### 运行程序，发现程序正常工作

![image-20260530165244879](./note05-使用用户控件组织代码.assets/image-20260530165244879.png)

![image-20260530165300631](./note05-使用用户控件组织代码.assets/image-20260530165300631.png)

![image-20260530165318195](./note05-使用用户控件组织代码.assets/image-20260530165318195.png)

# 2.重构MainWindow的xaml代码

 ### 1》这里我们需要把客户列表和客户详情的代码放到一个用户控件中，为了构建方便发使用分行和分列功能，我们先在MainWindow.xaml中把这两段代码用一个Grid元素来包裹起来，然后把上面的根Grid元素的列定义代码剪切过来。因为根Grid已经没有分列代码了，所以在主xaml程序的所有使用的ColumnSpan代码都可以删除了。

### 2》运行程序，效果一切正常

# 3.把客户相关代码抽取到用户控件

## 这里我们在项目上面点击右键-》添加-》新建文件夹

![image-20260530180150831](./note05-使用用户控件组织代码.assets/image-20260530180150831.png)

## 然后我们把这个文件夹命名为view

![image-20260530180249013](./note05-使用用户控件组织代码.assets/image-20260530180249013.png)

## 然后在view文件夹上面点击右键-》添加-》用户控件

![image-20260530180346783](./note05-使用用户控件组织代码.assets/image-20260530180346783.png)

## 在弹出的控件选择wpf，然后选择用户控件，起名CustomersView

![image-20260530180612444](./note05-使用用户控件组织代码.assets/image-20260530180612444.png)

## 点击添加，就创建了一个客户视图控件

![image-20260530180811615](./note05-使用用户控件组织代码.assets/image-20260530180811615.png)

## 然后我们把上一节课封装好的Grid代码剪切过来,CustomersView.xaml的代码如下

```
<UserControl x:Class="WiredbrainCoffeeApp.view.CustomersView"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:WiredbrainCoffeeApp.view"
             mc:Ignorable="d" 
             d:DesignHeight="450" d:DesignWidth="800">
    <Grid Grid.Row="2">
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition/>
            <ColumnDefinition Width="Auto"/>
        </Grid.ColumnDefinitions>
        <!--Customer List-->
        <Grid x:Name="customerListGrid"
         Background="#777">
            <Grid.RowDefinitions>
                <RowDefinition Height="Auto"/>
                <RowDefinition Height="*"/>
            </Grid.RowDefinitions>
            <StackPanel Orientation="Horizontal">
                <Button Margin="10" Width="75">
                    <StackPanel Orientation="Horizontal">
                        <Image Source="/Images/add.png"  Height="18" Margin="0 0 5 0 "/>
                        <TextBlock Text="Add"/>
                    </StackPanel>
                </Button>
                <Button Content="Delete" Width="75" Margin="0 10 10 10"/>
                <Button  Margin="0 10 10 10" Click="BtnMove_Click">
                    <Image Source="/Images/move.png"  Height="18" />
                </Button>
            </StackPanel>
            <ListView Grid.Row="1" Margin="10 0 10 10">
                <ListViewItem Content="Julia"/>
                <ListViewItem Content="Alex"/>
                <ListViewItem Content="Thomas"/>
            </ListView>
        </Grid>
        <!--Customer Detail-->
        <StackPanel  Grid.Column="1" Margin="10">
            <Label Content="First Name:" />
            <TextBox />
            <Label Content="Last Name:" />
            <TextBox />
            <CheckBox Margin="0 10 0 0" >
                IsDeveloper
            </CheckBox>
        </StackPanel>
    </Grid>
</UserControl>

```

## 然后我们把CustomersView控件添加到MainWindow.xaml中并且导入命名空间

![image-20260530181328422](./note05-使用用户控件组织代码.assets/image-20260530181328422.png)

## 然后它就会被添加view:前缀，声明命名空间导入成功，我们给他添加一个附加属性Grid.Row="2"

![image-20260530184132720](./note05-使用用户控件组织代码.assets/image-20260530184132720.png)

## 注意，此时你尝试运行程序，会报错，因为我们重构了xaml文件但是后台不知道，这样子就会出现引用了不存在的控件，这个问题如何解决？很简单，我们只需要把MainWindow.xaml.cs里面的按钮点击处理程序剪切然后粘贴到CustomersView.xaml.cs里面

![image-20260530185640182](./note05-使用用户控件组织代码.assets/image-20260530185640182.png)

### 运行程序，一切正常

![image-20260530185907165](./note05-使用用户控件组织代码.assets/image-20260530185907165.png)

![image-20260530185924079](./note05-使用用户控件组织代码.assets/image-20260530185924079.png)

# 4.理解WPF的xaml命名空间

![image-20260530190915488](./note05-使用用户控件组织代码.assets/image-20260530190915488.png)

#### 注意：local命名空间不是必须的。
