using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.EntityFrameworkCore;
using NotifyChanged_FK.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NotifyChanged_FK.ViewModel
{
    public partial class CompanyVM : ObservableObject
    {
        private CompanyContext ctx;
        public ICollectionView EmployeeView { get; set; }
        public ICollectionView DepartmentView { get; set; }
        [ObservableProperty]
        public Employee? selectedEmployee;
        public CompanyVM()
        {
            ctx = new CompanyContext();
            ctx.Departments.Load();
            ctx.Employees.Load();
            EmployeeView = CollectionViewSource.GetDefaultView(ctx.Employees.Local.ToObservableCollection());
        }
    }
}
