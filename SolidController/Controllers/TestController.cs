using DependencyInversion.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SolidController.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IGenericRepository _genericRepository;
        public TestController(IGenericRepository genericRepository)
        {
            _genericRepository = genericRepository;
        }

        /// <summary>
        /// trường hợp ko sử dụng abstraction 
        /// </summary>
        /// <returns></returns>
        [HttpGet("high-cohesion")]
        public IActionResult TestMethodSecond()
        {
            // Phụ thuộc vào class DependencyInversion.MySQL.GenericRepository 
            // Nếu muốn sử dụng database MongoDB thì phải sửa code class này thì có 2 trường hợp xảy ra
            // - Nếu sửa trực tiếp code mà không tạo repository mới thì sẽ
            // khó viết unit test cho method này vì phụ thuộc vào tính đúng sai của class mới và tên không đúng
            // phải sửa lại tên namespace ở tất cả class dùng nó
            // - Nếu tạo repository mới mà project có rất nhiều nơi đang dùng repository cũ thì ta sẽ phải sửa tên class
            // ở tất cả
            // => khó báo trì & dễ bug nếu sửa thiếu
            DependencyInversion.MySQL.GenericRepository genericRepository = new();
            genericRepository.Update();
            return Ok(StatusCodes.Status200OK);
        }

        [HttpGet("loose-coupling")]
        public IActionResult TestMethod()
        {
            // Thay vào đó ta dùng interface và không cần quan tâm nó được implement thế nào 
            // nếu cần thay đổi CSDL ta chỉ cần viết thêm repository implement interface đó 
            // (tuân thủ nguyên lý số 2 open for extension, closed for modification :)))
            _genericRepository.Update();
            return Ok(StatusCodes.Status200OK);
        }
    }
}
