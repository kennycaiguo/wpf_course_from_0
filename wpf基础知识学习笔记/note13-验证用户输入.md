# 1.内容提要

![image-20260613160112970](./note13-验证用户输入.assets/image-20260613160112970.png)

# 2.理解wpf中的用户输入验证

![image-20260613160234127](./note13-验证用户输入.assets/image-20260613160234127.png)



![image-20260613160314576](./note13-验证用户输入.assets/image-20260613160314576.png)



## 验证有几种方式，

### 第一种就是抛异常

![image-20260613160421125](./note13-验证用户输入.assets/image-20260613160421125.png)

### 第二种使用IDataErrorInfo接口

![image-20260613160616526](./note13-验证用户输入.assets/image-20260613160616526.png)

### 第三种，使用INotifyDataErrorInfo接口

![image-20260613160744425](./note13-验证用户输入.assets/image-20260613160744425.png)





![image-20260613160814894](./note13-验证用户输入.assets/image-20260613160814894.png)

### 第四种，使用自定义验证规则

![image-20260613160915848](./note13-验证用户输入.assets/image-20260613160915848.png)



### 建议使用第三种，他是最强大和最灵活的方法

![image-20260613161003665](./note13-验证用户输入.assets/image-20260613161003665.png)

![image-20260613161116619](./note13-验证用户输入.assets/image-20260613161116619.png)



# 3.使用INotifyDataErrorInfo的设计思路

## 我们在ViewModelBase基类添加验证功能，然后他的每一个子类 都有验证功能

![image-20260613161342624](./note13-验证用户输入.assets/image-20260613161342624.png)

## 但是并不是每一个视图模型都需要验证功能，比较好的做法是创建一个ValidationViewModelBase基类，从ViewModelBase继承，在这里实现验证功能，然后需要这个功能 的视图模型从这里继承

![image-20260613161807607](./note13-验证用户输入.assets/image-20260613161807607.png)

## 不需要验证的，就直接从ViewModelBase基类继承

![image-20260613162029558](./note13-验证用户输入.assets/image-20260613162029558.png)



# 4.创建ValidationViewModelBase类

## 1.打开项目，右键ViewModel文件夹，-》添加-》类，然后起名ValidationViewModelBase.cs

![image-20260613162314287](./note13-验证用户输入.assets/image-20260613162314287.png)

## 2.然后把类设置为public并且移除多余的using语句

![image-20260613162436664](./note13-验证用户输入.assets/image-20260613162436664.png)

## 3.让类继承自ViewModelBase并且实现INotifyDataErrorInfo接口

![image-20260613162649087](./note13-验证用户输入.assets/image-20260613162649087.png)

## 4.此时首先需要导入System.ComponentModel,我们只需要按alt+enter,选择实现接口，就会添加一些没有实现的方法

![image-20260613162840888](./note13-验证用户输入.assets/image-20260613162840888.png)

![image-20260613162932484](./note13-验证用户输入.assets/image-20260613162932484.png)

## 5.我们需要创建一个字典类型的泛型错误集合私有字典并且用字典的构造函数初始化它

![image-20260613165359793](./note13-验证用户输入.assets/image-20260613165359793.png)



## 可以将它改为只读

![image-20260613165527798](./note13-验证用户输入.assets/image-20260613165527798.png)





## 6.然后我们修改HasErrors方法的代码

![image-20260613165715047](./note13-验证用户输入.assets/image-20260613165715047.png)



## 7.然后我们添加GetErrors方法的代码

![image-20260613170424222](./note13-验证用户输入.assets/image-20260613170424222.png)

## 8.然后我们需要添加一个OnErrorsChanged方法来触发ErrorChanged事件，注意是一个收保护的虚方法

![image-20260613171127422](./note13-验证用户输入.assets/image-20260613171127422.png)







# 5.增加添加和移除错误的方法

## 1》进入ValidationViewModelBase源码，给他添加一个AddError的受保护方法

![image-20260614111148352](./note13-验证用户输入.assets/image-20260614111148352.png)

## 2.然后我们给类添加一个受保护的清除错误方法

