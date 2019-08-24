using Microsoft.Azure.Cosmos;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;


namespace CosmosDB
{
    class Program
    {
        private static readonly string _endpointUri = "";
        private static readonly string _primaryKey = "";
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            await Console.Out.WriteLineAsync($"Start Time:\t{DateTime.Now.ToShortTimeString()}");

            using (CosmosClient client = new CosmosClient(_endpointUri, _primaryKey))
            {
                DatabaseResponse databaseResponse = await client.CreateDatabaseIfNotExistsAsync("EntertainmentDatabase");
                Database targetDatabase = databaseResponse.Database;
                await Console.Out.WriteLineAsync($"Database Id:\t{targetDatabase.Id}");

                IndexingPolicy indexingPolicy = new IndexingPolicy
                {
                    IndexingMode = IndexingMode.Consistent,
                    Automatic = true,
                    IncludedPaths =
                    {
                        new IncludedPath
                        {
                            Path = "/*"
                        }
                    }
                };

                var containerProperties = new ContainerProperties("CustomCollection", "/medium")
                {
                    IndexingPolicy = indexingPolicy
                };

                var containerResponse = await targetDatabase.CreateContainerIfNotExistsAsync(containerProperties, 10000);
                var customContainer = containerResponse.Container;
                await Console.Out.WriteLineAsync($"Custom Container Id:\t{customContainer.Id}");

                var foodInteractions = new Bogus.Faker<PurchaseFoodOrBeverage>()
                    .RuleFor(i => i.Id, (fake) => Guid.NewGuid().ToString())
                    .RuleFor(i => i.medium, (fake) => nameof(PurchaseFoodOrBeverage))
                    .RuleFor(i => i.unitPrice, (fake) => Math.Round(fake.Random.Decimal(1.99m, 15.99m), 2))
                    .RuleFor(i => i.dayOfWeek, (fake) => fake.PickRandom(new List<string> { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday" }))
                    .RuleFor(i => i.quantity, (fake) => fake.Random.Number(1, 5))
                    .RuleFor(i => i.totalPrice, (fake, user) => Math.Round(user.unitPrice * user.quantity, 2))
                    .Generate(500);
                foreach (var interaction in foodInteractions)
                {
                    var itemResponse = await customContainer.CreateItemAsync(interaction);
                    var customItem = itemResponse.Resource;
                    await Console.Out.WriteLineAsync($"Item Id:\t{customItem.Id}");
                }

                var tvInteractions = new Bogus.Faker<WatchLiveTelevisionChannel>()
                    .RuleFor(i => i.Id, (fake) => Guid.NewGuid().ToString())
                    .RuleFor(i => i.medium, (fake) => nameof(WatchLiveTelevisionChannel))
                    .RuleFor(i => i.minutesViewed, (fake) => fake.Random.Number(1, 45))
                    .RuleFor(i => i.channelName, (fake) => fake.PickRandom(new List<string> { "NEWS-6", "DRAMA-15", "ACTION-12", "DOCUMENTARY-4", "SPORTS-8" }))
                    .RuleFor(i => i.dayOfWeek, (fake) => fake.PickRandom(new List<string> { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" }))
                    .Generate(500);
                foreach (var interaction in tvInteractions)
                {
                    var itemResponse = await customContainer.CreateItemAsync(interaction);
                    var customItem = itemResponse.Resource;
                    await Console.Out.WriteLineAsync($"Item Id:\t{customItem.Id}");
                }

            }
            await Console.Out.WriteLineAsync($"End Time:\t{DateTime.Now.ToShortTimeString()}");
        }
    }
}
