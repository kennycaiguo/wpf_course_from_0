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

# 5.增加添加和移除错误的方法



# 6.验证FirstName属性



# 7.移除ListView中的红色边框



# 8.在工具提示中显示错误信息



# 9.使用验证错误模板



# 10.在用户界面在显示错误信息

