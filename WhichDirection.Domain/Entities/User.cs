using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhichDirection.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        /// <summary>
        /// 姓名
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 登录名
        /// </summary>
        [Required(ErrorMessage = "必填项")]
        public string LoginName { get; set; }

        [Required(ErrorMessage = "必填项")]
        public string Pwd { get; set; }
        /// <summary>
        /// 是否为老师
        /// </summary>
        public bool IsTeacher { get; set; }
    }
}