![image-20260614111644565](./note13-验证用户输入.assets/image-20260614111644565.png)







# 6.验证FirstName属性

## 1.打开项目，进入CustomerItemViewModel类的代码，修改他的基类为ValidationViewModelBase

![image-20260614111956332](./note13-验证用户输入.assets/image-20260614111956332.png)

## 2.进入ValidationViewModelBase类修改一些这两个errors相关方法，给propertyName添加一个[CallerMemberName]特性并且把他们设置为可空类型

![image-20260614113114257](./note13-验证用户输入.assets/image-20260614113114257.png)



## ## 3.进入进入CustomerItemViewModel类的FirstName属性的setter中，添加验证代码

![image-20260614113330410](./note13-验证用户输入.assets/image-20260614113330410.png)

## 运行程序，选择一个客户，把FirstName对应的文本框的内容清除，文本框的边框会变为红色，他是列表对应的客户姓名前面也会有一个红色竖条

![image-20260614113608611](./note13-验证用户输入.assets/image-20260614113608611.png)

## 重新输入文本，红色消失

![image-20260614113657046](./note13-验证用户输入.assets/image-20260614113657046.png)

## 注意，在列表视图中我们并不需要这个红色竖条，下一节课，我们来移除它



# 7.移除ListView中的红色边框

## 1.打开我们的项目，进入CustomersView.xaml中，找到数据模板里面的TextBlock,把它的验证错误信息关闭

![image-20260614114506325](./note13-验证用户输入.assets/image-20260614114506325.png)

## 2，运行程序，效果如下

![image-20260614114614928](./note13-验证用户输入.assets/image-20260614114614928.png)



## 不过此时，用户仍然看不到错误信息

# 8.在工具提示中显示错误信息

## 1.打开项目进入CustomersView.xaml文件,我们需要在文本框元素里面设置样式，为此我们需要进入Style.xaml,给文本框样式添加一个触发器

![image-20260614121243031](./note13-验证用户输入.assets/image-20260614121243031.png)

## 效果如下

![image-20260614121149082](./note13-验证用户输入.assets/image-20260614121149082.png)

## 2.我们决定Tooltip提示有点小，我们可以在Style.xaml里面给他做一个设置

![image-20260614122803494](./note13-验证用户输入.assets/image-20260614122803494.png)

## 效果

![image-20260614122711710](./note13-验证用户输入.assets/image-20260614122711710.png)

# 9.使用验证错误模板

## 我们知道当绑定验证功能的文本框有用户输入错误，它默认会把边框颜色改为红色。我们可以使用附加属性Validation.ErrorTemplate来覆盖这个设置

### 1.进入Style.xaml文件，给TextBox的样式添加一个Setter，属性就是Validation.ErrorTemplate，有点复杂

![image-20260614125330448](./note13-验证用户输入.assets/image-20260614125330448.png)

### 运行程序，效果如下

![image-20260614125439982](./note13-验证用户输入.assets/image-20260614125439982.png)

### 2可以看到，效果不太好，我们需要在错误触发器哪里给他添加一个边距

![image-20260614125920959](./note13-验证用户输入.assets/image-20260614125920959.png)

### 3.错误信息对齐不太理想，我们需要到错误模板里面添加添加一个左边距

![image-20260614130214249](./note13-验证用户输入.assets/image-20260614130214249.png)

### 效果

![image-20260614130146267](./note13-验证用户输入.assets/image-20260614130146267.png)

# 10.在用户界面在显示错误信息

## 这一节课，我们学习如何在用户界面中显示实际的验证错误消息

### 1.打开项目进入Style.xaml,找错误模板里面的文本块元素，把我们上一节课的错误消息的硬编码改为使用绑定，我们在上面的课程中已经设置了获取错误的代码。我们需要给控件占位符添加一个Name属性，方便我们引用它来获取错误信息

![image-20260614131345637](./note13-验证用户输入.assets/image-20260614131345637.png)

### 运行程序，效果如下

![image-20260614131427472](./note13-验证用户输入.assets/image-20260614131427472.png)

## 小结

![image-20260614131631630](./note13-验证用户输入.assets/image-20260614131631630.png)
