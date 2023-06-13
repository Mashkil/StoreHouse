using Microsoft.EntityFrameworkCore;
using StoreHouse.Enums;
using StoreHouse.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreHouse.Model
{
    public static class DatabaseCommunication
    {
        public static async Task SoldItems(int itemId)
        {
            using (StoreHouseContext contex = new())
            {
                var itemToSold = await contex.Items.FirstOrDefaultAsync(e => e.Id == itemId);

                if (itemToSold != null)
                    itemToSold.Status = Enums.Status.Sold;

                await contex.SaveChangesAsync();
            }
        }

        public static async Task<List<Item>> GetItems(Status status)
        {
            using (StoreHouseContext contex = new())
            {
                var items = await contex.Items.Where(e => e.Status == status).ToListAsync();

                return items;
            }
        }
        public static async Task AddItem(Item item)
        {
            using (StoreHouseContext contex = new())
            {
                contex.Items.Add(item);
                
                await contex.SaveChangesAsync();
                
                contex.ChangeStatuses.Add(new ChangeStatus
                {
                    From = Status.Accepted,
                    To = Status.Accepted,
                    ItemId = item.Id,
                    TimeOfChange = DateTimeOffset.UtcNow
                });

                await contex.SaveChangesAsync();
            }
        }

        public static async Task<List<ChangeStatus>> CreateReport(bool all, bool accepted, bool onStore, bool sold, DateTimeOffset from, DateTimeOffset to)
        {
            List<ChangeStatus> itemsToReport = new List<ChangeStatus>();

            using (StoreHouseContext context = new())
            {
                if (all)
                    itemsToReport = await context.ChangeStatuses.Include(e => e.Item).Where(e => e.TimeOfChange >= from && e.TimeOfChange <= to).ToListAsync();

                else
                {
                    if (accepted)
                        itemsToReport.AddRange(await context.ChangeStatuses
                            .Include(e => e.Item)
                            .Where(e => e.To == Status.Accepted && (e.TimeOfChange >= from && e.TimeOfChange <= to))
                            .ToListAsync());

                    if (onStore)
                        itemsToReport.AddRange(await context.ChangeStatuses
                            .Include(e => e.Item)
                            .Where(e => e.To == Status.OnStoreHouse && (e.TimeOfChange >= from && e.TimeOfChange <= to))
                            .ToListAsync());

                    if (sold)
                        itemsToReport.AddRange(await context.ChangeStatuses
                            .Include(e => e.Item)
                            .Where(e => e.To == Status.Sold && (e.TimeOfChange >= from && e.TimeOfChange <= to))
                            .ToListAsync());
                }

                return itemsToReport;
            }
        }

        public static async Task Sold(int id)
        {
            using (StoreHouseContext context = new StoreHouseContext())
            {
                var item = await context.Items.FirstOrDefaultAsync(e => e.Id == id);

                context.ChangeStatuses.Add(new ChangeStatus
                {
                    TimeOfChange = DateTimeOffset.UtcNow,
                    From = item.Status,
                    To = Status.Sold,
                    ItemId = item.Id
                });

                item.Status = Status.Sold;

                await context.SaveChangesAsync();
            }
        }

        public static async Task ToStore(int id)
        {
            using (StoreHouseContext context = new StoreHouseContext())
            {
                var item = await context.Items.FirstOrDefaultAsync(e => e.Id == id);

                context.ChangeStatuses.Add(new ChangeStatus
                {
                    TimeOfChange = DateTimeOffset.UtcNow,
                    From = item.Status,
                    To = Status.OnStoreHouse,
                    ItemId = item.Id
                });

                item.Status = Status.OnStoreHouse;

                await context.SaveChangesAsync();
            }
        }
    }
}
