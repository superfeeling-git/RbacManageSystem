using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Rbac.WebAPI
{
    public class MyCustomBackService : BackgroundService
    {
        private ILogger<MyCustomBackService> logger;
        public MyCustomBackService(ILogger<MyCustomBackService> logger)
        {
            this.logger = logger;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672,
                UserName = "guest",
                Password = "guest"
            };

            var conn = factory.CreateConnection();

            var channel = conn.CreateModel();
               
            //定义交换器
            channel.ExchangeDeclare(exchange: "logs", type: ExchangeType.Direct);

            //定义队列
            var queueName = channel.QueueDeclare().QueueName;

            //绑定交换器和队列
            channel.QueueBind(queue: queueName, exchange: "logs", routingKey: "key-1901");

            //定义消费者
            var consumer = new EventingBasicConsumer(channel);

            consumer.Received += (o, e) => {
                //消息内容
                var body = e.Body.ToArray();

                //转成字符串
                var message = Encoding.UTF8.GetString(body);

                //用消息
                logger.LogInformation("+++++++++收到消息++++++++++");
                logger.LogInformation(message);

                //睡眠1秒
                Thread.Sleep(TimeSpan.FromSeconds(1));

                //确认收到消息
                channel.BasicAck(e.DeliveryTag, false);

                //下单业务逻辑
            };

            //消费消息
            channel.BasicConsume(queue: queueName,
                            autoAck: false, //手动应答
                            consumer: consumer);
            

            return Task.CompletedTask;
        }
    }
}
