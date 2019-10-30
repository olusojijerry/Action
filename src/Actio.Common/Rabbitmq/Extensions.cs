using Actio.Common.Commands;
using Actio.Common.Event;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Instantiation;
using RawRabbit.Pipe;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Actio.Common.Rabbitmq
{
	public static class Extensions
	{
		public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
			ICommandHandler<TCommand> handler) where TCommand : ICommand
			=> bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
				ctx => ctx.UseConsumerConfiguration(cfg =>
				cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));

		public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
			IEventhandler<TEvent> handler) where TEvent : IEvent
			=> bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
				ctx => ctx.UseConsumerConfiguration(cfg =>
				cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));

		private static string GetQueueName<T>()
			=> $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";

		public static void AddRabbitMq(this IServiceCollection service, IConfiguration configuration)
		{
			var options = new RabbitMqOptions();
			var section = configuration.GetSection("rabbitmq");
			section.Bind(options);
			var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
			{
				ClientConfiguration = options
			});

			service.AddSingleton<IBusClient>(_ => client);

		}
	}
}
