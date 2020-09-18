using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ViewComponentSample.ViewComponents
{
    public class MyListViewComponent : ViewComponent
    {
        //private readonly MyDbContext db;

        //public MyListViewComponent(MyDbContext context)
        //{
        //    db = context;
        //}

        public async Task<IViewComponentResult> InvokeAsync(string extraInfo)
        {
            var items = await GetItemsAsync(extraInfo);
            return View(items);
        }
        private Task<List<string>> GetItemsAsync(string extraInfo)
        {
            return Task.FromResult(new List<string>(new string[] { "aaa", "bbbb", "ccc", extraInfo }));
        }
    }
}