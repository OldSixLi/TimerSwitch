# TimerSwitch
基于Quartz.net的作业调度框架

该项目部署后，根据时间调度表达式（Quartz cron），定时执行某些SQL语句以完成某些特定任务。<br/>
例：定时向数据库中添加符合要求的数据。<br/>
时间调度表达式：/3 * * ? * * ;<br/>
SQL语句：insert into TimerTests  values('inserts data',getdate());<br/>
任务说明：每三秒向TimerTests表中添加一条数据。<br/>

