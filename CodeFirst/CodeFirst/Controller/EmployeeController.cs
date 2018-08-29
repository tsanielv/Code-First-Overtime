using System;
using CodeFirst.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Controller
{
    class EmployeeController
    {
        BaseContext _context = new BaseContext();
        public void Menu()
        {
            BaseContext _context = new BaseContext();
            int input;

            System.Console.WriteLine("====================================");
            Console.WriteLine("1. Insert Data Type Overtime");
            Console.WriteLine("2. Lihat  Data Semua Type Overtime");
            Console.WriteLine("3. Get By ID Type Overtime");
            Console.WriteLine("4. Update Data Type Overtime");
            Console.WriteLine("5. Delete Data Type Overtime");
            Console.WriteLine("====================================");
            Console.Write("Pilih Menu = ");
            int pilih = Convert.ToInt32(Console.ReadLine());

            switch (pilih)
            {
                case 1:
                    Insert();
                    Console.ReadKey();
                    break;

                case 2:
                    GetAll();
                    Console.ReadKey();
                    break;

                case 3:
                    Console.Clear();
                    Console.Write("Masukkan Kode Karyawan yang dicari : ");
                    input = Convert.ToInt32(Console.ReadLine());
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.Write("Masukkan Id yang dicari : ");
                    input = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("===========================");
                    Console.WriteLine("Data Sebelum Diubah");
                    Console.WriteLine("===========================");
                    GetById(input);
                    Console.WriteLine("===========================");
                    Update(input);
                    Console.WriteLine("===========================");
                    Console.WriteLine("Data Setelah Diubah");
                    Console.WriteLine("===========================");
                    GetById(input);
                    Console.WriteLine("===========================");
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.Write("Masukkan Id yang didihapus : ");
                    input = Convert.ToInt32(Console.ReadLine());
                    Delete(input);
                    Console.ReadKey();
                    break;
            }
        }


        public void Insert()
        {

            Console.Write("Masukkan Nama           : ");
            string name_employee = Console.ReadLine();
            Console.Write("Masukkan Alamat         : ");
            string address_employee = Console.ReadLine();
            Console.Write("Masukkan Gender         : ");
            string gender_employee = Console.ReadLine();
            Console.Write("Masukkan Email          : ");
            string email_employee = Console.ReadLine();
            Console.Write("Masukkan Password       : ");
            string password_emlpoyee = Console.ReadLine();
            Console.Write("Masukkan Salary         : ");
            int salary_employee = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Department ID  : ");
            int department_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Role ID        : ");
            int role_id = Convert.ToInt32(Console.ReadLine());

            Employee employee = new Employee()
            {
                name = name_employee,
                address = address_employee,
                gender = gender_employee,
                email = email_employee,
                password = password_emlpoyee,
                salary = salary_employee,
                departmentsId = department_id,
                rolesId = role_id
            };
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.Write(e.InnerException);
                Console.Write(e.Message);
                Console.Write(e.StackTrace);
            }
        }

        public List<Employee> GetAll()
        {
            Console.Clear();

            var getAll = _context.Employees.ToList();
            var d = (from Employee in _context.Employees
                     join Department in _context.Departments on Employee.departmentsId equals Department.id
                     join Role in _context.Roles on Employee.rolesId equals Role.id
                     select new { Employee.name, Employee.address, Employee.gender, Employee.email, Employee.password, Employee.salary, dname = Department.name, rname = Role.name }).ToList();
            for (int i = 0; i <= d.Count(); i++)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Nama       : " + d[i].name);
                Console.WriteLine("Address    : " + d[i].address);
                Console.WriteLine("Gender     : " + d[i].gender);
                Console.WriteLine("Email      : " + d[i].email);
                Console.WriteLine("Password   : " + d[i].password);
                Console.WriteLine("Salary     : " + d[i].salary);
                Console.WriteLine("Department : " + d[i].dname);
                Console.WriteLine("Role       : " + d[i].rname);
                Console.WriteLine("-------------------------");
            }

            return getAll;
        }


        //Method GetById untuk mencari data karyawan berdasarkan id dengan parameter inputan user
        public Employee GetById(int input)
        {
            Console.Clear();

            var employee = _context.Employees.FirstOrDefault(j => j.id == input);
            var d = (from Employee in _context.Employees
                     join Department in _context.Departments on Employee.departmentsId equals Department.id
                     join Role in _context.Roles on Employee.rolesId equals Role.id
                     select new { Employee.name, Employee.address, Employee.gender, Employee.email, Employee.password, Employee.salary, dname = Department.name, rname = Role.name }).ToList();
            for (int i = 0; i <= d.Count(); i++)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("Nama       : " + d[i].name);
                Console.WriteLine("Address    : " + d[i].address);
                Console.WriteLine("Gender     : " + d[i].gender);
                Console.WriteLine("Email      : " + d[i].email);
                Console.WriteLine("Password   : " + d[i].password);
                Console.WriteLine("Salary     : " + d[i].salary);
                Console.WriteLine("Department : " + d[i].dname);
                Console.WriteLine("Role       : " + d[i].rname);
                Console.WriteLine("-------------------------");
            }

            return employee;
        }


        //method searchId untuk mencari data berdasarkan id yang nantinya akan di update (semacam input where-nya gitu deh)
        public Employee searchId(int input)
        {
            var employee = _context.Employees.Find(input);
            if (employee == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }

            return employee;
        }


        //Method Update untuk update tabel Role dengan parameter id variabel input (inputan user)
        public int Update(int input)
        {
            //memasukkan data baru
            Console.Write("Masukkan Nama Baru           : ");
            string name_employee = Console.ReadLine();
            Console.Write("Masukkan Alamat Baru         : ");
            string address_employee = Console.ReadLine();
            Console.Write("Masukkan Gender Baru         : ");
            string gender_employee = Console.ReadLine();
            Console.Write("Masukkan Email Baru          : ");
            string email_employee = Console.ReadLine();
            Console.Write("Masukkan Password Baru       : ");
            string password_emlpoyee = Console.ReadLine();
            Console.Write("Masukkan Department ID Baru  : ");
            int department_id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Masukkan Role ID Baru        : ");
            int role_id = Convert.ToInt32(Console.ReadLine());

            var getemployee = _context.Employees.Find(input);
            if (getemployee == null)
            {
                Console.WriteLine("Id yang dicari tidak ada");
            }
            else
            {
                //proses penyimpanan ke database
                Employee employee = searchId(input);
                employee.name = name_employee;
                employee.address = address_employee;
                employee.gender = gender_employee;
                employee.email = email_employee;
                employee.password = password_emlpoyee;
                employee.departmentsId = department_id;
                employee.rolesId = role_id;

                _context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
            return input;
        }

        //Method Delete untuk menghapus data dengan parameter id variabel input (inputan user)
        public int Delete(int input)
        {
            Employee employee = _context.Employees.Find(input);
            _context.Entry(employee).State = System.Data.Entity.EntityState.Deleted;
            _context.SaveChanges();
            return input;
        }


    }
}