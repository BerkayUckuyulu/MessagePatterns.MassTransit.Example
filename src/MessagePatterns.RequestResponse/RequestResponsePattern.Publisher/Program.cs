// See https://aka.ms/new-console-template for more information
using MassTransit;
using MessagePatterns.Shared.Helpers;
using MessagePatterns.Shared.Messages.Concrete;

Console.WriteLine("Request-Response Publisher");


#region

// Yollanan mesaj sonucunda consumerdan bir response beklenen mesaj desenidir.
// gönderilen mesajın sonucunda bir response geleceği için rabbitMq tarafından bir queue daha oluşturulması gerekiyor. Bu queue oluşturma işlemini massTransit arkaplanda uniq olarak yönetiyor.

//TODO massTransitin default exchange yapısı fanout exchange, bu şekilde kullanıldığında request-response queuesunu dinleyen tüm consumerlar mesajı işleyecek ve bir response dönecek. Consumerlardan response döndüğü durumda bu responseları işleyecebilecek workQueue tasarımında consumerlar yaratılabilir mi incelenecek. Yani mesajın responsu sadece gönderildiği yerden değil de hem gönderildiği yerden hem de başka consumerlar tarafından tüketilebilir mi ?

//TODO response mesajları taşıyan exchange'in exchange tipinin nereden değiştirilebilindiğine bakılmalı.

#endregion

var bus = BusHelper.GetBus();

await bus.StartAsync();

var requestClient = bus.CreateRequestClient<RequestResponseRequestModel>(new($"{RabbitMqConfigurationHelper.RabbitMqUri}/request-response"), default);

int i = 1;

while (i < 100)
{
    var response = await requestClient.GetResponse<RequestResponseResponseModel>(new RequestResponseRequestModel() { MessageNo = ++i, Text = $"message - {i}" });

    Console.WriteLine(response.Message.Text);
    await Task.Delay(500);
}
