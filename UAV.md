# UAV

## 0. Advantages of DT

DT 对于产业企业来说，至少具备以下三个重要意义：

（1）**全流程 visualization**

这个是 DT 的核心价值之一。

Visualization 在工业生产场景下有重要的价值，而且能够全面贯穿整个工业生产过程，包括设计、工艺、制造、运维等环节，这为提升管理运营效率有重要影响，对于后续的流程改进也有重要的意义。

以腾讯的“**透明工厂**”项目为例，通过数字孪生技术，可以全面实现对生产、工艺、检测、质量、成本等数据的自动采集与集成，基于“虚幻”引擎来完成3D动态建模，从而实现公司级大数据的全面可视化。

（2）**Prediction**

预测对于生产场景的影响是不言而喻的，甚至有的专家会用预测来定义 DT 技术。

以腾讯的智慧城市“**穗智管**”案例为例，通过构建与物理城市映射融合的数字孪生城市，成为了管理者的重要参考，能够对整个城市运行体征和事件进行监测和预测，从而实现“一网统管、全城智治”。

（3）**全生命周期过程映射**

这个过程映射包括了很多内容，重点是仿真，包括产品设计仿真、加工工艺仿真、生产过程仿真、产品的维修维护仿真等，可以看出，数字模型的仿真分析完成了全生命周期的贯穿。 

通过仿真来确保与现实物理系统的一致性，这样才能基于数字模型来做出正确的预测，从而为后续的策略制定奠定依据。



DT **有两个核心的技术基础，一个是 modeling，另一个是 simulating**





## 1. Introduction to this project

### 1-1 Features of the UAVTwin platform (compared with traditional UAV testing)

- (主要从测试的方面来讲，还没有讲到双向实时映射)

- **Scene**: **flexible** configuration,  **high coverage**
- **The “corner case” can be retested**
- Simulate process **safe**: **no damage** to actual scene and UAV
- **Realize automation and cloud accelerated simulation**, which can improve test efficiency

<center>
<img src="/Users/nian/niannian/SJTU/42大四下/毕设/UAVTwin/pics/无人机数字孪生平台.png" alt="drawing" width="500"/>
</center>


### 1-2 UAVTwin core technologies

#### 1. Data perception and analysis

- **Automated testing**：batch simulation in DT platform: The UAV will automatically return to the initial state after crashing or completing the mission。
  - Autonomous flight in each round of simulation
  
  - if hit buildings or other obstacles, the UAV will crush 
  
  - **Automaticallt return to the initial state after crashing or completing the mission**
  
- **Intelligent algorithm**：DT platform the flight trajectory of UAV and other targets can be learned using **Reinfocement Learning** in multiple rounds of testing。
- Using AI, learning the **flight trajectory** of UAV and other targets in **multiple rounds** of testing
  
- State: the states of sensors（whether if there are buildings and other obstacles）, forward direction
  
- Action: Rotate, forward, backward, up, down
  
- Reward: Approach / stay away from destination

| States                     | Actions                     | Rewards                              |
| -------------------------- | --------------------------- | ------------------------------------ |
| **State of front sensors** | rotate 90° counterclockwise | **-10: hit buildings**               |
| **State of rear sensors**  | rotate 90° clockwise        | **-0.1: stay away from destination** |
| **State of left sensors**  | **forward, backward**       | **0.1：approach destination**        |
| **State of right sensors** | **left / right shift**      |                                      |
| Forward direction          | rise / fall                 |                                      |



#### 2. UAV modeling and rendering

- Basic model and functional model

**Basic model：**including 3D modeling of urban, forest and other environments and UAV model and controller.

**Functional model**：为使孪生侧的模型具有模拟物理实体功能而构建出的**算法模型**。

- **Scene and UAV modeling and rendering**

**Scene modeling and rendering and its assumptions：**

1. **所有的“强烈”碰撞体 building（碰到即无人机坠毁）**：

<center>
<img src="/Users/nian/niannian/SJTU/42大四下/毕设/UAVTwin/pics/building.png" alt="drawing" width="300"/>
</center>
2.**所有的“微弱”碰撞体道路、电线杆、flower, grass and etc.（碰到只影响飞行轨迹）**：

<center>
<img src="/Users/nian/niannian/SJTU/42大四下/毕设/UAVTwin/pics/roadGrass.png" alt="drawing" width="300"/>
</center>

UAV modeling and rendering: UAV 机身机臂、机翼、camera and etc.

<center>
<img src="/Users/nian/niannian/SJTU/42大四下/毕设/UAVTwin/pics/UAV.png" alt="drawing" width="200"/>
</center>


#### 3. UAVTwin Visualization

- **Visualization of model movement and parameters**

**Visualization of model movemen: ** the motion states of **UAV wings rotation, forward, backward, pitching, rolling, and yawing** can be observed from **first perspective**。

<center>
  <img src="/Users/nian/niannian/SJTU/42大四下/毕设/UAVTwin/pics/模型运动可视化.png" alt="drawing" width="300"/></center>
**Visualization of model parameters**：无人机的**运动参数数据**可以在 UI 面板上以数据、图标、警报等形式呈现。

无人机俯仰姿态角、滚动姿态角、偏航姿态角、机翼旋转角度、坠毁告警等。

<center>
  <img src="/Users/nian/niannian/SJTU/42大四下/毕设/UAVTwin/pics/模型参数可视化.png" alt="drawing" width="300"/></center>


## 2. Progress

### 1. Past

| 工作                                     | 完成日期 |
| :--------------------------------------- | -------- |
| 无人机建模                               | 10月     |
| unity 教程学习                           | 11月     |
| 将无人机导入合适的城市场景               | 12月21日 |
| unity3D 教程学习                         | 12月23日 |
| 完善无人机第一视角、速度改为位移游戏控制 | 12月24日 |
| 完成所有建筑物碰撞检测                   | 12月25日 |
| unity3D 进阶教程：第7章物理系统          | 12月25日 |
| 实现”回合制“和游戏导出                   | 12月28日 |
| 调研无人机轨迹学习                       | 1月10日  |
| 调研救灾场景下无人机集群与车             | 1月20日  |

### 2. Now

| 工作                                           | 日期    |
| :--------------------------------------------- | ------- |
| 实时模型参数可视化                             | 1月19日 |
| 无人机渲染开发                                 | 2月8日  |
| 修复“回合制”与实时模型参数可视化无法共存的问题 | 2月9日  |
| 添加高度参数可视化                             | 2月10日 |
| 坠毁告警弹窗                                   | 2月11日 |
| 修复告警UI、destroy UAV与“回合制”无法共存问题  | 2月12月 |
| UI 大小比例跟随分辨率                          | 2月13日 |
| 限制无人机俯仰、翻滚角度                       | 2月14日 |
| 完成轨迹展示                                   | 2月15日 |
| 加入可以看到轨迹全貌的俯视摄像头               | 2月16日 |
| 完成摄像头视角切换                             | 2月17日 |

### 3. Next

| 工作                                                    | 日期 |
| ------------------------------------------------------- | ---- |
|                                                         |      |
| 无人机集群（先读论文，再加入自己项目）                  |      |
| 区块链 共识协议加入到项目中（先读论文，再加入自己项目） |      |
| 跑火箭回收的项目                                        |      |
|                                                         |      |
|                                                         |      |
|                                                         |      |

关于毕设的想法：读论文（发现好的方法、思路） => 复现 + 加入到自己的毕设项目中去 =>（实现的具体技术学习）





## 3. How to use







