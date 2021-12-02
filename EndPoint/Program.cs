using App.DataBase;
using App.Services.AddNewContact;
using App.Services.DeleteContact;
using App.Services.EditConatct;
using App.Services.GetContactDetails;
using App.Services.GetListContact;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI_WinForm.Forms;

namespace EndPoint
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; set; }

        static void ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddScoped<IDataBaseContext, DataBaseContext>();
            services.AddScoped<IAddNewContactService, AddNewContactService>();
            services.AddScoped<IGetListContactService, GetListContactService>();
            services.AddTransient<IDeleteContactService, DeleteContactService>();
            services.AddTransient<IGetContactDetailsService, GetContactDetailsService>();
            services.AddTransient<IEditConatctService, EditContactService>();
            services.AddDbContext<DataBaseContext>();

            ServiceProvider = services.BuildServiceProvider();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigureServices();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceGetList = (IGetListContactService)ServiceProvider.GetService(typeof(IGetListContactService));
            var serviceDelete = (IDeleteContactService)ServiceProvider.GetService(typeof(IDeleteContactService));
            var serviceDetails = (IGetContactDetailsService)ServiceProvider.GetService(typeof(IGetContactDetailsService));
            var serviceEdit = (IEditConatctService)ServiceProvider.GetService(typeof(IEditConatctService));
            Application.Run(new frmMain(serviceGetList, serviceDelete, serviceDetails, serviceEdit));
        }
    }
}
