﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace BUS
{
    public interface IXetNghiemBUS
    {
        IList<XetNghiem> GetAll();
    }
}
