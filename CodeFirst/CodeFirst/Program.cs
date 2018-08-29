using System;
using CodeFirst.Models;
using CodeFirst.Controller;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        BaseContext _context = new BaseContext();
       public static void Main(string[] args)
        {
            int pilih;
            do
            {
                Console.Clear();
                Console.WriteLine("=======MENU=======");
                Console.WriteLine("1. Employee");
                Console.WriteLine("2. Data Overtime");
                Console.WriteLine("3. Department");
                Console.WriteLine("4. Role");
                Console.WriteLine("5. Customer");                
                Console.WriteLine("6. Tax");
                Console.WriteLine("7. Tipe Overtime");
                Console.WriteLine("8. Exit");
                Console.WriteLine("==================");
                Console.Write("Pilih Action : ");
                pilih = Convert.ToInt32(System.Console.ReadLine());
                switch (pilih)
                {
                    case 1:
                        EmployeeController callEmp = new EmployeeController();
                        callEmp.Menu();
                        break;
                    case 2:
                        DataOvertimeController callDOV = new DataOvertimeController();
                        callDOV.Menu();
                        break;
                    case 3:
                        DepartmentController callDept = new DepartmentController();
                        callDept.Menu();
                        break;
                    case 4:
                        RoleController callRole = new RoleController();
                        callRole.Menu();
                        break;
                    case 5:
                        CustomerController callCust = new CustomerController();
                        callCust.Menu();
                        break;
                    case 6:
                        TaxController callTax = new TaxController();
                        callTax.Menu();
                        break;
                    case 7:
                        TypeOvertimeController callType = new TypeOvertimeController();
                        break;
                    default:
                        System.Console.Write("Exit Cuy!");
                        System.Console.Read();
                        break;
                }
            } while (pilih != 2);
        }

        
    }
}
