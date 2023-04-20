﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgenciaTurismo.Models;
using AgenciaTurismo.Services;

namespace AgenciaTurismo.Controllers
{
    public class PackageController
    {
        public int Insert(Package package)
        {
            return new PackageService().Insert(package);
        }

        public List<Package> FindAll()
        {
            return new PackageService().FindAll();
        }

        public int Update(Package package)
        {
            return new PackageService().Update(package);
        }

        public int Delete(Package package)
        {
            return new PackageService().Delete(package);
        }


    }
}
